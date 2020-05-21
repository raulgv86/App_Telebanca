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

public partial class MyNewPaginasReportes_ReporteDatosTarjeta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DateTime Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
        //DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        //string operador = Request.QueryString["operador"];
        //string descripcion = Request.QueryString["descripcion"];
        string tarjeta = Request.QueryString["tarjeta"];
        Class1 MyClass = new Class1();
        MyDataSet DTS = MyClass.DatosTarjeta(tarjeta);
        string ReportPath = Server.MapPath("../Reports/DatosTarjeta.rpt");
        CrystalReportSource1.ReportDocument.Load(ReportPath);
        CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        Reporte_Datos_Tarjeta.ReportSource = CrystalReportSource1;
        Reporte_Datos_Tarjeta.RefreshReport();
    }
}
