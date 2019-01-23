<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presupuesto.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h1 align="center" class="display-4">Bienvenido</h1>
        <br>
        <asp:Label ID="nombreLabel" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" Font-Size="X-Large">usted cuenta con</asp:Label>
        <asp:Label ID="presupuestoLabel" runat="server" Text="Label" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <br>
    </div>
    <asp:Label ID="Label2" runat="server" Text="Digite la cantidad de su nuevo Presupuesto" Font-Bold="True" Font-Size="Large"></asp:Label>
    <asp:TextBox class="form-control col-md-2" ID="nuevoPresuTextBox" runat="server"></asp:TextBox>
    <asp:Button class="form-control btn btn-dark col-md-2" ID="editarButton" runat="server" Text="Editar Presupuesto" OnClick="editarButton_Click1" />
    <asp:Image ID="UsuarioImage" runat="server" Height="394px" ImageUrl="~/Resources/presupuesto-semanal-o-mensual-cuál-es-mejor.jpg" runat="server" Width="432px" AlternateText="Imagen no disponible" ImageAlign="right" />
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
    <br>
</asp:Content>
