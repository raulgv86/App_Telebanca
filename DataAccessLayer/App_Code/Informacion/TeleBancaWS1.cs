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
using System.Web.Services;
using System.Web.Services.Protocols;
using DataAccessLayer;



/// <summary>
/// Summary description for TeleBancaWS1
/// </summary>
/// 
public partial class TeleBancaWS : System.Web.Services.WebService
{
    /*------INICIO ------ CASO DE USO Servicio Información ------INICIO ------*/

    [WebMethod(EnableSession = true)]
    public bool ExisteEntidad(string nombre)
    {
        return GetUsuarioActual.ExisteEntidad(nombre);
    }
    [WebMethod(EnableSession = true)]
    public bool InsertarEntidad(string nombre, string direccion, string telefono, string fax, string codigo, string codigoAnterior, string sitiosWeb, string correosElectronicos)
    {
        return GetUsuarioActual.InsertarEntidad(nombre, direccion, telefono, fax, codigo, codigoAnterior, sitiosWeb, correosElectronicos);
    }

    [WebMethod(EnableSession = true)]
    public bool ModificarEntidad(string nombre, string direccion, string telefono, string fax, string codigo, string codigoAnterior, string sitiosWeb, string correosElectronicos)
    {
        return GetUsuarioActual.ModificarEntidad(nombre, direccion, telefono, fax, codigo, codigoAnterior, sitiosWeb, correosElectronicos);
    }
    [WebMethod(EnableSession = true)]
    public bool InsertarHistoricoEntidad(string nombre, string direccion, string telefono, string fax, string codigoactual, string codigoanterior, string correo, string sitioweb)
    {
        return GetUsuarioActual.InsertarHistoricoEntidad(nombre, direccion, telefono, fax, codigoactual, codigoanterior, correo, sitioweb);
    }
    
    [WebMethod(EnableSession = true)]
    public bool EliminarEntidad(string nombre)
    {
        return GetUsuarioActual.EliminarEntidad(nombre);
    }
    [WebMethod(EnableSession = true)]

