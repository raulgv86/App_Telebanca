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

public partial class MyNewPaginasReportes_ReporteTarjetas : System.Web.UI.Page
{
    public TeleBancaWS.TeleBancaWS Servicio;

    

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Servicio == null)
            if (Session["Servicio"] != null) Servicio = (TeleBancaWS.TeleBancaWS)Session["Servicio"];
        string Report = Request.QueryString["Report"];
        int type = Convert.ToInt16(Report);
        string ReportPath;
        DataSet DTS = Servicio.ReporteTarjetas(type);
        if (type == 0)
        {
            DTS.DataSetName = "MyDataSet";
            DTS.Tables[0].TableName = "Tarjetas";
            ReportPath = Server.MapPath("~/Reports/ReporteTarjetas.rpt");
            CrystalReportSource1.ReportDocument.Load(ReportPath);
            CrystalReportSource1.ReportDocument.SetDataSource(DTS);
            Reporte_Tarjetas.ReportSource = CrystalReportSource1;
            Reporte_Tarjetas.RefreshReport();
        }
        else
        {
            DTS.DataSetName = "MyDataSet";
            DTS.Tables[0].TableName = "Tarjetas_Asociados";
            ReportPath = Server.MapPath("~/Reports/ReporteTarjetasAsociadas.rpt");
            CrystalReportSource1.ReportDocument.Load(ReportPath);
            CrystalReportSource1.ReportDocument.SetDataSource(DTS);
            Reporte_Tarjetas.ReportSource = CrystalReportSource1;
            Reporte_Tarjetas.RefreshReport();
        }
    }
}
