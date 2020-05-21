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
using System.Threading;
public partial class Default2 : System.Web.UI.Page
{
    private TeleBancaWS.TeleBancaWS Servicio;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((MultiView)WebUserControl_ServicioPago1.FindControl("MVWPago")).ActiveViewIndex == 1)
        {
            MultiView1.ActiveViewIndex = 2;
            ImageButton8.Visible = true;
            ImageButton7.Visible = false;
        }

        

        Label1.Text = Convert.ToString(DateTime.Today.Year);
        InitializeComponent();
        try
        {
            
            if (!this.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }

            if (Servicio == null)
                if (Session["Servicio"] != null) Servicio = (TeleBancaWS.TeleBancaWS)Session["Servicio"];

            LblShowNombre.Text = Servicio.getUsuariActivo()[2];
            
           
        }
        catch (Exception ex)
       { Errores.Alert(this,ex.Message);}
}

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        //Panel1.BackImageUrl = "~/Images/Botones/BarraEstado/fondo_reposo_inicio.png";
        ImageButton1.Visible = true;
        ImageButton2.Visible = true;
        ImageButton4.Visible = true;
        ImageButton5.Visible = true;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        //Panel1.BackImageUrl = "~/Images/Botones/BarraEstado/fondo_reposo_Administracion.png";
        ImageButton1.Visible = true;
        ImageButton2.Visible = true;
        ImageButton4.Visible = true;
        ImageButton5.Visible = true;
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        //Panel1.BackImageUrl = "~/Images/Botones/BarraEstado/fondo_reposo_SPago.png";
        ImageButton1.Visible = true;
        ImageButton2.Visible = true;
        ImageButton4.Visible = true;
        ImageButton5.Visible = true;
      
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        //Panel1.BackImageUrl = "~/Images/Botones/BarraEstado/fondo_reposo_SInformacion.png";
        ImageButton1.Visible = true;
        ImageButton2.Visible = true;
        ImageButton4.Visible = true;
        ImageButton5.Visible = true;
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        MultiView1.ActiveViewIndex = 4;
        //Panel1.BackImageUrl = "~/Images/Botones/BarraEstado/fondo_reposo_GAutentificacion.png";
        ImageButton1.Visible = true;
        ImageButton2.Visible = true;
        ImageButton4.Visible = true;
        ImageButton5.Visible = true;
    }

    protected void WebUserControl1_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Servicio.Salir();
        Response.Redirect("Default.aspx");
    }

    private void InitializeComponent()
    {
        this.LoadComplete += new System.EventHandler(this.Default2_LoadComplete);
        this.SmartNavigation = true;
    }

    private void Default2_LoadComplete(object sender, EventArgs e)
    {
        new Errores(this).CapturarConfirmacion();
    }
    protected void View4_Activate(object sender, EventArgs e)
    {
        ((MultiView)WebUserControl_ServicioInformacion1.FindControl("MVwInformacion")).ActiveViewIndex = 0;
        ((Menu)WebUserControl_ServicioInformacion1.FindControl("Menu1")).Items[1].Selected = true;
    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Servicio.Salir();
        Response.Redirect("Default.aspx");
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        ((MultiView)WebUserControl_ServicioPago1.FindControl("MVWPago")).ActiveViewIndex = 1;

        MultiView1.ActiveViewIndex = 2;
        ImageButton8.Visible = true;
        ImageButton7.Visible = false;
        
      
        
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        ((MultiView)WebUserControl_ServicioPago1.FindControl("MVWPago")).ActiveViewIndex = 41;
        MultiView1.ActiveViewIndex = 2;
        ImageButton7.Visible = true;
        ImageButton8.Visible = false;
        int CountMenu = ((Menu)WebUserControl_ServicioInformacion1.FindControl("Menu1")).Items.Count;
        for (int i = 0; i < CountMenu; i++)
        {
            if (((Menu)WebUserControl_ServicioInformacion1.FindControl("Menu1")).Items[i].Value == "38" || ((Menu)WebUserControl_ServicioInformacion1.FindControl("Menu1")).Items[i].Value == "8"
                || ((Menu)WebUserControl_ServicioInformacion1.FindControl("Menu1")).Items[i].Value == "50" || ((Menu)WebUserControl_ServicioInformacion1.FindControl("Menu1")).Items[i].Value == "25")
            {

                ((Menu)WebUserControl_ServicioInformacion1.FindControl("Menu1")).Items[i].Enabled = false;

               
            }

        }
    }
    
}
