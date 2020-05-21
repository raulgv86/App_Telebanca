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

public partial class MyNewPaginasReportes_ReporteTarjetasCalientes : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //TeleBancaWS.InformeConsultas[] TempIC = (TeleBancaWS.InformeConsultas[])Datos[1];
        DateTime Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
        DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        string operador = Request.QueryString["operador"];
        string descripcion = Request.QueryString["descripcion"];
        Class1 MyClass = new Class1();
        MyDataSet DTS = MyClass.TarjetasCalientes(Desde,Hasta,descripcion,operador);

        ReportDocument reportContrato = new ReportDocument();
        reportContrato.Load(Server.MapPath("~/Reports/ReporteTarjetasCalientes.rpt")); // se tuvo que modificar esta linea, porque de la forma como cargaba el rpt no funcionaba        
        //reportContrato.SetParameterValue("Desde", Desde);
        reportContrato.SetDataSource(DTS.Tables["TarjetasCalientes"]);
        Reporte_Tarjetas_Calientes.ReportSource = reportContrato;
        Reporte_Tarjetas_Calientes.RefreshReport();


        /*CODIGO ANTERIOR*/
        //string ReportPath = Server.MapPath("../Reports/ReporteTarjetasCalientes.rpt");
        //CrystalReportSource1.ReportDocument.Load(ReportPath);
        //CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        //CrystalReportViewer1.ReportSource = CrystalReportSource1;
        //CrystalReportViewer1.RefreshReport();
    }
}
