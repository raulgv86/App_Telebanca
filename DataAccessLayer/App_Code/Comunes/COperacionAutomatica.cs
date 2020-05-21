
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Collections.Generic;
using DataAccessLayer;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic.Devices;

/// <summary>
/// Summary description for COperacionAutomatica
/// </summary>
public class COperacionAutomatica
{

    private static Configuracion configuracion;
    private DataAccessLayer.DataHandler Handler;    
    private System.Threading.Timer A, B;
    Object Bloqueo = new Object();
    Object Bloqueo1 = new Object();
    Object Bloqueo2 = new Object();
    private bool empesoConciliaciones;
    private bool empesoPeticiones;
    private bool EstaEnConciliacionesTrans;


    public COperacionAutomatica()
    {
        Handler = new DataAccessLayer.DataHandler();
        configuracion = new Configuracion();
        empesoConciliaciones = false;
        empesoPeticiones = false; 
        Actualizar();
        ActualizarTrans();     
    
    }
    public void Actualizar()
    {
        try
        {
            if (B == null)
            {
                configuracion = Handler.GetConfiguracion();
                empesoConciliaciones = false;
                empesoPeticiones = false;
                int Interval = 1200000;         //Cada 20 minutos...
                int Espera = 200;
                //B = new Timer(new TimerCallback(EjecutarEspera), null, Espera, Interval);
            }
        }
        catch (Exception)
        {}    
    }

    public void ActualizarTrans()
    {
        try
        {
            if (A == null)
            {
                EstaEnConciliacionesTrans = false;
                int Interval = 1200000;         //Cada 20 minutos...
                int Espera = 200;
               // A = new Timer(new TimerCallback(EjecutarTransacciones), null, Espera, Interval);
            }
        }
        catch (Exception)
        { }
    }


    public void EjecutarEspera(Object Info)
    {
        DateTime now = DateTime.Now;
        try
        {
            lock (Bloqueo1)
            {
                if (now.Hour == configuracion.HoraConciliaciones.Hour && !empesoConciliaciones)
                {
                    empesoConciliaciones = true;
                    //this.EnviarConciliaciones();  
                    this.ConfirmarReimpresion();
                    this.ConfirmarDesabilitadas();
                    this.SolicitudesDeBajaDeTarjeta();
                    this.CofirmarOperacionesMultas();
                   
                }
                else
                    if (now.Hour != configuracion.HoraConciliaciones.Hour && empesoConciliaciones)
                        empesoConciliaciones = false;
                
            }
            lock (Bloqueo2)
            {
                if ((now.Hour == configuracion.HoraInicioPetic.Hour) && !empesoPeticiones)
                {
                    empesoPeticiones = true;
                    //Modificacion para que no capte automaticamnete los ficheros de pago complejo 23/04/08
                    //this.CofirmarOperacionesMultas();
                    //this.ProcesoFTPPagoComplejo();
                    //this.GestionarAutenticaciones();
                    //*************************************************************************************

                    //Modificacion para que envie automaticamente operaciones de multas en estado T:2 
                    //que sean confirmadas 23/04/08
                   
                    //*************************************************************************************
                }
                else
                    if (now.Hour != configuracion.HoraInicioPetic.Hour && empesoPeticiones)
                        empesoPeticiones = false;
            }
        }
        finally { }
    }

    public void EjecutarTransacciones(Object Info)
    {
        configuracion = Handler.GetConfiguracion();
        lock (Bloqueo)
        {
            DateTime FechaContableAnterior = Handler.FechaContableUltima();
            if (DateTime.Now.Hour == 12 && FechaContableAnterior <= DateTime.Today)
            {
                this.ConciliacionesAutomaticasRecTransac();
            }
        }

    }

   
    //-----I----//
    #region I
    //****************************************************************************************************
    public void SolicitudesDeBajaDeTarjeta()
    {   
        string m = EjecutarSolicitudesDeBajaDeTarjeta();
        if (m != null)
            Handler.GuardarNotificacion(m, "Administrador");
    }

