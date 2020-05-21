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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;

public partial class MyNewPaginasReportes_ReporteUltimosMov : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MyDataSet DTS;
        //string ReportPath;
        DateTime Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
        DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        string operador = Request.QueryString["operador"];
        string operacion = Request.QueryString["tipooper"];
        int total = 0;
        Class1 MyClass = new Class1();
        ReportDocument reportConsultUltMov = new ReportDocument();


        if (operacion == "UltimosMovimientos")
        {
            DTS = MyClass.ReporteConsultaUltimosMov(Desde, Hasta, operador);
            
            reportConsultUltMov.Load(Server.MapPath("~/Reports/ReporteConsUltimosMov.rpt"));   
         
            reportConsultUltMov.SetDataSource(DTS);
            Reporte_UltimosMov.ReportSource = reportConsultUltMov;
            Reporte_UltimosMov.RefreshReport();
            Reporte_UltimosMov.EnableParameterPrompt = false;
        }

    }
}
