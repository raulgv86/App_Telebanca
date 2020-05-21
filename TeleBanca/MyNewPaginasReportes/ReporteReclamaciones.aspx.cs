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

public partial class MyNewPaginasReportes_ReporteReclamaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TeleBancaWS.InformeConsultas[] TempIC = (TeleBancaWS.InformeConsultas[])Datos[1];
        DateTime Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
        DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        //string por = Request.QueryString["por"];
        Class1 MyClass = new Class1();
        MyDataSet DTS = MyClass.IReclamaciones(Desde, Hasta);

        ReportDocument reportReclama = new ReportDocument();
        reportReclama.Load(Server.MapPath("~/Reports/ReporteReclamaciones.rpt"));
        reportReclama.SetDataSource(DTS);
        Reporte_Reclamaciones.ReportSource = reportReclama;
        Reporte_Reclamaciones.RefreshReport();

        


        /*CODIGO ANTERIOR*/
        //string ReportPath = Server.MapPath("../Reports/ReporteReclamaciones.rpt");
        //CrystalReportSource1.ReportDocument.Load(ReportPath);
        //CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        //CrystalReportViewer1.ReportSource = CrystalReportSource1;
        //CrystalReportViewer1.RefreshReport();
    }
}
