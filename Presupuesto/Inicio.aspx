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
        <br>
        <br>
        <a class="btn btn-primary btn-lg" href="http://localhost:52979/Registros/UsuarioWF.aspx" role="button">Editar Presupuesto</a>
    </div>
</asp:Content>
