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

public partial class Notificaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["bloqueo"]!=null && Session["bloqueo"].ToString() == "bloqueado")
        {
            Label1.Visible = true;
            Label1.Text = "!!! Ha agotado el máximo de intentos, su usuario ha sido Bloqueado !!!";
        }
        if (Session["mensaje"] != null) //&& Session["mensaje"].ToString() == "MismoUsuario")
        {
            Label2.Visible = true;
            Label2.Text = Session["mensaje"].ToString();//"!!! Fallo del Servidor, fue reiniciado y no está activado !!!";
        }
        if (Session["Clave"] != null && Session["Clave"].ToString() == "Vencida")
        {

            Label3.Visible = true;
            Label3.Text = "!!! Su contraseña ha caducado y su cuenta ha sido Bloqueada ";
            
        }

    }
}
