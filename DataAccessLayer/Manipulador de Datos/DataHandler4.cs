using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;



using System.Collections;
using System.Timers;


namespace DataAccessLayer
{ 
    public partial class DataHandler
    {
        
        #region MOD_INFORMACION

        //Ver a Pedro para la implementación...
        public List<InformeConsultas> ReporteConsultasAE(DateTime pFechaI, DateTime pFechaF) 
        {
            List<InformeConsultas> Result = new List<InformeConsultas>();

            DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter TempTA = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
            DataSet1 TempDS = new DataSet1();

            TempTA.ObtenerEntreFechas(TempDS.TLB_RelacionUserEntid, pFechaI, pFechaF);

            foreach (DataSet1.TLB_RelacionUserEntidRow i in TempDS.TLB_RelacionUserEntid)
            {
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Nombre de la Entidad", i.NombreC));
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Código de la Entidad", i.Cod_Entidad));
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Código Anterior de la Entidad", i.CodAntSucursal));
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Sitio Web", i.SitioWeb));
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Correo Electrónico", i.CorreoElectronico));
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Teléfono", i.Telefono));
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Fax", i.Fax));
                Result.Add(new InformeConsultas("", i.Fecha, i.Nombre, "Dirección", i.Direccion));
            }
            return Result;
        }

        //Ver a Pedro para la implementación...
        public List<InformeConsultas> ReporteConsultasIP(DateTime pFechaI, DateTime pFechaF)
        {
            //throw new NotImplementedException();
            List<InformeConsultas> Result = new List<InformeConsultas>();

            DataSet1TableAdapters.TLB_TemaTableAdapter TempTemaTA = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter TempTA = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter();
            DataSet1 TempDS = new DataSet1();

            TempTemaTA.Fill(TempDS.TLB_Tema);
            TempTA.ObtenerEntreFechas(TempDS.TLB_RelacionUserTema, pFechaI, pFechaF);
          
            foreach (DataSet1.TLB_RelacionUserTemaRow i in TempDS.TLB_RelacionUserTema)
            {
                Result.Add(new InformeConsultas("", i.Fecha, i.Id_Usuario, i.TLB_TemaRow.Tema, i.Contador));
            }
            return Result;            
        }

        //Ver a Pedro para la implementación...
        public List<DatosAgenda> ReportePersonalDetalladoAE(DateTime pFechaI, DateTime pFechaF, string pId_Operadora)
        {
            List<DatosAgenda> Result = new List<DatosAgenda>();
            DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter TempTA = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
            DataSet1 TempDS = new DataSet1();

            TempTA.Obtener_PersonalDetalladoAE(TempDS.TLB_RelacionUserEntid, pFechaI, pFechaF, pId_Operadora);

            foreach (DataSet1.TLB_RelacionUserEntidRow i in TempDS.TLB_RelacionUserEntid)
                Result.Add(new DatosAgenda("",i.Fecha,i.Id_Usuario,i.Nombre,i.Cod_Entidad,i.CodAntSucursal,i.NombreC,
                    i.Direccion,i.Fax,i.Telefono,i.CorreoElectronico,i.SitioWeb));
            return Result;
        }

        //Ver a Pedro para la implementación...
        public List<DatosProcesos> ReportePersonalDetalladoIP(DateTime pFechaI, DateTime pFechaF, string pId_Operadora)
        {
            //throw new NotImplementedException();
            List<DatosProcesos> Result = new List<DatosProcesos>();

            DataSet1TableAdapters.TLB_TemaTableAdapter TempTemaTA = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter TempTA = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter();
            DataSet1 TempDS = new DataSet1();

            TempTemaTA.Fill(TempDS.TLB_Tema);
            TempTA.Obtener_PersonalDetalladoIP(TempDS.TLB_RelacionUserTema, pFechaI, pFechaF, pId_Operadora);

            foreach (DataSet1.TLB_RelacionUserTemaRow i in TempDS.TLB_RelacionUserTema)
                Result.Add(new DatosProcesos("", i.Fecha, i.Id_Usuario, i.TLB_TemaRow.Tema, i.Contador));
            return Result;
        }       

