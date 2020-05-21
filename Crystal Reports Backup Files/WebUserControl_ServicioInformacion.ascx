<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl_ServicioInformacion.ascx.cs" Inherits="WebUserControla" %>
<%@ Register Assembly="msgBox" Namespace="BunnyBear" TagPrefix="cc1" %>
<script type="text/javascript" src="../../Scripts/JScript.js">
    </script>
<table width="800">
    <tr>
        <td style="width: 172px;" valign="top">
            <asp:Menu ID="Menu1" runat="server" BackColor="Transparent" BorderColor="Transparent"
                Font-Bold="False" Font-Italic="False" Font-Names="Calibri" Font-Overline="False"
                Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" ForeColor="Black"
                OnMenuItemClick="Menu1_MenuItemClick" Width="100%" Target="top">
                <StaticSelectedStyle BackColor="#FFFFCC" BorderColor="#FFFFCC" />
                <Items>
                    <asp:MenuItem Enabled="False" Selectable="False" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text=" " Value=" "></asp:MenuItem>
                    <asp:MenuItem Selected="True" SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Servicio de Informaci&#243;n" Value="0"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Gestionar Informaci&#243;n" Value="1"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Buscar Informaci&#243;n" Value="2"></asp:MenuItem>
                    <asp:MenuItem SeparatorImageUrl="~/Images/Imagenes/separador del men&#250; lateral .jpg"
                        Text="Realizar Reportes" Value="18"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#FFFFCC" BorderColor="#FFFFCC" />
            </asp:Menu>
        </td>
        <td style="width: 628px;" valign="top">
            <asp:MultiView ID="MVwInformacion" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                                padding-left: 15px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 538px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 21px; text-align: justify">
                                <span style="font-family: Verdana"><span style="font-size: 14pt"><strong><span style="font-family: Calibri; color: teal;">
                                    Servicio de Información<br />
                                </span>
                                    <br />
                                </strong><span lang="ES-TRAD" style="font-family: Calibri; mso-fareast-font-family: 'Times New Roman';
                                    mso-ansi-language: ES-TRAD; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                    mso-bidi-font-size: 10.0pt; mso-bidi-font-family: Arial">A través de esta sección
                                    usted podrá gestionar y dar respuestas a la información solicitada por los clientes
                                    respecto a procesos referentes a temas bancarios e informaciones que conciernen<span
                                        lang="ES-TRAD" style="font-size: 12pt; mso-fareast-font-family: 'Times New Roman';
                                        mso-ansi-language: ES-TRAD; mso-fareast-language: EN-US; mso-bidi-language: AR-SA;
                                        mso-bidi-font-size: 10.0pt; mso-bidi-font-family: Arial"></span> a otras entidades
                                    banca cubana. Permite además realizar reportes de los temas más solicitados para
                                    que se conozcan cuales son las mayores dudas que tiene la población respecto a sus
                                    prestaciones.</span></span></span></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana; background-color: darkslategray;">
                                    <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Gestionar Información"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                                                        <asp:Button ID="Button1" runat="server" Text="Gestión de Agenda Electrónica" OnClick="Button1_Click" Width="250px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                <br />
                                                        <asp:Button ID="Button2" runat="server" Text="Gestión de Información de Procesos" OnClick="Button2_Click" Font-Names="Calibri" Font-Size="11pt" Width="250px" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Buscar Información"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                                                        <asp:Button ID="Button3" runat="server" Text="Buscar en la Agenda Electrónica" OnClick="Button3_Click" Height="26px" Width="250px" Font-Names="Calibri" Font-Size="11pt" />&nbsp;<asp:Button
                                                            ID="Button60" runat="server" Height="26px" OnClick="Button60_Click" Text="Sucursales que trabajan los Sábados"
                                                            Width="250px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                <br />
                                                        <asp:Button ID="Button4" runat="server" Text="Buscar Información de Procesos " OnClick="Button4_Click" Height="26px" Width="250px" Font-Names="Calibri" Font-Size="11pt" />&nbsp;<asp:Button
                                                            ID="Button61" runat="server" Height="26px" Text="Horario Extendido y Desplazado "
                                                            Width="250px" OnClick="Button61_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                <br />
                                <asp:Button ID="Button62" runat="server" Height="26px" Text="Operaciones Clientes en Sucursal"
                                    Width="250px" OnClick="Button62_Click" Font-Names="Calibri" Font-Size="11pt" />&nbsp;<asp:Button ID="Button63" runat="server" Height="26px" Text="Ubicación Cajeros Automáticos"
                                        Width="250px" OnClick="Button63_Click" Font-Names="Calibri" Font-Size="11pt" /><br />
                                <br />
                                <asp:Button ID="Button64" runat="server" Height="26px" Text="Tipos de Cambio" Width="250px" OnClick="Button64_Click" Font-Names="Calibri" Font-Size="11pt" />&nbsp;<asp:Button
                                    ID="Button65" runat="server" Height="26px" OnClick="Button65_Click" Text="Datos Generales de Sucursales"
                                    Width="250px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                <br />
                                <asp:Button ID="Button66" runat="server" Height="26px" Text="Tasa de Interés" Width="250px" Font-Names="Calibri" Font-Size="11pt" OnClick="Button66_Click" />&nbsp;<asp:Button
                                    ID="Button67" runat="server" Height="26px" OnClick="Button67_Click" Text="Sucursales que venden Sellos Timbre"
                                    Width="250px" Font-Names="Calibri" Font-Size="11pt" /><br />
                                <br />
                                <asp:Button ID="Button68" runat="server" Font-Names="Calibri" Font-Size="11pt"
                                    Height="26px" OnClick="Button68_Click" Text="Pagos Jubilados-Pensionados" Width="250px" />
                                <asp:Button ID="Button70" runat="server" Font-Names="Calibri" Font-Size="11pt"
                                    Height="26px" OnClick="Button70_Click" Text="Renovación Tarjetas  Jubilados" Width="250px" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View4" runat="server" OnActivate="View4_Activate">
                    <table width="100%">
                        <tr>
                            <td style="width: 604px; height: 22px; background-color: darkslategray">
                                <span style="font-family: Verdana">
                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                                        ForeColor="#FFFFCC" Text="Gestión de Agenda Electrónica"></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 604px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <table style="width: 320px; height: 1px;">
                                    <tr>
                                        <td colspan="3" style="height: 72px; width: 74px; text-align: center;">
                                            <asp:ListBox ID="ListBox1" runat="server" Width="600px" Height="310px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 9px; width: 74px; text-align: center;">
                                            <asp:Button ID="Button5" runat="server" Font-Names="Calibri" Font-Size="11pt" OnClick="Button5_Click1" Text="Insertar" Width="76px" />
                                            <asp:Button ID="Button6" runat="server" Enabled="False" Font-Names="Calibri" Font-Size="11pt" OnClick="Button6_Click" Text="Modificar" Width="76px" />
                                            <asp:Button ID="Button7" runat="server" Enabled="False" Font-Names="Calibri" Font-Size="11pt" OnClick="Button7_Click" Text=" Eliminar" Width="76px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View5" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana; background-color: darkslategray;">
                                    <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Insertar Información en la Agenda Electrónica"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table>
                                    <tr>
                                        <td style="width: 332px">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Nombre de la Entidad:</span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox1" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">Sucursal Playa
</asp:TextBox></td>
                                        <td style="width: 6px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                ControlToValidate="TextBox1" ErrorMessage="*" ValidationExpression="([A-Z]|[a-z]| |[0-9])*"
                                                Width="1px"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 332px">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Dirección:</span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox2" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">42 y 29. Playa
</asp:TextBox></td>
                                        <td style="width: 6px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 332px">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Fax:</span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox4" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">2047394
</asp:TextBox></td>
                                        <td style="width: 6px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4"
                                                ErrorMessage="*" ValidationExpression="([0-9]| |[A-Z]|[a-z])*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 332px">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Código Anterior de la Sucursal:</span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox6" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">2421
</asp:TextBox></td>
                                        <td style="width: 6px">
                                        </td>
                                        <td style="width: 100px">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox6"
                                                ErrorMessage="*" ValidationExpression="(1|2|3|4|5|6|7|8|9|0)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 332px">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Código Actual de la Sucursal:</span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox7" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">242
</asp:TextBox></td>
                                        <td style="width: 6px">
                                        </td>
                                        <td style="width: 100px">
                                                        <asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox7" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox7"
                                                ErrorMessage="*" ValidationExpression="(1|2|3|4|5|6|7|8|9|0)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 332px">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Teléfono(s):</span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox3" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">2047394</asp:TextBox></td>
                                        <td style="width: 6px">
                                                        <asp:Button ID="Button47" runat="server" Text="▼" CausesValidation="False" OnClick="Button47_Click1" Width="17px" /></td>
                                        <td rowspan="2" style="width: 100px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                ControlToValidate="DropDownList9" ErrorMessage="RequiredFieldValidator" Width="1px">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox3"
                                                ErrorMessage="*" ValidationExpression="([0-9]| |[A-Z]|[a-z])*" Width="1px"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox3"
                                                ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 237px">
                                            <asp:DropDownList ID="DropDownList9" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">
                                                        </asp:DropDownList></td>
                                        <td style="width: 6px">
                                            <asp:Button ID="Button45" runat="server" Text="▲" Width="17px" OnClick="Button45_Click2" CausesValidation="False" /></td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 332px">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Sitio(s) Web Relacionado(s):</span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox5" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt"></asp:TextBox>
                                            &nbsp; &nbsp;
                                        </td>
                                        <td style="width: 6px">
                                                        <asp:Button ID="Button49" runat="server" Text="▼" Width="17px" OnClick="Button49_Click" CausesValidation="False" /></td>
                                        <td rowspan="2" style="width: 100px">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                                            runat="server" ControlToValidate="DropDownList10" ErrorMessage="*" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="TextBox5"
                                                ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 237px">
                                                        <asp:DropDownList ID="DropDownList10" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">
                                                        </asp:DropDownList></td>
                                        <td style="width: 6px">
                                            <asp:Button ID="Button48" runat="server" Text="▲" Width="17px" OnClick="Button48_Click" CausesValidation="False" /></td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 332px">
                                            <strong><span style="font-family: Calibri"><span style="font-size: 14pt">Correo(s)
                                                E<span lang="ES-TRAD"
                                                style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-TRAD;
                                                mso-fareast-language: EN-US; mso-bidi-language: AR-SA">lectrónico(s):</span></span></span></strong></td>
                                        <td style="width: 237px">
                                            <asp:TextBox ID="TextBox18" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">dirsuc2421@banco-metropolitano.cu
