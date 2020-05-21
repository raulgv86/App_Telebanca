<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reports_Reporte1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script language=javascript type="text/javascript">
function Comienzo()
{
  document.writeln(hey);
  window.focus();
}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reportes</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    
        <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
            rel="stylesheet" type="text/css" />
        <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
            rel="stylesheet" type="text/css" />
</head>
<body onactivate="javascript:OnExit()">
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="50px" Width="350px" HasCrystalLogo="False" PrintMode="ActiveX" ReuseParameterValuesOnRefresh="True" />
        <CR:CrystalReportSource ID="CRSConsultasAE" runat="server">
            <Report FileName="Reports\ConsultasAE.rpt">
            </Report>
        </CR:CrystalReportSource>
        &nbsp;
        <CR:CrystalReportSource ID="CRSGeneralDetalladoAE" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSGeneralDetalladoIP" runat="server">
        </CR:CrystalReportSource>     
        <CR:CrystalReportSource ID="CRSGeneralResumen" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSPersonalDetalladoAE" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSPersonalDetalladoIP" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSPersonalResumen" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSConsultasAEA" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSConsultasIPA" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSLotesPorImprimir" runat="server">
            <Report FileName="Reports\LotesPorImprimir.rpt">
            </Report>
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSTarjetasImpresas" runat="server">
            <Report FileName="Reports\TarjetasImpresas.rpt">
            </Report>
        </CR:CrystalReportSource>
        &nbsp;
        <CR:CrystalReportSource ID="CRSConsultasIP" runat="server">
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CRSTransaccion" runat="server">
            <Report FileName="Reports\Transaccion.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>   
    </form>
</body>
</html>
