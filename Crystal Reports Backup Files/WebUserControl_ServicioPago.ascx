<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl_ServicioPago.ascx.cs" Inherits="WebUserControl2" %>
<%@ Register Assembly="msgBox" Namespace="BunnyBear" TagPrefix="cc1" %>
<script type="text/javascript" src="../../Scripts/JScript.js">
    </script>
  <table width="800">
        <tbody>
            <tr>
                <td valign="top" align="left" style="height: 22457px; width: 204px;">
                    <asp:Menu ID="Menu1" runat="server"
                        Font-Bold="False" Font-Italic="False" Font-Names="Calibri" Font-Overline="False"
                        Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" ForeColor="Black"
                        OnMenuItemClick="Menu1_MenuItemClick" Width="100%" Target="top" EnableTheming="True">
                        <StaticSelectedStyle BackColor="#FFFFCC" BorderColor="#FFFFCC" BorderStyle="Outset" BorderWidth="3px" />
                        <Items>
                            <asp:MenuItem Enabled="False" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text=" " Value=" 11"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text=" Servicio de Pago" Value="1"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Tarjeta Caliente" Value="10"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Consultar Saldo" Value="8"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Configurar Servicios" Value="12"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Configurar Datos" Value="19"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Gestionar Banco" Value="22"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Iniciar Reclamaci&#243;n" Value="25"></asp:MenuItem>    
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Conciliaciones auxiliares" Value="30"></asp:MenuItem>
                            <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                                Text="Actualizar informaci&#243;n" Value="32"></asp:MenuItem>
                            <asp:MenuItem Text="Reporte Transaccion" Value="33" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#FFFFCC" BorderColor="#FFFFCC" />
                    </asp:Menu>
                            </td>  
                            <td colspan="2" style="width: 628px; height: 22457px;" valign="top">
                    <asp:MultiView ID="MVWPago" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MVWPago_ActiveViewChanged">
                        <asp:View ID="View1" runat="server">
                            <table width="100%">
                            <tr>
                                <td style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                                        padding-left: 15px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; text-align: justify" valign="top">
                                        <span style="font-size: 10pt;"><span style="font-family: Calibri"><strong><span style="font-size: 16pt; color: teal;">
                                            Servicio de Pago<br />
                                        </span>
                                        </strong><span lang="ES-TRAD" style="font-size: 14pt;
                                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-TRAD; mso-fareast-language: EN-US;
                                            mso-bidi-language: AR-SA; mso-bidi-font-size: 10.0pt; mso-bidi-font-family: Arial">
                                            <br />
                                            Usted está en la sección principal de Banca Telefónica, en la cual se atienden las solicitudes del cliente para el pago de los servicios, consulta de saldo, iniciación de reclamaciones y deshabilitación de tarjetas. Además permite realizar las conciliaciones de las tarjetas deshabilitadas, las transacciones y las reclamaciones, permite además la configuración de las sucursales donde los clientes tienen sus cuentas y de los servicios que se brindan.<br />
                                        </span></span></span></td>
                            </tr>
                        </table>
                            </asp:View>
                        <asp:View ID="View2" runat="server" OnActivate="View2_Activate"><table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 595px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                    <span style="font-size: 14pt; font-family: Calibri; background-color: darkslategray">
                                        <asp:Label ID="Label68" runat="server" Font-Names="Calibri" ForeColor="#FFFFCC" Text="Autenticar Cliente"></asp:Label></span></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static; height: 3px;
                                        text-align: center">
                                    <br />
                                    <table>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 37px; text-align: center">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox9"
                                                    ErrorMessage="*" ValidationExpression="[0-9][0-9]" Width="4px" Font-Names="Verdana" Font-Size="X-Small" ValidationGroup="1"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="TextBox9"
                                                    ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                                            <td style="width: 44px; text-align: center">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox8"
                                                    ErrorMessage="*" ValidationExpression="[0-9][0-9][0-9][0-9]" Width="3px" Font-Names="Verdana" Font-Size="X-Small" ValidationGroup="1"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="TextBox8"
                                                    ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                                            <td style="width: 51px; text-align: center">
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox10"
                                                    ErrorMessage="*" ValidationExpression="[0-9][0-9][0-9][0-9]" Width="1px" Font-Names="Verdana" Font-Size="X-Small" ValidationGroup="1"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox10"
                                                    ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                                            <td style="width: 51px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                                <span style="font-size: 14pt; font-family: Calibri"><strong>Tarjeta No:</strong></span></td>
                                            <td style="width: 37px; text-align: center">
                                                <input id="TextBox9" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox9',2,'TextBox8');"  onkeypress="SoloNumeros();" runat="server" maxlength="2" name="TextBox9" style="text-align: center; width: 25px"
                                                    type="text" readonly="readOnly" /></td>
                                            <td style="width: 44px; text-align: center">
                                                <input id="TextBox8" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox8',4,'TextBox10');" onkeypress="SoloNumeros();" runat="server" maxlength="4" name="TextBox8" style="text-align: center; width: 40px"
                                                    type="text" /></td>
                                            <td style="width: 51px; text-align: center">
                                                <input id="TextBox10" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox10',4,'Button1');" onkeypress="SoloNumeros();" runat="server" maxlength="4" name="TextBox10" style="text-align: center; width: 40px"
                                                    type="text" /></td>
                                            <td style="width: 51px; text-align: center">
                                                <asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="Button1_Click" CausesValidation="False" Font-Names="Calibri" ValidationGroup="1" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                            <td colspan="3" style="text-align: center">
                                                &nbsp;
                                                &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancelar" OnClick="Button2_Click" CausesValidation="False" Font-Names="Calibri" Enabled="False" Visible="False" /></td>
                                            <td colspan="1" style="text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                            &nbsp;&nbsp;
                        </asp:View>
                        <asp:View ID="View3" runat="server" OnActivate="View3_Activate">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 595px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                        <asp:Label ID="Label70" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="#FFFFCC" Text="Autenticar Cliente"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                            <table cellpadding="0" cellspacing="0" style="width: 300px">
                                <tr>
                                    <td style="width: 5905px; height: 19px; text-align: center;">
                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Cliente</strong></span></td>
                                    <td style="width: 2285px; height: 19px; text-align: center">
                                    </td>
                                    <td align="left" colspan="2" style="height: 19px">
                                        </td>
                                </tr>
                                <tr style="font-size: 10pt; font-family: Verdana">
                                    <td style="width: 5905px; text-align: center;" rowspan="5">
                                        <span><strong><span style="font-family: Calibri"><span style="font-size: 12pt"><span>
                                            <span style="font-size: 11pt"></span></span></span></span></strong></span>
                                        <strong><span style="font-size: 11pt; font-family: Calibri">
                                            <asp:Image ID="Image21" runat="server" ImageUrl="~/Images/Imagenes/Usuarios.png" /></span></strong></td>
                                    <td rowspan="5" style="width: 2285px; text-align: center">
                                    </td>
                                    <td align="center" style="height: 7px; text-align: center;" colspan="2">
                                        <strong><span style="font-size: 14pt; font-family: Calibri"> </span></strong>
                                        <asp:Label ID="Label69" runat="server" Font-Names="Calibri" Font-Size="14pt" Text="Dígitos del PIN"
                                            ToolTip="Número de Identificación Personal PIN(Personal Identification Number)" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr style="font-size: 10pt; font-family: Verdana">
                                    <td align="left" style="width: 128px; height: 5px; padding-bottom: 3px; text-align: center;">
                                        &nbsp;&nbsp;</td>
                                    <td align="left" style="padding-bottom: 3px; width: 43px; height: 5px; text-align: center;">
                                        </td>
                                </tr>
                                <tr style="font-size: 10pt; font-family: Verdana">
                                    <td align="left" style="text-align: center">
                                        <asp:Label ID="Label32" runat="server" Text="Primero" Height="20px" Font-Names="Calibri" Font-Size="12pt" Font-Bold="True" ForeColor="Teal"></asp:Label></td>
                                    <td align="left" style="text-align: center">
                                        <asp:Label ID="Label33" runat="server" Text="Cuarto" Height="20px" Font-Names="Calibri" Font-Size="12pt" Font-Bold="True" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="text-align: center;">
                                       <%-- <asp:TextBox ID="TextBox41" runat="server" Width="78px" Font-Names="Verdana" Font-Size="Small" Height="15px" MaxLength="1"></asp:TextBox>--%>
                                       <input type="Password" id="TextBox41" runat="server" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox41',1,'TextBox42');"  onkeypress="SoloNumeros();" style="text-align: center; width: 40px; font-family: Calibri;" onserverchange="TextBox41_ServerChange" maxlength="1" /></td>
                                    <td align="left" style="text-align: center;">
                                        <input type="Password" id="TextBox42" runat="server" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox42',1,'Button64');"  onkeypress="SoloNumeros();" style="text-align:center; width: 40px; font-family: Calibri;" maxlength="1" /></td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-bottom: 4px; width: 128px; padding-top: 3px; height: 23px;
                                        text-align: center">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox41"
                                            ErrorMessage="*" ValidationExpression="[0-9]" Width="1px" Font-Names="Verdana" Font-Size="X-Small" ValidationGroup="1"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="TextBox41"
                                            ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                                    <td align="left" style="padding-bottom: 4px; width: 43px; padding-top: 3px; height: 23px;
                                        text-align: center">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox42"
                                            ErrorMessage="*" ValidationExpression="[0-9]" Width="1px" Font-Names="Verdana" Font-Size="X-Small" ValidationGroup="1"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="TextBox42"
                                            ErrorMessage="*" Width="1px" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 5905px; height: 23px; text-align: center;">
                                        <strong><span style="font-size: 11pt; font-family: Calibri">
                                        <asp:Label ID="Label31" runat="server" BorderColor="Black" Text="Jose Rodriguez Delgado" BackColor="White" Font-Names="Calibri" Font-Size="13pt" Width="250px" ForeColor="Teal"></asp:Label></span></strong></td>
                                    <td align="right" style="width: 2285px; height: 23px; text-align: center">
                                    </td>
                                    <td align="left" style="padding-bottom: 4px; width: 128px; padding-top: 3px; height: 23px">
                                        &nbsp;<asp:Button ID="Button64" runat="server" Text="Aceptar" OnClick="Button64_Click" CausesValidation="False" Font-Names="Calibri" Width="60px" ValidationGroup="1" /></td>
                                    <td align="center" style="padding-bottom: 4px; width: 43px; padding-top: 3px; height: 23px; text-align: center;">
                                        <asp:Button ID="Button65" runat="server" Text="Cancelar" OnClick="Button65_Click" CausesValidation="False" Font-Names="Calibri" Width="60px" ValidationGroup="1" /></td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 5905px; height: 23px; text-align: center">
                                    </td>
                                    <td align="right" style="width: 2285px; height: 23px; text-align: center">
                                    </td>
                                    <td align="left" style="padding-bottom: 4px; width: 128px; padding-top: 3px; height: 23px">
                                    </td>
                                    <td align="center" style="padding-bottom: 4px; width: 43px; padding-top: 3px; height: 23px;
                                        text-align: center">
                                    </td>
                                </tr>
                            </table>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;<br />
                        </asp:View>
                        <asp:View ID="View4" runat="server">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 595px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                        <asp:Label ID="Label71" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Autenticar Cliente"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        &nbsp;
                                        <table>
                                            <tr>
                                                <td style="width: 211px">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                                </td>
                                                <td style="width: 81px; text-align: center; font-size: 12pt; font-family: Times New Roman; border-right: #66cc00 thin solid; border-left: #66cc00 thin solid;">
                                        <asp:Label ID="Label2" runat="server" Text="C8" BackColor="White" Font-Names="Courier New" Font-Size="18pt" Font-Bold="True" ForeColor="Teal" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></asp:Label></td>
                                                <td style="width: 58px; font-size: 12pt; font-family: Times New Roman;">
                                                </td>
                                                <td style="width: 69px; font-size: 12pt; font-family: Times New Roman;">
                                                </td>
                                            </tr>
                                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                                <td style="width: 211px; text-align: center; border-top: #66cc00 thin solid; border-bottom: #66cc00 thin solid;">
                                                    <span>
                                                        <asp:Label ID="Label133" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            ForeColor="Black" Text="Coordenada de la Matriz:"></asp:Label></span></td>
                                                <td style="text-align: center; border-right: #66cc00 thin solid; border-top: #66cc00 thin solid; border-left: #66cc00 thin solid; border-bottom: #66cc00 thin solid;">
                                                        <input type="Password" id="TextBox4" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox4',2,'Button6');"  onkeypress="SoloNumeros();"  runat="server" style="text-align: center; width: 40px; font-family: Calibri;" maxlength="2"
                                                             /></td>
                                                <td style="width: 58px; text-align: center; border-top: #66cc00 thin solid; border-bottom: #66cc00 thin solid;">
                                        <asp:Button ID="Button6" runat="server" Text="Aceptar" OnClick="Button6_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                <td style="width: 69px; text-align: center; border-top: #66cc00 thin solid; border-bottom: #66cc00 thin solid;">
                                                    <asp:Button ID="Button5" runat="server" Text="Cancelar" OnClick="Button5_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 211px; height: 21px;">
                                                </td>
                                                <td style="width: 81px; text-align: center; border-right: #66cc00 thin solid; border-left: #66cc00 thin solid; height: 21px;">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBox4"
                                            ErrorMessage="*" ValidationExpression="[0-9][0-9]" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="TextBox4"
                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td style="width: 58px; height: 21px;">
                                                </td>
                                                <td style="width: 69px; height: 21px;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View5" runat="server">
                            <table width="100%" cellpadding="0" cellspacing="0" id="TABLE1" onclick="return TABLE1_onclick()">
                                <tr>
                                    <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                        <asp:Label ID="Label75" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Servicio de Pago"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        &nbsp;
                                        <table>
                                            <tr>
                                                <td style="text-align: center; height: 20px;">
                                                    <strong><span>
                                                        <asp:Label ID="Label131" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            ForeColor="Teal" Text="Servicios Contratados"></asp:Label></span></strong></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="180px" Height="25px" Font-Names="Calibri" Font-Size="12pt">
                                                        <asp:ListItem></asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Button ID="Button7" runat="server" Text="Aceptar" OnClick="Button7_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                    <asp:Button ID="Button8" runat="server" Text="Cancelar" OnClick="Button8_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View6" runat="server" OnActivate="View6_Activate">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                        <asp:Label ID="Label76" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Servicio de Pago"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center" valign="top">
                                        <table>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Servicio a Pagar</span></strong></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center; height: 25px;">
                                                    <asp:Label ID="Label11" runat="server" Text="ETECSA" Font-Names="Calibri" Font-Bold="True" Font-Size="14pt" ForeColor="Teal"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Panel ID="Panel1" runat="server" Height="120px" Visible="False">
                                             <!--onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'CI_Pago',13,'Buscar_CI');" -->
                                                        <table>
                                                            <tr>
                                                                <td colspan="2" style="text-align: center">
                                                                    &nbsp;
                                                        <asp:Label ID="Label18" runat="server" Text="Carné de Identidad:" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" ForeColor="Black" ToolTip="carné. (Del fr. carnet). m. Librito de apuntaciones. || 2. Documento que se expide a favor de una persona, provisto de su fotografía y que la faculta para ejercer ciertas actividades o la acredita como miembro de determinada agrupación. || ~ de identidad. m. tarjeta de identidad." Width="138px"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="text-align: center">
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator32" runat="server"
                                                            ControlToValidate="CI_Pago" ErrorMessage="*" ValidationExpression="[0-9]+" ValidationGroup="1"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="CI_Pago"
                                                            ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <input type="text" runat="server" ID="CI_Pago" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'CI_Pago',16,'Buscar_CI');" onkeypress="SoloNumeros();" maxlength="16" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left" colspan="2">
                                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                        <asp:Button ID="Buscar_CI" runat="server" OnClick="BuscarAsociados_Pago" Text="Buscar" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" ValidationGroup="1" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="background-color: darkslategray; text-align: center;">
                                                    <asp:Label ID="Label135" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                        ForeColor="#FFFFCC" Text="Provincia?"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Image ID="Image24" runat="server" Height="35px" ImageUrl="~/Images/Imagenes/telefono1.jpeg" Visible="False" />&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Label ID="Label121" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                        ForeColor="Teal" Text="???" Visible="False"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="Panel_ListAsociados" runat="server" Width="100%">
                                                    <asp:DataGrid ID="asociadosSevPago"  runat="server" OnPreRender="asociadosSevPago_PreRender" OnEditCommand="asociadosSevPago_EditCommand" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" GridLines="Horizontal" Font-Names="Calibri" ForeColor="Black" ShowFooter="True" Font-Size="14pt">
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox runat="server" AutoPostBack="True" OnCheckedChanged="ValidarChequeadoPS" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <FooterStyle BackColor="#A2A764" />
                                                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                        <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                                    </asp:DataGrid></asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Image ID="Image23" runat="server" ImageUrl="~/Images/Imagenes/ETECSA_logo.jpg" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                        <asp:Button ID="Button10" runat="server" Text="Aceptar" OnClick="Button10_Click" Enabled="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" />
                                                    <asp:Button ID="Button9"
                                            runat="server" OnClick="Button9_Click1" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="background-color: darkslategray; text-align: left">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;</asp:View>
                        &nbsp;&nbsp;<br />
                        <asp:View ID="View7" runat="server" OnActivate="View7_Activate"><table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                    <asp:Label ID="Label77" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Servicio de Pago"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                    <table style="text-align: center">
                                        <tr>
                                            <td style="text-align: center">
                                                <strong style="text-align: center">
                                                    <asp:Label ID="Label132" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                        Text="Servicio a Pagar"></asp:Label></strong></td>
                                            <td style="width: 156px; text-align: center">
                                                &nbsp;<strong><span style="font-size: 14pt; font-family: Calibri">Monto a Pagar</span></strong></td>
                                            <td colspan="2" style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Teléfono</span></strong></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                        <asp:Label ID="Label1" runat="server" Text="ETECSA" Width="64px" Font-Names="Calibri" Font-Size="14pt" Font-Bold="True" ForeColor="Teal"></asp:Label></td>
                                            <td style="width: 156px; text-align: center">
                                                &nbsp;<strong>$<asp:Label ID="Label40" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal"></asp:Label></strong></td>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Label ID="Label106" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                    ForeColor="#FF8000" Text="NO.TELEFONO"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                            </td>
                                            <td style="width: 156px; text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Datos de Pago</span></strong></td>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Valor</span></strong></td>
                                            <td style="width: 3px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"></span></td>
                                            <td style="text-align: center">
                                                <strong>
                                            <asp:ListBox ID="ListBox2" runat="server" Height="60px" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged"
                                                Width="149px" Font-Names="Calibri" Font-Size="14pt" AutoPostBack="True"></asp:ListBox>&nbsp;<span
                                                    style="font-size: 14pt; font-family: Calibri"></span><span style="font-size: 14pt;
                                                        font-family: Calibri"></span></strong></td>
                                            <td style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri">
                                        <asp:TextBox ID="TextBox5" runat="server" Width="120px" Font-Names="Verdana"></asp:TextBox>
                                                    <br />
                                        <asp:Button ID="Button52" runat="server" OnClick="Button52_Click1" Text="Guardar" Font-Names="Calibri" Font-Size="11pt" Width="70px" Font-Bold="True" /></span></td>
                                            <td style="width: 3px; text-align: center">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator31" runat="server"
                                            ControlToValidate="TextBox5" EnableClientScript="False" ErrorMessage="*" ValidationExpression="[0-9]+.[0-9]{2}|[0-9]+"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                                <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                            </td>
                                            <td style="width: 156px; text-align: right">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">&nbsp;Efectuar Pago</span></strong></td>
                                            <td style="text-align: left">
                                        <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Sí" OnClientClick="DesactivarBoton('WebUserControl_ServicioPago1_', 'Button11');" Font-Names="Calibri" Font-Size="11pt" Width="70px" Font-Bold="True" /> <asp:Button ID="Button12" runat="server" Text="No" OnClick="Button12_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" Font-Bold="True" /></td>
                                            <td style="width: 3px; text-align: left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                            </td>
                                            <td style="width: 156px; text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                            </td>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                            </td>
                                            <td style="width: 3px; text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="width: 613px; height: 22px">
                                </td>
                            </tr>
                        </table>
                        </asp:View>
                        <asp:View ID="View8" runat="server" OnActivate="View8_Activate"><table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                    <asp:Label ID="Label78" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Servicio de Pago"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 613px;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static; height: 3px;
                                        text-align: center">
                                    <table>
                                        <tr>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Servicio a Pagar</span></strong></td>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">ID Asociado</span></strong></td>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Nombre</span></strong></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                        <asp:Label ID="Label4" runat="server" Text="ETECSA" Font-Names="Calibri" Font-Size="14pt" Font-Bold="True" ForeColor="Teal"></asp:Label></td>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                    ForeColor="Teal"></asp:Label></td>
                                            <td style="text-align: center">
                                        <asp:Label ID="Label6" runat="server" Text="Nombre del Cliente" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong></td>
                                            <td style="text-align: center">
                                            </td>
                                            <td style="text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                </td>
                                            <td style="text-align: center">
                                        <asp:DropDownList ID="PagosComp" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'PagosComp',4,'Button13');" runat="server" OnSelectedIndexChanged="SelectPagoAsociadComp" AutoPostBack="True" Font-Names="Calibri" Font-Size="12pt" Width="200px">
                                        </asp:DropDownList></td>
                                            <td style="text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"></span></td>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Importe a Pagar
                                                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" EnableTheming="True" ForeColor="#00C000"
                                                        RepeatDirection="Horizontal" ToolTip="Monedas de Cuentas asociadas a la Tarjeta Telebanca"
                                                        Visible="False">
                                                    </asp:RadioButtonList></span></strong><asp:Label ID="Label162" runat="server" Font-Bold="True"
                                                        Font-Names="Calibri" ForeColor="Red" Visible="False"></asp:Label></td>
                                            <td style="text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px">
                                        </td>
                                            <td style="text-align: center; height: 26px;">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">$<asp:Label ID="Label7" runat="server" Text="0.0" Font-Names="Calibri" Font-Size="14pt" Font-Bold="True" ForeColor="#FF8000"></asp:Label>
                                                    <asp:TextBox ID="TextBox54" runat="server" Visible="False" Width="100px"></asp:TextBox></span></strong></td>
                                            <td style="height: 26px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                        </td>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Efectuar Pago</span></strong></td>
                                            <td style="text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong></td>
                                            <td style="text-align: center">
                                        <asp:Button ID="Button13" runat="server" OnClick="Button13_Click1"
                                            Text="Si" Width="70px" OnClientClick="DesactivarBoton('WebUserControl_ServicioPago1_', 'Button13');" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt" />
                                                <asp:Button ID="Button18" runat="server" Text="No" Width="70px" OnClick="Button18_Click" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            <td style="text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"><strong>&nbsp;</strong></span></td>
                                            <td style="text-align: center">
                                                <asp:Button ID="Button100" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt"
                                                    OnClick="Button100_Click1" Text="T2" Visible="False" Width="60px" /></td>
                                            <td style="text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </asp:View>
                        <br />
                        <asp:View ID="View9" runat="server"><table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                    <asp:Label ID="Label27" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Consultar Saldo"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 613px;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static; height: 3px;
                                        text-align: center"><table cellpadding="0" cellspacing="0" style="width: 98%">
                                            <tr>
                                                <td style="font-weight: normal; font-size: 12pt; width: 145px; font-family: Verdana;
                                                height: 24px">
                                                </td>
                                                <td style="width: 95px; height: 24px">
                                                </td>
                                                <td style="width: 116px; height: 24px">
                                                </td>
                                                <td style="width: 133px; height: 24px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: normal; font-size: 12pt; width: 145px; font-family: Verdana;
                                                    height: 6px">
                                                    <span style="font-size: 14pt; font-family: Calibri;"><strong>Tarjeta No:</strong></span></td>
                                                <td style="width: 95px; height: 6px" align="left">
                                                <input id="TextBox2" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox2',2,'TextBox3');" onkeypress="SoloNumeros();" runat="server" maxlength="2" name="TextBox2" style="width: 39px"
                                                    type="text" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox2"
                                                    ErrorMessage="*" ValidationExpression="[0-9][0-9]" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="TextBox2"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td style="width: 116px; height: 6px; font-size: 12pt; color: #000000; font-family: Times New Roman;" align="left">
                                                    <span style="font-size: 10pt">
                                                 &nbsp;<input id="TextBox3" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox3',4,'TextBox43');" onkeypress="SoloNumeros();" runat="server" maxlength="4" name="TextBox3" style="width: 56px"
                                                    type="text" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                    ControlToValidate="TextBox3" ErrorMessage="*" ValidationExpression="[0-9][0-9][0-9][0-9]" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="TextBox3"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator></span></td>
                                                <td style="width: 133px; height: 6px; color: #000000; font-family: Times New Roman;" align="left">
                                                  &nbsp;<input id="TextBox43" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox43',4,'Button3');" onkeypress="SoloNumeros();" runat="server" maxlength="4" name="TextBox43" style="width: 56px"
                                                    type="text" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                    ControlToValidate="TextBox43" ErrorMessage="*" ValidationExpression="[0-9][0-9][0-9][0-9]" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="TextBox43"
                                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr style="font-family: Times New Roman">
                                                <td colspan="1" style="width: 145px; padding-top: 9px; height: 12px">
                                                    <span style="font-size: 10pt">&nbsp;</span></td>
                                                <td align="left" colspan="5" style="padding-left: 4px; padding-top: 5px; height: 12px">
                                                <asp:Button ID="Button3" runat="server" Text="Aceptar" OnClick="Button3_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" />
                                                &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="Button4" runat="server" Text="Cancelar" OnClick="Button4_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                            </tr>
                                        </table>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        </asp:View>
                        <asp:View ID="View10" runat="server" OnActivate="View10_Activate"><table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                    <asp:Label ID="Label86" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Consultar Saldo"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 613px;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static; height: 3px;
                                        text-align: center">
                                    <table>
                                        <tr>
                                            <td style="height: 25px; text-align: center">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Cliente</span></strong></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 25px; text-align: center">
                                    <asp:Label BackColor="White" BorderColor="#404040" ID="Label9" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal">Jose Rodriguez Delgado</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <hr style="border-left-color: silver; border-bottom-color: silver; border-top-style: double;
                                                    border-top-color: silver; border-right-style: double; border-left-style: double;
                                                    border-right-color: silver; border-bottom-style: double" />
                                                <strong><span style="font-size: 14pt; font-family: Calibri">$aldos</span></strong></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"><strong>
                                                    <asp:GridView ID="GridView6" runat="server" BackColor="#004040" BorderColor="LightGray"
                                                        BorderWidth="5px" CellPadding="2" ForeColor="Lime" GridLines="Horizontal" ShowHeader="False">
                                                        <FooterStyle BackColor="Tan" />
                                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                        <AlternatingRowStyle BackColor="#004040" />
                                                    </asp:GridView>
                                                    &nbsp;</strong>
                                                </span></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <hr style="border-left-color: silver; border-bottom-color: silver; border-top-style: double;
                                                    border-top-color: silver; border-right-style: double; border-left-style: double;
                                                    border-right-color: silver; border-bottom-style: double" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"></span>&nbsp;<asp:Button ID="Button25" runat="server" OnClick="Button25_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </asp:View>
                        <asp:View ID="View11" runat="server"><table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                    <asp:Label ID="Label82" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Tarjeta Caliente"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                    <br />
                                    <table>
                                        <tr>
                                            <td style="width: 227px; text-align: center;">
                                                <strong><span style="font-size: 14pt; font-family: Calibri">Carné de Identidad:</span></strong></td>
                                            <td style="width: 100px">
                                        <asp:TextBox ID="TextBox7" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox7',11,'Button21');" runat="server" Width="181px" CausesValidation="True" Font-Names="Calibri" MaxLength="11" Font-Size="10pt"></asp:TextBox></td>
                                            <td style="width: 15px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox7"
                                            ErrorMessage="*" 
                                            ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9]|[a-z]-[0-9][0-9][0-9][0-9][0-9][0-9]|[0-9][0-9][0-9][0-9][0-9][0-9][0-9]" 
                                            Width="10px" Font-Names="Verdana" Font-Size="X-Small" Height="17px" 
                                            Enabled="False"></asp:RegularExpressionValidator></td>
                                            <td style="width: 48px">
                                        <asp:Button ID="Button21" runat="server" Text="Buscar" OnClick="Button21_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                            <td style="width: 70px">
                                        <asp:Button ID="Button22" runat="server"
                                            Text="Cancelar" OnClick="Button22_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                            &nbsp;</asp:View>
                        <asp:View ID="View12" runat="server"><table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                    <asp:Label ID="Label83" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Tarjeta Caliente"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                    <table>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"><strong>Cliente:</strong></span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                            <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <span style="font-size: 14pt; font-family: Calibri"><strong>Titular de Tarjetas No:</strong></span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="194px"
                                            OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="139px" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: justify">
                                        <asp:RadioButtonList ID="RadioButtonList6" runat="server"  Width="166px" Font-Names="Calibri" Font-Size="14pt" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList6_SelectedIndexChanged2" ForeColor="Teal">
                                            <asp:ListItem>Deshabilitar</asp:ListItem>
                                            <asp:ListItem>Solicitar Tarjeta</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                        <asp:Button ID="Button23" runat="server" Text="Aceptar" OnClick="Button23_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" />&nbsp;
                                                <asp:Button ID="Button24" runat="server"
                                            Text="Cancelar" OnClick="Button24_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </asp:View>
                        <asp:View ID="View13" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 22px; background-color: darkslategray">
                                        <asp:Label ID="Label110" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Configuración de Servicios"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ListBox ID="ListBox3" runat="server" Height="184px" Width="250px" Font-Names="Calibri" Font-Size="12pt" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged"></asp:ListBox></td>
                                                <td style="width: 78px">
                                                    <asp:Button ID="Button55" runat="server" Text="Agregar" Width="76px" OnClick="Button55_Click1" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                    <br />
                                                    <asp:Button ID="Button56" runat="server" Text="Modificar" Width="76px" OnClick="Button56_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                    <br />
                                                                <asp:Button ID="Button57" runat="server" Text="Eliminar" Width="76px" OnClick="Button57_Click1" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                    <br />
                                                    <asp:Button ID="Button14" runat="server" Text="Cancelar" OnClick="Button14_Click1" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                                    <asp:Label ID="Label5" runat="server" Text="Tipo Servicio:" Width="96px" Font-Names="Calibri" Font-Size="12pt" Font-Bold="True" ForeColor="Transparent"></asp:Label></td>
                                                <td style="width: 78px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="46px" Font-Names="Calibri" Font-Size="12pt" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Width="93px" AutoPostBack="True" ForeColor="Teal" RepeatDirection="Horizontal" Font-Bold="True">
                                                        <asp:ListItem>Simple</asp:ListItem>
                                                        <asp:ListItem>Complejo</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                                <td style="width: 78px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View14" runat="server" OnActivate="View14_Activate">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 601px; font-family: Verdana;
                                        height: 22px; background-color: darkslategray">
                                        <asp:Label ID="Label111" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Agregar Servicio Simple"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <table>
                                            <tr>
                                                <td style="width: 213px; text-align: left;">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Nombre del Servicio</span></strong></td>
                                                <td style="text-align: center;">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Estado</strong></span></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 213px; text-align: left">
                                                        <asp:TextBox ID="TextBox6" runat="server" Width="160px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox6"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td rowspan="3" style="text-align: center; font-weight: bold; font-size: 14pt; color: #000000; font-family: Calibri;">
                                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Names="Calibri" Font-Size="12pt" ForeColor="Teal" RepeatDirection="Horizontal" >
                                                        <asp:ListItem Selected="True">Activo</asp:ListItem>
                                                        <asp:ListItem>Inactivo</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 213px; height: 17px; text-align: left;">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Id del Servicio</span></strong></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 213px; text-align: left">
                                                    <asp:TextBox ID="TextBox31" runat="server" Font-Names="Calibri" Width="160px" Font-Size="10pt"></asp:TextBox><strong><span
                                                        style="font-size: 14pt; font-family: Calibri"> </span></strong>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server"
                                                            ControlToValidate="TextBox31" ErrorMessage="*" ValidationExpression="[0-9][0-9]"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="TextBox31"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                                                <td colspan="2" style="text-align: left">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Nivel de Autenticación</strong></span></td>
                                            </tr>
                                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                                <td style="text-align: justify;" colspan="2">
                                                    <span></span>
                                                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" Font-Names="Calibri" Font-Size="12pt" Width="240px">
                                                        <asp:ListItem>Autenticar por CI</asp:ListItem>
                                                        <asp:ListItem>Autenticar por pin</asp:ListItem>
                                                        <asp:ListItem Value="Autenticar por n&#250;mero de tarjeta">Autenticar por n&#250;mero de tarjeta</asp:ListItem>
                                                    </asp:CheckBoxList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 213px; text-align: center;">
                                                    <span><span><span style="font-family: Calibri"><span style="font-size: 14pt"><strong>Cantidad de Coordenadas</strong> </span></span></span></span>
                                                </td>
                                                <td style="width: 89px">
                                                    <asp:Button ID="Button26" runat="server" Text="Datos Existentes" Width="120px" OnClick="Button26_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 213px; text-align: center;">
                                                    <asp:TextBox
                                                        ID="TextBox013" runat="server" Width="80px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox>
                                                    <asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator11" runat="server" ControlToValidate="TextBox013"
                                                        ErrorMessage="*" ValidationExpression="[0-9]+" Width="1px" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox013"
                                                        ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                                                <td style="width: 89px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Button ID="Button15" runat="server"
                                                        OnClick="Button30_Click1" Text="Aceptar" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" />&nbsp; <asp:Button ID="Button20" runat="server" OnClick="Button20_Click1"
                                                        Text="Cancelar" Width="64px" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View15" runat="server" OnActivate="View15_Activate">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 22px; background-color: darkslategray">
                                        <asp:Label ID="Label112" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Agregar Servicio Complejo"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 2px; border-top: #d8d787 2px solid;
                                        padding-left: 2px; padding-bottom: 2px; border-left: #d8d787 2px solid;
                                        padding-top: 2px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <br />
                                        <table>
                                            <tr>
                                                <td style="height: 25px; text-align: left">
                                                    <asp:Label ID="Label113" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                        Text="Nombre del Servicio"></asp:Label></td>
                                                <td colspan="2" style="text-align: center">
                                                    <span style="font-size: 14pt; font-family: Calibri">
                                                        <asp:Label ID="Label118" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            Text="Estado"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: justify">
                                                        <asp:TextBox ID="TextBox11" runat="server" Font-Names="Calibri" Font-Size="10pt" Width="160px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox11"
                                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td colspan="2" rowspan="3" style="text-align: center">
                                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" Font-Names="Calibri" Font-Size="12pt" ForeColor="Teal" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True">Activo</asp:ListItem>
                                                        <asp:ListItem>Inactivo</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 55px; text-align: left">
                                                    <span><span style="font-size: 14pt; font-family: Calibri">
                                                        <asp:Label ID="Label114" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            Text="Id del Servicio" Width="150px"></asp:Label></span></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                        <asp:TextBox ID="TextBox32" runat="server" Width="160px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server"
                                                            ControlToValidate="TextBox32" ErrorMessage="*" ValidationExpression="[0-9][0-9]"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="TextBox32"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 55px; text-align: justify">
                                                    <span style="font-size: 14pt; font-family: Calibri">
                                                        <asp:Label ID="Label115" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            Text="Nivel de Autenticación" Width="184px"></asp:Label></span></td>
                                                <td colspan="2" style="text-align: center">
                                                    <span style="font-family: Calibri"><span style="font-size: 14pt"><strong>P<span lang="ES" style="mso-ansi-language: ES"><span><span>róxima
                                                        Descarga FTP<?xml namespace=""
                                                            prefix="o" ?><?xml namespace="" prefix="o" ?></span></span></span></strong></span></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: justify">
                                                        <asp:CheckBoxList ID="CheckBoxList2" runat="server" Font-Names="Calibri" Font-Size="12pt" Height="43px" Width="260px">
                                                            <asp:ListItem>Autenticar por CI</asp:ListItem>
                                                            <asp:ListItem>Autenticar por pin</asp:ListItem>
                                                            <asp:ListItem Value="Autenticar por n&#250;mero de tarjeta">Autenticar por n&#250;mero de tarjeta</asp:ListItem>
                                                        </asp:CheckBoxList></td>
                                                <td colspan="2" rowspan="4" style="text-align: center">
                                                    <asp:Calendar ID="Calendar1" runat="server" Height="150px" Width="180px" Font-Size="8pt" Font-Names="Verdana" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" ForeColor="Black" OnDayRender="Calendar1_DayRender" ShowGridLines="True">
                                                        <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: justify">
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="Servicio con Asociados" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 55px; height: 18px; text-align: center">
                                                    <span style="font-size: 14pt; font-family: Calibri">&nbsp;<asp:Label ID="Label116"
                                                        runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt" Text="Cantidad de Coordenadas"
                                                        Width="205px"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                        <asp:TextBox
                                                        ID="TextBox28" runat="server" Width="80px" Font-Names="Verdana" Font-Size="Small" MaxLength="1"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                            ControlToValidate="TextBox28" ErrorMessage="*" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox28"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 55px; height: 25px; text-align: center">
                                                    <span style="font-family: Calibri"><strong><span style="font-size: 14pt">
                                                        <asp:Label ID="Label117" runat="server" Text="Días entre Descargas" Width="167px"></asp:Label></span></strong></span></td>
                                                <td colspan="2" style="height: 25px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:TextBox ID="TextBox12" runat="server" Font-Names="Verdana" Font-Size="Small" Width="80px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server"
                                                        ControlToValidate="TextBox12" ErrorMessage="*" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox12"
                                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td colspan="2" style="height: 28px; text-align: center">
                                                    <asp:Button ID="Button17" runat="server" Text="Aceptar" OnClick="Button17_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" />
                                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; 
                                                    <asp:Button ID="Button27" runat="server" Text="Cancelar" OnClick="Button27_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        &nbsp;
                        <asp:View ID="View16" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 22px; background-color: darkslategray">
                                        <asp:Label ID="Label119" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Modificar Servicio Simple"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <br />
                                        <table>
                                            <tr>
                                                <td style="width: 189px; text-align: left">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Nombre del Servicio</strong></span></td>
                                                <td style="text-align: center;">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Estado</span></strong></td>
                                            </tr>
                                            <tr style="font-family: Times New Roman">
                                                <td style="text-align: left">
                                                        <asp:Label ID="Label12" runat="server" Height="15px" Font-Names="Calibri" Font-Size="12pt" Font-Bold="True" ForeColor="Teal">Servicio</asp:Label></td>
                                                <td rowspan="3" style="text-align: center; font-size: 14pt;">
                                                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" Font-Names="Calibri" Font-Size="12pt" ForeColor="Teal" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True">Activo</asp:ListItem>
                                                        <asp:ListItem>Inactivo</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr style="font-weight: bold; font-size: 14pt; font-family: Times New Roman">
                                                <td style="width: 189px; text-align: left">
                                                    <span style="font-size: 14pt;"><span style="font-family: Calibri">ID del Servicio</span></span></td>
                                            </tr>
                                            <tr style="font-family: Times New Roman">
                                                <td style="text-align: left">
                                                        <asp:Label
                                                        ID="Label28" runat="server" Font-Names="Calibri" Font-Size="12pt" Height="15px"
                                                        Text="Label" ForeColor="Teal" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr style="font-family: Times New Roman">
                                                <td style="width: 189px; text-align: left">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Nivel de Autenticación</span></strong></td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Font-Names="Calibri" Font-Size="12pt" Width="282px">
                                                        <asp:ListItem>Autenticar por CI</asp:ListItem>
                                                        <asp:ListItem>Autenticar por pin</asp:ListItem>
                                                        <asp:ListItem Value="Autenticar por n&#250;mero de tarjeta">Autenticar por n&#250;mero de tarjeta</asp:ListItem>
                                                    </asp:CheckBoxList></td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Cantidad de Coordenadas</span></strong></td>
                                                <td>
                                                    <asp:Button ID="Button28" runat="server" Text="Datos Existentes" Width="163px" OnClick="Button28_Click1" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:TextBox ID="TextBox20" runat="server" Width="80px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator12" runat="server" ControlToValidate="TextBox20"
                                                        ErrorMessage="*" ValidationExpression="[0-9]+" Width="8px" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox20"
                                                        ErrorMessage="*" Width="2px"></asp:RequiredFieldValidator></td>
                                                <td style="height: 25px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Button ID="Button29" runat="server" OnClick="Button29_Click"
                                                        Text="Aceptar" Width="73px" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" />
                                                    &nbsp;
                                                    <asp:Button ID="Button30" runat="server" Text="Cancelar" Width="77px" OnClick="Button30_Click2" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View17" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 22px; background-color: darkslategray">
                                        <asp:Label ID="Label120" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Modificar Servicio Complejo"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                                        padding-left: 5px; padding-bottom: 2px; border-left: #d8d787 2px solid;
                                        padding-top: 2px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <br />
                                        <table>
                                            <tr>
                                                <td rowspan="1" style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Nombre del Servicio</span></strong></td>
                                                <td colspan="2" rowspan="1" style="font-size: 14pt; text-align: center">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 25px;">
                                                    <span style="font-family: Calibri; font-size: 14pt;"><strong style="text-align: center">
                                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="14pt" Font-Bold="True" ForeColor="Teal">Servicio</asp:Label></strong></span></td>
                                                <td colspan="2" style="text-align: center; font-size: 14pt; height: 25px;">
                                                    <strong><span style="font-family: Calibri">Estado</span></strong></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <strong><span style="text-align: center"><span style="font-size: 14pt; font-family: Calibri">
                                                        Id del Servicio<br />
                                                    </span>
                                                    <asp:Label
                                                        ID="Label29" runat="server" Font-Names="Calibri" Font-Size="14pt"
                                                        Text="Label" Font-Bold="True" ForeColor="Teal"></asp:Label></span></strong></td>
                                                <td colspan="2" style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">
                                                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" Font-Names="Calibri" Font-Size="12pt" ForeColor="Teal" RepeatDirection="Horizontal" ToolTip="Activar o Desactivar el Servicio" Font-Bold="True">
                                                        <asp:ListItem Selected="True">Activo</asp:ListItem>
                                                        <asp:ListItem>Inactivo</asp:ListItem>
                                                    </asp:RadioButtonList></span></strong></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 229px; text-align: left;">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong style="text-align: left">Nivel de Autenticación</strong></span></td>
                                                <td colspan="2" style="text-align: center">
                                                    <span><span><span><span><span style="font-family: Calibri"><span style="font-size: 14pt">
                                                        <strong><span>P</span><span lang="ES" style="mso-ansi-language: ES"><span><span><span><span>róxima
                                                        Descarga FTP<?xml
                                                            namespace="" prefix="o" ?></span></span></span></span></span></strong></span></span></span></span></span></span></td>
                                            </tr>
                                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                                <td style="text-align: justify">
                                                    <asp:CheckBoxList ID="CheckBoxList4" runat="server" Width="306px" Font-Names="Calibri" Font-Size="12pt" CellPadding="3">
                                                        <asp:ListItem>Autenticar por CI</asp:ListItem>
                                                        <asp:ListItem>Autenticar por pin</asp:ListItem>
                                                        <asp:ListItem>Autenticar por n&#250;mero de tarjeta</asp:ListItem>
                                                    </asp:CheckBoxList></td>
                                                <td colspan="2" rowspan="3">
                                                    <asp:Calendar ID="Calendar2" runat="server" Height="150px" Width="180px" Font-Size="10pt" Font-Names="Calibri" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" ForeColor="Black" ShowGridLines="True" OnDayRender="Calendar2_DayRender" OnSelectionChanged="Calendar2_SelectionChanged">
                                                        <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <SelectorStyle BackColor="#C0FFC0" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="12pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: justify">
                                                    <asp:CheckBox ID="CheckBox3" runat="server" Text="Servicio con Asociados" OnCheckedChanged="CheckBox3_CheckedChanged" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" Width="180px" /></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left;">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Cantidad de Coordenadas&nbsp;
                                                    </span></strong>
                                                    <asp:TextBox ID="TextBox27" runat="server" Width="38px" Font-Names="Verdana" Font-Size="Small" MaxLength="1"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                        ControlToValidate="TextBox27" ErrorMessage="*" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="TextBox27"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left;">
                                                    <strong><span style="font-size: 14pt"><span style="font-family: Calibri">Días entre<span> Descargas &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span></span></span></strong>
                                                        <asp:TextBox ID="TextBox21" runat="server" Font-Names="Verdana" Font-Size="Small" Width="38px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                                                            ControlToValidate="TextBox21" ErrorMessage="*" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox21"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Button ID="BtnDescFTP" runat="server" OnClick="BtnDescFTP_Click" Text="Descargar Ahora"
                                                        Width="127px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Button ID="Button33" runat="server" Text="Aceptar" OnClick="Button33_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" />
                                                    &nbsp; &nbsp; <asp:Button ID="Button35" runat="server" Text="Cancelar" OnClick="Button35_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View18" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 21px; background-color: darkslategray">
                                        <asp:Label ID="Label79" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Reporte de Transacciones"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <table>
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <span style="font-family: Calibri; font-size: 14pt;"><strong style="color: teal">Operador:</strong></span>
                                        <asp:TextBox ID="TextBox62" runat="server" Width="143px"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 21px; text-align: center">
                                                    <span style="text-align: center;">
                                                        <asp:Label ID="Label80" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            Text="DESDE"></asp:Label></span></td>
                                                <td colspan="2" style="font-size: 12pt; height: 21px; text-align: center">
                                                    <strong><span style="text-align: center;">
                                                        <asp:Label ID="Label81" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            Text="HASTA"></asp:Label></span></strong></td>
                                            </tr>
                                            <tr style="font-size: 12pt">
                                                <td>
                                                    <asp:Calendar ID="Calendar4" runat="server" Font-Names="Calibri" Font-Size="10pt" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" ForeColor="Black" Height="150px" OnDayRender="Calendar4_DayRender" ShowGridLines="True" Width="180px">
                                                        <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="12pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                                <td colspan="2">
                                                    <asp:Calendar ID="Calendar5" runat="server" Font-Names="Calibri" Font-Size="10pt" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" ForeColor="Black" Height="150px" OnDayRender="Calendar5_DayRender" ShowGridLines="True" Width="180px" OnSelectionChanged="Calendar5_SelectionChanged">
                                                        <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="12pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr style="font-size: 12pt">
                                                <td>
                                                </td>
                                                <td colspan="2" style="text-align: center">
                                                </td>
                                            </tr>
                                            <tr style="font-size: 12pt">
                                                <td colspan="3" style="background-color: darkslategray; text-align: center">
                                                    <asp:Label ID="Label165" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Lime"
                                                        Text="Reporte de Transacciones"></asp:Label></td>
                                            </tr>
                                            <tr style="font-size: 12pt">
                                                <td colspan="3" style="text-align: center">
                                                    <asp:RadioButtonList ID="RadioButtonList17" runat="server" AutoPostBack="True" Font-Bold="True"
                                                        Font-Names="Calibri" OnSelectedIndexChanged="RadioButtonList17_SelectedIndexChanged"
                                                        RepeatDirection="Horizontal" Enabled="False">
                                                        <asp:ListItem Value="1">CUP</asp:ListItem>
                                                        <asp:ListItem Value="2">CUC</asp:ListItem>
                                                        <asp:ListItem Value="12">CUP(CUC)</asp:ListItem>
                                                        <asp:ListItem Value="21">CUC(CUP)</asp:ListItem>
                                                        <asp:ListItem Value="80">Todas</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr style="font-size: 12pt">
                                                <td>
                                                    </td>
                                                <td style="text-align: center" colspan="2">
                                                    <asp:Button ID="Button68" runat="server" Text="Aceptar" OnClick="Button68_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" Enabled="False" />&nbsp; <asp:Button ID="Button69" runat="server" Text="Cancelar" OnClick="Button69_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px"  /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View19" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana; background-color: darkslategray">
                                        <asp:Label ID="Label85" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Configuración de Servicios"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <table>
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri; color: teal;">ASOCIAR DATOS</span></strong></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Datos a Incluir</span></strong></td>
                                                <td>
                                                </td>
                                                <td style="text-align: center">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Datos Existentes</strong></span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ListBox ID="ListBox7" runat="server" Height="100px" Width="200px" OnSelectedIndexChanged="ListBox7_SelectedIndexChanged" AutoPostBack="True" Font-Names="Calibri" Font-Size="12pt">
                                                        <asp:ListItem Value="relevante">IdAsociado</asp:ListItem>
                                                        <asp:ListItem Value="pago">Importe</asp:ListItem>
                                                    </asp:ListBox></td>
                                                <td style="text-align: center">
                                                    <asp:Button ID="Button71" runat="server" Text=">>" Width="50px" OnClick="Button71_Click" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FF8000" /><br />
                                                    <br />
                                                    <asp:Button ID="Button70" runat="server" Text="<<" Width="50px" OnClick="Button70_Click" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt" ForeColor="#FF8000" /></td>
                                                <td>
                                                    <asp:ListBox ID="ListBox8" runat="server" Height="100px" Width="200px" OnSelectedIndexChanged="ListBox8_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px; text-align: center">
                                                    <strong><span style="font-size: 10pt; font-family: Verdana"></span></strong>
                                                </td>
                                                <td style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Tipo de Dato</span></strong></td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" Font-Names="Calibri" Font-Size="12pt">
                                                        <asp:ListItem>Relevante</asp:ListItem>
                                                        <asp:ListItem>Importe</asp:ListItem>
                                                        <asp:ListItem>Pago</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button19" runat="server" OnClick="Button19_Click1" Text="Configurar datos"
                                                        Width="140px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Button ID="Button72" runat="server" Text="Aceptar" OnClick="Button72_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" />&nbsp;
                                                    <asp:Button ID="Button73" runat="server" Text="Cancelar" OnClick="Button73_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View20" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 591px; font-family: Verdana;
                                        height: 9px; background-color: darkslategray">
                                        <asp:Label ID="Label122" runat="server" ForeColor="#FFFFCC" Text="Configuración de los Datos"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <br />
                                        <table>
                                            <tr>
                                                <td rowspan="5" style="width: 100px">
                                                    <asp:ListBox ID="ListBox4" runat="server" Height="237px" Width="230px" OnLoad="ListBox4_Load" Font-Names="Calibri" Font-Size="12pt" AutoPostBack="True" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged1"></asp:ListBox></td>
                                                <td rowspan="5" style="width: 77px">
                                                                <asp:Button ID="Button16" runat="server" OnClick="Button16_Click3" Text="Insertar" Width="75px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                    <br />
                                                                <asp:Button ID="Button32" runat="server" OnClick="Button32_Click1" Text="Modificar"
                                                                    Width="75px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                    <br />
                                                                <asp:Button ID="Button54" runat="server" OnClick="Button54_Click" Text="Eliminar"
                                                                    Width="75px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                    <br />
                                                    <asp:Button
                                                        ID="Button34" runat="server" Text="Cancelar" OnClick="Button34_Click" Width="75px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View21" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label123" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Configuración de Datos"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri; color: teal;">Insertar
                                                            Datos</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Nombre<asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="TextBox18"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td>
                                                            <asp:TextBox ID="TextBox18" runat="server" Width="170px" OnLoad="TextBox18_Load" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td style="text-align: left">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Tipo</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:DropDownList ID="DropDownList2" runat="server" Width="172px"  Font-Names="Calibri" Font-Size="10pt">
                                                            </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Tamaño<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBox22"
                                                                ErrorMessage="*" ValidationExpression="[1-9][0-9]*" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="TextBox22"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                            <asp:TextBox ID="TextBox22" runat="server" Width="170px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                            <asp:Button ID="Button63" runat="server"
                                                                Text="Aceptar" OnClick="Button63_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                            <asp:Button ID="Button74" runat="server" Text="Cancelar" OnClick="Button74_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View22" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label124" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Configuración de Datos"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri; color: teal;">Modificar Datos</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Nombre<asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="TextBox29"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td colspan="2">
                                                            <asp:TextBox ID="TextBox29" runat="server" Font-Names="Calibri" Font-Size="10pt" Height="25px" Width="170px"></asp:TextBox></td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td colspan="2">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Tipo</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                            <asp:DropDownList ID="DropDownList4" runat="server" Width="170px" Font-Names="Calibri" Font-Size="10pt" Height="25px">
                                                            </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Tamaño<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                ControlToValidate="TextBox24" ErrorMessage="*" ValidationExpression="[1-9][0-9]*" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="TextBox24"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                            <asp:TextBox ID="TextBox24" runat="server" Width="170px" Font-Names="Calibri" Font-Size="10pt" Height="25px"></asp:TextBox>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                            <asp:Button ID="Button75" runat="server"
                                                                Text="Aceptar" OnClick="Button75_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                        <asp:Button ID="Button76" runat="server" Text="Cancelar" OnClick="Button76_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px"  /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View23" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label125" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Gestionar Banco"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 613px;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static; height: 3px;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri; color: teal;">Listado de Bancos</span></strong></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                        <asp:ListBox ID="ListBox9" runat="server" Height="214px"
                                                                Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ListBox9_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                                    <td style="width: 82px; text-align: center;">
                                                                        <asp:Button ID="Button31" runat="server" Text="Insertar" Width="70px" OnClick="Button31_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                                        <asp:Button ID="Button58" runat="server" Text="Modificar" Width="70px" OnClick="Button58_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                                        <asp:Button ID="Button59" runat="server" Text="Eliminar" Width="70px" OnClick="Button59_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                            <asp:Button ID="Button78" runat="server" Text="Cancelar" OnClick="Button78_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;">
                                                            <asp:Button ID="Button60" runat="server" Text="Actualizar Sucursales" Width="136px" OnClick="Button60_Click" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                    <td style="width: 82px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            &nbsp;</asp:View>
                        <asp:View ID="View24" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label126" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Gestionar Banco"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <strong><span style="font-size: 14pt; color: teal; font-family: Calibri">Insertar Banco</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Nombre<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox45"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox45" runat="server" Width="200px" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Abreviatura</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                            <asp:TextBox ID="TextBox35" runat="server" Width="200px" Font-Names="Calibri" Font-Size="11pt" Height="23px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">ID de Banco<asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server"
                                                                ControlToValidate="TextBox36" ErrorMessage="*" ValidationExpression="[0-9][0-9]"></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox36"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox36" runat="server" Width="200px" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Web Services<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox46"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                                ControlToValidate="TextBox46" ErrorMessage="*" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox46" runat="server" Width="200px" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Contraseña<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox47"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox47" runat="server" Width="200px" Font-Names="Calibri" TextMode="Password" Font-Size="11pt"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                            <asp:Button ID="Button79" runat="server"
                                                                Text="Aceptar" OnClick="Button79_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                            <asp:Button ID="Button80" runat="server" Text="Cancelar" OnClick="Button80_Click1" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View25" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label127" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Gestionar Banco"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <br />
                                            <table>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <strong><span style="font-size: 14pt; color: teal; font-family: Calibri">Modificar
                                                            Banco</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; height: 21px">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Nombre</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:Label ID="Label8" runat="server" Width="200px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Abreviatura</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox15" runat="server" Width="200px" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">ID de Banco</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox25" runat="server" Width="200px" ReadOnly="True" Font-Names="Calibri" Font-Size="11pt" Height="23px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Web Services<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox037"
                                                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server"
                                                                ControlToValidate="TextBox037" ErrorMessage="*" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"
                                                                Width="9px"></asp:RegularExpressionValidator></span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox037" runat="server" Width="200px" Font-Names="Calibri" Font-Size="11pt" Height="23px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; height: 21px">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Contraseña</span></strong></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                            <asp:TextBox ID="TextBox038" runat="server" Width="200px" Font-Names="Calibri" TextMode="Password" Font-Size="11pt" Height="23px">pass</asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                            <asp:Button ID="Button40" runat="server" Text="Aceptar" OnClick="Button40_Click1" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                            <asp:Button ID="Button41" runat="server" Text="Cancelar" OnClick="Button41_Click1" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View0_26" runat="server">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 595px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                        <asp:Label ID="Label109" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Iniciar Reclamación"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <br />
                                        <table>
                                            <tr>
                                                <td style="width: 100px">
                                                </td>
                                                <td style="width: 37px; text-align: center;">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                                        ControlToValidate="TextBox1" ErrorMessage="*" 
                                                        ValidationExpression="[0-9][0-9]" Width="4px" Font-Names="Verdana" Font-Size="X-Small" EnableViewState="False"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox1"
                                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td style="width: 40px; text-align: center;">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                        ControlToValidate="TextBox14" ErrorMessage="*" 
                                                        ValidationExpression="[0-9][0-9][0-9][0-9]" Width="1px" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox14"
                                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                <td style="width: 59px; text-align: center;">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                                        ControlToValidate="TextBox23" ErrorMessage="*" 
                                                        ValidationExpression="[0-9][0-9][0-9][0-9]" Width="9px" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox23"
                                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri;">Tarjeta No:</span></strong></td>
                                                <td style="width: 37px">
                                                <input id="TextBox1" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox1',2,'TextBox14');"  onkeypress="SoloNumeros();" runat="server" maxlength="2" name="TextBox1" style="width: 35px"
                                                        type="text" /></td>
                                                <td style="width: 40px; text-align: center;">
                                                    <input id="TextBox14" runat="server" name="TextBox14" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox14',4,'TextBox23');" onkeypress="SoloNumeros();"
                                                        style="width: 55px" type="text" maxlength="4" /></td>
                                                <td style="width: 59px; text-align: center;">
                                                <input id="TextBox23" runat="server" name="TextBox23" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox23',4,'Button50');" onkeypress="SoloNumeros();" style="width: 55px" type="text" maxlength="4" /></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                </td>
                                                <td style="text-align: center;" colspan="3">
                                                    <asp:Button ID="Button50" runat="server" Text="Aceptar" OnClick="Button50_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" />&nbsp;
                                                    <asp:Button ID="Button51" runat="server" Text="Cancelar" OnClick="Button51_Click1" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                            </tr>
                                        </table>
                                        &nbsp;
                                        &nbsp;
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                         
                        </asp:View>
                        <asp:View ID="View26" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label108" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Iniciar Reclamación"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <br />
                                            <table cellpadding="0" cellspacing="0" style="width: 300px">
                                                <tr>
                                                    <td style="width: 5905px; height: 19px; text-align: center;">
                                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Cliente</strong></span></td>
                                                    <td style="text-align: center">
                                                    </td>
                                                    <td align="left" colspan="2" style="height: 19px">
                                                    </td>
                                                </tr>
                                                <tr style="font-size: 10pt; font-family: Verdana">
                                                    <td style="width: 5905px; text-align: center;" rowspan="5">
                                                        <span><strong><span style="font-family: Calibri"><span style="font-size: 12pt"><span>
                                                            <span style="font-size: 11pt"></span></span></span></span></strong></span><strong><span style="font-size: 11pt; font-family: Calibri">
                                                                <asp:Image ID="Image22" runat="server" ImageUrl="~/Images/Imagenes/Usuarios.png" /></span></strong></td>
                                                    <td rowspan="5" style="width: 2285px; text-align: center">
                                                    </td>
                                                    <td align="center" style="height: 7px; text-align: center;" colspan="2">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                                        <asp:Label ID="Label107" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            Text="Dígitos del PIN" ToolTip="Número de Identificación Personal PIN(Personal Identification Number)"></asp:Label></td>
                                                </tr>
                                                <tr style="font-size: 10pt; font-family: Verdana">
                                                    <td align="left" style="width: 128px; height: 5px; padding-bottom: 3px; text-align: center;">
                                                        &nbsp;&nbsp;</td>
                                                    <td align="left" style="padding-bottom: 3px; width: 43px; height: 5px; text-align: center;">
                                                    </td>
                                                </tr>
                                                <tr style="font-size: 10pt; font-family: Verdana">
                                                    <td align="left" style="padding-bottom: 3px; width: 128px; height: 5px; text-align: center">
                                                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                            ForeColor="Teal" Height="20px" Text="Primero" Width="60px"></asp:Label></td>
                                                    <td align="left" style="padding-bottom: 3px; width: 43px; height: 5px; text-align: center">
                                                        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                            ForeColor="Teal" Height="20px" Text="Cuarto" Width="60px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 128px; height: 23px; padding-bottom: 4px; padding-top: 3px; text-align: center;">
                                                        <%-- <asp:TextBox ID="TextBox41" runat="server" Width="78px" Font-Names="Verdana" Font-Size="Small" Height="15px" MaxLength="1"></asp:TextBox>--%>
                                                        <asp:TextBox ID="TextBox16" runat="server" Width="60px"></asp:TextBox></td>
                                                    <td align="left" style="padding-bottom: 4px; width: 43px; padding-top: 3px; height: 23px; text-align: center;">
                                                        <input id="TextBox17" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox17',1,'Button36');"  onkeypress="SoloNumeros();" runat="server" style="width: 60px; font-family: Verdana;"
                                                            type="text" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-bottom: 4px; width: 128px; padding-top: 3px; height: 23px;
                                        text-align: center">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                            ControlToValidate="TextBox16" ErrorMessage="*" ValidationExpression="[0-9]" Font-Names="Verdana" Font-Size="X-Small"></asp:RegularExpressionValidator>&nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox16"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                    <td align="left" style="padding-bottom: 4px; width: 43px; padding-top: 3px; height: 23px;
                                        text-align: center">
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server"
                                                            ControlToValidate="TextBox17" ErrorMessage="*" ValidationExpression="[0-9]" Font-Names="Verdana" Font-Size="X-Small" Width="10px"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox17"
                                                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 5905px; height: 23px; text-align: center;">
                                                        <strong><span style="font-size: 11pt; font-family: Calibri">
                                                            <asp:Label ID="Label3" runat="server" BackColor="White" BorderColor="Black" Font-Names="Calibri"
                                                                Font-Size="14pt" Text="Jose Rodriguez Delgado" ForeColor="Teal"></asp:Label></span></strong></td>
                                                    <td align="right" style="width: 2285px; height: 23px; text-align: center">
                                                    </td>
                                                    <td align="left" style="padding-bottom: 4px; width: 128px; padding-top: 3px; height: 23px">
                                                        &nbsp;<asp:Button ID="Button36" runat="server" Text="Aceptar" OnClick="Button64_Click" CausesValidation="False" Font-Names="Calibri" Width="60px" /></td>
                                                    <td align="center" style="padding-bottom: 4px; width: 43px; padding-top: 3px; height: 23px; text-align: center;">
                                                        <asp:Button ID="Button37" runat="server" Text="Cancelar" OnClick="Button65_Click" CausesValidation="False" Font-Names="Calibri" Width="60px" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="text-align: center">
                                                    </td>
                                                    <td align="right" style="text-align: center">
                                                    </td>
                                                    <td align="left" style="padding-bottom: 4px; width: 128px; padding-top: 3px; height: 23px">
                                                    </td>
                                                    <td align="center" style="padding-bottom: 4px; width: 43px; padding-top: 3px; height: 23px;
                                        text-align: center">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View27" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label104" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Iniciar Reclamación"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <br />
                                            <table>
                                                <tr>
                                                    <td style="width: 211px">
                                                        <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                                    </td>
                                                    <td style="width: 81px; text-align: center; font-size: 12pt; font-family: Times New Roman;">
                                                        <asp:Label ID="Label17" runat="server" BackColor="White" Font-Bold="True" Font-Names="Calibri"
                                                            Font-Size="14pt" ForeColor="Teal" Text="1B" Width="31px"></asp:Label></td>
                                                    <td style="width: 44px; font-size: 12pt; font-family: Times New Roman;">
                                                    </td>
                                                    <td style="width: 58px; font-size: 12pt; font-family: Times New Roman;">
                                                    </td>
                                                    <td style="width: 69px; font-size: 12pt; font-family: Times New Roman;">
                                                    </td>
                                                </tr>
                                                <tr style="font-size: 12pt; font-family: Times New Roman">
                                                    <td style="width: 211px">
                                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Coordenada de la matriz:
                                                        </strong></span>
                                                    </td>
                                                    <td style="width: 81px; text-align: center"><input id="TextBox19" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox19',2,'Button38');"  onkeypress="SoloNumeros();" runat="server" style="width: 50px; font-family: Verdana;" type="text" /></td>
                                                    <td style="width: 44px">
                                                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                            ControlToValidate="TextBox19" ErrorMessage="*" ValidationExpression="[0-9][0-9]"></asp:RegularExpressionValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="*" ControlToValidate="TextBox19"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 58px; text-align: center">
                                                        <asp:Button ID="Button38" runat="server" Text="Aceptar" OnClick="Button6_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    <td style="width: 69px; text-align: center">
                                                        <asp:Button ID="Button39" runat="server" Text="Cancelar" OnClick="Button5_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 211px">
                                                    </td>
                                                    <td style="width: 81px; text-align: center">
                                                    </td>
                                                    <td style="width: 44px">
                                                    </td>
                                                    <td style="width: 58px">
                                                    </td>
                                                    <td style="width: 69px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View28" runat="server" OnActivate="View28_Activate">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="width: 11px; height: 22px">
                                        </td>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label105" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Iniciar Reclamación"></asp:Label></td>
                                        <td style="width: 11px; height: 22px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 11px; height: 3px">
                                        </td>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <br />
                                            <table>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center; color: teal;">
                                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Campos de Búsquedas</strong></span></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; height: 21px;">
                                                    </td>
                                                    <td style="text-align: center; height: 21px;">
                                                        <strong><span style="font-family: Calibri">TRAZA<asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server"
                                                            ControlToValidate="TextBox26" ErrorMessage="*" ValidationExpression="BT[0-9]{4}" Width="5px"></asp:RegularExpressionValidator></span></strong></td>
                                                    <td style="width: 100px; height: 21px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:TextBox ID="TextBox26" runat="server" OnTextChanged="TextBox39_TextChanged"
                                                            Width="164px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <strong><span style="font-family: Calibri">FECHA</span></strong></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Calibri" Font-Size="10pt">
                                                            <asp:ListItem Value="  "></asp:ListItem>
                                                            <asp:ListItem>01</asp:ListItem>
                                                            <asp:ListItem>02</asp:ListItem>
                                                            <asp:ListItem>03</asp:ListItem>
                                                            <asp:ListItem>04</asp:ListItem>
                                                            <asp:ListItem>05</asp:ListItem>
                                                            <asp:ListItem>06</asp:ListItem>
                                                            <asp:ListItem>07</asp:ListItem>
                                                            <asp:ListItem>08</asp:ListItem>
                                                            <asp:ListItem>09</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>13</asp:ListItem>
                                                            <asp:ListItem>14</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>16</asp:ListItem>
                                                            <asp:ListItem>17</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>19</asp:ListItem>
                                                            <asp:ListItem>20</asp:ListItem>
                                                            <asp:ListItem>21</asp:ListItem>
                                                            <asp:ListItem>22</asp:ListItem>
                                                            <asp:ListItem>23</asp:ListItem>
                                                            <asp:ListItem>24</asp:ListItem>
                                                            <asp:ListItem>25</asp:ListItem>
                                                            <asp:ListItem>26</asp:ListItem>
                                                            <asp:ListItem>27</asp:ListItem>
                                                            <asp:ListItem>28</asp:ListItem>
                                                            <asp:ListItem>29</asp:ListItem>
                                                            <asp:ListItem>30</asp:ListItem>
                                                            <asp:ListItem>31</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="DropDownList6" runat="server" Font-Names="Calibri" Font-Size="10pt">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem>01</asp:ListItem>
                                                            <asp:ListItem>02</asp:ListItem>
                                                            <asp:ListItem>03</asp:ListItem>
                                                            <asp:ListItem>04</asp:ListItem>
                                                            <asp:ListItem>05</asp:ListItem>
                                                            <asp:ListItem>06</asp:ListItem>
                                                            <asp:ListItem>07</asp:ListItem>
                                                            <asp:ListItem>08</asp:ListItem>
                                                            <asp:ListItem>09</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="DropDownList7" runat="server" Font-Names="Calibri" Font-Size="10pt">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <strong><span style="font-family: Calibri">SERVICIO</span></strong></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:DropDownList ID="DropDownList11" runat="server" Width="170px" Font-Names="Calibri" Font-Size="10pt">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <strong><span style="font-family: Calibri">MONTO</span></strong></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:TextBox ID="TextBox63" runat="server" Font-Names="Calibri" OnTextChanged="TextBox39_TextChanged"
                                                            Width="170px" Font-Size="10pt"></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:Button ID="Button118" runat="server" OnClick="Button118_Click" Text="Mostrar"
                                                            Width="65px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px">
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="text-align: center">
                                                        <asp:Label ID="Label45" runat="server" Text="! 0 Transacciones encontradas para los datos proporcionados !" Visible="False" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" ForeColor="Red" Width="434px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="text-align: center">
                                                        <asp:DataGrid ID="DataGrid2" runat="server" OnPreRender="DataGrid2_PreRender" CellPadding="2" ForeColor="Black" GridLines="Horizontal" Width="562px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                                        <FooterStyle BackColor="#A2A764" />
                                                        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                        <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                                        <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                        <Columns>
                                                            <asp:TemplateColumn>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox runat="server" AutoPostBack="True" OnCheckedChanged="ValidarChequeadoPS" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="text-align: center">
                                                        <asp:Button ID="Button42" runat="server" OnClick="Button42_Click" Text="Aceptar"
                                                            Width="65px" CausesValidation="False" Visible="False" Font-Names="Calibri" Font-Size="11pt" />&nbsp; 
                                                        <asp:Button ID="Button43" runat="server" Text="Cancelar" Width="65px" OnClick="Button43_Click1" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                </tr>
                                            </table>
                                            &nbsp;</td>
                                        <td style="font-size: 12pt; width: 11px; font-family: Times New Roman; height: 3px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View29" runat="server" OnActivate="View29_Activate">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 629px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label103" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Iniciar Reclamación"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GridView1" runat="server" ShowHeader="False" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="12pt" GridLines="None" Width="400px">
                                                            <Columns>
                                                                <asp:BoundField DataField="nombre" ReadOnly="True" HeaderText="nombre" >
                                                                   <ControlStyle Font-Names="Verdana" Font-Size="13pt" />
                                                                    <ItemStyle Font-Names="Verdana" Font-Size="13pt" /> 
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="valor" ReadOnly="True" HeaderText="valor" >
                                                                    <ControlStyle Font-Names="Verdana" Font-Size="11pt" />
                                                                    <ItemStyle Font-Names="Verdana" Font-Size="11pt" /> 
                                                                </asp:BoundField>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 406px; text-align: center">
                                                        <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Descripción</strong></span></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="TextBox30" runat="server" Height="100px" TextMode="MultiLine" Width="400px" Font-Names="Calibri" Font-Size="12pt"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <asp:Button ID="Button44" runat="server" Text="Aceptar" Width="65px" OnClick="Button44_Click1" Font-Names="Calibri" Font-Size="11pt" />&nbsp;
                                                        <asp:Button ID="Button45" runat="server" Text="Cancelar" Width="65px" OnClick="Button45_Click" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="font-size: 12pt; font-family: Times New Roman">
                                        <td style="width: 629px; height: 22px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View30" runat="server" OnActivate="View30_Activate">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label84" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Conciliaciones Auxiliares"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td colspan="2" style="height: 25px; text-align: left">
                                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Conciliaciones de:</strong></span></td>
                                                    <td style="width: 72px; height: 25px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: justify">
                                                            <asp:RadioButtonList ID="RadioButtonList11" runat="server" Font-Size="14pt" Width="162px" Font-Names="Calibri" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList11_SelectedIndexChanged">
                                                                <asp:ListItem>Transacciones</asp:ListItem>
                                                                <asp:ListItem>Reclamaciones</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    <td style="width: 72px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: left">
                                                            <asp:Label ID="Label14" runat="server" Text="Para enviar a:" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt" Visible="False" ToolTip="Bancos Asociados"></asp:Label></td>
                                                    <td style="width: 72px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                        <asp:ListBox ID="ListBox14" runat="server" Font-Names="Calibri" Font-Size="12pt" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="ListBox14_SelectedIndexChanged"></asp:ListBox></td>
                                                    <td style="width: 72px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: left">
                                                            <asp:Label ID="Label25" runat="server" Text="Fecha:" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt" Visible="False"></asp:Label></td>
                                                    <td style="width: 72px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                            <asp:Calendar ID="Calendar3" runat="server" Height="150px" Width="180px" Font-Size="10pt" Font-Names="Calibri" Visible="False" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" ForeColor="Black" OnDayRender="Calendar3_DayRender" ShowGridLines="True">
                                                                <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                    </td>
                                                    <td style="width: 72px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: center">
                                                        <asp:Button ID="Button46" runat="server" Text="Aceptar" OnClick="Button46_Click" Visible="False" Width="65px" Font-Names="Calibri" Font-Size="11pt" />&nbsp;
                                                        <asp:Button ID="Button48" runat="server" Text="Enviar" Width="65px" Visible="False" OnClick="Button48_Click" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                    <td style="width: 72px; text-align: center">
                                                        <asp:Button ID="Button47" runat="server" Text="Cancelar" Visible="False" Width="65px" OnClick="Button47_Click" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View31" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 608px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label102" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Conciliaciones Auxiliares"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <br />
                                            <table>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">Tarjetas Deshabilitadas</strong></span></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="ListBox15" runat="server" Height="100px" Width="220px" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View32" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            &nbsp;<asp:Label ID="Label101" runat="server" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="#FFFFCC" Text="Actualizar Información"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 613px;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static; height: 3px;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <span style="font-size: 14pt; color: green; font-family: Calibri"><strong style="color: teal">BANCOS</strong></span></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="ListBox16" runat="server" Width="300px" Font-Names="Calibri" Font-Size="12pt" Height="140px" AutoPostBack="True" OnSelectedIndexChanged="ListBox16_SelectedIndexChanged"></asp:ListBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 25px; text-align: center">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Actualizar Todos" Font-Names="Calibri" Font-Size="14pt" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged1" Font-Bold="False" /></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <asp:Button ID="Button49" runat="server" Text="Aceptar" OnClick="Button49_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" />&nbsp;
                                                        <asp:Button ID="Button53" runat="server" OnClick="Button53_Click1"
                                                            Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View33" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label99" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Contratar Servicio"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <strong><span style="font-size: 14pt; color: teal; font-family: Calibri">
                                                            <asp:Label ID="Label100" runat="server" Text="Servicios Contratados" Width="180px" ForeColor="Teal"></asp:Label></span></strong></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList5" runat="server" Width="250px" Font-Names="Calibri" Font-Size="10pt">
                                                            <asp:ListItem></asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="Label20"
                                                            runat="server" Text="Servicios Activos" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"></asp:Label></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <asp:ListBox ID="ListBox5" runat="server" Height="150px" Width="250px" Font-Names="Calibri" Font-Size="12pt" AutoPostBack="True" OnSelectedIndexChanged="ListBox5_SelectedIndexChanged"></asp:ListBox></td>
                                                    <td>
                                                        <asp:Button ID="Button61"
                                                            runat="server" Enabled="False" Text="Contratar" OnClick="Button61_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" /><br />
                                                        <br />
                                                        <asp:Button ID="Button62" runat="server" Enabled="False" OnClick="Button62_Click"
                                                            Text="Modificar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /><br />
                                                        <br />
                                                        <asp:Button ID="Button66" runat="server" Enabled="False" Text="Eliminar" OnClick="Button66_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" /><br />
                                                        <br />
                                                        <asp:Button ID="Button82" runat="server" OnClick="Button82_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View34" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 608px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label98" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Contratar Servicio"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <table>
                                                <tr>
                                                    <td colspan="4" style="height: 25px; text-align: center">
                                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Asociados de </strong></span>
                                                            <asp:Label ID="Label21" runat="server" Text="Label" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Cantidad de Asociados a
                                                            Contratar</strong></span></td>
                                                    <td style="width: 97px; text-align: left">
                                                        <asp:TextBox ID="TextBox48" runat="server" OnTextChanged="TextBox48_TextChanged"
                                                            Width="29px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox><span style="font-size: 10pt">
                                                                <span style="font-family: Calibri"><strong>Max (5)</strong></span></span></td>
                                                    <td style="width: 80px">
                                                        <asp:Button ID="Button81" runat="server" OnClick="Button81_Click" Text="Continuar" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">
                                                    </td>
                                                    <td style="width: 141px">
                                                    </td>
                                                    <td style="width: 97px">
                                                    </td>
                                                    <td style="width: 80px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">
                                                    </td>
                                                    <td style="width: 141px">
                                                        <asp:TextBox ID="TextBox33" runat="server" OnTextChanged="TextBox33_TextChanged"
                                                            Visible="False" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                    <td style="width: 97px">
                                                        <asp:Button ID="Button92" runat="server" OnClick="Button92_Click" Text="Cliente"
                                                            Visible="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    <td style="width: 80px">
                                                        <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="12pt" Font-Bold="True" ForeColor="Green"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">
                                                    </td>
                                                    <td style="width: 141px">
                                                        <asp:TextBox ID="TextBox34" runat="server" OnTextChanged="TextBox34_TextChanged"
                                                            Visible="False" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                    <td style="width: 97px">
                                                        <asp:Button ID="Button93" runat="server" OnClick="Button93_Click" Text="Cliente"
                                                            Visible="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    <td style="width: 80px">
                                                        <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                            ForeColor="Green"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">
                                                    </td>
                                                    <td style="width: 141px">
                                                        <asp:TextBox ID="TextBox39" runat="server" OnTextChanged="TextBox39_TextChanged1"
                                                            Visible="False" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                    <td style="width: 97px">
                                                        <asp:Button ID="Button94" runat="server" OnClick="Button94_Click" Text="Cliente"
                                                            Visible="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    <td style="width: 80px">
                                                        <asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                            ForeColor="Green"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">
                                                    </td>
                                                    <td style="width: 141px">
                                                        <asp:TextBox ID="TextBox40" runat="server" OnTextChanged="TextBox40_TextChanged"
                                                            Visible="False" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                    <td style="width: 97px">
                                                        <asp:Button ID="Button95" runat="server" OnClick="Button95_Click" Text="Cliente"
                                                            Visible="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    <td style="width: 80px">
                                                        <asp:Label ID="Label30" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                            ForeColor="Green"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">
                                                    </td>
                                                    <td style="width: 141px">
                                                        <asp:TextBox ID="TextBox44" runat="server" Visible="False" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                    <td style="width: 97px">
                                                        <asp:Button ID="Button96" runat="server" OnClick="Button96_Click" Text="Cliente"
                                                            Visible="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    <td style="width: 80px">
                                                        <asp:Label ID="Label35" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                            ForeColor="Green"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;" colspan="3">
                                                    </td>
                                                    <td style="width: 80px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 115px">
                                                    </td>
                                                    <td style="width: 141px">
                                                    </td>
                                                    <td style="width: 97px">
                                                        <asp:Button ID="Button67" runat="server" OnClick="Button67_Click" Text="Aceptar"
                                                            Width="65px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                                    <td style="width: 80px">
                                                        <asp:Button ID="Button77" runat="server" Text="Cancelar" OnClick="Button77_Click" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View35" runat="server">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                            height: 22px; background-color: darkslategray">
                                            <asp:Label ID="Label96" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Modificar Servicio"></asp:Label></td>
                                        <td style="height: 22px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                            padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                            padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                            text-align: center">
                                            <br />
                                            <table>
                                                <tr>
                                                    <td style="width: 268px; text-align: center">
                                                        <span style="font-size: 14pt; font-family: Calibri"><strong style="color: teal">Identificadores Asociados</strong></span></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 268px; text-align: center">
                                                        <asp:DataGrid ID="DataGrid1" runat="server" OnPreRender="DataGrid1_PreRender" OnSelectedIndexChanged="DataGrid1_SelectedIndexChanged" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" Font-Names="Calibri" Font-Size="12pt" ForeColor="Black" GridLines="None" ShowFooter="True" Width="250px">
                                                            <Columns>
                                                                <asp:TemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" AutoPostBack="True" OnCheckedChanged="ValidarChequeadoPS" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                            <FooterStyle BackColor="#A2A764" />
                                                            <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                            <AlternatingItemStyle BackColor="PaleGoldenrod" />
                                                            <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                        </asp:DataGrid></td>
                                                    <td style="text-align: left">
                                                        <asp:Button ID="Button124" runat="server" Font-Names="Calibri" Font-Size="11pt" OnClick="Button124_Click"
                                                            Text="Agregar" Width="70px" /><br />
                                                        <br />
                                                        <asp:Button ID="Button83" runat="server" Enabled="False" Text="Eliminar" OnClick="Button83_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" /><br />
                                                        <br />
                                            <asp:Button ID="Button85" runat="server" Text="Guardar" Width="70px" OnClick="Button85_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                                        <br />
                                                        <asp:Button ID="Button86" runat="server" OnClick="Button86_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 268px; height: 196px; text-align: center">
                                                        <asp:Panel ID="Panel6" runat="server" Visible="False" Width="100%">
                                                            <table style="border-right: green thin double; border-top: green thin double; border-left: green thin double;
                                                                border-bottom: green thin double">
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center">
                                                                        <asp:Label ID="Label97" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                                            Text="ID del Cliente para este Servicio" ForeColor="Teal"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center">
                                                                        <asp:TextBox ID="TextBox49" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox49',15,'Button91');" runat="server" MaxLength="15"></asp:TextBox>&nbsp;<asp:Button
                                                            ID="Button91" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'Button91',0,'Button84');" runat="server" OnClick="Button91_Click" Text="Identificar" Font-Names="Calibri" Font-Size="11pt" Height="25px" Width="80px" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center; height: 25px;">
                                                                        <strong><span style="font-size: 14pt; font-family: Calibri">Cliente:</span></strong></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center">
                                                                        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" ForeColor="Green">???</asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="text-align: center; height: 29px;">
                                                        <asp:Button ID="Button84" runat="server" OnClick="Button84_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                    <td style="height: 196px">
                                                    </td>
                                                </tr>
                                            </table>
                                            &nbsp;&nbsp;</td>
                                        <td style="font-size: 12pt; font-family: Times New Roman; height: 3px">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:View>
                        <asp:View ID="View36" runat="server" OnActivate="View36_Activate">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 21px; background-color: darkslategray">
                                        <asp:Label ID="Label95" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Reporte Contratos"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <table>
                                            <tr>
                                                <td style="text-align: right">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>
                                        Clasificado por:</strong></span></td>
                                                <td>
                                        <asp:DropDownList ID="DropDownList8" runat="server" Width="170px" Font-Names="Calibri" Font-Size="10pt">
                                            <asp:ListItem>Todos</asp:ListItem>
                                            <asp:ListItem>Contratar Servicio</asp:ListItem>
                                            <asp:ListItem>Modificacion del Contrato</asp:ListItem>
                                            <asp:ListItem>Eliminar Servicio</asp:ListItem>
                                        </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Operador:</strong></span></td>
                                                <td>
                                        <asp:TextBox ID="TextBox57" runat="server" Width="170px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Servicio:</strong></span></td>
                                                <td>
                                        <asp:DropDownList ID="DropDownList10" runat="server" Width="170px" Font-Names="Calibri" Font-Size="10pt">
                                            <asp:ListItem>Todos</asp:ListItem>
                                            <asp:ListItem>Aguas</asp:ListItem>
                                            <asp:ListItem>Electrica</asp:ListItem>
                                            <asp:ListItem>Etecsa</asp:ListItem>
                                        </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="Panel5" runat="server" Height="25px" Width="100%">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>DESDE</strong></span></td>
                                                <td style="text-align: center;">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>HASTA</strong></span></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 183px">
                                                    <asp:Calendar ID="Calendar6" runat="server" SelectedDate="2007-07-12" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" Height="150px" ShowGridLines="True" Width="180px" OnDayRender="Calendar6_DayRender">
                                                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                                <td>
                                                    <asp:Calendar ID="Calendar7" runat="server" SelectedDate="2007-07-12" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" Height="150px" ShowGridLines="True" Width="180px" OnDayRender="Calendar7_DayRender">
                                                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Button ID="Button88" runat="server" OnClick="Button88_Click1" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" />&nbsp; 
                                                    <asp:Button ID="Button87" runat="server" OnClick="Button87_Click1" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View37" runat="server" OnActivate="View37_Activate">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 21px; background-color: darkslategray">
                                        <asp:Label ID="Label94" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Reporte Reclamaciones"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <br />
                                        <table>
                                            <tr>
                                                <td style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">DESDE</span></strong></td>
                                                <td style="text-align: center">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>HASTA</strong></span></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Calendar ID="Calendar8" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" Height="150px" OnDayRender="Calendar8_DayRender" ShowGridLines="True" Width="180px">
                                                        <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                                <td>
                                                    <asp:Calendar ID="Calendar9" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" Height="150px" OnDayRender="Calendar9_DayRender" ShowGridLines="True" Width="180px">
                                                        <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="text-align: center">
                                                    <asp:Button ID="Button89" runat="server" OnClick="Button89_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" />&nbsp; 
                                                    <asp:Button ID="Button90" runat="server" OnClick="Button90_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View38" runat="server">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                        <asp:Label ID="Label26" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Consulta de Saldo Integrada"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <br />
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <span style="font-size: 14pt; color: green; font-family: Calibri">
                                                        <asp:Label ID="Label136" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                            ForeColor="Teal" Text="Cuentas del Cliente en su Banco"></asp:Label></span></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:GridView ID="GridView2" runat="server" CellPadding="2" ForeColor="Black" GridLines="Vertical"
                                                        Visible="False" Width="570px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Names="Calibri" Font-Size="14pt" ShowFooter="True">
                                                        <FooterStyle BackColor="#A2A764" />
                                                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                        <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" Font-Size="12pt" />
                                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center;">
                                                    <asp:Label ID="Label36" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                        <asp:TextBox ID="TextBox50" runat="server" Visible="False" OnTextChanged="TextBox50_TextChanged"></asp:TextBox>
                                                        <asp:Button ID="Button97" runat="server" OnClick="Button97_Click" Text="Buscar" Enabled="False" Visible="False" /></td>
                                            </tr>
                                        </table>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:View><asp:View ID="View39" runat="server" OnActivate="View39_Activate">
                            <table width="100%" cellpadding="0" cellspacing="0" id="TABLE2" onclick="return TABLE2_onclick()">
                                <tr>
                                    <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana; text-align: center;">
                                        <asp:Label ID="Label87" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                            Text="Captación de Datos para el Pago del Servicio de Multas"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                        <table>
                                            <tr style="font-size: 12pt">
                                                <td colspan="2" style="background-color: #a2a764; height: 20px; text-align: center;">
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Calibri"
                                                        Font-Size="Medium" ForeColor="White" NavigateUrl="~/Images/Imagenes/multas_reverso.PNG"
                                                        Target="_blank">Reverso del Talón</asp:HyperLink></td>
                                                <td style="height: 20px; background-color: #a2a764;" colspan="2">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri"></span></strong>
                                                </td>
                                                <td rowspan="10" style="width: 3px; background-color: #a2a764">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" rowspan="8" style="border-right: #a2a764 2px solid; border-top: #a2a764 2px solid;
                                                    border-left: #a2a764 2px solid; border-bottom: #a2a764 2px solid; text-align: center">
                                                    <asp:Image ID="Image25" runat="server" ImageUrl="~/Images/Imagenes/Talon_Multas.png" /></td>
                                                <td style="text-align: left">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Folio:
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator36" runat="server"
                                                        ControlToValidate="TextBox55" ErrorMessage="*" ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9]"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator38" runat="server" ControlToValidate="TextBox55" ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="TextBox55" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox55',6,'DropDownList13');" onkeypress="SoloNumeros();" runat="server" MaxLength="6" Font-Names="Calibri" Font-Size="10pt" Width="95px" AutoPostBack="True"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Artículo:</span></strong></td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="DropDownList13" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                                        DataTextField="articulo" DataValueField="articulo" Width="100px" OnSelectedIndexChanged="DropDownList13_SelectedIndexChanged">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">
                                                    Inciso:</span></strong></td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="DropDownList14" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                                                        DataTextField="inciso" DataValueField="inciso" Width="100px" OnSelectedIndexChanged="DropDownList14_SelectedIndexChanged">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Peligrosidad:</span></strong></td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="DropDownList16" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
                                                        DataTextField="peligrosidad" DataValueField="peligrosidad" Width="100px" Enabled="False" OnSelectedIndexChanged="DropDownList16_SelectedIndexChanged">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">Dígito:<asp:RegularExpressionValidator ID="RegularExpressionValidator35" runat="server"
                                                        ControlToValidate="DropDownList15" ErrorMessage="*" ValidationExpression="[a-zA-Z]"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator37" runat="server" ControlToValidate="DropDownList15" ErrorMessage="*"></asp:RequiredFieldValidator></span></strong></td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="DropDownList15" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList15_SelectedIndexChanged">
                                                        <asp:ListItem Value="null">-D&#237;gito-</asp:ListItem>
                                                        <asp:ListItem>A</asp:ListItem>
                                                        <asp:ListItem>B</asp:ListItem>
                                                        <asp:ListItem>C</asp:ListItem>
                                                        <asp:ListItem>D</asp:ListItem>
                                                        <asp:ListItem>E</asp:ListItem>
                                                        <asp:ListItem>F</asp:ListItem>
                                                        <asp:ListItem>G</asp:ListItem>
                                                        <asp:ListItem>H</asp:ListItem>
                                                        <asp:ListItem>I</asp:ListItem>
                                                        <asp:ListItem>J</asp:ListItem>
                                                        <asp:ListItem>K</asp:ListItem>
                                                        <asp:ListItem>L</asp:ListItem>
                                                        <asp:ListItem>M</asp:ListItem>
                                                        <asp:ListItem>N</asp:ListItem>
                                                        <asp:ListItem>&#209;</asp:ListItem>
                                                        <asp:ListItem>O</asp:ListItem>
                                                        <asp:ListItem>P</asp:ListItem>
                                                        <asp:ListItem>Q</asp:ListItem>
                                                        <asp:ListItem>R</asp:ListItem>
                                                        <asp:ListItem>S</asp:ListItem>
                                                        <asp:ListItem>T</asp:ListItem>
                                                        <asp:ListItem>U</asp:ListItem>
                                                        <asp:ListItem>V</asp:ListItem>
                                                        <asp:ListItem>W</asp:ListItem>
                                                        <asp:ListItem>X</asp:ListItem>
                                                        <asp:ListItem>Y</asp:ListItem>
                                                        <asp:ListItem>Z</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <span style="font-size: 14pt; font-family: Calibri"><strong>94-1<asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator44" runat="server" ControlToValidate="RadioButtonList16"
                                                        ErrorMessage="*"></asp:RequiredFieldValidator></strong></span></td>
                                                <td style="text-align: center">
                                                    <asp:RadioButtonList ID="RadioButtonList16" runat="server" AutoPostBack="True" Font-Bold="True"
                                                        Font-Names="Calibri" ForeColor="Red" OnSelectedIndexChanged="RadioButtonList16_SelectedIndexChanged"
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="0">S&#237;</asp:ListItem>
                                                        <asp:ListItem Value="1">No</asp:ListItem>
                                                    </asp:RadioButtonList></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <strong><span style="font-size: 14pt; font-family: Calibri">
                                                    <asp:Label ID="Label134" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt">Fecha</asp:Label></span></strong></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    <asp:Calendar ID="Calendar10" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="9pt"
                                                        ForeColor="Black" Height="150px" Width="202px" OnDayRender="Calendar10_DayRender" BorderWidth="1px" ShowGridLines="True" OnSelectionChanged="Calendar10_SelectionChanged">
                                                        <SelectedDayStyle BackColor="Lime" Font-Bold="True" ForeColor="White" />
                                                        <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                        <SelectorStyle BackColor="#FFCC66" />
                                                        <OtherMonthDayStyle ForeColor="#CC9966" />
                                                        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                        <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                    </asp:Calendar>
                                                    <asp:Button ID="Button139" runat="server" OnClick="Button139_Click" Text="Procesar" /></td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: #a2a764; text-align: center">
                                                    <strong><span style="color: #ffffcc; font-family: Calibri">Importe</span></strong></td>
                                                <td style="background-color: #a2a764; text-align: center">
                                                    <strong><span style="color: #ffffcc; font-family: Calibri">A Pagar</span></strong></td>
                                                <td colspan="2" style="background-color: #a2a764; text-align: center">
                                                    <span style="color: teal;"></span><span style="color: #ffffcc;
                                                        font-family: Calibri;"><strong>Efectuar Pago</strong></span></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <span style="color: teal; font-family: Calibri"><strong>&nbsp;<span style="color: black">$</span></strong><span
                                                        style="font-size: 14pt; color: #000000"><strong> </strong>
                                                    <asp:Label ID="Label37" runat="server" ForeColor="#FF8000" Font-Names="Calibri" Font-Size="14pt"></asp:Label></span></span></td>
                                                <td style="text-align: center">
                                                    <strong><span style="font-family: Calibri">$ </span></strong>
                                                    <asp:Label ID="Label39" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FF8000"></asp:Label></td>
                                                <td style="text-align: center">
                                                    <span style="font-family: Calibri">
                                        <asp:Button ID="Button99" runat="server" Enabled="False" Text="Sí" OnClick="Button99_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" Font-Bold="True" ForeColor="Black" /></span></td>
                                                <td style="text-align: center">
                                                    <span style="font-family: Calibri">
                                                    <asp:Button
                                            ID="Button101" runat="server" OnClick="Button101_Click" Text="No" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="65px" Font-Bold="True" ForeColor="Black" /></span></td>
                                                <td style="width: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="background-color: darkslategray; text-align: center">
                                                    <strong><span style="color: #ffffcc; font-family: Calibri">!!! Información del Sistema
                                                        !!!</span></strong></td>
                                                <td style="width: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center">
                                                    <asp:Label ID="Label163" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt">---</asp:Label></td>
                                                <td style="width: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="background-color: darkslategray; text-align: center">
                                                </td>
                                                <td style="width: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: center">
                                                    <asp:Panel ID="Panel9" runat="server" Height="20px" Width="500px">
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                                            SelectCommand="SELECT DISTINCT articulo FROM TLB_Multas ORDER BY articulo "></asp:SqlDataSource>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                                            SelectCommand="SELECT inciso FROM TLB_Multas WHERE (articulo = @articulo) ORDER BY inciso">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="DropDownList13" Name="articulo" PropertyName="SelectedValue" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                                            SelectCommand="SELECT peligrosidad FROM TLB_Multas WHERE (articulo = @art) AND (inciso = @inc) ORDER BY peligrosidad">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="DropDownList13" Name="art" PropertyName="SelectedValue" />
                                                                <asp:ControlParameter ControlID="DropDownList14" Name="inc" PropertyName="SelectedValue" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </asp:Panel>
                                                </td>
                                                <td style="width: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        &nbsp;
                                        &nbsp; &nbsp;&nbsp;</td>
                                </tr>
                            </table>
                        </asp:View>
                        &nbsp;
                        <asp:View ID="View40" runat="server" OnActivate="View40_Activate">
                            <table width="100%">
                                <tr>
                                    <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                        <strong><span style="background-color: darkslategray">
                                            <asp:Label ID="Label73" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                Text="Servicio al Cliente"></asp:Label></span></strong></td>
                                </tr>
                                <tr>
                                    <td style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                                        padding-left: 15px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 538px;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; height: 21px; text-align: justify" valign="top">
                                        <span style="font-size: 10pt;"><span><strong><span style="font-size: 14pt; font-family: Calibri;">
                                        </span>
                                            <br />
                                        </strong><span style="font-family: Calibri"><span style="font-size: 14pt">
                                        </span></span><span
                                                    style="font-family: Calibri"><span
                                                        style="font-size: 14pt">
                                                        <table style="font-size: 14pt; text-align: center">
                                                            <tr>
                                                                <td colspan="3" style="text-align: justify">
                                                                    Datos del<strong> </strong>cliente&nbsp;
                                            <asp:Label ID="Label41" runat="server" BackColor="White" BorderColor="Black" Font-Names="Calibri"
                                                Font-Size="14pt" Text="Jose Rodriguez Delgado" ForeColor="Teal"></asp:Label>&nbsp;validados<span style="font-family: Calibri"><span style="font-size: 14pt"> con éxito en el sistema, </span>
                                                                    <asp:Label ID="Label72" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="Teal"></asp:Label>
                                                                    <span style="font-size: 14pt">ahora puedes realizar las operaciones que el cliente te solicite.</span></span></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="text-align: center;">
                                                                    <asp:Panel ID="Panel8" runat="server" Height="20px">
                                                                    </asp:Panel>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="color: teal">
                                                                    <strong>SERVICIOS CONTRATADOS</strong></td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="height: 158px; text-align: center" valign="top">
                                                                    <asp:GridView ID="GridView5" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                                                        BorderWidth="1px" CellPadding="2" Font-Names="Calibri" Font-Size="14pt" ForeColor="Black"
                                                                        GridLines="Horizontal" ShowHeader="False" Width="200px">
                                                                        <FooterStyle BackColor="#A2A764" />
                                                                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                                        <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                                    </asp:GridView>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                    </span></span></span></span></td>
                                </tr>
                            </table>
                            &nbsp;</asp:View><asp:View ID="View41" runat="server" OnActivate="View41_Activate">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                            <strong><span>
                                                <asp:Label ID="Label74" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Servicio al Cliente"></asp:Label></span></strong></td>
                                    </tr>
                                    <tr>
                                        <td style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                                        padding-left: 15px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 538px;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; height: 21px; text-align: center" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><span lang="ES-TRAD" style="font-size: 14pt;
                                            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-TRAD; mso-fareast-language: EN-US;
                                            mso-bidi-language: AR-SA; mso-bidi-font-size: 10.0pt; mso-bidi-font-family: Arial"><span
                                                style="font-family: Calibri"><strong>
                                                    <br />
                                                    Cliente</strong>&nbsp; </span>
                                            <asp:Label ID="Label42" runat="server" BackColor="White" BorderColor="Black" Font-Names="Calibri"
                                                Font-Size="14pt" Text="Jose Rodriguez Delgado" ForeColor="Teal"></asp:Label><span style="font-family: Calibri">
                                                    desconectado del sistema.<br />
                                                    <br />
                                                </span></span></span></td>
                                    </tr>
                                </table>
                                &nbsp;</asp:View><asp:View ID="View42" runat="server" OnActivate="View42_Activate">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 21px; background-color: darkslategray">
                                                <asp:Label ID="Label88" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Reporte Tarjetas Calientes"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; text-align: right">
                                                            <span style="font-family: Calibri; font-size: 14pt;"><strong>Descripción: </strong></span>
                                                        </td>
                                                        <td colspan="2" style="font-size: 12pt; text-align: left">
                                                <asp:DropDownList ID="DropDownList9" runat="server" Width="110px" Font-Names="Calibri" Font-Size="10pt">
                                                    <asp:ListItem>Todos</asp:ListItem>
                                                    <asp:ListItem Value="P">Pedidas</asp:ListItem>
                                                    <asp:ListItem Value="D">Deshabilitadas</asp:ListItem>
                                                </asp:DropDownList></td>
                                                    </tr>
                                                    <tr style="font-size: 12pt">
                                                        <td style="width: 100px; text-align: right">
                                                            <span style="font-family: Calibri; font-size: 14pt;"><strong>Operador:</strong></span></td>
                                                        <td colspan="2" style="text-align: left">
                                                <asp:TextBox ID="TextBox56" runat="server" Width="110px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                                    </tr>
                                                    <tr style="font-size: 12pt">
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr style="font-size: 12pt">
                                                        <td style="text-align: center">
                                                            <span style="font-family: Calibri; font-size: 14pt;"><strong>DESDE</strong></span></td>
                                                        <td colspan="2" style="text-align: center">
                                                            <span style="font-family: Calibri; font-size: 14pt;"><strong>HASTA</strong></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Calendar ID="Calendar11" runat="server" SelectedDate="2007-07-12" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" Height="150px" OnDayRender="Calendar11_DayRender" ShowGridLines="True" Width="180px">
                                                                <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                                    ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Calendar ID="Calendar12" runat="server" SelectedDate="2007-07-12" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" Height="150px" OnDayRender="Calendar12_DayRender" ShowGridLines="True" Width="180px">
                                                                <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                                                    ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: justify">
                                                        </td>
                                                        <td style="text-align: center" colspan="2">
                                                            <asp:Button ID="Button102" runat="server" OnClick="Button102_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Height="25px" Width="65px" />&nbsp; 
                                                            <asp:Button ID="Button103" runat="server" OnClick="Button87_Click1" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Height="25px" Width="65px" /></td>
                                                    </tr>
                                                </table>
                                                &nbsp; &nbsp;&nbsp;&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:View><asp:View ID="View43" runat="server" OnActivate="View43_Activate">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                                <asp:Label ID="Label129" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Consultar Datos de Tarjeta"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td colspan="5" style="text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong style="color: teal">Tarjeta No: </strong></span>
                                                                <asp:TextBox ID="TextBox58" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox58',10,'Button104');" runat="server" Font-Names="Calibri" Font-Size="11pt" Width="150px"></asp:TextBox>&nbsp;
                                                                <asp:Button ID="Button104" runat="server" OnClick="Button104_Click" Text="Buscar" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5">
                                                            <asp:Panel ID="Panel7" runat="server" Height="23px" Width="550px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" style="text-align: center">
                                                <asp:GridView ID="GridView3" runat="server" CellPadding="2" Font-Size="12pt" ForeColor="Black"
                                                    GridLines="Horizontal" Visible="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Names="Calibri" ShowFooter="True">
                                                    <FooterStyle BackColor="#A2A764" />
                                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" style="text-align: center"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" rowspan="1" style="text-align: center">
                                                            <asp:Label ID="Label166" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"
                                                                Text="HISTORIAL DE ESTADOS"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" rowspan="1" style="text-align: center">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" rowspan="1" style="text-align: center">
                                                            <asp:GridView ID="GridView9" runat="server" CellPadding="2" Font-Size="12pt" ForeColor="Black"
                                                    GridLines="Horizontal" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Names="Calibri" ShowFooter="True" DataSourceID="SqlDataSource6" Width="600px" AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Actividad" HeaderText="Actividad" SortExpression="Actividad">
                                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="fecha" HeaderText="Fecha y Hora" SortExpression="fecha">
                                                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <FooterStyle BackColor="#A2A764" />
                                                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                                <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                            </asp:GridView>
                                                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                                                SelectCommand="SELECT fecha, Actividad, Estado FROM TLB_HistoricoTarjetas WHERE (NoTarjeta = @tarjeta) ORDER BY fecha DESC">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="TextBox58" Name="tarjeta" PropertyName="Text" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" rowspan="1" style="text-align: center">
                                                            <asp:Label ID="Label167" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"
                                                                Text="HISTORIAL DE OPERACIONES"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" rowspan="1" style="text-align: center"><asp:GridView ID="GridView10" runat="server" CellPadding="2" Font-Size="12pt" ForeColor="Black"
                                                    GridLines="Horizontal" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Names="Calibri" ShowFooter="True" DataSourceID="SqlDataSource7" Width="600px" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:BoundField DataField="Id_Usuario" HeaderText="Usuario" SortExpression="Id_Usuario">
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SERV_NOM" HeaderText="Servicio" SortExpression="SERV_NOM">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Traza" HeaderText="Traza" SortExpression="Traza">
                                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" SortExpression="FechaHora">
                                                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <FooterStyle BackColor="#A2A764" />
                                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                            <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                        </asp:GridView>
                                                            <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                                                SelectCommand="SELECT DISTINCT TLB_Transaccion.Traza, TLB_Transaccion.Id_Usuario, TLB_Transaccion.FechaHora, TLB_C_SERVBT.SERV_NOM FROM TLB_DatosTransaccion INNER JOIN TLB_Transaccion ON TLB_DatosTransaccion.Id_Transaccion = TLB_Transaccion.Id_Transaccion INNER JOIN TLB_C_SERVBT ON TLB_Transaccion.ID_SERV = TLB_C_SERVBT.ID_SERV WHERE (TLB_Transaccion.Id_NoTarjeta = @tarjeta) ORDER BY TLB_Transaccion.FechaHora DESC">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="TextBox58" Name="tarjeta" PropertyName="Text" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" rowspan="1" style="text-align: center">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View><asp:View ID="View44" runat="server" OnActivate="View44_Activate">
                                    <table width="100%" cellpadding="0" cellspacing="0" id="Table3" onclick="return TABLE2_onclick()">
                                        <tr>
                                            <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                                <asp:Label ID="Label93" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Reporte Diario"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong>FECHA</strong></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <asp:Calendar ID="Calendar13" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                        ForeColor="Black" Height="150px" Width="180px" BorderWidth="1px" OnDayRender="Calendar13_DayRender" ShowGridLines="True">
                                                                <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Button ID="Button105" runat="server" OnClick="Button105_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" />&nbsp;
                                                            <asp:Button ID="Button106" runat="server" OnClick="Button106_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View><asp:View ID="View45" runat="server" OnActivate="View45_Activate">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                                <asp:Label ID="Label128" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Reversar Transacción"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                <table>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <span style="font-size: 10pt"></span>
                                                        </td>
                                                        <td style="width: 88px">
                                                        </td>
                                                        <td style="width: 187px; text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong>Traza</strong></span></td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 60px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 88px">
                                                        </td>
                                                        <td style="width: 187px; text-align: center">
                                                            <asp:TextBox ID="TextBox59" runat="server" Width="180px" Font-Names="Calibri" Font-Size="11pt" Height="23px"></asp:TextBox></td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 60px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <span style="font-size: 10pt"></span>
                                                        </td>
                                                        <td style="width: 88px">
                                                        </td>
                                                        <td style="width: 187px; text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong>Fecha Transacción</strong></span></td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 60px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="width: 88px">
                                                        </td>
                                                        <td style="width: 187px; text-align: center">
                                                                <asp:Calendar ID="Calendar14" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                                        ForeColor="Black" Height="150px" Width="180px" BorderWidth="1px" OnDayRender="Calendar14_DayRender" ShowGridLines="True">
                                                                    <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                                    <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                    <SelectorStyle BackColor="#FFCC66" />
                                                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                    <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                </asp:Calendar>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="width: 60px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            &nbsp;</td>
                                                        <td style="width: 88px">
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Button ID="Button107" runat="server" OnClick="Button107_Click" Text="Buscar" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                            <asp:Button ID="Button109" runat="server" OnClick="Button109_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td style="width: 60px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" style="text-align: center">
                                                <asp:GridView ID="GridView4" runat="server" CellPadding="2" Font-Size="12pt" ForeColor="Black"
                                                    GridLines="Horizontal" Height="5px" Visible="False" Width="550px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Font-Names="Calibri" ShowFooter="True">
                                                    <FooterStyle BackColor="#A2A764" />
                                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" rowspan="2" style="text-align: center; height: 21px;">
                                                <asp:Button ID="Button108" runat="server" OnClick="Button108_Click" Text="Reversar" Font-Names="Calibri" Font-Size="11pt" Width="80px" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View><asp:View ID="View46" runat="server" OnActivate="View44_Activate">
                                    <table width="100%" cellpadding="0" cellspacing="0" id="Table4" onclick="return TABLE2_onclick()">
                                        <tr>
                                            <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                                <asp:Label ID="Label92" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Reporte Reverso de Transacciones"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                <table>
                                                    <tr>
                                                        <td style="color: teal; text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong>DESDE</strong></span></td>
                                                        <td style="color: teal; text-align: center">
                                                            <strong><span style="font-size: 14pt; font-family: Calibri">HASTA</span></strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Calendar ID="Calendar17" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                                                BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt"
                                                                ForeColor="Black" Height="150px" ShowGridLines="True" Width="180px" OnDayRender="Calendar17_DayRender">
                                                                <SelectedDayStyle BackColor="White" Font-Bold="True" ForeColor="Teal" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="12pt" ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                        </td>
                                                        <td>
                                                            <asp:Calendar ID="Calendar19" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                                                BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Calibri" Font-Size="10pt"
                                                                ForeColor="Black" Height="150px" ShowGridLines="True" Width="180px" OnDayRender="Calendar19_DayRender">
                                                                <SelectedDayStyle BackColor="White" Font-Bold="True" ForeColor="Teal" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="12pt" ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="text-align: center">
                                                            <asp:Button ID="Button110" runat="server" OnClick="Button110_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" />
                                                &nbsp;
                                                <asp:Button ID="Button111" runat="server" OnClick="Button106_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View><asp:View ID="View47" runat="server" OnActivate="View44_Activate">
                                    <table width="100%" cellpadding="0" cellspacing="0" id="Table5" onclick="return TABLE2_onclick()">
                                        <tr>
                                            <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                                <asp:Label ID="Label91" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Reporte Tabla Resumen Anual"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                &nbsp; &nbsp;&nbsp;<br />
                                                <asp:Button ID="Button112" runat="server" OnClick="Button112_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="Button113" runat="server" OnClick="Button106_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /><br />
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:View><asp:View ID="View48" runat="server" OnActivate="View44_Activate">
                                    <table width="100%" cellpadding="0" cellspacing="0" id="Table6" onclick="return TABLE2_onclick()">
                                        <tr>
                                            <td style="width: 613px; height: 22px; background-color: darkslategray; font-weight: bold; font-size: 12pt; font-family: Verdana;">
                                                <asp:Label ID="Label90" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Reporte Tabla Resumen Mensual"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="text-align: center">
                                                <asp:Label ID="Label43" runat="server" Text="AÑO:   " Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"></asp:Label></td>
                                                        <td style="text-align: center">
                                                <asp:TextBox ID="TextBox60" runat="server" Width="132px" Font-Names="Calibri" Font-Size="10pt" MaxLength="4"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="text-align: center">
                                                <asp:Label ID="Label44" runat="server" Text="Ejemplo: 2010" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel3" runat="server" Height="25px" Width="200px">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="text-align: center">
                                                <asp:Button ID="Button114" runat="server" OnClick="Button114_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="Button115" runat="server" OnClick="Button106_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View><asp:View ID="View49" runat="server" OnActivate="View49_Activate">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="font-weight: bold; font-size: 12pt; width: 613px; font-family: Verdana;
                                        height: 21px; background-color: darkslategray">
                                                <asp:Label ID="Label89" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                                    Text="Reporte Consulta de Saldos"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                        padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid;
                                        padding-top: 14px; border-bottom: #d8d787 2px solid; position: static;
                                        text-align: center">
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td colspan="3" style="text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong style="color: teal">Operador: </strong></span>
                                                <asp:TextBox ID="TextBox61" runat="server" Width="162px" Font-Names="Calibri"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Panel ID="Panel4" runat="server" Height="25px" Width="100%">
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong>DESDE</strong></span></td>
                                                        <td colspan="2" style="text-align: center">
                                                            <span style="font-size: 14pt; font-family: Calibri"><strong>HASTA</strong></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Calendar ID="Calendar15" runat="server" SelectedDate="2007-07-12" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" OnDayRender="Calendar15_DayRender" ShowGridLines="True" Width="180px">
                                                                <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Calendar ID="Calendar16" runat="server" SelectedDate="2007-07-12" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" OnDayRender="Calendar16_DayRender" ShowGridLines="True" Width="180px">
                                                                <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                                                <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                                                <SelectorStyle BackColor="#FFCC66" />
                                                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                                            </asp:Calendar>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="text-align: center" colspan="2">
                                                            <asp:Button ID="Button116" runat="server" OnClick="Button116_Click" Text="Aceptar" Font-Names="Calibri" Font-Size="11pt" Width="65px" />&nbsp; <asp:Button ID="Button117" runat="server" OnClick="Button87_Click1" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="65px" /></td>
                                                    </tr>
                                                </table>
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:View>
                        <asp:View ID="View50" runat="server">
                            <table style="width: 605px; color: #000000; border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid; border-bottom: #d8d787 2px solid;">
                                <tr>
                                    <td colspan="12" style="background-color: darkslategray; text-align: center">
                                        <span style="color: #ffffff; font-family: Calibri; font-size: 14pt;">
                                            <asp:Label ID="Label130" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="#FFFFCC" Text="Pago de Multas por Contravención"></asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td style="width: 366px; height: 22px">
                                        <span style="font-family: Calibri"><strong style="color: teal">Modelo del Talón:</strong></span></td>
                                    <td style="width: 83px; height: 22px">
                                        <asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="True" Height="22px"
                                            OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged" Width="97px">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>OC-1</asp:ListItem>
                                            <asp:ListItem>OC-13</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td colspan="8" style="height: 22px">
                                        <asp:Image ID="Image19" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoAceptado.PNG"
                                            Visible="False" Width="25px" /><asp:Image ID="Image20" runat="server" Height="22px"
                                                ImageUrl="~/Images/Imagenes/DatoNoAceptado.PNG" Visible="False" Width="25px" /></td>
                                    <td style="background-color: #a2a764; text-align: center; height: 22px;" colspan="2">
                                        <span style="color: #ffffff; font-family: Calibri"><strong style="color: #ffffcc">DATOS CAPTADOS</strong></span></td>
                                </tr>
                                <tr>
                                    <td style="width: 366px; height: 22px">
                                        <strong><span style="font-family: Calibri; color: teal;">Decreto-Ley:</span></strong></td>
                                    <td style="width: 83px; height: 22px">
                                        <asp:TextBox ID="TextBox64" runat="server" Width="97px" MaxLength="3"></asp:TextBox></td>
                                    <td colspan="8" style="height: 22px">
                                        <asp:Image ID="Image16" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoAceptado.PNG"
                                            Visible="False" Width="25px" /><asp:Image ID="Image17" runat="server" Height="22px"
                                                ImageUrl="~/Images/Imagenes/DatoNoAceptado.PNG" Visible="False" Width="25px" /><asp:Image
                                                    ID="Image18" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/Alerta.PNG"
                                                    Visible="False" Width="30px" /></td>
                                    <td style="border-right: thin inset; border-top: thin inset; border-left: thin inset;
                                        width: 119px; border-bottom: thin inset; height: 13px">
                                        <asp:Label ID="Label66" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            ForeColor="Black" Text="Mod Talón"></asp:Label></td>
                                    <td style="border-right: thin inset; border-top: thin inset; border-left: thin inset;
                                        width: 100px; border-bottom: thin inset; height: 13px">
                                        <asp:Label ID="Label67" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 366px; height: 17px;">
                                        <strong><span style="font-family: Calibri; color: teal;">No. Multa:</span></strong></td>
                                    <td style="width: 83px; height: 17px;">
                                        <asp:TextBox ID="TextBox68" runat="server" Width="97px" MaxLength="13" OnTextChanged="TextBox68_TextChanged" ValidationGroup="1"></asp:TextBox></td>
                                    <td colspan="8" style="height: 17px">
                                        <asp:Image ID="Image1" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image6" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoNoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image11" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/Alerta.PNG"
                                            Visible="False" Width="30px" /></td>
                                    <td style="width: 119px; height: 17px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label64" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="D-Ley" Width="82px"></asp:Label></td>
                                    <td style="width: 100px; height: 17px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label65" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 366px; height: 22px;">
                                        <strong><span style="font-family: Calibri; color: teal;">No. Doc. de Identificación:</span></strong></td>
                                    <td style="width: 83px; height: 22px;">
                                        <asp:TextBox ID="TextBox69" runat="server" Width="97px" MaxLength="11" ValidationGroup="1"></asp:TextBox></td>
                                    <td colspan="8" style="height: 22px">
                                        <asp:Image ID="Image2" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image7" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoNoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image12" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/Alerta.PNG"
                                            Visible="False" Width="30px" /></td>
                                    <td style="width: 119px; height: 13px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label53" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="N.M" Width="47px"></asp:Label></td>
                                    <td style="width: 100px; height: 13px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label48" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 366px; height: 16px; background-color: #a2a764; text-align: center;">
                                        <strong><span style="font-family: Calibri; color: #ffffcc;">Fecha de Imposición</span></strong></td>
                                    <td style="width: 83px; height: 16px;">
                                        <asp:TextBox ID="TextBox70" runat="server" ReadOnly="True" Width="97px" ValidationGroup="1"></asp:TextBox></td>
                                    <td colspan="8" style="height: 16px">
                                        <asp:Image ID="Image3" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image8" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoNoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image13" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/Alerta.PNG"
                                            Visible="False" Width="30px" /></td>
                                    <td style="width: 119px; height: 16px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label54" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="D.N.I"></asp:Label></td>
                                    <td style="width: 100px; height: 16px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label49" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td rowspan="7" style="width: 366px; text-align: left; background-color: #a2a764;">
                                        <asp:Calendar ID="Calendar18" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                            BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt"
                                            ForeColor="Black" Height="200px" Width="220px" FirstDayOfWeek="Monday" OnSelectionChanged="Calendar18_SelectionChanged" ToolTip="Seleccione Fecha de Imposici�ón" OnDayRender="Calendar18_DayRender" DayNameFormat="Shortest" ShowGridLines="True">
                                            <SelectedDayStyle BackColor="#FFC080" Font-Bold="True" />
                                            <TodayDayStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <DayHeaderStyle Font-Bold="True" BackColor="#FFCC66" Height="1px" />
                                            <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" Font-Names="Calibri" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                        </asp:Calendar>
                                    </td>
                                    <td style="width: 83px; height: 15px; text-align: center;">
                                        <strong><span style="font-family: Calibri; color: teal;">Importe:</span></strong></td>
                                    <td colspan="8" style="height: 15px">
                                    </td>
                                    <td style="width: 119px; height: 15px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label55" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="F.I"></asp:Label></td>
                                    <td style="width: 100px; height: 15px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label50" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 83px; height: 15px">
                                        <strong><span style="font-family: Calibri">$<asp:TextBox ID="TextBox71" runat="server" Width="35px" ValidationGroup="1" MaxLength="13"></asp:TextBox>.<asp:TextBox
                                            ID="TextBox65" runat="server" MaxLength="2" Width="15px">00</asp:TextBox></span></strong></td>
                                    <td colspan="8" style="height: 15px">
                                        <asp:Image ID="Image4" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoAceptado.PNG"
                                            Width="25px" /><asp:Image ID="Image9" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoNoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image14" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/Alerta.PNG"
                                            Width="30px" Visible="False" /></td>
                                    <td style="border-right: thin inset; border-top: thin inset; border-left: thin inset;
                                        width: 119px; border-bottom: thin inset; height: 13px">
                                        <asp:Label ID="Label58" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="Duplicada"></asp:Label></td>
                                    <td style="border-right: thin inset; border-top: thin inset; border-left: thin inset;
                                        width: 100px; border-bottom: thin inset; height: 13px">
                                        <asp:Label ID="Label51" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"
                                            Visible="False">No</asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 83px; text-align: center">
                                        <span style="font-family: Calibri; font-size: 11pt;"><strong style="color: teal">Moneda</strong></span></td>
                                    <td colspan="8">
                                    </td>
                                    <td style="width: 119px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset; height: 13px;">
                                        <asp:Label ID="Label59" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="Desde" Width="77px"></asp:Label></td>
                                    <td style="width: 100px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset; height: 13px;">
                                        <asp:Label ID="Label52" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 83px; text-align: center;">
                                        <span style="font-family: Calibri"><strong>&nbsp;<asp:Label ID="Label46" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red">?</asp:Label><span style="font-size: 11pt"></span></strong></span></td>
                                    <td colspan="8">
                                        <asp:Image ID="Image5" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image10" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/DatoNoAceptado.PNG"
                                            Width="25px" Visible="False" /><asp:Image ID="Image15" runat="server" Height="22px" ImageUrl="~/Images/Imagenes/Alerta.PNG"
                                            Width="30px" Visible="False" /></td>
                                    <td style="width: 119px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset; height: 13px; text-align: left;">
                                        <asp:Label ID="Label56" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="Importe" Width="60px"></asp:Label><span style="font-family: Calibri"><strong>$</strong></span></td>
                                    <td style="width: 100px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset; height: 13px;">
                                        <asp:Label ID="Label61" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 83px; text-align: center; height: 18px;">
                                        <span style="font-family: Calibri; font-size: 11pt;">
                                        <asp:Button ID="Button119" runat="server" Text="Procesar" Width="101px" OnClick="Button119_Click" ValidationGroup="1" /></span></td>
                                    <td colspan="8" style="height: 18px">
                                    </td>
                                    <td style="width: 119px; height: 18px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label60" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="A pagar" Width="60px"></asp:Label><span style="font-family: Calibri"><strong>$</strong></span></td>
                                    <td style="width: 100px; height: 18px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset;">
                                        <asp:Label ID="Label62" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 83px; text-align: center">
                                        <asp:Button ID="Button123" runat="server" Enabled="False" OnClick="Button123_Click"
                                            Text="Modificar" Width="101px" /></td>
                                    <td colspan="8">
                                        </td>
                                    <td style="width: 119px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset; height: 13px;">
                                        <asp:Label ID="Label57" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Small"
                                            Text="Moneda"></asp:Label></td>
                                    <td style="width: 100px; border-right: thin inset; border-top: thin inset; border-left: thin inset; border-bottom: thin inset; height: 13px;">
                                        <asp:Label ID="Label63" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Teal"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 83px; height: 13px; text-align: center;">
                                        <asp:Button ID="Button122" runat="server" Enabled="False" OnClick="Button122_Click"
                                            Text="Aceptar" Width="101px" ValidationGroup="1" /></td>
                                    <td colspan="8" style="height: 13px; text-align: center">
                                    </td>
                                    <td style="width: 119px; background-color: #a2a764; text-align: center;">
                                        <asp:Button ID="Button120" runat="server" Text="Pagar" Enabled="False" OnClick="Button120_Click" /></td>
                                    <td style="text-align: center; background-color: #a2a764;">
                                        <asp:Button ID="Button121" runat="server" Text="Cancelar" OnClick="Button121_Click" ValidationGroup="2" /></td>
                                </tr>
                                <tr>
                                    <td colspan="12" style="background-color: darkslategray; text-align: center">
                                        <span style="color: #ffffff; font-family: Calibri"><strong style="color: #ffffcc">!!! Información del Sistema
                                            !!!</strong></span></td>
                                </tr>
                                <tr>
                                    <td colspan="12" style="height: 21px">
                                        <asp:Label ID="Label47" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="Teal" Font-Bold="True" Width="600px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 366px; height: 21px">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" Font-Names="Calibri"
                                                ForeColor="Teal" Height="1px" Width="181px" ShowMessageBox="True" ShowSummary="False" ValidationGroup="1" />
                                    </td>
                                    <td style="width: 83px; height: 21px">
                                    </td>
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                    <td style="width: 3851px; height: 21px">
                                    </td>
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                    <td style="height: 21px">
                                    </td>
                                    <td style="width: 119px; height: 21px">
                                    </td>
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="12" style="background-color: darkslategray">
                                        <asp:Panel ID="Panel2" runat="server" Height="22px" Width="560px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox68"
                                                ErrorMessage="Por favor teclee el No. de la Multa a pagar." Display="None" ValidationGroup="1"></asp:RequiredFieldValidator><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="TextBox69"
                                                ErrorMessage="Por favor teclee el No. del Documento de Identificaci�ón registrado en el talón del infractor." Display="None" ValidationGroup="1"></asp:RequiredFieldValidator><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="TextBox70"
                                                ErrorMessage="Por favor seleccione la Fecha de Imposición de la Multa a pagar." Display="None" ValidationGroup="1"></asp:RequiredFieldValidator><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="TextBox71"
                                                ErrorMessage="Por favor teclee el Importe aplicado para esta Multa." Display="None" ValidationGroup="1"></asp:RequiredFieldValidator><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="TextBox64"
                                                Display="None" ErrorMessage="Por favor teclee el Decreto y/o Ley correspondiente."
                                                ValidationGroup="1"></asp:RequiredFieldValidator><br />
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox64"
                                                Display="None" ErrorMessage="Por favor en Decreto y/o Ley solo teclee caracteres númericos que no excedan 3 digítos."
                                                MaximumValue="999" MinimumValue="1" Type="Integer" ValidationGroup="1"></asp:RangeValidator><br />
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox71"
                                                Display="None" ErrorMessage="Por favor teclee solo caracteres numéricos en el Importe."
                                                MaximumValue="9999999999999" MinimumValue="0" Type="Double" ValidationGroup="1"></asp:RangeValidator><br />
                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="TextBox65"
                                                Display="None" ErrorMessage="Por favor teclee solo dos caracteres numéricos en los centavos del Importe."
                                                MaximumValue="99" MinimumValue="00" Type="Integer" ValidationGroup="1"></asp:RangeValidator><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="DropDownList12"
                                                Display="None" ErrorMessage="Por favor seleccione el Modelo del Talón." ValidationGroup="1"></asp:RequiredFieldValidator><br />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View51" runat="server" OnActivate="View51_Activate">
                            <table style="width: 609px">
                                <tr>
                                    <td colspan="5" style="background-color: darkslategray; text-align: center">
                                        <span style="font-size: 16pt; color: #33ff00; font-family: Calibri">
                                            <asp:Label ID="Label155" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="Lime" Text="TRANSFERENCIA AL PROPIO CLIENTE"></asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="3" style="text-align: center">
                                        <span style="font-size: 14px; font-family: Calibri"><strong>Carnet de Identidad</strong></span></td>
                                    <td style="font-size: 12pt; width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="3" style="text-align: center">
                                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="#006666" Text="60011225628"></asp:Label></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px; height: 21px">
                                    </td>
                                    <td style="text-align: center; width: 180px;">
                                        <span style="font-family: Calibri"><strong>Provincia</strong></span></td>
                                    <td>
                                    </td>
                                    <td style="text-align: center">
                                        <span style="font-family: Calibri"><strong>Municipio</strong></span></td>
                                    <td style="font-size: 12pt; width: 100px; height: 21px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px">
                                    </td>
                                    <td style="text-align: center; width: 180px;">
                                        <asp:DropDownList ID="DropDownList17" runat="server" Width="185px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList17_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td style="text-align: center;">
                                    </td>
                                    <td style="text-align: center">
                                        <asp:DropDownList ID="DropDownList18" runat="server" Width="185px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList18_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="3" style="text-align: center">
                                        <span style="font-family: Calibri"><strong>Sucursales Bancarias</strong></span></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="3" style="text-align: center">
                                        <asp:GridView ID="GridView7" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                            BorderWidth="1px" CellPadding="2" Font-Names="Calibri" Font-Size="13pt" ForeColor="Black"
                                            GridLines="None" ShowFooter="True" OnSelectedIndexChanged="GridView7_SelectedIndexChanged">
                                            <Columns>
                                                <asp:CommandField SelectText="→" ShowSelectButton="True" />
                                            </Columns>
                                            <FooterStyle BackColor="#A2A764" />
                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="White" BorderColor="#FF8000" BorderStyle="Double" BorderWidth="1px"
                                                ForeColor="Black" />
                                            <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="Yellow" />
                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        </asp:GridView>
                                        &nbsp; &nbsp;</td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt; font-family: Times New Roman;">
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="3" style="text-align: center">
                                        <span style="font-family: Calibri">&nbsp;<strong><span style="font-family: Calibri">Cantidad
                                            a Transferir</span></strong></span> <span style="font-family: Calibri"><strong>en<span></span></strong></span></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt; font-family: Times New Roman">
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="3" style="text-align: center">
                                        <asp:RadioButtonList ID="RadioButtonList7" runat="server" Font-Bold="True" Font-Names="Calibri"
                                            Font-Size="12pt" ForeColor="#339933" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList7_SelectedIndexChanged">
                                            <asp:ListItem>CUP</asp:ListItem>
                                            <asp:ListItem>CUC</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px; height: 26px;">
                                    </td>
                                    <td colspan="3" style="height: 26px; text-align: center">
                                        <span style="font-family: Calibri"><strong> </strong>
                                            <asp:TextBox ID="TextBox51" runat="server" Width="115px" Enabled="False"></asp:TextBox>
                                        </span><strong>. </strong>
                                        <asp:TextBox ID="TextBox52" runat="server" Width="26px" Enabled="False">00</asp:TextBox><span style="font-family: Calibri"><strong></strong></span></td>
                                    <td style="width: 100px; height: 26px;">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px; height: 26px">
                                    </td>
                                    <td colspan="3" style="height: 26px; text-align: center">
                                    </td>
                                    <td style="width: 100px; height: 26px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 180px; text-align: right">
                                        <strong><span style="font-family: Calibri">Transferir &gt;&gt;</span></strong></td>
                                    <td style="text-align: center">
                                            <asp:Button ID="Button126" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="10pt"
                                            Text="Sí" Width="53px" OnClick="Button126_Click" /></td>
                                    <td style="text-align: left">
                                        <asp:Button ID="Button125" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="10pt"
                                            Text="No" Width="55px" OnClick="Button125_Click" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td colspan="5" style="height: 20px; background-color: darkslategray">
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View52" runat="server" OnActivate="View52_Activate">
                            <table style="width: 599px">
                                <tr>
                                    <td colspan="5" style="background-color: darkslategray; text-align: center">
                                        <asp:Label ID="Label140" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="Lime" Text="Pago de Vuelos Nacionales AeroCaribbean"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="text-align: center">
                                        <asp:Label ID="Label141" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Personal Number Reservation (PNR)"
                                            ToolTip="Número de Reserva Personal"></asp:Label>
                                        &nbsp;<asp:TextBox ID="TextBox53" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox53',6,'Button127');" runat="server" Width="102px" OnTextChanged="TextBox53_TextChanged" MaxLength="6"></asp:TextBox>
                                        <asp:Button ID="Button127" runat="server" Text="Buscar" OnClick="Button127_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="background-color: darkslategray">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="5" style="text-align: center">
                                        <asp:Image ID="Image26" runat="server" ImageUrl="~/Images/Imagenes/logo aerocaribbean.JPG" /></td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="text-align: center" align="center">
                                        <asp:DetailsView ID="DetailsView1" runat="server" CellPadding="4" ForeColor="Black" Height="50px" Width="600px" AutoGenerateRows="False" DataSourceID="SqlDataSource5" AllowPaging="True" Font-Names="Calibri" HeaderText="Información" HorizontalAlign="Center" OnDataBound="DetailsView1_DataBound">
                                            <FooterStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <CommandRowStyle BackColor="#FFFF80" Font-Bold="True" />
                                            <RowStyle BackColor="#FFFBD6" ForeColor="#004040" Font-Names="Calibri" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FieldHeaderStyle BackColor="Yellow" Font-Bold="True" BorderColor="Lime" BorderStyle="Double" Font-Names="Calibri" Font-Strikeout="False" HorizontalAlign="Left" VerticalAlign="Middle" Width="200px" />
                                            <PagerStyle BackColor="SpringGreen" ForeColor="#333333" HorizontalAlign="Center" />
                                            <HeaderStyle BackColor="SpringGreen" Font-Bold="True" ForeColor="#404040" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Fields>
                                                <asp:BoundField DataField="Id_Asociado" HeaderText="PNR N&#250;merico" SortExpression="Id_Asociado" />
                                                <asp:BoundField DataField="PNR" HeaderText="PNR Alfan&#250;merico" SortExpression="PNR" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre(s) y Apellidos" SortExpression="Nombre" />
                                                <asp:BoundField DataField="Importe" DataFormatString="{0:C}" HeaderText="Importe CUP" SortExpression="Importe" />
                                                <asp:BoundField DataField="Vuelo" HeaderText="No. Vuelo" SortExpression="Vuelo" />
                                                <asp:BoundField DataField="Fecha_Vuelo" HeaderText="Fecha de Vuelo" SortExpression="Fecha_Vuelo" />
                                                <asp:BoundField DataField="Origen" HeaderText="Aeropuerto Origen" SortExpression="Origen" />
                                                <asp:BoundField DataField="Destino" HeaderText="Aeropuerto Destino" SortExpression="Destino" />
                                                <asp:BoundField DataField="Origen_Destino" HeaderText="Origen-Destino" SortExpression="Origen_Destino" />
                                                <asp:BoundField DataField="Fecha_Limite" HeaderText="Fecha L&#237;mite de Pago" SortExpression="Fecha_Limite" />
                                            </Fields>
                                        </asp:DetailsView>
                                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                            SelectCommand="SELECT TLB_SERV_08.Id_Asociado, TLB_SERV_08.Nombre, TLB_SERV_08.Importe, LEFT (TLB_SERV_08.descriptivo, 10) AS Fecha_Limite, RIGHT (LEFT (TLB_SERV_08.Informativo, 17), 6) AS PNR, RIGHT (LEFT (TLB_SERV_08.Informativo, 6), 4) AS Vuelo, RIGHT (TLB_SERV_08.Informativo, 35) AS Fecha_Vuelo, TLB_Vuelos_AeroCaribbean.Origen, TLB_Vuelos_AeroCaribbean.Destino, TLB_Vuelos_AeroCaribbean.Origen_Destino FROM TLB_SERV_08 INNER JOIN TLB_Vuelos_AeroCaribbean ON RIGHT (LEFT (TLB_SERV_08.Informativo, 6), 4) = TLB_Vuelos_AeroCaribbean.Vuelo WHERE (TLB_SERV_08.Id_Asociado = @PNR)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="TextBox53" Name="PNR" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                                </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="background-color: darkslategray">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;" colspan="5">
                                        <strong><span style="font-family: Calibri"></span></strong><span style="font-family: Calibri">
                                            <strong>
                                                <asp:Label ID="Label142" runat="server" ForeColor="Red"></asp:Label>Efectuar Pago </strong></span>
                                        <span style="font-family: Calibri">
                                        <asp:Button ID="Button128" runat="server" Text="Sí" Width="53px" OnClick="Button128_Click" />
                                        </span>
                                        <asp:Button ID="Button129" runat="server" Text="No" Width="53px" OnClick="Button129_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="background-color: darkslategray">
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View53" runat="server" OnActivate="View53_Activate">
                            <div style="text-align: center">
                                <table style="width: 600px">
                                    <tr>
                                        <td colspan="2" style="background-color: darkslategray; text-align: center">
                                            <asp:Label ID="Label143" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="Lime" Text="APLICANDO TIPO DE CAMBIO" ToolTip="El tipo o tasa de cambio entre dos divisas es la tasa o relación de proporción que existe entre el valor de una y la otra. Dicha tasa es un indicador que expresa cuántas unidades de una divisa se necesitan para obtener una unidad de la otra."></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:Label ID="Label144" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#00C000"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:Label ID="Label145" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" ForeColor="Black"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <strong><span style="font-family: Calibri">Finalizar Pago</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right" align="right">
                                            <asp:Button ID="Button98" runat="server" Text="Sí" Width="60px" OnClick="Button98_Click2" /></td>
                                        <td style="text-align: left" align="left">
                                            <asp:Button ID="Button130" runat="server" Text="No" Width="60px" OnClick="Button130_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="background-color: darkslategray">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="View54" runat="server" OnActivate="View54_Activate">
                            <div style="text-align: center">
                                <table style="width: 600px">
                                    <tr>
                                        <td colspan="2" style="background-color: darkslategray; text-align: center">
                                            <asp:Label ID="Label137" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                                ForeColor="Lime" Text="SELECCION DE MONEDA PARA EL PAGO" ToolTip="El tipo o tasa de cambio entre dos divisas es la tasa o relación de proporción que existe entre el valor de una y la otra. Dicha tasa es un indicador que expresa cuántas unidades de una divisa se necesitan para obtener una unidad de la otra."></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:RadioButtonList ID="RadioButtonList10" runat="server" Font-Names="Calibri" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList10_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Font-Size="Large" ForeColor="#FF8000">
                                            </asp:RadioButtonList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:Label ID="Label146" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" ForeColor="#00C000"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:Label ID="Label147" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <span style="font-family: Calibri"><strong>Finalizar Pago</strong></span></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right" align="right">
                                            <asp:Button ID="Button131" runat="server" Text="Sí" Width="60px" OnClick="Button131_Click" /></td>
                                        <td style="width: 100px; text-align: left">
                                            <asp:Button ID="Button132" runat="server" Text="No" Width="60px" OnClick="Button132_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="background-color: darkslategray">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:View>
                        <asp:View ID="View55" runat="server" OnActivate="View55_Activate">
                            <table style="width: 600px">
                                <tr>
                                    <td colspan="2" style="background-color: darkslategray; text-align: center">
                                        <asp:Label ID="Label138" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="Lime" Text="TRANSFERENCIAS" ToolTip="El tipo o tasa de cambio entre dos divisas es la tasa o relación de proporción que existe entre el valor de una y la otra. Dicha tasa es un indicador que expresa cuántas unidades de una divisa se necesitan para obtener una unidad de la otra."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center">
                                        <asp:RadioButtonList ID="RadioButtonList12" runat="server" Font-Names="Calibri" AutoPostBack="True" Font-Bold="True" Font-Size="Medium" ForeColor="#FF8000">
                                            <asp:ListItem Value="0">Transferencia al Propio Cliente</asp:ListItem>
                                            <asp:ListItem Value="1">Transferencia entre Cuentas/Tarjetas</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center">
                                        <asp:Button ID="Button133" runat="server" Text="Continuar" Width="100px" OnClick="Button133_Click" />
                                        <asp:Button ID="Button140" runat="server" Text="Cancelar" Width="100px" OnClick="Button140_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color: darkslategray">
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View56" runat="server" OnActivate="View56_Activate">
                            <table style="width: 600px">
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray; text-align: center">
                                        <asp:Label ID="Label139" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="Lime" Text="TRANSFERENCIA ENTRE CUENTAS/TARJETAS" ToolTip="El tipo o tasa de cambio entre dos divisas es la tasa o relación de proporción que existe entre el valor de una y la otra. Dicha tasa es un indicador que expresa cuántas unidades de una divisa se necesitan para obtener una unidad de la otra."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" rowspan="1" style="width: 193px; text-align: right">
                                    </td>
                                    <td colspan="1" style="width: 212px; text-align: center">
                                        <asp:Label ID="Label149" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Cuenta Destino:" Font-Size="Large"></asp:Label></td>
                                    <td colspan="1" rowspan="1" style="text-align: left" valign="top">
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: right; width: 193px;" rowspan="3">
                                        <asp:RadioButtonList ID="RadioButtonList15" runat="server" Font-Names="Calibri" OnSelectedIndexChanged="RadioButtonList15_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Font-Size="Small" ForeColor="#00C000" Height="40px" TextAlign="Left">
                                            <asp:ListItem Value="0"># Tarjeta Magn&#233;tica RED </asp:ListItem>
                                            <asp:ListItem Value="1"># Cuenta Estandarizada   </asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td colspan="1" style="width: 212px; text-align: center">
                                    </td>
                                    <td colspan="1" rowspan="4" style="text-align: left" valign="top">
                                        <asp:RadioButtonList ID="RadioButtonList14" runat="server" Font-Names="Calibri" OnSelectedIndexChanged="RadioButtonList14_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Font-Size="Small" ForeColor="#FF8000">
                                            <asp:ListItem Value="CUP">Asociada a BT en CUP</asp:ListItem>
                                            <asp:ListItem Value="CUC">Asociada a BT en CUC</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 212px; text-align: center">
                                        <asp:TextBox ID="TextBox66" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox66',4,'TextBox67');" runat="server" Width="30px" Enabled="False" MaxLength="4"></asp:TextBox>--<asp:TextBox
                                            ID="TextBox67" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox67',4,'TextBox72');" runat="server" Width="30px" Enabled="False" MaxLength="4"></asp:TextBox>--<asp:TextBox ID="TextBox72" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox72',4,'TextBox73');"
                                                runat="server" Width="30px" Enabled="False" MaxLength="4"></asp:TextBox>--<asp:TextBox
                                                    ID="TextBox73" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox73',4,'Button136');" runat="server" Enabled="False" MaxLength="4" Width="30px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 212px; text-align: center">
                                        <asp:TextBox ID="TextBox76" onkeyup="AsignarIrSiguiente('WebUserControl_ServicioPago1_', 'TextBox76',16,'Button136');" runat="server" Enabled="False" MaxLength="16" Width="174px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Label ID="Label160" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red"></asp:Label>
                                        <asp:Label ID="Label161" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 195px">
                                    </td>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Button ID="Button136" runat="server" Text="Procesar" Width="100px" Enabled="False" OnClick="Button136_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Label ID="Label150" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 195px">
                                    </td>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Label ID="Label151" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Importe"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <strong><span style="font-family: Calibri">$</span></strong><asp:TextBox ID="TextBox78" runat="server" Width="60px" Enabled="False" ValidationGroup="1"></asp:TextBox>
                                        <asp:Label ID="Label152" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator34" runat="server"
                                            ControlToValidate="TextBox78" ErrorMessage="Introduzca la cantidad en el formato CANTIDAD.CENTAVOS"
                                            Font-Bold="True" SetFocusOnError="True" ValidationExpression="\d+\.\d{2}" ValidationGroup="1"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Label ID="Label148" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Debitar desde cuenta asociada a BT en:" Font-Size="Medium"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:RadioButtonList ID="RadioButtonList13" runat="server" Font-Names="Calibri" OnSelectedIndexChanged="RadioButtonList13_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Font-Size="Large" ForeColor="#FF8000" RepeatDirection="Horizontal" Enabled="False">
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Label ID="Label159" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <span style="font-family: Calibri"><strong>Ordenar Transferencia</strong></span></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center; height: 26px;">
                                        <asp:Button ID="Button134" runat="server" Text="Sí" Width="60px" OnClick="Button134_Click" Enabled="False" ValidationGroup="1" /><asp:Button ID="Button135" runat="server" Text="No" Width="60px" OnClick="Button135_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: left">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray">
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View57" runat="server" OnActivate="View57_Activate">
                            <table style="width: 600px">
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray; text-align: center">
                                        <asp:Label ID="Label153" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="Lime" Text="PAGO DE FACTURA TELEFÓNICA" ToolTip="El tipo o tasa de cambio entre dos divisas es la tasa o relación de proporción que existe entre el valor de una y la otra. Dicha tasa es un indicador que expresa cuántas unidades de una divisa se necesitan para obtener una unidad de la otra."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; text-align: right;">
                                        <asp:Label ID="Label158" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                            ForeColor="Teal" Text="???"></asp:Label></td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:Image ID="Image27" runat="server" ImageAlign="Top" ImageUrl="~/Images/Imagenes/ETECSA_logo.jpg" /></td>
                                    <td style="width: 100px; text-align: left;">
                                        <asp:Label ID="Label157" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                            ForeColor="#FF8000" Text="NO.TELEFONO"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; text-align: right">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <strong><span style="font-family: Calibri">Factura en
                                            <asp:Label ID="Label164" runat="server" ForeColor="Red"></asp:Label></span></strong></td>
                                    <td style="width: 100px; text-align: left">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:GridView ID="GridView8" runat="server"  BackColor="White" BorderColor="#CCCCCC"
                                            BorderStyle="None" BorderWidth="1px" CellPadding="3" ShowFooter="True" DataSourceID="SqlDataSource4">
                                            <RowStyle ForeColor="#000066" />
                                            <FooterStyle BackColor="#006699" ForeColor="#000066" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT Id_Asociado AS Identificador, Nombre AS Titular_del_Contrato, RIGHT (Importe, 20) AS Importe FROM TLB_SERV_01 WHERE (Id_Asociado = @ID)">
                                        <SelectParameters>
                                                <asp:ControlParameter ControlID="Label156" Name="ID" PropertyName="Text" />
                                            </SelectParameters>
                                    </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:CheckBox ID="CheckBox4" runat="server" Font-Bold="True" Font-Names="Calibri"
                                            Text="Otro Importe" AutoPostBack="True" OnCheckedChanged="CheckBox4_CheckedChanged" /></td>
                                    <td style="width: 100px">
                                        <asp:Label ID="Label156" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:TextBox ID="TextBox75" runat="server" Width="80px" Enabled="False"></asp:TextBox></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="text-align: center;" colspan="2">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator33" runat="server"
                                            ControlToValidate="TextBox75" ErrorMessage="Introduzca la cantidad en el formato CANTIDAD.CENTAVOS"
                                            Font-Bold="True" SetFocusOnError="True" ValidationExpression="\d+\.\d{2}"></asp:RegularExpressionValidator></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:Label ID="Label154" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Efectuar Pago"></asp:Label></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Button ID="Button137" runat="server" Text="Sí" Width="60px" OnClick="Button137_Click" /></td>
                                    <td style="text-align: left">
                                        <asp:Button ID="Button138" runat="server" Text="No" Width="60px" OnClick="Button138_Click" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray">
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View58" runat="server">
                            <table style="width: 600px">
                                <tr>
                                    <td colspan="4" style="height: 21px; background-color: darkslategray; text-align: center">
                                        <asp:Label ID="Label168" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="Lime" Text="AMORTIZACIÓN DE DEUDAS" ToolTip="El tipo o tasa de cambio entre dos divisas es la tasa o relación de proporción que existe entre el valor de una y la otra. Dicha tasa es un indicador que expresa cuántas unidades de una divisa se necesitan para obtener una unidad de la otra."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:Label ID="Label169" runat="server" Font-Bold="True" Text="Carné de Identidad"></asp:Label></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:TextBox ID="TextBox74" runat="server" MaxLength="11" Width="130px"></asp:TextBox>
                                        <asp:Button ID="Button144" runat="server" OnClick="Button144_Click" Text="Buscar" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray; text-align: center">
                                        <asp:Label ID="Label170" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                            ForeColor="Lime" Text="CUENTAS ESTANDARIZADAS" ToolTip="El tipo o tasa de cambio entre dos divisas es la tasa o relación de proporción que existe entre el valor de una y la otra. Dicha tasa es un indicador que expresa cuántas unidades de una divisa se necesitan para obtener una unidad de la otra."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4" dir="auto">
                                        <asp:GridView ID="GridView11" runat="server" CellPadding="3" GridLines="None" OnSelectedIndexChanged="GridView11_SelectedIndexChanged" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" Width="600px">
                                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="#F7F7F7" />
                                            <AlternatingRowStyle BackColor="#F7F7F7" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <Columns>
                                                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                                            </Columns>
                                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:Label ID="Label173" runat="server" Font-Bold="True" Text="Deuda(Meses)"></asp:Label>
                                        <asp:TextBox ID="TextBox77" runat="server" Width="30px" MaxLength="3"></asp:TextBox>
                                        <asp:Button ID="Button143" runat="server" Text="Procesar" OnClick="Button143_Click" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:DetailsView ID="DetailsView2" runat="server" CellPadding="3" GridLines="Horizontal" Height="50px" Width="600px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                                            <AlternatingRowStyle BackColor="#99FFCC" ForeColor="Black" Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                            <RowStyle BackColor="White" ForeColor="Black" Font-Bold="True" Font-Italic="False" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:DetailsView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:Label ID="Label172" runat="server" Font-Bold="True" Text="Efectuar Pago"></asp:Label></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="text-align: right">
                                        <asp:Button ID="Button141" runat="server" Text="Sí" Width="60px" OnClick="Button141_Click" /></td>
                                    <td style="text-align: left">
                                        <asp:Button ID="Button142" runat="server" Text="No" Width="60px" /></td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="background-color: darkslategray">
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView></td>
            </tr>
        </tbody>
    </table>
