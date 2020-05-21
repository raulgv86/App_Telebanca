<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Default2" Async="true" %>

<%@ Register Assembly="msgBox" Namespace="BunnyBear" TagPrefix="cc1" %>

<%@ Register Src="Modules/Inicio/WebUserControl.ascx" TagName="WebUserControl" TagPrefix="uc6" %>

<%@ Register Src="Modules/Administracion/WebUserControl_Administracion.ascx" TagName="WebUserControl_Administracion"
    TagPrefix="uc4" %>

<%@ Register Src="Modules/Administracion/WebUserControl_Administracion.ascx" TagName="WebUserControl_Administracion"
    TagPrefix="uc1" %>

<%@ Register Src="Modules/Autenticacion/WebUserControl_Autentificacion.ascx" TagName="WebUserControl_Autentificacion"
    TagPrefix="uc2" %>
<%@ Register Src="Modules/Pago/WebUserControl_ServicioPago.ascx" TagName="WebUserControl_ServicioPago"
    TagPrefix="uc3" %>
<%@ Register Src="Modules/Informacion/WebUserControl_ServicioInformacion.ascx" TagName="WebUserControl_ServicioInformacion"
    TagPrefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Banca Telefónica               
    </title>
<script language="javascript" type="text/javascript" src="Scripts/JScript.js"></script>
<script language="javascript" type="text/javascript">

<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
function IMG1_onclick() {

}


//-->
</script>

   <%-- <link href="../../../../../Styles/Estilos.css"
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
        rel="stylesheet" type="text/css" />--%>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0px; clip: rect(0px 0px 0px 0px); font-size: 12pt; text-align: left;" onload="MM_preloadImages('Imagenes/Botones_Barra_Estado/temporal.png','Imagenes/Botones_Barra_Estado/bot_peque&ntilde;o_ sobre.png')">
    <form id="form1" runat="server">                
        <div style="margin: 0px; width: 100px; clip: rect(0px 0px 0px 0px); height: 614px">
                <table style="width: 794px">
                <tr>
                    <td colspan="4">
                        <img id="IMG1" src="Images/Imagenes/telebanca_portada.png" style="width: 825px; height: 110px" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 2px; background-color: darkslategray">
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="width: 368px; font-weight: bold;">
                    <iframe frameborder="0" width="1%" height="1px" src="HTML/saludo.htm" style="width: 127px; height: 30px;margin-top:-20px; font-weight: bold;" scrolling="no"></iframe>
                        <asp:Label ID="LblShowNombre" runat="server" Font-Bold="True" Font-Names="Calibri"
                            Font-Size="12pt" ForeColor="Teal" Text="Nombre"></asp:Label></td>
                    <td colspan="2" style="text-align: left; font-weight: bold;">
                     <iframe frameborder="0" width="100%" height="25px" src="HTML/fecha.htm" style="width: 69%; height: 30px; margin-top:-20px;font-weight: bold;" scrolling="no"></iframe>
                     <iframe frameborder="0" width="100%" height="25px" src="HTML/reloj.html" style="width: 30%; height: 30px; margin-top:-20px;font-weight: bold;" scrolling="no"></iframe>     </td>
                    <td style="text-align: right; width: 130px;">
                        <asp:ImageButton ID="ImageButton6" runat="server" Height="20px" ImageAlign="Right"
                            ImageUrl="~/Images/Imagenes/icono cerrar seción.jpg" OnClick="ImageButton6_Click" /><asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Names="Calibri"
                            Font-Overline="False" Font-Size="11pt" ForeColor="#00C000" OnClick="LinkButton2_Click" CausesValidation="False" Width="100px">Cerrar Sesión</asp:LinkButton></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 2px; background-color: darkslategray" align="right">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Imagenes/boton_inicio.png" Height="30px" OnClick="ImageButton1_Click" Width="140px" />
                        <asp:ImageButton ID="ImageButton4" runat="server" Height="30px" ImageUrl="~/Images/Imagenes/boton_informacion.png"
                            OnClick="ImageButton4_Click" Width="140px" />
                            <asp:ImageButton ID="ImageButton5" runat="server" Height="30px" ImageUrl="~/Images/Imagenes/boton_autenticacion.png"
                                OnClick="ImageButton5_Click" Width="140px" />
                <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="~/Images/Imagenes/boton_administracion.png"
                    OnClick="ImageButton2_Click" Width="140px" />&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Height="30px" ImageUrl="~/Images/Imagenes/boton_pago.png"
                    OnClick="ImageButton3_Click" Width="140px" />&nbsp;
                        <asp:ImageButton ID="ImageButton7" runat="server" Height="29px" ImageUrl="~/Images/Imagenes/tele0.png"
                            OnClick="ImageButton7_Click" ToolTip="Conectar Cliente" Width="70px" />&nbsp;<asp:ImageButton
                                ID="ImageButton8" runat="server" Height="29px" ImageUrl="~/Images/Imagenes/tele1.png"
                                OnClick="ImageButton8_Click" ToolTip="Desconectar Cliente" Visible="False" Width="70px" /></td>
                </tr>
                <tr>
                    <td colspan="4">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <uc6:WebUserControl ID="WebUserControl1" runat="server" OnLoad="WebUserControl1_Load" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <uc4:WebUserControl_Administracion ID="WebUserControl_Administracion1" runat="server" />
                </asp:View>
                <asp:View ID="View3" runat="server">
                    &nbsp;<uc3:WebUserControl_ServicioPago ID="WebUserControl_ServicioPago1" runat="server" />
                </asp:View>
                <asp:View ID="View4" runat="server" OnActivate="View4_Activate">
                    <uc5:WebUserControl_ServicioInformacion ID="WebUserControl_ServicioInformacion1"
                        runat="server" />
                </asp:View>
                <asp:View ID="View5" runat="server">
                    <uc2:WebUserControl_Autentificacion ID="WebUserControl_Autentificacion1" runat="server" />
                </asp:View>
            </asp:MultiView></td>
                </tr>
                <tr>
                    <td style="width: 368px; height: 21px">
        <cc1:msgBox ID="Mensajes" runat="server" />
                    </td>
                    <td style="width: 130px; height: 21px">
        <input
            id="HdnWhoConfirm" runat="server" style="width: 15px" type="hidden" /></td>
                    <td style="width: 363px; height: 21px">
                    </td>
                    <td style="width: 97px; height: 21px">
                    </td>
                </tr>
                    <tr>
                        <td colspan="4" style="height: 2px; background-color: darkslategray">
                        </td>
                    </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <span style="font-family: Calibri"><span style="font-size: 14pt"><strong><span style="color: green; font-size: 10pt;">Todos
                            los Derechos Reservados&nbsp; 2006-<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span><br />
                        </strong>
                            <span lang="ES" style="color: #c89800; font-family: 'Copperplate Gothic Bold','sans-serif';
                                mso-ansi-language: ES">Banco Central de Cuba<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                    prefix="o" ?><o:p></o:p></span></span></span></td>
                </tr>
                    <tr style="font-size: 12pt">
                        <td colspan="4" style="height: 2px; background-color: darkslategray">
                        </td>
                    </tr>
            </table>
        </div>
    </form>
</body>
</html>