</asp:TextBox></td>
                                        <td style="width: 6px">
                                                        <asp:Button ID="Button51" runat="server" Text="▼" Width="17px" OnClick="Button51_Click1" CausesValidation="False" /></td>
                                        <td rowspan="2" style="width: 100px">
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="DropDownList11"
                                                ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="TextBox18"
                                                ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 237px">
                                            <asp:DropDownList ID="DropDownList11" runat="server" Width="250px" Font-Names="Calibri" Font-Size="11pt">
                                                        </asp:DropDownList></td>
                                        <td style="width: 6px">
                                                        <asp:Button ID="Button50" runat="server" Text="▲" Width="17px" OnClick="Button50_Click1" CausesValidation="False" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 332px">
                                        </td>
                                        <td style="width: 237px; text-align: center">
                                                        <asp:Button ID="Button8" runat="server" Text="Aceptar" OnClick="Button8_Click" Width="76px" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" />
                                            &nbsp; &nbsp; &nbsp; &nbsp;
                                            <asp:Button ID="Button9" runat="server" Text="Cancelar" OnClick="Button9_Click1" Width="76px" CausesValidation="False" Font-Names="Calibri" Font-Size="11pt" /></td>
                                        <td style="width: 6px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View6" runat="server" OnActivate="View6_Activate">
                    <table width="100%" style="height: 1px">
                        <tr>
                            <td style="width: 408px; height: 20px; background-color: darkslategray" colspan="1">
                                <strong><span style="font-family: Verdana; color: #ffffcc;">Modificar Información en
                                    <?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?>
                                    <?xml namespace="" prefix="st1" ?>
                                    <st1:personname productid="la Agenda Electrónica" w:st="on">la Agenda Electrónica</st1:personname></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 408px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 1px; text-align: left">
                                <table style="width: 600px; height: 1px;">
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; height: 36px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Nombre de la Entidad:</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; height: 36px;">
                                            <asp:Label ID="Label4" runat="server" Width="381px" Font-Names="Arial" Font-Size="Smaller" Height="22px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; padding-top: 3px; height: 21px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Dirección:</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; padding-top: 3px; height: 21px">
                                            <asp:TextBox ID="TextBox8" runat="server" Width="381px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox8"
                                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; padding-top: 3px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Fax:</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; padding-top: 3px">
                                            <asp:TextBox ID="TextBox10" runat="server" Width="381px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox10"
                                                ErrorMessage="*" ValidationExpression="([0-9]| |[A-Z]|[a-z])*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; padding-top: 3px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Código Anterior de la Sucursal:</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; padding-top: 3px">
                                            <asp:TextBox ID="TextBox12" runat="server" Width="381px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBox12"
                                                ErrorMessage="*" ValidationExpression="(1|2|3|4|5|6|7|8|9|0)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; padding-top: 3px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Código Actual de la Sucursal:</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; padding-top: 3px">
                                            <asp:TextBox ID="TextBox13" runat="server" Width="381px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox13"
                                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBox13"
                                                ErrorMessage="*" ValidationExpression="(1|2|3|4|5|6|7|8|9|0)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; padding-top: 3px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Teléfono(s):</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; padding-top: 3px">
                                            <asp:TextBox ID="TextBox9" runat="server" Width="100px"></asp:TextBox>
                                            <asp:Button ID="Button52" runat="server" Text="<" Width="17px" OnClick="Button52_Click" CausesValidation="False" />
                                            <asp:Button ID="Button53" runat="server" Text=">" CausesValidation="False" OnClick="Button53_Click" Width="17px" />
                                            <asp:DropDownList ID="DropDownList12" runat="server" Width="237px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownList12"
                                                ErrorMessage="RequiredFieldValidator" Width="1px">*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                ControlToValidate="TextBox9" ErrorMessage="*" ValidationExpression="([0-9]| |[A-Z]|[a-z])*"
                                                Width="1px"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="TextBox9"
                                                ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; padding-top: 3px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Sitio(s) Web relacionado(s):</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; padding-top: 3px">
                                            <asp:TextBox ID="TextBox11" runat="server" Width="100px"></asp:TextBox>
                                            <asp:Button ID="Button54" runat="server" Text="<" Width="17px" OnClick="Button54_Click" CausesValidation="False" />
                                            <asp:Button ID="Button55" runat="server" Text=">" Width="17px" OnClick="Button55_Click" CausesValidation="False" />
                                            <asp:DropDownList ID="DropDownList13" runat="server" Width="237px">
                                            </asp:DropDownList>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                ControlToValidate="TextBox11" ErrorMessage="*" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="TextBox11"
                                                ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 3px; width: 121px; padding-top: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Correo(s) Electr<span>ó</span>nicos(s):</strong></span></td>
                                        <td style="padding-bottom: 3px; width: 435px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox21" runat="server" Width="100px"></asp:TextBox>
                                            <asp:Button ID="Button56" runat="server" Text="<" Width="17px" OnClick="Button56_Click" CausesValidation="False" />
                                            <asp:Button ID="Button57" runat="server" Text=">" Width="17px" OnClick="Button57_Click" CausesValidation="False" />
                                            <asp:DropDownList ID="DropDownList14" runat="server" Width="237px">
                                            </asp:DropDownList>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                ControlToValidate="TextBox21" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                Width="9px"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox21"
                                                ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px">
                                        </td>
                                        <td style="width: 435px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 121px; height: 51px;">
                                        </td>
                                        <td style="width: 435px; height: 51px;">
                                            <table style="width: 175px">
                                                <tr>
                                                    <td style="width: 50px; height: 21px">
                                                        <asp:Button ID="Button12" runat="server" Text="Aceptar" Width="76px" OnClick="Button12_Click1" CausesValidation="False" /></td>
                                                    <td style="width: 7px; height: 21px">
                                                    </td>
                                                    <td style="width: 4px; height: 21px">
                                                        <asp:Button ID="Button13" runat="server" Text="Cancelar" OnClick="Button13_Click" Width="76px" CausesValidation="False" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View7" runat="server" OnActivate="View7_Activate">
                    <table width="100%" style="height: 1px">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Gestión de Información de Procesos"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <table style="width: 302px; height: 1px;">
                                    <tr>
                                        <td colspan="3" style="text-align: justify;">
                                            <asp:ListBox ID="ListBox2" runat="server" Width="600px" OnSelectedIndexChanged="ListBox2_SelectedIndexChanged" Height="365px" AutoPostBack="True" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            <asp:Button ID="Button18" runat="server" Font-Names="Calibri" Font-Size="11pt" OnClick="Button18_Click" Text="Insertar" Width="70px" />
                                            <asp:Button ID="Button19" runat="server" Enabled="False" Font-Names="Calibri" Font-Size="11pt" OnClick="Button19_Click" Text="Modificar" Width="70px" />
                                            <asp:Button ID="Button20" runat="server" Enabled="False" Font-Names="Calibri" Font-Size="11pt" OnClick="Button20_Click" Text=" Eliminar" Width="70px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View8" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana; background-color: darkslategray; color: #ffffcc;">Insertar Información
                                    de Procesos</span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left" valign="top">
                                <table style="width: 600px; height: 350px;">
                                    <tr>
                                        <td style="width: 7997px; height: 21px; text-align: left;" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Tema del proceso:</strong></span></td>
                                        <td style="width: 200px; height: 21px">
                                            <asp:TextBox ID="TextBox14" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox14"
                                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7997px; height: 21px" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>
                                            Descripción:</strong></span></td>
                                        <td style="width: 200px; height: 21px">
                                            <asp:TextBox ID="TextBox15" runat="server" Height="238px" TextMode="MultiLine" Width="443px" Font-Names="Arial"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox15"
                                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7997px; height: 21px" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Palabra(s) clave(s):</strong></span></td>
                                        <td style="width: 200px; height: 21px">
                                            <asp:TextBox ID="TextBox16" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox16"
                                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7997px; height: 21px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Lista de temas existente:</strong></span></td>
                                        <td style="width: 200px; height: 21px">
                                            <asp:DropDownList ID="DropDownList1" runat="server" Width="365px">
                                                <asp:ListItem>Seleccione un Tema Padre</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7997px; height: 21px">
                                        </td>
                                        <td style="width: 200px; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 7997px; height: 21px">
                                        </td>
                                        <td style="width: 200px; height: 21px">
                                            <table style="width: 167px">
                                                <tr>
                                                    <td style="width: 50px; height: 21px">
                                                        <asp:Button ID="Button21" runat="server" Text="Aceptar" Width="76px" OnClick="Button21_Click" CausesValidation="False" /></td>
                                                    <td style="width: 7px; height: 21px">
                                                    </td>
                                                    <td style="width: 4px; height: 21px">
                                                        <asp:Button ID="Button22" runat="server" Text="Cancelar" OnClick="Button22_Click" Width="76px" CausesValidation="False" /></td>
                                                </tr>
                                            </table>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View9" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 594px; height: 22px; background-color: darkslategray;">
                                <span style="font-family: Verdana"><strong style="color: #ffffcc">Modificar</strong></span><span style="font-family: Verdana"><strong style="color: #ffffcc">
                                    Información de Procesos</strong></span></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 594px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                                <table style="width: 600px; height: 350px;">
                                    <tr>
                                        <td style="width: 606px; height: 21px" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Tema del proceso:</strong></span></td>
                                        <td style="width: 182px; height: 21px">
                                            <asp:Label ID="Label5" runat="server" Width="365px" Height="18px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 606px; height: 21px" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Texto:</strong></span></td>
                                        <td style="width: 182px; height: 21px">
                                            <asp:TextBox ID="TextBox19" runat="server" Height="238px" TextMode="MultiLine" Width="443px" Font-Names="Arial"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBox19"
                                                ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 606px; height: 21px" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Palabra(s) clave(s):</strong></span></td>
                                        <td style="width: 182px; height: 21px">
                                            <asp:TextBox ID="TextBox20" runat="server" Width="365px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBox20"
                                                ErrorMessage="RequiredFieldValidator" Width="7px">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 606px; height: 21px" valign="top">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Lista de temas padres existente:</strong></span></td>
                                        <td style="width: 182px; height: 21px">
                                            <asp:DropDownList ID="DropDownList2" runat="server" Width="365px">
                                                <asp:ListItem>Seleccione un Tema Padre</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 606px; height: 21px">
                                        </td>
                                        <td style="width: 182px; height: 21px">
                                            &nbsp;<asp:HiddenField ID="HiddenField1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 606px; height: 21px">
                                        </td>
                                        <td style="width: 182px; height: 21px">
                                            <table style="width: 167px">
                                                <tr>
                                                    <td style="width: 50px; height: 21px">
                                                        <asp:Button ID="Button25" runat="server" Text="Aceptar" Width="76px" OnClick="Button25_Click1" CausesValidation="False" /></td>
                                                    <td style="width: 7px; height: 21px">
                                                    </td>
                                                    <td style="width: 4px; height: 21px">
                                                        <asp:Button ID="Button26" runat="server" Text="Cancelar" OnClick="Button26_Click1" Width="76px" CausesValidation="False" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View10" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana; color: #ffffcc;">Buscar en
                                    <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?></span></strong><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?>
                                <?xml namespace="" prefix="st1" ?>
                                <st1:personname productid="la Agenda Electr?nica" w:st="on"><STRONG><SPAN style="COLOR: #ffffcc; FONT-FAMILY: Verdana">la Agenda Electrónica</SPAN></STRONG></st1:personname>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                                <table style="width: 565px">
                                    <tr>
                                        <td style="width: 202px; height: 26px; padding-bottom: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Nombre de la entidad:</strong></span></td>
                                        <td style="width: 300px; height: 26px; padding-bottom: 3px;">
                                            <asp:TextBox ID="TextBox22" runat="server" Width="354px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Dirección:</strong></span></td>
                                        <td style="width: 300px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox23" runat="server" Width="354px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 21px; padding-bottom: 3px; padding-top: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Fax:</strong></span></td>
                                        <td style="width: 300px; height: 21px; padding-bottom: 3px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox25" runat="server" Width="354px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 21px; padding-bottom: 3px; padding-top: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Código Anterior de la Sucursal:</strong></span></td>
                                        <td style="width: 300px; height: 21px; padding-bottom: 3px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox27" runat="server" Width="354px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                                ControlToValidate="TextBox27" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                                ValidationExpression="([0-9])*" Width="1px">*</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Código Actual de la Sucursal:</strong></span></td>
                                        <td style="width: 300px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox28" runat="server" Width="354px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                ControlToValidate="TextBox28" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                                ValidationExpression="([0-9])*" Width="1px">*</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Teléfono:</strong></span></td>
                                        <td style="width: 300px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox24" runat="server" Width="354px" AutoPostBack="True" CausesValidation="True"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                ControlToValidate="TextBox24" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                                ValidationExpression="\d{4}|\d{3}-\d{4}" Width="1px">*</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Sitio Web Relacionado:</strong></span></td>
                                        <td style="width: 300px; height: 26px; padding-bottom: 3px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox26" runat="server" Width="354px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                ControlToValidate="TextBox26" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                                ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" Width="1px">*</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 21px; padding-top: 3px;">
                                            <span style="font-family: Verdana"><span style="font-size: 10pt"><strong>Correo Electr<span>ónicos:</span></strong></span></span></td>
                                        <td style="width: 300px; height: 21px; padding-top: 3px;">
                                            <asp:TextBox ID="TextBox33" runat="server" Width="353px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                                ControlToValidate="TextBox33" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="1px">*</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 21px">
                                            <span style="font-size: 10pt; font-family: Verdana"></span></td>
                                        <td style="width: 300px; height: 21px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 202px; height: 21px">
                                        </td>
                                        <td style="width: 300px; height: 21px">
                                            <table style="width: 88px">
                                                <tr>
                                                    <td style="width: 50px; height: 21px">
                                                        <asp:Button ID="Button31" runat="server" Text="Aceptar" OnClick="Button31_Click" Width="76px" /></td>
                                                    <td style="width: 7px; height: 21px">
                                                    </td>
                                                    <td style="width: 4px; height: 21px">
                                                        <asp:Button ID="Button59" runat="server" OnClick="Button59_Click" Text="Cancelar" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View11" runat="server" OnActivate="View11_Activate">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Buscar en la Agenda Electrónica "></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <table style="width: 320px">
                                    <tr>
                                        <td colspan="3" style="text-align: justify">
                                            <asp:ListBox ID="ListBox3" runat="server" Width="600px" Height="327px" AutoPostBack="True" OnSelectedIndexChanged="ListBox3_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: center">
                                            <asp:Button ID="Button32" runat="server" Enabled="False" OnClick="Button32_Click" Text="Aceptar" Width="76px" />
                                            &nbsp;
                                            <asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Cancelar" Width="76px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View12" runat="server" OnActivate="View12_Activate">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana; color: #ffffcc;">Buscar en
                                    <?xml namespace="" ns="urn:schemas-microsoft-com:office:smarttags" prefix="st1" ?><?xml namespace="" prefix="st1" ?></span></strong><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?><?xml namespace="" prefix="st1" ?>
                                <?xml namespace="" prefix="st1" ?>
                                <st1:personname productid="la Agenda Electr?nica" w:st="on"><STRONG><SPAN style="COLOR: #ffffcc; FONT-FAMILY: Verdana">la Agenda Electrónica</SPAN></STRONG></st1:personname>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                                <table style="width: 565px">
                                    <tr>
                                        <td style="width: 4032px; height: 26px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Nombre de<span style="font-size: 14pt">
                                                <span style="font-size: 10pt">la entidad:</span></span></strong></span></td>
                                        <td style="width: 1277px; height: 26px">
                                            <asp:Label ID="Label24" runat="server" Text="Suc. Monserrate" Width="280px"></asp:Label></td>
                                        <td style="width: 58px; height: 26px">
                                            <asp:CheckBox ID="CheckBox1" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" /></td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td style="width: 4032px; height: 21px">
                                            <strong>Dirección:</strong></td>
                                        <td style="width: 1277px; height: 21px">
                                            <asp:Label ID="Label25" runat="server" Text="Monserrate y San José." Width="280px"></asp:Label></td>
                                        <td style="width: 58px; height: 21px">
                                            <asp:CheckBox ID="CheckBox2" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" /></td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td style="width: 4032px; height: 26px">
                                            <strong>Fax:</strong></td>
                                        <td style="width: 1277px; height: 26px">
                                            <asp:Label ID="Label27" runat="server" Text="8638999" Width="280px"></asp:Label></td>
                                        <td style="width: 58px; height: 26px">
                                            <asp:CheckBox ID="CheckBox3" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" /></td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td style="width: 4032px; height: 21px">
                                            <strong>Código Anterior de la Sucursal:</strong></td>
                                        <td style="width: 1277px; height: 21px">
                                            <asp:Label ID="Label29" runat="server" Text="9075" Width="281px" Height="1px"></asp:Label></td>
                                        <td style="width: 58px; height: 21px">
                                            <asp:CheckBox ID="CheckBox4" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox4_CheckedChanged" /></td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td style="width: 4032px; height: 21px">
                                            <strong>Código Actual de la Sucursal:</strong></td>
                                        <td style="width: 1277px; height: 21px">
                                            <asp:Label ID="Label30" runat="server" Text="309" Width="280px"></asp:Label></td>
                                        <td style="width: 58px; height: 21px">
                                            <asp:CheckBox ID="CheckBox5" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox5_CheckedChanged" /></td>
                                    </tr>
                                    <tr style="font-size: 10pt; font-family: Verdana">
                                        <td style="width: 4032px; height: 21px">
                                            <strong>Teléfono(s):</strong></td>
                                        <td style="width: 1277px; height: 21px">
                                            <asp:Label ID="Label26" runat="server" Text="8638999, 8633953, 8633956, 8633933" Width="280px"></asp:Label></td>
                                        <td style="width: 58px; height: 21px">
                                            <asp:CheckBox ID="CheckBox6" runat="server" Height="16px" Text=" " Width="1px" AutoPostBack="True" OnCheckedChanged="CheckBox6_CheckedChanged" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4032px; height: 21px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Sitio(s) Web relacionado(s):</strong></span></td>
                                        <td style="width: 1277px; height: 21px">
                                            <asp:Label ID="Label28" runat="server" Text="NO" Width="279px"></asp:Label></td>
                                        <td style="width: 58px; height: 21px">
                                            <asp:CheckBox ID="CheckBox7" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox7_CheckedChanged" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4032px; height: 21px">
                                            <span style="font-size: 10pt; font-family: Verdana"><strong>Correo(s) Electrónico(s):</strong></span></td>
                                        <td style="width: 1277px; height: 21px">
                                            <asp:Label ID="Label1" runat="server" Text="dirsuc9075@banco-metropolitano.cu" Width="280px"></asp:Label></td>
                                        <td style="width: 58px; height: 21px">
                                            <asp:CheckBox ID="CheckBox8" runat="server" Text=" " AutoPostBack="True" OnCheckedChanged="CheckBox8_CheckedChanged" /></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4032px; height: 21px">
                                        </td>
                                        <td style="width: 1277px; height: 21px">
                                        </td>
                                        <td style="width: 58px; height: 21px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 4032px; height: 21px">
                                        </td>
                                        <td style="width: 1277px; height: 21px">
                                            <table style="width: 107px">
                                                <tr>
                                                    <td style="width: 24px; height: 21px">
                                                        <asp:Button ID="Button33" runat="server" Text="Aceptar" OnClick="Button33_Click" Width="76px" Enabled="False" /></td>
                                                    <td style="width: 7px; height: 21px">
                                                    </td>
                                                    <td style="width: 10px; height: 21px">
                                                        <asp:Button ID="Button58" runat="server" OnClick="Button58_Click" Text="Cancelar" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 58px; height: 21px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View13" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;" valign="top">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label36" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Buscar Información de Procesos"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left" valign="top">
                                <asp:Button ID="Button34" runat="server" Text="Buscar por Tema " OnClick="Button34_Click" Width="200px" Font-Names="Calibri" Font-Size="11pt" />
                                <br />
                                <br />
                                <asp:Button ID="Button35" runat="server" Text="Buscar por Palabras Claves" OnClick="Button35_Click" Font-Names="Calibri" Font-Size="11pt" Width="200px" /></td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View14" runat="server" OnActivate="View14_Activate">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label6" runat="server" Text="Buscar Información de Procesos por Temas"
                                        Width="387px" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <br />
                                <table>
                                    <tr>
                                        <td style="width: 100px; text-align: justify;">
                                            <asp:ListBox ID="ListBox4" runat="server" Width="599px" Height="376px" AutoPostBack="True" OnSelectedIndexChanged="ListBox4_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center; height: 29px;">
                                                        <asp:Button ID="Button36" runat="server" Text="Aceptar" OnClick="Button36_Click" Width="70px" Enabled="False" Font-Names="Calibri" Font-Size="11pt" />&nbsp; 
                                                        <asp:Button ID="Button14" runat="server" Text="Cancelar" OnClick="Button14_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View15" runat="server">
                    <table width="100%" style="height: 500px">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label35" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Información de Procesos"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 5px; border-top: #d8d787 2px solid;
                                padding-left: 5px; padding-bottom: 2px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 2px; border-bottom: #d8d787 2px solid; height: 12px; text-align: center" valign="top">
                                <br />
                                <table style="width: 600px">
                                    <tr>
                                        <td style="text-align: center">
                                            <strong><span style="font-size: 14pt; color: teal; font-family: Calibri">Tema del Proceso</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label31" runat="server" Text="Label" Width="365px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Texto</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox30" runat="server" Height="150px" ReadOnly="True" TextMode="MultiLine"
                                                Width="589px" Font-Names="Calibri" Font-Size="12pt"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Palabras Claves</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label32" runat="server" Text="Label" Width="365px" Height="1px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Tema Padre</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Label" Width="365px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Subtemas</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="ListBox5" runat="server" Width="588px" Height="130px" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                                        <asp:Button ID="Button37" runat="server" Text="Aceptar" OnClick="Button37_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" />
                                            &nbsp; &nbsp; 
                                                        <asp:Button ID="Button38" runat="server" Text="Cancelar" OnClick="Button38_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View16" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label23" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Buscar por Palabras Claves"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <asp:TextBox ID="TextBox29" runat="server" Width="405px" AutoPostBack="True" Font-Names="Calibri" Font-Size="12pt"></asp:TextBox>
                                <asp:Button ID="Button39" runat="server" Text="Aceptar" OnClick="Button39_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" /><br />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View17" runat="server" OnActivate="View17_Activate">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label22" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Buscar por Palabras Claves"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table>
                                    <tr>
                                        <td style="text-align: justify;">
                                            <asp:ListBox ID="ListBox6" runat="server" Width="600px" Height="327px" OnSelectedIndexChanged="ListBox6_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                                        <asp:Button ID="Button40" runat="server" Text="Aceptar" OnClick="Button40_Click" Width="70px" Enabled="False" Font-Names="Calibri" Font-Size="11pt" />&nbsp; 
                                                        <asp:Button ID="Button41" runat="server" Text="Cancelar" OnClick="Button41_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View18" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray;">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Búsqueda de Información de Procesos por Palabras Claves"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 2px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table style="width: 600px">
                                    <tr>
                                        <td style="text-align: center">
                                            <strong><span style="font-size: 14pt; color: teal; font-family: Calibri">Tema del Proceso</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label33" runat="server" Text="Label" Width="365px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Texto</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox31" runat="server" Height="150px" ReadOnly="True" TextMode="MultiLine"
                                                Width="587px" Font-Names="Calibri" Font-Size="12pt"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Palabras Claves</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" Text="Label" Width="365px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Tema Padre</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Label" Width="365px" Font-Names="Calibri" Font-Size="12pt"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Subtemas</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="ListBox7" runat="server" Width="588px" Height="130px" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                                        <asp:Button ID="Button42" runat="server" Text="Aceptar" OnClick="Button42_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" />&nbsp; 
                                                        <asp:Button ID="Button43" runat="server" Text=" Cerrar" OnClick="Button43_Click" Width="70px" Font-Names="Calibri" Font-Size="11pt" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View19" runat="server"><table width="100%">
                    <tr>
                        <td style="width: 595px; height: 22px; background-color: darkslategray;">
                            <strong><span style="font-family: Verdana">
                                <asp:Label ID="Label20" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                    Text="Reportes"></asp:Label></span></strong></td>
                    </tr>
                    <tr>
                        <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: left">
                            <span style="font-size: 10pt; font-family: Verdana">
                                <asp:Button ID="Button28" runat="server" OnClick="Button28_Click1" Text="Trabajo de los Operadores" Font-Names="Calibri" Font-Size="11pt" Width="200px" /><br />
                                <br />
                                <asp:Button ID="Button29" runat="server" OnClick="Button29_Click" Text="Informes de las Consultas" Font-Names="Calibri" Font-Size="11pt" Width="200px" /></span></td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View20" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Reportes Trabajo Operadores"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 2px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table>
                                    <tr>
                                        <td colspan="2" style="text-align: center; height: 25px;">
                                            <strong><span style="font-size: 14pt; color: teal; font-family: Calibri">Rango para
                                                el Reporte</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 25px; text-align: center">
                                            <asp:Panel ID="Panel25" runat="server" Height="25px">
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <span style="font-size: 14pt; font-family: Calibri"><strong>DESDE</strong></span></td>
                                        <td style="text-align: center">
                                            <span style="font-size: 14pt; font-family: Calibri"><strong>HASTA</strong></span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" OnInit="Calendar1_Init" OnSelectionChanged="Calendar1_SelectionChanged" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" ShowGridLines="True" Width="180px" OnDayRender="Calendar1_DayRender">
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
                                            <asp:Calendar ID="Calendar2" runat="server" Width="180px" OnInit="Calendar2_Init" OnSelectionChanged="Calendar2_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" ShowGridLines="True" OnDayRender="Calendar2_DayRender">
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
                                        <td colspan="2" style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Tipo del Reporte</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                                <asp:DropDownList ID="DropDownList4" runat="server" Width="260px" Font-Names="Calibri" Font-Size="11pt">
                                                    <asp:ListItem Value="P">Personal</asp:ListItem>
                                                    <asp:ListItem Value="G">General</asp:ListItem>
                                                </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Criterio</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DropDownList ID="DropDownList3" runat="server" Width="260px" Font-Names="Calibri" Font-Size="11pt">
                                                <asp:ListItem Value="D">Detallado</asp:ListItem>
                                                <asp:ListItem Value="R">Resumen</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                                        <asp:Button ID="Button46" runat="server" OnClick="Button46_Click" Text="Aceptar"
                                                            Width="70px" Font-Names="Calibri" Font-Size="11pt" />&nbsp; 
                                                        <asp:Button ID="Button30" runat="server" OnClick="Button30_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View21" runat="server" OnActivate="View21_Activate" OnLoad="View21_Load">
                    <table width="100%">
                        <tr>
                            <td style="width: 505px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Reportes Trabajo Operadores"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 505px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table>
                                    <tr>
                                        <td style="text-align: justify;">
                                            <asp:ListBox ID="ListBox8" runat="server" Height="327px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ListBox8_SelectedIndexChanged" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Tipos de Información</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:DropDownList ID="DropDownList5" runat="server" Width="243px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" Font-Names="Calibri" Font-Size="11pt">
                                                <asp:ListItem Value="-1">&lt;&lt; Seleccione un Tipo de Reporte &gt;&gt;</asp:ListItem>
                                                <asp:ListItem Value="AE">Agenda Electr&#243;nica</asp:ListItem>
                                                <asp:ListItem Value="IP">Informaci&#243;n de Procesos</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                                        <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Aceptar"
                                                            Width="70px" Enabled="False" Font-Names="Calibri" Font-Size="11pt" />
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                        <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View22" runat="server" OnActivate="View22_Activate">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <span><span style="background-color: #d8d787"><strong><span style="font-family: Verdana">
                                    <span style="font-family: Times New Roman"><span style="font-family: Verdana">
                                        <asp:Label ID="Label17" runat="server" BackColor="DarkSlateGray" ForeColor="#FFFFCC"
                                            Text="Reporte Personal Resumen"></asp:Label></span></span></span></strong></span></span></td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table>
                                    <tr>
                                        <td style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri; color: teal;">Operador(a)</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: justify;">
                                            <asp:ListBox ID="ListBox10" runat="server" Height="327px" Width="312px" Font-Names="Calibri" Font-Size="12pt"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                                        <asp:Button ID="Button23" runat="server" OnClick="Button23_Click" Text="Aceptar"
                                                            Width="70px" Font-Names="Calibri" Font-Size="11pt" />&nbsp; 
                                            <asp:Button ID="Button24" runat="server" OnClick="Button24_Click" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View23" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <span><span style="background-color: #d8d787"><strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label16" runat="server" BackColor="DarkSlateGray" Font-Names="Calibri"
                                        Font-Size="14pt" ForeColor="#FFFFCC" Text="Reporte. General Detallado"></asp:Label></span></strong></span></span></td>
                        </tr>
                        <tr style="font-family: Times New Roman">
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 14px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table>
                                    <tr>
                                        <td style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri; color: teal;">Tipos de Información</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:DropDownList ID="DropDownList7" runat="server" Width="200px">
                                                <asp:ListItem Value="AE">Agenda Electr&#243;nica</asp:ListItem>
                                                <asp:ListItem Value="IP">Informaci&#243;n de Procesos</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                                        <asp:Button ID="Button16" runat="server" OnClick="Button16_Click" Text="Aceptar"
                                                            Width="76px" />&nbsp; 
                                                        <asp:Button ID="Button17" runat="server" OnClick="Button17_Click" Text="Cancelar" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp;<asp:View ID="View24" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 595px; height: 22px; background-color: darkslategray">
                                <strong><span style="font-family: Verdana">
                                    <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="14pt" ForeColor="#FFFFCC"
                                        Text="Informe de las Consultas"></asp:Label></span></strong></td>
                        </tr>
                        <tr>
                            <td style="border-right: #d8d787 2px solid; padding-right: 17px; border-top: #d8d787 2px solid;
                                padding-left: 17px; padding-bottom: 2px; border-left: #d8d787 2px solid; width: 595px;
                                padding-top: 14px; border-bottom: #d8d787 2px solid; height: 22px; text-align: center">
                                <br />
                                <table>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <strong><span style="font-size: 14pt; color: teal; font-family: Calibri">Rango para
                                                el Reporte</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:Panel ID="Panel26" runat="server" Height="25px">
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">DESDE</span></strong></td>
                                        <td style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">HASTA</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Calendar ID="Calendar3" runat="server" OnInit="Calendar3_Init" OnSelectionChanged="Calendar3_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" ShowGridLines="True" Width="180px" OnDayRender="Calendar3_DayRender">
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
                                            <asp:Calendar ID="Calendar4" runat="server" OnInit="Calendar3_Init" Width="180px" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="150px" ShowGridLines="True" OnDayRender="Calendar4_DayRender">
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
                                        <td colspan="2" style="text-align: center">
                                            <span style="font-size: 14pt; font-family: Calibri;"><strong>
    Tipo de Consulta</strong></span></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DropDownList ID="DropDownList6" runat="server" Width="320px" Font-Names="Calibri" Font-Size="11pt">
                                                <asp:ListItem Value="AE">Consultas a Agenda Electr&#243;nica</asp:ListItem>
                                                <asp:ListItem Value="IP">Consultas a Informaci&#243;n de Procesos</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <strong><span style="font-size: 14pt; font-family: Calibri">Orden de Aparición</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DropDownList ID="DropDownList8" runat="server" Width="320px" Font-Names="Calibri" Font-Size="11pt">
                                                <asp:ListItem Value="A">Ascendente</asp:ListItem>
                                                <asp:ListItem Value="D">Descendente</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                                        <asp:Button ID="Button27" runat="server" OnClick="Button27_Click" Text="Aceptar"
                                                            Width="70px" Font-Names="Calibri" Font-Size="11pt" />&nbsp; 
                                                        <asp:Button ID="Button44" runat="server" OnClick="Button44_Click1" Text="Cancelar" Font-Names="Calibri" Font-Size="11pt" Width="70px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; 
                <asp:View ID="View25" runat="server" OnActivate="View25_Activate">
                    <table style="width: 600px; border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid; border-bottom: #d8d787 2px solid;">
                        <tr>
                            <td colspan="2" style="background-color: darkslategray; text-align: center">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="#FFFFCC"
                                    Text="Sucursales del Banco que trabajan los Sábados"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left; height: 24px;">
                                <strong><span style="font-family: Calibri">Municipio: </span></strong>
                                <asp:DropDownList ID="DropDownList15" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
                                    DataTextField="Municipio" DataValueField="Municipio" Width="200px">
                                </asp:DropDownList>&nbsp;
                                <asp:Label ID="Label8" runat="server" ForeColor="#FF8000" Visible="False">0</asp:Label>
                                <strong><span style="font-family: Calibri">Horario &nbsp; Desde: 9:00 AM &nbsp;&nbsp;
                                    Hasta: 2:00 PM</span></strong></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="height: 24px; background-color: darkslategray">
                                <strong><span style="color: #ffffcc; font-family: Calibri">Sucursales que trabajan el 
                                    <span style="color: lime">1er</span>, <span style="color: lime">3er</span> y/o <span
                                        style="color: lime">5to</span> Sábado del mes en curso.</span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 67px" valign="middle">
                                <asp:Calendar ID="Calendar5" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                    BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="150px" OnDayRender="Calendar5_DayRender" ShowGridLines="True"
                                    ShowNextPrevMonth="False" Width="180px" FirstDayOfWeek="Sunday">
                                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                    <SelectorStyle BackColor="#FFCC66" />
                                    <TodayDayStyle BackColor="White" ForeColor="Black" BorderStyle="Solid" BorderWidth="2px" />
                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                    <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                </asp:Calendar>
                            </td>
                            <td style="width: 100px" valign="top">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal"
                                    DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" Height="150px"
                                    Width="412px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="NoSucursal" ReadOnly="True" SortExpression="NoSucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Ubicada en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="background-color: darkslategray">
                                <strong><span style="font-family: Calibri"><span style="color: #ffffcc"> Sucursales que
                                    trabajan el <span style="color: lime">2do</span> y <span style="color: lime">
                                        4to</span>
                                    Sábado del mes en curso.</span></span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 67px" valign="middle">
                                <asp:Calendar ID="Calendar6" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                    BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="150px" OnDayRender="Calendar6_DayRender" ShowGridLines="True"
                                    ShowNextPrevMonth="False" Width="180px" SelectionMode="None">
                                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                    <SelectorStyle BackColor="#FFCC66" />
                                    <TodayDayStyle BackColor="White" ForeColor="Black" BorderStyle="Solid" BorderWidth="2px" />
                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                    <TitleStyle BackColor="#A2A764" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                </asp:Calendar>
                            </td>
                            <td style="width: 100px" valign="top">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal"
                                    DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="None" Height="150px"
                                    Width="412px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="NoSucursal" ReadOnly="True" SortExpression="NoSucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Ubicada en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 21px; background-color: darkslategray">
                                <strong><span style="color: #ffffcc; font-family: Calibri">No trabajan nunca los Sábados.</span></strong></td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal"
                                    DataSourceID="SqlDataSource4" ForeColor="Black" GridLines="None" Width="600px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="NoSucursal" ReadOnly="True" SortExpression="NoSucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Ubicada en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="background-color: darkslategray; height: 21px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 67px">
                                <asp:Panel ID="Panel1" runat="server" Height="23px">
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica FROM TLB_Sucursal WHERE (Municipio = @municipio) AND (Grupo = @grupo) AND (Trabaja_Sabado = 'S')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList15" Name="municipio" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="Label8" Name="grupo" PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica FROM TLB_Sucursal WHERE (Municipio = @municipio) AND (Grupo <> @grupo) AND (Trabaja_Sabado = 'S')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList15" Name="municipio" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="Label8" Name="grupo" PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT DISTINCT Municipio FROM TLB_Sucursal ORDER BY Municipio DESC">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica FROM TLB_Sucursal WHERE (Municipio = @municipio) AND (Trabaja_Sabado = 'N')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList15" Name="municipio" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT Pais, Sigla, Moneda, Compra, Venta FROM TLB_Tipos_de_Cambio">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT DISTINCT Municipio FROM TLB_Sucursal ORDER BY Municipio DESC">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica FROM TLB_Sucursal WHERE (Municipio = @municipio) AND (Horario_Extendido = 'L')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList16" Name="municipio" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica FROM TLB_Sucursal WHERE (Municipio = @municipio) AND (Horario_Extendido = 'V')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList16" Name="municipio" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT DISTINCT Provincia FROM TLB_Ubicacion_Cajeros_Automaticos">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT distinct Municipio FROM TLB_Ubicacion_Cajeros_Automaticos WHERE (Provincia = @provincia)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList17" Name="provincia" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT ID_Cajero, Ubicacion_Fisica, Pertenece_a, Moneda1, Valor1, Moneda2, Valor2, Moneda3, Valor3, Moneda4, Valor4 FROM TLB_Ubicacion_Cajeros_Automaticos WHERE (Municipio = @municipio) AND (Provincia = @provincia) ORDER BY Valor1, Valor2, Valor3, Valor4">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList18" Name="municipio" PropertyName="SelectedValue" />
                                            <asp:ControlParameter ControlID="DropDownList17" Name="provincia" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT distinct Area FROM TLB_Operaciones_Cliente_Sucursales"></asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource13" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT Descripcion FROM TLB_Operaciones_Cliente_Sucursales WHERE (Area = @area)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="RadioButtonList1" Name="area" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource14" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT DISTINCT Municipio FROM TLB_Sucursal ORDER BY Municipio DESC">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource15" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica, Telefonos, NoSucursal_Antiguo, Nombre_Director_Sucursal FROM TLB_Sucursal WHERE (Municipio = @municipio)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList19" Name="municipio" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource16" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT DISTINCT Municipio FROM TLB_Sucursal ORDER BY Municipio DESC">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource17" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica FROM TLB_Sucursal WHERE (Vende_Sellos_Timbre = 'S') AND (Municipio = @municipio)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList20" Name="municipio" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource18" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT DISTINCT CONVERT (varchar(10), Fecha_Vigencia, 103) AS Fecha_Vigencia FROM TLB_Tipos_de_Cambio WHERE (Fecha_Vigencia IS NOT NULL)">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource19" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT NoSucursal, Nombre, Ubicacion_Fisica FROM TLB_Sucursal WHERE (Municipio = @municipio) AND (Horario_Extendido = 'S')">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList16" Name="municipio" PropertyName="SelectedValue" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </asp:Panel>
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View26" runat="server">
                    <table style="width: 600px">
                        <tr>
                            <td style="background-color: darkslategray;" align="center">
                                <span class="Apple-style-span" style="font-weight: normal; word-spacing: 0px; text-transform: none;
                                    text-indent: 0px; line-height: normal; font-style: normal; white-space: normal;
                                    letter-spacing: normal; border-collapse: separate; font-variant: normal; orphans: 2;
                                    widows: 2; webkit-border-horizontal-spacing: 0px; webkit-border-vertical-spacing: 0px;
                                    webkit-text-decorations-in-effect: none; webkit-text-size-adjust: auto; webkit-text-stroke-width: 0px">
                                    <span class="Apple-style-span" style="font-weight: bold; color: #ffffff; font-family: Calibri; text-align: center;">
                                        <asp:Panel ID="Panel6" runat="server" Height="20px" Width="600px" ForeColor="#FFFFCC">
                                            TIPO DE CAMBIO BANCO</asp:Panel>
                                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="Transparent" CellPadding="2" DataSourceID="SqlDataSource18"
                                            Font-Bold="True" Font-Names="Arial" ForeColor="Lime" GridLines="None" Height="23px" Width="254px">
                                            <FooterStyle BackColor="Tan" />
                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                            <Fields>
                                                <asp:BoundField DataField="Fecha_Vigencia" HeaderText="VIGENTE HASTA:" SortExpression="Fecha_Vigencia">
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                            </Fields>
                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                            <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                        </asp:DetailsView>
                                    </span></span></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <span class="Apple-style-span" style="font-weight: normal; word-spacing: 0px; text-transform: none;
                                    text-indent: 0px; line-height: normal; font-style: normal; white-space: normal;
                                    letter-spacing: normal; border-collapse: separate; font-variant: normal; orphans: 2;
                                    widows: 2; webkit-border-horizontal-spacing: 0px; webkit-border-vertical-spacing: 0px;
                                    webkit-text-decorations-in-effect: none; webkit-text-size-adjust: auto; webkit-text-stroke-width: 0px; font-family: Calibri;">
                                    <asp:Panel ID="Panel3" runat="server" Height="20px" Width="600px">
                                        <strong>
                                        MONEDAS LIBREMENTE CONVERTIBLES (MLC) vs PESOS CUBANOS CONVERTIBLES (CUC)</strong></asp:Panel>
                                </span></td>
                        </tr>
                        <tr>
                            <td style="width: 600px; background-color: darkslategray; height: 18px;">
                                <asp:Panel ID="Panel5" runat="server" Height="18px" Width="600px">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 161px;">
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource5"
                                    ForeColor="Black" GridLines="None" Width="600px" ShowFooter="True" Font-Names="Calibri" Font-Size="12pt">
                                    <Columns>
                                        <asp:BoundField DataField="Pais" HeaderText="Pais" SortExpression="Pais">
                                            <HeaderStyle Font-Names="Calibri" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Sigla" HeaderText="Sigla" SortExpression="Sigla">
                                            <HeaderStyle Font-Names="Calibri" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" SortExpression="Moneda">
                                            <HeaderStyle Font-Names="Calibri" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Compra" HeaderText="Compra" SortExpression="Compra">
                                            <HeaderStyle Font-Names="Calibri" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Venta" HeaderText="Venta" SortExpression="Venta">
                                            <HeaderStyle Font-Names="Calibri" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 17px">
                                <span class="Apple-style-span" style="word-spacing: 0px; font: 16px 'times new roman';
                                    text-transform: none; color: rgb(0,0,0); text-indent: 0px; white-space: normal;
                                    letter-spacing: normal; border-collapse: separate; orphans: 2; widows: 2; webkit-border-horizontal-spacing: 0px;
                                    webkit-border-vertical-spacing: 0px; webkit-text-decorations-in-effect: none;
                                    webkit-text-size-adjust: auto; webkit-text-stroke-width: 0px">
                                    <asp:Panel ID="Panel2" runat="server" Height="24px" Width="600px">
                                        <strong><span style="font-size: 11pt"><span style="font-family: Calibri"><span style="font-size: 12pt">
                                            ( * ) CUC por Euro y Libra Esterlina</span><span style="color: #ff6666"><span style="font-size: 12pt">
                                            </span>&nbsp;</span></span></span></strong> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <strong><span style="font-size: 12pt; color: #000000;
                                            font-family: Calibri">Al USD se le aplica un 10% de gravamen(Venta)</span></strong></asp:Panel>
                                </span></td>
                        </tr>
                        <tr>
                            <td style="background-color: darkslategray; text-align: center;" align="center">
                                &nbsp;<asp:Label ID="Label38" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="Lime"
                                    Text="CONVERTIDOR DE DIVISAS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <span style="font-family: Calibri"><strong>▼ El Cliente desea <span style="color: teal">
                                    Comprar</span> o <span style="color: teal">Vender</span> <span style="font-family: Times New Roman">
                                    ▼</span>&nbsp;<br />
                                </strong></span><asp:DropDownList ID="DropDownList21" runat="server" DataSourceID="SqlDataSourceTC" DataTextField="Moneda" DataValueField="Sigla" AutoPostBack="True" OnSelectedIndexChanged="DropDownList21_SelectedIndexChanged" OnDataBound="DropDownList21_DataBound">
                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceTC" runat="server" ConnectionString="<%$ ConnectionStrings:TeleBancaConnectionString %>"
                                        SelectCommand="SELECT Sigla, Moneda FROM TLB_Tipos_de_Cambio WHERE (Sigla <> 'CUP') ORDER BY COD_IVR">
                                    </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="Label39" runat="server" Font-Names="Calibri" Text="Cantidad: $"></asp:Label>
                                <asp:TextBox ID="TextBox17" runat="server" Width="100px"></asp:TextBox>
                                <asp:Button ID="Button69" runat="server" Text="Calcular" OnClick="Button69_Click" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="Label40" runat="server" Font-Bold="True" ForeColor="Teal"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="Label41" runat="server" Font-Bold="True" ForeColor="Teal"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 20px; position: static; background-color: darkslategray; text-align: center">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View27" runat="server">
                    <table style="width: 600px">
                        <tr>
                            <td style="width: 100px; height: 21px; background-color: darkslategray; text-align: left">
                                <strong>
                                    <asp:Panel ID="Panel7" runat="server" Height="20px" Width="600px">
                                        <span style="color: #ffffcc; font-family: Calibri">
                                        Sucursales con Horario Extendido y Desplazado</span></asp:Panel>
                                </strong></td>
                        </tr>
                        <tr>
                            <td style="width: 600px; height: 24px">
                                <strong><span style="font-family: Calibri">Municipio:</span></strong>
                                <asp:DropDownList ID="DropDownList16" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource6"
                                    DataTextField="Municipio" DataValueField="Municipio" Width="200px">
                                </asp:DropDownList>
                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; <strong><span style="font-family: Calibri; font-size: 10pt;">Horario Extendido Desde:
                                    11:00 AM&nbsp; Hasta: 6:00 PM</span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; background-color: darkslategray">
                                <span style="color: #ffffff; font-family: Calibri">
                                    <asp:Panel ID="Panel8" runat="server" Height="20px" Width="600px">
                                        <strong style="color: #ffffcc">
                                    Sucursales con horario extendido los <span style="color: lime">Lunes</span></strong></asp:Panel>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal"
                                    DataSourceID="SqlDataSource7" ForeColor="Black" GridLines="Horizontal" Height="200px"
                                    Width="600px" AllowSorting="True" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="Sucursal" ReadOnly="True" SortExpression="NoSucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Ubicada en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" Font-Names="Calibri" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 21px; background-color: darkslategray">
                                <strong>
                                    <asp:Panel ID="Panel9" runat="server" Height="20px" Width="600px">
                                        <span style="font-family: Calibri"><span style="color: #ffffcc">Sucursales con horario
                                            extendido los</span> <span style="color: lime">Viernes</span></span></asp:Panel>
                                </strong></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal"
                                    DataSourceID="SqlDataSource8" ForeColor="Black" GridLines="Horizontal" Height="200px"
                                    Width="600px" AllowSorting="True" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="Sucursal" ReadOnly="True" SortExpression="NoSucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Ubicada en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" Font-Names="Calibri" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 24px; background-color: darkslategray">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 23px; text-align: center">
                                <span style="font-family: Calibri"><strong>Horario desplazado de Lunes a Sábado Desde:
                                    8.30 AM Hasta: 7:30 PM</strong></span></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 24px; background-color: darkslategray">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 24px">
                                <asp:GridView ID="GridView11" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal"
                                    DataSourceID="SqlDataSource19" ForeColor="Black" GridLines="Horizontal" Height="200px"
                                    Width="600px" AllowSorting="True" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="Sucursal" ReadOnly="True" SortExpression="NoSucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Ubicada en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" Font-Names="Calibri" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 24px; background-color: darkslategray">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View28" runat="server">
                    <table style="width: 600px">
                        <tr>
                            <td style="background-color: darkslategray; text-align: center;">
                                <strong>
                                    <asp:Panel ID="Panel10" runat="server" Width="600px" Height="20px">
                                        <span style="color: #ffffcc; font-family: Calibri">
                                    Ubicación de los Cajeros Automáticos</span></asp:Panel>
                                    </strong></td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:Panel ID="Panel17" runat="server" Height="26px" Width="600px">
                                    <strong><span style="font-family: Calibri">Provincia:&nbsp;<asp:DropDownList ID="DropDownList17" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource9"
                                        DataTextField="Provincia" DataValueField="Provincia" Width="200px">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;Municipio:&nbsp;<asp:DropDownList ID="DropDownList18" runat="server" DataSourceID="SqlDataSource10"
                                        DataTextField="Municipio" DataValueField="Municipio" Width="200px" AutoPostBack="True">
                                    </asp:DropDownList></span></strong></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: darkslategray">
                                <asp:Panel ID="Panel11" runat="server" Height="20px" Width="600px" ForeColor="#FFFFCC">
                                    <span style="font-family: Calibri"><strong>Total</strong></span>
                                    <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="12pt"
                                        ForeColor="Lime" Text="Label"></asp:Label>
                                    <span style="font-family: Calibri"><strong>Cajeros</strong></span></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView7" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                    DataSourceID="SqlDataSource11" ForeColor="Black" GridLines="Horizontal" Width="600px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True" OnDataBound="GridView7_DataBound">
                                    <Columns>
                                        <asp:BoundField DataField="ID_Cajero" HeaderText="Cajero" SortExpression="ID_Cajero">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Est&#225; en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Pertenece_a" HeaderText="Es de:" SortExpression="Pertenece_a">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="#A2A764" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Valor1" HeaderText="$" SortExpression="Valor1">
                                            <HeaderStyle ForeColor="Lime" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Moneda1" HeaderText="Mon" SortExpression="Moneda1">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BackColor="#A2A764" HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Valor2" HeaderText="$" SortExpression="Valor2">
                                            <HeaderStyle ForeColor="Lime" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="2%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Moneda2" HeaderText="Mon" SortExpression="Moneda2">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BackColor="#A2A764" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Valor3" HeaderText="$" SortExpression="Valor3">
                                            <HeaderStyle ForeColor="Lime" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="2%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Moneda3" HeaderText="Mon" SortExpression="Moneda3">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                            <ItemStyle BackColor="#A2A764" HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Valor4" HeaderText="$" SortExpression="Valor4">
                                            <HeaderStyle ForeColor="Lime" HorizontalAlign="Center" VerticalAlign="Middle"
                                                Width="2%" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Moneda4" HeaderText="Mon" SortExpression="Moneda4">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                            <ItemStyle BackColor="#A2A764" HorizontalAlign="Center" VerticalAlign="Middle" Width="2%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" Font-Names="Calibri" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: darkslategray">
                                <asp:Panel ID="Panel12" runat="server" Height="20px" Width="600px">
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View29" runat="server">
                    <table style="width: 600px; border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid; border-bottom: #d8d787 2px solid;">
                        <tr>
                            <td style="width: 100px; background-color: darkslategray">
                                <span style="color: #ffffff; font-family: Calibri">
                                    <asp:Panel ID="Panel13" runat="server" Height="20px" Width="600px">
                                        <strong style="color: #ffffcc">
                                        Operaciones que pueden realizar los clientes naturales&nbsp; en su:</strong></asp:Panel>
                                </span></td>
                        </tr>
                        <tr>
                            <td style="width: 600px; height: 20px; text-align: center" valign="middle">
                                <asp:Panel ID="Panel14" runat="server" Height="20px" Width="600px">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource12"
                                    DataTextField="Area" DataValueField="Area" Font-Bold="True" Font-Names="Calibri"
                                    Height="20px" RepeatDirection="Horizontal" Width="200px">
                                </asp:RadioButtonList></asp:Panel>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 600px; height: 24px; background-color: darkslategray">
                                <asp:Panel ID="Panel15" runat="server" Height="20px" Width="600px">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource13"
                                    ForeColor="Black" GridLines="Horizontal" Width="600px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n" SortExpression="Descripcion" />
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 600px; height: 24px; background-color: darkslategray">
                                <asp:Panel ID="Panel16" runat="server" Height="20px" Width="600px">
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View30" runat="server">
                    <table style="width: 600px; border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid; border-bottom: #d8d787 2px solid;">
                        <tr>
                            <td style="background-color: darkslategray; height: 45px;">
                                <strong><span style="color: #ffffff; font-family: Calibri">
                                    <asp:Panel ID="Panel18" runat="server" Height="24px" Width="600px" ForeColor="#FFFFCC" Font-Names="Calibri" Font-Size="12pt">
                                        No Sucursal Actual-Anterior,
                                        Nombre, Ubicación, Teléfonos y Director(a) de <span>Sucursales</span></asp:Panel>
                                </span></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel20" runat="server" Height="26px" Width="600px">
                                    <span style="font-family: Calibri"><strong>Municipio:</strong></span>
                                    <asp:DropDownList ID="DropDownList19" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource14"
                                        DataTextField="Municipio" DataValueField="Municipio" Width="200px">
                                    </asp:DropDownList></asp:Panel>
                                <asp:GridView ID="GridView9" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal" DataSourceID="SqlDataSource15" ForeColor="Black" GridLines="Horizontal" Width="600px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="Sucursal:" ReadOnly="True" SortExpression="NoSucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NoSucursal_Antiguo" HeaderText="Anterior:" SortExpression="NoSucursal_Antiguo">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre:" SortExpression="Nombre">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Est&#225; en:" SortExpression="Ubicacion_Fisica">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Telefonos" HeaderText="Tel&#233;fonos:" SortExpression="Telefonos">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre_Director_Sucursal" HeaderText="Director:" SortExpression="Nombre_Director_Sucursal">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#A2A764" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; background-color: darkslategray">
                                <asp:Panel ID="Panel19" runat="server" Height="24px" Width="600px">
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp;<asp:View ID="View31" runat="server">
                    <table style="width: 600px; border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid; border-bottom: #d8d787 2px solid;">
                        <tr>
                            <td style="width: 100px; background-color: darkslategray; text-align: center">
                                <strong><span style="color: aliceblue; font-family: Calibri">
                                    <asp:Panel ID="Panel21" runat="server" Height="26px" Width="600px" ForeColor="#FFFFCC">
                                        Sucursales que venden Sellos Timbre</asp:Panel>
                                </span></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel22" runat="server" Height="26px" Width="600px">
                                    <strong><span style="font-family: Calibri">Municipio:
                                        <asp:DropDownList ID="DropDownList20" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource16"
                                            DataTextField="Municipio" DataValueField="Municipio" Width="200px">
                                        </asp:DropDownList></span></strong></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; background-color: darkslategray">
                                <asp:Panel ID="Panel23" runat="server" Height="26px" Width="600px">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="NoSucursal"
                                    DataSourceID="SqlDataSource17" ForeColor="Black" GridLines="Horizontal" Width="600px" Font-Names="Calibri" Font-Size="12pt" ShowFooter="True">
                                    <FooterStyle BackColor="#A2A764" />
                                    <Columns>
                                        <asp:BoundField DataField="NoSucursal" HeaderText="Sucursal" ReadOnly="True" SortExpression="NoSucursal">
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40%" />
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ubicacion_Fisica" HeaderText="Est&#225; en:" SortExpression="Ubicacion_Fisica">
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50%" />
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#A2A764" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; background-color: darkslategray">
                                <asp:Panel ID="Panel24" runat="server" Height="26px" Width="600px">
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View32" runat="server" OnActivate="View32_Activate">
                    <table style="border-right: #d8d787 2px solid; border-top: #d8d787 2px solid; border-left: #d8d787 2px solid;
                        width: 800px; border-bottom: #d8d787 2px solid">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <span style="font-family: Calibri"><strong>CUENTAS</strong></span></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" Font-Bold="True"
                                    Font-Names="Calibri" Font-Size="12pt" ForeColor="Teal" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Ahorro a la Vista</asp:ListItem>
                                    <asp:ListItem Value="2">Formaci&#243;n de Fondos</asp:ListItem>
                                    <asp:ListItem Value="3">Plazos Fijos </asp:ListItem>
                                    <asp:ListItem Value="4">Certificado de Dep&#243;sito</asp:ListItem>
                                    <asp:ListItem Value="5">Cuenta Corriente</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Panel ID="Panel30" runat="server" Height="20px" Width="600px">
                                </asp:Panel>
                                <strong>Fórmula: Interés =&nbsp; Importe * Días Transcurridos * Tasa Interés / 360 días</strong></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel27" runat="server" Visible="False" Width="800px">
                                    <table style="width: 800px">
                                        <tr>
                                            <td colspan="9" style="text-align: center">
                                                <span lang="ES-MX" style="font-size: 14pt; color: darkcyan; line-height: 115%; font-family: Calibri;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA"><strong>Ahorro a la Vista</strong></span></td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="3">
                                                Moneda</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="3">
                                                Frecuencia de Aplicación</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="3">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Saldo mínimo para Aplicar</span></td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="3">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Año Comercial </span>
                                            </td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="3">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Tasa de Interés </span>
                                            </td>
                                            <td rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Apertura</td>
                                            <td rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Depósito<br />
                                                Minimo en Banmet</td>
                                            <td colspan="2" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Extracción
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <strong>Libreta</strong></td>
                                            <td rowspan="2" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <strong>Tarjeta</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 58px; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span style="font-size: 9pt">En otros Bancos Comerciales mayor de estas cifras en la
                                                    propia sucursal de Banmet y con 72 horas de antelación</span></td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                CUP</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Trimestral 
                                                    <br />
                                                    (trimestres naturales)</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">$200.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    360 días</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">0.5 % </span>
                                            </td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $50.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $20.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $2000.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $5000.00</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                CUC</td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                Trimestral 
                                                <br />
                                                (trimestres naturales)</td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                $200.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                360 días</td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                0.5 %
                                            </td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                $50.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                $5.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                $80.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 40px; background-color: palegoldenrod;
                                                text-align: center">
                                                $5000.00</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                USD</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                Trimestral 
                                                <br />
                                                (trimestres naturales)</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $200.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                360 días</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                0.25 %
                                            </td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $50.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $5.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                No</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                No</td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                            <td colspan="1" style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                            <td colspan="1" style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                            <td colspan="1" style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                            <td colspan="1" style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Modalidad</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Libreta o Tarjeta Mágnetica</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Forma</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Individual, Indistinta, Conjunta o Mancomunada
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <strong>Beneficiario</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Solo en la Individual</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Comisión</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                A partir de la apertura de la cuenta si esta es cerrada antes de 1 mes se cobra
                                                $20.00 y si es en 3 meses $10.00 según el tipo de moneda de la Cuenta y en caso
                                                de pérdida se cobra $5.00 según la moneda de la Cuenta.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; height: 20px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel28" runat="server" Visible="False" Width="600px">
                                    <table style="width: 800px">
                                        <tr>
                                            <td colspan="9" style="text-align: center">
                                                <span lang="ES-MX" style="line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    <strong><span lang="ES-MX" style="line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                        mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                        <span style="font-size: 14pt; color: darkcyan; font-family: Calibri">Cuentas para el
                                                            Futuro (Formación de Fondos) Entidades, Trabajadores Bancarios y Jubilados.</span></span></strong></span></td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="2">
                                                Moneda</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="2">
                                                Frecuencia de Aplicación</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="2">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Saldo mínimo para Aplicar</span></td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="2">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Año Comercial</span></td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center" rowspan="2">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Tasa de Interés </span>
                                            </td>
                                            <td colspan="2" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; height: 40px;
                                                background-color: #a2a764; text-align: center">
                                                Apertura (Mínimo)</td>
                                            <td colspan="1" rowspan="2" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Depósito</td>
                                            <td colspan="1" rowspan="2" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Extracción</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                Trabajador Activo</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                Jubilado o Pensionado</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                CUP</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Trimestral</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Sobre cualquier saldo</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    360 días</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; font-family: 'Times New Roman','serif';
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">2.0 % </span>
                                            </td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $30.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $10.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                Según el monto de la apertura se descontará mensualmente del Salario o Pensión</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                Permitido 4 extracciones en 1 año, si efectúa una 5ta extracción se cierra la Cuenta.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Modalidad</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Libreta</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Forma</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Individual</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Beneficiario</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Sí</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Comisión</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                A partir de la apertura de la cuenta si esta es cerrada antes de 1 mes se cobra
                                                $20.00 y si es en 3 meses $10.00 según el tipo de moneda de la Cuenta y en caso
                                                de pérdida se cobra $5.00 según la moneda de la Cuenta.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Bonificación</strong></td>
                                            <td colspan="8" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                2.0 % adicional (Se aplica si no realiza extracciones en un año contados
                                                    a partir de la fecha en que se abrió la cuenta), mas 1 % si no hace extracciones durante
                                                3 años.</td>
                                        </tr>
                                        <tr style="font-family: Times New Roman">
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; height: 20px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel29" runat="server" Visible="False" Width="600px">
                                    <table style="width: 800px">
                                        <tr>
                                            <td colspan="11" style="text-align: center">
                                                <span lang="ES-MX" style="font-size: 14pt; color: darkcyan; line-height: 115%; font-family: Calibri;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA"><strong>Plazos Fijos</strong></span></td>
                                        </tr>
                                        <tr>
                                            <td rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Moneda</td>
                                            <td colspan="7" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Tasas de Interés %</td>
                                            <td colspan="1" rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Apertura<br />
                                                (Mínimo)</td>
                                            <td colspan="1" rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Depósito</td>
                                            <td colspan="1" rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Extracción</td>
                                        </tr>
                                        <tr>
                                            <td colspan="7" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Plazos (Meses)</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                3</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                6</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                12</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                24</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                36</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                60</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                72</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                CUP</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">2.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    2.50</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    4.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    5.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    6.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                6.50</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                7.00</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $200.00
                                                <br />
                                                <strong><span style="font-size: 11pt">($100.00 para el plazo de 72 meses)&nbsp;</span></strong></td>
                                            <td rowspan="3" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                NO ADMITE</td>
                                            <td rowspan="3" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                Si lo hace no gana intereses, excepto en el plazo de 72 meses que puede extraer
                                                los intereses todos los años, por ser una cuenta con pago anticipado de intereses.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                CUC</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">1.50</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    2.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    2.50</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    3.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    4.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                4.25</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                -</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                $100.00</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                USD</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">0.5</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    0.75</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    1.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    1.25</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    1.75</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                1.90</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                -</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $100.00</td>
                                        </tr>
                                        <tr>
                                            <td colspan="11" style="font-size: 12pt; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Modalidad</strong></td>
                                            <td colspan="10" style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Contrato por 3,6,12,24,36,60 y 72 meses, <strong>(72 meses solo en CUP)</strong></td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Forma</strong></td>
                                            <td colspan="10" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Individual, Indistinta, Mancomunada y Menor de Edad con Representación Legal.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Beneficiario</strong></td>
                                            <td colspan="10" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Solo en el caso de la Cuenta Individual.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Comisión</strong></td>
                                            <td colspan="10" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                A partir de la apertura de la cuenta si esta es cerrada antes de 1 mes se cobra
                                                $20.00 y si es en 3 meses $10.00 según el tipo de moneda de la Cuenta y en caso
                                                de pérdida se cobra $5.00 según la moneda de la Cuenta.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Interés</strong></td>
                                            <td colspan="10" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Puede variar según lo que decida BCC y es mayor mientras mayor sea el plazo de imposición.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="11" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; height: 20px;
                                                background-color: #a2a764; text-align: center">
                                                <strong style="color: #ffffcc">Frecuencia de aplicación:</strong> Según período
                                                pactado y <span style="color: black"><strong>Se paga sólo al vencimiento</strong>.(<strong>Excepto
                                                    en el de 72 meses</strong>)</span></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="Panel31" runat="server" Visible="False" Width="800px">
                                    <table style="width: 800px">
                                        <tr>
                                            <td colspan="10" style="text-align: center">
                                                <span lang="ES-MX" style="font-size: 14pt; color: darkcyan; line-height: 115%; font-family: Calibri;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA"><strong>Certificados de Depósito</strong></span></td>
                                        </tr>
                                        <tr>
                                            <td rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Moneda</td>
                                            <td colspan="6" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Tasas de Interés %</td>
                                            <td colspan="1" rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Apertura</td>
                                            <td colspan="1" rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Depósito</td>
                                            <td colspan="1" rowspan="3" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Extracción</td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Plazos (Meses)</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                3</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                6</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center; width: 35px;">
                                                12</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                24</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                36</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                60</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; height: 21px; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                CUP</td><td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                    <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                        2.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    2.50</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center; width: 35px;">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    4.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    5.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    6.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                6.50</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $100.00
                                            </td>
                                            <td rowspan="3" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                NO ADMITE</td>
                                            <td rowspan="3" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: justify">
                                                De hacerlo en los plazos de 3,6,y 12 meses debe haber transcurrido el 50% ó + del
                                                tiempo y solo cobra el 50% del interés, de hacerloen los plazos de 24,36,60 meses
                                                tiene que haber transcurrido el 25% ó + del tiempo y solo se le paga el 50% del
                                                interés.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                CUC</td><td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                    <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                        1.50</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    2.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center; width: 35px;">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    2.50</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    3.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    4.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                4.25</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: palegoldenrod;
                                                text-align: center">
                                                $500.00
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                USD</td><td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                    <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                        0.5</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    0.75</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center; width: 35px;">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    1.00</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    1.25</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">
                                                    1.75</span></td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                1.90</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $500.00
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="6" style="font-size: 12pt; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                            <td colspan="9" style="font-size: 12pt; color: #ffffcc; font-family: Calibri; height: 20px;
                                                background-color: #a2a764; text-align: center">
                                                <span style="color: #ffffcc; background-color: #a2a764">De presentarse el cliente para
                                                    liquidar su Certificado de Depósito:</span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-size: 12pt; font-family: Calibri; height: 20px; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                Forma de Pago 
                                                <br />
                                                (<span lang="ES-MX" style="font-size: 12pt; line-height: 115%; font-family: 'Times New Roman','serif';
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA"><strong>3, 6 y 12 meses</strong></span>)</td>
                                            <td colspan="6" style="font-size: 12pt; font-family: Calibri; height: 20px; background-color: palegoldenrod;
                                                text-align: center">
                                                Forma de Pago (<span lang="ES-MX" style="font-size: 12pt; line-height: 115%; font-family: 'Times New Roman','serif';
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA"><strong>24, 36 y 60 meses</strong></span>)</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-size: 12pt; font-family: Times New Roman; height: 59px;
                                                background-color: lightgoldenrodyellow; text-align: justify">
                                                Antes de haber transcurrido el 50% de término pactado, se le paga sólo el principal
                                                y pierde el derecho al cobro del interés.<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                                                    prefix="o" ?><o:p></o:p></td>
                                            <td colspan="6" style="font-size: 12pt; font-family: Times New Roman; height: 59px;
                                                background-color: palegoldenrod; text-align: justify">
                                                Antes de haber trascurrido el 25% de término pactado, se le paga sólo el principal
                                                y pierde el derecho al cobro del interés.<o:p></o:p></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-size: 12pt; font-family: Times New Roman; background-color: lightgoldenrodyellow;
                                                text-align: justify">
                                                Si ha transcurrido el 50% o más del término pactado, se le paga el &nbsp; principal
                                                y el 50%&nbsp; del interés acumulado hasta el cierre del día anterior.<o:p></o:p></td>
                                            <td colspan="6" style="font-size: 12pt; font-family: Times New Roman; height: 20px;
                                                background-color: palegoldenrod; text-align: justify">
                                                Si ha transcurrido el 25% o más del término pactado, se paga el principal y el&nbsp;
                                                50%&nbsp; del interés&nbsp; acumulado hasta el cierre del día anterior.<o:p></o:p></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="font-size: 12pt; font-family: Times New Roman; background-color: lightgoldenrodyellow;
                                                text-align: justify">
                                                Si ha transcurrido el 100% del término pactado, se le paga el &nbsp; principal y
                                                el 100%&nbsp; del interés&nbsp; acumulado hasta el cierre.<o:p></o:p></td>
                                            <td colspan="6" style="font-size: 12pt; font-family: Times New Roman; height: 20px;
                                                background-color: palegoldenrod; text-align: justify">
                                                Si ha transcurrido el 100% del término pactado, se le paga el &nbsp; principal y
                                                el 100%&nbsp; del interés.<o:p></o:p></td>
                                        </tr>
                                        <tr>
                                            <td colspan="9" style="font-size: 12pt; font-family: Times New Roman; height: 20px;
                                                background-color: #a2a764; text-align: center">
                                                <span lang="ES-MX" style="display: none; font-size: 12pt; color: #ffffcc; font-family: 'Times New Roman','serif';
                                                    mso-fareast-font-family: 'Times New Roman'; mso-fareast-language: ES-MX; mso-hide: all">
                                                    &nbsp;<strong style="color: #ffffcc">Frecuencia de aplicación:</strong> <span style="color: black">
                                                        Según período pactado.</span></span></td>
                                        </tr>
                                        <tr>
                                            <td rowspan="1" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Modalidad</strong></td>
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Certificado por 3,6,12,24,36 y 60 meses.</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="1" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Forma</strong></td>
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Individual, Indistinta, Conjunta o Mancomunada y Menor de Edad representado.</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="1" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Beneficiario</strong></td>
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                NO ADMITE</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="1" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Comisión</strong></td>
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                A partir de la apertura de la cuenta si esta es cerrada antes de 1 mes se cobra
                                                $20.00 y si es en 3 meses $10.00 según el tipo de moneda de la Cuenta y en caso
                                                de pérdida se cobra $5.00 según la moneda de la Cuenta.</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="1" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Interés</strong></td>
                                            <td colspan="9" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                El Interés puede variar según lo que decida BCC, a mayor plazo mayor interés.</td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" style="font-size: 12pt; font-family: Times New Roman; height: 20px;
                                                background-color: #a2a764; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10" style="font-size: 12pt; font-family: Calibri; text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="Panel4" runat="server" Visible="False" Width="800px">
                                    <table style="width: 800px">
                                        <tr>
                                            <td colspan="6" style="text-align: center">
                                                <span lang="ES-MX" style="line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    <strong><span lang="ES-MX" style="line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                        mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                        <span style="font-size: 14pt; color: darkcyan; font-family: Calibri">Cuentas Corrientes
                                                            (<span style="color: black">No Acumula Intereses</span>)</span></span></strong></span></td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                Moneda</td>
                                            <td style="font-size: 12pt; color: #ffffcc; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; mso-fareast-font-family: 'Times New Roman';
                                                    mso-ansi-language: ES-MX; mso-fareast-language: ES-MX; mso-bidi-language: AR-SA">
                                                    Tasa de Interés </span>
                                            </td>
                                            <td colspan="2" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Apertura&nbsp;<br />
                                                (<span style="color: black">En el banco según la Residencia del Interesado o donde la
                                                    Cooperativa realiza sus Operaciones</span>)</td>
                                            <td colspan="1" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Depósito</td>
                                            <td colspan="1" style="font-size: 12pt; color: #ffffcc; font-family: Calibri;
                                                background-color: #a2a764; text-align: center">
                                                Extracción</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">CUP</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center"><span lang="ES-MX" style="font-size: 12pt; line-height: 115%;
                                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                                    mso-bidi-language: AR-SA">No Acumula&nbsp;</span></td>
                                            <td colspan="2" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">$500.00 </td>
                                            <td colspan="2" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">Ambas operaciones se realizan a través de los Instrumentos de Pago (Cheques, Tarjetas Magnéticas, Transferencia, etc..)</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                CUC</td>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                No Acumula</td>
                                            <td colspan="2" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: center">
                                                $50.00
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="font-size: 12pt; font-family: Calibri; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Modalidad</strong></td>
                                            <td colspan="5" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Tarjeta Magnética o Chequera.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Forma</strong></td>
                                            <td colspan="5" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                Individual, Indistinta, Mancomunada.</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Beneficiario</strong></td>
                                            <td colspan="5" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                NO ADMITE</td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                <strong>Comisión</strong></td>
                                            <td colspan="5" style="font-size: 12pt; font-family: Calibri; background-color: lightgoldenrodyellow;
                                                text-align: left">
                                                A partir de la apertura de la cuenta si esta es cerrada antes de 1 mes se cobra
                                                $20.00 y si es en 3 meses $10.00 según el tipo de moneda de la Cuenta y en caso
                                                de pérdida se cobra $5.00 según la moneda de la Cuenta.</td>
                                        </tr>
                                        <tr style="font-family: Times New Roman">
                                            <td colspan="6" style="font-size: 12pt; font-family: Calibri; height: 20px; background-color: #a2a764;
                                                text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px; text-align: center">
                                <span lang="ES-MX" style="font-size: 12pt; line-height: 115%; font-family: 'Times New Roman','serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA"></span>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View33" runat="server">
                    <table style="width: 568px">
                        <tr>
                            <td style="text-align: center">
                                <strong><span><span style="color: #008080"><span style="font-family: Calibri">PAGO A
                                    JUBILADOS Y PENSIONADOS DE SEGURIDAD SOCIAL 
                                    <br />
                                    EN LA HABANA</span></span></span></strong></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Imagenes/cj95.jpg" Width="596px" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View34" runat="server">
                    <table style="width: 600px">
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <span style="color: teal; font-family: Calibri">
                                    <asp:Label ID="Label42" runat="server" Font-Bold="True" Text="PLAZO PARA LA RENOVACION DE TARJETAS A JUBILADOS"></asp:Label></span></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width: 100px; background-color: darkslategray">
                                <span lang="ES-MX" style="font-size: 11pt; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES;
                                    mso-bidi-language: AR-SA">&nbsp;</span></td>
                        </tr>
                        <tr>
                            <td style="width: 197px; height: 39px; background-color: palegoldenrod; text-align: center;">
                                Año de Nacimiento del Jubilado</td>
                            <td style="width: 64px; height: 39px; background-color: palegoldenrod; text-align: center;">
                                Tarjetas a Renovar</td>
                            <td style="width: 114px; height: 39px; background-color: palegoldenrod; text-align: center;">
                                Fecha Tope 
                                <br />
                                (Poner en H)</td>
                            <td style="width: 110px; height: 39px; background-color: palegoldenrod; text-align: center;">
                                Fecha Tope 
                                <br />
                                (Tarjeta en Lata)</td>
                        </tr>
                        <tr>
                            <td style="width: 197px; background-color: palegoldenrod;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">A partir de 1951 </span>
                            </td>
                            <td style="width: 64px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">20411</span></td>
                            <td style="width: 114px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">20 de Mayo</span></td>
                            <td style="width: 110px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">30 de Junio</span></td>
                        </tr>
                        <tr>
                            <td style="width: 197px; height: 19px; background-color: palegoldenrod;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">De 1946 a 1950</span></td>
                            <td style="width: 64px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">20436</span></td>
                            <td style="width: 114px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">19 de Junio</span></td>
                            <td style="width: 110px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">31 de Julio</span></td>
                        </tr>
                        <tr>
                            <td style="width: 197px; height: 19px; background-color: palegoldenrod;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">De 1942 a 1945</span></td>
                            <td style="width: 64px; height: 19px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">17152</span></td>
                            <td style="width: 114px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">15 de Julio</span></td>
                            <td style="width: 110px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">30 de Agosto</span></td>
                        </tr>
                        <tr>
                            <td style="width: 197px; background-color: palegoldenrod;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">De 1939 a 1941</span></td>
                            <td style="width: 64px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">17152</span></td>
                            <td style="width: 114px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">19 de Agosto</span></td>
                            <td style="width: 110px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">30 de Septiembre</span></td>
                        </tr>
                        <tr>
                            <td style="width: 197px; background-color: palegoldenrod;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">De 1933 a 1938</span></td>
                            <td style="width: 64px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">16519</span></td>
                            <td style="width: 114px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">18 de Septiembre</span></td>
                            <td style="width: 110px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">31 de Octubre</span></td>
                        </tr>
                        <tr>
                            <td style="width: 197px; background-color: palegoldenrod;">
                                <font face="Calibri" size="3">
                                    <p>
                                        Hasta 1932</p>
                                </font>
                            </td>
                            <td style="width: 64px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">19407</span></td>
                            <td style="width: 114px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">17 de Octubre</span></td>
                            <td style="width: 110px; background-color: palegoldenrod; text-align: center;">
                                <span lang="ES-MX" style="font-size: 11pt; color: black; line-height: 115%; font-family: 'Calibri','sans-serif';
                                    mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: ES-MX; mso-fareast-language: ES-MX;
                                    mso-bidi-language: AR-SA; mso-ascii-theme-font: minor-latin; mso-fareast-theme-font: minor-fareast;
                                    mso-hansi-theme-font: minor-latin">29 de Noviembre</span></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width: 100px; height: 21px; background-color: darkslategray">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView></td>
    </tr>
</table>
<input id="HdnConfirm" runat="server" style="width: 15px" type="hidden" />
<input id="HdnWhoConfirm" runat="server" style="width: 17px; height: 22px;" type="hidden" />
