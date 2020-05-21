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


public partial class MyNewPaginasReportes_ReporteOperacionesReversadas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DateTime Fecha = Convert.ToDateTime(Request.QueryString["fecha"]);
        DateTime Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
        DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        Class1 MyClass = new Class1();
        MyDataSet DTS = MyClass.OperacionesReversadas(Desde,Hasta);

        ReportDocument reportContrato = new ReportDocument();
        reportContrato.Load(Server.MapPath("~/Reports/OperacionesReversadas.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
        //reportContrato.SetParameterValue("Desde", Desde);
        reportContrato.SetDataSource(DTS);
        Reporte_Operaciones_Reversadas.ReportSource = reportContrato;
        Reporte_Operaciones_Reversadas.RefreshReport();


        /*CODIGO ANTERIOR*/
        //string ReportPath = Server.MapPath("../Reports/OperacionesReversadas.rpt");
        //CrystalReportSource1.ReportDocument.Load(ReportPath);
        ////CrystalReportSource1.ReportDocument.SetParameterValue("Desde", Desde);
        //CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        //CrystalReportViewer1.ReportSource = CrystalReportSource1;
        //CrystalReportViewer1.RefreshReport();
    }
}
