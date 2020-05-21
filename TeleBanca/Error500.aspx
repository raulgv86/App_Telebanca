<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error500.aspx.cs" Inherits="Error500" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta http-equiv="X-UA-Compatible" content="IE=8; IE=9; IE=11" />

    <%--<link href="https://fonts.googleapis.com/css?family=Encode+Sans+Semi+Condensed:100,200,300,400" rel="stylesheet">--%>
    <link href="Styles/Estilos_Error500.css" rel="stylesheet" />
    <title>Error Interno</title>

    <%--funcion para mostrar la descripcion del error--%>
    <script>
        function mostrar(id) {
            obj = document.getElementById(id);
            obj.style.visibility = (obj.style.visibility == 'hidden') ? 'visible' : 'hidden';
        }
    </script>

</head>
<body class="loading">
    <form id="form1" runat="server">
      <div style="align-content:center">
          <img class="imagen" src="Images/error500.jpg"/>
          <div>
              <asp:Panel ID="Panel1" runat="server">   
                  <%--<asp:Button ID="btn_error" runat="server" Text="Muestralo" OnClick="btn_error_Click" Visible="False" />  --%>             
                  <%--<a href="#" runat="server" onclick="Mostrar_Error()" >Ver Error</a>--%>
                  <br />
                  <br />
                  <asp:Label ID="Label1" runat="server" Text="Texto Error" BackColor="Yellow" BorderColor="White" ForeColor="Black"></asp:Label>
              </asp:Panel>
          </div>
      </div>
      <script src="Scripts/jquery-1.10.2.js"></script>
      <script src="Scripts/JavaScript_Error500.js" type="text/javascript"></script>
      <script src="js/main.js" type="text/javascript"></script>
    </form>
</body>
</html>
