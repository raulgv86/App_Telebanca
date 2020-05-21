<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteSolicitudPinDigitalTM.aspx.cs" Inherits="MyNewPaginasReportes_ReporteSolicitudPinDigitalTM" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte Solicitud Pin Digital Tarjeta Magnetica</title>

    <script language="javascript" type="text/javascript" src="../aspnet_client/system_web/4_0_30319/crystalreportviewers13/js/crviewer/crv.js"></script>
 
    <link href="/aspnet_client/System_Web/2_0_50727/crystalreportviewers13/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/crystalreportviewers13/css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="Reporte_PinDigitalTM" runat="server" AutoDataBind="true" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"></CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
