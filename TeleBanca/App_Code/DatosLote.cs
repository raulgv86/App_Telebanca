using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DatosLote
/// </summary>
public class DatosLote
{

    public DatosLote()
    {

    }

    private string nombre;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    private string apellido;

    public string Apellido
    {
        get { return apellido; }
        set { apellido = value; }
    }

    private string numeroTarjeta;

    public string NumeroTarjeta
    {
        get { return numeroTarjeta; }
        set { numeroTarjeta = value; }
    }
    private string idCliente;

    public string IdCliente
    {
        get { return idCliente; }
        set { idCliente = value; }
    }

    private int indice;

    public int Indice
    {
        get { return indice; }
        set { indice = value; }
    }

    public DatosLote(string nombre, string apellido, string numeroTarjeta, string idCliente, int indice)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.numeroTarjeta = numeroTarjeta;
        this.idCliente = idCliente;
        this.indice = indice;
    }
}
