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

public partial class MyNewPaginasReportes_ReporteOperaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MyDataSet DTS;
        //string ReportPath;
        DateTime Desde = Convert.ToDateTime(Request.QueryString["Desde"]);
        DateTime Hasta = Convert.ToDateTime(Request.QueryString["Hasta"]);
        string operador = Request.QueryString["operador"];
        string operacion = Request.QueryString["tipooper"];
        int Inte = 0;
        Class1 MyClass = new Class1();
        ReportDocument reportOperaciones = new ReportDocument();

        //if (operacion == "Saldos")
        //{
        //    DTS = MyClass.ReporteConsultaSaldos(Desde, Hasta, operador);
        //    foreach (DataRow row in DTS.ConsultaSaldos.Rows)
        //    {
        //        if (row[4].ToString() == "I") Inte++;
        //    }
        //    foreach (DataRow row in DTS.ConsultaSaldos.Rows)
        //    {
        //        row[5] = Inte;
        //    }

        //    reportOperaciones.Load(Server.MapPath("~/Reports/ReporteConsSaldos.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba

        //   // ReportPath = Server.MapPath("~/Reports/ReporteConsSaldos.rpt");
        //}
        //else
        //{
        //    DTS = MyClass.TablaResumenMensual(operador);
        //    reportOperaciones.Load(Server.MapPath("~/Reports/ReporteTransacciones.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
        //    //ReportPath = Server.MapPath("~/Reports/ReporteTransacciones.rpt");
        //}

        //reportOperaciones.SetDataSource(DTS);
        //Reporte_Operaciones.ReportSource = reportOperaciones;
        //Reporte_Operaciones.RefreshReport();

        /*CODIGO ANTERIOR*/
        //CrystalReportSource1.ReportDocument.Load(ReportPath);
        //CrystalReportSource1.ReportDocument.SetDataSource(DTS);
        //CrystalReportViewer1.ReportSource = CrystalReportSource1;
        //CrystalReportViewer1.RefreshReport();

        if (operacion == "Saldos")
        {
            DTS = MyClass.ReporteConsultaSaldos(Desde, Hasta, operador);
            foreach (DataRow row in DTS.ConsultaSaldos.Rows)
            {
                if (row[4].ToString() == "I") Inte++;
            }
            foreach (DataRow row in DTS.ConsultaSaldos.Rows)
            {
                row[5] = Inte;
            }
            reportOperaciones.Load(Server.MapPath("~/Reports/ReporteConsSaldos.rpt"));   
         
        }
        else
        {
            DTS = MyClass.TablaResumenMensual(operador);
            reportOperaciones.Load(Server.MapPath("~/Reports/ReporteTransacciones.rpt"));      
        }

        reportOperaciones.SetDataSource(DTS);
        Reporte_Operaciones.ReportSource = reportOperaciones;
        Reporte_Operaciones.RefreshReport();
        Reporte_Operaciones.EnableParameterPrompt = false;
    }
}
