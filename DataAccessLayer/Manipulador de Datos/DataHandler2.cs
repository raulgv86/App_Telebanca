using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Timers;
using System.IO;
using System.Xml;
using System.Globalization;

namespace DataAccessLayer
{
    public partial class DataHandler
    {
        //--------------------------------------------------------------------------------------
        public BancoPersistente GetBancoDadoID(string ID_Banco)
        {
            try
            {
                DataSet1.TLB_BancoDataTable BDT;
                
                try
                {
                    BDT = new DataSet1TableAdapters.TLB_BancoTableAdapter().GetData();
                }
                catch (Exception)
                {
                    throw new Exception("No existe conexion con la BD");
                }

                DataSet1.TLB_BancoRow BROW = BDT.FindById_Banco(ID_Banco);
                if (BROW == null)
                {
                    throw new Exception("Banco Inexistente en la BD");
                }
                BancoPersistente BNK = new BancoPersistente();
                BNK.Abreviatura = BROW.Abreviatura;
                BNK.Nombre = BROW.Nombre;
                BNK.NumBanco = BROW.Id_Banco;
                BNK.PassWord = BROW.Pasword;
                BNK.WebServices = BROW.WebService;
                BNK.Centrollamad = BROW.CentroLlamadas;
                BNK.Identificationserver = BROW.WSIS;
                return BNK;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //****************************************************************************************
        public BancoPersistente GetBancoDadoNombre(string Nombre)
        {
            try
            {
                DataSet1.TLB_BancoDataTable BDT;
                try
                {
                    BDT = new DataSet1TableAdapters.TLB_BancoTableAdapter().GetBancoDadoNombre(Nombre);
                }
                catch (Exception)
                {
                    throw new Exception("No existe conexion con la BD");
                }
                if (BDT.Rows.Count == 0)
                {
                    throw new Exception("Nombre de Banco Inexistente en la BD");
                }
                DataSet1.TLB_BancoRow BROW = (DataSet1.TLB_BancoRow)BDT.Rows[0];
                BancoPersistente BNK = new BancoPersistente();
                BNK.Abreviatura = BROW.Abreviatura;
                BNK.Nombre = BROW.Nombre;
                BNK.NumBanco = BROW.Id_Banco;
                BNK.PassWord = BROW.Pasword;
                BNK.WebServices = BROW.WebService;
                return BNK;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //**************************************************************************************
        public Configuracion GetConfiguracion()
        {

            try
            {
                Configuracion o = new Configuracion();
                DataSet1.TLB_ConfiguraciónDataTable conf_dt = new DataSet1TableAdapters.TLB_ConfiguraciónTableAdapter().GetData();
                DataSet1.TLB_ConfiguraciónRow conf_row = null;
                if (conf_dt.Rows.Count > 0)
                {
                    conf_row = (DataSet1.TLB_ConfiguraciónRow)conf_dt.Rows[0];

                    o.DireccServBD = conf_row.DireccServBD;
                    //o.UsuarioBD = conf_row.UsuarioBD; // Raul
                    //o.ContrasenaBD = conf_row.ContrasenaBD; // Raul
                    o.HoraConciliaciones = (!conf_row.IsHoraConciliacionesNull()) ? conf_row.HoraConciliaciones : o.HoraConciliaciones;
                    o.DireccionServidorFtp = conf_row.DireccServFTP;
                    o.UsuarioFTP = conf_row.UsuarioFTP;
                    o.ContraseñaFTP = conf_row.ContraseñaFTP;
                    o.HoraInicioPetic = (!conf_row.IsHoraInicioPeticNull()) ? conf_row.HoraInicioPetic : o.HoraInicioPetic;
                    o.DireccSalvaBD = conf_row.DireccSalvaBD;
                    o.TiempoInactividad = (!conf_row.IsTiempoInactividadNull()) ? conf_row.TiempoInactividad : o.TiempoInactividad;
                    o.HoraSalva = (!conf_row.IsHoraSalvaNull()) ? conf_row.HoraSalva : o.HoraSalva;
                    try
                    { o.ImpresoraPin = conf_row.ImpresoraPin; }
                    catch { o.ImpresoraPin = ""; }
                    try
                    { o.ImpresoraTarjeta = conf_row.ImpresoraTarjeta; }
                    catch { o.ImpresoraTarjeta = ""; }
                }
                return o;
            }
            catch (Exception e)
            {
                ///*escribir en el log*/

                //string path = @"C:\Logs_Telebanca\log_error.txt";

                //using (TextWriter writer = File.AppendText(path))
                //{
                //    string separador = " : ";
                //    string metodo_error = "GetConfiguracion \n";
                //    string nombre_proyecto = "(DataAccessLayer): ";
                //    string date = DateTime.Now.ToString() + " \n";
                //    string separa = "-------------------------------------------------------";
                //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
                //}


                throw new Exception(e.Message);
            }


        }
        #region MOD_AUTENTICACION
        //CU_CREAR AUTENTICACIONES
        //PROGRAMADOR: Edisbel
        //**************************************************************************************
        public List<TarjetaPersistente> ObtenerSolicitudes(string IDBanco)
        {
            try
            {
                List<TarjetaPersistente> LT = new List<TarjetaPersistente>();
                BancoPersistente BNK = GetBancoDadoID(IDBanco);
                WSBanco.Service WS = new WSBanco.Service();
                WS.Url = BNK.WebServices;
                DataSet AUT = new DataSet();
                try
                {
                   // AUT = WS.TarjetasAImprimir();
                }
                catch 
                {
                    throw new Exception("No existe Conexion con el WebService: " + "'" + BNK.WebServices + "'" + " del Banco: " + BNK.Nombre);
                }
                
                AUT.WriteXml("C:\\TarjetasAimprimirll.xml");
                TextWriter tw2 = new StreamWriter("C:\\TarjetasAimprimirll.txt");
                tw2.WriteLine("entro");
                tw2.WriteLine("-----------------------");
                if ((AUT != null) && (AUT.Tables.Count > 0))
                    foreach (DataRow i in AUT.Tables[0].Rows)
                    {
                        TarjetaPersistente T = new TarjetaPersistente();
                        T.IdNumeroTarjeta = i.ItemArray[0].ToString();
                        tw2.WriteLine(T.IdNumeroTarjeta);
                        if (T.IdNumeroTarjeta.Length < 2)
                        { tw2.WriteLine("**************"); }
                        T.NombrePropietario = i.ItemArray[1].ToString();
                        tw2.WriteLine(T.NombrePropietario);
                        if (T.NombrePropietario.Length < 2)
                        { tw2.WriteLine("**************"); }
                        T.Apellidos = i.ItemArray[2].ToString();
                        tw2.WriteLine(T.Apellidos);
                        if (T.Apellidos.Length < 2)
                        { tw2.WriteLine("**************"); }
                        T.IdCliente = i.ItemArray[3].ToString();
                        tw2.WriteLine(T.IdCliente);
                        if (T.IdCliente.Length < 2)
                        { tw2.WriteLine("**************"); }
                        T.TipoIdentificacion = i.ItemArray[4].ToString();
                        tw2.WriteLine(T.TipoIdentificacion);
                        if (T.TipoIdentificacion.Length < 2)
                        { tw2.WriteLine("**************"); }
                        T.NoSucursal = i.ItemArray[5].ToString();
                        tw2.WriteLine(T.NoSucursal);
                        if (T.NoSucursal.Length < 2)
                        { tw2.WriteLine("**************"); }
                        T.Pais = i.ItemArray[6].ToString();
                        tw2.WriteLine(T.Pais);
                        if (T.Pais.Length < 2)
                        { tw2.WriteLine("**************"); }
                        tw2.WriteLine("-----------------------");
                        LT.Add(T);
                    }
                tw2.Close();
                return LT;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //********************************************************************************
        public List<string> ObtenerIDTarjetas()
        {
            try
            {
                List<string> lista_idTarjetas = new List<string>();
                DataSet1.TLB_TarjetaDataTable t_dt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetData();
                foreach (DataSet1.TLB_TarjetaRow i in t_dt)
                {
                    lista_idTarjetas.Add(i.Id_NoTarjeta);
                }
                return lista_idTarjetas;
            }
            catch (Exception)
            {
                throw new Exception("No Se puede Obtener los Id de las Tarjetas Existentes, No hay conexion con la Base de datos");
            }

        }
        //**********************************************************************************
        public List<Matriz> ObtenerNuevasMatrices()
        {
            try
            {
                List<Matriz> lm = new List<Matriz>();
                string[] filas = new string[10];
                DataSet1.TLB_MatrizDataTable matrices = new DataSet1TableAdapters.TLB_MatrizTableAdapter().ObtenerMatDes("desocupada");
                foreach (DataSet1.TLB_MatrizRow i in matrices)
                {
                    Matriz m = new Matriz();
                    m.ID = i.Id_Matriz;
                    m.Estado = i.Estado;
                    m.Encriptada = true;

                    filas[0] = i.C1;
                    filas[1] = i.C2;
                    filas[2] = i.C3;
                    filas[3] = i.C4;
                    filas[4] = i.C5;
                    filas[5] = i.C6;
                    filas[6] = i.C7;
                    filas[7] = i.C8;
                    filas[8] = i.C9;
                    filas[9] = i.C10;
                    m.Filas = filas;

                    lm.Add(m);
                }
                return lm;
            }
            catch (Exception)
            {
                throw new Exception("No se pueden Obtener Matrices, no hay conexion con la BD");
            }
        }
        //*******************************************************************************************
        public int GuardarNotificacion(Notificacion n)
        {
            try
            {
                DataSet1.TLB_NotificacionDataTable ndt = new DataSet1.TLB_NotificacionDataTable();
                DataSet1.TLB_NotificacionRow nrow = ndt.NewTLB_NotificacionRow();
                nrow.Descripcion = n.Descripcion;
                nrow.Id_Rol = n.Id_Rol;
                nrow.fecha = DateTime.Now;
                ndt.AddTLB_NotificacionRow(nrow);
                //new DataSet1TableAdapters.TLB_NotificacionTableAdapter(
                new DataSet1TableAdapters.TLB_NotificacionTableAdapter().Update(ndt);
                return nrow.Id_Notificacion;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //*******************************************************************************************
        public bool GuardarNotificacion(string message, string idRol)
        {
            try
            {
                new DataAccessLayer.DataSet1TableAdapters.TLB_NotificacionTableAdapter().Insert(message, idRol, DateTime.Now);
                return true;
            }
            catch (Exception)
            {
                AsegurarNotificaciones();
                DataSet1.TLB_NotificacionDataTable NDT = new DataSet1.TLB_NotificacionDataTable();
                NDT.ReadXml(DataHandler.MyCurrent.Server.MapPath("\\Ficheros\\Notificaciones\\Notificaciones.xml"));
                DataSet1.TLB_NotificacionRow NROW = NDT.NewTLB_NotificacionRow();
                NROW.Descripcion = message;
                NROW.Id_Rol = idRol;
                NROW.fecha = DateTime.Now;
                NDT.AddTLB_NotificacionRow(NROW);
                NDT.WriteXml(DataHandler.MyCurrent.Server.MapPath("\\Ficheros\\Notificaciones\\Notificaciones.xml"));
                return false;
            }
        }
        //**************************************************************************************************

        private void AsegurarNotificaciones()
        {
            string p = DataHandler.MyCurrent.Server.MapPath("\\Telebanca\\Ficheros\\Notificaciones");

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(p);
            System.IO.FileInfo[] fi = di.GetFiles("Notificaciones.xml");
            if (fi.Length == 0)
            {
                System.IO.FileStream fs = new System.IO.FileStream(p + "\\Notificaciones.xml", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
                System.IO.StreamWriter aa = new System.IO.StreamWriter(fs);
                aa.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                aa.WriteLine("<DocumentElement />");
                aa.Close();
                fs.Close();
            }
            //****************
        }
        //**************************************************************************************************
        public bool CargarNotificacionesBD()
        {
            string p = DataHandler.MyCurrent.Server.MapPath("\\Ficheros\\Notificaciones\\Notificaciones.xml");
            try
            {
                AsegurarNotificaciones();
                System.IO.FileStream f = new System.IO.FileStream(p, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
                DataSet1.TLB_NotificacionDataTable NDT = new DataSet1.TLB_NotificacionDataTable();
                NDT.ReadXml(f);
                f.Close();
                new DataSet1TableAdapters.TLB_NotificacionTableAdapter().Update(NDT);

                //estas dos lines de codigo son para borrar toda la informacion del xml
                //sin perder el formato valido del xml
                System.IO.FileStream ww = new System.IO.FileStream(p, System.IO.FileMode.Truncate, System.IO.FileAccess.Write);

                DataSet1.TLB_NotificacionDataTable N = new DataSet1.TLB_NotificacionDataTable();
                N.WriteXml(ww);
                ww.Close();

                //*****FTP

                CargarMensagesFicheroFTP();
                //********




                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //****************************************************************************************
        private void CargarMensagesFicheroFTP()
        {
            string fich = DataHandler.MyCurrent.Server.MapPath("\\Ficheros\\MensajeEmergenciaFTP\\");
            DirectoryInfo directorio = new DirectoryInfo(fich);
            FileInfo[] filInf = directorio.GetFiles("*.txt");
            DataSet1.TLB_NotificacionDataTable nt = new DataSet1.TLB_NotificacionDataTable();
            foreach (FileInfo fil in filInf)
            {
                StreamReader r = new StreamReader(fil.FullName);
                string lin = "";
                if ((lin = r.ReadLine()) != "")
                {
                    DataSet1.TLB_NotificacionRow nr = nt.NewTLB_NotificacionRow();
                    nr.Descripcion = lin;
                    nr.Id_Rol = "Administrador";
                    nt.AddTLB_NotificacionRow(nr);
                    r.Close();
                    StreamWriter w = new StreamWriter(fil.FullName);
                    w.WriteLine("");
                    w.Close();
                }


            }
            new DataSet1TableAdapters.TLB_NotificacionTableAdapter().Update(nt);

        }
        //****************************************************************************************
        public bool ActualizarEstadoMatrices(List<Matriz> lm)
        {
            try
            {
                DataSet1.TLB_MatrizDataTable mdt = new DataSet1TableAdapters.TLB_MatrizTableAdapter().GetData();
                int pos = 0;
                foreach (DataSet1.TLB_MatrizRow i in mdt)
                {
                    if (lm.Count > pos)
                    {
                        if (i.Id_Matriz == lm[pos].ID)
                        {
                            i.Estado = "ocupada";
                            pos++;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                new DataSet1TableAdapters.TLB_MatrizTableAdapter().Update(mdt);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Matrices no Actualizadas, no existe coneion con la BD");
            }
        }
        //*********************************************************************************************
        public bool GuardarTargetasProcesadas(List<TarjetaPersistente> l_procesadas)
        {
            try
            {
                DataSet1.TLB_TarjetaDataTable tDT = new DataSet1.TLB_TarjetaDataTable();
                foreach (TarjetaPersistente i in l_procesadas)
                {                    
                    DataSet1.TLB_TarjetaRow tarjeta_row = tDT.NewTLB_TarjetaRow();

                    tarjeta_row.Id_NoTarjeta = i.IdNumeroTarjeta;
                    tarjeta_row.No_Pin = i.NoPin;
                    tarjeta_row.Nombre = i.NombrePropietario;
                    tarjeta_row.PrimerApellido = i.Apellidos;
                    tarjeta_row.NoSucursal = i.NoSucursal;
                    tarjeta_row.FechaOrdenImp = i.FechaOrdenImp;
                    tarjeta_row.EstadoPin = i.EstadoPin;
                    tarjeta_row.Estado = i.Estado;
                    tarjeta_row.Id_Matriz = i.Matriz.ID;
                    if (i.IdLote > 0)
                    {
                        tarjeta_row.Id_Lote = i.IdLote;
                    }
                    tarjeta_row.IdentificacionCliente = i.IdCliente;
                    tarjeta_row.TipoIdentificacion = i.TipoIdentificacion;
                    tarjeta_row.Id_Pais = i.Pais;

                    tDT.AddTLB_TarjetaRow(tarjeta_row);

                }
                new DataSet1TableAdapters.TLB_TarjetaTableAdapter().Update(tDT);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Tarjetas no Guardadas, " + ex.Message);  //"Tarjetas no Guardadas, No existe conexion con la BD"
            }
        }
        //************************************************************************************
        public List<TarjetaPersistente> ConectWSBuscarTarjetasDarBaja(BancoPersistente b)
        {
            try
            {
                WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
                ws.Url = b.WebServices;
                List<TarjetaPersistente> ltp = new List<TarjetaPersistente>();
                DataSet dset = ws.TarjetasCanceladas();
                foreach (DataRow i in dset.Tables[0].Rows)
                {
                    TarjetaPersistente tp = new TarjetaPersistente();
                    tp.IdNumeroTarjeta = i.ItemArray[0].ToString();
                    tp.Estado = i.ItemArray[1].ToString();
                    ltp.Add(tp);
                }
                return ltp;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*********************************************************************************************************
        public bool ExisteTarjeta(string id)
        {
            try
            {
                return (new DataSet1TableAdapters.TLB_TarjetaTableAdapter().ExisteTarjeta1(id).Rows.Count > 0);
            }
            catch (Exception)
            {
                throw new Exception("Error de Conexion con la Base de Datos");
            }
        }
        //*********************************************************************************************************
        public bool ActualizarEstadoTarjeta(string idTarjeta, string estado)
        {
            try
            {
                new DataSet1TableAdapters.TLB_TarjetaTableAdapter().UpdateEstadoTarjeta(estado, idTarjeta);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("No existe conexion con la Base de Datos");
            }
        }
        //*********************************************************************************************************        
        //CU_CONCILIACIONES AUTOMATICAS
        //PROGRAMADOR: Edisbel
        public List<LotePersistente> ObtenerLotesEnFechaPin(DateTime fp)
        {
            try
            {
                List<LotePersistente> llp = new List<LotePersistente>();
                DateTime fIni = new DateTime(fp.Year, fp.Month, fp.Day, 0, 0, 0);
                DateTime fFin = new DateTime(fp.Year, fp.Month, fp.Day, 23, 59, 59);
                DataSet1.TLB_LoteDataTable l_dt = new DataSet1TableAdapters.TLB_LoteTableAdapter().ObtenerLotesEnFechaPin(fIni, fFin);
                foreach (DataSet1.TLB_LoteRow i in l_dt)
                {
                    LotePersistente lote = new LotePersistente();
                    lote.Id_Lote = i.Id_Lote;
                    lote.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                    lote.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                    lote.FechaHoraImpPin = i.FechaHoraPin;
                    lote.IdUsuarioPin = i.Id_UsuarioPin;

                    llp.Add(lote);
                }
                return llp;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //**********************************************************************************************************
        public List<TarjetaPersistente> ObtenerTarjetasdeLote(int Id_lote)
        {
            try
            {
                List<TarjetaPersistente> lista_tarjetas = new List<TarjetaPersistente>();
                DataSet1.TLB_TarjetaDataTable t_dt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(Id_lote);
                DataSet1.TLB_MatrizDataTable MDT = new DataSet1TableAdapters.TLB_MatrizTableAdapter().GetData();
                foreach (DataSet1.TLB_TarjetaRow i in t_dt)
                {
                    DataSet1.TLB_MatrizRow MROW = MDT.FindById_Matriz(i.Id_Matriz);
                    Matriz M = new Matriz();
                    TarjetaPersistente tar = new TarjetaPersistente();
                    tar.IdNumeroTarjeta = i.Id_NoTarjeta;
                    tar.NoPin = i.No_Pin;
                    tar.NombrePropietario = i.Nombre;
                    tar.Apellidos = i.PrimerApellido;
                    tar.NoSucursal = i.NoSucursal;
                    tar.FechaOrdenImp = i.FechaOrdenImp;
                    tar.EstadoPin = i.EstadoPin;
                    tar.Estado = i.Estado;
                    //tar.Matriz.ID = i.Id_Matriz;                    
                    M.ID = MROW.Id_Matriz;
                    M.Estado = MROW.Estado;
                    string[] fil = new string[10];
                    fil[0] = MROW.C1;
                    fil[1] = MROW.C2;
                    fil[2] = MROW.C3;
                    fil[3] = MROW.C4;
                    fil[4] = MROW.C5;
                    fil[5] = MROW.C6;
                    fil[6] = MROW.C7;
                    fil[7] = MROW.C8;
                    fil[8] = MROW.C9;
                    fil[9] = MROW.C10;
                    M.Filas = fil;
                    tar.Matriz = M;
                    try { tar.IdLote = i.Id_Lote; }
                    catch { tar.IdLote = -1; }
                    tar.IdCliente = i.IdentificacionCliente;
                    tar.Pais = i.Id_Pais;

                    lista_tarjetas.Add(tar);
                }
                return lista_tarjetas;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //*******************************************************************************************************
        public List<string> TarjetasCanceladasEnDiaDeBanco(DateTime d, string idBanco)//OK
        {
            try
            {
                idBanco = idBanco + "%";
                List<string> tj = new List<string>();
                DateTime fIni = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
                DateTime fFin = new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
                DataSet1.TLB_HistoricoTarjetasDataTable t_dt = new DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter().TarjetasCanceladasEnDiaDeBanco("D", "P", fIni, fFin, idBanco);

                foreach (DataSet1.TLB_HistoricoTarjetasRow i in t_dt)
                {
                    tj.Add(i.NoTarjeta);
                }
                return tj;
            }
            catch (Exception)
            {
                throw new Exception("No existe Conexion con la BD");
            }
        }

        //*********************************************************************************************************
        public List<string> TarjetasDeBancoActivasEnFecha(DateTime fecha, string idBanco)//OK
        {
            try
            {
                idBanco = idBanco + "%";
                List<string> ids_tarjetas = new List<string>();
                DateTime fini = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
                DateTime ffin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
                DataSet1.TLB_TarjetaDataTable t_dt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().TarjetasDeBancoActivasEnFecha(idBanco, fini, ffin, "A");
                foreach (DataSet1.TLB_TarjetaRow i in t_dt)
                {
                    ids_tarjetas.Add(i.Id_NoTarjeta);
                }
                return ids_tarjetas;
            }
            catch (Exception)
            {
                throw new Exception("No existe Conexion con la BD");
            }
        }
        //******************************************************************************
        public List<string> TarjetasDeBancoCreadasEnDia(DateTime f, string IDBanco)//OK
        {
            try
            {
                List<string> LST = new List<string>();
                IDBanco = IDBanco + "%";
                DateTime fini = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
                DateTime ffin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59);
                DataSet1.TLB_TarjetaDataTable TDT = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().TarjetasDeBancoCreadasEnDia(fini, ffin, IDBanco, "C");
                foreach (DataSet1.TLB_TarjetaRow i in TDT)
                {
                    LST.Add(i.Id_NoTarjeta);
                }
                return LST;

            }
            catch (Exception)
            {

                throw new Exception("No existe Conexion con la BD");

            }
        }
        //**************************************************************
        public string AutenticarConWS(string PassWord, string Url)
        {
            try
            {
                WSBanco.Service WS = new WSBanco.Service();
                WS.Url = Url;
                return WS.Autenticar(PassWord);
            }
            catch (Exception)
            {
                throw new Exception("No hay Conexion Con el Web Service");
            }

        }

        //***********************************************************
        public string[] EnviarConciliacionActivas(string[] ids, string Url)//OK
        {
            try
            {
                WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
                ws.Url = Url;
                return ws.ConfirmarImpresion(ids);
            }
            catch 
            {
                throw new Exception("No hay conexion con el WS: " + Url);
            }
        }
        //---------------------------------------------------------------------------------------------------------
        public string[] EnviarConciliacionCanceladas(string[] t, string Url)//OK
        {
            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = Url;
                return ws.ConfirmarCanceladas(t);
            }
            catch 
            {
                throw new Exception("No hay conexion con el WS: " + Url);
            }
        }
        //*****************************************************************************************************
        public string[] EnviarConciliacionCreadas(string[] lti, string Url)
        {
            try
            {
                WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
                ws.Url = Url;
                return ws.ConfirmarCreadas(lti);
            }
            catch (Exception)
            {
                throw new Exception("No hay conexion con el WS: " + Url);
            }
        }
        //*********************************************************************************************************
        public bool UpdateEstadoTarjeta(string IdTarjeta, string estado)
        {
            try
            {
                new DataSet1TableAdapters.TLB_TarjetaTableAdapter().UpdateEstadoTarjeta(estado, IdTarjeta);
                return true;

            }
            catch (Exception)
            {
                throw new Exception("No hay Conexion con la BD");
            }

        }
        //**************************************************************************************
        public bool UpdateEstadoTarjetaHistorico(string IdTarjeta, string estado)
        {
            try
            {
                new DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter().UpdateEstadoTarjeta(estado, IdTarjeta);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("No hay Conexion con la BD");
            }
        }
        //******************************** CU IMPRIMIR PINES ****************************************************
        public void ActualizarEstadoPinTarjetas(int idLote)
        {
            try
            {
                DataSet1.TLB_TarjetaDataTable TDT = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(idLote);
                foreach (DataSet1.TLB_TarjetaRow i in TDT.Rows)
                {
                    i.EstadoPin = "A";
                }
                new DataSet1TableAdapters.TLB_TarjetaTableAdapter().Update(TDT);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //********************************************************************************************************
        public void ActualizarEstadoPinLote(int idLote, DateTime f)
        {
            try
            {
                DataSet1.TLB_LoteDataTable LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().ObtenerLoteDadoIdLote(idLote);
                if (LDT.Rows.Count == 0)
                {
                    throw new Exception("Id de Lote inexistente en BD");
                }
                else
                {
                    DataSet1.TLB_LoteRow LROW = (DataSet1.TLB_LoteRow)LDT.Rows[0];
                    LROW.EstadoP = "F";
                    LROW.FechaHoraPin = f;
                    new DataSet1TableAdapters.TLB_LoteTableAdapter().Update(LDT);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //***************************************************************************************************
        public void ActualizarEstadoTLote(int idLote, DateTime f)
        {
            try
            {
                DataSet1.TLB_LoteDataTable LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().ObtenerLoteDadoIdLote(idLote);
                if (LDT.Rows.Count == 0)
                {
                    throw new Exception("Id de Lote inexistente en BD");
                }
                else
                {
                    DataSet1.TLB_LoteRow LROW = (DataSet1.TLB_LoteRow)LDT.Rows[0];
                    LROW.EstadoT = "F";
                    LROW.FechaHoraTarjeta = f;
                    new DataSet1TableAdapters.TLB_LoteTableAdapter().Update(LDT);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //**************** INICIO ************************ CU_REALIZAR REPORTE ***********************************
        //PROGRAMADOR: Edisbel
        public List<LotePersistente> ObtenerLotesPorAmbosEstados(string estt, string estp)
        {
            try
            {
                List<LotePersistente> lista_lotes = new List<LotePersistente>();
                DataSet1.TLB_LoteDataTable ldt = new DataSet1TableAdapters.TLB_LoteTableAdapter().LotesPorAmbosEstados(estt, estp);
                foreach (DataSet1.TLB_LoteRow i in ldt)
                {
                    LotePersistente lote = new LotePersistente();
                    lote.Id_Lote = i.Id_Lote;
                    lote.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                    lote.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                    lote.FechaHoraImpPin = i.FechaHoraPin;
                    lote.EstadoT = i.EstadoT;
                    lote.EstadoP = i.EstadoP;
                    DataSet1.TLB_TarjetaDataTable tdt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(i.Id_Lote);
                    List<TarjetaPersistente> listaTarjetas = new List<TarjetaPersistente>();
                    foreach (DataSet1.TLB_TarjetaRow j in tdt)
                    {
                        TarjetaPersistente tar = new TarjetaPersistente();
                        tar.IdNumeroTarjeta = j.Id_NoTarjeta;
                        tar.NoPin = j.No_Pin;
                        tar.NombrePropietario = j.Nombre;
                        tar.Apellidos = j.PrimerApellido;
                        tar.NoSucursal = j.NoSucursal;
                        tar.FechaOrdenImp = j.FechaOrdenImp;
                        tar.EstadoPin = j.EstadoPin;
                        tar.Estado = j.Estado;
                        tar.Matriz.ID = j.Id_Matriz;
                        try { tar.IdLote = j.Id_Lote; }
                        catch { tar.IdLote = -1; }
                        tar.IdCliente = j.IdentificacionCliente;
                        tar.TipoIdentificacion = j.TipoIdentificacion;
                        tar.Pais = j.Id_Pais;
                        listaTarjetas.Add(tar);
                    }
                    lote.Tarjetas = listaTarjetas;
                    lista_lotes.Add(lote);
                }
                return lista_lotes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //**************** FIN *************************** CU_REALIZAR REPORTE ***********************************

        #endregion
        #region MOD_SERVICIO INFORMACION
        //Programador del acceso a datos: Edisbel
        /************* INICIO ************** MODULO SERVICIO INFORMACION *************** INICIO ***************/
        public bool ExisteInformacion(string Tema)
        {
            try
            {
                DataSet1.TLB_TemaDataTable tDT = new DataSet1TableAdapters.TLB_TemaTableAdapter().ExisteInfoDeTema(Tema);
                if (tDT.Rows.Count != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*****************************************************************************************************
        public bool ExisteInformacion(int id_Tema)
        {
            try
            {
                DataSet1.TLB_TemaDataTable tDT = new DataSet1TableAdapters.TLB_TemaTableAdapter().ExisteT(id_Tema);
                if (tDT.Rows.Count != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*****************************************************************************

        //********************************************************************************        
        public List<InformacionPersistente> ListaTemas()
        {
            try
            {
                List<InformacionPersistente> result = new List<InformacionPersistente>();
                DataSet1.TLB_TemaDataTable tema_dt = new DataSet1TableAdapters.TLB_TemaTableAdapter().GetData();

                foreach (DataSet1.TLB_TemaRow i in tema_dt.Rows)
                {
                    InformacionPersistente temp = new InformacionPersistente();
                    temp.Tema = i.Tema;
                    temp.Texto = i.Descripcion;
                    temp.IdTema = i.Id_Tema;
                    result.Add(temp);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /************* FIN ***************** MODULO SERVICIO INFORMACION **************** FIN *****************/
    #endregion
        #region MOD_SERVIVIO DE PAGO
        public bool AgregarReclamacion(ReclamacionTransaccion r)
        {
            try
            {
                new DataSet1TableAdapters.TLB_ReclamacionTableAdapter().Insert(r.Fecha, int.Parse(r.IdTransaccion), r.IdUsuario, r.Descripcion);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*******************************************************************************************

        //Arreglar esto con Ernesto!!!!!!!!!
        public Transaccion BuscarTransaccionAReclamar(string traza, DateTime f)
        {
            try
            {
                Transaccion output = new Transaccion();
                DateTime fini = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
                DateTime ffin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59);
                DataSet1.TLB_TransaccionDataTable t_dt = new DataSet1TableAdapters.TLB_TransaccionTableAdapter().ObtenerTransaccionPorTrazaYFecha(traza, fini, ffin);
                if (t_dt.Rows.Count == 0)
                {
                    return output;
                }
                DataSet1.TLB_TransaccionRow r = (DataSet1.TLB_TransaccionRow)t_dt.Rows[0];
                DataSet1.TLB_DatosTransaccionDataTable dtdt = new DataSet1TableAdapters.TLB_DatosTransaccionTableAdapter().DatosTransacPorID(r.Id_Transaccion);

                output.ConsecutivoTransac = r.Id_Transaccion.ToString();
                output.Traza = r.Traza;
                output.IdServicio = r.ID_SERV.ToString();
                output.IdUsuario = r.Id_Usuario;
                output.Fecha = r.FechaHora;
                output.NumeroTarjeta = r.Id_NoTarjeta;
                List<string> datos = new List<string>();
                foreach (DataSet1.TLB_DatosTransaccionRow i in dtdt)
                {
                    datos.Add(IdDatoToString(i.ID_DATOS.ToString()) + i.Valor);
                }
                output.Datos = datos.ToArray();

                return output;
            }

            catch (Exception)
            {
                throw new Exception("No hay Conexion con la BD");
            }

        }
        //***************************************************************************************************

        public bool BorrarNotificacion(int idNotificacion)
        {
            try
            {
                new DataSet1TableAdapters.TLB_NotificacionTableAdapter().DeleteNotificacion(idNotificacion);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //********************************************************************************************
        public int BuscarHoraDescargaFTP()
        {
            try
            {
                int output = Convert.ToInt32(GetConfiguracion().HoraInicioPetic);
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //**********************************************************************************************
        public int BuscarFrecuenciaDescargaFTP(string codServicio)
        {
            try
            {
                DataSet1.TLB_C_SERVBTDataTable serv_dt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetServicioPorID(codServicio);
                DataSet1.TLB_C_SERVBTRow serv_row = (DataSet1.TLB_C_SERVBTRow)serv_dt.Rows[0];

                return (Convert.ToInt32(serv_row.FrecuenciaDescargaFTP));

            }
            catch (Exception)
            {
                throw;
            }
        }
        //*********************************************************************************************
        public string BuscarCodigoError(string traza)
        {
            try
            {
                DataSet1.TLB_ErrorDataTable error_dt = new DataSet1TableAdapters.TLB_ErrorTableAdapter().BuscarError(traza);
                DataSet1.TLB_ErrorRow error_row = (DataSet1.TLB_ErrorRow)error_dt.Rows[0];
                return error_row.Descripcion;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*********************************************************************************************
        public List<TarjetaPersistente> BuscarTarjetasPorCI(string CI)
        {
            try
            {
                List<TarjetaPersistente> tar_list = new List<TarjetaPersistente>();
                DataSet1.TLB_TarjetaDataTable t_dt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTargetasDadoCI(CI);
                foreach (DataSet1.TLB_TarjetaRow i in t_dt)
                {
                    TarjetaPersistente t = new TarjetaPersistente();
                    t.IdNumeroTarjeta = i.Id_NoTarjeta;
                    t.NoPin = i.No_Pin;
                    t.NombrePropietario = i.Nombre;
                    t.Apellidos = i.PrimerApellido;

                    t.NoSucursal = i.NoSucursal;
                    t.FechaOrdenImp = i.FechaOrdenImp;
                    t.EstadoPin = i.EstadoPin;
                    t.Estado = i.Estado;
                    t.Matriz.ID = i.Id_Matriz;
                    try { t.IdLote = i.Id_Lote; }
                    catch { t.IdLote = -1; }
                    t.IdCliente = i.IdentificacionCliente;
                    t.TipoIdentificacion = i.TipoIdentificacion;
                    t.Pais = i.Id_Pais;

                    tar_list.Add(t);

                }
                return tar_list;
            }
            catch (Exception)
            {
                throw;
            }
        }





        /*******************************************************************************************************/
        public List<Servicio> ObtenerServiciosContratados(string numTarjeta)
        {
            BancoPersistente bp = new BancoPersistente();
            try
            {
                bp = BuscarBanco(this.N_CLlamadas());
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
            WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
            ws.Url = bp.WebServices;
            DataSet dset = new DataSet();
            try
            {
                dset = ws.ServiciosxTarjeta(numTarjeta);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con el Web Services");
            }
            List<Servicio> ls = new List<Servicio>();
            try
            {
                //Mostrar servicios por defecto
                Servicio s = new Servicio();
                s.CodigoServicio = "04";
                ls.Add(s);
                Servicio s1 = new Servicio();
                s1.CodigoServicio = "03";
                ls.Add(s1);
                Servicio s2 = new Servicio();
                s2.CodigoServicio = "06";
                ls.Add(s2);
                Servicio s3 = new Servicio();
                s3.CodigoServicio = "07";
                ls.Add(s3);
                Servicio s4 = new Servicio();
                s4.CodigoServicio = "08";
                ls.Add(s4);
                Servicio s5 = new Servicio();
                s5.CodigoServicio = "09";
                ls.Add(s5);
                
                //Raul: gas
                //Servicio s6 = new Servicio();
                //s5.CodigoServicio = "11";
                //ls.Add(s6);
                foreach (DataRow i in dset.Tables[0].Rows)
                {
                    if ((!ls[ls.Count - 1].CodigoServicio.Equals(i.ItemArray[0].ToString())))
                    {
                        s = new Servicio();
                        ls.Add(s);
                        s.CodigoServicio = i.ItemArray[0].ToString();
                    }
                    if (i.ItemArray[1].ToString() != "")
                    {
                        Asociado a = new Asociado();
                        s.Asociados.Add(a);
                        a.Datos.Add(new Dato((Convert.ToInt32(i.ItemArray[1])).ToString(), i.ItemArray[2].ToString()));
                    }
                }
                return ls;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }

        }

        public bool ModificarContrato(Interfaz_de_Datos.ContratoPersistente pContrato,string usuario)
        {
            BancoPersistente bp = new BancoPersistente();
            try
            {
                bp = BuscarBanco(pContrato.Tarjeta.IdNumeroTarjeta.Substring(0, 2));
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
            WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
            ws.Url = bp.WebServices;
            DataSet dset = new DataSet();
            try
            {
                dset = ws.ServiciosxTarjeta(pContrato.Tarjeta.IdNumeroTarjeta);
            }
            catch (Exception )
            {
                throw new Exception("Error de conexión con el Web Services");
            }

            // Descartando que se modifique el servicio de Multas...
            for (int i = 0; i < pContrato.Sevicios.Count; i++)
                if (pContrato.Sevicios[i].CodigoServicio.Equals("04"))
                {
                    pContrato.Sevicios.RemoveAt(i);
                    break;
                }
            try
            {
                dset.Tables[0].Clear();
                foreach (Servicio i in pContrato.Sevicios)
                    foreach (Asociado j in i.Asociados)
                    {
                        DataRow TempRow = dset.Tables[0].NewRow();
                        TempRow[0] = i.CodigoServicio;
                        TempRow[1] = j.Datos[0].Id;
                        TempRow[2] = j.Datos[0].Valor;
                        dset.Tables[0].Rows.Add(TempRow);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataSet a = dset; 
            // llamar al m'etodo de karina
            try
            {
                //XmlDocument xmlaa = new XmlDocument();
                string xml = dset.GetXml();
               // xmlaa = dset.GetXml();
                //dset.WriteXml("C:\\prueba.xml");
                //xmlaa.Save("xm"
                //return 
                
                string[] resp = ws.ActualizaContrato(pContrato.Tarjeta.IdNumeroTarjeta, dset, usuario);
               // Handler.InsertarAccionUsuario(new AccionUsuarioPersistente(this.Usuario, "Configuración de los Servicios", DateTime.Now, TempDes));
                string cod = resp[0].ToString();
                string desc = resp[1].ToString();
                
                if (cod == "0")
                { return true;}
                else
                { return false; }
                
                //return resp;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con el Web Services");
            }
            
            //return resp; 
        }

        /*******************************************************************************************************/
        public DataSet ConsultarSaldo(string numTarjeta)
        {
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
                return ws.ConsultaSaldo(numTarjeta);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
        }
        public DataSet ConsultaSaldoIntegrada(string tarjeta)
        {
            DataSet Saldos = new DataSet();
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(tarjeta.Substring(0, 2));
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
               Saldos = ws.ConsultaSaldoCuentas(tarjeta);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
            return Saldos;      
        }
        /*******************************************************************************************************/
        #region<Raul: (anterior a lo del USD) EnviarTransaccion>
        //public string EnviarTransaccion(Transaccion t, bool moneda)
        //{
        //    WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
        //    BancoPersistente bnk = new BancoPersistente();
        //    string aux = "000";
        //    string[] salida = new string[0];//new string[] { "1234567890000", "00" }; 

        //    DateTime FechaReal = t.Fecha;//Cambio fecha
        //    DataSet1.TLB_TransaccionDataTable t_dt = new DataSet1.TLB_TransaccionDataTable();
        //    DataSet1.TLB_TransaccionRow t_row = t_dt.NewTLB_TransaccionRow();
        //    t_row.Id_Usuario = t.IdUsuario;
        //    t_row.Id_NoTarjeta = t.NumeroTarjeta;
        //    //t_row.FechaHora = t.Fecha;
        //    t_row.FechaHora = new DateTime(t.Fecha.Year, t.Fecha.Month, t.Fecha.Day, t.Fecha.Hour, t.Fecha.Minute, t.Fecha.Second);
        //    //t_row.FechaHoraContable = FechaContableUltima().Add(new TimeSpan(t.Fecha.Hour, t.Fecha.Minute, t.Fecha.Second));
        //    DateTime contult = FechaContableUltima();
        //    t_row.FechaHoraContable = new DateTime(contult.Year, contult.Month, contult.Day, t.Fecha.Hour, t.Fecha.Minute, t.Fecha.Second);
        //    string IdServicio = "";
        //    if (Convert.ToInt32(t.IdServicio) > 50)
        //    {
        //        IdServicio = "0" + Convert.ToString(Convert.ToInt32(t.IdServicio) - 50);
        //        if (IdServicio.Length > 2)
        //        {
        //            IdServicio = IdServicio.Substring(1, 2);
        //        }
        //        t_row.ID_SERV = IdServicio;
        //    }
        //    else
        //    {
        //        t_row.ID_SERV = t.IdServicio;
        //    }

        //    t_row.Asociado = " ";
        //    if (moneda == true)
        //    {
        //        if (Convert.ToInt32(t.IdServicio) > 50)
        //        {
        //            t_row.Importe = 12;
        //        }
        //        else
        //        {
        //            t_row.Importe = 2;
        //        }

        //    }
        //    if (moneda == false)
        //    {
        //        if (Convert.ToInt32(t.IdServicio) > 50)
        //        {
        //            t_row.Importe = 21;
        //        }
        //        else
        //        {
        //            t_row.Importe = 1;
        //        }
        //    }
        //    t_row.Traza = " ";

        //    t_dt.AddTLB_TransaccionRow(t_row);
        //    try
        //    {
        //        bnk = GetBancoDadoID(t.NumeroTarjeta.Substring(0, 2));
        //        new DataSet1TableAdapters.TLB_TransaccionTableAdapter().Update(t_dt);
        //        t.Fecha = t_row.FechaHoraContable;
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Error de conexión con la base de datos");
        //    }
        //    ws.Url = bnk.WebServices;

        //    aux += t_row.Id_Transaccion.ToString();
        //    //***********************************
        //    string IdTransaccion = t_row.Id_Transaccion.ToString();
        //    //***********************************
        //    aux = aux.ToString().Substring(aux.ToString().Length - 4);
        //    //***Crear arreglo bidimensional
        //    string[] dat = t.Datos;
        //    string[][] dat2 = new string[dat.Length][];
        //    for (int i = 0; i < dat.Length; i++)
        //    {
        //        dat2[i] = new string[2];
        //    }

        //    for (int i = 0; i < dat.Length; i++)
        //    {
        //        dat2[i][0] = dat[i].Substring(0, 2);
        //        dat2[i][1] = dat[i].Substring(2);
        //    }
        //    //****           
        //    try
        //    {
        //        int horareal = FechaReal.Hour;
        //        int horaBT = t.Fecha.Hour;
        //        if (t.IdServicio == "07" || t.IdServicio == "57")
        //        {
        //            salida = ws.Transferencias(t.NumeroTarjeta, t.IdServicio, moneda, dat2, aux, FechaReal, horareal, t.Fecha, horaBT);
        //        }
        //        else if (t.IdServicio == "09" || t.IdServicio == "59")
        //        {
        //            string c_estand = Convert.ToString(dat[0].ToString().Substring(2, 16)); // cuenta estandarizada a amortizar
        //            //decimal imp_mens = Convert.ToDecimal(dat2[1][1]);
        //            decimal imp_mens = Convert.ToDecimal(dat[4]);
        //            decimal imp_rec = Convert.ToDecimal(dat[3]);

        //            salida = ws.AmortizarDeuda(t.NumeroTarjeta, t.IdServicio, moneda, aux, FechaReal, imp_mens, imp_rec, c_estand);
        //            //salida = ws.AmortizarDeuda(t.NumeroTarjeta, t.IdServicio, moneda, aux, FechaReal,dat2[]);

        //        }
        //        else
        //        {
        //            //Raul: kitar esto despues/ Para ver como vienen los parametros de entrada:
        //            //TextWriter tw5 = new StreamWriter("C:\\SalvasErroresWS\\ParametrosPagarDesdeTelebanca.txt");
        //            //tw5.WriteLine("Juego de Datos que se le pasa al webservice:");
        //            //tw5.WriteLine("-------------------------------------------------------");
        //            //tw5.WriteLine("Tarjeta: " + t.NumeroTarjeta);
        //            //tw5.WriteLine("Servicio: " + t.IdServicio);
        //            //tw5.WriteLine("Divisa: " + moneda.ToString());
        //            //tw5.WriteLine("Datos[0]: " + dat2[0][1].ToString());
        //            //tw5.WriteLine("Datos[1]: " + dat2[1][1].ToString());
        //            //tw5.WriteLine("Datos[2]: " + dat2[2][1].ToString());
        //            //tw5.WriteLine("Consecutivo: " + aux);
        //            //tw5.WriteLine("Fecha: " + FechaReal.ToString());
        //            //tw5.WriteLine("Hora: " + horareal.ToString());
        //            //tw5.WriteLine("FechaBT: " + t.Fecha.ToString());
        //            //tw5.WriteLine("HoraBT: " + horaBT.ToString());
        //            //tw5.Close();

        //            salida = ws.Pagar(t.NumeroTarjeta, t.IdServicio, moneda, dat2, aux, FechaReal, horareal, t.Fecha, horaBT);
        //        }
        //        if (salida == null) throw new Exception();
        //    }
        //    catch (Exception e)
        //    {
        //        ///*escribir en el log*/

        //        //string path = @"C:\Logs_Telebanca\log_error.txt";

        //        //using (TextWriter writer = File.AppendText(path))
        //        //{
        //        //    string separador = " : ";
        //        //    string metodo_error = "EnviarTransaccion \n";
        //        //    string nombre_proyecto = "(DataHandler2): ";
        //        //    string date = DateTime.Now.ToString() + " \n";
        //        //    string separa = "-------------------------------------------------------";
        //        //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
        //        //}

        //        new DataSet1TableAdapters.TLB_TransaccionTableAdapter().DeleteTransaccion(t_row.Id_Transaccion);
        //        throw new Exception("Los datos de pagos enviados para contabilizar la operación no se han procesado por el SABIC");
        //    }
        //    if (salida[1] == "0")
        //    {
        //        t_row.Traza = salida[0];
        //    }
        //    else
        //        t_row.Traza = "E" + salida[1];

        //    DataSet1.TLB_DatosTransaccionDataTable dt_dt = new DataSet1.TLB_DatosTransaccionDataTable();
        //    try
        //    {

        //        if (t.IdServicio == "09" || t.IdServicio == "59")
        //        {
        //            string[] datos_aux = t.Datos;

        //            for (int i = 0; i < datos_aux.Length - 2; i++)
        //            {
        //                DataSet1.TLB_DatosTransaccionRow TempRow = dt_dt.NewTLB_DatosTransaccionRow();
        //                TempRow.Id_Transaccion = t_row.Id_Transaccion;
        //                TempRow.ID_DATOS = Convert.ToInt16(datos_aux[i].Substring(0, 2));
        //                TempRow.Valor = datos_aux[i].Substring(2, datos_aux[i].Length - 2);
        //                dt_dt.AddTLB_DatosTransaccionRow(TempRow);
        //            }
        //        }
        //        else
        //        {
        //            foreach (string i in t.Datos)
        //            {
        //                DataSet1.TLB_DatosTransaccionRow TempRow = dt_dt.NewTLB_DatosTransaccionRow();
        //                TempRow.Id_Transaccion = t_row.Id_Transaccion;
        //                TempRow.ID_DATOS = Convert.ToInt16(i.Substring(0, 2));
        //                TempRow.Valor = i.Substring(2, i.Length - 2);
        //                dt_dt.AddTLB_DatosTransaccionRow(TempRow);
        //            }
        //        }

        //        //foreach (string i in t.Datos)
        //        //{
        //        //    DataSet1.TLB_DatosTransaccionRow TempRow = dt_dt.NewTLB_DatosTransaccionRow();
        //        //    TempRow.Id_Transaccion = t_row.Id_Transaccion;
        //        //    TempRow.ID_DATOS = Convert.ToInt16(i.Substring(0, 2));                    
        //        //    TempRow.Valor = i.Substring(2, i.Length - 2);
        //        //    dt_dt.AddTLB_DatosTransaccionRow(TempRow);
        //        //}
        //        new DataSet1TableAdapters.TLB_DatosTransaccionTableAdapter().Update(dt_dt);
        //        new DataSet1TableAdapters.TLB_TransaccionTableAdapter().UpdateTraza(t_row.Traza, t_row.Id_Transaccion);
        //        //Modificacion T:1 y Y:2 Multas, para guardar en tabla en espera de confirmacion
        //        if (t_row.Traza.Substring(0, 1) != "E")
        //        {
        //            string CI = t.Datos[0].Substring(2);
        //            string Monto = t.Datos[1].Substring(2);
        //            string Inf = t.Datos[2].Substring(2);
        //            //if (Inf.Contains("T:2")) --- se comento porque ya no se necesitan confirmar las multas T:2
        //            //{
        //            //    this.InsertarMultaParaConfirmar(IdTransaccion, CI, Monto, Inf, FechaReal);
        //            //}
        //        }
        //        //******************************************************************************
        //    }
        //    catch (Exception)
        //    {
        //        AsegurarXML();

        //        DataSet1.TLB_TransaccionDataTable tt = new DataSet1.TLB_TransaccionDataTable();
        //        DataSet1.TLB_DatosTransaccionDataTable tdt = new DataSet1.TLB_DatosTransaccionDataTable();

        //        tt.ReadXml(@"C:\TransacionesNoGuardadasEnDB.xml");
        //        tdt.ReadXml(@"C:\DatosTransacionesNoGuardadasEnDB.xml");

        //        DataSet1.TLB_TransaccionRow tr = tt.NewTLB_TransaccionRow();
        //        tr.Id_Transaccion = t_row.Id_Transaccion;
        //        tr.Id_Usuario = t_row.Id_Usuario;
        //        tr.Importe = t_row.Importe;
        //        tr.Traza = t_row.Traza;
        //        tr.Asociado = t_row.Asociado;
        //        tr.FechaHora = t_row.FechaHora;
        //        tr.FechaHoraContable = t_row.FechaHoraContable;
        //        tr.Id_NoTarjeta = t_row.Id_NoTarjeta;
        //        tr.ID_SERV = t_row.ID_SERV;
        //        tt.AddTLB_TransaccionRow(tr);

        //        foreach (DataSet1.TLB_DatosTransaccionRow dtr in dt_dt.Rows)
        //        {
        //            DataSet1.TLB_DatosTransaccionRow auxD = tdt.NewTLB_DatosTransaccionRow();
        //            auxD.Id_Transaccion = dtr.Id_Transaccion;
        //            auxD.ID_DATOS = dtr.ID_DATOS;
        //            auxD.Valor = dtr.Valor;
        //            tdt.AddTLB_DatosTransaccionRow(auxD);
        //        }

        //        tt.WriteXml(@"C:\TransacionesNoGuardadasEnDB.xml");
        //        tdt.WriteXml(@"C:\DatosTransacionesNoGuardadasEnDB.xml");

        //    }
        //    if (t_row.Traza.Length < 5)
        //        throw new Exception(salida[2]);
        //    return t_row.Traza;


        //}
        #endregion
        public string EnviarTransaccion(Transaccion t, int moneda)
        {
            WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
            BancoPersistente bnk = new BancoPersistente();
            string aux = "000";
            string[] salida = new string[0];//new string[] { "1234567890000", "00" }; 

            DateTime FechaReal = t.Fecha;//Cambio fecha
            DataSet1.TLB_TransaccionDataTable t_dt = new DataSet1.TLB_TransaccionDataTable();
            DataSet1.TLB_TransaccionRow t_row = t_dt.NewTLB_TransaccionRow();
            t_row.Id_Usuario = t.IdUsuario;
            t_row.Id_NoTarjeta = t.NumeroTarjeta;
            //t_row.FechaHora = t.Fecha;
            t_row.FechaHora = new DateTime(t.Fecha.Year, t.Fecha.Month, t.Fecha.Day, t.Fecha.Hour, t.Fecha.Minute, t.Fecha.Second);
            //t_row.FechaHoraContable = FechaContableUltima().Add(new TimeSpan(t.Fecha.Hour, t.Fecha.Minute, t.Fecha.Second));
            DateTime contult = FechaContableUltima();
            t_row.FechaHoraContable = new DateTime(contult.Year, contult.Month, contult.Day, t.Fecha.Hour, t.Fecha.Minute, t.Fecha.Second);
            string IdServicio = "";
            if (Convert.ToInt32(t.IdServicio) > 50)
            {
                IdServicio = "0" + Convert.ToString(Convert.ToInt32(t.IdServicio) - 50);
                if (IdServicio.Length > 2) 
                {
                    IdServicio = IdServicio.Substring(1,2);                    
                }
                t_row.ID_SERV = IdServicio;
            }
            else
            {
                t_row.ID_SERV = t.IdServicio;
            }

            t_row.Asociado = " ";
            if (moneda == 1) // cuando es CUC
            {
                if (Convert.ToInt32(t.IdServicio) > 50)
                {
                    t_row.Importe = 12;
                }
                else
                {
                    t_row.Importe = 2;
                }
                
            }
            if (moneda == 0) // cuando es CUP
            {
                if (Convert.ToInt32(t.IdServicio) > 50)
                {
                    t_row.Importe = 21;
                }
                else
                {
                    t_row.Importe = 1;
                }
            }
            if (moneda == 2) // Raul: cuando es USD. Ver si es necesario dejar esto
            {
                if (Convert.ToInt32(t.IdServicio) > 50)
                {
                    t_row.Importe = 12;
                }
                else
                {
                    t_row.Importe = 2;
                }
            }
            t_row.Traza = " ";

            t_dt.AddTLB_TransaccionRow(t_row);
            try
            {
                bnk = GetBancoDadoID(t.NumeroTarjeta.Substring(0, 2));
                new DataSet1TableAdapters.TLB_TransaccionTableAdapter().Update(t_dt);
                t.Fecha = t_row.FechaHoraContable;
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
            ws.Url = bnk.WebServices;

            aux += t_row.Id_Transaccion.ToString();
            //***********************************
            string IdTransaccion = t_row.Id_Transaccion.ToString();
            //***********************************
            aux = aux.ToString().Substring(aux.ToString().Length - 4);
            //***Crear arreglo bidimensional
            string[] dat = t.Datos;
            string[][] dat2 = new string[dat.Length][];
            for (int i = 0; i < dat.Length; i++)
            {
                dat2[i] = new string[2];
            }

            for (int i = 0; i < dat.Length; i++)
            {
                dat2[i][0] = dat[i].Substring(0, 2);
                dat2[i][1] = dat[i].Substring(2);
            }
            //****           
            try
            {
                int horareal = FechaReal.Hour;
                int horaBT = t.Fecha.Hour;
                if (t.IdServicio == "07" || t.IdServicio == "57")
                {
                    salida = ws.Transferencias(t.NumeroTarjeta, t.IdServicio, moneda, dat2, aux, FechaReal, horareal, t.Fecha, horaBT);
                }
                else if (t.IdServicio == "09" || t.IdServicio == "59")
                {
                    string c_estand = Convert.ToString(dat[0].ToString().Substring(2, 16)); // cuenta estandarizada a amortizar
                    //decimal imp_mens = Convert.ToDecimal(dat2[1][1]);
                    decimal imp_mens = Convert.ToDecimal(dat[4]);
                    decimal imp_rec = Convert.ToDecimal(dat[3]);

                    salida = ws.AmortizarDeuda(t.NumeroTarjeta, t.IdServicio, moneda, aux, FechaReal, imp_mens, imp_rec, c_estand);
                    //salida = ws.AmortizarDeuda(t.NumeroTarjeta, t.IdServicio, moneda, aux, FechaReal,dat2[]);
     
                }
                else
                {
                    //Raul: kitar esto despues/ Para ver como vienen los parametros de entrada:
                    //TextWriter tw5 = new StreamWriter("C:\\SalvasErroresWS\\ParametrosPagarDesdeTelebanca.txt");
                    //tw5.WriteLine("Juego de Datos que se le pasa al webservice:");
                    //tw5.WriteLine("-------------------------------------------------------");
                    //tw5.WriteLine("Tarjeta: " + t.NumeroTarjeta);
                    //tw5.WriteLine("Servicio: " + t.IdServicio);
                    //tw5.WriteLine("Divisa: " + moneda.ToString());
                    //tw5.WriteLine("Datos[0]: " + dat2[0][1].ToString());
                    //tw5.WriteLine("Datos[1]: " + dat2[1][1].ToString());
                    //tw5.WriteLine("Datos[2]: " + dat2[2][1].ToString());
                    //tw5.WriteLine("Consecutivo: " + aux);
                    //tw5.WriteLine("Fecha: " + FechaReal.ToString());
                    //tw5.WriteLine("Hora: " + horareal.ToString());
                    //tw5.WriteLine("FechaBT: " + t.Fecha.ToString());
                    //tw5.WriteLine("HoraBT: " + horaBT.ToString());
                    //tw5.Close();

                    salida = ws.Pagar(t.NumeroTarjeta, t.IdServicio, moneda, dat2, aux, FechaReal, horareal, t.Fecha, horaBT);
                }
                if (salida == null) throw new Exception();
            }
            catch (Exception e)
            {
                ///*escribir en el log*/

                //string path = @"C:\Logs_Telebanca\log_error.txt";

                //using (TextWriter writer = File.AppendText(path))
                //{
                //    string separador = " : ";
                //    string metodo_error = "EnviarTransaccion \n";
                //    string nombre_proyecto = "(DataHandler2): ";
                //    string date = DateTime.Now.ToString() + " \n";
                //    string separa = "-------------------------------------------------------";
                //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
                //}
                string nombre_ser = "";
                if (t.IdServicio == "01" || t.IdServicio == "51")
                    nombre_ser = "Etecsa";
                if (t.IdServicio == "02" || t.IdServicio == "52")
                    nombre_ser = "Electricidad";
                if (t.IdServicio == "03" || t.IdServicio == "53")
                    nombre_ser = "Onat";
                if (t.IdServicio == "04" || t.IdServicio == "54")
                    nombre_ser = "Multa";
                if (t.IdServicio == "05" || t.IdServicio == "55")
                    nombre_ser = "Agua";
                if (t.IdServicio == "07" || t.IdServicio == "57")
                    nombre_ser = "Transferencia";
                if (t.IdServicio == "09" || t.IdServicio == "59")
                    nombre_ser = "Amortizacion";
                if (t.IdServicio == "11" || t.IdServicio == "61")
                    nombre_ser = "Gas";

                new DataSet1TableAdapters.TLB_TransaccionTableAdapter().DeleteTransaccion(t_row.Id_Transaccion);
                
                string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
                                
                string sSQL = "INSERT dbo.TLB_BITACORA VALUES("+t.NumeroTarjeta+",'','','','','','Pago_Servicio',GETDATE(),'Intenta pagar el servicio: "+ nombre_ser +" con el id_asociado: "+dat2[0][1].ToString().Trim()+ " con el importe: "+dat2[1][1].ToString().Trim()+ ". Operador que atiende: "+t.IdUsuario.Trim()+"',ERROR PAGO SERVICIO: "+e.Message.Trim()+"')";
                SqlConnection myconexion = new SqlConnection(sCadenaConexion);
                SqlCommand mycomand = new SqlCommand(sSQL, myconexion);

                mycomand.ExecuteNonQuery();

                throw new Exception("Los datos de pagos enviados para contabilizar la operación no se han procesado por el SABIC");
            }
            if (salida[1] == "0")
            {
                t_row.Traza = salida[0];
            }
            else
                t_row.Traza = "E" + salida[1];

            DataSet1.TLB_DatosTransaccionDataTable dt_dt = new DataSet1.TLB_DatosTransaccionDataTable();
            try
            {

                if (t.IdServicio == "09" || t.IdServicio == "59")
                {
                    string[] datos_aux = t.Datos;

                    for (int i = 0; i < datos_aux.Length - 2; i++)
                    {
                        DataSet1.TLB_DatosTransaccionRow TempRow = dt_dt.NewTLB_DatosTransaccionRow();
                        TempRow.Id_Transaccion = t_row.Id_Transaccion;
                        TempRow.ID_DATOS = Convert.ToInt16(datos_aux[i].Substring(0, 2));
                        TempRow.Valor = datos_aux[i].Substring(2, datos_aux[i].Length - 2);
                        dt_dt.AddTLB_DatosTransaccionRow(TempRow);
                    }
                }
                else
                {
                    foreach (string i in t.Datos)
                    {
                        DataSet1.TLB_DatosTransaccionRow TempRow = dt_dt.NewTLB_DatosTransaccionRow();
                        TempRow.Id_Transaccion = t_row.Id_Transaccion;
                        TempRow.ID_DATOS = Convert.ToInt16(i.Substring(0, 2));
                        TempRow.Valor = i.Substring(2, i.Length - 2);
                        dt_dt.AddTLB_DatosTransaccionRow(TempRow);
                    }
                }

                //foreach (string i in t.Datos)
                //{
                //    DataSet1.TLB_DatosTransaccionRow TempRow = dt_dt.NewTLB_DatosTransaccionRow();
                //    TempRow.Id_Transaccion = t_row.Id_Transaccion;
                //    TempRow.ID_DATOS = Convert.ToInt16(i.Substring(0, 2));                    
                //    TempRow.Valor = i.Substring(2, i.Length - 2);
                //    dt_dt.AddTLB_DatosTransaccionRow(TempRow);
                //}
                new DataSet1TableAdapters.TLB_DatosTransaccionTableAdapter().Update(dt_dt);
                new DataSet1TableAdapters.TLB_TransaccionTableAdapter().UpdateTraza(t_row.Traza, t_row.Id_Transaccion);
                //Modificacion T:1 y Y:2 Multas, para guardar en tabla en espera de confirmacion
                if (t_row.Traza.Substring(0, 1) != "E")
                {
                    string CI = t.Datos[0].Substring(2);
                    string Monto = t.Datos[1].Substring(2);
                    string Inf = t.Datos[2].Substring(2);
                    //if (Inf.Contains("T:2")) --- se comento porque ya no se necesitan confirmar las multas T:2
                    //{
                    //    this.InsertarMultaParaConfirmar(IdTransaccion, CI, Monto, Inf, FechaReal);
                    //}
                }
                //******************************************************************************
            }
            catch (Exception)
            {
                AsegurarXML();

                DataSet1.TLB_TransaccionDataTable tt = new DataSet1.TLB_TransaccionDataTable();
                DataSet1.TLB_DatosTransaccionDataTable tdt = new DataSet1.TLB_DatosTransaccionDataTable();

                tt.ReadXml(@"C:\TransacionesNoGuardadasEnDB.xml");
                tdt.ReadXml(@"C:\DatosTransacionesNoGuardadasEnDB.xml");

                DataSet1.TLB_TransaccionRow tr = tt.NewTLB_TransaccionRow();
                tr.Id_Transaccion = t_row.Id_Transaccion;
                tr.Id_Usuario = t_row.Id_Usuario;
                tr.Importe = t_row.Importe;
                tr.Traza = t_row.Traza;
                tr.Asociado = t_row.Asociado;
                tr.FechaHora = t_row.FechaHora;
                tr.FechaHoraContable = t_row.FechaHoraContable;
                tr.Id_NoTarjeta = t_row.Id_NoTarjeta;
                tr.ID_SERV = t_row.ID_SERV;
                tt.AddTLB_TransaccionRow(tr);

                foreach (DataSet1.TLB_DatosTransaccionRow dtr in dt_dt.Rows)
                {
                    DataSet1.TLB_DatosTransaccionRow auxD = tdt.NewTLB_DatosTransaccionRow();
                    auxD.Id_Transaccion = dtr.Id_Transaccion;
                    auxD.ID_DATOS = dtr.ID_DATOS;
                    auxD.Valor = dtr.Valor;
                    tdt.AddTLB_DatosTransaccionRow(auxD);
                }

                tt.WriteXml(@"C:\TransacionesNoGuardadasEnDB.xml");
                tdt.WriteXml(@"C:\DatosTransacionesNoGuardadasEnDB.xml");

            }
            if (t_row.Traza.Length < 5)
            {
                string nombre_ser = "";
                if (t.IdServicio == "01" || t.IdServicio == "51")
                    nombre_ser = "Etecsa";
                if (t.IdServicio == "02" || t.IdServicio == "52")
                    nombre_ser = "Electricidad";
                if (t.IdServicio == "03" || t.IdServicio == "53")
                    nombre_ser = "Onat";
                if (t.IdServicio == "04" || t.IdServicio == "54")
                    nombre_ser = "Multa";
                if (t.IdServicio == "05" || t.IdServicio == "55")
                    nombre_ser = "Agua";
                if (t.IdServicio == "07" || t.IdServicio == "57")
                    nombre_ser = "Transferencia";
                if (t.IdServicio == "09" || t.IdServicio == "59")
                    nombre_ser = "Amortizacion";
                if (t.IdServicio == "11" || t.IdServicio == "61")
                    nombre_ser = "Gas";

                string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
                string sSQL = "";

                if (t.IdServicio == "07" || t.IdServicio == "57")
                {
                    sSQL = "INSERT dbo.TLB_BITACORA VALUES(" + t.NumeroTarjeta + ",'','','','','','Pago_Transferencia',GETDATE(),'Intenta pagar el servicio: " + nombre_ser + " hacia la tarjeta: " + dat2[0][1].ToString() + " con el importe: " + dat2[1][1].ToString() + ". Operador que atiende: " + t.IdUsuario.Trim() + "','ERROR PAGO SERVICIO: " + salida[2].Trim() + "')";
                }
                else
                {
                    sSQL = "INSERT dbo.TLB_BITACORA VALUES(" + t.NumeroTarjeta + ",'','','','','','Pago_Servicio',GETDATE(),'Intenta pagar el servicio: " + nombre_ser + " con el id_asociado: " + dat2[0][1].ToString() + " con el importe: " + dat2[1][1].ToString() + ". Operador que atiende: " + t.IdUsuario.Trim() + "','ERROR PAGO SERVICIO: " + salida[2].Trim() + "')";
                }

                SqlConnection myconexion = new SqlConnection(sCadenaConexion);

                myconexion.Open();

                SqlCommand mycomand = new SqlCommand(sSQL, myconexion);

                mycomand.ExecuteNonQuery();

                myconexion.Close();

                throw new Exception(salida[2]);
            }
            return t_row.Traza;


        }

        //Modificacion para tratamiento de pago de multas T:1 o T:2---17/04/08***********************
        public string[] ObtenerMontoMulta(string art, string inciso, string peligrosidad)
        {
            string[] Datos = new string[2];
            string[] DatosFinal = new string[2];
            string mensaje00 = "False";
            string mensaje01 = "No existe esa Combinación de Artículo-Inciso";
            string mensaje02 = "La Combinación de Artículo-Inciso no corresponde con la Peligrosidad insertada";

            try
            {
                Datos = this.ObtenerMontoMulta(art, inciso);
                if (Datos[0] != "")
                {
                    if (Datos[0].Trim() == peligrosidad.Trim())
                    {
                        DatosFinal[0] = Datos[1].Trim(); //Cuantia                   
                    }
                    else
                    {
                        DatosFinal[0] = mensaje00;
                        DatosFinal[1] = mensaje02;
                    }
                }
                else
                { 
                    DatosFinal[0] = mensaje00;
                    DatosFinal[1] = mensaje01;
                }
            }
            catch (Exception Exc)
            {
                throw new Exception(Exc.Message);
            }
            return DatosFinal;

        }
        public string[] ObtenerMontoMulta(string art, string inciso)
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            string sSQL = "SELECT * from TLB_Multas WHERE (articulo='" + art + "') AND (inciso = '"+inciso+"')";
            SqlConnection myconexion = new SqlConnection(sCadenaConexion);
            SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
            string[] Datos = new string[2];
            string peligrosidad1 = "";
            string cuantia = "";
            try
            {
                myconexion.Open();
                SqlDataReader myreader = mycomand.ExecuteReader();

                if (myreader.Read())
                {
                    peligrosidad1 = myreader.GetString(2);
                    cuantia = myreader.GetString(3);
                }
                myreader.Close();
            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {

                myconexion.Close();
            }
            Datos[0] = peligrosidad1;
            Datos[1] = cuantia;
            return Datos;    
        }
        public void InsertarMultaParaConfirmar(string id, string CI, string Importe, string Informativo,DateTime Fecha)
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            string sSQL = "insert Into TLB_MultasPendientes (Id_Transaccion, CI, Importe, Informativo, FechaPago)";
            sSQL = sSQL + " values ('" + id + "','" + CI + "','" + Importe + "','" + Informativo + "','"+Fecha+"')";
            SqlConnection myconexion = new SqlConnection(sCadenaConexion);

            try
            {
                SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
                myconexion.Open();

                mycomand.ExecuteNonQuery();



            }

            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {
                myconexion.Close();
            }
        }
        //*******************************************************************************************

        //*******************************************************************************************
        private void AsegurarXML()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("C:\\");
            System.IO.FileInfo[] fi = di.GetFiles("TransacionesNoGuardadasEnDB.xml");
            if (fi.Length == 0)
            {
                System.IO.FileStream fs = new System.IO.FileStream("C:\\TransacionesNoGuardadasEnDB.xml", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
                System.IO.StreamWriter aa = new System.IO.StreamWriter(fs);
                aa.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                aa.WriteLine("<DocumentElement />");
                aa.Close();
                fs.Close();
            }
            di = new System.IO.DirectoryInfo("C:\\");
            fi = di.GetFiles("DatosTransacionesNoGuardadasEnDB.xml");
            if (fi.Length == 0)
            {
                System.IO.FileStream fs = new System.IO.FileStream("C:\\DatosTransacionesNoGuardadasEnDB.xml", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
                System.IO.StreamWriter aa = new System.IO.StreamWriter(fs);
                aa.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                aa.WriteLine("<DocumentElement />");
                aa.Close();
                fs.Close();
            }
        }
        /*******************************************************************************************************/
        public bool ActualizarTransacionesDeXMLParaDB()
        {
            try
            {
                AsegurarXML();
                DataSet1.TLB_TransaccionDataTable DSET = new DataSet1.TLB_TransaccionDataTable();
                DSET.ReadXml("C:/TransacionesNoGuardadasEnDB.xml");
                if (DSET.Rows.Count > 0)
                {
                    foreach (DataSet1.TLB_TransaccionRow i in DSET.Rows)
                    {
                        new DataSet1TableAdapters.TLB_TransaccionTableAdapter().UpdateTraza(i.Traza, i.Id_Transaccion);
                    }
                    DSET.Clear();
                    DSET.WriteXml("C:/TransacionesNoGuardadasEnDB.xml");
                }
                DataSet1.TLB_DatosTransaccionDataTable DT = new DataSet1.TLB_DatosTransaccionDataTable();
                DT.ReadXml("C:/DatosTransacionesNoGuardadasEnDB.xml");
                if (DT.Rows.Count > 0)
                {
                    foreach (DataSet1.TLB_DatosTransaccionRow i in DT.Rows)
                    {
                        new DataSet1TableAdapters.TLB_DatosTransaccionTableAdapter().Update(i);
                    }
                    DT.Clear();
                    DT.WriteXml("C:/DatosTransacionesNoGuardadasEnDB.xml");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*******************************************************************************************************/
        
         public string FiltroBuscarPagoComplejo(string idServicio, string idCliente)
         {
             
             string retorno = "0";

             try
             {

                 DataSet1.TLB_PagoComplejoDataTable pcDT = new DataSet1TableAdapters.TLB_PagoComplejoTableAdapter().Filtro_Factura(idServicio, idCliente, ref retorno);

                 return retorno;
               
             }
             catch (Exception)
             {
                 throw;
             }
         }
        
        public List<PagoComplejo> BuscarPagoComplejo(string idServicio, string idCliente)
        {
            try
            {
                
                List<PagoComplejo> list = new List<PagoComplejo>();
                DataSet1.TLB_PagoComplejoDataTable pcDT = new DataSet1TableAdapters.TLB_PagoComplejoTableAdapter().Datos_Factura(idServicio, idCliente);
                    foreach (DataSet1.TLB_PagoComplejoRow pcRow in pcDT.Rows)
                {
                    PagoComplejo pago = new PagoComplejo();
                    pago.Descriptivo = pcRow.descriptivo;
                    pago.Identificador = pcRow.Id_Asociado;
                    pago.Importe = Convert.ToSingle(pcRow.Importe);
                    pago.Informativo = pcRow.Informativo;
                    pago.Nombre = pcRow.Nombre;
                    pago.Tipo = pcRow.ID_SERV.ToString();
                    pago.ID = pcRow.ID;
                    list.Add(pago);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*******************************************************************************************************
        public void EliminarPagoComplejo(string cod_serv, int id)
        {
            try
            {
                
                new DataSet1TableAdapters.TLB_PagoComplejoTableAdapter().sp_Eliminar_Datos_Factura(cod_serv, Convert.ToString(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*******************************************************************************************************
        public bool EsServConAsociados(string codigoServicio)
        {
            try
            {
                DataSet1.TLB_C_SERVBTDataTable st = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetServicioPorID(codigoServicio);
                DataSet1.TLB_C_SERVBTRow sr = (DataSet1.TLB_C_SERVBTRow)st.Rows[0];
                return sr.Asociados;
            }
            catch (Exception)
            {
                throw;
            }
            //simples
            /*   if (codigoServicio == "13")
               {
                   return true;
               }
               if (codigoServicio == "16")
               {
                   return true;
               }
           //complejos
               if (codigoServicio == "10")
               {
                   return false;
               }
               return false;*/
        }
        //*******************************************************************************************************
        public List<string> ObtenerServiciosPorTipo(string tipo)
        {
            try
            {
                List<string> list = new List<string>();
                DataSet1.TLB_C_SERVBTDataTable sdt = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().ObtenerServicioPorTipo(tipo);
                foreach (DataSet1.TLB_C_SERVBTRow i in sdt)
                {
                    list.Add(i.ID_SERV);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //*******************************************************************************************************        
        public bool EsServicioActivo(string codServ)
        {
            try
            {
                DataSet1.TLB_C_SERVBTDataTable serv = new DataSet1TableAdapters.TLB_C_SERVBTTableAdapter().GetServicioPorID(codServ);
                DataSet1.TLB_C_SERVBTRow servR = (DataSet1.TLB_C_SERVBTRow)serv.Rows[0];
                if (servR.SERV_EST.Equals("AC"))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        //*******************************************************************************************************        
        //CU_CONCILIACIONES AUTOMATICAS**************************************************************************

        //*******************************************************************************************************
        public bool EnviarReclamacionesenDia(DateTime f, string id)
        {
            DataSet1.TLB_ConcReclamacionesDataTable rec = new DataSet1.TLB_ConcReclamacionesDataTable();
            DataSet dset = new DataSet();
            BancoPersistente bnk = new BancoPersistente();
            try
            {
                string idBanco = id + "%";
                DateTime fini = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
                DateTime ffin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59);

                rec = new DataSet1TableAdapters.TLB_ConcReclamacionesTableAdapter().ReclamacionesDeBancoEnDia(fini, ffin, idBanco);
                bnk = GetBancoDadoID(id);
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message) as SqlException;
            }

            dset.Merge(rec);

            WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
            ws.Url = bnk.WebServices;
            try
            {
                string[] kjn = ws.InformarReclamaciones(dset);
                //hay que ver que hacer con el arreglo devuelto por el banco!!!!
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con el Web Service: " + bnk.WebServices);
            }
            if (rec.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }
        //*******************************************************************************************************
        public bool EnviarTransaccionesenDia(DateTime f, string id)
        {
            DataSet1.TLB_ConcTransDataTable CTDT = new DataSet1.TLB_ConcTransDataTable();
            DataSet1.TLB_ConcDatTransDataTable CDTDT = new DataSet1.TLB_ConcDatTransDataTable();
            DataSet dset = new DataSet();
            try
            {
                string idBanco = id + "%";
                DateTime fini = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
                DateTime ffin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59, 59);

                CTDT = new DataSet1TableAdapters.TLB_ConcTransTableAdapter().TransaccionesEnFechaT(fini, ffin, idBanco);
                CDTDT = new DataSet1TableAdapters.TLB_ConcDatTransTableAdapter().DatosDeTransaccionesEnFecha(fini, ffin, idBanco);

                dset.Merge(CTDT);
                dset.Merge(CDTDT);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
            BancoPersistente bnk = new BancoPersistente();
            try
            {
                bnk = GetBancoDadoID(id);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexión con la base de datos");
            }
            WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
            ws.Url = bnk.WebServices;
            int cantTotal =0;
            try
            {
                //Incluir Llamada a Metodo para transformar FechaHora y FechaHoraContable de DateTime a string
                DataSet dsetFinal = TranformarFechaHorayFechaHoraContable(dset);
                //***********************************************************************************
                //dset.WriteXml("C:\\nuevo.xml");
                //dsetFinal.WriteXml("C:\\nuevofinal.xml");
                string dia = f.ToString("dd");
                string mes = f.ToString("MM");
                // string mes
                string[] kjn = ws.ConfirmarTransacciones(dsetFinal, dia, mes);
                cantTotal = dsetFinal.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                ///*escribir en el log*/

                //string path = @"C:\Logs_Telebanca\log_error.txt";

                //using (TextWriter writer = File.AppendText(path))
                //{
                //    string separador = " : ";
                //    string metodo_error = "ConfirmarTransacciones \n";
                //    string nombre_proyecto = "(DataHanlder2): ";
                //    string date = DateTime.Now.ToString() + " \n";
                //    string separa = "-------------------------------------------------------";
                //    writer.WriteLine(date+metodo_error + separador+ nombre_proyecto+separador+ex.Message+" Cantidad filas: "+cantTotal.ToString()+separa);
                //}

                throw new Exception("Error de conexión con el Web Services del Banco: " + bnk.Nombre+ ". Error: "+ex.Message);
            }
            //hay que ver que hacer con el arreglo devuelto por el banco!!!!
            if (CDTDT.Rows.Count > 0 && CDTDT.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                string idbanco = this.N_CLlamadas();
                return false;
                string mes = Convert.ToString(DateTime.Today.Month);
                string dia = Convert.ToString(DateTime.Today);
                string asunto = "!Alerta, Fallo en el Sistema!";
                string message = "\nSaludos,\n" +
                "El envío automático del Fichero N" + idbanco + mes + dia + " ha fallado, ejecute el proceso manual (Conciliación Auxiliar)" +
                "\n\n================================================================================================\nEste correo electrónico forma parte del proceso automático de entrega de mensajes y comentarios, por favor no responder.\n================================================================================================";
                this.SendErrorMail(asunto, message);

            }
        }
        //Enviar alertas por el MAIL
        public void SendErrorMail(string asunto, string mensaje)
        {
            string idbanco = this.N_CLlamadas();
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
            if (idbanco == "95")
            {
            correo.From = new System.Net.Mail.MailAddress("noresponder-bancatelefonica@banmet.cu");
            }
            if (idbanco == "06")
            {
                correo.From = new System.Net.Mail.MailAddress("noresponder-bancatelefonica@dmpe.bandec.cu");
            }
            if (idbanco == "0212")
            {
                correo.From = new System.Net.Mail.MailAddress("noresponder-bancatelefonica@bpa.cu");
            }
            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myconection = new SqlConnection(stringConection);

            SqlCommand mycommand = new SqlCommand("sp_lista_correos1", myconection);
            mycommand.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(mycommand);
            DataSet ds = new DataSet();

            try
            {
                adapter.Fill(ds, "Correos");
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myconection.Close();
            }

            DataTable list = ds.Tables[0];

            //lista de la base de datos
            for (int i = 0; i < list.Rows.Count; i++)
            {
                correo.To.Add((string)list.Rows[i][0]);
            }
            correo.Subject = asunto;
            correo.Body = mensaje;
            correo.IsBodyHtml = false;
            correo.Priority = System.Net.Mail.MailPriority.High;
            //
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            //
            //---------------------------------------------
            // Estos datos debes rellenarlos correctamente
            //---------------------------------------------

            
            string idban = this.N_CLlamadas();

            if (idban == "95")
            {
                smtp.Host = "172.31";
                smtp.Credentials = new System.Net.NetworkCredential("noresponder-bancatelefonica@banmet.cu", "");
                smtp.EnableSsl = false;
            }
            if (idban == "0212")
            {
                smtp.Host = "IP";
                smtp.Credentials = new System.Net.NetworkCredential("@", "pass");
                smtp.EnableSsl = false;
            }
            if (idban == "06")
            {
                smtp.Host = "172.31.26.3";
                smtp.Credentials = new System.Net.NetworkCredential("noresponder-bancatelefonica@dmpe.bandec.cu", "");
                smtp.EnableSsl = false;
            }
            try
            {
                smtp.Send(correo);

            }
            catch (Exception ex)
            {
                string error = "ERROR: " + ex.Message;
            }
        }
        //***************************************************************************************************
        //CU_ACTUALIZAR SERVICIOS Y DATOS 
        //YULIER
        public List<string> ActualizarServicioDat(List<string> IDBancos)
        {
            List<string> dev = new List<string>();
            DataSet DSET = new DataSet();

            DataSet1.TLB_ActClasif_C_SERVDataTable SERV = new DataSet1TableAdapters.TLB_ActClasif_C_SERVTableAdapter().GetData();
            DataSet1.TLB_C_DATSERDataTable DAT_SER = new DataSet1TableAdapters.TLB_C_DATSERTableAdapter().GetData();
            DataSet1.TLB_C_RELSDDataTable REL_SERV_DAT = new DataSet1TableAdapters.TLB_C_RELSDTableAdapter().GetData();

            DSET.Merge(SERV);
            DSET.Merge(DAT_SER);
            DSET.Merge(REL_SERV_DAT);

            List<BancoPersistente> LB = ObtenerListaBanco();

            foreach (BancoPersistente i in LB)
            {
                if (!IDBancos.Contains(i.NumBanco))
                {
                    LB.Remove(i);
                }
            }
            XmlDataDocument dc = new XmlDataDocument(DSET);
            DSET = dc.DataSet;
            foreach (BancoPersistente i in LB)
            {
                WSBanco.Service ws = new DataAccessLayer.WSBanco.Service();
                ws.Url = i.WebServices;
                try
                {
                    //if (!ws.ActualizarClasificadores())
                   // {
                        dev.Add(i.Nombre);
                    //}
                }
                catch (Exception)
                {
                    dev.Add(i.Nombre);
                }
            }
            return dev;
        }
        //reporte tarjetas//
        public DataSet Tarjetas(int type)
        {
            
            WSBanco.Service ws = new WSBanco.Service();
            BancoPersistente bnk;
            try
            {
                string idbanco = this.N_CLlamadas();
                bnk = GetBancoDadoID(idbanco);
               
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
            ws.Url = bnk.WebServices;
            DataSet Tarj = ws.ReporteTarjetas(type);
            return Tarj;
        }

        //Metodo para para transformar FechaHora y FechaHoraContable de DateTime a string
        public DataSet TranformarFechaHorayFechaHoraContable(DataSet dset)
        {
            DataColumn DTC = new DataColumn();
            DTC.ColumnName = "FechaHoraString";
            DTC.DataType = Type.GetType("System.String");
            DataColumn DTC1 = new DataColumn();
            DTC1.ColumnName = "FechaHoraContableString";
            DTC1.DataType = Type.GetType("System.String");
            dset.Tables[0].Columns.Add(DTC);
            dset.Tables[0].Columns.Add(DTC1);
            foreach (DataRow DR in dset.Tables[0].Rows)
            {
                DateTime DT = Convert.ToDateTime(DR[4], new CultureInfo("en-US"));
                //DR[6] = DT.ToString("dd/MM/yyyy hh:mm:ss tt");
                DR[7] = DT.ToString("ddMMyyyyHH:mm:sstt");
                //DR[6] = DT.ToString();
                DateTime DT1 = Convert.ToDateTime(DR[5], new CultureInfo("en-US"));
               // DR[7] = DT1.ToString("dd/MM/yyyy hh:mm:ss tt");
                DR[8] = DT.ToString("ddMMyyyyHH:mm:sstt");
                //DR[7] = DT1.ToString();
                //string aaa = DT1.ToString();
                //DateTime aaaa = Convert.ToDateTime(aaa);
            }
            return dset;
        }

        public DataSet Nombre_Titular(string numTarjeta, int tipo_cuenta, string cuenta)
        {
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
                return ws.NombreDelTitular(tipo_cuenta, cuenta);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
        }

        public DataSet Credit(string numTarjeta, string ci)
        {
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
                return ws.GetCuentasCred(ci);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
        }

        public DataSet DaCredit(string notarjeta, string serv, string ce, int meses)
        {
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
            }
            catch (Exception e)
            {
                throw new Exception("ErrorCBD" + e.Message);
            }
            try
            {
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;
                return ws.GetDatosDeuda(notarjeta, serv, ce, meses);
            }
            catch (Exception)
            {
                throw new Exception("Error de conexion con el WebService: " + bnk.WebServices);
            }
        }

        public string N_F(string ID, string cod)
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;

            string sSQL = "SELECT Nombre FROM TLB_SERV_" + cod + " WHERE Id_Asociado = '" + ID + "'";

            SqlConnection myconexion = new SqlConnection(sCadenaConexion);
            SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
            string nombre = "";
            try
            {
                myconexion.Open();
                SqlDataReader myreader = mycomand.ExecuteReader();

                if (myreader.Read())
                {
                    nombre = myreader.GetString(0);
                }

                myreader.Close();
            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {

                myconexion.Close();
            }

            return nombre;
        }

        public string N_CLlamadas()
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;

            string sSQL = "SELECT Id_Banco FROM TLB_Banco";

            SqlConnection myconexion = new SqlConnection(sCadenaConexion);
            SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
            string id = "";
            try
            {
                myconexion.Open();
                SqlDataReader myreader = mycomand.ExecuteReader();

                if (myreader.Read())
                {
                    id = myreader.GetString(0);
                }

                myreader.Close();
            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {

                myconexion.Close();
            }

            return id;
        }

        public string WSIS()
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;

            string sSQL = "SELECT WSIS FROM TLB_Banco";

            SqlConnection myconexion = new SqlConnection(sCadenaConexion);
            SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
            string ws = "";
            try
            {
                myconexion.Open();
                SqlDataReader myreader = mycomand.ExecuteReader();

                if (myreader.Read())
                {
                    ws = myreader.GetString(0);
                }

                myreader.Close();
            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {

                myconexion.Close();
            }

            return ws;
        }

        public Boolean PINWSISS(string tarjeta, int[] pinpos1, char[] pinpos2)
        {
            BancoPersistente BNK = GetBancoDadoID(tarjeta.Substring(0, 2));
            string URL = BNK.Identificationserver.ToString();

            bool b = false;

            if (tarjeta.Substring(0, 2) == "06")
            {
                ISWS.Service1Client IS = new ISWS.Service1Client(new System.ServiceModel.BasicHttpBinding(), new System.ServiceModel.EndpointAddress(URL));

                try
                {
                    b = IS.ValidaPosicPINTarjeta(tarjeta, pinpos1, pinpos2);
                }
                catch (Exception Exc)
                {
                    throw new Exception("Error de conexion con la Servicio Web del Servidor de Identidad: " + Exc.Message);
                }
            }

            return b;
           
        }

        public Boolean COORWSISS(string tarjeta, int f, int c, string v)
        {
            BancoPersistente BNK = GetBancoDadoID(tarjeta.Substring(0, 2));
            string URL = BNK.Identificationserver.ToString();

            bool coo = false;

            if (tarjeta.Substring(0, 2) == "06")
            {
                ISWS.Service1Client IS = new ISWS.Service1Client(new System.ServiceModel.BasicHttpBinding(), new System.ServiceModel.EndpointAddress(URL));

                try
                {
                    coo = IS.ValidaRespuesta(tarjeta, f, c, v);
                }
                catch (Exception Exc)
                {
                    throw new Exception("Error de conexion con la Servicio Web del Servidor de Identidad: " + Exc.Message);
                }
            }

            return coo;
        }
        public string Nombre_CLlamadas()
        {
            string sCadenaConexion = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;

            string sSQL = "SELECT CentroLlamadas FROM TLB_Banco";

            SqlConnection myconexion = new SqlConnection(sCadenaConexion);
            SqlCommand mycomand = new SqlCommand(sSQL, myconexion);
            string id = "";
            try
            {
                myconexion.Open();
                SqlDataReader myreader = mycomand.ExecuteReader();

                if (myreader.Read())
                {
                    id = myreader.GetString(0);
                }

                myreader.Close();
            }
            catch (Exception Exc)
            {
                throw new Exception("Error de conexion con la Base de Datos: " + Exc.Message);
            }
            finally
            {

                myconexion.Close();
            }

            return id;
        }

        public DataSet Ultimos_Movimientos(string tarjeta, string moneda, string servicio)
        {
            BancoPersistente bnk;
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());

                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;

                DataSet nuevo =  new DataSet();

                return ws.Ultimos_Movimientos(tarjeta, moneda, servicio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Cancelar_Registro_BancaMovil(string Tarjeta, string num_movil, string operador, out bool error, out int cod_error, out string mensaje)
        {
            error = false;
            cod_error = 0;
            mensaje = "";
            string resultado = "";

            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBanConnection;
            SqlConnection myconection = new SqlConnection(stringConection);

            //string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;                
            SqlCommand mycommand = new SqlCommand("SSP_ELIMINAR_REGISTRO_TRANSFERMOVIL", myconection);// sp en telebanca que dentro tiene el llamado al sp de banca movil
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.AddWithValue("@TARJETA_BT", Tarjeta);
            mycommand.Parameters.AddWithValue("@NUM_MOVIL", num_movil);
            mycommand.Parameters.AddWithValue("@OPERADOR", operador);


            mycommand.Parameters.Add("@ERROR", SqlDbType.Bit, 1);
            mycommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            mycommand.Parameters["@ERROR"].Value = 0;

            mycommand.Parameters.Add("@COD_ERROR", SqlDbType.Int, 2);
            mycommand.Parameters["@COD_ERROR"].Direction = ParameterDirection.Output;
            mycommand.Parameters["@COD_ERROR"].Value = 0;

            mycommand.Parameters.Add("@WRETURN", SqlDbType.VarChar, 2000);
            mycommand.Parameters["@WRETURN"].Direction = ParameterDirection.Output;
            mycommand.Parameters["@WRETURN"].Value = "";

            mycommand.CommandTimeout = 1800;
            try
            {
                myconection.Open();
                mycommand.ExecuteNonQuery();

                mensaje = mycommand.Parameters["@WRETURN"].Value.ToString();
                error = bool.Parse(mycommand.Parameters["@ERROR"].Value.ToString());
                cod_error = int.Parse(mycommand.Parameters["@COD_ERROR"].Value.ToString());
                //if (!mensaje.Contains("Error") && error == false && cod_error == 0)
                    resultado = mensaje;

            }
            catch (SqlException e)
            {
                resultado = "Ocurrio un problema. " + e.Message;
            }
            finally
            {

                myconection.Close();
            }

            return resultado;
        }

        public DataSet Localizar_TransfExterior(string Tarjeta, string num_ideper, out bool error, out int cod_error, out string mensaje)
        {
            error = false;
            cod_error = 0;
            mensaje = "";
            DataSet resultado = new DataSet();

            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBanConnection;
            SqlConnection myconection = new SqlConnection(stringConection);

            //string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;                
            SqlCommand mycommand = new SqlCommand("SSP_BT_LOCALIZA_TRANSFERENCIA", myconection);// sp en telebanca que dentro tiene el llamado al sp de metroci para localizar transf
            mycommand.CommandType = CommandType.StoredProcedure;
            mycommand.Parameters.AddWithValue("@ID_TARJETA", Tarjeta);
            mycommand.Parameters.AddWithValue("@NUM_IDEPER", num_ideper);


            mycommand.Parameters.Add("@ERROR", SqlDbType.Bit, 1);
            mycommand.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            mycommand.Parameters["@ERROR"].Value = 0;
            
            mycommand.Parameters.Add("@WRETURN", SqlDbType.VarChar, 2000);
            mycommand.Parameters["@WRETURN"].Direction = ParameterDirection.Output;
            mycommand.Parameters["@WRETURN"].Value = "";

            mycommand.Parameters.Add("@COD_ERROR", SqlDbType.Int, 2);
            mycommand.Parameters["@COD_ERROR"].Direction = ParameterDirection.Output;
            mycommand.Parameters["@COD_ERROR"].Value = 0;


            mycommand.CommandTimeout = 1800;
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(mycommand);

                myconection.Open();
                
                adaptador.Fill(resultado);

                if (resultado == null || resultado.Tables.Count == 0 || resultado.Tables[0].Rows.Count == 0)
                {
                    foreach (DataRow item in resultado.Tables[0].Rows)
                    {
                        error = true;
                        cod_error = int.Parse(item["@ERROR"].ToString());
                        mensaje = item["@WRETURN"].ToString();
                    }
                }                
                

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {

                myconection.Close();
            }

            return resultado;
        }


        public DataSet ReportesGrales()
        {
            DataSet nombres = new DataSet();
            string stringConection = DataAccessLayer.Properties.Settings.Default.TeleBanConnection;
            SqlConnection myconection = new SqlConnection(stringConection);

            SqlCommand command = new SqlCommand("SSP_BT_NOMBRES_REPORTES", myconection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adaptador = new SqlDataAdapter(command);

            try
            {
                myconection.Open();
                adaptador.Fill(nombres);
            }
            catch (SqlException e)
            {
                DataTable t_error = new DataTable("ERROR");
                DataColumn c1 = new DataColumn("mensaje");
                t_error.Columns.Add(c1);                

                DataRow fila = t_error.NewRow();
                fila[0] = "Error. "+e.Message;
                
                nombres.Tables.Add(t_error);
            }
            finally
            {

                myconection.Close();
            }

            return nombres;
        }

        public DataSet Datos_MTARJ(string tarjeta)
        {
            DataSet resultado = new DataSet();
            BancoPersistente bnk;
            string error="";
            try
            {
                bnk = GetBancoDadoID(this.N_CLlamadas());
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bnk.WebServices;

                resultado = ws.GetDatosCliente_MTARJ(tarjeta);
                if (resultado == null)
                {
                    error = "Hubo un error a la hora de traer los datos del cliente en SABIC. ";
                    throw new Exception(error);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(error+ex.Message);
            }

            return resultado;
        }

        public DataSet Buscar_Tarjetas_PAN_Cliente(string numideper, string codtipid, string codpais)
        {
            DataSet resultado = new DataSet();

            try
            {
                BancoPersistente bank = GetBancoDadoID(this.N_CLlamadas());
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bank.WebServices;

                
            }
            catch (Exception ex)
            {

                throw;
            }
            return resultado;
        }

        public DataSet Datos_PAN(string pan, string tb, string numideper, string codtipid, string codpais, out string mensaje_error, out int cod_error)
        {
            DataSet dataset = new DataSet();
            bool valido = false;
            mensaje_error = "";
            cod_error = 0;

            try
            {
                BancoPersistente bank = GetBancoDadoID(this.N_CLlamadas());
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bank.WebServices;

                dataset = ws.GetDatosPan(pan, tb, numideper, codtipid, codpais);

                //if (dataset != null)
                //{
                //    string cod_categoria = dataset.Tables[0].Rows[0][4].ToString();
                //    string caract_categoria = dataset.Tables[0].Rows[0][5].ToString().Trim();
                //    string codigo_error = dataset.Tables[1].Rows[0][1].ToString();

                //    if (cod_categoria == "30" && caract_categoria == "Titular" && codigo_error == "0")
                //    {
                //        valido = true;
                //    }
                //    else
                //    {
                //        mensaje_error = dataset.Tables[1].Rows[0][0].ToString();
                //        cod_error = int.Parse(dataset.Tables[1].Rows[0][1].ToString());
                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }

            return dataset;
            //return valido ? "Satisfactorio":mensaje_error;
        }


        public DataSet GuardarInfoPAN_Activacion(string pan, string num_ideper, string codigo_encrip, string estado, out string mensaje, out int cod_error)
        {
            DataSet resultado = new DataSet();
            mensaje = "";
            cod_error = 0;
            try
            {
                BancoPersistente bank = GetBancoDadoID(this.N_CLlamadas());
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bank.WebServices;

                resultado = ws.SaveInfoPAN(pan, num_ideper, codigo_encrip, estado, out mensaje, out cod_error);
                //resultado = ws.SaveInfoPAN(pan, num_ideper, codigo_encrip, estado, out mensaje, out cod_error);

                if (resultado != null)
                {
                    if (mensaje != "" && cod_error != 0)
                    {
                        throw new Exception(mensaje);
                    }
                }

                //if (dataset != null)
                //{
                //    string cod_categoria = dataset.Tables[0].Rows[0][4].ToString();
                //    string caract_categoria = dataset.Tables[0].Rows[0][5].ToString().Trim();
                //    string codigo_error = dataset.Tables[1].Rows[0][1].ToString();

                //    if (cod_categoria == "30" && caract_categoria == "Titular" && codigo_error == "0")
                //    {
                //        valido = true;
                //    }
                //    else
                //    {
                //        mensaje_error = dataset.Tables[1].Rows[0][0].ToString();
                //        cod_error = int.Parse(dataset.Tables[1].Rows[0][1].ToString());
                //    }
                //}
            }
            catch (Exception)
            {
                
                throw new Exception("Los datos enviados para la activacion del PIN digital no se han procesado por el SABIC");
            }

            return resultado;
        }

        public DataSet Importe_Conv_USD_to_CUPon(string moneda_origen, string moneda_destino, DateTime fecha_bt, float importe_acreditar)
        {
            DataSet resultado = new DataSet();
            
            try
            {
                BancoPersistente bank = GetBancoDadoID(this.N_CLlamadas());
                WSBanco.Service ws = new WSBanco.Service();
                ws.Url = bank.WebServices;

                resultado = ws.Importe_Debito_USD(moneda_origen,moneda_destino,fecha_bt,importe_acreditar);
                //resultado = ws.SaveInfoPAN(pan, num_ideper, codigo_encrip, estado, out mensaje, out cod_error);

                if (resultado == null || resultado.Tables[0].Rows.Count==0)
                {
                    throw new Exception("Error SABIC");                    
                }                
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }

    #endregion
    }
}