using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error500 : System.Web.UI.Page
{
    String Texto_error = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Texto_error = Session["Texto_Error"].ToString(); //Request.QueryString["Label1"].ToString();
            Label1.Text = Texto_error.ToString().Trim();
        }
        else
        {
            Texto_error = Session["Texto_Error"].ToString();
            Label1.Text = Texto_error.ToString().Trim();
        }

    }

    public void Mostrar_Error()
    {
        Label1.Visible = true ? (Label1.Visible = false) : (Label1.Visible = true);
    }

    //public void Mostrar(string mensaje)
    //{
    //    String Texto_error = Request.QueryString["Label1"].ToString();

    //    Label1.Text = Texto_error.ToString().Trim();
    //}
    protected void btn_error_Click(object sender, EventArgs e)
    {
        if (Label1.Visible)
            Label1.Visible = false;
        else
            Label1.Visible = true;
    }
}