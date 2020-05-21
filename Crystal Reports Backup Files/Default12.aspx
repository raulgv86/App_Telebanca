<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>
<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default12.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bienvenido a BanTel</title>
</head>
<body style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; clip: rect(auto auto auto auto); padding-top: 0px; text-align: center;">
          
    <form id="form1" runat="server">
    <div>
        <br />
        <table>
            <tr>
                <td style="text-align: center">
                    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Images/Imagenes/TarjetaTB.png"
                        Height="672px" Width="804px">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        &nbsp;&nbsp;
            <asp:Login ID="Login12" runat="server" FailureText="Usuario o contraseña no válidos. Intente otra vez."
                LoginButtonText="Acceder" OnAuthenticate="Login12_Authenticate" PasswordLabelText="Contraseña"
                RememberMeText="Recordar contraseña." TitleText="" UserNameLabelText="Usuario" PasswordRequiredErrorMessage="*" UserNameRequiredErrorMessage="*" DestinationPageUrl="~/Main.aspx" DisplayRememberMe="False" Font-Bold="True" Font-Names="Calibri" EnableTheming="True" ForeColor="#404040" Width="300px">
                <TextBoxStyle Width="150px" Font-Names="Calibri" Font-Size="10pt" />
                <FailureTextStyle Font-Bold="True" Font-Names="Calibri" Font-Size="10pt" />
                <ValidatorTextStyle Font-Names="Calibri" />
                <LoginButtonStyle Font-Names="Calibri" Font-Size="11pt" />
                <LayoutTemplate>
                    <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                        <tr>
                            <td style="width: 312px; height: 119px; text-align: center">
                                <table border="0" cellpadding="0">
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Bold="True"
                                                Font-Names="Calibri" ForeColor="Black">Usuario</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Font-Names="Calibri" Font-Size="10pt" Width="160px"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                ErrorMessage="*" Font-Names="Calibri" ToolTip="*" ValidationGroup="Login12">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Bold="True"
                                                Font-Names="Calibri" ForeColor="Black">Contraseña</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" Font-Names="Calibri" Font-Size="10pt" TextMode="Password"
                                                Width="160px"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                ErrorMessage="*" Font-Names="Calibri" ToolTip="*" ValidationGroup="Login12">*</asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="font-weight: bold; font-size: 10pt; color: red;
                                            font-family: Calibri">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                        <td align="center" colspan="1" style="font-weight: bold; font-size: 10pt; color: red;
                                            font-family: Calibri">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2" style="height: 27px">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Font-Bold="True"
                                                Font-Names="Calibri" Font-Size="11pt" ForeColor="Black" Text="Acceder" ValidationGroup="Login122" OnClick="LoginButton_Click" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 27px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
                    </asp:Panel>
                    </td>
            </tr>
        </table>
        <iframe frameborder="0" width="100%" height="200px" src="HTML/Buen_Trato12.htm" style="width: 100%; height: 250px" scrolling="yes"></iframe>
    
    </div>
    </form>
      

</body>

<script type="text/javascript" language="javascript">
<!-- // Hide

    var isDOM = false, isNS4 = false;
    if (document.all) var isDOM = true, docObj = 'document.all.', styObj = '.style';
    else if (document.layers) var isNS4 = true, docObj = 'document.', styObj = '';

    var quotes = new Array(); c = 0;
    quotes[c] = 'Banco Central de Cuba'; c++;
    quotes[c] = 'Sistema Informativo Bancario'; c++;
    quotes[c] = 'B. C. C.'; c++;
    quotes[c] = 'S. I. B.'; c++;
    quotes[c] = '...consultas online...'; c++;
    quotes[c] = '...tablas de clasificadores...'; c++;
    quotes[c] = '...consultas generales...'; c++;
    quotes[c] = '...validación de los modelos...'; c++;
    quotes[c] = '...navegación simplificada...'; c++;
    quotes[c] = 'Banco Central de Cuba'; c++;
    quotes[c] = 'Sistema Informativo Bancario'; c++;
    quotes[c] = 'B. C. C.'; c++;
    quotes[c] = 'S. I. B.'; c++;
    quotes[c] = '...consultas online...'; c++;
    quotes[c] = '...tablas de clasificadores...'; c++;
    quotes[c] = '...consultas generales...'; c++;
    quotes[c] = '...validación de los modelos...'; c++;
    quotes[c] = '...navegación simplificada...'; c++;

    var visQuotes = 7; // Maximum onscreen at once.

    var sDivSty = new Array(visQuotes);
    var sDivRef = new Array(visQuotes);
    var speed = new Array(visQuotes);

    //  Left: Low speed colours (lighter) .... Right: High speed colours (darker).
    var colours = new Array('B2C7DE','A4BCD8','96B2D2','88A8CC','7A9EC6','6C94C0','5E89BA');


    function checkDivs()
    {
     for (i = 0; i < visQuotes; i++)
     {
      // If it's moved offscreen to the left (or starting), set things in motion...
      if (parseInt(sDivSty[i].left) < (0 - (isDOM ? sDivRef[i].clientWidth : sDivSty[i].clip.width)))
      {
       speed[i] = Math.floor(Math.random() * 56) + 8; // Varies: 8 to 63.
       // Off to the right it goes.
       sDivSty[i].left = (isDOM ? document.body.clientWidth : window.innerWidth) + Math.random() * 50;
       // Write a quote in a colour that depends on the speed.

    /*  Stylesheets - guess which browser has bugs :)
     *
     *  divText = '<nobr><span style="font: ' + speed[i] + 'px Arial, Helvetica; ' +
     *   'color: #' + colours[Math.floor(speed[i] / 8) - 1] + '">' +
     *   quotes[Math.floor(Math.random() * quotes.length)] + '</span></nobr>';
     */

       fontSize = Math.floor(speed[i] / 8) - 1;
       divText = '<nobr><font face="Arial, Helvetica" size="' + fontSize + '" color="#' +
        colours[fontSize] + '">' + quotes[Math.floor(Math.random() * quotes.length)] +
        '</font></nobr>';

       if (isDOM) sDivRef[i].innerHTML = divText;
       if (isNS4)
       {
        sDivRef[i].document.write(divText);
        sDivRef[i].document.close();
       }
       // Position and layer it according to its speed (faster = higher).
       sDivSty[i].zIndex = speed[i];
       topMax = (isDOM ? document.body.clientHeight : innerHeight) - speed[i];
       sDivSty[i].top = topMax * Math.random();
      }
      // All items: Keep 'em moving left.
      sDivSty[i].left = parseInt(sDivSty[i].left) - (speed[i] / 4);
     }
    }


    function initDivs()
    {
     for (i = 0; i < visQuotes; i++)
     {
      divID = 'sDiv' + i.toString();
      if (isDOM) document.write('<div id="' + divID + '" style="position: absolute; left: -1000">&nbsp;</div>');
      // Have to use layers, divs are buggy as..... in NS. Again.
      if (isNS4) document.write('<layer id="' + divID + '" left="-1000">&nbsp;</layer>');
      sDivRef[i] = eval(docObj + 'sDiv' + i);
      sDivSty[i] = eval(docObj + 'sDiv' + i + styObj);
     }

     setInterval('checkDivs()', 50);
    }

    if (isDOM || isNS4) initDivs();

    // End Hide -->
    </script>
</html>