        //Ver a Pedro para la implementación...
        public List<DatosAgenda> ReporteGeneralDetalladoAE(DateTime pFechaI, DateTime pFechaF)
        {
            List<DatosAgenda> Result = new List<DatosAgenda>();
            DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter TempTA2 = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
            DataSet1 TempDS = new DataSet1();

            TempTA2.ReporteGeneralDetallado(TempDS.TLB_RelacionUserEntid, pFechaI, pFechaF);

            foreach(DataSet1.TLB_RelacionUserEntidRow i in TempDS.TLB_RelacionUserEntid)
            {
                DatosAgenda temp = new DatosAgenda();
                temp.Fecha = i.Fecha;
                temp.Cod_Entidad = i.Nombre;
                temp.CodAntSucursal = i.CodAntSucursal;
                temp.Codi_Entidad = i.Cod_Entidad;
                temp.CorreoElectronico = i.CorreoElectronico;
                temp.Direccion = i.Direccion;
                temp.Fax = i.Fax;
                temp.SitioWeb = i.SitioWeb;
                temp.Telefono = i.Telefono;
                temp.Nombre = i.NombreC;
                Result.Add(temp);
            }
            return Result;         
        }

        //Ver a Pedro para la implementación...
        public List<DatosProcesos> ReporteGeneralDetalladoIP(DateTime pFechaI, DateTime pFechaF)
        {
            List<DatosProcesos> Result = new List<DatosProcesos>();
            DataSet1TableAdapters.TLB_TemaTableAdapter TempTA1 = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
            DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter TempTA2 = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter();
            DataSet1 TempDS = new DataSet1();

            TempTA2.ReporteGeneralDetallado(TempDS.TLB_RelacionUserTema, pFechaI, pFechaF);

            foreach(DataSet1.TLB_RelacionUserTemaRow i in TempDS.TLB_RelacionUserTema)
            {
                DatosProcesos temp = new DatosProcesos();
                TempDS.Merge(TempTA1.ExisteT(i.Id_Tema));
                temp.Fechap = i.Fecha;
                temp.Tema = i.TLB_TemaRow.Tema;
                temp.Solicitudes = i.Contador;
                Result.Add(temp);
            }
            return Result;         
        }

        //Ver a Pedro para la implementación...
        public List<UsuarioPersistente> OperadorasAE(DateTime pFechaI, DateTime pFechaF) 
        {
            List<UsuarioPersistente> Result = new List<UsuarioPersistente>();
            DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter TempTA = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
            DataSet1 TempDS = new DataSet1();

            TempTA.ObtenerEntreFechas(TempDS.TLB_RelacionUserEntid, pFechaI, pFechaF);
            foreach (DataSet1.TLB_RelacionUserEntidRow i in TempDS.TLB_RelacionUserEntid)
            {
                bool Esta = false;
                foreach (UsuarioPersistente j in Result)
                {
                    Esta = j.Usuario == i.Id_Usuario;
                     if (Esta)
                        break;
                }
                if (!Esta)
                    Result.Add(BuscarUsuario(i.Id_Usuario));
            }
            return Result;
        }

