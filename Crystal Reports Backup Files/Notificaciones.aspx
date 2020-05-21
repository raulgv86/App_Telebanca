<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notificaciones.aspx.cs" Inherits="Notificaciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table style="width: 800px; height: 600px; text-align: center;">
            <tr>
                <td style="width: 100px; text-align: center;" align="center" valign="middle">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 29px;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Imagenes/important.png" /><br />
                    <span style="font-size: 16pt; color: #00cc66; font-family: Calibri"><strong>!Información!</strong></span></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: center;">
                    <asp:Label ID="Label1" runat="server" Visible="False" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large"
                        ForeColor="Red" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="X-Large"
                        ForeColor="Red" Visible="False"></asp:Label></td>
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
        </table>
    
    </div>
    </form>
</body>
</html>
