<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReporteReclamaciones.aspx.cs" Inherits="MyNewPaginasReportes_ReporteReclamaciones" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte de Reclamaciones Telebanca</title>
        <script language="javascript" type="text/javascript" src="../aspnet_client/system_web/4_0_30319/crystalreportviewers13/js/crviewer/crv.js"></script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cr:crystalreportviewer id="Reporte_Reclamaciones" runat="server" autodatabind="True"
            height="50px" reportsourceid="CrystalReportSource1" width="350px" ToolPanelView="None" HasToggleGroupTreeButton="False"></cr:crystalreportviewer>
        <cr:crystalreportsource id="CrystalReportSource1" runat="server">
<Report FileName="Reports\ReporteReclamaciones.rpt"></Report>
</cr:crystalreportsource>
    
    </div>
    </form>
</body>
</html>