        //Ver a Pedro para la implementación...
        public List<UsuarioPersistente> OperadorasIP(DateTime pFechaI, DateTime pFechaF)
        {
            List<UsuarioPersistente> Result = new List<UsuarioPersistente>();
            DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter TempTA = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserTemaTableAdapter();
            DataSet1.TLB_RelacionUserTemaDataTable TempTbl = new DataSet1.TLB_RelacionUserTemaDataTable();

            List<string> TempList = new List<string>();
            TempTA.ObtenerEntreFechas(TempTbl, pFechaI, pFechaF);
            foreach (DataSet1.TLB_RelacionUserTemaRow i in TempTbl)
            if (!TempList.Contains(i.Id_Usuario))
            {
                TempList.Add(i.Id_Usuario);
                Result.Add(BuscarUsuario(i.Id_Usuario));
            }

            return Result; 
        }

        
       
     
        //BUSQUEDAS DE INFORMACION DE ENTIDADES EN LA AGENDA
        public List<EntidadPersistente> BuscarInformacionDadoNombre(string nombre)
        {
            throw new NotImplementedException();
        }
        public List<EntidadPersistente> BuscarInformacionDadoDireccion(string direccion)
        {
            throw new NotImplementedException();
        }
        public List<EntidadPersistente> BuscarInformacionDadoFax(string fax)
        {
            throw new NotImplementedException();
        }
        public List<EntidadPersistente> BuscarInformacionDadoTelefono(string telefono)
        {
            throw new NotImplementedException();
        }
        public List<EntidadPersistente> BuscarInformacionDadoSitosWeb(string sitosWeb)
        {
            throw new NotImplementedException();
        }
        public List<EntidadPersistente> BuscarInformacionDadoCorreoElectronico(string correoElectronico)
        {
            throw new NotImplementedException();
        }
        public List<EntidadPersistente> BuscarInformacionDadoCodigoActual(string codigoActual)
        {
            throw new NotImplementedException();
        }
        public List<EntidadPersistente> BuscarInformacionDadoCodigoAnterior(string codigoAnterior)
        {
            throw new NotImplementedException();
        }
        
        public List<EntidadPersistente> BuscarInformacionAgenda(EntidadPersistente entidad)
        {
            return new List<EntidadPersistente>();
        }

