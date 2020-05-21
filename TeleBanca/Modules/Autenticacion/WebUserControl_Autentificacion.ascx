<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl_Autentificacion.ascx.cs" Inherits="WebUserControlb" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>


<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />
<link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
    rel="stylesheet" type="text/css" />

<table width="800">
    <tr>
        <td rowspan="3" style="width: 140px;" valign="top">
            <asp:Menu ID="Menu1" runat="server" BackColor="Transparent" BorderColor="Transparent"
                Font-Bold="False" Font-Italic="False" Font-Names="Calibri" Font-Overline="False"
                Font-Size="12pt" Font-Strikeout="False" Font-Underline="False" ForeColor="Black"
                OnMenuItemClick="Menu1_MenuItemClick" Width="135px">
                <StaticSelectedStyle BackColor="#FFFFCC" BorderColor="#FFFFCC" />
                <Items>
                    <asp:MenuItem Enabled="False" Selectable="False" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text=" " Value=" "></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Gesti&#243;n de Autenticaci&#243;n" Value="0"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Captar Matriz" Value="1"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Conciliaciones auxiliares" Value="2"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Crear Lote" Value="3"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Imprimir Pines" Value="5"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Imprimir Tarjetas" Value="8"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Realizar Reporte" Value="11"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#FFFFCC" BorderColor="#FFFFCC" />
            </asp:Menu>
        </td>
        <td colspan="2" rowspan="3" style="width: 628px;" valign="top">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <span style="font-family: Times New Roman Baltic"> 
                        <table width="100%">
                            <tr>
                                <td style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                                    padding-left: 15px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 538px;
                                    padding-top: 14px; border-bottom: #d8d787 2px solid; height: 21px; text-align: justify">
                                    <span><span style="font-size: 14pt"><strong><span style="font-family: Calibri; color: teal;">Gestión de Autenticación<br />
                                        <br />
                                    </span>
                                    </strong><span style="font-family: Calibri"><span lang="ES-TRAD" style="line-height: normal; mso-bidi-font-family: Arial">
                                        <span style="mso-fareast-font-family: 'Times New Roman';
                                            mso-ansi-language: ES-TRAD; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                            mso-bidi-font-family: Arial; mso-bidi-font-size: 10.0pt"><span style="font-size: 14pt">
                                                En esta sección se podrán generar las tarjetas solicitadas por los clientes para
                                                asociarse al pago de servicios de TeleBanca, cada una con matriz y PIN los cuales
                                                se imprimen de forma independiente.
                                                <br />
                                                <br />
                                                También podrá crear lotes con las tarjetas que hallan sido enviadas desde los diferentes
                                                bancos para ser impresos, reimpresos y finalizados para brindar la posibilidad además
                                                de notificar, de forma manual, a los bancos<span style="mso-spacerun: yes">&nbsp; </span>
                                                las tarjetas creadas en caso que no se pudiera realizar automáticamente.<?xml namespace=""
                                                    ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><?xml namespace="" prefix="o" ?><o:p></o:p></span></span></span><br />
                                    </span>
                                    </span></span>
                                </td>
                            </tr>
                        </table>
                    </span>
                </asp:View>
                <asp:View ID="Matriz" runat="server" OnActivate="Matriz_Activate">
                    <table style="height: 62px" width="100%">
                        <tr>
                            <td style="width: 641px">
                                <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid"
                                    width="100%">
                                    <tr>
                                        <td colspan="3" style="height: 22px; background-color: darkslategray">
                                            <span style="font-family: Verdana">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                    ForeColor="#FFFFCC" Text="Captar Matrices"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" rowspan="1" valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td style="text-align: center;" colspan="3">
                                                        <asp:Label ID="Label2" runat="server" Text="Archivos Disponibles:" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;" valign="top">
                                                        &nbsp;<asp:Panel ID="Panel6" runat="server" BorderStyle="Solid" BorderWidth="2px"
                                                            Height="300px" ScrollBars="Vertical" Width="250px">
                                                        <asp:TreeView ID="TreeView1" runat="server" BorderWidth="0px" Height="275px" OnTreeNodeExpanded="TreeView1_TreeNodeExpanded" Width="217px" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" Font-Strikeout="False" ForeColor="#404040" NodeIndent="10" ShowLines="True">
                                                            <RootNodeStyle ImageUrl="~/Images/iconstreeview/xpMyComp.gif" />
                                                            <NodeStyle ImageUrl="~/Images/iconstreeview/Folder.gif" />
                                                            <SelectedNodeStyle BackColor="#C0C0FF" />
                                                        </asp:TreeView>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="text-align: justify;" colspan="2" align="left" valign="top">
                                                        <span style="font-size: 10pt; font-family: Verdana"></span>
                                                        <br />
                                                        <asp:ListBox ID="ListBox1" runat="server" Height="295px" Width="264px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="height: 21px" colspan="2">
                                                        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Encriptar y Guardar" Font-Names="Calibri" Font-Size="11pt" />
                                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click"
                                                            Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px; width: 641px;">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Concilaciones" runat="server" OnActivate="View_Concilaciones_Activate">
                    <table style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid;
                        width: 581px; border-bottom: #d8d787 2px solid">
                        <tr>
                            <td colspan="1" style="background-color: darkslategray">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                    ForeColor="#FFFFCC" Text="Conciliaciones Auxiliares"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <span style="font-size: 14pt; font-family: Calibri"><strong style="text-align: center; color: teal;">
                                    Tipo de Conciliación</strong></span></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                                                <asp:RadioButtonList ID="RadioButtonList_C" runat="server" AutoPostBack="True" Font-Names="Calibri" Font-Size="12pt" OnSelectedIndexChanged="RadioButtonList_C_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="0">Tarjeta Activa</asp:ListItem>
                                                                    <asp:ListItem Value="1">Solicitudes de Baja</asp:ListItem>
                                                                    <asp:ListItem Value="2">Tarjeta Creada</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <span style="font-size: 14pt; font-family: Calibri"><strong style="text-align: center; color: teal;">
                                    Bancos</strong></span></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                                                <asp:DropDownList ID="DropDownList_C_Bancos" runat="server" Width="200px" Font-Names="Calibri" Font-Size="12pt" EnableTheming="True" AutoPostBack="True" DataTextField="[Seleccione el Banco]" OnSelectedIndexChanged="DropDownList_C_Bancos_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                                                <asp:Calendar ID="Calendar_C" runat="server" Width="180px" Visible="False" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" Height="150px" ShowGridLines="True" OnDayRender="Calendar_C_DayRender">
                                                                    <SelectedDayStyle BorderColor="#D8D787" BackColor="#FFC080" Font-Bold="True" />
                                                                    <DayStyle BorderColor="#D8D787" />
                                                                    <NextPrevStyle BorderColor="Transparent" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                    <DayHeaderStyle BorderColor="#D8D787" BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                    <TodayDayStyle BackColor="White" ForeColor="Black" BorderColor="#FFC080" BorderWidth="2px" />
                                                                    <SelectorStyle BackColor="#FFCC66" />
                                                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                    <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                                                <asp:Button ID="Button_C_Aceptar" runat="server" Text="Aceptar" OnClick="Button_C_Aceptar_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp;
                                                                <asp:Button ID="Button_C_Cancelar" runat="server" Text="Cancelar" OnClick="Button_C_Cancelar_Click" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_CrearLotes" runat="server" OnActivate="View_CrearLotes_Activate">
                    <table style="height: 62px" width="100%">
                        <tr>
                            <td style="width: 641px; height: 229px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid"
                                    width="100%">
                                    <tr>
                                        <td colspan="3" style="height: 22px; background-color: darkslategray; width: 592px;">
                                            <span style="font-family: Verdana">
                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                    ForeColor="#FFFFCC" Text="Crear Lote"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" rowspan="1" valign="top" style="height: 19px; width: 592px;">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                        <br />
                                                        <table>
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Sucursal</strong></span></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="DropDownList_CL_Sucursales" runat="server" Width="176px" Height="22px" Font-Names="Calibri" Font-Size="12pt" OnSelectedIndexChanged="DropDownList_CL_Sucursales_SelectedIndexChanged" AutoPostBack="True">
                                                                        <asp:ListItem>Selecione la Sucursal</asp:ListItem>
                                                                        <asp:ListItem>Sucursal01</asp:ListItem>
                                                                        <asp:ListItem>Sucursal02</asp:ListItem>
                                                                        <asp:ListItem>Sucursal03</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center">
                                                                                    <asp:Label ID="Label_CL_DatosSucursal" runat="server" Text="Datos de la Sucursal" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" ForeColor="Teal"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center;">
                                                                                <asp:Label ID="Label_CL_NombreSucursal" runat="server" Text="Nombre:" Font-Names="Calibri" Font-Size="12pt" Font-Bold="True"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center;">
                                                                                <asp:Label ID="Label_CL_Nombre" runat="server" Font-Names="Calibri" Font-Size="12pt" Width="145px"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center;">
                                                                                <asp:Label ID="Label_CL_Cantidad" runat="server" Text="Cantidad:" Font-Names="Calibri" Font-Size="12pt" Font-Bold="True"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center;">
                                                                                <asp:Label ID="Label_CLCantidad" runat="server" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center">
                                                        <asp:Button ID="Button_CL_Aceptar" runat="server" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_CL_Aceptar_Click" Width="70px" />&nbsp; 
                                                                    <asp:Button ID="Button_CL_Cancelar" runat="server" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_CL_Cancelar_Click" Width="70px" /></td>
                                                            </tr>
                                                        </table>
                                                        </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_CrearLotes_Fechas" runat="server" OnActivate="View_CrearLotes_Fechas_Activate">
                    <table style="height: 62px" width="100%">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid"
                                    width="100%">
                                    <tr>
                                        <td colspan="3" style="height: 22px; background-color: darkslategray; width: 597px;">
                                            <span style="font-family: Verdana">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                    ForeColor="#FFFFCC" Text="Crear Lote"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" rowspan="2" valign="top" style="height: 19px; width: 597px;">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" style="width: 544px; text-align: center;" rowspan="3">
                                                        <br />
                                                        <table>
                                                            <tr>
                                                                <td colspan="2" style="text-align: center">
                                                                    <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Datos de la Sucursal</strong></span></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2">
                                                                    <span style="font-family: Calibri"><strong>Número:</strong></span></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2">
                                                        <asp:Label ID="Label_CL_FechasNumero" runat="server" Font-Names="Calibri" Font-Size="12pt" Width="280px"></asp:Label></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2">
                                                                    <span style="font-family: Calibri"><strong>
                                                                                Nombre:</strong></span></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2">
                                                        <asp:Label ID="Label_CL_FechasNombre" runat="server" Font-Names="Calibri" Font-Size="12pt" Width="277px"></asp:Label></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td>
                                                                    <span style="font-family: Calibri"><strong>
                                                        Fechas</strong></span></td>
                                                                <td>
                                                                    <span style="font-family: Calibri"><strong>Cantidad</strong></span></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2">
                                                        <asp:CheckBoxList ID="CheckBoxList_CL_Fechas" runat="server" Height="20px" Width="317px" Font-Names="Calibri" Font-Size="12pt" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList_CL_Fechas_SelectedIndexChanged">
                                                        </asp:CheckBoxList></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td style="text-align: center">
                                                                    <span style="font-family: Calibri"><strong>Total Seleccionado</strong></span></td>
                                                                <td style="text-align: left">
                                                                    <asp:Label ID="Label_CL_FechasTotal" runat="server" Font-Names="Calibri" Font-Size="12pt">0</asp:Label></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2" style="text-align: center">
                                                                    <asp:Button ID="Button_CL_FechasCrear" runat="server" Text="Crear" Width="70px" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_CL_FechasCrear_Click" />
                                                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                                                    <asp:Button ID="Button_CL_FechasCancelar" runat="server" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_CL_FechasCancelar_Click" Width="70px" /></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="Imprimir_Pines" runat="server" OnActivate="Imprimir_Pines_Activate">
                    <table style="height: 62px" width="100%">
                        <tr>
                            <td style="height: 423px" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid"
                                    width="100%">
                                    <tr>
                                        <td colspan="3" style="height: 22px; background-color: darkslategray">
                                            <span style="font-family: Verdana">
                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                    ForeColor="#FFFFCC" Text="Imprimir Lotes de Pines"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" rowspan="2" valign="top" style="height: 249px">
                                            <table style="height: 46px" width="100%">
                                                <tr>
                                                    <td style="height: 15px; text-align: center;" colspan="5">
                                                        <br />
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Lotes</strong></span></td>
                                                                <td>
                                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Cantidad</strong></span></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2">
                                                                                                      <asp:CheckBoxList ID="CheckBoxList_IP_Lotes" runat="server" Width="333px" Height="1px" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList_IP_Lotes_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt">
                                                        </asp:CheckBoxList></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2" style="text-align: center">
                                                                <asp:Panel ID="Panel4" runat="server" EnableTheming="True" Height="300px" ScrollBars="Vertical"
                                                                    Width="125px">
                                                                                                      </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td style="text-align: center">
                                                                    <span style="font-family: Calibri"><strong>Total Seleccionado</strong></span></td>
                                                                <td>
                                                                                <asp:Label ID="Label_IP_Cantidad" runat="server" Text="0" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr style="font-size: 12pt">
                                                                <td colspan="2" style="text-align: center">
                                                        <asp:Button ID="Button_IP_Aceptar" runat="server" Text="Imprimir" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_IP_Aceptar_Click" Width="70px" />&nbsp; 
                                                        <asp:Button ID="Button_IP_Cancelar" runat="server" Text="Cancelar" Width="70px" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_IP_Cancelar_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="font-size: 12pt">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server" OnActivate="View2_Activate">
                    <table style="height: 62px" width="100%">
                        <tr>
                            <td style="width: 641px">
                                <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid; height: 31px;"
                                    width="100%">
                                    <tr>
                                        <td colspan="3" style="height: 22px; background-color: darkslategray">
                                            <span style="font-family: Verdana">
                                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                    ForeColor="#FFFFCC" Text="Reimprimir y Finalizar Lotes de Pines"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" rowspan="2" valign="top" style="text-align: center;">
                                            <br />
                                            <table>
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                        <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Lotes</strong></span></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                            <asp:Panel ID="Panel7" runat="server" Height="350px" ScrollBars="Vertical" Width="170px" BorderWidth="1px">
                                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                                                    Width="145px" Font-Names="Calibri" Font-Size="12pt">
                                                </asp:CheckBoxList></asp:Panel>
                                                    </td>
                                                    <td valign="top">
                                            <asp:Button ID="Button_IP_Reimprimir" runat="server" Text="Reimprimir" Width="120px" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_IP_Reimprimir_Click" /><br />
                                                        <br />
                                            <asp:Button ID="Button_IP_ReimpFinalizar" runat="server" Text="Finalizar" Width="120px" OnClick="Button_IP_ReimpFinalizar_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Marcar Todos"
                                                                        Width="120px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Desmarcar Todos"
                                                                        Width="120px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Reimprimir_Pines3" runat="server" OnActivate="View_Reimprimir_Pines3_Activate"><table style="height: 1px" width="100%">
                    <tr>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 169px">
                            <table style="width: 100%">
                                <tr>
                                    <td colspan="3" style="height: 80px">
                                        <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid; height: 1px;"
                                    width="100%">
                            <tr>
                                <td colspan="3" style="height: 22px; background-color: darkslategray; width: 586px;">
                                    <span style="font-family: Verdana">
                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="#FFFFCC" Text="Reimprimir Pines"></asp:Label></span></td>
                            </tr>
                            <tr>
                                <td colspan="3" rowspan="2" valign="top" style="height: 19px; width: 586px; text-align: center;">
                                    <br />
                                    <table>
                                        <tr>
                                            <td colspan="4">
                    <asp:GridView ID="GridView_IP_Reimprimir" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="2px" CellPadding="4" Font-Names="Calibri" Font-Size="12pt" ForeColor="#E0E0E0" Width="100%" AutoGenerateColumns="False" Height="1px" AllowPaging="True" OnPageIndexChanging="GridView_IP_Reimprimir_PageIndexChanging" ShowFooter="True">
                                <FooterStyle ForeColor="Black" BackColor="#A2A764" />
                                <RowStyle BackColor="White" ForeColor="Black" BorderColor="Brown" BorderStyle="Groove" />
                                <EditRowStyle BorderWidth="2px" />
                                <SelectedRowStyle Font-Bold="True" ForeColor="Black" />
                                <PagerStyle BackColor="#E0E0E0" ForeColor="#330099" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                <AlternatingRowStyle ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="Indice" HeaderText="Indice" />
                                    <asp:BoundField DataField="IdCliente" HeaderText="IdCliente" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                    <asp:BoundField DataField="NumeroTarjeta" HeaderText="N&#250;mero Tarjeta" />
                                </Columns>
                                <PagerSettings PageButtonCount="5" />
                            </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"><strong>DESDE</strong></span></td>
                                            <td>
                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="83px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt">
                                            </asp:DropDownList></td>
                                            <td style="width: 100px; text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"><strong>HASTA</strong></span></td>
                                            <td>
                                            <asp:DropDownList ID="DropDownList2" runat="server" Width="95px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt">
                                            </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                            <asp:Button ID="Button_IP_ReimpAceptar" runat="server" Text="Aceptar" OnClick="Button_IP_ReimpAceptar_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp; 
                                            <asp:Button ID="Button_IP_ReimpCancelar" runat="server" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_IP_ReimpCancelar_Click" CausesValidation="False" Width="70px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View_Imprimir_Tarjetas4" runat="server" OnActivate="View_Imprimir_Tarjetas4_Activate"><table style="height: 62px" width="100%">
                    <tr>
                        <td style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 599px; height: 10px;">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid; height: 14px;"
                                    width="100%">
                                <tr>
                                    <td colspan="3" style="height: 22px; background-color: darkslategray">
                                        <span style="font-family: Verdana">
                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="#FFFFCC" Text="Imprimir Lotes de Tarjetas"></asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="2" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td style="height: 15px; width: 497px; text-align: center;">
                                                    <br />
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <span style="font-size: 14pt; font-family: Calibri"><strong>Lotes</strong></span></td>
                                                            <td>
                                                                <span style="font-size: 14pt; font-family: Calibri"><strong>Cantidad</strong></span></td>
                                                        </tr>
                                                        <tr style="font-size: 12pt">
                                                            <td colspan="2">
                                                                                                                <asp:Panel ID="Panel5" runat="server" Height="300px" ScrollBars="Vertical" Width="100%">
                                                    <asp:CheckBoxList ID="CheckBoxList_IT_Lotes" runat="server" Width="333px" OnSelectedIndexChanged="CheckBoxList_IT_Lotes_SelectedIndexChanged" AutoPostBack="True" Font-Names="Calibri" Font-Size="12pt">
                                                    </asp:CheckBoxList></asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-size: 12pt">
                                                            <td>
                                                                <span style="font-family: Calibri"><strong>Total Seleccionado</strong></span></td>
                                                            <td>
                                                                                <asp:Label ID="Label_IT_Cantidad" runat="server" Text="0" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                        </tr>
                                                        <tr style="font-size: 12pt">
                                                            <td colspan="2" style="text-align: center">
                                            <asp:Button ID="Button_IT_Aceptar" runat="server" Text="Imprimir" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_IT_Aceptar_Click" Width="70px" />&nbsp; 
                                            <asp:Button ID="Button_IT_Cancelar" runat="server" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" OnClick="Button_IT_Cancelar_Click" Width="70px" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View3" runat="server" OnActivate="View3_Activate">
                    <table style="height: 62px" width="100%">
                        <tr>
                            <td style="width: 641px; height: 9px;">
                                <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid; height: 1px;"
                                    width="100%">
                                    <tr>
                                        <td colspan="3" style="height: 22px; background-color: darkslategray">
                                            <span style="font-family: Verdana">
                                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                    ForeColor="#FFFFCC" Text="Reimprimir y Finalizar Lotes de Tarjetas"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" rowspan="2" valign="top" style="text-align: center;">
                                            <br />
                                            <table>
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                        <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Lotes</strong></span></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                                <asp:Panel ID="Panel8" runat="server" Height="350px" ScrollBars="Vertical" Width="170px" BorderWidth="1px">
                                                                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" Width="147px" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt">
                                                                    </asp:CheckBoxList></asp:Panel>
                                                    </td>
                                                    <td valign="top">
                                                                <asp:Button ID="Button_IT_Reimprimir" runat="server" OnClick="Button_IT_Reimprimir_Click"
                                                                    Text="Reimprimir" Width="120px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                                <asp:Button ID="Button_IT_Finalizar" runat="server" Text="Finalizar" Width="120px" OnClick="Button_IT_Finalizar_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                                                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Marcar Todos"
                                                                                            Width="120px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Desmarcar Todos"
                                                                                            Width="120px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View_Reimprimir_Tarjetas" runat="server" OnActivate="View_Reimprimir_Tarjetas_Activate"><table style="height: 62px" width="100%">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid; height: 1px;"
                                    width="100%">
                                <tr>
                                    <td colspan="3" style="height: 22px; background-color: darkslategray">
                                        <span style="font-family: Verdana">
                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="#FFFFCC" Text="Reimprimir Tarjetas"></asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="2" valign="top" style="text-align: center">
                                        &nbsp;<br />
                                        <table>
                                            <tr>
                                                <td colspan="4">
                                                        <asp:GridView ID="GridView_IT_Reimp" runat="server" BackColor="Transparent" BorderColor="Transparent" BorderWidth="2px" CellPadding="4" Font-Names="Calibri" Font-Size="12pt" ForeColor="#E0E0E0" Width="100%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView_IT_Reimp_PageIndexChanging" ShowFooter="True">                                                        <FooterStyle BackColor="#A2A764" BorderStyle="Solid" />
                                                        <RowStyle BackColor="White" ForeColor="Black" BorderColor="Brown" BorderStyle="Groove" /><EditRowStyle BackColor="Red" BorderColor="#FFFF80" BorderStyle="Solid" BorderWidth="2px" />
                                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Black" />
                                                        <PagerStyle BackColor="#E0E0E0" ForeColor="#330099" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                        <AlternatingRowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="indice" HeaderText="Indice" />
                                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                            <asp:BoundField DataField="Apellido" HeaderText="Apellidos" />
                                                            <asp:BoundField DataField="NumeroTarjeta" HeaderText="Numero Tarjeta" />
                                                            <asp:BoundField DataField="idCliente" HeaderText="Cliente" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>DESDE</strong></span></td>
                                                <td colspan="2" style="text-align: left">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>HASTA</strong></span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Height="22px"
                                                                    OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Width="106px">
                                                                </asp:DropDownList></td>
                                                <td colspan="2" style="text-align: left">
                                                                <asp:DropDownList ID="DropDownList4" runat="server" Width="90px">
                                                                </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center">
                                                                <asp:Button ID="Button_IT_ReimpAceptar" runat="server" Text="Aceptar" OnClick="Button_IT_ReimpAceptar_Click" CausesValidation="False" />&nbsp;
                                                                <asp:Button ID="Button_IT_ReimpCancelar" runat="server" Text="Cancelar" OnClick="Button_IT_ReimpCancelar_Click" CausesValidation="False" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View_RealizarReporte" runat="server" OnActivate="View_RealizarReporte_Activate"><table style="height: 62px" width="100%">
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid; height: 37px;"
                                    width="100%">
                                <tr>
                                    <td colspan="3" style="height: 22px; background-color: darkslategray; width: 565px;">
                                        <span style="font-family: Verdana">
                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="#FFFFCC" Text="Realizar Reporte"></asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="2" valign="top" style="width: 565px">
                                        <table width="100%">
                                            <tr>
                                                <td colspan="2" style="height: 15px; text-align: center;">
                                                    <br />
                                                    <table>
                                                        <tr>
                                                            <td colspan="3" style="text-align: center">
                                                                <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Tipos de Reporte</strong></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:RadioButtonList ID="RadioButtonList_RR" runat="server" AutoPostBack="True" Font-Names="Calibri"
                                                                    Font-Size="12pt" OnSelectedIndexChanged="RadioButtonList_RR_SelectedIndexChanged" Width="150px">
                                                                    <asp:ListItem Value="0">Lotes Impresos</asp:ListItem>
                                                                    <asp:ListItem Value="1">Lotes por Imprimir</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="text-align: center">
                                                                <asp:Button ID="Button_RR_Aceptar" runat="server" Font-Names="Calibri" Font-Size="11pt"
                                                                    OnClick="Button_RR_Aceptar_Click" Text="Aceptar" Width="70px" />&nbsp;
                                                                <asp:Button ID="Button_RR_Camcelar" runat="server" Font-Names="Calibri" Font-Size="11pt"
                                                                    Text="Cancelar" OnClick="Button_RR_Camcelar_Click" Width="70px" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View_ReporteCreados" runat="server" OnActivate="View_ReporteCreados_Activate"><table style="height: 62px" width="100%">
                    <tr>
                        <td style="height: 75px">
                            <table border="0" cellpadding="0" cellspacing="0" style="border-right: #d8d787 thin solid;
                                    border-top: #d8d787 thin solid; border-left: #d8d787 thin solid; border-bottom: #d8d787 thin solid; height: 1px;"
                                    width="100%">
                                <tr>
                                    <td colspan="3" style="height: 22px; background-color: darkslategray">
                                        <span style="font-family: Verdana">
                                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="#FFFFCC" Text="Reporte de Lotes Impresos"></asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="2" valign="top">
                                        <table style="height: 66px" width="100%">
                                            <tr style="font-size: 12pt">
                                                <td colspan="2" style="text-align: center;">
                                                    <br />
                                                    <table>
                                                        <tr>
                                                            <td style="text-align: center">
                                                                <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Lotes</strong></span></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: justify;">
                                                                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList3_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt">
                                                                    </asp:CheckBoxList></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center">
                                                                <asp:Button ID="Button_RR_CreadosAceptar" runat="server" OnClick="Button_RR_CreadosAceptar_Click"
                                                                    Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                                <asp:Button ID="Button_RR_CreadosCancelar" runat="server" Text="Cancelar" OnClick="Button_RR_CreadosCancelar_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </asp:View>
                &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
            </asp:MultiView></td>
    </tr>
    <tr>
    </tr>
    <tr>
    </tr>
</table>
