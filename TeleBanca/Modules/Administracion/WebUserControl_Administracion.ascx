<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl_Administracion.ascx.cs" Inherits="WebUserControl_Administracion" %>
<%@ Register Assembly="msgBox" Namespace="BunnyBear" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" 
    namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<script language="javascript" type="text/javascript">
// <!CDATA[
  



function TABLE1_onclick() {

}

// ]]>
</script>
<table width="800">
    <tr>
        <td valign="top" align="left">
        <asp:Menu ID="Menu1" runat="server" BackColor="Transparent" BorderColor="Transparent" Font-Bold="False" Font-Italic="False" Font-Overline="False"
            Font-Strikeout="False" Font-Underline="False" ForeColor="Black"
            Width="139px" OnMenuItemClick="Menu1_MenuItemClick" Font-Names="Verdana" Font-Size="10pt">
            <StaticSelectedStyle BackColor="DarkGray" />
            <Items>
                <asp:MenuItem Enabled="False" Selectable="False" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                    Text=" " Value=" "></asp:MenuItem>
                <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                    Text=" Administraci&#243;n" Value="0" Selected="True"></asp:MenuItem>
                <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg" Text="Gestionar Usuario"
                    Value="1"></asp:MenuItem>
                <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg" Text="Gestionar Roles"
                    Value="4"></asp:MenuItem>
                <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg" Text="Configuraci&#243;n"
                    Value="7"></asp:MenuItem>
                <asp:MenuItem Text="Salvar-Restaurar" Value="8" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"></asp:MenuItem>
                <asp:MenuItem Text="Actualizar Informaci&#243;n" Value="9" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"></asp:MenuItem>
                <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                    Text="Gestionar Notificaciones" Value="10"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="WhiteSmoke" />
        </asp:Menu>
        </td>
        <td colspan="2" valign="top" style="width: 628px;">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="presentacionAdministracion" runat="server">
                <table width="100%">
                    <tr>
                        <td style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                            padding-left: 15px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 538px; padding-top: 14px; border-bottom: #d8d787 2px solid; height: 21px;
                            text-align: justify">
                            <span style="font-size: 16pt; font-family: Calibri; color: green;"><strong style="text-align: justify; color: teal;">Administración del Sistema<br />
                            </strong></span>
                                <span lang="ES-MX" style="font-size: 14pt; mso-bidi-font-family: Arial; mso-fareast-font-family: 'Times New Roman';
                                    mso-ansi-language: ES-TRAD; mso-bidi-font-size: 10.0pt; mso-fareast-language: EN-US;
                                    mso-bidi-language: AR-SA"><span style="font-family: Calibri">
                                        <br />
                                        En esta sesión los administradores podrán captar y configurar
                                        los datos generales de la organización donde se explotará el sistema. También, en
                                        esta sección, podrá acceder a las opciones de salvar y restaurar la Base de Datos
                                        del sistema, se definen y actualizan los usuarios del sistema y los roles que estos
                                        desempeñan, y se tiene acceso a las las notificaciones de las operaciones que se
                                        realizan en la Banca Telefónica.</span> </span>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="gestionarUsuario" runat="server" OnActivate="gestionarUsuario_Activate" OnLoad="gestionarUsuario_Load">
                <table width="100%">
                    <tr>
                        <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                            <strong><span style="font-family: Verdana">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                    ForeColor="#FFFFCC" Text="Gestionar Usuario"></asp:Label></span></strong></td>
                    </tr>
                    <tr style="font-family: Times New Roman">
                        <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td rowspan="9" style="width: 100px">
                                    <asp:ListBox ID="ListBoxGestionarUsuarioUsuarios" runat="server" Width="280px" AutoPostBack="True" OnSelectedIndexChanged="ListBoxGestionarUsuarioUsuarios_SelectedIndexChanged" Height="260px" Font-Names="Calibri" Font-Size="12pt">
                                            <asp:ListItem Selected="True">Error al cargar los usuarios</asp:ListItem>
                                        </asp:ListBox></td>
                                    <td align="left" colspan="3" rowspan="9" valign="top">
                                        <asp:Panel ID="Panel1" runat="server" Height="50px" Visible="False">
                                            <table style="width: 170px; height: 80px">
                                                <tr>
                                                    <td style="font-weight: bold; height: 23px; width: 70px;" align="right" valign="top">
                                                        <span style="font-size: 14pt; font-family: Calibri">Nombre:</span>&nbsp;
                                                    </td>
                                                    <td align="left" style="height: 23px" valign="top">
                                        <asp:Label ID="LabelGestionarUsuarioNombre" runat="server" Width="200px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 23px; font-weight: bold; width: 70px;" align="right" valign="top">
                                                        <span style="font-size: 14pt; font-family: Calibri">Usuario:</span>&nbsp;
                                                    </td>
                                                    <td align="left" style="height: 23px" valign="top">
                                    <asp:Label ID="LabelGestionarUsuarioUsuario" runat="server" Width="200px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 23px; font-weight: bold; width: 70px;" align="right" valign="top">
                                                        <span style="font-size: 14pt; font-family: Calibri">Rol:</span>&nbsp;
                                                    </td>
                                                    <td style="height: 23px" align="left" valign="top">
                                        <asp:Label ID="LabelGestionarUsuarioRol" runat="server" Width="200px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="font-weight: bold; height: 23px; width: 70px;" valign="top">
                                                        <span style="font-size: 14pt; font-family: Calibri">CI:</span>
                                                    </td>
                                                    <td align="left" style="height: 23px" valign="top">
                                                        <asp:Label ID="LabelGestionarUsuarioCarnet" runat="server" Width="200px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 27px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="text-align: center">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="  Crear  " Font-Names="Calibri" Font-Size="11pt" Width="70px" />
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Modificar" Font-Names="Calibri" Font-Size="11pt" Width="70px" />
                                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" Text=" Eliminar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    <td>
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="text-align: center">
                                                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click1"
                                        Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="crearUsuario" runat="server" OnActivate="crearUsuario_Activate"><table width="100%">
                <tr>
                    <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                        <strong><span style="font-family: Verdana">
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                ForeColor="#FFFFCC" Text=" Crear Usuario"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags"
                            prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace=""
                                prefix="st1" ?></td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                        <table style="width: 580px">
                            <tr>
                                <td style="width: 702px; height: 26px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Nombre:</strong></span></td>
                                <td style="width: 208px; height: 21px">
                            <asp:TextBox ID="TextBoxCrearUsuarioNombre" runat="server" Width="160px" MaxLength="30" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1162px; height: 26px">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxCrearUsuarioNombre"
                                        ErrorMessage="*" ValidationExpression="([a-zA-Z ]|[ñ|Ñ|á|é|í|ó|ú])+"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr style="font-size: 10pt; font-family: Verdana">
                                <td style="width: 702px; height: 26px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Usuario:</strong></span></td>
                                <td style="width: 208px; height: 26px">
                            <asp:TextBox ID="TextBoxCrearUsuarioUsuario" runat="server" Width="160px" MaxLength="15" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1162px; height: 26px">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxCrearUsuarioUsuario"
                                        ErrorMessage="*" ValidationExpression="([a-zA-Z]+[0-9]*)+"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 702px; height: 26px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Contraseña:</strong></span></td>
                                <td style="width: 208px; height: 26px">
                            <asp:TextBox ID="TextBoxCrearUsuarioClave" runat="server" Width="160px" TextMode="Password" MaxLength="20" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1162px; height: 26px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 702px; height: 26px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Confirmar Contraseña:</strong></span></td>
                                <td style="width: 208px; height: 21px">
                            <asp:TextBox ID="TextBoxCrearUsuarioConfirmClave" runat="server" Width="160px" TextMode="Password" MaxLength="20" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1162px; height: 21px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 702px; height: 26px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Rol:</strong></span></td>
                                <td style="width: 208px; height: 21px">
                    <asp:DropDownList ID="DropDownListCrearUsuarioRol" runat="server" Width="160px" Font-Names="Calibri" Font-Size="10pt">
                        <asp:ListItem>Error</asp:ListItem>
                    </asp:DropDownList></td>
                                <td style="width: 1162px; height: 21px">
                            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click1" Text="Crear Rol" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 702px; height: 13px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Carné de Identidad:</strong></span></td>
                                <td style="width: 208px; height: 13px">
                                    <asp:TextBox ID="TextBoxCrearUsuarioCarnet" runat="server" MaxLength="11" Width="160px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1162px; height: 13px">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                        ControlToValidate="TextBoxCrearUsuarioCarnet" ErrorMessage="*"
                                        ValidationExpression="([0-9]*)+"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 702px; height: 26px">
                                </td>
                                <td style="width: 208px; height: 21px; text-align: center;">
                            <asp:Button ID="Button4" runat="server" Text="  Crear  " OnClick="Button4_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" OnClientClick="return confirm('¿Está seguro que desea guardar el nuevo usuario ?');" />&nbsp;
                                                <asp:Button ID="Button5" runat="server" Text="Cancelar" OnClick="Button5_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                <td style="width: 1162px; height: 21px">
                                    </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </asp:View>
            &nbsp;
            <asp:View ID="modificarUsuario" runat="server" OnActivate="modificarUsuario_Activate"><table width="100%">
                <tr>
                    <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                        <strong><span style="font-family: Verdana">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                ForeColor="#FFFFCC" Text="Modificar Usuario"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags"
                            prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace=""
                                prefix="st1" ?></td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                        <table style="width: 580px">
                            <tr>
                                <td style="width: 937px; height: 21px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Nombre:</strong></span></td>
                                <td style="width: 209px; height: 21px">
                        <asp:TextBox ID="TextBoxModificarUsuarioNombre" runat="server" Width="160px" MaxLength="30" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1350px; height: 26px">
                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                        ControlToValidate="TextBoxModificarUsuarioNombre" ErrorMessage="*"
                                        ValidationExpression="([a-zA-Z ]|[ñ|Ñ|á|é|í|ó|ú])+"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr style="font-size: 10pt; font-family: Verdana">
                                <td style="width: 937px; height: 21px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Usuario:</strong></span></td>
                                <td style="width: 209px; height: 21px">
                        <asp:TextBox ID="TextBoxModificarUsuarioUsuario" runat="server" Width="160px" MaxLength="15" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1350px; height: 21px">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                        ControlToValidate="TextBoxModificarUsuarioUsuario" ErrorMessage="*" ValidationExpression="([a-zA-Z]+[0-9]*)+"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 937px; height: 21px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Contraseña:</strong></span></td>
                                <td style="width: 209px; height: 21px">
                        <asp:TextBox ID="TextBoxModificarUsuarioClave" runat="server" Width="160px" TextMode="Password" MaxLength="20" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1350px; height: 21px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 937px; height: 21px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Confirmar Contraseña:</strong></span></td>
                                <td style="width: 209px; height: 21px">
                        <asp:TextBox ID="TextBoxModificarUsuarioConfirmClave" runat="server" Width="160px" TextMode="Password" MaxLength="20" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1350px; height: 21px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 937px; height: 21px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Rol:</strong></span></td>
                                <td style="width: 209px; height: 21px"><asp:DropDownList ID="DropDownListModificarUsuarioRol" runat="server" Width="160px" Font-Names="Calibri" Font-Size="10pt">
                        <asp:ListItem>Administrador</asp:ListItem>
                        <asp:ListItem>Usuario</asp:ListItem>
                    </asp:DropDownList></td>
                                <td style="width: 1350px; height: 21px">
                                    <asp:Button ID="Button13" runat="server" OnClick="Button13_Click2" Text="Crear Rol" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 937px; height: 15px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Carné de Identidad:</strong></span></td>
                                <td style="width: 209px; height: 15px">
                                    <asp:TextBox ID="TextBoxModificarUsuarioCarnet" runat="server" MaxLength="11" Width="160px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td style="width: 1350px; height: 15px">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                                        ControlToValidate="TextBoxCrearUsuarioUsuario" ErrorMessage="*" Height="1px"
                                        ValidationExpression="([0-9]*)+" Width="1px"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="width: 937px; height: 21px">
                                </td>
                                <td style="width: 209px; height: 21px; text-align: center;">
                        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Modificar" Font-Names="Calibri" Font-Size="11pt" Width="70px" OnClientClick="return confirm('¿Está seguro que desea guardar los cambios realizados ?');" />
                                    &nbsp; &nbsp;<asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Cancelar" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                <td style="width: 1350px; height: 21px">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                <br />
            </asp:View>
            <asp:View ID="gestionarRoles" runat="server" OnLoad="View9_Load" OnActivate="gestionarRoles_Activate">
                <table width="100%">
                    <tr>
                        <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                            <strong><span style="font-family: Verdana">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                    ForeColor="#FFFFCC" Text="Gestionar Roles"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags"
                                prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace=""
                                    prefix="st1" ?></td>
                    </tr>
                    <tr style="font-family: Times New Roman">
                        <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                            <br />
                            <table>
                                <tr>
                                    <td valign="top">
                                    <asp:ListBox ID="ListBoxGestionatRolesRoles" runat="server" Width="280px" AutoPostBack="True" Height="260px" OnSelectedIndexChanged="ListBoxGestionatRolesRoles_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt">
                                            <asp:ListItem>Error al cargar los roles</asp:ListItem>
                                        </asp:ListBox></td>
                                    <td colspan="2">
                                        <asp:Panel ID="Panel2" runat="server" Height="80px" Width="125px" Visible="False">
                                            <table style="width: 123px; height: 80px">
                                                <tr>
                                                    <td style="width: 7px; height: 21px; font-weight: bold;" align="left" valign="top">
                                                        <span style="font-size: 14pt; font-family: Calibri">&nbsp;Nombre:</span></td>
                                                    <td style="width: 7px; height: 21px" align="left" valign="top">
                                                        <asp:Label ID="Label6" runat="server" Width="170px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 7px; height: 23px; font-weight: bold;" align="left" valign="top">
                                                        <span style="font-size: 14pt; font-family: Calibri">&nbsp;Descripción:</span></td>
                                                    <td style="height: 23px;" align="left" valign="top">
                                                        <asp:Label ID="Label7" runat="server" Width="170px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="height: 22px; font-weight: bold;">
                                                        <span style="font-size: 14pt; font-family: Calibri">Funcionalidades</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2" style="height: 205px; padding-right: 2px; padding-left: 2px; padding-bottom: 5px;" valign="top">
                                                        <asp:ListBox ID="ListBox1ListaFuncionalidades" runat="server" Height="180px" Width="250px" Font-Names="Calibri" Font-Size="12pt">
                                                            <asp:ListItem>Error al cargar las funcionalidades</asp:ListItem>
                                                        </asp:ListBox><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                                    <asp:Button ID="Button14" runat="server" Text="Adicionar" OnClick="Button14_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                                                    <asp:Button ID="Button15" runat="server" Text="Modificar" OnClick="Button15_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                            <asp:Button ID="Button16" runat="server" Text=" Eliminar" OnClick="Button16_Click" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center">
                                                    <asp:Button ID="Button10" runat="server" OnClick="Button10_Click1" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 595px; height: 22px">
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="crearRol" runat="server" OnActivate="crearRol_Activate"><table style="width: 647px">
                <tr>
                    <td style="width: 98%; height: 22px; background-color: darkslategray" align="left">
                        <strong><span style="font-family: Verdana">
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                ForeColor="#FFFFCC" Text="Nuevo Rol"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags"
                            prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace=""
                                prefix="st1" ?></td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td style="border-right: #d8d787 2px solid; padding-right: 0px; border-top: #d8d787 2px solid;
                            padding-left: 0px; padding-bottom: 0px; border-left: #d8d787 2px solid; width: 98%;
                            padding-top: 0px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center; margin: 0px;" colspan="" rowspan="">
                        <table>
                            <tr>
                                <td>
                                    <strong><span style="font-size: 14pt; font-family: Calibri">Nombre del Rol</span></strong></td>
                                <td style="height: 28px">
                            <asp:TextBox ID="TextBoxCrearRolNombre" runat="server" MaxLength="100" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxCrearRolNombre"
                                        ErrorMessage="*" ValidationExpression="(([a-zA-Z ]|[ñ|Ñ|á|é|í|ó|ú])+[0-9]*)+"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Descripción del Rol</strong></span></td>
                                <td>
                            <asp:TextBox ID="TextBoxCrearRolDescripcion" runat="server" MaxLength="16" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBoxCrearRolDescripcion"
                                        ErrorMessage="*" ValidationExpression="(([a-zA-Z ]|[ñ|Ñ|á|é|í|ó|ú])+[0-9]*)+"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <strong><span style="font-size: 14pt; font-family: Calibri">Funcionalidades</span></strong></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="Panel4" runat="server" Height="270px" ScrollBars="Vertical" Width="550px" BorderStyle="Ridge" BorderWidth="1px">
                                    <asp:CheckBoxList ID="CheckBoxListCrearRolFuncionalidades" runat="server" RepeatColumns="2" Width="550px" Font-Names="Calibri" Font-Size="12pt">
                                        <asp:ListItem Selected="True">Error al cargar las funcionalidades</asp:ListItem>
                                    </asp:CheckBoxList></asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                                <asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="Adicionar" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                            <asp:Button ID="Button18" runat="server" OnClick="Button18_Click" Text="Cancelar" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </asp:View>
            &nbsp;
            <asp:View ID="modificarRol" runat="server" OnActivate="modificarRol_Activate"><table style="width: 647px">
                <tr>
                    <td style="width: 98%; height: 22px; background-color: darkslategray" align="left">
                        <strong><span style="font-family: Verdana">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                ForeColor="#FFFFCC" Text="Modificar Rol"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags"
                            prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace=""
                                prefix="st1" ?></td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td style="border-right: #d8d787 2px solid; padding-right: 0px; border-top: #d8d787 2px solid;
                            padding-left: 0px; padding-bottom: 0px; border-left: #d8d787 2px solid;
                            padding-top: 0px; border-bottom: #d8d787 2px solid; text-align: left; margin: 0px;">
                        <table width="100%">
                            <tr>
                                <td style="height: 26px">
                                    <span style="font-size: 14pt; font-family: Calibri; font-weight: bold;">Nombre del Rol
                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span>
                                    <asp:TextBox ID="TextBoxModificarRolNombre" runat="server" MaxLength="100" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBoxModificarRolNombre"
                                        ErrorMessage="*" ValidationExpression="([a-zA-Z ])*"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td style="height: 26px">
                                    <span style="font-size: 14pt; font-family: Calibri"><strong>Descripción del Rol&nbsp;
                                    </strong>
                                    <asp:TextBox ID="TextBoxD" runat="server" MaxLength="16" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                        ControlToValidate="TextBoxD" ErrorMessage="*" ValidationExpression="([a-zA-Z ])*"></asp:RegularExpressionValidator></span></td>
                            </tr>
                            <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                                <td style="height: 21px; text-align: center;">
                                    <span style="font-size: 14pt; font-family: Calibri; font-weight: bold;">Funcionalidades</span></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td>
                                    <asp:Panel ID="Panel5" runat="server" Height="270px" Width="550px" BorderStyle="Ridge" BorderWidth="1px" ScrollBars="Vertical">
                                    <asp:CheckBoxList ID="CheckBoxListModificarRolFuncionalidades" runat="server" RepeatColumns="2" Width="550px" Font-Names="Calibri" Font-Size="12pt">
                                        <asp:ListItem Selected="True">Error al cargar las funcionalidades</asp:ListItem>
                                    </asp:CheckBoxList><br />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="height: 21px; text-align: center;">
                            <asp:Button ID="Button21" runat="server" OnClick="Button21_Click" Text="Modificar" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                            <asp:Button ID="Button22" runat="server" OnClick="Button22_Click" Text="Cancelar" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </asp:View>
            &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:View ID="gConfiguracion" runat="server" OnActivate="gConfiguracion_Activate"><table width="100%" style="height: 391px">
                <tr>
                    <td style="width: 472px; height: 22px; background-color: darkslategray" align="left">
                        <strong><span style="font-family: Verdana">
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                ForeColor="#FFFFCC" Text="Configuración de Telebanca"></asp:Label><?xml
                            namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml
                                namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong></td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 472px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 221px; text-align: left" align="right">
                        <table style="width: 580px; left: 0px; position: relative; top: 0px; font-family: Calibri;">
                            <tr style="font-size: 10pt; font-family: Verdana"><td style="width: 227px;" align="left">
                                <span style="font-size: 12pt; font-family: Calibri"><strong>
                                Hora de Concilaciones:&nbsp;</strong></span></td><td>
                                        <asp:TextBox ID="TextBox6" runat="server" Width="153px" ReadOnly="True" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td align="center">
                                    <asp:Button ID="Button23" runat="server" OnClick="Button23_Click" Text="<<" Width="33px" /></td>
                                <td>
                                    <asp:DropDownList ID="DropDownList3" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownList5" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                        <asp:ListItem>32</asp:ListItem>
                                        <asp:ListItem>33</asp:ListItem>
                                        <asp:ListItem>34</asp:ListItem>
                                        <asp:ListItem>35</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>37</asp:ListItem>
                                        <asp:ListItem>38</asp:ListItem>
                                        <asp:ListItem>39</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>41</asp:ListItem>
                                        <asp:ListItem>42</asp:ListItem>
                                        <asp:ListItem>43</asp:ListItem>
                                        <asp:ListItem>44</asp:ListItem>
                                        <asp:ListItem>45</asp:ListItem>
                                        <asp:ListItem>46</asp:ListItem>
                                        <asp:ListItem>47</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                        <asp:ListItem>49</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>51</asp:ListItem>
                                        <asp:ListItem>52</asp:ListItem>
                                        <asp:ListItem>53</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>55</asp:ListItem>
                                        <asp:ListItem>56</asp:ListItem>
                                        <asp:ListItem>57</asp:ListItem>
                                        <asp:ListItem>58</asp:ListItem>
                                        <asp:ListItem>59</asp:ListItem>
                                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList6" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                        <asp:ListItem>32</asp:ListItem>
                                        <asp:ListItem>33</asp:ListItem>
                                        <asp:ListItem>34</asp:ListItem>
                                        <asp:ListItem>35</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>37</asp:ListItem>
                                        <asp:ListItem>38</asp:ListItem>
                                        <asp:ListItem>39</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>41</asp:ListItem>
                                        <asp:ListItem>42</asp:ListItem>
                                        <asp:ListItem>43</asp:ListItem>
                                        <asp:ListItem>44</asp:ListItem>
                                        <asp:ListItem>45</asp:ListItem>
                                        <asp:ListItem>46</asp:ListItem>
                                        <asp:ListItem>47</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                        <asp:ListItem>49</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>51</asp:ListItem>
                                        <asp:ListItem>52</asp:ListItem>
                                        <asp:ListItem>53</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>55</asp:ListItem>
                                        <asp:ListItem>56</asp:ListItem>
                                        <asp:ListItem>57</asp:ListItem>
                                        <asp:ListItem>58</asp:ListItem>
                                        <asp:ListItem>59</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td align="left" style="width: 227px;">
                                    <span><strong>
                                    Tiempo de Inactividad:</strong></span></td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="153px" ReadOnly="True" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td align="center">
                                    <asp:Button ID="Button26" runat="server" Text="<<" Width="33px" OnClick="Button26_Click1" /></td>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownList10" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList11" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
                                        <asp:ListItem>01</asp:ListItem>
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
                                        <asp:ListItem Value="30"></asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                        <asp:ListItem>32</asp:ListItem>
                                        <asp:ListItem>33</asp:ListItem>
                                        <asp:ListItem>34</asp:ListItem>
                                        <asp:ListItem>35</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>37</asp:ListItem>
                                        <asp:ListItem>38</asp:ListItem>
                                        <asp:ListItem>39</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>41</asp:ListItem>
                                        <asp:ListItem>42</asp:ListItem>
                                        <asp:ListItem>43</asp:ListItem>
                                        <asp:ListItem>44</asp:ListItem>
                                        <asp:ListItem>45</asp:ListItem>
                                        <asp:ListItem>46</asp:ListItem>
                                        <asp:ListItem>47</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                        <asp:ListItem>49</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>51</asp:ListItem>
                                        <asp:ListItem>52</asp:ListItem>
                                        <asp:ListItem>53</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>55</asp:ListItem>
                                        <asp:ListItem>56</asp:ListItem>
                                        <asp:ListItem>57</asp:ListItem>
                                        <asp:ListItem>58</asp:ListItem>
                                        <asp:ListItem>59</asp:ListItem>
                                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList12" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                        <asp:ListItem>32</asp:ListItem>
                                        <asp:ListItem>33</asp:ListItem>
                                        <asp:ListItem>34</asp:ListItem>
                                        <asp:ListItem>35</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>37</asp:ListItem>
                                        <asp:ListItem>38</asp:ListItem>
                                        <asp:ListItem>39</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>41</asp:ListItem>
                                        <asp:ListItem>42</asp:ListItem>
                                        <asp:ListItem>43</asp:ListItem>
                                        <asp:ListItem>44</asp:ListItem>
                                        <asp:ListItem>45</asp:ListItem>
                                        <asp:ListItem>46</asp:ListItem>
                                        <asp:ListItem>47</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                        <asp:ListItem>49</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>51</asp:ListItem>
                                        <asp:ListItem>52</asp:ListItem>
                                        <asp:ListItem>53</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>55</asp:ListItem>
                                        <asp:ListItem>56</asp:ListItem>
                                        <asp:ListItem>57</asp:ListItem>
                                        <asp:ListItem>58</asp:ListItem>
                                        <asp:ListItem>59</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri"><td style="width: 227px;" align="left">
                                <span><strong>
                                    Dirección &nbsp;Servidor BD:</strong></span></td><td>
                                        <asp:TextBox ID="TextBox5" runat="server" Width="153px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                        ControlToValidate="TextBox5" ErrorMessage="*" ValidationExpression="((((1?)([0-9]{1,2})|(2)(0|1|2|3|4|5)?(0|1|2|3|4|5)?)\.){3})(\d{1,3})"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5"
                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri"><td style="width: 227px;" align="left">
                                <span><strong>
                                    Hora inicio Peticiones WS:</strong></span></td><td>
                                        <asp:TextBox ID="TextBox8" runat="server" Width="153px" ReadOnly="True" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td align="center">
                                    <asp:Button ID="Button24" runat="server" OnClick="Button24_Click" Text="<<" Width="33px" /></td>
                                <td>
                                    <asp:DropDownList ID="DropDownList9" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList8" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                        <asp:ListItem>32</asp:ListItem>
                                        <asp:ListItem>33</asp:ListItem>
                                        <asp:ListItem>34</asp:ListItem>
                                        <asp:ListItem>35</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>37</asp:ListItem>
                                        <asp:ListItem>38</asp:ListItem>
                                        <asp:ListItem>39</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>41</asp:ListItem>
                                        <asp:ListItem>42</asp:ListItem>
                                        <asp:ListItem>43</asp:ListItem>
                                        <asp:ListItem>44</asp:ListItem>
                                        <asp:ListItem>45</asp:ListItem>
                                        <asp:ListItem>46</asp:ListItem>
                                        <asp:ListItem>47</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                        <asp:ListItem>49</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>51</asp:ListItem>
                                        <asp:ListItem>52</asp:ListItem>
                                        <asp:ListItem>53</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>55</asp:ListItem>
                                        <asp:ListItem>56</asp:ListItem>
                                        <asp:ListItem>57</asp:ListItem>
                                        <asp:ListItem>58</asp:ListItem>
                                        <asp:ListItem>59</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownList7" runat="server" Width="41px">
                                        <asp:ListItem>00</asp:ListItem>
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
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                        <asp:ListItem>32</asp:ListItem>
                                        <asp:ListItem>33</asp:ListItem>
                                        <asp:ListItem>34</asp:ListItem>
                                        <asp:ListItem>35</asp:ListItem>
                                        <asp:ListItem>36</asp:ListItem>
                                        <asp:ListItem>37</asp:ListItem>
                                        <asp:ListItem>38</asp:ListItem>
                                        <asp:ListItem>39</asp:ListItem>
                                        <asp:ListItem>40</asp:ListItem>
                                        <asp:ListItem>41</asp:ListItem>
                                        <asp:ListItem>42</asp:ListItem>
                                        <asp:ListItem>43</asp:ListItem>
                                        <asp:ListItem>44</asp:ListItem>
                                        <asp:ListItem>45</asp:ListItem>
                                        <asp:ListItem>46</asp:ListItem>
                                        <asp:ListItem>47</asp:ListItem>
                                        <asp:ListItem>48</asp:ListItem>
                                        <asp:ListItem>49</asp:ListItem>
                                        <asp:ListItem>50</asp:ListItem>
                                        <asp:ListItem>51</asp:ListItem>
                                        <asp:ListItem>52</asp:ListItem>
                                        <asp:ListItem>53</asp:ListItem>
                                        <asp:ListItem>54</asp:ListItem>
                                        <asp:ListItem>55</asp:ListItem>
                                        <asp:ListItem>56</asp:ListItem>
                                        <asp:ListItem>57</asp:ListItem>
                                        <asp:ListItem>58</asp:ListItem>
                                        <asp:ListItem>59</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri"><td style="width: 227px;" align="left">
                                <span><strong>
                                    Direc Salvas de la Base Datos:</strong></span></td><td align="left">
                                        <asp:TextBox ID="TextBox19" runat="server" Width="150px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td align="left">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                        ControlToValidate="TextBox19" ErrorMessage="*" ValidationExpression="[a-zA-Z ]{1}:\\(\w|\\)*"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox19"
                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td>
                                    </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td align="left" style="width: 227px;">
                                    <strong>
                                    Hora de Salva :</strong></td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" Width="150px" ReadOnly="True" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td align="center">
                                    <asp:Button ID="Button31" runat="server" OnClick="Button31_Click" Text="<<" Width="33px" /></td>
                                <td><asp:DropDownList ID="DropDownList13" runat="server" Width="41px">
                                    <asp:ListItem>00</asp:ListItem>
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
                                </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList14" runat="server" Width="41px">
                                    <asp:ListItem>00</asp:ListItem>
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
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>32</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>41</asp:ListItem>
                                    <asp:ListItem>42</asp:ListItem>
                                    <asp:ListItem>43</asp:ListItem>
                                    <asp:ListItem>44</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>46</asp:ListItem>
                                    <asp:ListItem>47</asp:ListItem>
                                    <asp:ListItem>48</asp:ListItem>
                                    <asp:ListItem>49</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>51</asp:ListItem>
                                    <asp:ListItem>52</asp:ListItem>
                                    <asp:ListItem>53</asp:ListItem>
                                    <asp:ListItem>54</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                    <asp:ListItem>56</asp:ListItem>
                                    <asp:ListItem>57</asp:ListItem>
                                    <asp:ListItem>58</asp:ListItem>
                                    <asp:ListItem>59</asp:ListItem>
                                </asp:DropDownList>&nbsp;<asp:DropDownList ID="DropDownList15" runat="server" Width="41px">
                                    <asp:ListItem>00</asp:ListItem>
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
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                    <asp:ListItem>32</asp:ListItem>
                                    <asp:ListItem>33</asp:ListItem>
                                    <asp:ListItem>34</asp:ListItem>
                                    <asp:ListItem>35</asp:ListItem>
                                    <asp:ListItem>36</asp:ListItem>
                                    <asp:ListItem>37</asp:ListItem>
                                    <asp:ListItem>38</asp:ListItem>
                                    <asp:ListItem>39</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>41</asp:ListItem>
                                    <asp:ListItem>42</asp:ListItem>
                                    <asp:ListItem>43</asp:ListItem>
                                    <asp:ListItem>44</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                    <asp:ListItem>46</asp:ListItem>
                                    <asp:ListItem>47</asp:ListItem>
                                    <asp:ListItem>48</asp:ListItem>
                                    <asp:ListItem>49</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>51</asp:ListItem>
                                    <asp:ListItem>52</asp:ListItem>
                                    <asp:ListItem>53</asp:ListItem>
                                    <asp:ListItem>54</asp:ListItem>
                                    <asp:ListItem>55</asp:ListItem>
                                    <asp:ListItem>56</asp:ListItem>
                                    <asp:ListItem>57</asp:ListItem>
                                    <asp:ListItem>58</asp:ListItem>
                                    <asp:ListItem>59</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td style="width: 227px;">
                                    <span><strong>Dirección &nbsp;Servidor FTP:</strong></span></td>
                                <td>
                                        <asp:TextBox ID="TextBox14" runat="server" Width="150px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                        ControlToValidate="TextBox14" ErrorMessage="*" ValidationExpression="((((1?)([0-9]{1,2})|(2)(0|1|2|3|4|5)?(0|1|2|3|4|5)?)\.){3})(\d{1,3})"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox14"
                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td>
                                    </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td style="width: 227px;">
                                    <span><strong>Usuario FTP:</strong></span></td>
                                <td>
                                        <asp:TextBox ID="TextBox7" runat="server" Width="150px" Font-Names="Calibri" Font-Size="10pt"></asp:TextBox></td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox7"
                                        ErrorMessage="*" ValidationExpression="([a-zA-Z ])*"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7"
                                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td align="center">
                                    </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td style="width: 227px;">
                                    <span><strong>
                                    Contraseña FTP:</strong></span></td>
                                <td>
                                        <asp:TextBox ID="TextBox11" runat="server" Width="150px" Font-Names="Calibri" Font-Size="10pt" TextMode="Password"></asp:TextBox></td>
                                <td>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                        ControlToValidate="TextBox11" ErrorMessage="*" ValidationExpression="([a-zA-Z ]|\d*)*"></asp:RegularExpressionValidator></td>
                                <td align="center">
                                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td style="width: 227px;">
                                    <strong>
                                    Impresora de Pines:</strong></td>
                                <td colspan="3" rowspan="" align="center">
                                    <asp:DropDownList ID="DdlImprPin" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlImprPin_SelectedIndexChanged"
                                        Width="314px" Visible="False" Font-Names="Calibri" Font-Size="10pt">
                                    </asp:DropDownList>&nbsp;
                                    <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text=" Aceptar " CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td style="width: 227px;">
                                    <strong>
                                    Impresora de Tarjetas:</strong></td>
                                <td align="center" colspan="3">
                                    <asp:DropDownList ID="DdlImprTarj" runat="server" AutoPostBack="True" Width="314px" OnSelectedIndexChanged="DdlImprTarj_SelectedIndexChanged" Visible="False" Font-Names="Calibri" Font-Size="10pt">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;<asp:Button ID="Button12" runat="server" OnClick="Button51_Click" Text="Cancelar" Width="80px" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Calibri">
                                <td style="width: 227px;">
                                    <strong>
                                    Fecha Contable Base Dato:</strong>
                                </td>
                                <td align="center" colspan="3">
                                    <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Theme="Youthful">
                                    </dx:ASPxDateEdit>&nbsp;
                                    <dx:ASPxButton ID="UpdateFecContButton" runat="server" Text="Actualizar Fecha" OnClick="UpdateFecContButton_Click">
                                        <ClientSideEvents Click="function(s, e) {
	return confirm(' Desea realmente actualizar la fecha contable? ');
}" />
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </asp:View>
            &nbsp; &nbsp;&nbsp;
            <asp:View ID="salvarOrestaurarDatos" runat="server"><table width="100%">
                <tr>
                    <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                        <strong><span style="font-family: Verdana">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                ForeColor="#FFFFCC" Text="Gestionar Salva-Restauración-Mantenimiento"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags"
                            prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace=""
                                prefix="st1" ?></td>
                </tr>
                <tr style="font-family: Times New Roman">
                    <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                        <br />
                        <table>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                            <asp:RadioButtonList ID="RadioButtonListSalvarRestaurarDatos" runat="server" RepeatDirection="Horizontal"
                                Width="322px" AutoPostBack="True" OnPreRender="RadioButtonListSalvarRestaurarDatos_PreRender" OnSelectedIndexChanged="RadioButtonListSalvarRestaurarDatos_SelectedIndexChanged" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt" ForeColor="Teal">
                                <asp:ListItem Selected="True">Realizar Salvas  </asp:ListItem>
                                <asp:ListItem>Restaurar Base de Datos</asp:ListItem>
                            </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:DropDownList ID="DropDownList16" runat="server" Width="177px" Font-Names="Calibri" Font-Size="12pt">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="Button30" runat="server" OnClick="Button30_Click1" Text="Aceptar" Width="70px" Font-Names="Calibri" Font-Size="11pt" />&nbsp;<asp:Button
                                        ID="Button32" runat="server" OnClick="Button32_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="Button25" runat="server" Text="Aceptar" OnClick="Button25_Click1" style="left: 0px; position: relative; top: 0px" Font-Names="Calibri" Font-Size="11pt" Width="70px" />&nbsp;
                            <asp:Button ID="Button38" runat="server" OnClick="Button38_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label ID="Label5" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                        ForeColor="Teal" Text="Mantenimiento"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Calibri" Text="Salvar Transacciones del año:"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                        BorderWidth="1px" CellPadding="2" Font-Names="Calibri" Font-Size="12pt" ForeColor="Black"
                                        GridLines="Horizontal" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" ShowHeader="False">
                                        <FooterStyle BackColor="#A2A764" />
                                        <SelectedRowStyle BackColor="#E0E0E0" ForeColor="Black" />
                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        <Columns>
                                            <asp:BoundField DataField="Column1" HeaderText="Column1" ReadOnly="True" SortExpression="Column1" />
                                            <asp:CommandField SelectText="&lt;--" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="select distinct YEAR(FechaHora)from TLB_Transaccion where YEAR(FechaHora)< YEAR(GETDATE())-2">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="Button35" runat="server" Text="Salvar" OnClick="Button35_Click1" />&nbsp;
                                    <asp:Button ID="Button36" runat="server" Text="Cancelar" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </asp:View>
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
            <asp:View ID="gestionarInformTb" runat="server" OnActivate="gestionarInformTb_Activate">
                <table width="100%">
                    <tr>
                        <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                            <strong><span style="font-family: Verdana">
                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                    ForeColor="#FFFFCC" Text="Gestionar Información de Telebanca"></asp:Label><?xml
                                namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml
                                    namespace="" prefix="st1" ?></span></strong><?xml namespace="" prefix="st1" ?></td>
                    </tr>
                    <tr style="font-family: Times New Roman">
                        <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                            <table style="width: 580px">
                                <tr>
                                    <td style="width: 7866px; height: 26px">
                                    </td>
                                    <td style="width: 203px; height: 26px">
                                    </td>
                                    <td style="width: 1277px; height: 26px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 7866px; height: 13px">
                                        <span style="font-family: Calibri"><strong>Nombre:</strong></span></td>
                                    <td style="width: 203px; height: 13px">
                            <asp:TextBox ID="TextBox30" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 13px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox30"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                            ControlToValidate="TextBox30" ErrorMessage="*" ValidationExpression="([a-zA-Z ])*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 10pt; font-family: Verdana">
                        <td align="left" style="width: 7866px; height: 18px;">
                            <span style="font-size: 12pt; font-family: Calibri"><strong>
                            Dirección:</strong></span></td>
                                    <td style="width: 203px; height: 21px">
                            <asp:TextBox ID="TextBox31" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 21px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox31"
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                            ControlToValidate="TextBox31" ErrorMessage="*" ValidationExpression="([a-zA-Z ])*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 18px">
                            <span style="font-family: Calibri"><strong>Teléfono:</strong></span></td>
                                    <td style="width: 203px; height: 18px">
                            <asp:TextBox ID="TextBox32" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 18px">
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox32"
                                            ErrorMessage=" *" MaximumValue="999999999999" MinimumValue="99"
                                            Type="Double"></asp:RangeValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 20px">
                            <span style="font-family: Calibri"><strong>Fax:</strong></span></td>
                                    <td style="width: 203px; height: 20px">
                            <asp:TextBox ID="TextBox33" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 20px">
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox33"
                                            ErrorMessage="*" MaximumValue="999999999999" MinimumValue="9" Type="Double"></asp:RangeValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 21px">
                            <span style="font-family: Calibri"><strong>
                            Sitio Web:</strong></span></td>
                                    <td style="width: 203px; height: 21px">
                            <asp:TextBox ID="TextBox34" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 21px" align="left">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox34"
                                            ErrorMessage=" *" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"
                                            Width="182px"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 21px">
                            <span style="font-family: Calibri"><strong>Logotipo:</strong></span></td>
                                    <td style="width: 203px; height: 21px">
                            <asp:TextBox ID="TextBox35" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 21px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                            ControlToValidate="TextBox35" ErrorMessage="*" ValidationExpression="([a-zA-Z ]|\d*)*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 21px">
                            <span style="font-family: Calibri;"><strong>Director:</strong></span></td>
                                    <td style="width: 203px; height: 21px">
                            <asp:TextBox ID="TextBox36" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 21px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                            ControlToValidate="TextBox36" ErrorMessage="*" ValidationExpression="([a-zA-Z ])*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 11px">
                            <span style="font-family: Calibri"><strong>
                            Correo Electrónico:</strong></span></td>
                                    <td style="width: 203px; height: 11px">
                            <asp:TextBox ID="TextBox37" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 11px" align="left">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox37"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" EnableTheming="True" ErrorMessage="*" Width="19px" Height="25px"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 21px">
                            <span style="font-family: Calibri"><strong>Ministerio:</strong></span></td>
                                    <td style="width: 203px; height: 21px">
                            <asp:TextBox ID="TextBox38" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 21px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                            ControlToValidate="TextBox38" ErrorMessage="*" ValidationExpression="([a-zA-Z ]|\d*)*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                        <td align="left" style="width: 7866px; height: 34px;">
                            <span style="font-family: Calibri"><strong>Descripción de Servicios: </strong></span>
                        </td>
                                    <td style="width: 203px; height: 34px">
                            <asp:TextBox ID="TextBox39" runat="server" Width="200px"></asp:TextBox></td>
                                    <td style="width: 1277px; height: 34px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server"
                                            ControlToValidate="TextBox39" ErrorMessage="*" ValidationExpression="([a-zA-Z ]|\d*)*"></asp:RegularExpressionValidator></td>
                                </tr>
                                <tr style="font-size: 12pt">
                                    <td style="width: 7866px; height: 21px">
                                    </td>
                                    <td style="width: 203px; height: 21px; text-align: center;">
                            <asp:Button ID="Button50" runat="server" OnClick="Button50_Click" Text="Aceptar" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" OnClientClick="return confirm('¿ Está seguro que desea modificar la Informacion de la Banca ?');" />&nbsp;
                            <asp:Button ID="Button51" runat="server" OnClick="Button51_Click" Text="Cancelar" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                    <td style="width: 1277px; height: 21px">
                                    </td>
                                </tr>
                            </table>
                            </td>
                    </tr>
                </table>
            </asp:View>
            <br />
            <asp:View ID="MostrarNotificaciones" runat="server" OnActivate="MostrarNotificaciones_Activate">
                <table width="100%">
                    <tr>
                        <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                            <strong><span style="font-family: Verdana">
                                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                    ForeColor="#FFFFCC" Text="Mostrar Notificaciones"></asp:Label></span></strong></td>
                    </tr>
                    <tr style="font-family: Times New Roman">
                        <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 12px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 12px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                            <table style="width: 580px; height: 22px;">
                                <tr>
                                    <td style="height: 22px; width: 599px;">
                                        <asp:Panel ID="Panel3" runat="server" Height="330px" ScrollBars="Vertical" Width="570px" BorderStyle="Ridge" BorderWidth="1px">
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                BackColor="White" BorderStyle="Double"
                                                CellPadding="4" DataSourceID="SqlDataSource1" GridLines="Horizontal"
                                                OnRowDataBound="GridView1_RowDataBound" Width="548px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                                <RowStyle BackColor="White" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha">
                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle Width="30%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n" SortExpression="Descripcion">
                                                        <ItemStyle Width="70%" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <FooterStyle BackColor="#A2A764" ForeColor="#333333" />
                                                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                                SelectCommand="SELECT fecha, Descripcion FROM TLB_Notificacion WHERE (fecha >= GETDATE() - 3) ORDER BY fecha DESC">
                                            </asp:SqlDataSource>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 22px; width: 599px;" align="left">
                                        Cantidad de notificaciones:&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Red"
                                            Text="0"></asp:Label>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; 
                                                    <asp:Button ID="Button27" runat="server" OnClick="Button27_Click" Text="Marcar  Todas" Width="115px" Visible="False" />&nbsp;
                                                &nbsp;
                                                    <asp:Button ID="Button28" runat="server" OnClick="Button28_Click1" Text="Desmarcar  Todas" Enabled="False" Width="115px" Visible="False" /></td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 22px; width: 599px;">
                                        <table style="width: 570px; height: 36px;">
                                            <tr>
                                                <td style="width: 85px; height: 26px">
                                                    &nbsp;
                                                    <asp:Button ID="Button19" runat="server" OnClick="Button19_Click" Text="Eliminar" Visible="False" /></td>
                                                <td style="width: 480px; height: 26px" align="center">
                                                    &nbsp;<asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="Cancelar" Visible="False" />&nbsp;<asp:Button
                                                        ID="Button34" runat="server" OnClick="Button34_Click1" Text="Actualizar" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View1" runat="server">
                <table width="100%">
                    <tr>
                        <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                            <strong><span style="font-family: Verdana">
                                <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                    ForeColor="#FFFCCC" Text=" Reporte de Tarjetas de Banca Telefonica"></asp:Label></span></strong></td>
                    </tr>
                    <tr>
                        <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                            &nbsp;<span style="font-family: Calibri"><strong>Seleccione Reporte: </strong></span>
                            &nbsp;
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Value="0">Tarjetas</asp:ListItem>
                                <asp:ListItem Value="1">Tarjetas_Asociados</asp:ListItem>
                            </asp:DropDownList><br />
                            <br />
                            <asp:Button ID="Button29" runat="server" OnClick="Button29_Click1" Text="Aceptar" />
                            <asp:Button ID="Button33" runat="server" OnClick="Button33_Click1" Text="Cancelar" /></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server" OnActivate="View2_Activate">
                <table width="100%">
                    <tr>
                        <td style="width: 595px; height: 22px; background-color: darkslategray" align="left">
                            <strong><span style="font-family: Verdana">
                                <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                    ForeColor="#FFFFCC" Text="Desbloquear Usuario"></asp:Label><?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags"
                                        prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace=""
                                            prefix="st1" ?></td>
                    </tr>
                    <tr style="font-family: Times New Roman; color: #000000;">
                        <td style="border-right: #d8d787 2px solid; padding-right: 10px; border-top: #d8d787 2px solid;
                            padding-left: 10px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                            padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                            <table style="width: 580px">
                                <tr>
                                    <td style="width: 702px; height: 26px">
                                        <span style="font-size: 14pt; font-family: Calibri"><strong>Carné de Identidad:</strong></span></td>
                                    <td style="width: 208px; height: 21px; text-align: center;">
                                        <asp:TextBox ID="TextBox3" runat="server" Font-Names="Calibri" Font-Size="10pt" MaxLength="11"
                                            ToolTip="Carné de Identidad" ValidationGroup="1" Width="140px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox><asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator26" runat="server" ControlToValidate="TextBoxCrearUsuarioCarnet"
                                                ErrorMessage="*" ValidationExpression="([0-9]*)+"></asp:RegularExpressionValidator></td>
                                    <td style="width: 1162px; height: 26px">
                                        &nbsp;
                                        <asp:Button ID="Button40" runat="server" Text="Buscar" OnClick="Button5_Click" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" Width="70px" ValidationGroup="1" /></td>
                                </tr>
                                <tr style="font-size: 14pt; font-family: Calibri; font-weight: bold; color: #000000;">
                                    <td style="height: 26px; text-align: center;" colspan="3">
                                        <span></span>
                                        <asp:GridView ID="GridView3" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                            BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource3" ForeColor="Black"
                                            GridLines="Horizontal" AutoGenerateColumns="False" DataKeyNames="usuario" ShowFooter="True" Font-Names="Calibri" Font-Size="Small" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
                                            <FooterStyle BackColor="#A2A764" />
                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="White" ForeColor="Black" />
                                            <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                            <Columns>
                                                <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="usuario" />
                                                <asp:BoundField DataField="nombre" HeaderText="Nombre(s) y Apellidos" SortExpression="nombre" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n" SortExpression="Descripcion" />
                                                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr style="font-weight: bold; font-size: 14pt; color: #000000; font-family: Calibri">
                                    <td colspan="3" style="height: 26px; text-align: center">
                                        <asp:Label ID="Label19" runat="server" Font-Names="Calibri" ForeColor="#00C000" Visible="False"></asp:Label></td>
                                </tr>
                                <tr style="font-size: 14pt; color: #000000; font-family: Calibri">
                                    <td style="width: 702px; height: 26px">
                                        <span style="font-size: 12pt; font-family: Times New Roman"></span>
                                    </td>
                                    <td style="width: 208px; height: 26px; text-align: center;">
                                        <strong>Desbloquear</strong></td>
                                    <td style="width: 1162px; height: 26px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 702px; height: 26px">
                                        <span style="font-size: 14pt; font-family: Calibri"><strong></strong></span>
                                    </td>
                                    <td style="width: 208px; height: 21px; text-align: center;">
                                        <asp:Button ID="Button37" runat="server" Text="Sí" Width="70px" Enabled="False" OnClick="Button37_Click1" />&nbsp;
                                        <asp:Button ID="Button39" runat="server" Text="No" Width="70px" OnClick="Button39_Click" /></td>
                                    <td style="width: 1162px; height: 21px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 702px; height: 26px">
                                        <span style="font-size: 14pt; font-family: Calibri"><strong></strong></span>
                                    </td>
                                    <td style="width: 208px; height: 21px">
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>" SelectCommand="SELECT TOP (1) TLB_Usuario.usuario, TLB_Usuario.nombre, TLB_AccionesUsuario.Fecha, TLB_AccionesUsuario.Descripcion FROM TLB_Usuario INNER JOIN TLB_AccionesUsuario ON TLB_Usuario.usuario = TLB_AccionesUsuario.Usuario WHERE (TLB_Usuario.Activo = 0) AND (TLB_Usuario.CI = @CI) ORDER BY TLB_AccionesUsuario.Fecha DESC">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="TextBox3" Name="CI" PropertyName="Text" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td style="width: 1162px; height: 21px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView></td>
    </tr>
    </table>
<br />
<br />
<br />
<br />
<br />
&nbsp;
