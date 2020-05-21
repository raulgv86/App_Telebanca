<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteContratos.aspx.cs" Inherits="MyNewPaginasReportes_ReporteContratos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte de Contratos Telebanca</title>
    <script language="javascript" type="text/javascript" src="../aspnet_client/system_web/4_0_30319/crystalreportviewers13/js/crviewer/crv.js"></script>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="Reporte_Contrato" runat="server" AutoDataBind="True" ToolPanelView="None" HasToggleGroupTreeButton="False" Height="50px"
            Width="350px" HasCrystalLogo="False" ReportSourceID="CrystalReportSource1" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="../Reports/ReporteContratos.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
