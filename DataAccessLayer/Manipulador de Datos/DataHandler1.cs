using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Timers;
using System.Web.Services;
using System.IO;


namespace DataAccessLayer
{ 
    public partial class DataHandler
    {
        public Reportes.PersonalDetallado ReportePersonalDetallado()
        {
            Reportes.PersonalDetallado Result = new DataAccessLayer.Reportes.PersonalDetallado();
            DataSet1 TempDS = new DataSet1();
            new DataSet1TableAdapters.TLB_EntidadesTableAdapter().Fill(TempDS.TLB_Entidades);
            new DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter().Fill(TempDS.TLB_RelacionUserEntid);
            Result.SetDataSource(TempDS);            
            Result.Refresh();
            return Result; 
        }

        /************* INICIO ************** MODULO INFORMACION ****************** INICIO ****************/

        public EntidadPersistente BuscarEntidadPorNombre(string Nombre)
        {
            DataSet1TableAdapters.TLB_EntidadesTableAdapter entidades = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
            DataSet1 ds1 = new DataSet1();
            entidades.Fill(ds1.TLB_Entidades);

            EntidadPersistente result = new EntidadPersistente();

            foreach (DataSet1.TLB_EntidadesRow i in ds1.TLB_Entidades)
            {
                if (i.Nombre == Nombre)
                {
                    try
                    {
                        result.Codigo = i.CodActual;
                    }
                    catch
                    {
                        result.Codigo =  "";
                    }
                    result.CodigoAnterior = i.CodAntSucursal;

                    result.Nombre = i.Nombre;
                    result.Direccion = i.Direccion;

                    try
                    {
                        result.Fax = i.Fax;
                    }
                    catch
                    {
                        result.Fax = "";
                    }

                    result.Telefono = i.Telefono;

                    List<string> TempList = new List<string>();
                    try
                    {
                        TempList.AddRange(i.CorreoElectronico.Split(';'));
                    }
                    catch { }
                    result.CorreoElectronico = TempList;
                    TempList = new List<string>();
                    try
                    {
                        TempList.AddRange(i.SitioWeb.Split(';'));
                    }
                    catch { }
                    result.SitiosWeb = TempList;
                    break;
                }
            }
            return result;
        }
        
        public List<EntidadPersistente> BuscarEnAgendaElectronica(string consulta)
        {
            SqlConnection myConnection = new SqlConnection(Properties.Settings.Default.TeleBancaConnectionString);


            SqlCommand command = new SqlCommand(consulta, myConnection);
            List<EntidadPersistente> entidades = new List<EntidadPersistente>();
            try
            {
                myConnection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                EntidadPersistente entidad = new EntidadPersistente();
                object[] objEntidad = new object[8];
                char [] arr = new char[1]{';'};
                while(dataReader.Read())
                {
                  
                    dataReader.GetValues(objEntidad);
                    entidad.Nombre = objEntidad[2].ToString();
                    entidad.Direccion = objEntidad[3].ToString();
                    entidad.Telefono = objEntidad[5].ToString();
                    entidad.Fax = objEntidad[4].ToString();
                    entidad.Codigo = objEntidad[0].ToString();
                    entidad.CodigoAnterior = objEntidad[1].ToString();
                    entidad.CorreoElectronico.AddRange(objEntidad[6].ToString().Split(arr));
                    entidad.SitiosWeb.AddRange(objEntidad[7].ToString().Split(arr));
                    entidades.Add(entidad);
                    entidad = new EntidadPersistente();
                    objEntidad = new object[8];
                } return entidades;
   
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                myConnection.Close();
            }
        }

        /*-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ PINES -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_*/
        
        public List<LotePersistente> LotesContenido()
        {
            throw new NotImplementedException();
        }    


        /*-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_ TARJETAS -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_*/
        //Modifica el estado de la tarjeta
        public bool ModificarEstadoDeLaTarjeta(string tarjeta, string nuevoEstado)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjetaN = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();
            ds1.TLB_Tarjeta.Merge(tarjetaN.ExisteTarjeta1(tarjeta));

            DataSet1.TLB_TarjetaRow tmp = ds1.TLB_Tarjeta.FindById_NoTarjeta(tarjeta);

            if (tmp != null)
            {
                tmp.Estado = nuevoEstado;
                tarjetaN.Update(ds1.TLB_Tarjeta);
                return true;
            }
            return false;
        }

