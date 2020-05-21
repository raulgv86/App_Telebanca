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
        ReportDocument reportLocalizacionTransf = new ReportDocument();


        if (operacion == "ReportLocalizaTransf")
        {
            DTS = MyClass.ReporteLocalizaTransfExterior(Desde, Hasta, operador);

            reportLocalizacionTransf.Load(Server.MapPath("~/Reports/ReporteLocalizacionTransfExt.rpt"));

            reportLocalizacionTransf.SetDataSource(DTS.Tables["ReportLocalizaTransf"]);
            Reporte_LocalizaTransf.ReportSource = reportLocalizacionTransf;
            Reporte_LocalizaTransf.RefreshReport();
            Reporte_LocalizaTransf.EnableParameterPrompt = false;
        }

    }
}
