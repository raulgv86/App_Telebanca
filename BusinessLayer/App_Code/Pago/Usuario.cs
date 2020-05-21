using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DataAccessLayer;
using System.Collections;
using System.Text;
using System.IO;
using System.Globalization;


/// <summary>
/// Summary description for Class1
/// </summary>    
public partial class Usuario : UsuarioPersistente
{
    private static Configuracion configuracion;
    Tarjeta tarjeta;
    List<Servicio> Servicios;
    List<ServicioPersistente> listaServ; //esta es la lista de los servicio que tiene Telebanca
    //se recarga cada vez que se inserta o modifica un servicio, desde el metodo ListaServiciosExistentes()
    // estos atrivutos viven en la sesion del usuario y posibilitan conextarse a la BD menos veces.

    public List<Dato> datosPago;

    //solo se usa en el pago complejo para guardar el id del Dato que represente a idCliente
    private string idCliente;

    public Tarjeta Tarjeta
    {
        get
        {
            return tarjeta;
        }
        set
        {
            tarjeta = value;
        }
    }

    #region  Pago

    public void ActualizarSucursales()
    {
      List<string> bancosNoActualizados =  Handler.ActualizarSucursales();
      if (bancosNoActualizados.Count > 0)
      {
          string mens = "No se pudieron actualizar los bancos: ";
          foreach (string str in bancosNoActualizados)
          {
              mens += str + ", ";
          }
          mens = mens.Substring(0, mens.Length - 2) + " ";
          throw new Exception(mens);
      }
      throw new Exception("Actualizacion realizada satisfactoriamente");
    }
   
