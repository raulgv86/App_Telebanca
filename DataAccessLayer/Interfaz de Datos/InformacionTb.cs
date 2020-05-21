using System;
using System.Web;

public class InformacionTb
{
    private string nombreTb;
    private string direccionTb;
    private string telefonoTb;
    private string faxTb;
    private string urlSitioWeb;
    private string logotipoTb;
    private string nombreDirector;
    private string correoDirector;
    private string descripcionServicios;
    private string organismoTb;


    public InformacionTb(
        string NombreTb, 
        string DireccionTb, 
        string TelefonoTb, 
        string FaxTb, 
        string UrlSitioWeb, 
        string LogotipoTb,
        string NombreDirector,
        string CorreoElectronico,
        string DescripcionServicios,
        string OrganismoTb) 
    {
        this.nombreTb = NombreTb;
        this.direccionTb = DireccionTb;
        this.telefonoTb = TelefonoTb;
        this.faxTb = FaxTb;
        this.urlSitioWeb = UrlSitioWeb;
        this.logotipoTb = LogotipoTb;
        this.nombreDirector = NombreDirector;
        this.correoDirector = CorreoElectronico;        
        this.descripcionServicios = DescripcionServicios;
        this.organismoTb = OrganismoTb;
    }
    public InformacionTb() { } 
	
    public string GetSetNombreTb
    {
        get { return nombreTb; }
        set { nombreTb = value; }
    } 
    public string GetSetDireccionTb
    {
        get { return direccionTb; }
        set { direccionTb = value; }
    }
    public string GetSetTelefonoTb
    {
        get { return telefonoTb; }
        set { telefonoTb = value; }
    }
    public string GetSetFaxTb
    {
        get { return faxTb; }
        set { faxTb = value; }
    }
    public string GetSetUrlSitioWeb
    {
        get { return urlSitioWeb; }
        set { urlSitioWeb = value; }
    }
    public string GetSetLogoTipo
    {
        get { return logotipoTb; }
        set { logotipoTb = value; }
    }
    public string GetSetNombreDirector
    {
        get { return nombreDirector; }
        set { nombreDirector = value; }
    }
    public string GetSetCorreoElectronico
    {
        get { return correoDirector; }
        set { correoDirector = value; }
    }
    public string GetSetDescripcionServicios
    {
        get { return descripcionServicios; }
        set { descripcionServicios = value; }
    }
    public string GetSetOrganismoTb
    {
        get { return organismoTb; }
        set { organismoTb = value; }
    }

	
	
	
	
	
	
}
