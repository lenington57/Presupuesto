﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CUsuarioWF.aspx.cs" Inherits="Presupuesto.Consultas.CUsuarioWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 align="center" style="font-weight: bold">Consulta de Usuarios</h3>
    <div class="form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-success" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>Todo por Fecha</asp:ListItem>
                <asp:ListItem>UsuarioId</asp:ListItem>
                <asp:ListItem>Nombre</asp:ListItem>
            </asp:DropDownList>
        </div>
        <%--Criterio--%>
        <div class="form-group col-md-3">
            <asp:Label ID="Label1" runat="server" class="text-success" Text="Criterio">Criterio</asp:Label>
            <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="buscarLinkButton" CssClass="btn btn-outline-success mt-4" runat="server" OnClick="buscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
        </div>
    </div>

    <%--Rango fecha--%>
    <div class="form-row justify-content-center">
        <div class="form-group col-md-2">
            <asp:Label Text="Desde" class="text-success" runat="server" />
            <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
        <div class="form-group col-md-2">
            <asp:Label Text="Hasta" class="text-success" runat="server" />
            <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>
    <div class="form-row justify-content-center">
        <asp:GridView ID="usuarioGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
            <AlternatingRowStyle BackColor="#999999" />
            <Columns>
                <asp:BoundField DataField="UsuarioId" HeaderText="UsuarioId" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Password" HeaderText="Contraseña" />
                <asp:BoundField DataField="CPassword" HeaderText="Confirmación" />
                <asp:BoundField DataField="MontoPresupuesto" HeaderText="Presupuesto" />
            </Columns>
            <HeaderStyle BackColor="003366" Font-Bold="True" />
        </asp:GridView>
    </div>
     <div class="card-footer">
        <div class="justify-content-start">
            <div class="form-group" style="display: inline-block">
                <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-info mt-4" runat="server">
                            <span class="fas fa-print"></span>
                            Imprimir
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
