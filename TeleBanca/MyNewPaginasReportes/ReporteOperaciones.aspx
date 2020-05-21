<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteOperaciones.aspx.cs" Inherits="MyNewPaginasReportes_ReporteOperaciones" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte Operaciones</title>
    <script language="javascript" type="text/javascript" src="../aspnet_client/system_web/4_0_30319/crystalreportviewers13/js/crviewer/crv.js"></script>
 
    <link href="/aspnet_client/System_Web/2_0_50727/crystalreportviewers13/css/default.css" rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/crystalreportviewers13/css/default.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="Reporte_Operaciones" runat="server" AutoDataBind="true" HasCrystalLogo="False" HasToggleGroupTreeButton="false" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
