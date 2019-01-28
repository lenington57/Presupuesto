<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriaWF.aspx.cs" Inherits="Presupuesto.Registros.CategoriaWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.8/css/all.css">
    <!------ Hasta aquí los links ---------->
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card">
                <div class="card-header text-uppercase text-center text-primary">Categoría</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="CategoriaId"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" />
                                    <asp:TextBox class="form-control" ID="usuarioIdTextBox" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <asp:Image ID="CategoriasImage" runat="server" Height="215px" ImageUrl="~/Resources/coleccion-iconos-negocios_1270-6.jpg" runat="server" Width="222px" AlternateText="Imagen no disponible" ImageAlign="right" />
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- form-group// -->
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
                                    <asp:TextBox class="form-control" ID="descripcionTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- form-group// -->
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Monto Mensual"></asp:Label>
                                    <asp:TextBox class="form-control" ID="montoMensualTextBox" Text="0" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- form-group// -->
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button Text="Nuevo" class="btn btn-primary btn-sm" runat="server" ID="nuevoButton" />
                                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="guadarButton" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="eliminarButton" />
                                </div>
                            </div>
                        </div>
                        <!-- form-group// -->
                    </form>
                </article>
            </div>
            <!-- card.// -->
            <br>
    </div>
</div>
    </div>
    </div>
</asp:Content>
