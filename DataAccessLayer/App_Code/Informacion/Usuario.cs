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
using System.Collections;
using DataAccessLayer;

/// <summary>
/// Summary description for Class1
/// </summary>
public partial class Usuario : UsuarioPersistente
{
    /*------INICIO ------ CASO DE USO Servicio Información ------INICIO ------*/


    public bool ExisteEntidad(string nombre) 
    {
        return Handler.ExisteEntidad(nombre);
    }

    public bool ExisteInformacion(string Tema)
    {
        return Handler.ExisteInformacion(Tema);
    }
    public bool InsertarEntidad(string nombre, string direccion, string telefono, string fax, string codigo, string codigoAnterior, string sitiosWeb, string correosElectronicos)
    {
                
            char[] caracteres = new char[1] { ';' };

            sitiosWeb = sitiosWeb.Trim();
            string[] sites = sitiosWeb.Split(caracteres);
            List<string> sitios = new List<string>();

            for (int i = 0; i < sites.Length; i++)
                sitios.Add(sites[i]);
            sitios.Remove("");
            correosElectronicos = correosElectronicos.Trim();
            string[] emails = correosElectronicos.Split(caracteres);
            List<string> correos = new List<string>();

            for (int i = 0; i < emails.Length; i++)
                correos.Add(emails[i]);
            correos.Remove("");
            return Handler.InsertarEntidad(new EntidadPersistente(nombre, direccion, telefono, fax, codigo, codigoAnterior, sitios, correos));
            
        
    }