    public ArrayList BuscarDatosEntidad(string nombre)
    {
        return GetUsuarioActual.BuscarDatosEntidad(nombre);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList Lista_Entidades()
    {
        return GetUsuarioActual.Lista_Entidades();
    }

    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionPorPalabraClave(string palabraClave)
    {
        return GetUsuarioActual.BuscarInformacionPorPalabraClave(palabraClave);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionAgenda(string consulta)
    {
        //criterios de busquedas? (entidades)sasdf
        return GetUsuarioActual.BuscarInformacionAgenda(consulta);
    }

    [WebMethod(EnableSession = true)]
    public bool InsertarInformacion(string tema, string[] palabrasClaves, int temaPadre, string texto)
    {
        return GetUsuarioActual.InsertarInformacion(tema, palabrasClaves, temaPadre, texto);
    }
    [WebMethod(EnableSession = true)]
    
    public bool ModificarInformacion(string tema, List<string> palabrasClaves, int temaPadre, string texto, int idTema)
    {
        return GetUsuarioActual.ModificarInformacion(tema, palabrasClaves, temaPadre, texto, idTema);
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarInformacion(int idTema)
    {
        return GetUsuarioActual.EliminarInformacion(idTema);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList DatosTema(int idTema)
    {
        return GetUsuarioActual.DatosTema(idTema);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList Lista_Temas()
    {
        return GetUsuarioActual.Lista_Temas();
    }

    [WebMethod(EnableSession = true)]
    public ArrayList SubTemas(int idTema)
    {
        return GetUsuarioActual.SubTemas(idTema);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionProcesosPorTemas(string tema)
    {/*InformacionPersistente*/
        return GetUsuarioActual.BuscarInformacionProcesosPorTemas(tema);
    }

    [WebMethod(EnableSession = true)]
    public bool InsertarUsuarioAccedeTema(int idTema)
    {
        return GetUsuarioActual.InsertarUsuarioAccedeTema(idTema);
    }

    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoNombre(string nombre)
    {
        return GetUsuarioActual.BuscarInformacionDadoNombre(nombre);
    }
    
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoDireccion(string direccion)
    {
        return GetUsuarioActual.BuscarInformacionDadoDireccion(direccion);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoFax(string fax)
    {
        return GetUsuarioActual.BuscarInformacionDadoFax(fax);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoTelefono(string telefono)
    {
        return GetUsuarioActual.BuscarInformacionDadoFax(telefono);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoSitosWeb(string sitosWeb)
    {
        return GetUsuarioActual.BuscarInformacionDadoSitosWeb(sitosWeb);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoCorreoElectronico(string correoElectronico)
    {
        return GetUsuarioActual.BuscarInformacionDadoCorreoElectronico(correoElectronico);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoCodigoActual(string codigoActual)
    {
        return GetUsuarioActual.BuscarInformacionDadoCodigoActual(codigoActual);
    }
    [WebMethod(EnableSession = true)]
    public ArrayList BuscarInformacionDadoCodigoAnterior(string codigoAnterior)
    {
        return GetUsuarioActual.BuscarInformacionDadoCodigoAnterior(codigoAnterior);
    }
    //1
    [WebMethod(EnableSession = true)]
    public InformeConsultas[] ReporteConsultasAE(DateTime pFechaI, DateTime pFechaF)
    {
       return GetUsuarioActual.ReporteConsultasAE(pFechaI, pFechaF);        
    }
    //2
    [WebMethod(EnableSession = true)]
    public InformeConsultas[] ReporteConsultasIP(DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.ReporteConsultasIP(pFechaI, pFechaF);
    }
    //3
    [WebMethod(EnableSession = true)]
    public DatosAgenda[] ReportePersonalDetalladoAE(DateTime pFechaI, DateTime pFechaF, string pId_Operadora)
    {
        return GetUsuarioActual.ReportePersonalDetalladoAE(pFechaI, pFechaF, pId_Operadora);
    }
    //4
    [WebMethod(EnableSession = true)]
    public DatosProcesos[] ReportePersonalDetalladoIP(DateTime pFechaI, DateTime pFechaF, string pId_Operadora)
    {
        return GetUsuarioActual.ReportePersonalDetalladoIP(pFechaI, pFechaF, pId_Operadora);
    }
    //5
    [WebMethod(EnableSession = true)]
    public DatosResumen[] ReportePersonalResumen(string pUsuario, DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.ReportePersonalResumen(pUsuario, pFechaI, pFechaF);
    }
    //6
    [WebMethod(EnableSession = true)]
    public DatosAgenda[] ReporteGeneralDetalladoAE(DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.ReporteGeneralDetalladoAE(pFechaI, pFechaF);
    }
    //7
    [WebMethod(EnableSession = true)]
    public DatosProcesos[] ReporteGeneralDetalladoIP(DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.ReporteGeneralDetalladoIP(pFechaI, pFechaF);
    }
    //8
    [WebMethod(EnableSession = true)]
    public DatosResumen[] ReporteGeneralResumen(DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.ReporteGeneralResumen(pFechaI, pFechaF);
    }


    [WebMethod(EnableSession = true)]
    public string[][] OperadorasAE(DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.OperadorasAE(pFechaI, pFechaF);
    }

    [WebMethod(EnableSession = true)]
    public string[][] OperadorasIP(DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.OperadorasIP(pFechaI, pFechaF);
    }

    [WebMethod(EnableSession = true)]
    public string[][] Operadoras(DateTime pFechaI, DateTime pFechaF)
    {
        return GetUsuarioActual.Operadoras(pFechaI, pFechaF);
    }

    //Amary Jackson
    [WebMethod(EnableSession = true)]
    public string[] ConsultaAgendaElectronica(string nombre, string Direccion, string Fax, string Telefono, string correoElectronico, string SitioWeb, string CodAntSucursal, string CodActual) 
    {       
        return GetUsuarioActual.ConsultaAgendaElectronica(nombre,Direccion,Fax,Telefono,correoElectronico, SitioWeb, CodAntSucursal,CodActual);
    }

    //Amary Jackson
    [WebMethod(EnableSession = true)]
    public string[] BusquedaPorNombre(string Nombre)
    {
        return GetUsuarioActual.BusquedaPorNombre(Nombre);
    }

    //Amary Jackson
    [WebMethod(EnableSession = true)]
    public void ActualizarFilaAgendaElectronica(int Cod_Entidad, int CodAntSucursal, int Direccion, int Fax, int Telefono, int CorreosElectronicos, int SitiosWeb, int NombreC, DateTime FechaOriginal, string NombreOriginal, string Idusuario) 
    {
        try
        {
            GetUsuarioActual.ActualizarFila_TLB_RelacionUserEntid(Cod_Entidad, CodAntSucursal, Direccion, Fax, Telefono, CorreosElectronicos, SitiosWeb, NombreC, FechaOriginal, NombreOriginal, Idusuario);
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public string[] ListaTemas() 
    {
        try
        {
            return GetUsuarioActual.ListaTemas();
        }
        catch (Exception error) 
        {
            throw new Exception(error.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public string[] ObtenerDatosTema(string Tema)
    {
        try
        {
            return GetUsuarioActual.ObtenerDatosTema(Tema);
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public void ActualizarBusquedaProcesos(DateTime Fecha,string Idusuario,string IdTema) 
    {
        try
        {
            GetUsuarioActual.ActualizarBusquedaProcesos(Fecha, Idusuario, IdTema);
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }
    [WebMethod(EnableSession = true)]
    public string[] BuscarPorPalabraClave(string palabra) 
    {
        try
        {
            return GetUsuarioActual.BuscarPorPalabraClave(palabra);
        }
        catch (Exception error) 
        {
            throw new Exception(error.Message);
        }
    } 

    //----------------------------------------
    [WebMethod(EnableSession = true)]
    public bool ExisteInformacion(string Tema)
    {
        return GetUsuarioActual.ExisteInformacion(Tema);
    }
    //--------------------------------------------------------------------------
    /*------  FIN  ------ CASO DE USO Servicio Información ------  FIN  ------*/
}
