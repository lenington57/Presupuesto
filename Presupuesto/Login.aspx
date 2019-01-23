<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presupuesto.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" integrity="sha384-GJzZqFGwb1QTTN6wy59ffF1BuGJpLSa9DkKMp0DgiMDm4iYMj70gZWKYbI706tWS" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-dark bg-dark">
                <a class="navbar-brand" style="font-size: xx-large; border-color: #FFFFFF; color: #FFFFFF;">Iniciar Sesión</a>
                <div class="form-group col-md-3">
                    <asp:Label ID="Label1" runat="server" Text="Email" ForeColor="White">Email</asp:Label>
                    <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="Contraseña" ForeColor="White">Contraseña</asp:Label>
                    <asp:TextBox ID="TextBox1" AutoCompleteType="Disabled" class="form-control input-group" type="password" runat="server"></asp:TextBox>
                    <br>
                    <asp:Button class="form-control btn btn-light col-sm-4 " ID="entrarButton" runat="server" Text="Entrar" />
                </div>
            </nav>
        </div>
        <br>
        <br>
        <asp:Image ID="UsuarioImage" runat="server" Height="394px" ImageUrl="~/Resources/presupuesto-semanal-o-mensual-cuál-es-mejor.jpg" runat="server" Width="432px" AlternateText="Imagen no disponible" ImageAlign="right" />
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" integrity="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" integrity="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" crossorigin="anonymous"></script>
</body>
</html>
