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
using CrystalDecisions.ReportSource;

public partial class MyNewPaginasReportes_ParteDiario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime Fecha = Convert.ToDateTime(Request.QueryString["fecha"]);
        Class1 MyClass = new Class1();
        MyDataSet DTS = MyClass.ParteDiarioIni(Fecha);

        ReportDocument reportContrato = new ReportDocument();
        reportContrato.Load(Server.MapPath("~/Reports/ParteDiario01.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
        
        reportContrato.SetDataSource(DTS);
        Parte_Diario.ReportSource = reportContrato;
        Parte_Diario.RefreshReport();
        //CrystalReportViewer1.ReportSource = reportContrato;
        //CrystalReportViewer1.RefreshReport();
        
        //string ReportPath = Server.MapPath("../Reports/ParteDiario01.rpt");
        //CrystalReportSource1.ReportDocument.Load(ReportPath);
        ////CrystalReportSource1.ReportDocument.SetParameterValue("Desde", Desde);
        //CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        //CrystalReportViewer1.ReportSource = CrystalReportSource1;
        //CrystalReportViewer1.RefreshReport();
    }
}