    public bool ModificarEntidad(string nombre, string direccion, string telefono, string fax, string codigo, string codigoAnterior, string sitiosWeb, string correosElectronicos)
    {
        try
        {
            if (Handler.ExisteEntidad(nombre))
            {
                char[] caracteres = new char[1] { ';' };

                sitiosWeb = sitiosWeb.Trim();
                string[] sites = sitiosWeb.Split(caracteres);
                List<string> sitios = new List<string>();

                for (int i = 0; i < sites.Length; i++)
                    sitios.Add(sites[i]);
                sitios.Remove("");

                correosElectronicos = correosElectronicos.Trim();
                string[] emails = correosElectronicos.Split(caracteres);
                List<string> correos = new List<string>();

                for (int i = 0; i < emails.Length; i++)
                    correos.Add(emails[i]);
                correos.Remove("");
                return Handler.ModificarEntidad(new EntidadPersistente(nombre, direccion, telefono, fax, codigo, codigoAnterior, sitios, correos));
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;

    }

    public ArrayList BuscarDatosEntidad(string nombre)
    {
        EntidadPersistente entidad;
        try
        {
            entidad = Handler.BuscarEntidad(nombre);
        }
        catch (Exception ex)
        {

            throw ex;
        }

        ArrayList datosEntidad = new ArrayList();

        datosEntidad.Add(entidad.Nombre);
        datosEntidad.Add(entidad.Direccion);
        datosEntidad.Add(entidad.Telefono);
        datosEntidad.Add(entidad.Fax);
        datosEntidad.Add(entidad.Codigo);
        datosEntidad.Add(entidad.CodigoAnterior);
        entidad.CorreoElectronico.Remove("");
        entidad.SitiosWeb.Remove("");
        string aux = "";
        foreach (string i in entidad.SitiosWeb)
        {
            aux += i + ";";
        }
        datosEntidad.Add(aux);
        aux = "";
        foreach (string i in entidad.CorreoElectronico)
        {
            aux += i + ";";
        }
        datosEntidad.Add(aux);

        return datosEntidad;
    }
    public bool InsertarHistoricoEntidad(string nombre, string direccion, string telefono, string fax, string codigoactual, string codigoanterior, string correo, string sitioweb) 
    {
        EntidadPersistente ent = new EntidadPersistente(nombre, direccion, telefono, fax, codigoactual, codigoanterior, correo, sitioweb);
        return Handler.InsertarHistoricoEntidad(ent);
       
    }

    public bool EliminarEntidad(string nombre)
    {

        try
        {
            if (!Handler.ExisteEntidad(nombre))
                throw new Exception("La entidad a eliminar no existe.");
            return Handler.EliminarEntidad(nombre);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return false;
    }

    public ArrayList Lista_Entidades()
    {
        try
        {
            List<EntidadPersistente> entidades = Handler.ObtenerListaEntidades();
            ArrayList nombresEntidades = new ArrayList();

            ArrayList array = new ArrayList();

            for (int i = 0; i < entidades.Count; i++)
            {
                array.Add(entidades[i].Nombre);
                array.Add(entidades[i].Codigo);
                nombresEntidades.Add(array);
                array = new ArrayList();
            }

            return nombresEntidades;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public ArrayList BuscarInformacionPorPalabraClave(string palabraClave)
    {
        try
        {
            List<InformacionPersistente> temas = Handler.BuscarInformacionPorPalabraClave(palabraClave);
            ArrayList listaTemas = new ArrayList();

            ArrayList array = new ArrayList();

            for (int i = 0; i < temas.Count; i++)
            {
                array.Add(temas[i].Tema);
                array.Add(temas[i].IdTema);
                listaTemas.Add(array);
                array = new ArrayList();
            }
            return listaTemas;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public ArrayList BuscarInformacionAgenda(string consulta)
    {
     /*   char[] caracteres = new char[1] { ';' };

        sitiosWeb = sitiosWeb.Trim();
        string[] sites = sitiosWeb.Split(caracteres);
        List<string> sitios = new List<string>();

        for (int i = 0; i < sites.Length; i++)
            sitios.Add(sites[i]);

        correosElectronicos = correosElectronicos.Trim();
        string[] emails = correosElectronicos.Split(caracteres);
        List<string> correos = new List<string>();

        for (int i = 0; i < emails.Length; i++)
            correos.Add(emails[i]);*/
        try
        {
            List<EntidadPersistente> entidades = Handler.BuscarEnAgendaElectronica(consulta);// BuscarInformacionAgenda(new EntidadPersistente(nombre, direccion, telefono, fax, codigo, codigoAnterior, sitios, correos));
            ArrayList nombresEntidades = new ArrayList();

            for (int i = 0; i < entidades.Count; i++)
                nombresEntidades.Add(entidades[i].Nombre);

            return nombresEntidades;
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public bool InsertarInformacion(string tema, string[] palabrasClaves, int temaPadre, string texto)
    {
        List<string> tempList = new List<string>();
        tempList.AddRange(palabrasClaves);
        try
        {
            if (!Handler.ExisteInformacion(tema))
                return Handler.InsertarInformacion(new InformacionPersistente(tema, tempList, temaPadre, texto));
            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public bool ModificarInformacion(string tema, List<string> palabrasClaves, int temaPadre, string texto, int idTema)
    {
        try
        {
            if (Handler.ExisteInformacion(tema) == true)//arreglar
            {
                Handler.ModificarInformacion(new InformacionPersistente(tema, palabrasClaves, temaPadre, texto), idTema);
            }
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool EliminarInformacion(int idTema)
    {
        try
        {
           if (!Handler.ExisteInformacion(idTema))
                throw new Exception("El tema a eliminar no existe.");
            return Handler.EliminarInformacion(idTema);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return false;
    }

    public ArrayList DatosTema(int idTema)
    {
       try
        {
            ArrayList tema = new ArrayList();
            ArrayList palabrasClaves = new ArrayList();

            InformacionPersistente infoTema = Handler.ObtenerDatosTema(idTema);

            tema.Add(infoTema.IdTema);
            tema.Add(infoTema.Tema);
            tema.Add(infoTema.Texto);
            tema.Add(infoTema.TemaPadre);

            foreach (string i in infoTema.PalabrasClaves)
            {
                palabrasClaves.Add(i);
            }
            tema.Add(palabrasClaves);
            return tema;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public ArrayList SubTemas(int idTema)
    {
        try
        {
            ArrayList nombresSubTemas = new ArrayList();
            List<InformacionPersistente> subTemas = Handler.SubTemas(idTema);
            int cantidad = subTemas.Count;
            for (int i = 0; i < cantidad; i++)
                nombresSubTemas.Add(subTemas[i].Tema);
           
            return nombresSubTemas;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public ArrayList Lista_Temas()
    {
        try
        {
            List<InformacionPersistente> temas = Handler.ListaTemas();

            ArrayList listaTemas = new ArrayList();

            ArrayList objTemas = new ArrayList();

            int cantidad = temas.Count;

            for (int i = 0; i < cantidad; i++)
            {
                listaTemas.Add(temas[i].Tema);
                listaTemas.Add(temas[i].IdTema);
                objTemas.Add(listaTemas);
                listaTemas = new ArrayList();
            }
            return objTemas;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public ArrayList BuscarInformacionProcesosPorTemas(string tema)
    {
        try
        {
            return new ArrayList();
            //return Handler.BuscarInformacionProcesosPorTemas(tema);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public bool InsertarUsuarioAccedeTema(int idTema)
    {
        try
        {//ExisteUsuarioAccedeTema();
            if (Handler.InsertarRelacUsuarioTema(new HistorialUsuarioTemaPersitente(Usuario, idTema, System.DateTime.Now)))
                return true;
            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public ArrayList BuscarInformacionDadoNombre(string nombre)
    {
        try
        {
            List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoNombre(nombre);
            ArrayList nombresEntidades = new ArrayList();
            int cantidad = entidades.Count;
            for (int i = 0; i < cantidad; i++)
                nombresEntidades.Add(entidades[i].Nombre);

            return nombresEntidades;
        }
        catch (Exception ex)
        {

            throw ex;
        }
 
    }
    public ArrayList BuscarInformacionDadoDireccion(string direccion)
    {
        try
        {
            List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoDireccion(direccion);
            ArrayList nombresEntidades = new ArrayList();
            int cantidad = entidades.Count;
            for (int i = 0; i < cantidad; i++)
                nombresEntidades.Add(entidades[i].Nombre);

            return nombresEntidades;

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
    public ArrayList BuscarInformacionDadoFax(string fax)
    {
        try
        {
            List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoFax(fax);
            ArrayList nombresEntidades = new ArrayList();
            int cantidad = entidades.Count;
            for (int i = 0; i < cantidad; i++)
                nombresEntidades.Add(entidades[i].Nombre);

            return nombresEntidades;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        
    }
    public ArrayList BuscarInformacionDadoTelefono(string telefono)
    {

        List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoTelefono(telefono);
        ArrayList nombresEntidades = new ArrayList();
        int cantidad = entidades.Count;
        for (int i = 0; i < cantidad; i++)
            nombresEntidades.Add(entidades[i].Nombre);

        return nombresEntidades;
    }
    public ArrayList BuscarInformacionDadoSitosWeb(string sitosWeb)
    {
        List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoSitosWeb(sitosWeb);
        ArrayList nombresEntidades = new ArrayList();
        int cantidad = entidades.Count;
        for (int i = 0; i < cantidad; i++)
            nombresEntidades.Add(entidades[i].Nombre);

        return nombresEntidades;
    }
    public ArrayList BuscarInformacionDadoCorreoElectronico(string correoElectronico)
    {
        List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoCorreoElectronico(correoElectronico);
        ArrayList nombresEntidades = new ArrayList();
        int cantidad = entidades.Count;
        for (int i = 0; i < cantidad; i++)
            nombresEntidades.Add(entidades[i].Nombre);

        return nombresEntidades;
    }
    public ArrayList BuscarInformacionDadoCodigoActual(string codigoActual)
    {
        List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoCodigoActual(codigoActual);
        ArrayList nombresEntidades = new ArrayList();
        int cantidad = entidades.Count;
        for (int i = 0; i < cantidad; i++)
            nombresEntidades.Add(entidades[i].Nombre);

        return nombresEntidades;
    }
    public ArrayList BuscarInformacionDadoCodigoAnterior(string codigoAnterior)
    {
        List<EntidadPersistente> entidades = Handler.BuscarInformacionDadoCodigoAnterior(codigoAnterior);
        ArrayList nombresEntidades = new ArrayList();
        int cantidad = entidades.Count;
        for (int i = 0; i < cantidad; i++)
            nombresEntidades.Add(entidades[i].Nombre);

        return nombresEntidades;
    }

    /*------  FIN  ------ CASO DE USO Servicio Información ------  FIN  ------*/
    
    // Métodos para añadirle el usuario actual a los Reporte

    private void AgregarNombreaObjeto(DataAccessLayer.InformeConsultas aInformeConsulta)
    {
        aInformeConsulta.Reportero = this.Nombre;
    }

    private void AgregarNombreaObjetoDatosAgenda(DataAccessLayer.DatosAgenda aDatosAgenda)
    {
        aDatosAgenda.Reportero = this.Nombre;
    }

    private void AgregarNombreaObjetoDatosProcesos(DataAccessLayer.DatosProcesos aDatosProcesos)
    {
        aDatosProcesos.Reportero = this.Nombre;
    }

    // Métodos para añadirle el usuario actual a los Reporte
    
    public InformeConsultas[] ReporteConsultasAE(DateTime pFechaI, DateTime pFechaF) 
    {
        List<DataAccessLayer.InformeConsultas> TempList = Handler.ReporteConsultasAE(pFechaI, pFechaF);
        TempList.ForEach(AgregarNombreaObjeto);
        return TempList.ToArray();
    }
    
    //2
    public InformeConsultas[] ReporteConsultasIP(DateTime pFechaI, DateTime pFechaF)
    {
        List<DataAccessLayer.InformeConsultas> TempList = Handler.ReporteConsultasIP(pFechaI, pFechaF);
        TempList.ForEach(AgregarNombreaObjeto);
        return TempList.ToArray();
    }

    //3
    public DatosAgenda[] ReportePersonalDetalladoAE(DateTime pFechaI, DateTime pFechaF, string pId_Operadora)
    {
        List<DataAccessLayer.DatosAgenda> TempList = Handler.ReportePersonalDetalladoAE(pFechaI, pFechaF, pId_Operadora);
        TempList.ForEach(AgregarNombreaObjetoDatosAgenda);
        return TempList.ToArray();
    }

    //4
    public DatosProcesos[] ReportePersonalDetalladoIP(DateTime pFechaI, DateTime pFechaF, string pId_Operadora)
    {
        List<DataAccessLayer.DatosProcesos> TempList = Handler.ReportePersonalDetalladoIP(pFechaI, pFechaF, pId_Operadora);
        TempList.ForEach(AgregarNombreaObjetoDatosProcesos);
        return TempList.ToArray();
    }

    //5
    public DatosResumen[] ReportePersonalResumen(string pUsuario, DateTime pFechaI, DateTime pFechaF)
    {
        Dictionary<DateTime, DatosResumen> TempDict = new Dictionary<DateTime, DatosResumen>();
        List<DatosAgenda> TempList1 = Handler.ReportePersonalDetalladoAE( pFechaI.Date, pFechaF.Date, pUsuario);
        List<DatosProcesos> TempList2 = Handler.ReportePersonalDetalladoIP(pFechaI.Date, pFechaF.Date, pUsuario);

        string OpNombre = Handler.BuscarUsuario(pUsuario).Nombre;

        foreach (DatosAgenda i in TempList1)
        {
            int Suma = i.Codi_Entidad + i.CodAntSucursal + i.CorreoElectronico + i.Direccion + i.Fax + i.Nombre + i.SitioWeb + i.Telefono;
            DatosResumen TemDat = new DatosResumen(this.Nombre, OpNombre, 0, Suma, i.Fecha.Date);
            TempDict.Add(TemDat.Fecha.Date, TemDat);
        }
        foreach (DatosProcesos i in TempList2)
        {
            if (TempDict.ContainsKey(i.Fechap.Date))
                TempDict[i.Fechap.Date].Inf_procesos += i.Solicitudes;
            else
            {
                DatosResumen TemDat = new DatosResumen(this.Nombre, OpNombre, i.Solicitudes, 0, i.Fechap.Date);
                TempDict.Add(TemDat.Fecha.Date, TemDat);
            }
        }
        DatosResumen[] Result = new DatosResumen[TempDict.Count];
        TempDict.Values.CopyTo(Result, 0);
        return Result;
    }

    //6 
    public DatosAgenda[] ReporteGeneralDetalladoAE(DateTime pFechaI, DateTime pFechaF)
    {
        List<DataAccessLayer.DatosAgenda> TempList = Handler.ReporteGeneralDetalladoAE(pFechaI, pFechaF);
        TempList.ForEach(AgregarNombreaObjetoDatosAgenda);
        return TempList.ToArray();
    }

    //7
    public DatosProcesos[] ReporteGeneralDetalladoIP(DateTime pFechaI, DateTime pFechaF)
    {
        List<DataAccessLayer.DatosProcesos> TempList = Handler.ReporteGeneralDetalladoIP(pFechaI, pFechaF);
        TempList.ForEach(AgregarNombreaObjetoDatosProcesos);
        return TempList.ToArray();
    }
      
    //8
    public DatosResumen[] ReporteGeneralResumen(DateTime pFechaI, DateTime pFechaF)
    {
        Dictionary<DateTime, DatosResumen> TempDict = new Dictionary<DateTime, DatosResumen>();
        List<DatosAgenda> TempList1 = Handler.ReporteGeneralDetalladoAE(pFechaI.Date, pFechaF.Date);
        List<DatosProcesos> TempList2 = Handler.ReporteGeneralDetalladoIP(pFechaI.Date, pFechaF.Date);

        foreach (DatosAgenda i in TempList1)
        {
            int Suma = i.Codi_Entidad + i.CodAntSucursal + i.CorreoElectronico + i.Direccion + i.Fax + i.Nombre + i.SitioWeb + i.Telefono;
            DatosResumen TemDat = new DatosResumen(this.Nombre, "Todos", 0, Suma, i.Fecha.Date);
            TempDict.Add(TemDat.Fecha.Date, TemDat);
        }
        foreach (DatosProcesos i in TempList2)
        {
            if (TempDict.ContainsKey(i.Fechap.Date))
                TempDict[i.Fechap.Date].Inf_procesos += i.Solicitudes;
            else
            {
                DatosResumen TemDat = new DatosResumen(this.Nombre, "Todos", i.Solicitudes, 0, i.Fechap.Date);
                TempDict.Add(TemDat.Fecha.Date, TemDat);
            }
        }
         DatosResumen[] Result = new DatosResumen[TempDict.Count];
         TempDict.Values.CopyTo(Result, 0);
         return Result;
    }



    public string[][] OperadorasAE(DateTime pFechaI, DateTime pFechaF)
    {
        List<UsuarioPersistente> TempList = Handler.OperadorasAE(pFechaI, pFechaF);
        string[][] Result = new string[2][];
        Result[0] = new string[TempList.Count];
        Result[1] = new string[TempList.Count];
        int j = 0;
        foreach(UsuarioPersistente i in TempList)
        {
            Result[0][j] = i.Nombre;
            Result[1][j] = i.Usuario;
            j++;
        }
        return Result;
    }

    public string[][] OperadorasIP(DateTime pFechaI, DateTime pFechaF)
    {
        List<UsuarioPersistente> TempList = Handler.OperadorasIP(pFechaI, pFechaF);
        string[][] Result = new string[2][];
        Result[0] = new string[TempList.Count];
        Result[1] = new string[TempList.Count];
        int j = 0;
        foreach (UsuarioPersistente i in TempList)
        {
            Result[0][j] = i.Nombre;
            Result[1][j] = i.Usuario;
            j++;
        }
        return Result;
    }

    public string[][] Operadoras(DateTime pFechaI, DateTime pFechaF)
    {
        List<UsuarioPersistente> TempList = Handler.OperadorasIP(pFechaI, pFechaF);
        Dictionary<string, UsuarioPersistente> TempList2 = new Dictionary<string, UsuarioPersistente>();
        foreach (UsuarioPersistente i in TempList)
            TempList2.Add(i.Usuario, i);
        TempList = Handler.OperadorasAE(pFechaI, pFechaF);
        foreach (UsuarioPersistente i in TempList)
            if (!TempList2.ContainsKey(i.Usuario)) TempList2.Add(i.Usuario, i);

        UsuarioPersistente[] TempList1 = new UsuarioPersistente[TempList2.Count];
        TempList2.Values.CopyTo(TempList1, 0);

        string[][] Result = new string[2][];
        Result[0] = new string[TempList2.Count];
        Result[1] = new string[TempList2.Count];
        int j = 0;
        foreach (UsuarioPersistente i in TempList1)
        {
                Result[0][j] = i.Nombre;
                Result[1][j] = i.Usuario;
                j++;
        }
        return Result;
    }

    //Amary Jackson
    /// <summary>
    /// Devuelve un Arreglo Unidimensional: nombres
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
    public string[] ConsultaAgendaElectronica(string nombre, string Direccion, string Fax, string Telefono, string correoElectronico, string SitioWeb, string CodAntSucursal, string CodActual) 
    {
        try
        {   
            List<EntidadPersistente> ListaFilas = Handler.ConsultaAgendaElectronica(nombre, Direccion, Fax, Telefono, correoElectronico, SitioWeb, CodAntSucursal, CodActual);
            string[]  ResultadoConsulta = new string[ListaFilas.Count];
            int PosFila = 0;
            foreach (EntidadPersistente Fila in ListaFilas)
            {
                ResultadoConsulta[PosFila] = Fila.Nombre;
                PosFila++;
            }
            return ResultadoConsulta;
        }
        catch (Exception error) 
        {
            throw new Exception(error.Message);
        }
    }
    /// <summary>
    /// nombre,Direccion,Fax,Telefono, correoElectronico,SitioWeb,CodAntSucursal,CodActual 
    /// </summary>
    /// <param name="Nombre"></param>
    /// <returns></returns>
    public string[] BusquedaPorNombre(string Nombre)
    {
        try
        {
            EntidadPersistente Fila = Handler.BuscarEntidadPorNombre(Nombre);
            return new string[] {Fila.Nombre,Fila.Direccion,Fila.Fax,Fila.Telefono,Fila.F_CorreosElectronicos,Fila.F_SitiosWeb,Fila.CodigoAnterior,Fila.Codigo};
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
    public void ActualizarFila_TLB_RelacionUserEntid(int Cod_Entidad, int CodAntSucursal, int Direccion, int Fax, int Telefono, int CorreosElectronicos, int SitiosWeb, int NombreC, DateTime FechaOriginal, string NombreOriginal, string Idusuario)
    {
        try
        {
            int []Filas =  Handler.BusquedaEnRelacionUserEntidPorFecha_Nombre_IdUsuario(FechaOriginal, Idusuario, NombreOriginal);
            bool EstaVacio = true;
            for (int i = 0; i < Filas.Length; i++)
            {
                if (Filas[i] > 0)
                {
                    EstaVacio = false;
                    break;
                }

            }
            if (EstaVacio)
            {
                Handler.InseertarFila_TLB_RelacionUserEntid(FechaOriginal, Idusuario, Cod_Entidad, Cod_Entidad, NombreOriginal, Direccion, Fax, Telefono, CorreosElectronicos, SitiosWeb, NombreC);
            }
            else
            {
                 Handler.ActualizarFila_TLB_RelacionUserEntid(Filas[0]+Cod_Entidad,Filas[1]+ CodAntSucursal,Filas[2]+ Direccion,Filas[3]+ Fax,Filas[4]+ Telefono,Filas[5]+ CorreosElectronicos,Filas[6]+ SitiosWeb,Filas[7]+ NombreC, FechaOriginal, NombreOriginal, Idusuario);
            }
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public string[] ListaTemas()
    {
        try
        {
            return Handler.ListaTema();
        }
        catch (Exception error)
        {

            throw new Exception(error.Message);
        }
    }


    public string[] ObtenerDatosTema(string Tema) 
    {
        try
        {
            InformacionPersistente Obj = Handler.MostrarDatosTema(Tema);
            string Subtemas = "", PalabrasClaves = "";
            foreach (string E in Obj.FSubtemas)
            {
                Subtemas += E + ";";
            }
            if(Subtemas.Length>0)
                Subtemas = Subtemas.Substring(0,Subtemas.Length-1);
            foreach (string E in Obj.PalabrasClaves)
	        {
                PalabrasClaves += E + ";";
	        }
            if(PalabrasClaves.Length>0)
                PalabrasClaves = PalabrasClaves.Substring(0,PalabrasClaves.Length-1);
            return new string[] {Obj.Tema,Obj.Texto,Obj.SuperTema,Subtemas,PalabrasClaves,Obj.IdTema.ToString() };
        }
        catch (Exception error)
        {

            throw new Exception(error.Message);
        }
    }

    public void ActualizarBusquedaProcesos(DateTime Fecha, string Idusuario, string IdTema) 
    {
        try
        {
            Handler.ActualizarRelacionUserTema(Fecha, Idusuario, IdTema);
        }
        catch (Exception error) 
        {
            throw new Exception(error.Message);
        }
    }

    public string[] BuscarPorPalabraClave(string palabra) 
    {
        try
        {
            return Handler.BuscarPorPalabra(palabra);
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }


    //---------------------------------------------------------------------------------
}