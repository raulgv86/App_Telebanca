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

public delegate void abcd();

public partial class Modules_Inicio_WebUserControl : System.Web.UI.UserControl
{
    private TeleBancaWS.TeleBancaWS Servicio;
    private bool HayConfirmacion;


    protected void Page_Load(object sender, EventArgs e)
    {
        //string banco = Servicio.CLlamadas();
        Label7.Text = "Bienvenido";

        try
        {
        
            if (Session["Clave"].ToString() == "0")
            {
                Label5.Visible = true;
                Label6.Visible = true;
                Label5.Text = "!!! Su contraseña vence hoy, le sugerimos cambiarla, para ello haga clic ";
                LinkButton1.Visible = true;
            }

            if (Session["Clave"] != null && Session["Clave"].ToString() != "0")
            {
                Label5.Visible = true;
                Label6.Visible = true;
                Label5.Text = "!!! Su contraseña caducará en " + Session["Clave"] + " días, le sugerimos cambiarla, para ello haga clic ";
                LinkButton1.Visible = true;
            }
            if (Convert.ToInt32(Session["Clave"]) > 7)
            {
                Label5.Visible = false;
                Label6.Visible = false;
                Label5.Text = "";
                LinkButton1.Visible = false;
            }
            if (Convert.ToInt32(Session["Clave"]) < 0)
            {
                Label5.Visible = true;
                Label6.Visible = true;
                Label5.Text = "!!! Su contraseña venció hace" + Convert.ToInt32(Session["Clave"])+ " días, le sugerimos cambiarla, para ello haga clic ";
                LinkButton1.Visible = true;
            }
        
            if (Servicio == null)
                if (Session["Servicio"] != null) Servicio = (TeleBancaWS.TeleBancaWS)Session["Servicio"];
        }
        catch
        {
            Errores.Alert(this, "Su sesion ha expirado. Vuelva a autenticarse");
            return; 
        }
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        MultiView1.ActiveViewIndex = Convert.ToInt32(e.Item.Value);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if ((TbxPassAnterior.Text == "") || (TbxPassNueva.Text == "") || (TbxPassConfirm.Text == ""))
        {
            Errores.Alert(this, "Debe especificar todos los parámetros");
            return; 
        }
        //if ((TbxPassNueva.Text.Length<1)||(TbxPassNueva.Text.Length>20))
        //{
        //    Errores.Alert(this, "Su contraseña no esta en el formato correcto");
        //    return;
        //}

        if ((CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(TbxPassNueva.Text) != CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(TbxPassConfirm.Text)))
        {
            Errores.Alert(this, "La nueva contraseña y su confirmación no coinciden");
            return; 
        }
        
        string[] user = Servicio.getUsuariActivo();

        if (TbxPassNueva.Text == user[0].ToString())
        {
            Errores.Alert(this, "La Contraseña no puede ser igual al Usuario"); return;
        }
        string error = "";

        if (!SecurInstallSabic.ClaveAcceso.ValidarFortalezaClave(TbxPassNueva.Text, out error, 6, true, true, true, true))
        {
            Errores.Alert(this, error); return;
        }

        string cAnterior = CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(TbxPassAnterior.Text);
        try
        {
            string[] tmpUsuario = Servicio.getUsuariActivo();

            if (tmpUsuario[1].ToLower().Equals(cAnterior.ToLower()))
            {
                HdnPass.Value = TbxPassNueva.Text;
                string passNew= CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(TbxPassNueva.Text);
                if (Servicio.ModificarClave(tmpUsuario[0].ToString(), passNew) == true)
                {
                    Errores.Alert(this, "Contraseña actualizada satisfactoriamente");
                    Response.Redirect("Default.aspx");
                }
                else
                    Errores.Alert(this, "Contraseña incorrecta");
                //new Errores(this).Confirmar("Realmente desea cambiar la contraseña...", "CambiarContrasena");
            }
            else
                Errores.Alert(this, "Contraseña incorrecta");
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error... " + ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Menu1.Items[1].Selected = true;
    }

    public bool CambiarContrasena()
    {
        bool Result = false;
        string usuario = Servicio.getUsuariActivo()[0];
        string cNueva = CriptoTeleBanca.CriptografiaTeleBanca.EncriptarPasswordSHA1(HdnPass.Value);
        try
        {
            Result = Servicio.ModificarClave(usuario, cNueva);
            if (Result)
            {
                Errores.Alert(this, "Su contraseña ha sido cambiada satifactoriamente");
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[1].Selected = true;
            }
            if (!Result)
            {
                Errores.Alert(this, "Su contraseña no ha sido cambiada pues coincide con alguna de las 10 anteriores");
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[1].Selected = true;
            }
        }
        catch (Exception ex)
        {
            Errores.Alert(this, "Error... " + ex.Message);
        }
        return Result;
    }
    protected void Button5_Click1(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Navegador.RedirectToPopUp(this, "./Ayuda/WEBHELP/ayudatbanca.htm");
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        Label2.Text=GridView1.Rows.Count.ToString();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void View2_Activate(object sender, EventArgs e)
    {
        TbxPassAnterior.Focus();
    }
}
