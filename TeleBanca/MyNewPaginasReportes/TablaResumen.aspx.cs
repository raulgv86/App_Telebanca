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


public partial class MyNewPaginasReportes_TablaResumen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Anterior

        //MyDataSet DTS;
        //string ReportPath;
        //string Fecha = Request.QueryString["anno"];
        //Class1 MyClass = new Class1();
        //if (Fecha == null)
        //{
        //    DTS = MyClass.TablaResumenAnual();
        //    ReportPath = Server.MapPath("../Reports/TablaResumenAnual.rpt");
        //}
        //else
        //{
        //    DTS = MyClass.TablaResumenMensual(Fecha);
        //    ReportPath = Server.MapPath("../Reports/TablaResumenMensual.rpt");
        //}

        //CrystalReportSource1.ReportDocument.Load(ReportPath);
        //CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        //Reporte_Resumen.ReportSource = CrystalReportSource1;
        //Reporte_Resumen.RefreshReport();

        ////ReportDocument reportResumen = new ReportDocument();
        ////reportResumen.Load(Server.MapPath(ReportPath)); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
        //////reportContrato.SetParameterValue("Desde", Desde);
        ////reportResumen.SetDataSource(DTS);
        ////Reporte_Resumen.ReportSource = reportResumen;
        ////Reporte_Resumen.RefreshReport();

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        MyDataSet DTS = new MyDataSet();
        string ReportPath;
        string Fecha = Request.QueryString["anno"];
        Class1 MyClass = new Class1();
        ReportDocument reportResumen = new ReportDocument();

        if (Fecha == null)
        {
            DTS = MyClass.TablaResumenAnual();
            reportResumen.Load(Server.MapPath("~/Reports/TablaResumenAnual.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
            reportResumen.SetDataSource(DTS);
            Reporte_Resumen.ReportSource = reportResumen;
            Reporte_Resumen.RefreshReport();
        }
        else
        {
            DTS = MyClass.TablaResumenMensual(Fecha);
            reportResumen.Load(Server.MapPath("~/Reports/TablaResumenMensual.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
            reportResumen.SetDataSource(DTS);
            Reporte_Resumen.ReportSource = reportResumen;
            Reporte_Resumen.RefreshReport();
        }

        /*Para poder cargar el rpt, se tuvo que agregar en el HEAD de la pagina del reporte la sgte linea:
         <script language="javascript" type="text/javascript" src="../aspnet_client/system_web/4_0_30319/crystalreportviewers13/js/crviewer/crv.js"></script>
         
         Para poder agregarla tiene que estar la carpeta: aspnet_client\system_web\4_0_30319\crystalreportviewers13, en el proyecto
         Casi siempre esta en el wwwroot del inetput del sistema operativo, en C:\
         
         */
    }
}