        //Amary Jackson
        /// <summary>
        /// Devuleve los Resultados de la Consulta teniendo en ncuenta los parametros de Entrada
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="Direccion"></param>
        /// <param name="Fax"></param>
        /// <param name="Telefono"></param>
        /// <param name="correoElectronico"></param>
        /// <param name="SitioWeb"></param>
        /// <param name="CodAntSucursal"></param>
        /// <param name="CodActual"></param>
        /// <returns></returns>
        public List<EntidadPersistente> ConsultaAgendaElectronica(string nombre, string Direccion, string Fax, string Telefono, string correoElectronico, string SitioWeb, string CodAntSucursal, string CodActual) 
        {
            try
            {
                DataSet1TableAdapters.TLB_EntidadesTableAdapter Tabla = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
                string Consulta = "";
                bool anadio = false;
                //campo Nombre
                if (nombre.Trim().Length > 0)
                {
                   Consulta+="Nombre = '"+nombre+"'";
                    anadio = true;
                }
                if (Direccion.Trim().Length > 0)
                {
                    if (anadio)
                    {
                        Consulta += "and Direccion = '" + Direccion + "'";
                    }
                    else
                    {
                        Consulta += "Direccion = '" + Direccion + "'";
                        anadio = true;
                    }
                }

                //Campo Fax
                if (Fax.Trim().Length > 0)
                {
                    if (anadio)
                    {
                        Consulta += "and Fax = '" + Fax + "'";
                    }
                    else
                    {
                        Consulta += "Fax = '" + Fax + "'";
                        anadio = true;
                    }
                }

                //Campo Telefono
                if (Telefono.Trim().Length > 0)
                {
                    if (anadio)
                    {
                        Consulta += "and Telefono LIKE '%" + Telefono + "%'";
                    }
                    else
                    {
                        Consulta += "Telefono LIKE '%" + Telefono + "%'";
                        anadio = true;
                    }
                }
                //Campo correoElectronico
                if (correoElectronico.Trim().Length > 0)
                {
                    if (anadio)
                    {
                        Consulta += "and correoElectronico LIKE '%" + correoElectronico + "%'";
                    }
                    else
                    {
                        Consulta += "correoElectronico LIKE '%" + correoElectronico + "%'";
                        anadio = true;
                    }
                }
                //SitioWeb
                if (SitioWeb.Trim().Length > 0)
                {
                    if (anadio)
                    {
                        Consulta += "and SitioWeb LIKE '%" + SitioWeb + "%'";
                    }
                    else
                    {
                        Consulta += "SitioWeb LIKE '%" + SitioWeb + "%'";
                        anadio = true;
                    }
                }
                //CodAntSucursal
                if (CodAntSucursal.Trim().Length > 0)
                {
                    if (anadio)
                    {
                        Consulta += "and CodAntSucursal = '" + CodAntSucursal + "'";
                    }
                    else
                    {
                        Consulta += "CodAntSucursal = '" + CodAntSucursal + "'";
                        anadio = true;
                    }
                }

                //CodActual
                if (CodActual.Trim().Length > 0)
                {
                    if (anadio)
                    {
                        Consulta += "and CodActual = '" + CodActual + "'";
                    }
                    else
                    {
                        Consulta += "CodActual = '" + CodActual + "'";
                    }
                }
              DataRow[] Filas= Tabla.GetData().Select(Consulta);
              
                List<EntidadPersistente> ListaFilas = new List<EntidadPersistente>();
                for (int i = 0; i < Filas.Length; i++)
                {
                    ListaFilas.Add(new EntidadPersistente(Filas[i].ItemArray.GetValue(2).ToString(),"", "","","","","",""));
                }
                return ListaFilas;
            }
            catch (Exception error) 
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// Encuentra todos los datos a partir del Nombre
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public EntidadPersistente BusquedaPorNombre(string Nombre) 
        {
            try
            {
                DataSet1TableAdapters.TLB_EntidadesTableAdapter Tabla = new DataAccessLayer.DataSet1TableAdapters.TLB_EntidadesTableAdapter();
                DataSet1.TLB_EntidadesRow Fila = Tabla.BusquedaPorNombre(Nombre) as DataSet1.TLB_EntidadesRow;
                return new EntidadPersistente(Fila.Nombre, Fila.Direccion, Fila.Telefono, Fila.Fax, Fila.CodActual, Fila.CodAntSucursal, Fila.SitioWeb, Fila.CorreoElectronico);
            }
            catch (Exception error) 
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// Actualiza los datos de la Fila en la tabla TLB_RelacionUserEntid donde  la Fecha, Nombre e IdUsuario conincidan
        /// </summary>
        /// <param name="Cod_Entidad"></param>
        /// <param name="CodAntSucursal"></param>
        /// <param name="Direccion"></param>
        /// <param name="Fax"></param>
        /// <param name="Telefono"></param>
        /// <param name="CorreosElectronicos"></param>
        /// <param name="SitiosWeb"></param>
        /// <param name="NombreC"></param>
        /// <param name="FechaOriginal"></param>
        /// <param name="NombreOriginal"></param>
        /// <param name="Idusuario"></param>
        public void ActualizarFila_TLB_RelacionUserEntid(int Cod_Entidad,int CodAntSucursal,int Direccion, int Fax,int Telefono,int CorreosElectronicos,int SitiosWeb,int NombreC,DateTime FechaOriginal,string NombreOriginal,string Idusuario) 
        {
            try
            {
                DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter Tabla = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
                Tabla.ActualizarFila_TLB_RelacionUserEntid(Cod_Entidad, CodAntSucursal, Direccion, Fax, Telefono, CorreosElectronicos, SitiosWeb, NombreC, FechaOriginal, Idusuario, NombreOriginal);
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// Inserta una Fila en la Tabla TLB_RelacionUserEntid
        /// </summary>
        /// <param name="Fecha"></param>
        /// <param name="IdUsuario"></param>
        /// <param name="Cod_Entidad"></param>
        /// <param name="CodAntSucursal"></param>
        /// <param name="Nombre"></param>
        /// <param name="Direccion"></param>
        /// <param name="Fax"></param>
        /// <param name="Telefono"></param>
        /// <param name="CorreosElectronicos"></param>
        /// <param name="SitiosWeb"></param>
        /// <param name="NombreC"></param>
        /// <returns></returns>
        public bool InseertarFila_TLB_RelacionUserEntid(DateTime Fecha, string IdUsuario,int Cod_Entidad,int CodAntSucursal,string Nombre, int Direccion, int Fax,int Telefono,int CorreosElectronicos,int SitiosWeb,int NombreC) 
        {
            try
            {
               DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter Tabla = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
               Tabla.Insert(Fecha,IdUsuario.Trim().Length>15?IdUsuario.Trim().Substring(0,15): IdUsuario.Trim(), Cod_Entidad, CodAntSucursal, Nombre, Direccion, Fax, Telefono, CorreosElectronicos, SitiosWeb, NombreC);
               return true;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// Devuleve la Cantidad de Usuarios dados Fecha,IdUsuario, NombreEmpresa 
        /// </summary>
        /// <param name="Fecha"></param>
        /// <param name="IdUsuario"></param>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public int[] BusquedaEnRelacionUserEntidPorFecha_Nombre_IdUsuario(DateTime Fecha, string IdUsuario, string Nombre) 
        {
            try
            {
                DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter Tabla = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionUserEntidTableAdapter();
                DataSet1.TLB_RelacionUserEntidDataTable Filas = new DataSet1.TLB_RelacionUserEntidDataTable();
                Tabla.BusquedaEnRelacionUserEntidPorFecha_Nombre_IdUsuario(Filas, Fecha, Nombre, IdUsuario);
                if(Filas.Rows.Count >0)
                    return new int[] {Filas[0].Cod_Entidad,Filas[0].CodAntSucursal,Filas[0].Direccion,Filas[0].Fax,Filas[0].Telefono,Filas[0].CorreoElectronico,Filas[0].SitioWeb,Filas[0].NombreC};
                return new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        
        //Dagmar
        public bool EliminarInformacion(int idTema)
        {
            try
            {
                DataSet1TableAdapters.TLB_RelacionTemasTableAdapter Relacion = new DataAccessLayer.DataSet1TableAdapters.TLB_RelacionTemasTableAdapter();
                if (Relacion.ObtenerSubTemas(idTema).Rows.Count == 0)
                {
                    Relacion.EliminarSuperTema(idTema);
                    return new DataSet1TableAdapters.TLB_TemaTableAdapter().EliminarTema(idTema) > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public string[] ListaTema() 
        {
            try
            {
                DataSet1TableAdapters.TLB_TemaTableAdapter Tabla = new DataAccessLayer.DataSet1TableAdapters.TLB_TemaTableAdapter();
                DataSet1.TLB_TemaDataTable Resultado = Tabla.ListaTemas();
                string[] Nombres = new string[Resultado.Rows.Count];
                int pos = 0;
                foreach (DataSet1.TLB_TemaRow Fila in Resultado)
                {
                    Nombres[pos++] = Fila.Tema;
                }
                return Nombres;
            }
            catch(Exception error)
            {
                throw new Exception(error.Message);
            }
        }

       //-------------------------------------------------------------------------


        //****
        
      
        
        
        public List<DateTime> TarjetasAImprimirPorSucursalNoIdLoteFechaUnica(string noSucursal)
        {
            /*
            List<DateTime> list = new List<DateTime>();
            DataSet1.TLB_querysAparte2DataTable qa2dt = new DataSet1TableAdapters.TLB_querysAparte2TableAdapter().GetTarjetasDeSucursalFechaDistinct(noSucursal);
            foreach (DataSet1.TLB_querysAparte2Row i in qa2dt)
            {
                list.Add(i.FechaOrdenImp);
            }
            return list;*/

             throw new NotImplementedException();
           // return new Lis
        }
    }
    

    
#endregion

}