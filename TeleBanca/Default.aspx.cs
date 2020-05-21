using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;



public partial class _Default : System.Web.UI.Page 
{ 
    int aux;
    protected void Page_Load(object sender, EventArgs e)
    {

        //string cadena = ConfigurationManager.ConnectionStrings["TeleBancaConnectionString"].ConnectionString;
        //SqlConnection cnx = new SqlConnection(cadena);

        //cnx.Open();

      

        Login1.Focus();
        if (!IsPostBack)
        {
            Session["intentos"] = "0";
        }

    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        TeleBancaWS.TeleBancaWS TempServ = new TeleBancaWS.TeleBancaWS();
        TempServ.CookieContainer = new System.Net.CookieContainer();
        try
        {
            e.Authenticated = TempServ.Autenticar(Login1.UserName, CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(Login1.Password));
        }
        catch (Exception ee)
        {
            Session["mensaje"] = "MismoUsuario";
            Response.Redirect("Notificaciones.aspx");
        }


        if (e.Authenticated)
        {
            Session["Servicio"] = TempServ;
            DateTime Fecha = TempServ.Fecha_Expira(Login1.UserName);
            TimeSpan calculo = Fecha.Subtract(DateTime.Now.Date);
            int d = calculo.Days;


            if (d != 0 && d <= 7)
            {
                Session["Clave"] = Convert.ToString(d);
                Response.Redirect("Main.aspx");
            }
            if (!calculo.ToString().StartsWith("-"))
            {
                Session["Clave"] = Convert.ToString(d);
                Response.Redirect("Main.aspx");
            }
            if (calculo.ToString().StartsWith("-"))
            {
                Session["Clave"] = "Vencida";
                TempServ.DesactivarUser(Login1.UserName);
                Response.Redirect("Notificaciones.aspx");
            }
            if (d > 7)
            {
                Session["Clave"] = Convert.ToString(d);
            }
        }
        else
        {

            int temp = Convert.ToInt32(Session["intentos"]);
            aux = temp + 1;
            Session["intentos"] = aux.ToString();

            if (aux >= 3)
            {

                string user_dominio = User.Identity.Name;
                string ip_remoto = Page.Request.ServerVariables["REMOTE_ADDR"];
                string nombre_pc = Page.Request.ServerVariables["REMOTE_HOST"];
                string descripción = "Bloqueado por " + user_dominio + " desde la PC: " + nombre_pc + " con IP: " + ip_remoto;

                TempServ.DesactivarUser(Login1.UserName);
                //TempServ.Quien_Bloquea_Usuario(Login1.UserName, descripción);
                Session["bloqueo"] = "bloqueado";
                Response.Redirect("Notificaciones.aspx");
                Login1.Enabled = false;
            }
            else
            {
                Session["bloqueo"] = "libre";
            }
        }
    }

    //protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    //{
    //    TeleBancaWS.TeleBancaWS TempServ = new TeleBancaWS.TeleBancaWS();
    //    TempServ.CookieContainer = new System.Net.CookieContainer();
    //    try
    //    {
            
    //        string h = DateTime.Now.Hour.ToString();
    //        //string pass = CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1("L1sandra*");
    //        e.Authenticated = TempServ.Autenticar(Login1.UserName, CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(Login1.Password));

    //        if (e.Authenticated)
    //        {
    //            Session["Servicio"] = TempServ;
    //            DateTime Fecha = TempServ.Fecha_Expira(Login1.UserName);
    //            TimeSpan calculo = Fecha.Subtract(DateTime.Now.Date);
    //            int d = calculo.Days;


    //            if (d != 0 && d <= 7)
    //            {
    //                Session["Clave"] = Convert.ToString(d);
    //                Response.Redirect("Main.aspx");
    //            }
    //            if (!calculo.ToString().StartsWith("-"))
    //            {
    //                Session["Clave"] = Convert.ToString(d);
    //                Response.Redirect("Main.aspx");

    //            }
    //            if (calculo.ToString().StartsWith("-"))
    //            {
    //                Session["Clave"] = "Vencida";
    //                TempServ.DesactivarUser(Login1.UserName);
    //                Response.Redirect("Notificaciones.aspx");
    //            }
    //            if (d > 7)
    //            {
    //                Session["Clave"] = Convert.ToString(d);
    //            }
    //        }
    //        else
    //        {

    //            int temp = Convert.ToInt32(Session["intentos"]);
    //            aux = temp + 1;
    //            Session["intentos"] = aux.ToString();

    //            if (aux >= 3)
    //            {

    //                string user_dominio = User.Identity.Name;
    //                string ip_remoto = Page.Request.ServerVariables["REMOTE_ADDR"];
    //                string nombre_pc = Page.Request.ServerVariables["REMOTE_HOST"];
    //                string descripción = "Bloqueado por " + user_dominio + " desde la PC: " + nombre_pc + " con IP: " + ip_remoto;

    //                TempServ.DesactivarUser(Login1.UserName);
    //                TempServ.Quien_Bloquea_Usuario(Login1.UserName, descripción);
    //                Session["bloqueo"] = "bloqueado";
    //                Response.Redirect("Notificaciones.aspx");
    //                Login1.Enabled = false;

    //            }
    //            else
    //            {
    //                Session["bloqueo"] = "libre";
    //            }
    //        }
    //    }
    //    catch (Exception ee)
    //    {
    //        //Session["mensaje"] = "MismoUsuario";
    //        Session["mensaje"] = ee.Message.ToString();
    //        Response.Redirect("Notificaciones.aspx");
    //        //Response.Redirect("Notificaciones.aspx");
    //    }            
  
    //}

    public void CambiarPass()
    {
        Response.Redirect("Modules/Inicio/WebUserControl.ascx");
    }

    public void Out()
    {
        Session["UserName"] = null;
    }
    
}
