﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CCategoriaWF.aspx.cs" Inherits="Presupuesto.Consultas.CCategoriaWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 align="center" style="font-weight: bold">Consulta de Categorías</h3>
    <div class="form-row justify-content-center">
        <%--Filtro--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-success" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>CategoriaId</asp:ListItem>
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>Descripcion</asp:ListItem>
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
        <asp:GridView ID="categoriaGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
            <AlternatingRowStyle BackColor="#999999" />
            <Columns>
                <asp:BoundField DataField="CategoriaId" HeaderText="CategoriaId" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="MontoMensualidad" HeaderText="Monto" />
            </Columns>
            <HeaderStyle BackColor="003366" Font-Bold="True" />
        </asp:GridView>
    </div>
    <div class="card-footer">
        <div class="justify-content-start">
            <div class="form-group" style="display: inline-block">
                <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-info mt-4" runat="server" OnClick="ImprimirLinkButton_Click">
                            <span class="fas fa-print"></span>
                            Imprimir
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