    //***********************************************************************************************************
    public string EjecutarSolicitudesDeBajaDeTarjeta()
    {
        string noMatrices = "No existen matrices disponibles";
        string noWebService = "No se pudo establecer conexión con el Web Service del Banco";
        string mensaje; int desabilitadas = 0, pedidas = 0;

        List<BancoPersistente> bancos = new List<BancoPersistente>();
        try
        {
            bancos = Handler.ObtenerListaBanco();
        }
        catch (Exception)
        { return "No se pudo para obtener la lista de Bancos Asociados porque no hay conexión con la Base de datos"; }

        if (bancos.Count == 0)
        {
            Handler.GuardarNotificacion("No hay Bancos Asociados", "Administrador");
        }
        else
        {
            for (int i = 0; i < bancos.Count; i++)
            {
                List<TarjetaPersistente> lista = new List<TarjetaPersistente>();
                try
                {
                    lista = Handler.ConectWSBuscarTarjetasDarBaja(bancos[i]);
                }
                catch (Exception)
                {
                    Handler.GuardarNotificacion(noWebService + ": " + bancos[i].Nombre, "Administrador");
                }
                for (int j = 0; j < lista.Count; j++)
                {
                    TarjetaPersistente TempTarg = new TarjetaPersistente();
                    try
                    {
                        TempTarg = Handler.BuscarTarjeta(lista[j].IdNumeroTarjeta);
                    }
                    catch (Exception)
                    {
                        return "No se pudo verificar la existencia de la tarjeta del Banco: " + bancos[i].Nombre + " porque no hay conexión con la Base de Datos";

                    }

                    if (TempTarg.IdNumeroTarjeta != null)
                    {
                        string estadoanterior = TempTarg.Estado;
                        if (lista[j].Estado == "03")
                        {
                            TempTarg.Estado = "E";
                        }
                        //else
                        //    if (lista[j].Estado == "04")
                        //        TempTarg.Estado = "P";
                        if (estadoanterior != TempTarg.Estado)
                        {
                            try
                            {
                                Handler.ModificarTarjeta(TempTarg.IdNumeroTarjeta, TempTarg);
                            }
                            catch (Exception) { return "No se pudo modificar la tarjeta del Banco " + bancos[i].Nombre + " porque no hay conexión con la Base de Datos"; }
                        }
                    }
                }
                try
                {
                    //////desabilitadas = Handler.DeshabilitarTarjetas();
                }
                catch (Exception) { return "No se pudo desabilitar las tarjetas del Banco " + bancos[i].Nombre + " porque no hay conexión con la Base de Datos"; }

                List<TarjetaPersistente> tpedidas = new List<TarjetaPersistente>();
                try
                {
                   // tpedidas = Handler.BuscarTarjetasPorEstado("P");
                }
                catch (Exception) { return "No se pudo procesar las tarjetas en estado pedida del Banco " + bancos[i].Nombre + " porque no hay conexión con la Base de Datos"; }

                pedidas = 0;
                for (int j = 0; j < tpedidas.Count; j++)
                {
                    int matr = 0;
                    try
                    {
                        matr = Handler.CantidadDeMatricesDisponibles();
                    }
                    catch (Exception) { return "No se pudo verificar si existen matrices disponibles porque no hay conexión con la Base de Datos"; }
                    if (matr != 0)
                    {
                        try
                        {
                            Handler.GuardarTarjetaEnHistorico(tpedidas[j]);
                        }
                        catch (Exception) { return "No se pudo guardar los datos de la tarjeta del Banco; " + bancos[i].Nombre + "en el historico porque no hay conexión con la Base de Datos"; }

                        Random num = new Random();
                        tpedidas[j].NoPin = num.Next(1000, 10000).ToString();
                        tpedidas[j].Matriz = ObtenerNuevaMatriz();
                        tpedidas[j].Estado = "C";
                        tpedidas[j].EstadoPin = "C";
                        tpedidas[j].FechaOrdenImp = DateTime.Now;
                        try
                        {
                            Handler.ModificarTarjeta(tpedidas[j].IdNumeroTarjeta, tpedidas[j]);
                        }
                        catch (Exception) { return "No se pudo guardar los datos de la tarjeta del Banco; " + bancos[i].Nombre + " porque no hay conexión con la Base de Datos"; }
                        pedidas++;
                    }
                    else
                    {
                        Handler.GuardarNotificacion(noMatrices, "Administrador");
                        break;
                    }
                }
                if (desabilitadas != 0 || pedidas != 0)
                    mensaje = "Se deshabilitó " + desabilitadas.ToString() + " tarjeta(s) y se cambió " + pedidas.ToString() + " tarjeta(s) por otras nuevas del banco: " + bancos[i].Nombre;
                else
                    mensaje = "No se deshabilitaron ni se cambiaron tarjetas por otras nuevas en el banco: " + bancos[i].Nombre;
                try
                {
                    //Handler.GuardarNotificacion(mensaje, "Administrador");
                }
                catch (Exception) { return mensaje; }
            }
            try
            {
                //desabilitadas = Handler.CantidadDeTarjetasCambiadasEnElDiaDadoEstado("D");
            }
            catch (Exception) { return "No se pudo obtener las cantidad de bajas procesadas porque no hay conexión con la Base de Datos"; }
            try
            {
                //pedidas = Handler.CantidadDeTarjetasCambiadasEnElDiaDadoEstado("P");
            }
            catch (Exception) { return "No se pudo obtener las cantidad de tarjeta pedidas porque no hay conexión con la Base de Datos"; }

            if (desabilitadas != 0 || pedidas != 0)
                mensaje = "Se deshabilitó " + desabilitadas.ToString() + " tarjeta(s) y se cambió " + pedidas.ToString() + " tarjeta(s) por otras nuevas";
            else
                mensaje = "No se deshabilitaron ni se cambiaron tarjetas en el dia ";
            try
            {
                //Handler.GuardarNotificacion(mensaje, "Administrador");
            }
            catch (Exception) { return mensaje; }
        }
        return null;
    }