    public string[] BuscarTarjetaPorCI(string CI)
    {//retorna los nombres y los numTarjeta
        if (Rol.Funcionalidades.Contains("Tarjeta Caliente"))
        {
            List<TarjetaPersistente> Listtp = new List<TarjetaPersistente>();
            try
            {
                Listtp = Handler.BuscarTarjetasPorCI(CI);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
            List<string> numerosTarjeta = new List<string>();
            foreach (TarjetaPersistente tp in Listtp)
            {
                if (numerosTarjeta.Count == 0)
                    numerosTarjeta.Add(tp.NombrePropietario + " " + tp.Apellidos);
                if (tp.Estado.Equals("A")||tp.Estado.Equals("C")) 
                    numerosTarjeta.Add(tp.IdNumeroTarjeta);
            }
            return numerosTarjeta.ToArray();
        }
        return new string[0];
    }
    public string ObtenerTarjeta(string numeroTarjeta)
    {
          try
            {
                tarjeta = new Tarjeta(Handler.BuscarTarjeta(numeroTarjeta));
                if (tarjeta.IdCliente == null)
                {
                    return "";
                }
              
                if ((tarjeta.IdCliente.Trim()) == (CarnetIdentidad.Trim()))
                {
                    return "operadora|" + tarjeta.Estado.Trim();
                }
                else
                {
                    return tarjeta.Estado.Trim();
                }
            }
            catch (Exception e)
            {
                throw e;//new Exception("Error al buscar coincidencia entre CI del Cliente y CI del Operador(a)");
            }
    }

    public string ObtenerEstado_Pin(string numeroTarjeta)
    {
        try
        {
            tarjeta = new Tarjeta(Handler.BuscarTarjeta(numeroTarjeta));
            if (tarjeta.IdCliente == null)
            {
                return "";
            }

            if ((tarjeta.IdCliente.Trim()) == (CarnetIdentidad.Trim()))
            {
                return "operadora|" + tarjeta.EstadoPin.Trim();
            }
            else
            {
                return tarjeta.EstadoPin.Trim();
            }
        }
        catch (Exception e)
        {
            throw e;//new Exception("Error al buscar coincidencia entre CI del Cliente y CI del Operador(a)");
        }
    }

    public TarjetaPersistente ObtenerDatosTarjeta(string numeroTarjeta)
    {
        try
        {
            tarjeta = new Tarjeta(Handler.BuscarTarjeta(numeroTarjeta));
            return tarjeta;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public string ObtenerCarnet(string Tarjeta)
    {
        try
        {
            tarjeta = new Tarjeta(Handler.BuscarTarjeta(Tarjeta));

            return tarjeta.IdCliente;
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos");
        }
    }
    public DataSet ConsultarSaldo(string Tarjeta)
    {
        DataSet result = new DataSet();
        if (Rol.Funcionalidades.Contains("Consultar Saldo"))
        {
        result = Handler.ConsultarSaldo(Tarjeta);            
        try
        {   
            
            List<string> descrip = new List<string>();
            descrip.Add(tarjeta.IdNumeroTarjeta);
            Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Consultar Saldo", DateTime.Now, descrip));
        }
        catch (Exception e)
        {
          throw new Exception("ErrorCBD" + e.Message);
        }
        }
        return result;
    }

    public DataSet ObtenerMonedas(string Tarjeta)
    {
        DataSet result = new DataSet();
        if (Rol.Funcionalidades.Contains("Consultar Saldo"))
        {
            result = Handler.ConsultarSaldo(Tarjeta);
            try
            {

                List<string> descrip = new List<string>();
                descrip.Add(tarjeta.IdNumeroTarjeta);
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
        }
        return result;
    }
    public DataSet ConsultaSaldosIntegrada(string tarjeta)
    {
        DataSet Saldos = new DataSet();
        if (Rol.Funcionalidades.Contains("Consulta de Saldos Integrada"))
        {
            try
            {
                Saldos = Handler.ConsultaSaldoIntegrada(tarjeta);
                List<string> descrip = new List<string>();
                descrip.Add(tarjeta);
                descrip.Add("Consulta de Saldo Integrada");
                Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Consultar Saldo", DateTime.Now, descrip));
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return Saldos;
    }
    public bool CambiarEstadoTarjeta(string numeroTarjeta, string estado)
    {
        bool result = false;
        if (Rol.Funcionalidades.Contains("Tarjeta Caliente"))
        {
            try
            {
                result = Handler.ModificarEstadoDeLaTarjeta(numeroTarjeta, estado);
                List<string> descrip = new List<string>();
                descrip.Add(numeroTarjeta); descrip.Add(estado);
                Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Tarjeta Caliente", DateTime.Now, descrip));
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return result;
    }
    public int[] PreguntarPin()
    {
        Random r = new Random();
        int[] result = new int[2];
        result[0] = r.Next(4);
        result[1] = r.Next(4); ;
        while (result[1] == result[0])
        {
            result[1] = r.Next(4);
        }
        return result;
    }
    public string PreguntarCoordenada()
    {//se devuelven las coordenadas de la matriz que se van a preguntar
        //ejemplo {"a1"}
        Random r = new Random();
        int[] intR = new int[2];
        string alfabeto = "ABCDEFGHIJ";
        intR[0] = r.Next(10);
        intR[1] = r.Next(10);
        string result;
        result = alfabeto.Substring(intR[0], 1) + Convert.ToString(intR[1]+1); 
        return result;
    }
    public Boolean ChequearPin(int[] ping)
    {//se le pasa un arreglo de 4, que representa digito y valor seguidamente
        //ejemplo {"1","2","2","3"}
        bool a = false;
        try
        {
            if (tarjeta.IdNumeroTarjeta.Substring(0, 2) == "06")
            {
                int[] p = new int[2];
                char[] d = new char[2];

                p[0] = ping[0] + 1;
                p[1] = ping[2] + 1;


                d[0] = Convert.ToString(ping[1])[0];
                d[1] = Convert.ToString(ping[3])[0];

                a = this.PINWSIS(tarjeta.IdNumeroTarjeta.ToString(), p, d);

                
            }
            if (tarjeta.IdNumeroTarjeta.Substring(0, 2) == "95")
            {
                TeleBancaWS web = new TeleBancaWS();
                string dpin = tarjeta.NoPin;
                string nuPing = web.Desencrypt(dpin);
                if (nuPing.Substring(ping[0], 1).Equals(Convert.ToString(ping[1])) &&
                    nuPing.Substring(ping[2], 1).Equals(Convert.ToString(ping[3])))
                    a = true;
                else
                    a = false;
            }
        }
        catch (Exception)
        {
            throw new Exception("Error al comprobar los dígitos aleatorios del PIN");
        }

        return a;
    }
    public Boolean ChequearCoordenada(string[] coordenadas)
    {//se le pasa un arreglo de 2, que representa coordenada y seguidamente el valor 
        //ejemplo {"a1","12"}
        bool b = false;
        try
        {
            if (tarjeta.IdNumeroTarjeta.Substring(0, 2) == "06")
            {
                string alfabeto = "ABCDEFGHIJ";
                int l1, n1;
                string v1;
                string coord = coordenadas[0];
                l1 = alfabeto.IndexOf(coord.Substring(0, 1)) + 1;
                n1 = Convert.ToInt32(coord.Substring(1, coord.Length - 1));
                v1 = coordenadas[1];
               
                b = this.COORWSIS(tarjeta.IdNumeroTarjeta,n1,l1,v1);
            }

            if (tarjeta.IdNumeroTarjeta.Substring(0, 2) == "95")
            {
                string alfabeto = "ABCDEFGHIJ";
                int l1, n1;
                string v1;
                string coord = coordenadas[0];
                l1 = alfabeto.IndexOf(coord.Substring(0, 1));
                n1 = Convert.ToInt32(coord.Substring(1, coord.Length - 1)) - 1;
                v1 = coordenadas[1];
                string celda1;

                Matriz m = tarjeta.DarMatriz();
                celda1 = m.Filas[n1].Substring(l1 * 2, 2);

                if (Convert.ToInt32(celda1) == Convert.ToInt32(v1))
                    b = true;
                else
                    b = false;
            }
        }
        catch (Exception)
        {
            throw new Exception("Error al comprobar coordenada");
        }

        return b;
    }

    // Raul: Metodo para Obtener Valores de coordenadas:
    public string[] ObtenerValoresCoordenadas(string[] coordenadas)
    {//se le pasa un arreglo de 2, que representa las coordenadas
        //ejemplo {"a1","b1"}
        string[] coordResult = new string[2];
        try
        {            
            if (tarjeta.IdNumeroTarjeta.Substring(0, 2) == "95")
            {
                string alfabeto = "ABCDEFGHIJ";
                int l1, l2, n1, n2;                
                
                string coord1 = coordenadas[0];
                string coord2 = coordenadas[1];

                l1 = alfabeto.IndexOf(coord1.Substring(0, 1));
                n1 = Convert.ToInt32(coord1.Substring(1, coord1.Length - 1)) - 1;

                l2 = alfabeto.IndexOf(coord2.Substring(0, 1));
                n2 = Convert.ToInt32(coord2.Substring(1, coord2.Length - 1)) - 1;
                
                string celda1;
                string celda2;

                Matriz m = tarjeta.DarMatriz();
                celda1 = m.Filas[n1].Substring(l1 * 2, 2);
                celda2 = m.Filas[n2].Substring(l2 * 2, 2);

                if (Convert.ToInt32(celda1).ToString().Length == Convert.ToInt32(celda2).ToString().Length)
                {
                    coordResult[0] = celda1;
                    coordResult[1] = celda2;
                }
                
                    
            }
        }
        catch (Exception)
        {
            throw new Exception("Error al comprobar coordenada");
        }

        return coordResult;
    }


    //*********nnnnnnnnnnnnnnnnn 
    public void ObtenerListDatosPago(string codServ)
    {
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            try
            {
                datosPago = Handler.BuscarDatos(codServ, new string[] {"2","4" });
              //  datosPago = Handler.BuscarDatosPago(codServ);//busca los datos de "pago" un servicio 
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
    }
    public ArrayList MostrarServiciosContratados()
    { //tiene dos arraglos (string[]) con codServ y nombre de serv
            ArrayList aux = new ArrayList();
            if (Rol.Funcionalidades.Contains("Servicio de Pago"))
            {
            Servicios = Handler.ObtenerServiciosContratados(tarjeta.IdNumeroTarjeta);

            try
            {
                QuitarServiciosDesactivados();
                string[] codigoServ = new string[Servicios.Count]; int i = 0;
                foreach (Servicio serv in Servicios)
                {
                    codigoServ[i] = serv.CodigoServicio;
                    i++;
                } i = 0;
                string[] nombres = new string[codigoServ.Length];

                foreach (string cod in codigoServ)
                {
                    nombres[i] = Handler.BuscarNombreServ(codigoServ[i]);//busca nombre por el id servicio
                    i++;
                }
                aux.Add(codigoServ);
                aux.Add(nombres);
                return aux;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }

        }
        return new ArrayList();
    }
   
    private void QuitarServiciosDesactivados()
    {
        for (int i = 0; i < Servicios.Count; i++)
        {
            if (!Handler.EsServicioActivo(Servicios[i].CodigoServicio))
            {
                Servicios.RemoveAt(i);
                i--;
            }
        }
    }

    public bool ContratarServicio(string aServNombre, string[] Asociados , string usuario)
    {
        // Se debe actualizar la traza del sistema
        try
        {
            
            DataAccessLayer.Interfaz_de_Datos.ContratoPersistente TempContrato = new DataAccessLayer.Interfaz_de_Datos.ContratoPersistente(tarjeta.IdNumeroTarjeta);
            List<Asociado> TempList = new List<Asociado>();
            ServicioPersistente TempServ = Handler.BuscarServicio(aServNombre);
            int IdDato = 0;

            foreach (DatoPersistente i in TempServ.DatosPersistentes)
                if (i.TipoDato.Equals("1"))
                {
                    IdDato = Handler.IdDato(i.NombreDato);
                    break;
                }

            if (IdDato == 0) return false;

            foreach (string i in Asociados)
            {
                Asociado TempAsoc = new Asociado();
                TempAsoc.Datos.Add(new Dato(IdDato.ToString(), i));
                TempList.Add(TempAsoc);
            }
            TempContrato.Sevicios.Add(new Servicio(TempServ.IdServicio, TempList));
            //Accion de Usuario**************************************************
            List<string> descrip = new List<string>();
            string Tipo = "Contratar Servicio";
            descrip.Add(Tipo);
            descrip.Add(tarjeta.IdNumeroTarjeta);
            descrip.Add(TempServ.IdServicio);
            descrip.Add(TempServ.Nombre);
            for (int i = 0; i < Asociados.Length; i++)
            {
                descrip.Add(Asociados[i].ToString());
            }
            
            //********************************************************************
            bool resp= Handler.ModificarContrato(TempContrato,usuario);
            Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Contratar Servicios", DateTime.Now, descrip));
            return resp;
        }
        catch 
        {
            return false;
        }
    }

    public bool ModificarContratoServicio(string aServNombre, string[] Asociados, string usuario)
    {
        // Se debe actualizar la traza del sistema
        try
        {
            DataAccessLayer.Interfaz_de_Datos.ContratoPersistente TempContrato = new DataAccessLayer.Interfaz_de_Datos.ContratoPersistente(tarjeta.IdNumeroTarjeta);
            
            List<Asociado> TempList = new List<Asociado>();
            ServicioPersistente TempServ = Handler.BuscarServicio(aServNombre);
            int IdDato = 0;

            //Borrando El servicio Completo
            for( int i = 0; i < TempContrato.Sevicios.Count; i++)
                if (TempContrato.Sevicios[i].CodigoServicio.Equals(TempServ.IdServicio))
                {
                    TempContrato.Sevicios.RemoveAt(i);
                    break;
                }

            foreach (DatoPersistente i in TempServ.DatosPersistentes)
                if (i.TipoDato.Equals("1"))
                {
                    IdDato = Handler.IdDato(i.NombreDato);
                    break;
                }

            if (IdDato == 0) return false;

            foreach (string i in Asociados)
            {
                Asociado TempAsoc = new Asociado();
                TempAsoc.Datos.Add(new Dato(IdDato.ToString(), i));
                TempList.Add(TempAsoc);
            }
            TempContrato.Sevicios.Add(new Servicio(TempServ.IdServicio, TempList));
            //Accion de Usuario**************************************************
            List<string> descrip = new List<string>();
            string Tipo = "Modificacion del Contrato";
            descrip.Add(Tipo);
            descrip.Add(tarjeta.IdNumeroTarjeta);
            descrip.Add(TempServ.IdServicio);
            descrip.Add(TempServ.Nombre);
            for (int i = 0; i < Asociados.Length; i++)
            {
                descrip.Add(Asociados[i].ToString());
            }
           
            //********************************************************************
            bool resp = Handler.ModificarContrato(TempContrato,usuario);
            Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Contratar Servicios", DateTime.Now, descrip));
            return resp;
        }
        catch
        {
            return false;
        }
    }

    public bool DescontratarServicio(string aServNombre, string usuario)
    {
        // Se debe actualizar la traza del sistema
        try
        {
            DataAccessLayer.Interfaz_de_Datos.ContratoPersistente TempContrato = new DataAccessLayer.Interfaz_de_Datos.ContratoPersistente(tarjeta.IdNumeroTarjeta);
            ServicioPersistente TempServ = Handler.BuscarServicio(aServNombre);

            //Borrando El servicio Completo
            for (int i = 0; i < TempContrato.Sevicios.Count; i++)
                if (TempContrato.Sevicios[i].CodigoServicio.Equals(TempServ.IdServicio))
                {
                    TempContrato.Sevicios.RemoveAt(i);
                    break;
                }
            //Accion de Usuario**************************************************
            List<string> descrip = new List<string>();
            string Tipo = "Eliminar Servicio";
            descrip.Add(Tipo);
            descrip.Add(tarjeta.IdNumeroTarjeta);
            descrip.Add(TempServ.IdServicio);
            descrip.Add(TempServ.Nombre);
            //for (int i = 0; i < Asociados.Length; i++)
            //{
            //    descrip.Add(Asociados[i].ToString());
            //}
            
            //********************************************************************
           bool resp = Handler.ModificarContrato(TempContrato,usuario);
            Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Contratar Servicios", DateTime.Now, descrip));
            return resp;
        }
        catch
        {
            return false;
        }
    }

    public bool EstanTodosModificados()
    {
        foreach (Dato dat in datosPago)
        {
            if (dat.Valor == "")
                return false;
        }
        return true;
    }
    public string[] BuscarIdDatosPago(string codServ)
    {
        string[] aux = new string[datosPago.Count];
        int i = 0;
        foreach (Dato dat in datosPago) 
        {
            aux[i] = dat.Id;
            i++;
        }
        return aux;
    }

    //**************nnnnnnnnnnnnn     
    public string[] MostrarIdAsociados(string codigoServicio)
    {
        string[] ids = new string[1];
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            foreach (Servicio serv in Servicios)
            {
                if (serv.CodigoServicio.Equals(codigoServicio))
                {
                    List<Asociado> listA = serv.Asociados;
                    ids = new string[listA.Count];
                    int i = 0;
                    foreach (Asociado asoc in listA)
                    {
                        ids[i] = asoc.Datos[0].Valor;
                        i++;
                    }
                }
            }
        }
        return ids;
    }
    public ArrayList MostrarDatosAsociadosServicio(string codigoServicio)
    {//devuelve un ArrayList que tiene en la primera posicion string[] idDato
        // y en las otras string[] valor con los valores de esos ids para todos los asociados al servicio
        ArrayList result = new ArrayList();
        string[] ids = new string[1];
        bool idsGuardados = false;
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            foreach (Servicio serv in Servicios)
            {
                if (serv.CodigoServicio.Equals(codigoServicio))
                {
                    List<Asociado> listA = serv.Asociados;

                   result.Add(Handler.EsServConAsociados(codigoServicio));
                   if (codigoServicio == "04") idCliente = "6";    //Para quitar y arreglar
                   if (codigoServicio == "03") idCliente = "14";
                   if (codigoServicio == "06") idCliente = "15";
                   if (codigoServicio == "07") idCliente = "16";
                   if (codigoServicio == "08") idCliente = "17";
 
                    foreach (Asociado asoc in listA)
                    {
                            List<Dato> dat = asoc.Datos;
                            ids = new string[dat.Count];
                            string[] valores = new string[dat.Count];
                            for (int i = 0; i < dat.Count; i++)
                            {
                                if (i == 0)
                                {
                                    idCliente = dat[i].Id;
                                }
                                ids[i] = dat[i].Id;
                                valores[i] = dat[i].Valor;
                            }
                            if (!idsGuardados)
                            {
                                ids = BuscarNombresDatos(ids);
                                result.Add(ids);
                                idsGuardados = true;
                            }
                            result.Add(valores);
                    }
                }
            }
              
        }

        return result;
    }
    public string[] BuscarNombresDatos(string[] idDato)
    {
        try
        {
         string[] nombres = new string[idDato.Length];
        for (int i = 0; i < idDato.Length; i++)
        {    //BuscarNombreDato(int iddato);
            nombres[i] = Handler.BuscarNombreDato(Convert.ToInt32(idDato[i]));
        }
        return nombres;
    }
    catch (Exception)
    {
        throw new Exception("Error de conexión con la base de datos");
    }
    }
    public string[] MostrarTransaccionAReclamar(string traza, int[] fechaTrans) 
    {//muestra estos datos en este orden
        //Asociado, FechaHora, Importe,  No. Tarjeta,	Servicio, Nombre y Apellidos del cliente
        //si la transaccion devuelta es null se da un arreglo de tamaño 1
        string[] aux = new string[1];
        if (Rol.Funcionalidades.Contains("Iniciar Reclamación"))
        {
            try
            {

                DateTime f = new DateTime(fechaTrans[2], fechaTrans[1], fechaTrans[0]);
                Transaccion transacion = Handler.BuscarTransaccionAReclamar(traza, f);
                if (transacion.IdServicio == null)
                    aux = new string[1];
                else
                {
                    // aux = new string[6 + transacion.Datos.Length];
                    aux = new string[7];


                    aux[0] = transacion.Fecha.ToString();

                    aux[2] = transacion.IdUsuario;
                    aux[3] = transacion.NumeroTarjeta;
                    aux[4] = Handler.BuscarNombreServ(transacion.IdServicio);
                    tarjeta = new Tarjeta(Handler.BuscarTarjeta(transacion.NumeroTarjeta));
                    aux[5] = tarjeta.NombrePropietario + " " + tarjeta.Apellidos;
                    aux[6] = transacion.ConsecutivoTransac;
                    //int i=0;
                    foreach (string dato in transacion.Datos)
                    {
                        string id = dato.Substring(0, 2);
                        if (Handler.BuscarNombreDato(Convert.ToInt32(id)).Equals("Importe"))
                        {
                            aux[1] = dato.Substring(2);
                            break;
                            //i++;
                        }
                        //if (Handler.BuscarNombreDato(Convert.ToInt32(id)).Equals("IdAsociado"))
                        //{
                        //    aux[0] = dato.Substring(2);
                        //    i++;
                        //}
                        //if (i == 2)
                        //    break;
                    }

                }

                return aux;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return new string[0];
    }
    public bool ReclamarTransaccion(string idTransaccion, string idUsuario, string descripcion)
    {
        if (Rol.Funcionalidades.Contains("Iniciar Reclamación"))
        {
            try
            {
                ReclamacionTransaccion transRecla = new ReclamacionTransaccion(idTransaccion, idUsuario, DateTime.Now, descripcion);

                if (Handler.AgregarReclamacion(transRecla))
                {

                    return true;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        } return false;
    }
    public int BuscarNivelAutenticacionPorCoord(string codigoServicio)
    {//devuelve la cantidad de coordenadas mas que hay que pedir
        try
        {
            return Handler.BuscarNivelAutenticacionPorCoord(codigoServicio);
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos");
        }

    }
    public bool BuscarNivelAutenticacionPorCI(string codigoServicio)
    {//devuelve si hay que pedir el carnet de identidad
        try
        {
            return Handler.BuscarNivelAutenticacionPorCI(codigoServicio);
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos");
        }
    }
    public string VerificarMetodoPago(string codigoServicio)
    {//devuelve el metodo (simple o complejo) de un servicio, para ser pagado
        try
        {
            return Handler.BuscarMetodoAutenticacion(codigoServicio);
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos");
        }
       
    }
    //*********
   /*
    public string[] BuscarPagoComplejo(string codigoServicio, string idCliente)
    { //retorno : nombre, importe, informativo
        string[] aux = new string[3];
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            try
            {
                PagoComplejo pc = Handler.BuscarPagoComplejo(Convert.ToInt32(codigoServicio), idCliente);
                aux[0] = IdDatoToString(Handler.IdDato("Nombre").ToString()) + pc.Nombre;
                aux[1] = IdDatoToString(Handler.IdDato("Importe").ToString()) + Convert.ToString(pc.Importe);
                aux[2] = IdDatoToString(Handler.IdDato("Imformativo").ToString()) + pc.Informativo;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return aux;
    }
    */

    public ArrayList BuscarPagoComplejo(string codigoServicio, string idCliente)
    { //retorno:ArrayList de string[]{  nombre, importe, informativo}
        ArrayList res = new ArrayList();
        List<PagoComplejo> datos = new List<PagoComplejo>();
        string[] filtro = new string[6];

        string nombrecll = Handler.Nombre_CLlamadas();
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            
            try
            {
                filtro[5] = Handler.FiltroBuscarPagoComplejo(codigoServicio, idCliente);   
            }
            catch (Exception)
            {
                throw new Exception("Error al buscar la existencia de la factura en la base de datos");
            }

            if (filtro[5] == "3")
            {
                datos = Handler.BuscarPagoComplejo(codigoServicio, idCliente); 
            }
            if (filtro[5] == "2")
            {
                throw new Exception("La Factura solicitada para el ID: " + idCliente + ", ya fue pagada mediante " + nombrecll);
            }
            if (filtro[5] == "1")
            {
                throw new Exception("La Factura solicitada para el ID: " + idCliente + " no está registrada en " + nombrecll.Trim() + " para realizar pagos");
            }

            if (datos.Count == 0)

                throw new Exception("La Factura solicitada para el ID: " + idCliente + " no está registrada en " + nombrecll.Trim() + " para realizar pagos");

                foreach (PagoComplejo pc in datos)
                {
                    string[] aux = new string[5];
                    aux[0] = pc.ID.ToString();
                    aux[1] = pc.Descriptivo;
                    aux[2] = IdDatoToString(Handler.IdDato("Nombre").ToString()) + pc.Nombre;
                    aux[3] = IdDatoToString(Handler.IdDato("Importe").ToString()) + Convert.ToString(pc.Importe);
                    aux[4] = IdDatoToString(Handler.IdDato("Imformativo").ToString()) + pc.Informativo;
                    res.Add(aux);
                }
           
        }
        return res;
    }

    //**********
    private string IdDatoToString(string id)
    {
        if (id.Length < 2)
        {
            string aux = "0";
            aux += id;
            return aux;
        }
        else
            return id;
    }
    private string buscarEnDatosPagosPorID(string id)
    {
      foreach (Dato dat in datosPago)
	  {
          if (dat.Id==id)
	      {
              return dat.Valor;
	      }
	  }
      return "";
    }

    #region<Raul: (anterior a lo del USD) EnviarTransaccion>
    //public string EnviarTransaccion(string codigoServicio, int posAsociado, bool moneda)
    //{
    //    string mensaje = "";
    //    if (Rol.Funcionalidades.Contains("Servicio de Pago"))
    //    {
    //        Asociado aux = new Asociado();
    //        foreach (Servicio serv in Servicios)
    //            if (serv.CodigoServicio.Equals(codigoServicio))
    //                aux = serv.Asociados[posAsociado];

    //        int tamDat = datosPago.Count + aux.Datos.Count;
    //        string[] dat = new string[tamDat];
    //        int i = 0;
    //        foreach (Dato d in datosPago)
    //        {
    //            dat[i] = IdDatoToString(d.Id) + d.Valor;
    //            i++;
    //        }
    //        foreach (Dato d in aux.Datos)
    //        {
    //            dat[i] = IdDatoToString(d.Id) + d.Valor;
    //            i++;
    //        }
    //        Transaccion t = new Transaccion(null, codigoServicio, tarjeta.IdNumeroTarjeta, Usuario, DateTime.Now, dat);
    //        mensaje = Handler.EnviarTransaccion(t, moneda);
    //        try
    //        {
    //            if (mensaje.Length < 5)
    //            {
    //                mensaje = Handler.BuscarCodigoError(mensaje.Substring(1));
    //            }
    //            else
    //            {
    //                mensaje = "La transacción ha sido realizada satisfactoriamente. Traza : " + mensaje;

    //                try
    //                {
    //                    List<string> descrip = new List<string>();
    //                    descrip.Add(tarjeta.IdNumeroTarjeta);
    //                    descrip.Add(Handler.BuscarNombreServ(codigoServicio));
    //                    descrip.Add(buscarEnDatosPagosPorID("4"));
    //                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Servicio de Pago", DateTime.Now, descrip));
    //                }
    //                catch (Exception)
    //                {
    //                    // throw new Exception("Error de conexión con la BD");
    //                }
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            throw new Exception("Error de conexión con la base de datos");
    //        }
    //    }
    //    return mensaje;

    //}
    #endregion
    public string EnviarTransaccion(string codigoServicio,int posAsociado, int moneda)
    {
        string mensaje = "";
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            Asociado aux = new Asociado();
            foreach (Servicio serv in Servicios)
                if (serv.CodigoServicio.Equals(codigoServicio))
                    aux = serv.Asociados[posAsociado];
       
            int tamDat = datosPago.Count + aux.Datos.Count;
            string[] dat = new string[tamDat];
            int i = 0;
            foreach (Dato d in datosPago)
            {
                dat[i] = IdDatoToString(d.Id) + d.Valor;
                i++;
            }
            foreach (Dato d in aux.Datos)
            {
                dat[i] = IdDatoToString(d.Id) + d.Valor;
                i++;
            }
            Transaccion t = new Transaccion(null, codigoServicio, tarjeta.IdNumeroTarjeta, Usuario, DateTime.Now, dat);
            mensaje = Handler.EnviarTransaccion(t, moneda);
            try
            {
                if (mensaje.Length < 5)
                {
                    mensaje = Handler.BuscarCodigoError(mensaje.Substring(1));
                }
                else
                {
                    mensaje = "La transacción ha sido realizada satisfactoriamente. Traza : " + mensaje;
                    
                    try
                    {
                        List<string> descrip = new List<string>();
                        descrip.Add(tarjeta.IdNumeroTarjeta);
                        descrip.Add(Handler.BuscarNombreServ(codigoServicio));
                        descrip.Add(buscarEnDatosPagosPorID("4"));
                        Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Servicio de Pago", DateTime.Now, descrip));
                    }
                    catch (Exception)
                    {
                       // throw new Exception("Error de conexión con la BD");
                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return mensaje;
  
    }

    #region<Raul: (anterior a lo del USD) EnviarTransaccionPagoComplejo>
    //public string EnviarTransaccionPagoComplejo(string codigoServicio, string[] datos, bool moneda)
    //{// idcliente, importe, informativo
    //    string mensaje = "";
    //    if (Rol.Funcionalidades.Contains("Servicio de Pago"))
    //    {
    //        //int ide = int.Parse(datos[0]);
    //        int ide = 0; // Raul. la linea de arriba era la q estaba. en caso de bateo comentarear esta y poner la de arriba. la var ide es para pasarsela al EliminarPagoComplejo
    //        //string[] aux = new string[3];
    //        string[] aux = new string[datos.Length];
    //        //datos.CopyTo(aux, 2);



    //        if (codigoServicio == "09" || codigoServicio == "59")
    //        {
    //            //idCliente = datos[0]; 
    //            idCliente = "";
    //            aux[0] = datos[2]; // cuenta estandarizada
    //            aux[1] = datos[3]; // importe total amortizar
    //            //aux[2] = datos[4]; 
    //            aux[2] = datos[0]; // Raul: aqui se cambio x la linea de arriba para asignarle el num de C.I de la persona
    //            aux[3] = datos[4]; // importe recargo
    //            aux[4] = datos[1]; // importe mensual amortizar
    //            datos = aux;
    //            datos[0] = IdDatoToString(Handler.IdDato("IDAmort").ToString()) + datos[0];

    //        }
    //        else
    //        {
    //            ide = int.Parse(datos[0]);
    //            string[] aux2 = new string[3];
    //            aux2[0] = datos[2];
    //            aux2[1] = datos[3];
    //            aux2[2] = datos[4];
    //            datos = aux2;
    //            datos[0] = IdDatoToString(idCliente) + datos[0];
    //        }

    //        //datos[0] = IdDatoToString(idCliente) + datos[0];

    //        Transaccion t = new Transaccion(null, codigoServicio, tarjeta.IdNumeroTarjeta, Usuario, DateTime.Now, datos);
    //        mensaje = Handler.EnviarTransaccion(t, moneda);
    //        try
    //        {

    //            if (mensaje.Length < 5)
    //            {
    //                mensaje = Handler.BuscarCodigoError(mensaje.Substring(1));
    //            }
    //            else
    //            {
    //                if (Convert.ToInt32(codigoServicio) > 50)
    //                {
    //                    codigoServicio = "0" + Convert.ToString(Convert.ToInt32(t.IdServicio) - 50);

    //                    if (codigoServicio.Length >= 3) { codigoServicio = codigoServicio.Substring(1, 2); }
    //                }

    //                Handler.EliminarPagoComplejo(codigoServicio, ide);

    //                mensaje = "..:: Transacción realizada satisfactoriamente ::.. Traza: " + mensaje;

    //                try
    //                {

    //                    List<string> descrip = new List<string>();
    //                    descrip.Add(tarjeta.IdNumeroTarjeta);
    //                    descrip.Add(Handler.BuscarNombreServ(codigoServicio));
    //                    descrip.Add(aux[1].Substring(2));
    //                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Servicio de Pago", DateTime.Now, descrip));
    //                }
    //                catch (Exception)
    //                {
    //                    // throw new Exception("Error de conexión con la BD");
    //                }
    //            }



    //        }
    //        catch (Exception)
    //        {

    //            throw new Exception(" Error de conexión con la base de datos ");
    //        }
    //    }
    //    return mensaje;
    //}
    #endregion
    public string EnviarTransaccionPagoComplejo(string codigoServicio, string[] datos, int moneda)
    {// idcliente, importe, informativo
        string mensaje = "";
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            //int ide = int.Parse(datos[0]);
            int ide = 0; // Raul. la linea de arriba era la q estaba. en caso de bateo comentarear esta y poner la de arriba. la var ide es para pasarsela al EliminarPagoComplejo
            //string[] aux = new string[3];
            string[] aux = new string[datos.Length];
            //datos.CopyTo(aux, 2);

            

            if (codigoServicio == "09" || codigoServicio == "59")
            {                
                //idCliente = datos[0]; 
                idCliente = "";
                aux[0] = datos[2]; // cuenta estandarizada
                aux[1] = datos[3]; // importe total amortizar
                //aux[2] = datos[4]; 
                aux[2] = datos[0]; // Raul: aqui se cambio x la linea de arriba para asignarle el num de C.I de la persona
                aux[3] = datos[4]; // importe recargo
                aux[4] = datos[1]; // importe mensual amortizar
                datos = aux;
                datos[0] = IdDatoToString(Handler.IdDato("IDAmort").ToString()) + datos[0];

            }
            else
            {
                ide = int.Parse(datos[0]);
                string[] aux2 = new string[3];
                aux2[0] = datos[2];
                aux2[1] = datos[3];
                aux2[2] = datos[4];
                datos = aux2;
                datos[0] = IdDatoToString(idCliente) + datos[0];

                aux = aux2; // nuevo Raul. Igualar los dos arreglos para poder insertar luego en la tabla de Acciones del usuario los datos del pago
            }
            
            //datos[0] = IdDatoToString(idCliente) + datos[0];

            Transaccion t = new Transaccion(null, codigoServicio, tarjeta.IdNumeroTarjeta, Usuario, DateTime.Now, datos);
            mensaje = Handler.EnviarTransaccion(t, moneda);
            try
            {
               
                if (mensaje.Length < 5)
                {
                    mensaje = Handler.BuscarCodigoError(mensaje.Substring(1));
                }
                else
                {
                    if (Convert.ToInt32(codigoServicio) > 50)
                    {
                        codigoServicio = "0" + Convert.ToString(Convert.ToInt32(t.IdServicio) - 50);

                        if (codigoServicio.Length >= 3) { codigoServicio = codigoServicio.Substring(1, 2); }
                    }
                   
                    Handler.EliminarPagoComplejo(codigoServicio, ide);
                    
                    mensaje = "..:: Transacción realizada satisfactoriamente ::.. Traza: " + mensaje;
                                    
                    try
                    {
                        
                        List<string> descrip = new List<string>();
                        descrip.Add(tarjeta.IdNumeroTarjeta);
                        descrip.Add(Handler.BuscarNombreServ(codigoServicio));
                        descrip.Add(aux[1].Substring(2));
                        Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Servicio de Pago", DateTime.Now, descrip));
                    }
                    catch (Exception)
                    {
                        // throw new Exception("Error de conexión con la BD");
                    }
                }

                
                
            }
            catch (Exception)
            {

                throw new Exception(" Error de conexión con la base de datos ");
            }
        }   
       return mensaje;
    }

    private bool EsValorPagoValido(string idDato, string valor)
    {
        DatoPersistente definicion = new DatoPersistente();
        definicion = Handler.BuscarDato(new DatoPersistente(Handler.BuscarNombreDato(int.Parse(idDato)),"","",0));
        if (valor == "" || valor.Length > definicion.TamañoDato || (valor.IndexOf(",")!= -1))
            return false;
        try
        { 
         switch (definicion.Tipo)
          {
	               
		   case "char":
               char.Parse(valor);
                break;
            case "short":
                short.Parse(valor);
                break;
            case "int":
                int.Parse(valor);
                break;
            case "float":
                float.Parse(valor);
                break;
            case "long":
                long.Parse(valor);
                break;
            case "double":
                break;
            case "bool":
                double.Parse(valor);
                break;
            case "DateTime":
                DateTime.Parse(valor);
                break;

            default://para string
                break;
         
        }
        	}
	catch (Exception)
	{
        return false;
    }
    return true;

    }

    public bool ModificarDatoPago(string idDato, string valor)
    {
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            if (!EsValorPagoValido(idDato, valor))
                return false;
            foreach (Dato d in datosPago)
            {
                if (d.Id.Equals(idDato))
                {
                    d.Valor = valor;
                    return true;
                }
            }
        }
        return false;
    }
    public string MostrarDatoPago(string idDato)
    {
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            foreach (Dato d in datosPago)
            {
                if (d.Id.Equals(idDato))
                {
                    return d.Valor;
                }
            }
        }
        return "";
    }
   /* public string BuscarCodigoError(string traza)
    {
        try
        {
            return Handler.BuscarCodigoError(traza);
        }
        catch (Exception)
        {
            throw new Exception("Error de conexión con la base de datos");
        }
    }*/


    //Raul: Nuevas Funcionalidades: Ult_Mov, Cancelar_RegistroBM
    public DataSet Ultimos_Movimientos(string Tarjeta, string moneda, string servicio)
    {
        DataSet result = new DataSet();
        try
        {
            if (Rol.Funcionalidades.Contains("Ultimos Movimientos"))
            {
                result = Handler.Ultimos_Movimientos(Tarjeta, moneda, servicio);
                string moneda_consultada = moneda.Equals("40") ? "CUP" : "CUC";
                List<string> descrip = new List<string>();
                descrip.Add(tarjeta.IdNumeroTarjeta + "/" + moneda_consultada);
                Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Ultimos Movimientos", DateTime.Now, descrip));
            }
        }
        catch (Exception)
        {

            throw;
        }
        return result;
    }

    public string Cancelar_Registro_BancaMovil(string Tarjeta, string num_movil)
    {
        string result = "";
        bool error = false;
        int cod_error = 0;
        string mensaje = "";

        if (Rol.Funcionalidades.Contains("Cancelar Registro Banca Movil"))
        {
            result = Handler.Cancelar_Registro_BancaMovil(Tarjeta, num_movil, Usuario, out error, out cod_error, out mensaje);

            if (result !="" && error == false && cod_error == 0 && !mensaje.Contains("Error"))
            {
                List<string> descrip = new List<string>();
                descrip.Add(tarjeta.IdNumeroTarjeta + "/ Canceló movil: " + num_movil);

                //string dateTime = DateTime.Now.ToString();
                //string createddate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd h:mm tt");
                //DateTime fecha = DateTime.ParseExact(createddate, "yyyy-MM-dd h:mm tt", CultureInfo.InvariantCulture);
                Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Cancelar Registro Banca Movil", DateTime.Now, descrip));
            }
            
        }

        return result;
    }

    public DataSet Localizar_TransfExterior(string Tarjeta, string num_ideper, out bool error, out int cod_error, out string mensaje)
    {
        DataSet result = new DataSet();
        error = false;
        cod_error = 0;
        mensaje = "";

        if (Rol.Funcionalidades.Contains("LocalizaTransfExt"))
        {
            result = Handler.Localizar_TransfExterior(Tarjeta, num_ideper, out error, out cod_error, out mensaje);

            if (result != null && error == false && cod_error == 0 && !mensaje.Contains("ERROR"))
            {
                List<string> descrip = new List<string>();
                descrip.Add(tarjeta.IdNumeroTarjeta + "/ Localizo Transferencia Exterior. CI: " + num_ideper.ToString().Trim());

                //string dateTime = DateTime.Now.ToString();
                //string createddate = Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd h:mm tt");
                //DateTime fecha = DateTime.ParseExact(createddate, "yyyy-MM-dd h:mm tt", CultureInfo.InvariantCulture);
                Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "LocalizaTransfExt", DateTime.Now, descrip));
            }

        }

        return result;
    }

    public DataSet Solicitud_PinDigital_Magnetica(string tarjetaBT, string tarjetaPAN)
    {
        DataSet resultado = new DataSet();
        if (Rol.Funcionalidades.Contains("PinDigitalTarjetaMagnetica"))
        {
            resultado = Handler.Solicitud_PinDigital_Magnetica(tarjetaBT, tarjetaPAN);
            if (resultado.Tables.Count>1)
            {
                List<string> descrip = new List<string>();
                descrip.Add(tarjeta.IdNumeroTarjeta + "/ Activo el Pin Digital de la tarjeta: " + tarjetaPAN.ToString().Trim());

                Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "PinDigitalTarjetaMagnetica", DateTime.Now, descrip));
            }
        }

        return resultado;
    }

    public DataSet Informacion_Telebanca_BancaMovil(string tarjetaBT, string movil, string numideper, DateTime f_ini, DateTime f_fin, out string msg, out int coderr)
    {
        DataSet resultado = new DataSet();
        msg = "";
        coderr = 0;

        if (Rol.Funcionalidades.Contains("Banca Movil"))
        {
            resultado = Handler.Informacion_Telebanca_BancaMovil(tarjetaBT, movil, numideper, f_ini, f_fin, out msg, out coderr);
            //if (resultado.Tables.Count > 1)
            //{
            //    string tarjeta_asociada = resultado.Tables[1].Rows[0][0].ToString().Trim();
            //    string numero_cel = resultado.Tables[1].Rows[0][1].ToString().Trim();
            //    List<string> descrip = new List<string>();
            //    descrip.Add(tarjeta.IdNumeroTarjeta + "/ Consulta Informacion Banca Movil. BT: " + tarjeta_asociada.Trim() + ". MOVIL: " + numero_cel.Trim());

            //    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Banca Movil", DateTime.Now, descrip));
            //}
        }

        return resultado;
    }


    #endregion  Pago
  


    #region  Banco



    /*-------Inicio--------Caso de Uso Gestion de Banco----------------------------------*/

    public bool AdicionarBanco(string nombre, string webServices, string passWord, string numBanco, string abreviatura, string centrollamad, string identificationserver)
    {
        BancoPersistente banco = new BancoPersistente(nombre, webServices, passWord, numBanco, abreviatura, centrollamad, identificationserver);

        if (Rol.Funcionalidades.Contains("Gestionar Banco"))
        {
            try
            {
                string datos = "";
                datos = Handler.VerificarDatosBanco(nombre, webServices, numBanco, abreviatura);
                if (datos == "")
                    return Handler.AdicionarBanco(banco);
                else
                    return false;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }


        }
        return false;
    }

    public string[] BuscarDatosBanco(string numBanco)
    {
        if (Rol.Funcionalidades.Contains("Gestionar Banco"))
        {
            try
            {
                BancoPersistente banco = Handler.BuscarBanco(numBanco);
                string[] datos = new string[5];
                datos[0] = banco.Nombre;
                datos[1] = banco.WebServices;
                datos[2] = banco.PassWord;
                datos[3] = banco.NumBanco;
                datos[4] = banco.Abreviatura;

                return datos;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return new string[0];
    }

    public ArrayList ObtenerListaBanco()
    {
        if (Rol.Funcionalidades.Contains("Gestionar Banco"))
        {
            try
            {
                List<BancoPersistente> lb = Handler.ObtenerListaBanco();
                int cantElementos = lb.Count;
                string[] listnombres = new string[cantElementos];
                string[] listnumeros = new string[cantElementos];
                ArrayList lista = new ArrayList();

                for (int i = 0; i < cantElementos; i++)
                {
                    listnombres[i] = lb[i].Nombre;
                }

                for (int i = 0; i < cantElementos; i++)
                {
                    listnumeros[i] = lb[i].NumBanco;
                }

                lista.Add(listnumeros);
                lista.Add(listnombres);

                return lista;

            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return new ArrayList();

    }

    public bool ModificarBanco(string nombre, string webServices, string passWord, string numBanco, string abreviatura, string centrollamad, string identificationserver)
    {
        BancoPersistente banco = new BancoPersistente(nombre, webServices, passWord, numBanco, abreviatura, centrollamad, identificationserver);
        if (Rol.Funcionalidades.Contains("Gestionar Banco"))
        {
            try
            {
                string datos = "";
                List<BancoPersistente> lb = Handler.ObtenerListaBanco();
                for (int i = 0; i < lb.Count; i++)
                    if (lb[i].Nombre != nombre)
                    {
                        if (lb[i].WebServices == webServices)
                            datos += "WebService -" + webServices + "-";
                        if (lb[i].Abreviatura == abreviatura)
                            if (abreviatura != "")
                                datos += "Abreviatura -" + abreviatura + "-";
                    }

                if (datos == "")
                    return Handler.ModificarBanco(banco);
                else
                    return false;



            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return false;
    }

    public bool EliminarBanco(string numBanco)
    {
        if (Rol.Funcionalidades.Contains("Gestionar Banco"))
        {
            try
            {
                return Handler.EliminarBanco(numBanco);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return false;
    }
    /*---------Fin---------Caso de Uso Gestion de Banco----------------------------------*/






    #endregion  Banco

    #region ReporteTransaccion
    public ReporteTransacciones[] getLitadoTransacciones(DateTime ini, DateTime fin, string operador, string value) {

        try
        {   ReporteTransacciones[] aux = Handler.ObtenerReporteTransac(ini, fin,operador, value, this.Nombre); 

            //foreach (ReporteTransacciones var in aux)
            //    {
            //            var.Reportero = this.Nombre;
            //    }
                return aux;
        }
        catch (Exception ex)
        {
            //throw new Exception("Error de conexión con la base de datos");
		throw new Exception(ex.Message);
        }
    
    }


    #endregion ReporteTransaccion






    //---------Inicio-------Caso de Uso Configurar Servicios y Datos------------Inicio----------
    #region Servicios
    public bool InsertarServicio(string idServ, string nombre, bool autenticaPorTarjeta, bool autenticaPorCI, bool autenticaPorPin, string estado, string tipoServicio, int cantCoord, DateTime fechaDescargaFTP, int frecuencia,bool asociados)
    {             // inserta cualquier tipo de servicio...simple o complejo
        if (Rol.Funcionalidades.Contains("Configuración de los Servicios"))
        {
            ServicioPersistente servicio = new ServicioPersistente(idServ, nombre, autenticaPorTarjeta, autenticaPorCI, autenticaPorPin, estado, tipoServicio, cantCoord, fechaDescargaFTP, frecuencia,asociados);
            try
            {
                if (!Handler.ExisteServicio(servicio.Nombre, servicio.IdServicio))
                    if (Handler.InsertarServicio(servicio))
                    {
                        List<string> TempDes = new List<string>();
                        TempDes.Add(nombre);
                        if (tipoServicio == "01")
                            TempDes.Add("Insertar Servicio simple");
                        else
                            TempDes.Add("Insertar Servicio Complejo");

                        Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Configuración de los Servicios", DateTime.Now, TempDes));

                        return true;
                    }// se inserta un servicio
                return false;
            }
            catch (Exception)
            {

                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return false;                   
    }

    public bool InsertarDatosAServicio(string nombServ, object[] datos)
    {            // para cada dato que se le adicionó al servicio se llama a este metodo
        if (Rol.Funcionalidades.Contains("Configuración de los Servicios"))
        {
            ServicioPersistente servicio = Handler.BuscarServicio(nombServ);
            if (servicio != null)
            {                
                servicio.DatosPersistentes = new List<DatoPersistente>();
                foreach (object o in datos)
                {
                    string[] aux = (string[])o;
                    if (aux[0].Equals("IdAsociado"))
                        switch (Convert.ToInt32(servicio.IdServicio))
                        {
                            case 1:
                                aux[0] = "IdTelefono";
                                break;
                            case 2:
                                aux[0] = "IDElectrica";
                                break;
                            case 4:
                                aux[0] = "IDMultas";
                                break;
                            case 5:
                                aux[0] = "IDAguas";
                                break;
                        }
                    servicio.DatosPersistentes.Add(new DatoPersistente(aux[0], aux[1], "", 0));
                }
                try
                {

                    return Handler.ModificarServicio(servicio);
                }
                catch (Exception)
                {

                    throw new Exception("Error de conexión con la base de datos");
                }

            }
            return false;
        }
        return false;
       
    }

    public bool ModificarServicio(string idserv, string nombre, bool autenticaPorTarjeta, bool autenticaPorCI, bool autenticaPorPin, string estado, string tipoServicio, int cantCoord, DateTime fechaDescargaFTP, int frecuencia,bool asociados)
    {           //se modifica un servicio: sea simple o complejo
        if (Rol.Funcionalidades.Contains("Configuración de los Servicios"))
        {
            ServicioPersistente servicio = Handler.BuscarServicio(nombre);  // aqui se busca
            if (servicio == null)
                return false;
            servicio.IdServicio = idserv;
            servicio.AutenticaPorTarjeta = autenticaPorTarjeta;
            servicio.AutenticaPorCI = autenticaPorCI;
            servicio.AutenticaPorPin = autenticaPorPin;
            servicio.Estado = estado;
            servicio.TipoServicio = tipoServicio;
            servicio.CantCoord = cantCoord;
            servicio.FechaDescargaFTP = fechaDescargaFTP;
            servicio.Frecuencia = frecuencia;
            servicio.Asociados = asociados;
            try
            {
                if (Handler.ModificarServicio(servicio))
                {
                    List<string> TempDes = new List<string>();
                    TempDes.Add(servicio.Nombre);
                    if (servicio.TipoServicio == "01")
                        TempDes.Add("Modificar Servicio simple");
                    else
                        TempDes.Add("Modificar Servicio Complejo");

                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Configuración de los Servicios", DateTime.Now, TempDes));

                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
            return false;
        } 
        return false;

    }

    public bool DescargarFicheroServicioFTP(string IdServicio, DateTime fecha, out string mensaje)
    {
        // ejemplo de los parametros que se le pasa al sp
        //@downloadUrl = N'ftp://192.168.22.13/ONAT/onat/E032018.txt',
        //@SaveToDirectory = N'C:\\Empresas\\03',
        //@loadUrl = N'C:\\Empresas\\03\\E032018.txt',
        //@UserFtp = N'ftpuser',
        //@PassFtp = N'Metro2018*',
        //@idServicio = N'03',

        //string usuario_supervisor = Usuario;
        bool result_ftp = false;
        string nombServ = "";
        string downloadFTP = "";
        string loadBD = "";
        string SaveToDirectoryBD = "";
        mensaje = "";
        string aa = Convert.ToString(fecha.Year).Substring(2, 2);
        string mm = fecha.Month.ToString(); if (mm.Length == 1) { mm = "0" + mm; } // se le concatena el 0 delante del mes porque en la fecha la trae sin el 0 y el fichero trae 0
        string dd = fecha.Day.ToString(); if (dd.Length == 1) { dd = "0" + dd; }// se le concatena el 0 delante del dia porque en la fecha la trae sin el 0 y el fichero trae 0
        string nombre_fichero = "E" + IdServicio + aa + mm + dd + ".txt";
        try
        {
            ManipuladorFTP mFTP = new ManipuladorFTP();
            mFTP.UsuarioFTP = configuracion.UsuarioFTP;
            mFTP.ClaveUsuarioFTP = configuracion.ContraseñaFTP;
            mFTP.DireccionServidor = configuracion.DireccionServidorFtp;

            nombServ = Handler.BuscarNombreServ(IdServicio);
            nombServ = "//" + nombServ.ToUpper() + "//" + nombServ + "//"; // ruta del ftp donde se encuentra el fichero a descargar

            downloadFTP = mFTP.DireccionServidor + nombServ + nombre_fichero;

            SaveToDirectoryBD = "C:\\Empresas\\" + IdServicio; // ruta donde se va guardar en la BD
            loadBD = SaveToDirectoryBD + "\\" + nombre_fichero;



            //if (Handler.Descargar_Fichero_BD(downloadFTP, SaveToDirectoryBD, loadBD, mFTP.UsuarioFTP, mFTP.ClaveUsuarioFTP, IdServicio, Usuario, out mensaje) == true)
            if (Handler.Descargar_Fichero_BD(downloadFTP, SaveToDirectoryBD, loadBD, mFTP.UsuarioFTP, mFTP.ClaveUsuarioFTP, IdServicio, out mensaje) == true)
            {
                Handler.GuardarNotificacion(mensaje, "Administrador");
                result_ftp = true;
            }
            else
            {
                Handler.GuardarNotificacion("Error al descargar el fichero " + nombre_fichero + ". " + mensaje, "Administrador");
            }
        }

        catch (Exception e)
        {
            ///*escribir en el log*/

            //string path = @"C:\Logs_Telebanca\log_error.txt";

            //using (TextWriter writer = File.AppendText(path))
            //{
            //    string separador = " : ";
            //    string metodo_error = "ProcesarDescargaFTP \n";
            //    string nombre_proyecto = "(BusinessLayer): ";
            //    string date = DateTime.Now.ToString() + " \n";
            //    string separa = "-------------------------------------------------------";
            //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
            //}

            result_ftp = false;

            throw new Exception("Error: " + e.Message);
        }

        return result_ftp;

    }


    public bool EliminarServicio(string nombServ)
    {
        if (Rol.Funcionalidades.Contains("Configuración de los Servicios"))
        {
            try
            {
                ServicioPersistente servicio = Handler.BuscarServicio(nombServ); // se busca primero
                if (servicio == null)
                    return false;
                if (Handler.EliminarServicio(servicio.Nombre))
                {
                    List<string> TempDes = new List<string>();
                    TempDes.Add(servicio.Nombre);
                    if (servicio.TipoServicio == "01")
                        TempDes.Add("Eliminar Servicio simple");
                    else
                        TempDes.Add("Modificar Servicio Complejo");

                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Configuración de los Servicios", DateTime.Now, TempDes));
                    return true;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error de conexión con la base de datos");
            }
            return false;
        } return false;
    }

    public string[] ListaServiciosExistentes() // para mostrar los nombres de todos los servicios existentes en la interfaz grafica
    {
        if (Rol.Funcionalidades.Contains("Configuración de los Servicios") || Rol.Funcionalidades.Contains("Contratar Servicios"))
        {
            // se utiliza al principio
            try
            {
                listaServ = Handler.ListaServiciosExistentes();
            }
            catch (Exception)
            {

                throw new Exception("Error de conexión con la base de datos");
            }

            int length = listaServ.Count;

            string[] listaNom = new string[length]; //arreglo de nombres

            for (int i = 0; i < length; i++)
            {
                listaNom[i] = listaServ[i].Nombre;   // lleno la lista de nombres
            }

            return listaNom;
        }
        return new string[0];
    }
    public ArrayList GetListaAtributosDeServicios(string nombre)
    {   // devuelve los atributos sencillos del ServicioPersistente, 
        //dado un nombre:           
        if (Rol.Funcionalidades.Contains("Configuración de los Servicios"))
        {
            int lenght = listaServ.Count;           // esto es para Modificar el servicio


            foreach (ServicioPersistente serv in listaServ)
            {
                if (nombre == serv.Nombre)
                {
                    return this.ProcesaServicio(serv);  // metodo para devolver un array list de   
                }                                    // de arreglos de string con los atrivutos simples del servicio..       
            }
            return null;
        } return new ArrayList();

    }
    public ArrayList ProcesaServicio(ServicioPersistente serv)
    {    //se utiliza para devolver un ArrayList de string[] 
        //de los atrivutos de un servicio.
        ArrayList array = new ArrayList();
        string[] datos = new string[6];
        
        // comun para ambos los niveles de auteticacion
            if (serv.AutenticaPorCI)
                datos[0] = "CI";
            if (serv.AutenticaPorPin)
                datos[1] = "Pin";
            if (serv.AutenticaPorTarjeta)
                datos[2] = "Tarjeta";
                datos[3] = Convert.ToString(serv.CantCoord);
                if (serv.Asociados)
                {
                    datos[5] = "tiene asociados";
                }
                else { datos[5] = ""; }
            array.Add(datos.Clone());   //---------- 1´ la autenticacion

        if (serv.TipoServicio == "01")  // para un servicio simple
            {
            datos = new string[1];
            datos[0] = serv.TipoServicio;
            array.Add(datos.Clone());  //---------- 2   el tipo de servicio         
            datos[0] = serv.Estado;
            array.Add(datos.Clone());//----------  3   el estado del servicio           
            }
        else              // para un servicio complejo 
            { 
            datos = new string[1];              
            datos[0] = serv.Frecuencia.ToString();
            array.Add(datos.Clone());//----------2  // la frecuencia de actualizacion en el FTP
            datos[0] = serv.TipoServicio;
            array.Add(datos.Clone());//------------3  // el tipo de servicio
            DateTime d = serv.FechaDescargaFTP;
            array.Add(d);    //-------------------4  // la fecha de inicion para la descarga: el DateTime       
            datos[0] = serv.Estado;
            array.Add(datos.Clone());  //---------------5 // el estado del servicio

        }
       // comun para ambos el id servicio
        datos[0] = Convert.ToString(serv.IdServicio);
        array.Add(datos.Clone());//-------------4 o 6: el id del servicio
        return array;

    }
    public ArrayList GetListaDatosDeServicios(string nombSer) 
        // devuelve la lista de los Datos Persistentes que tiene el Servicio en la BD       
    {   // se utiliza en enlaze datos-servicio de Modificar Servicio                                                       
        if (Rol.Funcionalidades.Contains("Configuración de los Servicios"))
        {
            ArrayList array = new ArrayList();

            int pos = this.ObtenerPosServicio(nombSer);


            return this.ProcesaListaDatos(listaServ[pos].DatosPersistentes);// metodo para  
            //se utiliza para coger un Arraylist de string[] de la lista de DatosPersistentes  del servicio   
        }
        return new ArrayList();
    }
    #endregion Servicios
    #region DATOS

    public bool AdicionarDato(string nombreDato, string tipoDato, string tipo, int tamañoDato)
    {
        DatoPersistente dato = new DatoPersistente(nombreDato, tipoDato, tipo, tamañoDato);
        if (Rol.Funcionalidades.Contains("Configuración de los Datos"))
        {
            try
            {

                if ((Handler.BuscarDato(dato).NombreDato != null))
                    return false;

                if (Handler.AdicionarDato(dato))//adicionar un dato a un servicio dado
                {
                    List<string> listado = new List<string>();
                    listado.Add(nombreDato);
                    listado.Add("Adicionar Dato");
                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Configuración de los Datos", DateTime.Now, listado));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return false;
    }
    public bool ModificarDato(string nombreDato, string tipoDato, string tipo, int tamañoDato, string nombreAnt)
    {
        if (Rol.Funcionalidades.Contains("Configuración de los Datos"))
        {
            DatoPersistente dato = new DatoPersistente(nombreAnt, tipoDato, tipo, tamañoDato);

            try
            {
                if (Handler.BuscarDato(dato) != null)
                    if (nombreAnt != dato.NombreDato)
                        return false;
                dato.NombreDato = nombreDato;
                dato.TipoDato = tipoDato;
                dato.Tipo = tipo;
                dato.TamañoDato = tamañoDato;
                if (Handler.ModificarDato(dato, nombreAnt))//modificar un dato a un servicio dado  
                {
                    List<string> listado = new List<string>();
                    listado.Add(nombreDato);
                    listado.Add("Modificar Dato");
                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Configuración de los Datos", DateTime.Now, listado));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return false;

    }
    public bool EliminarDato(string nombreDato, string tipoDato, string tipo, int tamañoDato)
    {
        if (Rol.Funcionalidades.Contains("Configuración de los Datos"))
        {
            try
            {
                DatoPersistente dato = Handler.BuscarDato(new DatoPersistente(nombreDato, tipoDato, tipo, tamañoDato));
                if (dato == null)
                    return false;
                if (Handler.EliminarDato(dato))//Eliminar un dato a un servicio dado
                {
                    List<string> listado = new List<string>();
                    listado.Add(nombreDato);
                    listado.Add("Eliminar Dato");
                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Configuración de los Datos", DateTime.Now, listado));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return false;
    }

    public int ObtenerPosServicio(string nomServ)
    {
        int lenght = listaServ.Count;

        for (int i = 0; i < lenght; i++)
        {
            if (nomServ.Equals(listaServ[i].Nombre))
                return i;
        }
        return 0;

    }

    public ArrayList GetListadoTodosDatos() // devuelve la lista de todos los datos de la BD
    {   
        //se utiliza en: insertar servicio, modificar servicio
        try
        {
            List<DatoPersistente> listDatos = Handler.GetDatos();
            return ProcesaListaDatos(listDatos);
        }
        catch (Exception)
        {
            throw new Exception(" Error de conexión con la base de datos");
        }



    }
   
    public ArrayList ProcesaListaDatos(List<DatoPersistente> listDatos)
    {                                      //se utiliza para coger un Arraylist de string[] de la lista de DatosPersistentes  del servicio
        ArrayList array = new ArrayList();
        string[] desc = new string[5];

        foreach (DatoPersistente obj in listDatos)
        {
            desc[0] = obj.NombreDato.ToString();
            if (obj.TipoDato == null)
                desc[1] = null;
            else
                desc[1] = obj.TipoDato.ToString();
            desc[2] = obj.Tipo.ToString();
            desc[3] = Convert.ToString(obj.TamañoDato);

            array.Add(desc.Clone());

        }
        return array;

    }
    public ArrayList GetListaDatosNoAsociados() //devuelve lista de datos que no estan con ningun servicio
    {                                           //se utiliza en modificar dato, eliminar dato
        return ProcesaListaDatos(Handler.GetDatosNoAsociados());

    }
    #endregion DATOS

    //---------Fin---------Caso de Uso Configurar Servicios y Datos---------------Fin----------
    
    
   
    #region ACTUALIZAR_SERV_DATOS
    public ArrayList ActualizarServiciosDatos(object[] listBancos) 
    {
        if (Rol.Funcionalidades.Contains("Salvar y Restaurar Datos"))
        {
            try
            {
                List<string> listado = new List<string>();
                ArrayList result = new ArrayList();
                foreach (string var in listBancos)
                {
                    listado.Add(var);
                }
                List<string> TempDes = listado.GetRange(0, listado.Count);
                listado = Handler.ActualizarServicioDat(listado);

                foreach (string var in listado)
                {
                    result.Add(var);
                    TempDes.Remove(Handler.GetBancoDadoNombre(var).NumBanco);
                }
                for (int i = 0; i < TempDes.Count; i++)
                {
                    string aa = TempDes[i];
                    TempDes.RemoveAt(i);
                    TempDes.Insert(i, Handler.GetBancoDadoID(aa).Nombre);
                }
                if (TempDes.Count > 0)
                    Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Actualizar Información", DateTime.Now, TempDes));


                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        return new ArrayList(0);
    }
    public ArrayList ListadoDeBancosId() 
    {
        if (Rol.Funcionalidades.Contains("Salvar y Restaurar Datos"))
        {
            ArrayList array = new ArrayList();
            try
            {
                string[] aux = new string[2];
                List<BancoPersistente> list = Handler.ObtenerListaBanco();
                foreach (BancoPersistente var in list)
                {
                    aux[0] = var.Nombre;
                    aux[1] = var.NumBanco;
                    array.Add(aux.Clone());
                }
                return array;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        }
        return new ArrayList();
    }
    #endregion ACTUALIZAR_SERV_DATOS

    #region CONCILIACIONES


    //---------Inicio---------Caso de Uso Conciliaciones Automaticas---------------Inicio----------
    
    //Tarjetas en caliente Diarias
   

/****************************************************************************************************/
   
    //Transacciones diarias
    
        

/***************************************************************************************************/
    //Reclamaciones Diarias

    
    

    public bool ConciliacionesAuxiliaresTransaccion(DateTime fecha,string NumBanco)
    {

        if (!Handler.ActualizarTransacionesDeXMLParaDB())
            return false;
        if (Handler.FechaContableUltima().Date == fecha.Date)
            throw new Exception("La conciliación no puede ser enviada porque ese día no se ha cerrado aún...");

        return Handler.EnviarTransaccionesenDia(fecha, NumBanco);
    }

    public bool ConciliacionesAuxiliaresReclamaciones(DateTime fecha, string NumBanco)
    {
        return Handler.EnviarReclamacionesenDia(fecha, NumBanco);           
    }


    
    //---------Fin---------Caso de Uso Conciliaciones Automaticas---------------Fin----------------
    
    #endregion CONCILIACIONES

    //Modificacion para tratamiento de pago de multas T:1 o T:2---17/04/08***********************
    public string[] ObtenerMontoMulta(string art, string inciso, string peligrosidad)
    {
        return Handler.ObtenerMontoMulta(art, inciso, peligrosidad);
    }
    //***************************************************************************************

    //Modificacion mostrar el monto de etecsa 22/04/2008
    public string ProcesarFicheroEtecsa(string idTelefono)
    {
       return Handler.ProcesarFicheroEtecsa(idTelefono);
       
    }

    public void ReversarOperacion(string Id_Transaccion)
    {
      Handler.ReversarOperacion(Id_Transaccion,Usuario);
      //Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Consultar Saldo", DateTime.Now, descrip));
    }

    public DataSet TransferenciasP()
    {
        DataSet ds = new DataSet();
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            ds = Handler.TransfProv();
        }
        return ds;

        
    }
    public DataSet TransferenciasM(string codigo)
    {
        DataSet ds = new DataSet();
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            ds = Handler.TransfMun(codigo);
        }
        return ds;
    }
    public DataSet TransferenciasB(string codigo)
    {
        DataSet ds = new DataSet();
        if (Rol.Funcionalidades.Contains("Servicio de Pago"))
        {
            ds = Handler.TransfBanco(codigo);
        }
        return ds;
    }


    //Desbloquear Usuario
    public bool Desbloqueo_Usuario(string usuario)
    {
        bool result = false;
        
            try
            {
                result = Handler.Desbloquearusuario(usuario);
                List<string> descrip = new List<string>();
                descrip.Add(usuario);
                Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(Usuario, "Desbloquear Usuario", DateTime.Now, descrip));
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
        
        return result;
    }

}


