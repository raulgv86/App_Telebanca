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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;


public partial class MyNewPaginasReportes_ReporteContratos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TeleBancaWS.InformeConsultas[] TempIC = (TeleBancaWS.InformeConsultas[])Datos[1];
        DateTime Desde = Convert.ToDateTime( Request.QueryString["Desde"]);
        DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        string por = Request.QueryString["por"];
        string oper = Request.QueryString["oper"];
        string serv = Request.QueryString["serv"];
        Class1 MyClass = new Class1();

        Desde.ToString("yyyy-MM-dd h:mm tt");
        Hasta.ToString("yyyy-MM-dd h:mm tt");
        MyDataSet DTS = MyClass.IContratodeServicios(Desde, Hasta,por,oper,serv);


        /*Para poder cargar el rpt, se tuvo que agregar en el HEAD de la pagina del reporte la sgte linea:
         <script language="javascript" type="text/javascript" src="../aspnet_client/system_web/4_0_30319/crystalreportviewers13/js/crviewer/crv.js"></script>
         
         Para poder agregarla tiene que estar la carpeta: aspnet_client\system_web\4_0_30319\crystalreportviewers13, en el proyecto
         Casi siempre esta en el wwwroot del inetput del sistema operativo, en C:\
         
         */
        ReportDocument reportContrato = new ReportDocument();
        reportContrato.Load(Server.MapPath("~/Reports/ReporteContratos.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
        //reportContrato.SetParameterValue("Desde", Desde);
        reportContrato.SetDataSource(DTS);
        Reporte_Contrato.ReportSource = reportContrato;
        Reporte_Contrato.RefreshReport();



        /*CODIGO ANTERIOR*/
        //string ReportPath = Server.MapPath("~/Reports/ReporteContratos.rpt");
        //CrystalReportSource1.ReportDocument.Load(ReportPath);
        ////CrystalReportSource1.ReportDocument.SetParameterValue("Desde", Desde);
        //CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        //CrystalReportViewer1.ReportSource = CrystalReportSource1;
        //CrystalReportViewer1.RefreshReport();

        //C:\Users\Administrator\Desktop\BT\Telebanca\Reports\ReporteContratos.rpt
    }
}