    public Matriz ObtenerNuevaMatriz()
    {
        List<Matriz> matrices = new List<Matriz>();
        matrices = Handler.Obtener10MatricDisponibles();
        Random num = new Random();
        int v = num.Next(0, matrices.Count);
        matrices[v].Estado = "ocupada";
        try
        {
            Handler.ModificarEstadoDeLaMatriz(matrices[v].ID, "ocupada");
        }
        catch (Exception e)
        {
            /*escribir en el log*/

            string path = @"C:\Logs_Telebanca\log_error.txt";

            using (TextWriter writer = File.AppendText(path))
            {
                string separador = " : ";
                string metodo_error = "ObtenerNuevaMatriz \n";
                string nombre_proyecto = "(BusinessLayer): ";
                string date = DateTime.Now.ToString();
                writer.WriteLine(date + separador + nombre_proyecto + metodo_error + e.Message);
                writer.WriteLine(separador + metodo_error + date);
            }

            throw new Exception("No se pudo poner la matriz en esta ocupada porque no hay conexión con la Base de Datos"); 
        }
        return matrices[v];
    }   
   

    #endregion
    //************************** CU_SOLICITUDES DE BAJA TARJETAS *****************************
    //PROGRAMADOR: <ARREGLADO> 11/10/2006
    //----II----//
    #region II
    //********** INICIO ************* CU_CREAR AUTENTICACIONES *****************************************************
    //PROGRAMADOR: Edisbel
    //REV 12/9/2006
    public void GestionarAutenticaciones()
    {
        int C = 0;
        bool agotadas = false;
        try
        {
            List<string> TDB = new List<string>();
            List<BancoPersistente> LB = Handler.ObtenerListaBanco();
            if (LB.Count == 0)
            {
                throw new Exception("No Existen Bancos Asociados en la BD");
            }

            foreach (BancoPersistente i in LB)
            {
                List<TarjetaPersistente> LAP = new List<TarjetaPersistente>();
                List<TarjetaPersistente> LBanco = new List<TarjetaPersistente>();

                List<Matriz> MDB = Handler.ObtenerNuevasMatrices();
                if (MDB.Count == 0)
                {
                    throw new Exception("No hay matrices Disponibles en BD");
                }
                TDB = Handler.ObtenerIDTarjetas();

                List<Matriz> MActualizar = new List<Matriz>();
                List<TarjetaPersistente> TActualizar = new List<TarjetaPersistente>();
                try
                {
                    LBanco = Handler.ObtenerSolicitudes(i.NumBanco);
                    if (LBanco.Count == 0)
                    {
                        if (!Handler.GuardarNotificacion("No existen nuevas solicitudes del Banco: " + i.Nombre, "Operadora de Autenticacion"))
                            throw new Exception("No hay Conexion con la BD");                        
                    }
                    else
                    {
                        LAP.AddRange(LBanco);
                        foreach (string J in TDB)
                        {
                            foreach (TarjetaPersistente K in LBanco)
                                if (J == K.IdNumeroTarjeta)
                                    LAP.Remove(K);

                            if (LAP.Count == 0)
                                break;
                        }
                        LBanco = LAP;
                        Random RN = new Random(5713);
                        foreach (TarjetaPersistente j in LBanco)
                        {
                            if (Handler.ExisteTarjeta(j.IdNumeroTarjeta)) continue;
                            if (MDB.Count > LBanco.IndexOf(j))
                            {
                                j.FechaOrdenImp = DateTime.Now;
                                j.Matriz = MDB[LBanco.IndexOf(j)];
                                j.NoPin = RN.Next(1000, 9999).ToString();                                
                                j.Estado = "C";
                                j.EstadoPin = "creado";
                                MDB[LBanco.IndexOf(j)].Estado = "ocupada";

                                MActualizar.Add(MDB[LBanco.IndexOf(j)]);
                                TActualizar.Add(j);
                            }
                            else
                            {
                                agotadas = true;
                                break;
                            }
                        }
                        if (MActualizar.Count != 0 && TActualizar.Count != 0)
                        {
                            try
                            {
                                Handler.ActualizarSucursales();
                                Handler.GuardarTargetasProcesadas(TActualizar);
                                Handler.ActualizarEstadoMatrices(MActualizar);
                                C += TActualizar.Count;
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Error al Guardar Tarjetas o Actualizar Matrices del Banco: " + i.Nombre +
                                    " '" + e.Message + "'");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    if (!Handler.GuardarNotificacion(e.Message, "Operadora de Autenticacion"))
                    {
                        throw;
                    }
                }
                if (agotadas)
                {
                    throw new Exception("Matrices agotadas en BD");
                }
            }
            Handler.GuardarNotificacion("Se procesaron: " + C + " Solicitudes de Autenticacion", "Operadora de Autenticacion");

        }
        catch (Exception e)
        {
            Handler.GuardarNotificacion("Solicitud de Autenticaciones Cancelada: " + "'" + e.Message + "'",
                "Operadora de Autenticacion");
            Handler.GuardarNotificacion("Se procesaron: " + C + " Solicitudes de Autenticacion", "Operadora de Autenticacion");
        }
    }
    //********** FIN *************** CU_CREAR AUTENTICACIONES ***************************************************

    //********** INICIO ************ CU_CONCILIACIONES AUTOMATICAS **********************************************
    //PROGRAMADOR: Edisbel
    public void EnviarConciliaciones()
    {
        try
        {
            string[] DEVACTIVAS;
            string[] DEVCANCELADAS;
            string[] DEVCREADAS;

            List<BancoPersistente> LB = Handler.ObtenerListaBanco();
            if (LB.Count == 0)
            {
                throw new Exception("No existen Bancos Asociados en la BD");
            }

            foreach (BancoPersistente i in LB)
            {
                List<string> IDSTarjetasActivas = Handler.TarjetasDeBancoActivasEnFecha(DateTime.Now, i.NumBanco);
                if (IDSTarjetasActivas.Count == 0)
                {
                    if (!Handler.GuardarNotificacion("No hay tarjetas Activas en el dia para el Banco: " + i.Nombre, "Operadora de Autenticacion"))
                    {
                        Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay conexion con la BD", "Operadora de Autenticacion");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        DEVACTIVAS = Handler.EnviarConciliacionActivas(IDSTarjetasActivas.ToArray(), i.WebServices);
                        if (DEVACTIVAS.Length == 0)
                        {
                            if (!Handler.GuardarNotificacion("La Conciliación de Tarjetas Activas se ha enviado satisfactoriamente al Banco: " + i.Nombre,
                                "Operadora de Autenticacion"))
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay conexion con la BD", "Operadora de Autenticacion");
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                foreach (string j in DEVACTIVAS)
                                {
                                    Handler.UpdateEstadoTarjeta(j, "N");
                                }
                            }
                            catch (Exception)
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay Conexion con la BD",
                                    "Operadora de Autenticacion");
                                return;
                            }
                            if (!Handler.GuardarNotificacion("Existen Tarjetas no validas (Activas) del Banco: " + i.Nombre,
                                "Operadora de Autenticacion"))
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay Conexion con la BD",
                                    "Operadora de Autenticacion");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (!Handler.GuardarNotificacion("Conciliacion de Tarjetas Activas no enviada al Banco: " +
                            i.Nombre + ", no hay Conexion con el WebService", "Operadora de Autenticacion"))
                        {
                            throw new Exception("Conciliaciones Canceladas, no hay conexion con la BD");
                        }
                    }
                }
                List<string> IDSTarjetasCanceladas = Handler.TarjetasCanceladasEnDiaDeBanco(DateTime.Now, i.NumBanco);
                if (IDSTarjetasCanceladas.Count == 0)
                {
                    if (!Handler.GuardarNotificacion("No hay tarjetas con el estado “Pedida” o “Deshabilitada”" +
                        " en el día en el histórico para el Banco: " + i.Nombre, "Operadora de Autenticacion"))
                    {
                        Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay conexion con la BD", "Operadora de Autenticacion");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        DEVCANCELADAS = Handler.EnviarConciliacionCanceladas(IDSTarjetasCanceladas.ToArray(), i.WebServices);
                        if (DEVCANCELADAS.Length == 0)
                        {
                            if (!Handler.GuardarNotificacion("La Conciliación de Tarjetas Canceladas se ha enviado satisfactoriamente al Banco: " + i.Nombre,
                                "Operadora de Autenticacion"))
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay conexion con la BD", "Operadora de Autenticacion");
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                foreach (string j in DEVCANCELADAS)
                                {
                                    //Handler.UpdateEstadoTarjetaHistorico(j, "N");
                                   Handler.UpdateEstadoTarjeta(j, "N");
                                }
                            }
                            catch (Exception)
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay Conexion con la BD",
                                    "Operadora de Autenticacion");
                                return;
                            }
                            if (!Handler.GuardarNotificacion("Existen Tarjetas no validas (Canceladas) del Banco: " + i.Nombre,
                                "Operadora de Autenticacion"))
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay Conexion con la BD",
                                    "Operadora de Autenticacion");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (!Handler.GuardarNotificacion("Conciliacion de Tarjetas Canceladas no enviada al Banco: " +
                           i.Nombre + ", no hay Conexion con el WebService", "Operadora de Autenticacion"))
                        {
                            throw new Exception("Conciliaciones Canceladas, no hay conexion con la BD");
                        }
                    }

                }
                List<string> IDSTarjetasCreadas = Handler.TarjetasDeBancoCreadasEnDia(DateTime.Now, i.NumBanco);
                if (IDSTarjetasCreadas.Count == 0)
                {
                    if (!Handler.GuardarNotificacion("No hay tarjetas con el estado “Creada” para el Banco: " + i.Nombre,
                        "Operadora de Autenticacion"))
                    {
                        Handler.GuardarNotificacion("No hay tarjetas con el estado “Pedida” o “Deshabilitada”" +
                         " en el día en el histórico para el Banco: " + i.Nombre, "Operadora de Autenticacion");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        DEVCREADAS = Handler.EnviarConciliacionCreadas(IDSTarjetasCreadas.ToArray(), i.WebServices);
                        if (DEVCREADAS.Length == 0)
                        {
                            if (!Handler.GuardarNotificacion("La Conciliación de Tarjetas Creadas se ha enviado satisfactoriamente al Banco: " + i.Nombre,
                                "Operadora de Autenticacion"))
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay conexion con la BD", "Operadora de Autententicacion");
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                foreach (string j in DEVCREADAS)
                                {
                                    Handler.UpdateEstadoTarjetaHistorico(j, "N");
                                }
                            }
                            catch (Exception)
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay Conexion con la BD",
                                    "Operadora de Autenticacion");
                                return;
                            }
                            if (!Handler.GuardarNotificacion("Existen Tarjetas no validas (Canceladas) del Banco: " + i.Nombre,
                                "Operadora de Autenticacion"))
                            {
                                Handler.GuardarNotificacion("Conciliaciones Canceladas, no hay Conexion con la BD",
                                    "Operadora de Autenticacion");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        /*escribir en el log*/

                        string path = @"C:\Logs_Telebanca\log_error.txt";

                        using (TextWriter writer = File.AppendText(path))
                        {
                            string separador = " : ";
                            string metodo_error = "EnviarConciliaciones \n";
                            string nombre_proyecto = "(BusinessLayer): ";
                            string date = DateTime.Now.ToString();
                            writer.WriteLine(date + separador + nombre_proyecto + metodo_error + e.Message);
                            writer.WriteLine(separador + metodo_error + date);
                        }

                        if (!Handler.GuardarNotificacion("Conciliacion de Tarjetas Creadas no enviada al Banco" +
                           i.Nombre + ", no hay Conexion con el WebService", "Operadora de Autenticacion"))
                        {
                            throw new Exception("Conciliaciones Canceladas, no hay conexion con la BD");
                        }
                    }
                }
            }
        }
        catch (Exception eX)
        {
            Handler.GuardarNotificacion(eX.Message, "Operadora de Autenticacion");
        }

    }//OK REV 14/9/2006
    //********** FIN ************ CU_CONCILIACIONES AUTOMATICAS **********************************************
    #endregion

    //---III----//

    #region III
    public void ProcesoFTPPagoComplejo(DateTime fecha)
    {
        string fich = "C:\\Inetpub\\wwwroot\\Telebanca\\Ficheros\\MensajeEmergenciaFTP\\"; //System.Web.SiteMap().  
        DirectoryInfo directorio = new DirectoryInfo(fich);
        if (!directorio.Exists)
        {
            directorio.Create();
        }

        string directorioFTP = "C:\\Inetpub\\wwwroot\\Telebanca\\Ficheros\\DirectorioTempDescargaFTP\\";
        directorio = new DirectoryInfo(directorioFTP);
        if (!directorio.Exists)
        {
            directorio.Create();
        }
  



        try
        {
            ManipuladorFTP mFTP = new ManipuladorFTP();
            mFTP.UsuarioFTP = configuracion.UsuarioFTP;
            mFTP.ClaveUsuarioFTP = configuracion.ContraseñaFTP;
            mFTP.DireccionServidor = configuracion.DireccionServidorFtp;
            mFTP.DireccionServBD = configuracion.DireccServBD; // Raul
            mFTP.Usuario_BD = configuracion.UsuarioBD; // Raul
            mFTP.Contrasena_BD = configuracion.ContrasenaBD; // Raul

            //ServicioComplejo.DirFicheroReporte = fich;

            List<string> codigos = Handler.ObtenerServiciosPorTipo("02");
            foreach (string aux in codigos)
            {
                string nombServ = Handler.BuscarNombreServ(aux);
                nombServ = "/" + nombServ.ToUpper()+ "/" + nombServ + "/";
                //ServicioComplejo serv = new ServicioComplejo(Handler, aux, directorioFTP, nombServ);
                ServicioComplejo serv = new ServicioComplejo(Handler, aux, directorioFTP, nombServ,""); //Raul
                serv.ManipuladorFTP = mFTP;
              //  serv.DirFicheroReporte = fich;
                serv.Proceso(fecha);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool ProcesoFTPPagoComplejo(string IdServicio, DateTime fecha)
    {

        bool result_ftp = false;
        string fich = "C:\\Empresas\\" + IdServicio + "\\"; //System.Web.SiteMap().  
        DirectoryInfo directorio = new DirectoryInfo(fich);
        string nombServ = "";
        //if (!directorio.Exists)
        //{
        //    directorio.Create();
        //}

        string directorioFTP = "C:\\Empresas\\" + IdServicio + "\\";
        directorio = new DirectoryInfo(directorioFTP);

        
        //if (!directorio.Exists)
        //{
        //    directorio.Create();
        //}

        try
        {
            ManipuladorFTP mFTP = new ManipuladorFTP();
            mFTP.UsuarioFTP = configuracion.UsuarioFTP;
            mFTP.ClaveUsuarioFTP = configuracion.ContraseñaFTP;
            mFTP.DireccionServidor = configuracion.DireccionServidorFtp;

            #region Modificaciones Raul
           

            // CAMBIO RELIZADO POR RAUL PARA PROBAR LA CARGA DEL FICHERO A LA BD
              mFTP.DireccionServBD = configuracion.DireccServBD;
            //mFTP.Usuario_BD = configuracion.UsuarioBD;
            //mFTP.Contrasena_BD = configuracion.ContrasenaBD;

            string directorio_rutaBD = @"\\"+ mFTP.DireccionServBD.ToString()+ @"\C$\Empresas\" + IdServicio + @"\";

            #endregion 

            //ServicioComplejo.DirFicheroReporte = fich;

            List<string> codigos = Handler.ObtenerServiciosPorTipo("02");
            if (codigos.IndexOf(IdServicio) < 0) return false;

            nombServ = Handler.BuscarNombreServ(IdServicio);
            nombServ = "//" + nombServ.ToUpper() + "//" + nombServ + "//";

            //ServicioComplejo serv = new ServicioComplejo(Handler, IdServicio, directorioFTP, nombServ);
            ServicioComplejo serv = new ServicioComplejo(Handler, IdServicio, directorioFTP, nombServ,directorio_rutaBD); // Raul

            serv.ManipuladorFTP = mFTP;
            if (serv.Proceso(fecha))
            {
                result_ftp = true;
            }
        }
        catch (Exception e)
        {
            /*escribir en el log*/

            string path = @"C:\Logs_Telebanca\log_error.txt";

            using (TextWriter writer = File.AppendText(path))
            {
                string separador = " : ";
                string metodo_error = "ProcesoFTPPagoComplejo \n";
                string nombre_proyecto = "(BusinessLayer): ";
                string date = DateTime.Now.ToString();
                writer.WriteLine(date + separador + nombre_proyecto + metodo_error + e.Message);
                writer.WriteLine(separador + metodo_error + date);
            }

            result_ftp = false;

            throw;
        }

        return result_ftp;
    }


    #endregion


    #region X
    public void ConciliacionesAutomaticasRecTransac()
    {
        DateTime FechaContableUltima;
        try
        {
            List<BancoPersistente> ListB = Handler.ObtenerListaBanco();
            if (ListB.Count > 0)
            {
                //**Modificacion para cambio de fecha 17/06/08  
                FechaContableUltima = Handler.FechaContableUltima();
                Handler.CambiarFechaContable(DateTime.Today.Add(new TimeSpan(1, 0, 0, 0)));
                try
                {
                    foreach (BancoPersistente BP in ListB)
                    {
                        /* if (*/
                        this.ConciliacionesAutomaticasTransacciones(BP, FechaContableUltima); /*&& !Handler.CambiarFechaContable(DateTime.Today.Add(new TimeSpan(1, 0, 0, 0))))*/
                        // Handler.CambiarFechaContable(Handler.FechaContableUltima().Add(new TimeSpan(1, 0, 0, 0)));
                        this.ConciliacionesAutomaticasReclamaciones(BP);
                    }
                }
                catch(Exception)
                {
                    Handler.CambiarFechaContable(FechaContableUltima.Add(new TimeSpan(-1, 0, 0, 0)));
                }
            }
            else
            {          
                    Handler.GuardarNotificacion("No hay Bancos Asociados", "Administrador");
                    return;
            }
        Handler.GuardarNotificacion("Se han procesado todos los bancos asociados.", "Administrador");
            
        }//end try ObtenerListaBanco
        catch (Exception e)
        {
            /*escribir en el log*/

            string path = @"C:\Logs_Telebanca\log_error.txt";

            using (TextWriter writer = File.AppendText(path))
            {
                string separador = " : ";
                string metodo_error = "ConciliacionesAutomaticasRecTransac \n";
                string nombre_proyecto="(BusinessLayer): ";
                string date = DateTime.Now.ToString();
                writer.WriteLine(date+separador+nombre_proyecto+metodo_error+e.Message);
                writer.WriteLine(separador + metodo_error + date );
            }

            Handler.GuardarNotificacion("No se pudieron enviar las Conciliaciones a los Bancos Asociados", "Administrador"); 
        }

    }

    /****************************************************************************************************/

    //Transacciones diarias
    private bool ConciliacionesAutomaticasTransacciones(BancoPersistente B, DateTime FechaContableUltima)
    {
        try
        {
            
            if (Handler.EnviarTransaccionesenDia(FechaContableUltima, B.NumBanco)) //  envia las conciliaciones de tarjetas calientes al web service correspondiente   
            {               
                Handler.GuardarNotificacion("La Conciliación de Transacciones se ha enviado satisfactoriamente al Banco" + B.Nombre, "Administrador");               
            }
            else
            {
                Handler.GuardarNotificacion("No hay transacciones del Banco" + B.Nombre, "Administrador");
            }
        }
        catch (Exception)
        {
           Handler.GuardarNotificacion("La Conciliación de Transacciones no se pudo enviar al Banco " + B.Nombre, "Administrador");
           return false; 
        }
        return true;
    }


    /***************************************************************************************************/
    //Reclamaciones Diarias

    private void ConciliacionesAutomaticasReclamaciones(BancoPersistente B1)
    {
        try
        {
            if (Handler.EnviarReclamacionesenDia(DateTime.Now, B1.NumBanco)) // este metodo no se ha hecho... es el de enviar las reclamaciones...
            {
                Handler.GuardarNotificacion("La Conciliación de Reclamaciones se ha enviado satisfactoriamente al Banco" + B1.Nombre, "Administrador");                
            }
            else
            {
                Handler.GuardarNotificacion("No hay reclamaciones del banco: " + B1.Nombre, "Administrador");
            }
        }
        catch (Exception)
        {
            Handler.GuardarNotificacion("La Conciliación de Reclamaciones no se pudo enviar al Banco: " + B1.Nombre, "Administrador");
        }

    }
    #endregion    


    // ////Modificacion para que envie automaticamente operaciones de multas en estado T:2 
    //que sean confirmadas 23/04/08
    public void CofirmarOperacionesMultas()
    {
        string CI = "";
        //int InfPend = 0;
        string InfPendiente = "";
        int DigPend = 0;
        string DigPendiente = "";
        int FolPend = 0;
        string FolPendiente = "";
        int FPagoPend = 0;
        string FPagoPendiente = "";
        string Inf = "";
        int IDig = 0;
        string Dig = "";
        int IFol = 0;
        string Fol = "";
        int IFPago = 0; ;
        string FPago = "";
        string Id_transaccion = "";
        string ID = "";
        string Fecha = "";
        DataSet OperacionesConfirmadas;

        try
        {
            //Dataset para metro;
            OperacionesConfirmadas = new DataSet();
            DataTable Multas = new DataTable();
            Multas.TableName = "Multas";
            DataColumn Traza = new DataColumn();
            Traza.ColumnName = "Traza";
            DataColumn Id_serv = new DataColumn();
            Id_serv.ColumnName = "Id_serv";
            DataColumn Id_Cliente = new DataColumn();
            Id_Cliente.ColumnName = "Id_Cliente";
            DataColumn FechaPago = new DataColumn();
            FechaPago.ColumnName = "FechaPago";
            DataColumn Obs = new DataColumn();
            Obs.ColumnName = "Obs";
            Multas.Columns.Add(Traza);
            Multas.Columns.Add(Id_serv);
            Multas.Columns.Add(Id_Cliente);
            Multas.Columns.Add(FechaPago);
            Multas.Columns.Add(Obs);
            OperacionesConfirmadas.Tables.Add(Multas);
            
            
            DataSet MultasC = Handler.OperacionesMultasxConfirmar();
            foreach (DataRow row in MultasC.Tables[0].Rows)
            {
                Id_transaccion = row[0].ToString();
                CI = row[1].ToString();
                InfPendiente = row[3].ToString();
                DigPend = InfPendiente.IndexOf("DIG:");
                DigPendiente = InfPendiente.Substring(DigPend, 5);
                FolPend = InfPendiente.IndexOf("FOLIO:");
                FolPendiente = InfPendiente.Substring(FolPend, 14);
                FPagoPend = InfPendiente.IndexOf("FEC_IMP:");
                FPagoPendiente = InfPendiente.Substring(FPagoPend, 16);
                DateTime Fecha111 = Convert.ToDateTime(row[5]);
                /////////////////////Fecha = row[5].ToString();
                Fecha = Fecha111.ToString("yyyy-MM-ddTHH:mm:ss");
                DataSet MultasxId = Handler.OperacionesEnFicheroxCI(CI.Trim());
                foreach (DataRow row1 in MultasxId.Tables[0].Rows)
                {
                    Inf = row1[3].ToString();
                    IDig = Inf.IndexOf("DIG:");
                    Dig = Inf.Substring(IDig, 5);
                    IFol = Inf.IndexOf("FOLIO:");
                    Fol = Inf.Substring(IFol, 14);
                    IFPago = Inf.IndexOf("FEC_IMP:");
                    FPago = Inf.Substring(IFPago, 16);
                    ID = row1[0].ToString();

                    if (DigPendiente == Dig && FolPendiente == Fol && FPagoPendiente == FPago)
                    {
                        //Handler.ModificarOperacionesMultasPendientes(Id_transaccion);
                        //Handler.EliminarOperacionesdePagoComplejo(ID);
                        OperacionesConfirmadas.Tables[0].Rows.Add(Id_transaccion, "04", CI, Fecha, Inf + " T:2");

                    }
                }
            }
            //enviar a metro el dataset operacionesconfirmadas
             if (OperacionesConfirmadas.Tables[0].Rows.Count > 0)
                {
                    if (Handler.EnviarOperacionesConfirmadas(OperacionesConfirmadas))
                    {
                        foreach (DataRow row1 in OperacionesConfirmadas.Tables[0].Rows)
                        {
                            Handler.ModificarOperacionesMultasPendientes(row1[0].ToString());
                        }

                        Handler.GuardarNotificacion("Se enviaron " + OperacionesConfirmadas.Tables[0].Rows.Count.ToString() + " multas confirmadas T:2", "Operadora de Autenticacion");

                    }
                    else
                    {
                        Handler.GuardarNotificacion("Ocurrio un problema con el Web Service y no se pudieron actualizar las multas pendientes T:2", "Operadora de Autenticacion");
                    }
             }
             else
             {
                 Handler.GuardarNotificacion("No se encontraron Multas por confirmar T:2", "Operadora de Autenticacion");
             }
                       
        }
        catch (Exception e)
        {
            Handler.GuardarNotificacion(e.Message, "Operadora de Autenticacion");
        }
    }
    //*************************************************************************************


    public void ConfirmarReimpresion()
    {
        
        try
        {
            Handler.ConfirmarReimpresion();

        }
        catch (Exception e)
        {
            Handler.GuardarNotificacion(e.Message, "Operadora de Autenticacion");
        }
    }

    public void ConfirmarDesabilitadas()
    {

        try
        {
            Handler.ConfirmarDesabilitadas();

        }
        catch (Exception e)
        {
            Handler.GuardarNotificacion(e.Message, "Operadora de Autenticacion");
        }
    }

}
