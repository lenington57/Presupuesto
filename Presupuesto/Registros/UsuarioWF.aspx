﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioWF.aspx.cs" Inherits="Presupuesto.Registros.UsuarioWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="font-weight: bold">Abre una nueva cuenta</h3>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="UsuarioId"></asp:Label>
                <asp:Button class="btn btn-primary" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click"/>
                <asp:TextBox class="form-control" ID="usuarioIdTextBox" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Image ID="UsuarioImage" runat="server" Height="394px" ImageUrl="~/Resources/presupuesto-semanal-o-mensual-cuál-es-mejor.jpg" runat="server" Width="432px" AlternateText="Imagen no disponible" ImageAlign="right" />
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox class="form-control" ID="nombreTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
                <asp:TextBox class="form-control" ID="emailTextBox" placeholder="micorreo@gmail.com" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox class="form-control" ID="passwordTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Confirmar Contraseña"></asp:Label>
                <asp:TextBox class="form-control" ID="cpasswordTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Presupuesto"></asp:Label>
                <asp:TextBox class="form-control" ID="presupuestoTextBox" placeholder="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Button class="btn btn-primary" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click"/>
                <asp:Button class="btn btn-success" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click"/>
                <asp:Button class="btn btn-danger" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
