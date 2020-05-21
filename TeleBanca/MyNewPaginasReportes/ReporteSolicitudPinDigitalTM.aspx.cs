using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyNewPaginasReportes_ReporteSolicitudPinDigitalTM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MyDataSet DTS;
        //string ReportPath;
        DateTime Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
        DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        string operador = Request.QueryString["operador"];
        string operacion = Request.QueryString["tipooper"];
        
        Class1 MyClass = new Class1();
        ReportDocument reportPinDigital = new ReportDocument();


        if (operacion == "ReportePinDigital")
        {
            DTS = MyClass.ReporteSolicitudPinDigitalTM(Desde, Hasta, operador);

            reportPinDigital.Load(Server.MapPath("~/Reports/ReporteSolicitudPinDigital.rpt"));

            reportPinDigital.SetDataSource(DTS.Tables["PinDigitalTM"]);

            Reporte_PinDigitalTM.ReportSource = reportPinDigital;
            Reporte_PinDigitalTM.RefreshReport();
            Reporte_PinDigitalTM.EnableParameterPrompt = false;
            
        }
    }
}