        //Buscar una tarjeta
        public TarjetaPersistente BuscarTarjeta(string tarjeta)
        {
            TarjetaPersistente result = new TarjetaPersistente();
            

            if (tarjeta.Substring(0, 2) == "06")
            {
                
                BancoPersistente BNK = GetBancoDadoID(tarjeta.Substring(0, 2));
                string URL = BNK.Identificationserver.ToString();

                ISWS.Service1Client IS = new ISWS.Service1Client(new System.ServiceModel.BasicHttpBinding(), new System.ServiceModel.EndpointAddress(URL));
                ISWS.TB_Data DP = new ISWS.TB_Data();
                ISWS.DatosPersona DPP = new ISWS.DatosPersona();
                ISWS.VData DB = new ISWS.VData();

                try
                {
                    
                   DP = IS.TB_BuscarPersona(tarjeta,3);
                   result.Estado = DP.EstadoTarjeta;
                   result.IdNumeroTarjeta = DP.TarjetaId;
                   result.NombrePropietario = DP.Persona.Nombre;
                   result.Apellidos = DP.Persona.Apellido1 + " " + DP.Persona.Apellido2;
                   result.TipoIdentificacion = DP.Persona.TipoId;
                   result.NoSucursal = DP.Persona.Sucursal;
                   result.IdCliente = DP.Persona.IdNumber;
                   result.Pais = DP.Persona.Pais;
                   
                }
                catch (Exception e)
                {
                    ///*escribir en el log*/

                    //string path = @"C:\Logs_Telebanca\log_error.txt";

                    //using (TextWriter writer = File.AppendText(path))
                    //{
                    //    string separador = " : ";
                    //    string metodo_error = "BuscarTarjeta -> TB: "+tarjeta+" \n";
                    //    string nombre_proyecto = "(DataAccessLayer): ";
                    //    string date = DateTime.Now.ToString() + " \n";
                    //    string separa = "-------------------------------------------------------";
                    //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
                    //}

                    throw new Exception("Tarjeta no existente, o no activada para ser utilizada desde Banca Telefónica ",e);
                }

                return result;
            }
            
            if (tarjeta.Substring(0, 2) == "95")
            {
                DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjetaN = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
                DataSet1TableAdapters.TLB_MatrizTableAdapter matriz = new DataAccessLayer.DataSet1TableAdapters.TLB_MatrizTableAdapter();
                DataSet1TableAdapters.TLB_PaisTableAdapter Pais = new DataAccessLayer.DataSet1TableAdapters.TLB_PaisTableAdapter();
                DataSet1TableAdapters.TLB_LoteTableAdapter Lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();

                DataSet1.TLB_TarjetaRow tmp = null;
                DataSet1.TLB_MatrizRow TmpMatriz = null;

                try
                {
                    tmp = tarjetaN.ExisteTarjeta1(tarjeta)[0];
                    TmpMatriz = matriz.ObtenerMatriz(tmp.Id_Matriz)[0];
                }
                catch { }
                

                if (tmp != null)
                {
                    result.Estado = tmp.Estado;
                    result.EstadoPin = tmp.EstadoPin;
                    result.FechaOrdenImp = tmp.FechaOrdenImp;
                    result.IdCliente = tmp.IdentificacionCliente;
                    try { result.IdLote = tmp.Id_Lote; }
                    catch { result.IdLote = -1; }
                    result.IdNumeroTarjeta = tmp.Id_NoTarjeta;
                    result.Matriz = new Matriz(TmpMatriz.Id_Matriz, TmpMatriz.C1,
                        TmpMatriz.C2, TmpMatriz.C3, TmpMatriz.C4, TmpMatriz.C5,
                        TmpMatriz.C6, TmpMatriz.C7, TmpMatriz.C8, TmpMatriz.C9,
                        TmpMatriz.C10, true);
                    result.NombrePropietario = tmp.Nombre;
                    result.Apellidos = tmp.PrimerApellido;
                    result.TipoIdentificacion = tmp.TipoIdentificacion;
                    result.NoSucursal = tmp.NoSucursal;
                    result.NoPin = tmp.No_Pin;
                    result.Pais = tmp.Id_Pais;
                }
                else
                {
                    result.Estado = "";
                }
                

            }

            if (tarjeta.Substring(0, 2) == "12")
            {
                

            }
            return result;
            
        }    
        
               
        //Lista de tarjetas que tengan el estado especificado
        public List<TarjetaPersistente> BuscarTarjetasPorEstado(string estado)
        {
            List<TarjetaPersistente> Result = new List<TarjetaPersistente>();
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjetaN = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();
            tarjetaN.Fill(ds1.TLB_Tarjeta);

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                if (i.Estado == estado)
                    Result.Add(BuscarTarjeta(i.Id_NoTarjeta));
                
            }
              return Result;
        }           


        //Guarda en un historico los datos de la tarjeta(TLB_HistoricoTarjetas) 
        public bool GuardarTarjetaEnHistorico(TarjetaPersistente t)
        {
            DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter historicoT = new DataAccessLayer.DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter();
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1TableAdapters.TLB_SucursalTableAdapter sucursal = new DataAccessLayer.DataSet1TableAdapters.TLB_SucursalTableAdapter();


            DataSet1 ds1 = new DataSet1();
            tarjeta.Fill(ds1.TLB_Tarjeta);
            sucursal.Fill(ds1.TLB_Sucursal);
            historicoT.Fill(ds1.TLB_HistoricoTarjetas);

            DataSet1.TLB_SucursalRow sucursalRow = ds1.TLB_Sucursal.FindByNoSucursal(t.NoSucursal);

            DataSet1.TLB_TarjetaRow result = ds1.TLB_Tarjeta.FindById_NoTarjeta(t.IdNumeroTarjeta);
            if (result != null && sucursalRow != null)
            {
                DataSet1.TLB_HistoricoTarjetasRow historicoRow = ds1.TLB_HistoricoTarjetas.NewTLB_HistoricoTarjetasRow();
                historicoRow.Estado = t.Estado;
                historicoRow.FechaBaja = DateTime.Today;
                historicoRow.Id_Matriz = result.Id_Matriz;
                historicoRow.Id_Pin = t.NoPin;
                historicoRow.Id_Lote = t.IdLote;

                historicoRow.Nombre = t.NombrePropietario;
                historicoRow.PrimerApellido = t.Apellidos;
                historicoRow.SegundoApellido = "";
                historicoRow.NoSucursal = t.NoSucursal;
                historicoRow.NoTarjeta = t.IdNumeroTarjeta;
                historicoRow.Id_Pais = t.Pais;
                historicoRow.IdentificacionCliente = t.IdCliente;
                historicoRow.TipoIdentificacion = t.TipoIdentificacion;


                ds1.TLB_HistoricoTarjetas.AddTLB_HistoricoTarjetasRow(historicoRow);
                historicoT.Update(ds1.TLB_HistoricoTarjetas);
                return true;
            }
            return false;
        }

        //Eliminar tarjeta 
        public bool EliminarTarjeta(string numero)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1TableAdapters.TLB_TransaccionTableAdapter transaccion = new DataAccessLayer.DataSet1TableAdapters.TLB_TransaccionTableAdapter();
            DataSet1TableAdapters.TLB_HistoricoTransacionesTableAdapter historicoTRANS = new DataAccessLayer.DataSet1TableAdapters.TLB_HistoricoTransacionesTableAdapter();

            DataSet1 ds1 = new DataSet1();
            tarjeta.Fill(ds1.TLB_Tarjeta);
            transaccion.Fill(ds1.TLB_Transaccion);
            historicoTRANS.Fill(ds1.TLB_HistoricoTransaciones);

            DataSet1.TLB_TarjetaRow tmp = ds1.TLB_Tarjeta.FindById_NoTarjeta(numero);

            if (tmp != null)
            {
                DataSet1.TLB_TransaccionRow[] listaTrans = tmp.GetTLB_TransaccionRows();


                for (int i = 0; i < listaTrans.Length; i++)
                {

                    DataSet1.TLB_HistoricoTransacionesRow transRow = ds1.TLB_HistoricoTransaciones.NewTLB_HistoricoTransacionesRow();
                    transRow.Asociado = listaTrans[i].Asociado;
                    transRow.Id_NoTarjeta = listaTrans[i].Id_NoTarjeta;
                    transRow.ID_SERV = listaTrans[i].ID_SERV;
                    transRow.Id_Transacción = listaTrans[i].Id_Transaccion;
                    transRow.Id_Usuario = listaTrans[i].Id_Usuario;
                    transRow.Importe = listaTrans[i].Importe;
                    transRow.FechaHora = listaTrans[i].FechaHora;
                    transRow.FechaHistorico = DateTime.Today;
                    ds1.TLB_HistoricoTransaciones.AddTLB_HistoricoTransacionesRow(transRow);
                    historicoTRANS.Update(ds1.TLB_HistoricoTransaciones);
                    listaTrans[i].Delete();

                }

                tmp.Delete();
                transaccion.Update(ds1.TLB_Transaccion);
                tarjeta.Update(ds1.TLB_Tarjeta);
                return true;
            }


            return false;
        }

        //Modificar el estado de la matriz
        public bool ModificarEstadoDeLaMatriz(int id, string nuevoEstado)
        {

            DataSet1TableAdapters.TLB_MatrizTableAdapter matriz = new DataAccessLayer.DataSet1TableAdapters.TLB_MatrizTableAdapter();
            DataSet1 ds1 = new DataSet1();
            matriz.Fill(ds1.TLB_Matriz);

            DataSet1.TLB_MatrizRow matrizROW = ds1.TLB_Matriz.FindById_Matriz(id);

            if (matrizROW != null)
            {
                matrizROW.Estado = nuevoEstado;
                matriz.Update(ds1.TLB_Matriz);
                return true;
            }

            return false;
        }

        //Modificar tarjeta -  SOLO SE MODIFICARAN ALGUNOS CAMPOS
        public bool ModificarTarjeta(string numero, TarjetaPersistente t)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            tarjeta.Fill(ds1.TLB_Tarjeta);

            DataSet1.TLB_TarjetaRow tarjRow = ds1.TLB_Tarjeta.FindById_NoTarjeta(numero);

            if (tarjRow != null)
            {
                tarjRow.Estado = t.Estado;
                tarjRow.EstadoPin = t.EstadoPin;
                tarjRow.FechaOrdenImp = t.FechaOrdenImp;
                tarjRow.Id_Matriz = t.Matriz.ID;
                tarjRow.No_Pin = t.NoPin;

                tarjeta.Update(ds1.TLB_Tarjeta);

                return true;
            }

            return false;

        }

        //Cantidad de Solicicitudes en el dia 
        public int CantidadDeSolicitudesDeBajaDelDia()
        {
            DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter historico = new DataAccessLayer.DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter();
            DataSet1 ds1 = new DataSet1();

            historico.Fill(ds1.TLB_HistoricoTarjetas);

            return historico.CantSolicBajasPorDia(DateTime.Today).Count;

        }

        //Es la cantidad de tarjetas de Histórico de Tarjetas dado el estado y que su fecha sea la actual...
        public int CantidadDeTarjetasCambiadasEnElDiaDadoEstado(string estado)
        {
            DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter historico = new DataAccessLayer.DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter();

            return (int)historico.CantTarjCambiadasDiaDadoEstado(DateTime.Today.Date, estado);
        }


        //obtener 10 matrices del total disponible
        public List<Matriz> Obtener10MatricDisponibles()
        {
            DataSet1TableAdapters.TLB_MatrizTableAdapter matriz = new DataAccessLayer.DataSet1TableAdapters.TLB_MatrizTableAdapter();
            DataSet1 ds1 = new DataSet1();

            matriz.Fill(ds1.TLB_Matriz);
            List<Matriz> result = new List<Matriz>();

            DataSet1.TLB_MatrizDataTable matrices = matriz.ObtenerMatricesDisponibles();

            foreach (DataSet1.TLB_MatrizRow i in matrices)
            {
                result.Add(new Matriz(i.Id_Matriz,i.C1,i.C2,i.C3,i.C4,i.C5,i.C6,i.C7,i.C8,i.C9,i.C10,true));
            }
            return result;
        }

        public int CantidadDeMatricesDisponibles()
        {
            DataSet1TableAdapters.TLB_MatrizTableAdapter matriz = new DataAccessLayer.DataSet1TableAdapters.TLB_MatrizTableAdapter();
            DataSet1 ds1 = new DataSet1();
            matriz.Fill(ds1.TLB_Matriz);

            int contador = 0;

            foreach(DataSet1.TLB_MatrizRow i in ds1.TLB_Matriz)
            {
                if(i.Estado == "desocupada")
                    contador++;
            }

            return contador;
        }


        public List<TarjetaPersistente> TarjetasImpresasDadoFecha(DateTime f)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();


            DataSet1 ds1 = new DataSet1();
            lote.Fill(ds1.TLB_Lote);
            
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();
            DateTime fIni = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
            DateTime fFin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59);
            ds1.Merge(tarjeta.TarjetasImpresasDadoFecha(fIni,fFin));

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta,i.No_Pin,i.Nombre,
                                                  i.PrimerApellido,i.NoSucursal,
                                                  i.FechaOrdenImp,i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));
            }

            return result;
        }

        public List<TarjetaPersistente> TarjetasImpresasPorOperadora(string operadora)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();
                     

            ds1.Merge(tarjeta.TarjetasImpresasDadoOperadora(operadora));
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta, i.No_Pin, i.Nombre,
                                                  i.PrimerApellido, i.NoSucursal,
                                                  i.FechaOrdenImp, i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));
            }

            return result;

        }

               
        public List<TarjetaPersistente> TarjetasDadoSucursalEstado(string sucursal, string estado) 
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();


            ds1.Merge(tarjeta.TarjetaDadoSucursalEstado(sucursal,estado));
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta, i.No_Pin, i.Nombre,
                                                  i.PrimerApellido, i.NoSucursal,
                                                  i.FechaOrdenImp, i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));
                
            }

            return result;

        }

        public List<TarjetaPersistente> TarjetaDadoNombreCliente(string nombreCliente)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            ds1.Merge(tarjeta.TarjetaDadoNombreCliente(nombreCliente));

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {

                 result.Add( new TarjetaPersistente(i.Id_NoTarjeta, i.No_Pin, i.Nombre,
                                                  i.PrimerApellido, i.NoSucursal,
                                                  i.FechaOrdenImp, i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));

            } 
            return result;
        }

        public List<TarjetaPersistente> TarjetasDadoApellidoCliente(string apellidoCliente)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            ds1.TLB_Tarjeta.Merge(tarjeta.TarjetaDadoApellidoCliente(apellidoCliente));
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta, i.No_Pin, i.Nombre,
                                                  i.PrimerApellido, i.NoSucursal,
                                                  i.FechaOrdenImp, i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));

            }

            return result;
        }

        
        public List<TarjetaPersistente> TarjetasDadoBancoEstado(string codigoBanco, string estado) 
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();


            ds1.Merge(tarjeta.TarjetaDadoBancoEstado(codigoBanco,estado));
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta, i.No_Pin, i.Nombre,
                                                  i.PrimerApellido, i.NoSucursal,
                                                  i.FechaOrdenImp, i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));

            }

            return result;


        }

        public TarjetaPersistente TarjetasDadoIdCliente(string idCliente)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();
            tarjeta.Fill(ds1.TLB_Tarjeta);

            DataSet1.TLB_TarjetaRow tarjRow = tarjeta.TarjetaDadoIdCliente(idCliente)[0];
            TarjetaPersistente result = new TarjetaPersistente();

            if (tarjRow != null)
            {
                result.Estado = tarjRow.Estado;
                result.EstadoPin = tarjRow.EstadoPin;
                result.FechaOrdenImp = tarjRow.FechaOrdenImp;
                try {result.IdLote = tarjRow.Id_Lote;}
                catch {result.IdLote = -1; }                
                result.IdCliente = tarjRow.IdentificacionCliente;
                result.IdNumeroTarjeta = tarjRow.Id_NoTarjeta;
                result.Matriz = new Matriz(tarjRow.TLB_MatrizRow.Id_Matriz, tarjRow.TLB_MatrizRow.C1,
                                           tarjRow.TLB_MatrizRow.C2, tarjRow.TLB_MatrizRow.C3, tarjRow.TLB_MatrizRow.C4,
                                           tarjRow.TLB_MatrizRow.C5, tarjRow.TLB_MatrizRow.C6, tarjRow.TLB_MatrizRow.C7,
                                           tarjRow.TLB_MatrizRow.C8, tarjRow.TLB_MatrizRow.C9, tarjRow.TLB_MatrizRow.C10, true);
                result.NombrePropietario = tarjRow.Nombre;
                result.Apellidos = tarjRow.PrimerApellido;                
                result.NoSucursal = tarjRow.NoSucursal;
                result.NoPin = tarjRow.No_Pin;
                result.TipoIdentificacion = tarjRow.TipoIdentificacion;
                result.Pais = tarjRow.Id_Pais;               
                
            }
            return result;
        }


        public bool SalvarEnHistoricoTransaccionesDadoTarjeta(string idTarjeta)
        {
            DataSet1TableAdapters.TLB_TransaccionTableAdapter transaccion = new DataAccessLayer.DataSet1TableAdapters.TLB_TransaccionTableAdapter();
            

            DataSet1 ds1 = new DataSet1();

            transaccion.Fill(ds1.TLB_Transaccion);
            
            DataSet1.TLB_HistoricoTransacionesRow insertarTrans = ds1.TLB_HistoricoTransaciones.NewTLB_HistoricoTransacionesRow();
            DataSet1.TLB_TransaccionDataTable transTable = transaccion.ObtenerTransaccionDadoIdTarjeta(idTarjeta);

            if (transTable.Count != 0)
            {
                foreach (DataSet1.TLB_TransaccionRow i in transTable)
                {
                    insertarTrans.Asociado = i.Asociado;
                    insertarTrans.FechaHistorico = DateTime.Today;
                    insertarTrans.FechaHora = i.FechaHora;
                    insertarTrans.Id_NoTarjeta = i.Id_NoTarjeta;
                    insertarTrans.ID_SERV = i.ID_SERV;
                    insertarTrans.Id_Transacción = i.Id_Transaccion;
                    insertarTrans.Id_Usuario = i.Id_Usuario;
                    insertarTrans.Importe = i.Importe;
                    insertarTrans.Traza = i.Traza;

                }
                return true;
             }
             return false;
        }


        public int ObtenerCantPorFechaYNoSucursal(DateTime fecha, string noSucursal)
        {
            return (int)new DataSet1TableAdapters.TLB_TarjetaTableAdapter().CantidadTarjetasSinLoteDadoFecha(noSucursal, fecha.Date);
        }

        //Buscar las tarjetas con Id_Lote en null y en estado C
        //DISTINCT para campo NoSucursal
        public List<string> BuscarTarjetasNoIdLoteEstadoC()
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();
            tarjeta.Fill(ds1.TLB_Tarjeta);

            List<string> list = new List<string>();
            
            foreach (DataSet1.TLB_TarjetaRow i in tarjeta.BuscarTarjetasNoIdLoteEstadoC1())
            {
                list.Add(i.NoSucursal);
            }
            return list;
        }


        public List<TarjetaPersistente> TarjetasAImprimirPorSucursal(string NoSucursal)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();


            ds1.Merge(tarjeta.TarjetasAImprimirPorSucursal(NoSucursal));
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            //try
            {
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta, i.No_Pin, i.Nombre,
                                                  i.PrimerApellido, i.NoSucursal,
                                                  i.FechaOrdenImp, i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));
            }            

            return result;

        }


       
        public List<TarjetaPersistente> TarjetasAImprimirPorSucursalNoIdLoteFecha(string noSucursal, DateTime f)
        {
            List<TarjetaPersistente> list = new List<TarjetaPersistente>();
           
            DateTime fini = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
            DateTime ffin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59);
            DataSet1.TLB_TarjetaDataTable tdt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorSucursalNoIdLoteFecha("C", fini, ffin, noSucursal);
                foreach (DataSet1.TLB_TarjetaRow i in tdt)
            {
                TarjetaPersistente t = new TarjetaPersistente();
                t.Estado = i.Estado;
                t.EstadoPin = i.EstadoPin;
                t.FechaOrdenImp = i.FechaOrdenImp;
                t.IdCliente = i.IdentificacionCliente;
                try { t.IdLote = i.Id_Lote; }
                catch { t.IdLote = -1; }                
                t.IdNumeroTarjeta = i.Id_NoTarjeta;
                t.Matriz.ID = i.Id_Matriz;
                t.NombrePropietario = i.Nombre;
                t.NoPin = i.No_Pin;
                t.NoSucursal = i.NoSucursal;
                t.Pais = i.Id_Pais;
                t.Apellidos = i.PrimerApellido;                
                t.TipoIdentificacion = i.TipoIdentificacion;
                list.Add(t);
            }
            return list;
        }


        //Tarjetas listas para imprimir dado UNA sucursal que no tengan Id_Lote
        public List<TarjetaPersistente> TarjetasAImprimirPorSucursalNoIdLote(string noSucursal)
        {
            List<TarjetaPersistente> list = new List<TarjetaPersistente>();
            DataSet1.TLB_TarjetaDataTable tdt = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().TarjetasDesucursalIdNullCreadas(noSucursal);
            foreach (DataSet1.TLB_TarjetaRow i in tdt)
            {
                TarjetaPersistente t = new TarjetaPersistente();
                t.Estado = i.Estado;
                t.EstadoPin = i.EstadoPin;
                t.FechaOrdenImp = i.FechaOrdenImp;
                t.IdCliente = i.IdentificacionCliente;
                t.IdNumeroTarjeta = i.Id_NoTarjeta;
                t.Matriz.ID = i.Id_Matriz;
                t.NombrePropietario = i.Nombre;
                t.NoPin = i.No_Pin;
                t.NoSucursal = i.NoSucursal;
                t.Pais = i.Id_Pais;
                t.Apellidos = i.PrimerApellido;                
                t.TipoIdentificacion = i.TipoIdentificacion;
                try { t.IdLote = i.Id_Lote; }
                catch { t.IdLote = -1; }
                list.Add(t);
            }
            return list;
        }

        //Mostrar las tarjetas listas para imprimir dado UN numero de sucursal y UNA fecha
        public List<TarjetaPersistente> TarjetasAImprimirPorSucursalYFecha(string noSucursal, DateTime fecha)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            DateTime fini = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime ffin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
            ds1.Merge(tarjeta.TarjetasAImprimirPorSucursalYFecha(noSucursal, fini, ffin));
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta, i.No_Pin, i.Nombre,
                                                  i.PrimerApellido, i.NoSucursal,
                                                  i.FechaOrdenImp, i.EstadoPin,
                                                  i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                       i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                       i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                       i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                  i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));

            }

            return result;

         
        }




      //Buscara las tarjetas en Estado Creadas o Activas (depende del parametro "estado") dado la fecha de impresion de la tarjeta
        public List<TarjetaPersistente> TarjetasEnEstadoCreadaActivasDadoFecha(DateTime fecha, string estado)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            tarjeta.Fill(ds1.TLB_Tarjeta);
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();


            DateTime fIni = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime fFin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
            ds1.Merge(tarjeta.TarjetasEnEstadoCreadasActivasDadoFecha(estado,fIni,fFin));

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                result.Add(new TarjetaPersistente(i.Id_NoTarjeta,i.No_Pin, i.Nombre,
                                                                 i.PrimerApellido, i.NoSucursal,
                                                                 i.FechaOrdenImp, i.EstadoPin,
                                                                 i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                                      i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                                      i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                                      i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                                 i.Id_Lote, i.IdentificacionCliente, i.TipoIdentificacion, i.Id_Pais));
            }
            return result;
        }

        public List<TarjetaPersistente> TarjetasDeshabilitadasPedidasDadoFecha(DateTime fecha, string estado)
        {
            DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter historTarj = new DataAccessLayer.DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter();
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();

            DataSet1 ds1 = new DataSet1();
            tarjeta.Fill(ds1.TLB_Tarjeta);

            DateTime fIni = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime fFin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
            ds1.Merge(historTarj.TarjetasEnEstadoPedidaDeshDadoFecha(fIni,fFin,estado));
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();

            int Id_lote= 0; 
  

            foreach(DataSet1.TLB_HistoricoTarjetasRow i in ds1.TLB_HistoricoTarjetas)
            {
                
                result.Add(new TarjetaPersistente(i.NoTarjeta, i.Id_Pin, i.Nombre,
                                                                 i.PrimerApellido, i.NoSucursal,
                                                                 i.FechaBaja, i.Estado,
                                                                 i.Estado, new Matriz(i.TLB_MatrizRow.Id_Matriz, i.TLB_MatrizRow.C1,
                                                                                      i.TLB_MatrizRow.C2, i.TLB_MatrizRow.C3, i.TLB_MatrizRow.C4,
                                                                                      i.TLB_MatrizRow.C5, i.TLB_MatrizRow.C6, i.TLB_MatrizRow.C7,
                                                                                      i.TLB_MatrizRow.C8, i.TLB_MatrizRow.C9, i.TLB_MatrizRow.C10, true),
                                                                 Id_lote, "-","-", null));
            }

            return result;
        }

        /*pone las tarjetas que esten en estado deshabiitada que se encuentren en la tabla tarjeta 
        en la tabla HistoricoTarjetas  y las elimina de la tabla tarjeta*/
        public int DeshabilitarTarjetas()
        {
            
            int Result = 0;            
            DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter HistoricoTA = new DataSet1TableAdapters.TLB_HistoricoTarjetasTableAdapter();
            List<TarjetaPersistente> TempTargetas = BuscarTarjetasPorEstado("D");
            foreach (TarjetaPersistente i in TempTargetas)
            {
                HistoricoTA.Insert(i.IdNumeroTarjeta, i.NoSucursal,i.Matriz.ID, i.NoPin, i.NombrePropietario,i.Apellidos,
                    "", i.Estado, DateTime.Now, i.IdLote, i.IdCliente, i.TipoIdentificacion, i.Pais, DateTime.Today, "Deshabilitar Tarjeta");

                EliminarTarjeta(i.IdNumeroTarjeta);
                Result++;
            }
            return Result;  
        }


        public List<TarjetaPersistente> ObtenerListaTarjeta()
        {

            List<TarjetaPersistente> result = new List<TarjetaPersistente>();
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            tarjeta.Fill(ds1.TLB_Tarjeta);
            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                result.Add(BuscarTarjeta(i.Id_NoTarjeta));
            }
            return result;

        }

        //actualiza el ID_lote de la tarjeta y el estado (activa) porque se acaba de imprimir
        public bool ActualizarTarjetasAImprimir(string IdNumeroTarjeta, int idLote)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            tarjeta.Fill(ds1.TLB_Tarjeta);

            DataSet1.TLB_TarjetaRow tarjetRow = ds1.TLB_Tarjeta.FindById_NoTarjeta(IdNumeroTarjeta);
            

            if (tarjetRow != null)
            {
                tarjetRow.Id_Lote = idLote;
                tarjeta.Update(ds1.TLB_Tarjeta);
                return true;

            }
            return false;
        }


        public int CodigoBanco(string nombreBanco)
        {
            return 1;
        }

        public List<TarjetaPersistente> TarjetasDadoLote(int lote)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1TableAdapters.TLB_MatrizTableAdapter matriz = new DataAccessLayer.DataSet1TableAdapters.TLB_MatrizTableAdapter();
            
            DataSet1 ds1 = new DataSet1();
            
            matriz.Fill(ds1.TLB_Matriz);
            tarjeta.Fill(ds1.TLB_Tarjeta);
            List<TarjetaPersistente> result = new List<TarjetaPersistente>();
            
            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                try
                {                   
                    if (i.Id_Lote == lote)
                    {
                      
                        TarjetaPersistente T = new TarjetaPersistente();
                        String IdNumeroTarjeta="";                        
                        String NoPin="";                      
                        String NombrePropietario="";                         
                        String Apellidos="";                        
                        String NoSucursal="";                        
                        DateTime FechaOrdenImp=DateTime.Now;                       
                        String EstadoPin="";                         
                        String Estado="";
                        int Id_Lote = -1;                        
                        String IdentificacionCliente="";                      
                        String TipoIdentificacion="";                       
                        String Id_Pais= "";
                        int Id_MAtriz = 0;

                        String MatrizRow_C1 = "";
                        String MatrizRow_C2 = "";
                        String MatrizRow_C3 = "";
                        String MatrizRow_C4 = "";
                        String MatrizRow_C5 = "";
                        String MatrizRow_C6 = "";
                        String MatrizRow_C7 = "";
                        String MatrizRow_C8 = "";
                        String MatrizRow_C9 = "";
                        String MatrizRow_C10 = "";
                      
                                                
                        try {  IdNumeroTarjeta = i.Id_NoTarjeta; }
                        catch (Exception) { IdNumeroTarjeta = ""; }
                        try {  NoPin = i.No_Pin;}
                        catch (Exception) {  NoPin = ""; }
                        try {  NombrePropietario = i.Nombre; }
                        catch (Exception) {  NombrePropietario = ""; }
                        try {  Apellidos =i.PrimerApellido; }
                        catch (Exception) {  Apellidos = ""; }
                        try {  NoSucursal = i.NoSucursal; }
                        catch (Exception) {  NoSucursal = ""; }
                        try { FechaOrdenImp = i.FechaOrdenImp; }
                        catch (Exception) {  FechaOrdenImp = DateTime.Now; }
                        try { EstadoPin = i.EstadoPin; }
                        catch (Exception) { EstadoPin  =""; }
                        try { Estado = i.Estado; }
                        catch (Exception) { Estado =""; }
                         try { Id_Lote = i.Id_Lote; }
                        catch (Exception) { Id_Lote =-1; }
                         try { IdentificacionCliente = i.IdentificacionCliente; }
                        catch (Exception) { IdentificacionCliente =""; }
                         try { TipoIdentificacion = i.TipoIdentificacion; }
                        catch (Exception) { TipoIdentificacion =""; }
                         try { Id_Pais = i.Id_Pais; }
                        catch (Exception) { Id_Pais =""; }
                         try { Id_MAtriz = i.TLB_MatrizRow.Id_Matriz; }
                         catch (Exception) { Id_MAtriz = 0; }

                         try { MatrizRow_C1 = i.TLB_MatrizRow.C1; }
                         catch (Exception) { MatrizRow_C1 = ""; }
                         try { MatrizRow_C2 = i.TLB_MatrizRow.C2; }
                         catch (Exception) { MatrizRow_C2 = ""; }
                         try { MatrizRow_C3 = i.TLB_MatrizRow.C3; }
                         catch (Exception) { MatrizRow_C3 = ""; }
                         try { MatrizRow_C4 = i.TLB_MatrizRow.C4; }
                         catch (Exception) { MatrizRow_C4 = ""; }
                         try { MatrizRow_C5 = i.TLB_MatrizRow.C5; }
                         catch (Exception) { MatrizRow_C5 = ""; }
                         try { MatrizRow_C6 = i.TLB_MatrizRow.C6; }
                         catch (Exception) { MatrizRow_C6 = ""; }
                         try { MatrizRow_C7 = i.TLB_MatrizRow.C7; }
                         catch (Exception) { MatrizRow_C7 = ""; }
                         try { MatrizRow_C8 = i.TLB_MatrizRow.C8; }
                         catch (Exception) { MatrizRow_C8 = ""; }
                         try { MatrizRow_C9 = i.TLB_MatrizRow.C9; }
                         catch (Exception) { MatrizRow_C9 = ""; }
                         try { MatrizRow_C10 = i.TLB_MatrizRow.C10; }
                         catch (Exception) { MatrizRow_C10 = ""; }       
                        
                          result.Add(new TarjetaPersistente(IdNumeroTarjeta,
                          NoPin, NombrePropietario, Apellidos, NoSucursal,                                                                     
                         FechaOrdenImp, EstadoPin, Estado,

                         new Matriz(Id_MAtriz, MatrizRow_C1, MatrizRow_C2, MatrizRow_C3, MatrizRow_C4,
                          MatrizRow_C5, MatrizRow_C6, MatrizRow_C7, MatrizRow_C8, MatrizRow_C9, MatrizRow_C10, true),
                         
                          Id_Lote,IdentificacionCliente,TipoIdentificacion,Id_Pais));
                    } 
                }
                catch (Exception)
                {                 
                }
           }
            return result;
        }


        public string ObtenerNombrePaisDadoIdPais(string IdPais)
        {
            DataSet1TableAdapters.TLB_PaisTableAdapter pais = new DataAccessLayer.DataSet1TableAdapters.TLB_PaisTableAdapter();
            DataSet1 ds1 = new DataSet1();

            pais.Fill(ds1.TLB_Pais);

            DataSet1.TLB_PaisRow PaisRow = ds1.TLB_Pais.FindByCOD_PAIS(IdPais);

            if (PaisRow != null)
                return PaisRow.NOM_PAIS;
            else
                return "NoEncontrado";
        }
        
        //Buscar Lote-----------------LOTE------------------------------------------------------------------
        public LotePersistente BuscarLote(int Id_lote)
        {
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 = new DataSet1();
            lote.Fill(ds1.TLB_Lote);

            LotePersistente result = new LotePersistente();
            DataSet1.TLB_LoteRow loteRow = ds1.TLB_Lote.FindById_Lote(Id_lote);

            if (loteRow != null)
            {
                result.Id_Lote = loteRow.Id_Lote;
                result.FechaHoraImpPin = loteRow.FechaHoraPin;
                result.FechaHoraImpTarjetas = loteRow.FechaHoraTarjeta;
                result.IdUsuarioPin = loteRow.Id_UsuarioPin;
                result.IdUsuarioTarjeta = loteRow.Id_UsuarioTarjeta;

                return result;

            }
            return result;
        }
        public List<LotePersistente> LotesDadoOperadora(string operadora)
        {
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 = new DataSet1();
            lote.Fill(ds1.TLB_Lote);

            ds1.Merge(lote.LoteDadoOperadora(operadora));

            List<LotePersistente> result = new List<LotePersistente>();

            foreach (DataSet1.TLB_LoteRow i in ds1.TLB_Lote)
            {
                result.Add(new LotePersistente(i.Id_Lote,i.Id_UsuarioTarjeta,i.FechaHoraTarjeta,i.FechaHoraPin,i.Id_UsuarioPin,i.EstadoP,i.EstadoT));
            }

            return result;
        }


        //busca los lotes de Pines que imprimio una operadora determinada
        public List<LotePersistente> LotePinesFinalizados(string operadora)
        {

            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();

            DataSet1 ds1= new DataSet1();

            lote.Fill(ds1.TLB_Lote);

            DataSet1.TLB_LoteDataTable loteTable = lote.LotesPinesFinalizado(operadora);
            List<LotePersistente> result = new List<LotePersistente>();


            if (loteTable.Count != 0)
            {
                foreach (DataSet1.TLB_LoteRow i in loteTable)
                {
                    result.Add(new LotePersistente(i.Id_Lote, i.Id_UsuarioTarjeta, i.FechaHoraTarjeta, i.FechaHoraPin, i.Id_UsuarioPin, i.EstadoP, i.EstadoT));
                
                }
            }

            return result;
        }


        //busca los lotes de Tarjetas que imprimio una operadora determinada
        public List<LotePersistente> LoteTarjetasFinalizados(string operadora)
        {

            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();

            DataSet1 ds1 = new DataSet1();

            lote.Fill(ds1.TLB_Lote);

            DataSet1.TLB_LoteDataTable loteTable = lote.LotesTarjetasFinalizados(operadora);
            List<LotePersistente> result = new List<LotePersistente>();


            if (loteTable.Count != 0)
            {
                foreach (DataSet1.TLB_LoteRow i in loteTable)
                {
                    result.Add(new LotePersistente(i.Id_Lote, i.Id_UsuarioTarjeta, i.FechaHoraTarjeta, i.FechaHoraPin, i.Id_UsuarioPin, i.EstadoP, i.EstadoT));

                }
            }
            return result;
        }

        //buscar los lotes en lso cuales el estado sea creado ('c')
        public List<LotePersistente> BuscarLoteEstadoTC()
        {
            List<LotePersistente> LLOTE = new List<LotePersistente>();            
            try
            {
                DataSet1.TLB_LoteDataTable LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().GetLotesPorEstadoT("C");
                foreach (DataSet1.TLB_LoteRow i in LDT.Rows)
                {
                    List<TarjetaPersistente> T = new List<TarjetaPersistente>();
                    LotePersistente L = new LotePersistente();
                    L.EstadoP = i.EstadoP;
                    L.EstadoT = i.EstadoT;
                    //L.FechaHoraImpPin = i.FechaHoraPin;
                    //L.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                    L.Id_Lote = i.Id_Lote;
                    //L.IdUsuarioPin = i.Id_UsuarioPin;
                    //L.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                    DataSet1.TLB_TarjetaDataTable TDT = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(i.Id_Lote);
                    foreach (DataSet1.TLB_TarjetaRow j in TDT.Rows)
                    {
                        TarjetaPersistente tar = new TarjetaPersistente();
                        tar.Apellidos = j.PrimerApellido;
                        tar.Estado = j.Estado;
                        tar.EstadoPin = j.EstadoPin;
                        tar.FechaOrdenImp = j.FechaOrdenImp;
                        tar.IdCliente = j.IdentificacionCliente;
                        tar.IdLote = j.Id_Lote;
                        tar.IdNumeroTarjeta = j.Id_NoTarjeta;
                        tar.Matriz.ID = j.Id_Matriz;
                        tar.NombrePropietario = j.Nombre;
                        tar.NoPin = j.No_Pin;
                        tar.NoSucursal = j.NoSucursal;
                        tar.Pais = j.Id_Pais;
                        tar.TipoIdentificacion = j.TipoIdentificacion;
                        T.Add(tar);
                    }
                    L.Tarjetas = T;
                    LLOTE.Add(L);
                }
                return LLOTE;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        //Actualizar datos en el registro de el/los lotes que se seleccionaron para imprimir.
        //Poner como estado Impreso (I)
        public bool ActualizarCamposLoteOrdenImp(int idLote, string idUsuarioOperadora, DateTime dtValor)
        {

            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 = new DataSet1();
            lote.Fill(ds1.TLB_Lote);

            bool result = false;

            DataSet1.TLB_LoteRow tmp = ds1.TLB_Lote.FindById_Lote(idLote);

            if (tmp != null)
            {
                tmp.EstadoT = "I";
                tmp.FechaHoraTarjeta = dtValor;
                tmp.Id_UsuarioTarjeta = idUsuarioOperadora;

                lote.Update(ds1.TLB_Lote);

                result = true;
            }

            return result;
        }
        //********************************************************************************************************
        public bool ActualizarPinEnLote(int idLote, string idUsuarioPin, DateTime dtValor)
        {
            try
            {
                DataSet1.TLB_LoteDataTable LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().GetData();
                DataSet1.TLB_LoteRow LROW = LDT.FindById_Lote(idLote);
                LROW.EstadoP = "I";
                LROW.FechaHoraPin = dtValor;
                LROW.Id_UsuarioPin = idUsuarioPin;
                new DataSet1TableAdapters.TLB_LoteTableAdapter().Update(LDT);
                return true;
            }
            catch (Exception e)
            {
                ///*escribir en el log*/

                //string path = @"C:\Logs_Telebanca\log_error.txt";

                //using (TextWriter writer = File.AppendText(path))
                //{
                //    string separador = " : ";
                //    string metodo_error = "ActualizarPinEnLote: \n"+"Lote: "+idLote.ToString()+"\n"+"Usuario-Pin: "+idUsuarioPin+"\n";
                //    string nombre_proyecto = "(DataAccessLayer): ";
                //    string date = DateTime.Now.ToString() + " \n";
                //    string separa = "-------------------------------------------------------";
                //    writer.WriteLine(date + separador + nombre_proyecto + metodo_error + " Error: " + e.Message + separa);
                //}

                return false;
                throw new Exception("", e);
            }
        }

        public LotePersistente ObtenerLoteDadoIdLote(int idLote)
        {
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 = new DataSet1();

            ds1.Merge(lote.ObtenerLoteDadoIdLote(idLote));

            LotePersistente result = new LotePersistente();

            foreach (DataSet1.TLB_LoteRow i in ds1.TLB_Lote)
            {
                result.Id_Lote = i.Id_Lote;
                result.EstadoP = i.EstadoP;
                result.EstadoT = i.EstadoT;
                DateTime a = DateTime.Today;
                try
                {
                    result.FechaHoraImpPin = i.FechaHoraPin;
                    result.IdUsuarioPin = i.Id_UsuarioPin;
                }
                catch
                {
                    try
                    {
                        result.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                        result.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                    }
                    catch
                    {
                        return result;
                    }
                    return result;
                }
            }
            return result;
        }
//-------------------CU_Realizar Reportes INICIO--------------------------------
        public List<LotePersistente> ObtenerLotesDadoEstadoPin(string estadoP)
        {
            List<LotePersistente> LL = new List<LotePersistente>();
            try
            {
                DataSet1.TLB_LoteDataTable LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().GetLotesEstadoP(estadoP);
                foreach (DataSet1.TLB_LoteRow i in LDT.Rows)
                {
                    try
                    {
                        List<TarjetaPersistente> LT = new List<TarjetaPersistente>();
                        LotePersistente L = new LotePersistente();
                        try
                        {
                            L.EstadoP = i.EstadoP;
                        }
                        catch (Exception)
                        { L.EstadoP = ""; }
                        try
                        {
                            L.EstadoT = i.EstadoT;
                        }
                        catch (Exception)
                        { L.EstadoT = ""; }
                        try
                        {
                            L.FechaHoraImpPin = i.FechaHoraPin;
                        }
                        catch (Exception)
                        {
                            L.FechaHoraImpPin = DateTime.Now;
                        }
                        try
                        {
                            L.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                        }
                        catch (Exception)
                        {
                            L.FechaHoraImpTarjetas = DateTime.Now;
                        }
                        try
                        {
                            L.Id_Lote = i.Id_Lote;
                        }
                        catch (Exception)
                        { L.Id_Lote = -1; }
                        try
                        {
                            L.IdUsuarioPin = i.Id_UsuarioPin;
                        }
                        catch (Exception)
                        { L.IdUsuarioPin = ""; }
                        try
                        {
                            L.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                        }
                        catch (Exception)
                        {
                            L.IdUsuarioTarjeta = "";
                        }
                        DataSet1.TLB_TarjetaDataTable TDT = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(i.Id_Lote);
                        foreach (DataSet1.TLB_TarjetaRow j in TDT.Rows)
                        {

                            TarjetaPersistente T = new TarjetaPersistente();
                            try
                            {
                                T.Apellidos = j.PrimerApellido;
                            }
                            catch (Exception)
                            {
                                T.Apellidos = "";
                            }
                            try
                            {
                                T.Estado = j.Estado;
                            }
                            catch (Exception)
                            {
                                T.Estado = "";
                            }
                            try
                            {
                                T.EstadoPin = j.EstadoPin;
                            }
                            catch (Exception)
                            {
                                T.EstadoPin = "";
                            }
                            try
                            {
                                T.FechaOrdenImp = j.FechaOrdenImp;
                            }
                            catch (Exception)
                            {
                                T.FechaOrdenImp = DateTime.Now;
                            }
                            try
                            {
                                T.IdCliente = j.IdentificacionCliente;
                            }
                            catch (Exception)
                            {
                                T.IdCliente = "";
                            }
                            try
                            {
                                T.IdLote = j.Id_Lote;
                            }
                            catch (Exception)
                            {
                                T.IdLote = -1;
                            }
                            try
                            {
                                T.IdNumeroTarjeta = j.Id_NoTarjeta;
                            }
                            catch (Exception)
                            {
                                T.IdNumeroTarjeta = "";
                            }
                            try
                            {
                                Matriz c = new Matriz();
                                c.ID = j.Id_Matriz;
                                T.Matriz = c;
                            }
                            catch (Exception)
                            {
                                Matriz c = new Matriz();
                                c.ID = 0;
                                T.Matriz = null;
                            }
                            try
                            {
                                T.NombrePropietario = j.Nombre;
                            }
                            catch (Exception)
                            {
                                T.NombrePropietario = "";
                            }
                            try
                            {
                                T.NoPin = j.No_Pin;
                            }
                            catch (Exception)
                            {
                                T.NoPin = "";
                            }
                            try
                            {
                                T.NoSucursal = j.NoSucursal;
                            }
                            catch (Exception)
                            {
                                T.NoSucursal = "";
                            }
                            try
                            {
                                T.Pais = j.Id_Pais;
                            }
                            catch (Exception)
                            {
                                T.Pais = "";
                            }
                            try
                            {
                                T.TipoIdentificacion = j.TipoIdentificacion;
                            }
                            catch (Exception)
                            {
                                T.TipoIdentificacion = "";
                            }
                            LT.Add(T);

                        }
                        L.Tarjetas = LT;
                        LL.Add(L);
                    }
                    catch (Exception)
                    { }
                }               
                return LL;
            }
            catch (Exception)
            {                
                throw;
            }   
        }
        //*****************************************************************************
        public List<LotePersistente> ObtenerLotesEstadoPinFinDadoFecha(string estado, DateTime f)
        {
            List<LotePersistente> LL = new List<LotePersistente>();
            try
            {
                DataSet1.TLB_LoteDataTable LDT = new DataSet1.TLB_LoteDataTable();
                if (estado == "F")
                {
                    DateTime fini = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
                    DateTime ffin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59);
                    LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().ObtenerLotesEstadoPDadoFecha(estado, fini, ffin);
                }
                else
                {
                    LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().GetLotesEstadoP(estado);
                }
                foreach (DataSet1.TLB_LoteRow i in LDT.Rows)
                {

                    try
                    {
                        List<TarjetaPersistente> LT = new List<TarjetaPersistente>();
                        LotePersistente L = new LotePersistente();

                        try
                        {
                            L.EstadoP = i.EstadoP;
                        }
                        catch
                        {
                            L.EstadoP = "";
                        }
                        try
                        {
                            L.EstadoT = i.EstadoT;
                        }
                        catch
                        {
                            L.EstadoT = "";
                        }
                        try
                        {
                            L.FechaHoraImpPin = i.FechaHoraPin;
                        }
                        catch
                        {
                            L.FechaHoraImpPin = DateTime.Now;
                        }
                        try
                        {
                            L.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                        }
                        catch
                        {
                            L.FechaHoraImpTarjetas = DateTime.Now;
                        }
                        try
                        {
                            L.Id_Lote = i.Id_Lote;
                        }
                        catch
                        {
                            L.Id_Lote = -1;
                        }
                        try
                        {
                            L.IdUsuarioPin = i.Id_UsuarioPin;
                        }
                        catch
                        {
                            L.IdUsuarioPin = "";
                        }
                        try
                        {
                            L.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                        }
                        catch
                        {
                            L.IdUsuarioTarjeta = "";
                        }

                        DataSet1.TLB_TarjetaDataTable TDT = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(i.Id_Lote);
                        foreach (DataSet1.TLB_TarjetaRow j in TDT.Rows)
                        {

                            TarjetaPersistente T = new TarjetaPersistente();
                            try
                            {
                                T.Apellidos = j.PrimerApellido;
                            }catch
                            {
                                T.Apellidos = "";
                            }
                            try
                            {
                                T.Estado = j.Estado;
                            }
                            catch
                            {
                                T.Estado = "";
                            }
                            try
                            {
                                T.EstadoPin = j.EstadoPin;
                            }
                            catch
                            { T.EstadoPin = "";
                            }
                            try
                            {
                                T.FechaOrdenImp = j.FechaOrdenImp;
                            }
                            catch
                            { T.FechaOrdenImp = DateTime.Now;
                            }
                            try
                            {
                                T.IdCliente = j.IdentificacionCliente;
                            }
                            catch
                            {
                                T.IdCliente = "";
                            }
                            try
                            {
                                T.IdLote = j.Id_Lote;
                            }
                            catch
                            {
                                T.IdLote = -1;
                            }
                            try
                            {
                                T.IdNumeroTarjeta = j.Id_NoTarjeta;
                            }
                            catch
                            {
                                T.IdNumeroTarjeta = "";
                            }
                            try
                            {
                            Matriz c = new Matriz();
                            c.ID = j.Id_Matriz;
                            T.Matriz = c;
                        }
                        catch
                        {
                            Matriz c = new Matriz();
                            c.ID = 0;
                            T.Matriz = c;
                        }
                        try
                        {
                            T.NombrePropietario = j.Nombre;
                        }
                        catch
                        {
                            T.NombrePropietario = "";
                        }
                        try
                        {
                            T.NoPin = j.No_Pin;
                        }
                        catch
                        {
                            T.NoPin = "";
                        }
                        try
                        {
                            T.NoSucursal = j.NoSucursal;
                        }
                        catch
                        {
                            T.NoSucursal = "";
                        }
                        try
                        {
                            T.Pais = j.Id_Pais;
                        }
                        catch
                        {
                            T.Pais = "";
                        }
                        try
                        {
                            T.TipoIdentificacion = j.TipoIdentificacion;
                        }
                        catch
                        {
                            T.TipoIdentificacion = "";
                        }
                            LT.Add(T);
                        }

                        L.Tarjetas = LT;
                        LL.Add(L);
                    }
                    catch
                    {
                    }
                       
                    }
                    return LL;
              
            }
            catch (Exception)
            {                
                throw;
            }        
        }
        //*******************************************************************************
        public List<LotePersistente> ObtenerLotesEstadoTFinDadoFecha(string estado, DateTime f)
        {
            List<LotePersistente> LL = new List<LotePersistente>();
            try
            {
                DataSet1.TLB_LoteDataTable LDT = new DataSet1.TLB_LoteDataTable();
                if (estado == "F")
                {
                    DateTime fini = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
                    DateTime ffin = new DateTime(f.Year, f.Month, f.Day, 23, 59, 59);
                    LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().obtenerLotesEstadoTDadoFecha(estado, fini, ffin);
                }
                else
                {
                    LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().GetLotesPorEstadoT(estado);
                }
                foreach (DataSet1.TLB_LoteRow i in LDT.Rows)
                {
                    try
                    {

                        List<TarjetaPersistente> LT = new List<TarjetaPersistente>();
                        LotePersistente L = new LotePersistente();
                        try
                        {
                            L.EstadoP = i.EstadoP;
                        }
                        catch
                        {
                            L.EstadoP = "";
                        }
                        try
                        {
                            L.EstadoT = i.EstadoT;
                        }
                        catch
                        {
                            L.EstadoT = "";
                        }
                        try
                        {
                            L.FechaHoraImpPin = i.FechaHoraPin;
                        }
                        catch
                        {
                            L.FechaHoraImpPin = DateTime.Now;
                        }
                        try
                        {
                            L.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                        }
                        catch
                        {
                            L.FechaHoraImpTarjetas = DateTime.Now;
                        }
                        try
                        {
                            L.Id_Lote = i.Id_Lote;
                        }
                        catch
                        {
                            L.Id_Lote = -1;
                        }
                        try
                        {
                            L.IdUsuarioPin = i.Id_UsuarioPin;
                        }
                        catch
                        {
                            L.IdUsuarioPin = "";
                        }
                        try
                        {
                            L.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                        }
                        catch
                        {
                            L.IdUsuarioTarjeta = "";
                        }
                        DataSet1.TLB_TarjetaDataTable TDT = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(i.Id_Lote);
                        foreach (DataSet1.TLB_TarjetaRow j in TDT.Rows)
                        {
                           
                                TarjetaPersistente T = new TarjetaPersistente();
                                try
                                {
                                    T.Apellidos = j.PrimerApellido;
                                }
                                catch
                                {
                                    T.Apellidos = "";
                                }
                                 try
                                {
                                T.Estado = j.Estado;
                                }
                               catch 
                                 {
                                     T.Estado = "";
                                 }
                                try
                                {
                                T.EstadoPin = j.EstadoPin;
                                }
                               catch
                                {
                                    T.EstadoPin = "";
                                }
                               try
                                {
                                T.FechaOrdenImp = j.FechaOrdenImp;
                                }
                                catch
                                {
                                    T.FechaOrdenImp = DateTime.Now;
                                }
                               try
                                {
                                T.IdCliente = j.IdentificacionCliente;
                                }  
                                catch
                                {
                                    T.IdCliente = "";
                                }
                                try
                                {
                                T.IdLote = j.Id_Lote;
                                }
                               catch
                               {
                                   T.IdLote = -1;
                               }
                                try
                                {
                                T.IdNumeroTarjeta = j.Id_NoTarjeta;
                               }
                               catch
                                {
                                    T.IdNumeroTarjeta = "";
                                }
                                try
                                {
                                Matriz c = new Matriz();
                                c.ID = j.Id_Matriz;
                                T.Matriz = c;
                               }
                               catch
                                {
                                    Matriz c = new Matriz();
                                    c.ID = 0;
                                    T.Matriz = null;
                                }                               
                                try
                                {
                                T.NombrePropietario = j.Nombre;
                                }
                                catch (Exception)
                                {
                                    T.NombrePropietario = "";
                                }
                                try
                                {
                                T.NoPin = j.No_Pin;
                                }
                                catch (Exception)
                                {
                                    T.NoPin = "";
                                }
                                try
                                {
                                T.NoSucursal = j.NoSucursal;
                                }
                                catch (Exception)
                                {
                                    T.NoSucursal = "";
                                }
                                try
                                {
                                T.Pais = j.Id_Pais;
                                }
                                catch (Exception)
                                {
                                    T.Pais = "";
                                }
                               try
                                {
                                T.TipoIdentificacion = j.TipoIdentificacion;
                                 }
                               catch (Exception)
                               {
                                   T.TipoIdentificacion = "";
                               }
                                LT.Add(T);
                            
                        }
                        L.Tarjetas = LT;
                        LL.Add(L);
                    }
                    catch (Exception)
                    { 
                    }
                }
                return LL;
            }
            catch (Exception)
            {
                throw;
            }        
        }

        //***************************************************************************
        public List<LotePersistente> ObtenerLotesDadoEstadoT(string estadoT)
        {
            DataSet1.TLB_LoteDataTable LDT = new DataSet1TableAdapters.TLB_LoteTableAdapter().GetLotesPorEstadoT(estadoT);
            List<LotePersistente> lista = new List<LotePersistente>();
           
                foreach (DataSet1.TLB_LoteRow i in LDT)
                {
                    try
                   {
                    LotePersistente lote = new LotePersistente();
                    try
                    {
                        lote.EstadoP = i.EstadoP;
                    }
                    catch
                    {
                        lote.EstadoP = "";
                    }
                    try
                    {
                        lote.EstadoT = i.EstadoT;
                    }
                    catch
                    {
                        lote.EstadoT = "";
                    }
                    try
                    {
                        lote.FechaHoraImpPin = i.FechaHoraPin;
                    }
                    catch
                    {
                        lote.FechaHoraImpPin = DateTime.Now;
                    }
                    try
                    {
                        lote.FechaHoraImpTarjetas = i.FechaHoraTarjeta;
                    }
                    catch
                    {
                        lote.FechaHoraImpTarjetas = DateTime.Now;
                    }
                    try
                    {
                        lote.Id_Lote = i.Id_Lote;
                    }
                    catch
                    {
                        lote.Id_Lote = -1;
                    }
                    try
                    {
                        lote.IdUsuarioPin = i.Id_UsuarioPin;
                    }
                    catch
                    {
                        lote.IdUsuarioPin = "";
                    }
                    try
                    {
                        lote.IdUsuarioTarjeta = i.Id_UsuarioTarjeta;
                    }
                    catch
                    {
                        lote.IdUsuarioTarjeta = "";
                    }
                    DataSet1.TLB_TarjetaDataTable TDT = new DataSet1TableAdapters.TLB_TarjetaTableAdapter().GetTarjetasPorLote(i.Id_Lote);
                    List<TarjetaPersistente> lt = new List<TarjetaPersistente>();
                    foreach (DataSet1.TLB_TarjetaRow j in TDT)
                    {
                        TarjetaPersistente tp = new TarjetaPersistente();
                        try{
                         tp.Estado = j.Estado;
                        }
                        catch(Exception)
                        {
                            tp.Estado="";
                        }
                        try{
                            tp.EstadoPin = j.EstadoPin;
                        }
                        catch
                        { 
                            tp.EstadoPin = ""; 
                        }
                        try
                        {                        
                        tp.IdCliente = j.IdentificacionCliente;
                        }
                        catch
                        {
                            tp.IdCliente = "";                        
                        }
                        try
                        {
                            tp.IdNumeroTarjeta = j.Id_NoTarjeta;
                        }
                        catch
                        {
                            tp.IdNumeroTarjeta = "";
                        }
                        try
                        {
                        tp.Matriz.ID = j.Id_Matriz;
                        }
                        catch
                        {
                            tp.Matriz.ID = -1;
                        }
                        try
                        {
                        tp.NombrePropietario = j.Nombre;
                        }
                        catch
                        {
                            tp.NombrePropietario = "";
                        }
                        try{
                        tp.NoPin = j.No_Pin;
                            }
                        catch
                        {
                            tp.NoPin = "";
                        }
                        try{
                        tp.NoSucursal = j.NoSucursal;
                            }
                        catch
                        {
                            tp.NoSucursal = "";
                        }
                        try{
                        tp.Pais = j.Id_Pais;
                            }
                        catch
                        {
                            tp.Pais = "";
                        }
                        try{
                        tp.Apellidos = j.PrimerApellido;
                            }
                        catch                
                        {
                            tp.Apellidos = "";
                        }
                        try{
                        tp.TipoIdentificacion = j.TipoIdentificacion;
                            }
                        catch
                        {
                            tp.TipoIdentificacion = "";
                        }
                        try
                        { 
                            tp.IdLote = j.Id_Lote; 
                        }
                        catch 
                        { 
                            tp.IdLote = -1;
                        }
                        lt.Add(tp);
                    }
                    lote.Tarjetas = lt;
                    lista.Add(lote);
                    }
                 catch(Exception)
                 {}
                }
                return lista;
            
        }
//--------------CU_REALIZAR REPORTES FIN--------------------------------
        //Actualizar lotes que tengan estadoT “Impreso” y cambiar por “Finalizado” (F)
        public bool ActualizarCamposLoteFinalizar(int idLote)
        {
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 = new DataSet1();
            lote.Fill(ds1.TLB_Lote);

            bool result = false;

            DataSet1.TLB_LoteRow tmp = ds1.TLB_Lote.FindById_Lote(idLote);

            if (tmp != null)
            {
                tmp.EstadoT = "F";
                lote.Update(ds1.TLB_Lote);

                result = true;
            }

            return result;
        }



        public List<LotePersistente> BuscarLoteFechaHoraPinVacia()
        {
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 =  new DataSet1();

            ds1.Merge(lote.BuscarLoteFechaHoraPinVacia());
            List<LotePersistente> result =  new List<LotePersistente>();
            
            foreach(DataSet1.TLB_LoteRow i in ds1.TLB_Lote)
            {
                result.Add(new LotePersistente(i.Id_Lote,i.Id_UsuarioTarjeta,i.FechaHoraTarjeta,i.FechaHoraPin,i.Id_UsuarioPin,i.EstadoP,i.EstadoT));
                
            }
            return result;

        }

        public List<LotePersistente> BuscarLoteFechaImpPinLLena()
        {
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 = new DataSet1();

            ds1.Merge(lote.BuscarLoteFechaHoraPinLlena());
            List<LotePersistente> result = new List<LotePersistente>();

            foreach (DataSet1.TLB_LoteRow i in ds1.TLB_Lote)
            {
                result.Add(new LotePersistente(i.Id_Lote, i.Id_UsuarioTarjeta, i.FechaHoraTarjeta, i.FechaHoraPin, i.Id_UsuarioPin,i.EstadoP,i.EstadoT));

            }
            return result; 
        }





        public ReporteContenido LoteContenido(int idLote)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();
            tarjeta.Fill(ds1.TLB_Tarjeta);

            ReporteContenido result = new ReporteContenido();

            foreach(DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta)
            {
                if (i.Id_Lote == idLote)
                {
                   
                    result.NroTarjeta= i.Id_NoTarjeta;
                    result.TipoIdentificacion = i.IdentificacionCliente; 
                    result.NombrePropietario = i.Nombre;
                    result.PrimerApellido = i.PrimerApellido;                    
                }
            }

            return result;
        }


        public ReporteContenido ReporteContenido(int idLote)
        {

            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            tarjeta.Fill(ds1.TLB_Tarjeta);

            ReporteContenido result = new ReporteContenido(); 

            foreach (DataSet1.TLB_TarjetaRow i in ds1.TLB_Tarjeta.Rows)
            {
                if (i.Id_Lote == idLote)
                {
                    result.NroTarjeta = i.Id_NoTarjeta;
                    result.TipoIdentificacion = i.TipoIdentificacion;
                    result.NombrePropietario = i.Nombre;
                    result.PrimerApellido = i.PrimerApellido;
                    result.NumeroSucursal = i.TLB_SucursalRow.NoSucursal;
                    result.Banco = i.Id_NoTarjeta.Substring(0, 2);

                    return result; 
                }
            }
            return result;           

        }
               

        //Comprueba en la tabla Lote si existe alguno dado el usuario y la fecha/hora
        public bool ExisteLote(string idUsuario, DateTime dtValor)
        {
            DataSet1TableAdapters.TLB_LoteTableAdapter lote = new DataAccessLayer.DataSet1TableAdapters.TLB_LoteTableAdapter();
            DataSet1 ds1 = new DataSet1();

            lote.Fill(ds1.TLB_Lote);

            foreach (DataSet1.TLB_LoteRow i in ds1.TLB_Lote.Rows)
                if ((i.Id_UsuarioTarjeta == idUsuario) && (i.FechaHoraTarjeta == dtValor))
                    return true;

            return false;
        }

        public int InsertarLote(LotePersistente lote)
        {
            DataSet1.TLB_LoteDataTable tlbLote = new DataSet1.TLB_LoteDataTable();
            DataSet1.TLB_LoteRow loterow = tlbLote.NewTLB_LoteRow();
            loterow.EstadoP = lote.EstadoP;
            loterow.EstadoT = lote.EstadoT;
            //loterow.FechaHoraPin = DBNull.Value;
            //loterow.FechaHoraTarjeta = DBNull.Value;

            //loterow.Id_UsuarioPin = lote.IdUsuarioPin;
            //loterow.Id_UsuarioTarjeta = lote.IdUsuarioTarjeta;
            tlbLote.AddTLB_LoteRow(loterow);
            new DataSet1TableAdapters.TLB_LoteTableAdapter().Update(tlbLote);
            return loterow.Id_Lote;
        }

        public List<LotePersistente> LotesDadoIntervalo(DateTime fechI, DateTime fechF)
        {
            throw new NotImplementedException();
        }


        //obtener la cantidad de tarjetas que tiene un lote
        public int LoteCantidadTarjeta(int idlote)
        {
            DataSet1TableAdapters.TLB_TarjetaTableAdapter tarjeta = new DataAccessLayer.DataSet1TableAdapters.TLB_TarjetaTableAdapter();
            DataSet1 ds1 = new DataSet1();

            tarjeta.Fill(ds1.TLB_Tarjeta);

            return (int)tarjeta.CantTarjetasDeLote(idlote);

        }




        public string BuscarNombreSucursalDadoNumero(string NoSucursal)
        {

            DataSet1TableAdapters.TLB_SucursalTableAdapter sucursal = new DataAccessLayer.DataSet1TableAdapters.TLB_SucursalTableAdapter();
            DataSet1 ds1 = new DataSet1();

            sucursal.Fill(ds1.TLB_Sucursal);

            DataSet1.TLB_SucursalRow sucursalRow = ds1.TLB_Sucursal.FindByNoSucursal(NoSucursal);
            if (sucursalRow != null)
                return sucursalRow.Nombre;
            else
                return "NoEncontrada";

        }

        public string ObtenerNoSucursalDadoNombreSucursal(string nombreSucursal)
        {
            DataSet1TableAdapters.TLB_SucursalTableAdapter sucursal = new DataAccessLayer.DataSet1TableAdapters.TLB_SucursalTableAdapter();
            DataSet1 ds1 = new DataSet1();

            sucursal.Fill(ds1.TLB_Sucursal);
            string numero = "NoEncontrado";

            foreach (DataSet1.TLB_SucursalRow i in ds1.TLB_Sucursal.Rows)
            {
                if (i.Nombre == nombreSucursal)
                    numero = i.NoSucursal;

            }
            return numero;
        }

        /************* FIN ***************** MODULO AUTENTICACION ****************** FIN *******************/

       /*------INICIO----------MODULO SERVICIO DE INFORMACION------INICIO----------------*/

      
        public bool InsertarInformacion(InformacionPersistente Informacion)
        {

            DataSet1TableAdapters.TLB_TemaTableAdapter tema = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter TPalabra = new DataAccessLayer.DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_PalabraClaveTableAdapter palabra = new DataAccessLayer.DataSet1TableAdapters.TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_RelacionTemasTableAdapter RelacTema = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionTemasTableAdapter();


            DataSet1 ds1 = new DataSet1();

            tema.Fill(ds1.TLB_Tema);
            palabra.Fill(ds1.TLB_PalabraClave);
            TPalabra.Fill(ds1.TLB_Tema_TLB_PalabraClave);
            RelacTema.Fill(ds1.TLB_RelacionTemas);

            
            
            DataSet1.TLB_TemaDataTable temTable = tema.DatosTema(Informacion.Tema);
            DataSet1.TLB_TemaRow temaNuevo = ds1.TLB_Tema.NewTLB_TemaRow();

            DataSet1.TLB_RelacionTemasRow RelacTemaRow = ds1.TLB_RelacionTemas.NewTLB_RelacionTemasRow();
            bool insertado = false;
            bool agregado = false;

            if (temTable.Count == 0)
            {
                temaNuevo.Descripcion = Informacion.Texto;
                temaNuevo.Tema = Informacion.Tema;
                ds1.TLB_Tema.AddTLB_TemaRow(temaNuevo);
                tema.Update(ds1.TLB_Tema);

                DataSet1.TLB_TemaDataTable temaTable = tema.DatosTema(Informacion.Tema);

                //agregando el Tema y Super Tema(Tema Padre) en la Tabla RelacionTema
                if (Informacion.TemaPadre != 0)
                {
                    RelacTemaRow.SuperTema = Informacion.TemaPadre;
                    RelacTemaRow.SubTema = temaTable[0].Id_Tema;
                    ds1.TLB_RelacionTemas.AddTLB_RelacionTemasRow(RelacTemaRow);
                    RelacTema.Update(ds1.TLB_RelacionTemas);
                                        
                }
                insertado = true;
            }
            

                foreach (string i in Informacion.PalabrasClaves)
                {
                    DataSet1.TLB_PalabraClaveDataTable palClavTable = palabra.BuscarPalabraClave(i);
                    DataSet1.TLB_PalabraClaveRow nuevaPalabra = ds1.TLB_PalabraClave.NewTLB_PalabraClaveRow();
                    
                    if (palClavTable.Count == 0)
                    {
                        nuevaPalabra.Palabra = i;
                        ds1.TLB_PalabraClave.AddTLB_PalabraClaveRow(nuevaPalabra);
                        palabra.Update(ds1.TLB_PalabraClave);
                    }
                    DataSet1.TLB_Tema_TLB_PalabraClaveRow temaPalabra = ds1.TLB_Tema_TLB_PalabraClave.NewTLB_Tema_TLB_PalabraClaveRow();
                    DataSet1.TLB_TemaDataTable IdTemaTmp = tema.DatosTema(Informacion.Tema);

                    //actualizando la palabra a buscar
                    palClavTable = palabra.BuscarPalabraClave(i);


                        temaPalabra.Id_Tema = IdTemaTmp[0].Id_Tema; 
                        temaPalabra.Id_Palabra = palClavTable[0].Id_Palabra;
                        ds1.TLB_Tema_TLB_PalabraClave.AddTLB_Tema_TLB_PalabraClaveRow(temaPalabra);
                        TPalabra.Update(ds1.TLB_Tema_TLB_PalabraClave); 
                        
                    agregado = true;
                }

                if (insertado && agregado)
                    return true;
                else 
                    return false;

               
        }

      
        public bool ModificarInformacion(InformacionPersistente Informacion, int idTema)
        {
        
            DataSet1TableAdapters.TLB_TemaTableAdapter tema = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter TPalabra = new DataAccessLayer.DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_PalabraClaveTableAdapter palabra = new DataAccessLayer.DataSet1TableAdapters.TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_RelacionTemasTableAdapter RelacTema = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionTemasTableAdapter();


            DataSet1 ds1 = new DataSet1();

            tema.Fill(ds1.TLB_Tema);
            palabra.Fill(ds1.TLB_PalabraClave);
            TPalabra.Fill(ds1.TLB_Tema_TLB_PalabraClave);
            RelacTema.Fill(ds1.TLB_RelacionTemas);

            DataSet1.TLB_TemaDataTable temTable = tema.SeleccionarTema(idTema);
            DataSet1.TLB_RelacionTemasDataTable relaTemas = RelacTema.ObtenerSuperTemas(idTema);

            bool modificoTema=false, modifRelac=false, modifTemPadre= false;

            if (temTable.Count != 0)
            {
                temTable[0].Descripcion = Informacion.Texto;
                temTable[0].Tema = Informacion.Tema;
                new DataSet1TableAdapters.TLB_TemaTableAdapter().Update(temTable);
            
                modificoTema = true;
            }

            if (relaTemas.Count != 0)
            {
                if (Informacion.TemaPadre == 0)
                {
                    ///////////////////
                    // RelacTema DataSet1TableAdaer
                    RelacTema.Fill(ds1.TLB_RelacionTemas);
                    foreach (DataSet1.TLB_RelacionTemasRow i in ds1.TLB_RelacionTemas)
                        if (i.SubTema == idTema)
                            i.Delete();
                    RelacTema.Update(ds1.TLB_RelacionTemas);
                    //////////////////
                }
                else
                {
                    relaTemas[0].SuperTema = Informacion.TemaPadre;
                    new DataSet1TableAdapters.TLB_RelacionTemasTableAdapter().Update(relaTemas);
                    modifTemPadre = true;
                }
            }

          //  //borrando todas las tuplas de la relacion Tema-Palabra donde el IdTema sea el pasado
            DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter temaPalabrasClaves = new DataAccessLayer.DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter();
            temaPalabrasClaves.Fill(ds1.TLB_Tema_TLB_PalabraClave);

            foreach (DataSet1.TLB_Tema_TLB_PalabraClaveRow i in ds1.TLB_Tema_TLB_PalabraClave)
                if (i.Id_Tema == idTema)
                    i.Delete();

            temaPalabrasClaves.Update(ds1.TLB_Tema_TLB_PalabraClave);

            foreach (string i in Informacion.PalabrasClaves)
            {
                DataSet1.TLB_PalabraClaveDataTable palClavTable = palabra.BuscarPalabraClave(i);
                DataSet1.TLB_PalabraClaveRow palabClaveResult = ds1.TLB_PalabraClave.NewTLB_PalabraClaveRow();
                DataSet1.TLB_Tema_TLB_PalabraClaveRow temaPalabraClv = ds1.TLB_Tema_TLB_PalabraClave.NewTLB_Tema_TLB_PalabraClaveRow();

                if (palClavTable.Count == 0)
                 {
                    palabClaveResult.Palabra = i;
                    ds1.TLB_PalabraClave.AddTLB_PalabraClaveRow(palabClaveResult);
                    
                    //new DataSet1TableAdapters.TLB_PalabraClaveTableAdapter().Update(palClavTable);
                    palabra.Update(ds1.TLB_PalabraClave);

                    //vuelvo a mandar a buscar la palabra para tener su Id
                    palClavTable = palabra.BuscarPalabraClave(i);
                    if((int)TPalabra.EstanRelacionadosTemaPalabra(idTema,palClavTable[0].Id_Palabra) == 0)
                    {
                        temaPalabraClv.Id_Tema=idTema;
                        temaPalabraClv.Id_Palabra=palClavTable[0].Id_Palabra;
                        ds1.TLB_Tema_TLB_PalabraClave.AddTLB_Tema_TLB_PalabraClaveRow(temaPalabraClv);
                        //TPalabra.Update(ds1.TLB_Tema_TLB_PalabraClave);
                        new DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter().Update(ds1.TLB_Tema_TLB_PalabraClave);
                    }
                 }
                
                else
                    {
                        if ((int)TPalabra.EstanRelacionadosTemaPalabra(idTema, palClavTable[0].Id_Palabra) == 0)
                           {
                            temaPalabraClv.Id_Tema=idTema;
                            temaPalabraClv.Id_Palabra=palClavTable[0].Id_Palabra;
                            ds1.TLB_Tema_TLB_PalabraClave.AddTLB_Tema_TLB_PalabraClaveRow(temaPalabraClv);
                            new DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter().Update(ds1);
                            TPalabra.Update(ds1.TLB_Tema_TLB_PalabraClave);
                           }

                           palClavTable[0].Delete();
                    }
                
                modifRelac=true;

            }

            if (modificoTema && modifRelac && modifTemPadre)
                return true;
            else
                return false;                  
        }


        public List<InformacionPersistente> BuscarInformacionPorPalabraClave(string palabraClave)
        {
            DataSet1TableAdapters.TLB_TemaTableAdapter tema = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter TPalabra = new DataAccessLayer.DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_PalabraClaveTableAdapter palabra = new DataAccessLayer.DataSet1TableAdapters.TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_RelacionTemasTableAdapter RelacTema = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionTemasTableAdapter();


            DataSet1 ds1 = new DataSet1();

            tema.Fill(ds1.TLB_Tema);
            palabra.Fill(ds1.TLB_PalabraClave);
            TPalabra.Fill(ds1.TLB_Tema_TLB_PalabraClave);
            RelacTema.Fill(ds1.TLB_RelacionTemas);

            DataSet1.TLB_PalabraClaveDataTable palabraClvTable = palabra.BuscarPalabraClave(palabraClave);
            List<InformacionPersistente> result = new List<InformacionPersistente>();

            if (palabraClvTable.Count != 0)
            {
                DataSet1.TLB_TemaDataTable temaTable = tema.BuscarDatosDeTemasDadoPalabraClv(palabraClave);

                if (temaTable.Count != 0)
                {
                    foreach (DataSet1.TLB_TemaRow i in temaTable)
                    {
                        result.Add(MostrarDatosTema(i.Id_Tema.ToString()));
                    }
                }
            }

            return result;
        }
       


        //devuelve la informacion de cada tema que sea hijo del temaPadre pasado como parametro
        public List<InformacionPersistente> SubTemas(int IdTema)
        {
            DataSet1TableAdapters.TLB_TemaTableAdapter tema = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter TPalabra = new DataAccessLayer.DataSet1TableAdapters.TLB_Tema_TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_PalabraClaveTableAdapter palabra = new DataAccessLayer.DataSet1TableAdapters.TLB_PalabraClaveTableAdapter();
            DataSet1TableAdapters.TLB_RelacionTemasTableAdapter RelacTema = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionTemasTableAdapter();


            DataSet1 ds1 = new DataSet1();

            tema.Fill(ds1.TLB_Tema);
            palabra.Fill(ds1.TLB_PalabraClave);
            TPalabra.Fill(ds1.TLB_Tema_TLB_PalabraClave);
            RelacTema.Fill(ds1.TLB_RelacionTemas);

            List<InformacionPersistente> result = new List<InformacionPersistente>();

            DataSet1.TLB_RelacionTemasDataTable relacTemaTable = RelacTema.ObtenerSubTemas(IdTema);

            if (relacTemaTable.Count != 0)
            {
                foreach (DataSet1.TLB_RelacionTemasRow i in relacTemaTable)
                {
                    result.Add(MostrarDatosTema(i.SubTema.ToString()));
                }
            }


            return result;

        }

        
        //inserta en la tabla Usuario-Tema
        public bool InsertarRelacUsuarioTema(HistorialUsuarioTemaPersitente acceso)
        {
            DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter userTema = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter();
            DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();
            DataSet1TableAdapters.TLB_TemaTableAdapter tema = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();

            
            DataSet1 ds1 = new DataSet1();
            userTema.Fill(ds1.TLB_RelacionUserTema);
            usuario.Fill(ds1.TLB_Usuario);
            tema.Fill(ds1.TLB_Tema);

            DataSet1.TLB_RelacionUserTemaRow relacUserTemaRow = ds1.TLB_RelacionUserTema.NewTLB_RelacionUserTemaRow();

            DataSet1.TLB_UsuarioRow userRow = ds1.TLB_Usuario.FindByusuario(acceso.Usuario);
            DataSet1.TLB_TemaRow temaRow = ds1.TLB_Tema.FindById_Tema(acceso.IdTema);

            if (userRow != null && temaRow != null)
            {

                relacUserTemaRow.Fecha = acceso.Fecha;
                relacUserTemaRow.Id_Tema = acceso.IdTema;
                relacUserTemaRow.Id_Usuario = acceso.Usuario;

                ds1.TLB_RelacionUserTema.AddTLB_RelacionUserTemaRow(relacUserTemaRow);
                userTema.Update(ds1.TLB_RelacionUserTema);

                return true;
            }

            return false;
        }

       public bool InsertarAccionUsuario(AccionUsuarioPersistente accionUsuario)
        {
            try
            {
                //DataSet1TableAdapters.TLB_AccionesUsuarioTableAdapter accionUser = new DataAccessLayer.DataSet1TableAdapters.TLB_AccionesUsuarioTableAdapter();
                //DataSet1TableAdapters.TLB_UsuarioTableAdapter usuario = new DataAccessLayer.DataSet1TableAdapters.TLB_UsuarioTableAdapter();
                //DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter funcionalidad = new DataAccessLayer.DataSet1TableAdapters.TLB_FuncionalidadesTableAdapter();

                //DataSet1 ds1 = new DataSet1();

                //accionUser.Fill(ds1.TLB_AccionesUsuario);
                //usuario.Fill(ds1.TLB_Usuario);
                //funcionalidad.Fill(ds1.TLB_Funcionalidades);

                //DataSet1.TLB_UsuarioRow userRow = ds1.TLB_Usuario.FindByusuario(accionUsuario.Usuario);
                //DataSet1.TLB_FuncionalidadesRow funcRow = ds1.TLB_Funcionalidades.FindByFuncionalidad(accionUsuario.Funcionalidad);

                //DataSet1.TLB_AccionesUsuarioRow accUserInsert = ds1.TLB_AccionesUsuario.NewTLB_AccionesUsuarioRow();

                //if (userRow != null && funcRow != null)
                //{

                //    accUserInsert.Descripcion = "";
                //    foreach (string i in accionUsuario.Descripcion)
                //    {
                //        accUserInsert.Descripcion += "/" + i;
                //    }

                //    accUserInsert.Fecha = accionUsuario.Fecha;
                //    accUserInsert.Funcionalidad = accionUsuario.Funcionalidad;
                //    accUserInsert.Usuario = accionUsuario.Usuario;

                //    ds1.TLB_AccionesUsuario.AddTLB_AccionesUsuarioRow(accUserInsert);
                    //accionUser.Update(ds1.TLB_AccionesUsuario);
                    //llamar a nueva funcion para insertar a accion de usuario
                    InsertAccUsuario(accionUsuario);
                    //**********************************************************

                    return true;
                //}

                //return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        //*********************NEW Update para insertar accion de usuario***********
        public void InsertAccUsuario(AccionUsuarioPersistente accionUsuario)
        {
            string StringConection = DataAccessLayer.Properties.Settings.Default.TeleBancaConnectionString;
            SqlConnection myConection = new SqlConnection(StringConection);

            string Descripcion = "";
            foreach (string i in accionUsuario.Descripcion)
            {
                Descripcion += "/" + i;
            }
            string formato_fecha = "SET DATEFORMAT YMD ";
            string sSQL = formato_fecha+"insert Into TLB_AccionesUsuario (Usuario, Funcionalidad, Fecha, Descripcion)";
            sSQL = sSQL + " values ('" + accionUsuario.Usuario + "','" +accionUsuario.Funcionalidad + "','"+accionUsuario.Fecha+"','"+Descripcion+"')";
            SqlCommand mycommand = new SqlCommand(sSQL, myConection);


            try
            {
                myConection.Open();
                mycommand.ExecuteNonQuery();
            }
            catch (Exception excp)
            {
                throw excp;
            }
            finally
            {
                myConection.Close();
            }
        }   
        //**************************************************************************

        /*------FIN----------MODULO SERVICIO DE INFORMACION------FIN----------------*/





    }
}