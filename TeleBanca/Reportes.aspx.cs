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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class Reports_Reporte1 : System.Web.UI.Page
{
    public TeleBancaWS.TeleBancaWS Servicio;
    public object[] Datos;

    protected void Page_Load(object sender, EventArgs e)
    {        
        Datos = (object[])Application["Datos"];        
        string Reporte = Datos[0].ToString();


        string ReportPath = ""; 
        switch (Reporte)
        {
            case "ConsultasAE":
                TeleBancaWS.InformeConsultas[] TempIC = (TeleBancaWS.InformeConsultas[])Datos[1];
                ReportPath = Server.MapPath("Reports/ConsultasAE.rpt");
                CRSConsultasAE.ReportDocument.Load(ReportPath);
                CRSConsultasAE.ReportDocument.SetDataSource(TempIC);
                CrystalReportViewer1.ReportSource = CRSConsultasAE;
                CrystalReportViewer1.RefreshReport();                
                break;

            case "ConsultasAEA":
                TeleBancaWS.InformeConsultas[] TempICA = (TeleBancaWS.InformeConsultas[])Datos[1];
                ReportPath = Server.MapPath("Reports/ConsultasAEA.rpt");
                CRSConsultasAEA.ReportDocument.Load(ReportPath);
                CRSConsultasAEA.ReportDocument.SetDataSource(TempICA);
                CrystalReportViewer1.ReportSource = CRSConsultasAEA;
                CrystalReportViewer1.RefreshReport();
                break;

            case "ConsultasIP":
                TeleBancaWS.InformeConsultas[] TempIC1 = (TeleBancaWS.InformeConsultas[])Datos[1];
                ReportPath = Server.MapPath("Reports/ConsultasIP.rpt");
                CRSConsultasIP.ReportDocument.Load(ReportPath);
                CRSConsultasIP.ReportDocument.SetDataSource(TempIC1);
                CrystalReportViewer1.ReportSource = CRSConsultasIP;
                CrystalReportViewer1.RefreshReport();
                break;

            case "ConsultasIPA":
                TeleBancaWS.InformeConsultas[] TempIC1A = (TeleBancaWS.InformeConsultas[])Datos[1];
                ReportPath = Server.MapPath("Reports/ConsultasIPA.rpt");
                CRSConsultasIPA.ReportDocument.Load(ReportPath);
                CRSConsultasIPA.ReportDocument.SetDataSource(TempIC1A);
                CrystalReportViewer1.ReportSource = CRSConsultasIPA;
                CrystalReportViewer1.RefreshReport();
                break;
               // CRSConsultasAE.ReportDocument.p

            case "GeneralDetalladoAE":
                TeleBancaWS.DatosAgenda[] TempDA = (TeleBancaWS.DatosAgenda[])Datos[1];
                ReportPath = Server.MapPath("Reports/GeneralDetalladoAE.rpt");
                CRSGeneralDetalladoAE.ReportDocument.Load(ReportPath);
                CRSGeneralDetalladoAE.ReportDocument.SetDataSource(TempDA);
                CrystalReportViewer1.ReportSource = CRSGeneralDetalladoAE;
                CrystalReportViewer1.RefreshReport();
                break;

            case "GeneralDetalladoIP":
                TeleBancaWS.DatosProcesos[] TempDP = (TeleBancaWS.DatosProcesos[])Datos[1];
                ReportPath = Server.MapPath("Reports/GeneralDetalladoIP.rpt");
                CRSGeneralDetalladoIP.ReportDocument.Load(ReportPath);
                CRSGeneralDetalladoIP.ReportDocument.SetDataSource(TempDP);
                CrystalReportViewer1.ReportSource = CRSGeneralDetalladoIP;
                CrystalReportViewer1.RefreshReport();
                break;

            case "GeneralResumen":
                TeleBancaWS.DatosResumen[] TempDR = (TeleBancaWS.DatosResumen[])Datos[1];
                ReportPath = Server.MapPath("Reports/GeneralResumen.rpt");
                CRSGeneralResumen.ReportDocument.Load(ReportPath);
                CRSGeneralResumen.ReportDocument.SetDataSource(TempDR);
                CrystalReportViewer1.ReportSource = CRSGeneralResumen;
                CrystalReportViewer1.RefreshReport();
                break;

            case "PersonalDetalladoAE":
                TeleBancaWS.DatosAgenda[] TempDA1 = (TeleBancaWS.DatosAgenda[])Datos[1];
                ReportPath = Server.MapPath("Reports/PersonalDetalladoAE.rpt");
                CRSPersonalDetalladoAE.ReportDocument.Load(ReportPath);
                CRSPersonalDetalladoAE.ReportDocument.SetDataSource(TempDA1);
                CrystalReportViewer1.ReportSource = CRSPersonalDetalladoAE;
                CrystalReportViewer1.RefreshReport();
                break;

            case "PersonalDetalladoIP":
                TeleBancaWS.DatosProcesos[] TempDP1 = (TeleBancaWS.DatosProcesos[])Datos[1];
                ReportPath = Server.MapPath("Reports/PersonalDetalladoIP.rpt");
                CRSPersonalDetalladoIP.ReportDocument.Load(ReportPath);
                CRSPersonalDetalladoIP.ReportDocument.SetDataSource(TempDP1);
                CrystalReportViewer1.ReportSource = CRSPersonalDetalladoIP;
                CrystalReportViewer1.RefreshReport();
                break;

            case "PersonalResumen":
                TeleBancaWS.DatosResumen[] TempDR1 = (TeleBancaWS.DatosResumen[])Datos[1];
                ReportPath = Server.MapPath("Reports/PersonalResumen.rpt");
                CRSPersonalResumen.ReportDocument.Load(ReportPath);
                CRSPersonalResumen.ReportDocument.SetDataSource(TempDR1);
                CrystalReportViewer1.ReportSource = CRSPersonalResumen;
                CrystalReportViewer1.RefreshReport();
                break;

            case "ReporteTImpresas":
                TeleBancaWS.DatosTarjetas[] TempDT1 = (TeleBancaWS.DatosTarjetas[])Datos[1];
                ReportPath = Server.MapPath("Reports/TarjetasImpresas.rpt");
                CRSTarjetasImpresas.ReportDocument.Load(ReportPath);
                CRSTarjetasImpresas.ReportDocument.SetDataSource(TempDT1);
                CrystalReportViewer1.ReportSource = CRSTarjetasImpresas;
                CrystalReportViewer1.RefreshReport();
                break;

            case "ReportePorImprimir":
                TeleBancaWS.Datoslote[] TempDT2 = (TeleBancaWS.Datoslote[])Datos[1];
                ReportPath = Server.MapPath("Reports/LotesPorImprimir.rpt");
                CRSLotesPorImprimir.ReportDocument.Load(ReportPath);
                CRSLotesPorImprimir.ReportDocument.SetDataSource(TempDT2);
                CrystalReportViewer1.ReportSource = CRSLotesPorImprimir;
                CrystalReportViewer1.RefreshReport();
                break; 

            case "ReporteTransacciones":
                //ReportDocument reportContrato = new ReportDocument();
                //TeleBancaWS.ReporteTransacciones[] tempRT = (TeleBancaWS.ReporteTransacciones[])Datos[1];
                //reportContrato.Load(Server.MapPath("~/Reports/Transaccion.rpt")); // se tuvo que modificar esta linea, porque como cargaba el rpt no funcionaba
                ////reportContrato.SetParameterValue("Desde", Desde);
                //reportContrato.SetDataSource(tempRT);
                //CRSTransaccion.ReportSource = reportContrato;
                //CRSTransaccion.RefreshReport();



                /*CODIGO ANTERIOR*/
                TeleBancaWS.ReporteTransacciones[] tempRT = (TeleBancaWS.ReporteTransacciones[])Datos[1];
                ReportPath = Server.MapPath("Reports/Transaccion.rpt");
                CRSTransaccion.ReportDocument.Load(ReportPath);
                CRSTransaccion.ReportDocument.SetDataSource(tempRT);
                string mon = Session["siglasmon"].ToString();
                CRSTransaccion.ReportDocument.SetParameterValue("mon", mon);
                CrystalReportViewer1.ReportSource = CRSTransaccion;
                CrystalReportViewer1.RefreshReport();
                break;

        }






    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}
