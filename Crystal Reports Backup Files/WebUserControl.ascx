<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="Modules_Inicio_WebUserControl" %>
<%@ Register Assembly="msgBox" Namespace="BunnyBear" TagPrefix="cc1" %>
<table width="650">
    <tr>
        <td align="center" colspan="1" rowspan="3" style="text-align: justify" valign="top">
            <asp:Menu ID="Menu1" runat="server" BackColor="Transparent" BorderColor="Transparent"
                Font-Bold="False" Font-Italic="False" Font-Names="Calibri" Font-Overline="False"
                Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" ForeColor="Black"
                OnMenuItemClick="Menu1_MenuItemClick" Width="200px">
                <StaticSelectedStyle BackColor="#FFFFCC" BorderColor="#FFFFCC" BorderStyle="Outset" BorderWidth="3px" />
                <Items> 
                    <asp:MenuItem Enabled="False" Selectable="False" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text=" " Value=" "></asp:MenuItem>
                    <asp:MenuItem Selected="True" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Inicio" Value="0"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Acceso Ayuda " Value="2"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Modificar Clave " Value="1"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#FFFFCC" />
            </asp:Menu>
        </td>
        <td align="center" colspan="2" rowspan="3" style="width: 500px; text-align: justify;" valign="top" id="HdnWhoConfirm">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; text-align: center">
                                <span style="font-family: Calibri">
                                    <table width="570">
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="font-size: 24pt; color: teal; text-align: center">
                                                <span style="font-size: 26pt; color: darkcyan">
                                                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></span></td>
                                            <td style="font-size: 24pt; width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 235px; text-align: justify" colspan="3">
                                                <strong>
                                                    <br />
                                                    <span style="font-size: 14pt; color: black; font-family: Trebuchet MS;">
                                                    Beneficios</span></strong><br />
                                                <ul>
                                                    <li style="text-align: justify"><span style="color: black; font-family: Trebuchet MS">
                                                        Es un servicio SIN COSTO.</span></li><li style="text-align: justify"><span style="color: black; font-family: Trebuchet MS;
                                                        text-align: justify">Puede realizar sus operaciones bancarias, desde cualquier
                                                        línea telefónica.</span></li><li style="text-align: justify"><span style="color: black; font-family: Trebuchet MS">
                                                        Su utilización evita la pérdida de tiempo.</span></li><li style="text-align: justify"><span style="color: black; font-family: Trebuchet MS">
                                                        Cuenta con un&nbsp; respaldo tecnológico, que la convierte
                                                        en un servicio seguro, ágil y fácil.</span></li></ul>
                                                <p>
                                                    &nbsp;</p>
                                            </td>
                                        </tr>
                                        <tr style="font-size: 12pt">
                                            <td colspan="3" style="text-align: center">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red"
                                                    Visible="False"></asp:Label><asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True"
                                                        Font-Names="Calibri" ForeColor="#00C000" OnClick="LinkButton1_Click" Visible="False">aquí</asp:LinkButton>
                                                <strong><span style="color: red">
                                                    <asp:Label ID="Label6" runat="server" Text="!!!" Visible="False"></asp:Label></span></strong></td>
                                        </tr>
                                        <tr style="font-size: 12pt">
                                            <td colspan="3" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <br />
                                </span>
                                <asp:Panel ID="Panel2" runat="server" Height="50px" Visible="False" Width="125px">
                                    <table style="width: 540px; text-align: center">
                                    <tr>
                                        <td style="width: 100px; color: #ffffcc; background-color: darkslategray; text-align: left">
                                            <span style="font-size: 14pt; font-family: Calibri; height: 22px; width: 228px;">
                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="White"
                                                    Text="Label"></asp:Label>&nbsp;
                                                <asp:Label ID="Label1" runat="server" Text="Usuarios en Línea" Font-Names="Calibri" Height="22px" Width="150px"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; text-align: justify">
                                            <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical" Width="540px">
                                                <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                                    BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black"
                                                    GridLines="Horizontal" Height="200px" Width="520px" Font-Names="Calibri" OnDataBound="GridView1_DataBound" ShowFooter="True" Visible="False">
                                                    <FooterStyle BackColor="#A2A764" />
                                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; background-color: darkslategray">
                                            &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                                SelectCommand="SELECT nombre AS Usuario FROM TLB_Usuario WHERE (Activo = 1) AND (nombre <> 'Administrador del Sistema')">
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                                &nbsp;<br />
                                </td>
                        </tr>
                    </table>
                    <br />
                </asp:View>
                &nbsp;<asp:View ID="View2" runat="server" OnActivate="View2_Activate">
                    <table style="width: 590px">
                        <tr>
                            <td align="left" style="background-color: darkslategray; text-align: center;">
                                <strong><span><span style="font-family: Calibri"><span style="font-size: 16pt; color: #ffffcc">
                                    <span style="color: yellow; background-color: darkslategray">
                                        <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Strikeout="False"
                                            ForeColor="#FFFFCC" Height="22px" Text="Cambiar Contraseña" Width="200px"></asp:Label></span></span></span></span></strong></td>
                        </tr>
                        <tr style="font-family: Times New Roman; font-size: 14pt;">
                            <td style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid; width: 666px; border-bottom: #d8d787 2px solid; text-align: center">
                                <br />
                                <table style="width: 540px; text-align: center;">
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td align="left" colspan="3" style="height: 21px; background-color: #a2a764">
                                        </td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td align="left" style="width: 21493px; height: 26px">
                                            <span style="font-size: 14pt; font-family: Calibri"><strong>Contraseña Actual:&nbsp;</strong></span></td>
                                        <td style="height: 26px; text-align: left;">
                                <asp:TextBox ID="TbxPassAnterior" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
                                        <td rowspan="3" style="width: 7280px; text-align: center">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Imagenes/cambiar_contrasenna.png" /></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 21493px; height: 18px">
                                            <span style="font-size: 14pt; font-family: Calibri"><strong>Nueva Contraseña:</strong></span></td>
                                        <td style="height: 18px">
                                <asp:TextBox ID="TbxPassNueva" runat="server" TextMode="Password" Width="150px"></asp:TextBox><span
                                    style="font-size: 10pt; font-family: Verdana">&nbsp; </span>
                                </td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td align="left" style="width: 21493px; height: 21px">
                                            <span><span style="font-family: Calibri"><span style="font-size: 14pt"><strong><span>
                                            Confirmar Nueva Contraseña:</span>&nbsp;</strong></span></span></span></td>
                                        <td style="height: 21px">
                                <asp:TextBox ID="TbxPassConfirm" runat="server" TextMode="Password" OnDisposed="Button1_Click" Width="150px"></asp:TextBox>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 21493px; height: 21px">
                                        </td>
                                        <td style="height: 21px">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="Small" Height="23px" Width="70px" />&nbsp;
                                                    <asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click1"
                                                            Style="left: 0px; position: relative; top: 0px" Text="Cancelar" Width="70px" Font-Names="Calibri" Font-Size="Small" Height="23px" /></td>
                                        <td style="width: 7280px; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 21px; background-color: #a2a764">
                                            <strong style="color: #ffffcc"><span style="font-family: Calibri">Selección de una buena
                                                contraseña</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 21px; text-align: justify">
                                            <span style="color: teal; font-family: Calibri">Crear una contraseña exclusiva te ayudará
                                                a evitar el acceso no autorizado de tu usuario en TeleBanca. A continuación te ofrecemos
                                                algunos consejos para crear una buena contraseña y mantenerla segura:</span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 21px">
                                            <li style="text-align: justify"><span style="font-family: Calibri">Da rienda suelta
                                                a tu imaginación. No utilices palabras que figuren en el diccionario. </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">Utiliza al menos
                                                ocho caracteres diferentes.&nbsp;</span></li><li style="text-align: justify"><span style="font-family: Calibri">No utilices una contraseña
                                                que ya hayas usado en otro sitio. </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">No utilices patrones
                                                de teclado (asdf) ni una secuencia ordenada de números (1234). </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">Crea un acrónimo.
                                                No utilices uno muy conocido, PNR, UNE, ETECSA, SBN, PCC, UJC, BCC, etc, combínalo
                                                con números y signos de puntuación. </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">No utilices contraseñas
                                                <span>como tu nombre, tu usuario, carné de identidad, edad, nombre de algún familiar,
                                                    etc. </span></span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">Incluye signos de
                                                puntuación y números. Utiliza una combinación de letras mayúsculas y minúsculas,
                                                e incluye números. </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">Incluye elementos
                                                similares que puedan sustituirse entre sí, como el número cero en lugar de la letra
                                                "O" o el símbolo de dólar ($) en lugar de la letra "S". </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">Incluye sustituciones
                                                fonéticas, como "Hoy T quiero más K ayer" en lugar de "Hoy te quiero más que ayer".
                                            </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">Evita que la contraseña
                                                sólo incluya números, letras mayúsculas o letras minúsculas. </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">Utiliza métodos para
                                                recopilar letras y números al azar, como abrir un libro, mirar la chapa de un vehículo
                                                o anotar la tercera letra de las primeras diez palabras que leas. </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">No repitas caracteres
                                                (aa11). </span></li>
                                            <li style="text-align: justify"><span style="font-family: Calibri">No utilices una contraseña
                                                que se ofrezca como ejemplo de contraseña segura. </span></li>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 21493px; height: 21px">
                                        </td>
                                        <td style="height: 21px">
                                        </td>
                                        <td style="width: 7280px; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 21px; background-color: #a2a764">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: darkslategray;">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View5" runat="server">
                    <table style="width: 589px">
                        <tr>
                            <td align="left" style="background-color: darkslategray; text-align: left;">
                                <strong><span style="font-family: Verdana; height: 22px; background-color: darkslategray;">
                                    <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="16pt" ForeColor="#FFFFCC"
                                        Text=" Ayuda" Width="33px"></asp:Label></span>&nbsp;</strong></td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: justify">
                                <span style="font-size: 10pt; font-family: Verdana"><span style="font-size: 14pt;
                                    font-family: Calibri">El Centro de Llamadas,
                                    centrará su actividad en el Pago de Servicios a poseedores de Cuentas de Ahorro
                                    asociados a Tarjetas Débito RED del Sistema Bancario Nacional a través de los teleoperadores, los
                                    cuales ejecutarán las operaciones bancarias a partir de las indicaciones
                                    recibidas del cliente por vía telefónica.<br />
                                </span>
                                    <br />
                                    <br />
                                </span>
                                <p class="MsoNormal" style="margin: 0cm 0cm 0pt">
                                    <span style="font-family: Calibri"><span style="font-size: 14pt; color: #a2a764"><strong>
                                    Para más información del sistema presione el botón→→</strong></span></span>
                                    <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button3_Click"
                                    Text="Ayuda" Font-Names="Calibri" Height="23px" Width="60px" />
                                &nbsp;&nbsp;&nbsp;
                                </p>
                                &nbsp;<br />
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="Button5" runat="server" OnClick="Button5_Click1" Text="Salir" Font-Names="Calibri" Height="23px" Width="60px" /></td>
                        </tr>
                        <tr>
                            <td style="background-color: darkslategray;">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp; &nbsp;
                <br />
                <br />
            </asp:MultiView></td>
    </tr>
    <tr>
    </tr>
    <tr>
    </tr>
    <tr>
        <td align="center" colspan="1" rowspan="1" style="width: 500px; text-align: justify"
            valign="top">
        </td>
        <td align="center" colspan="2" rowspan="1" style="width: 500px; text-align: justify"
            valign="top">
                                <input id="HdnPass" runat="server" style="width: 16px" type="hidden" /></td>
    </tr>
</table>
