<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebPublica.Carrito" %>

<%@ Register Src="~/ControlesDeUsuario/WucVistaPreviaArticulo.ascx" TagName="WucVistaPreviaArticulo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        * {
            padding: 0;
            margin: 0;
        }

        h1 {
            font: bold 32px Times;
            color: #666;
            text-align: center;
            padding: 20px 0;
        }

        #container {
            width: 700px;
            margin: 10px auto;
        }

        .mGrid {
            width: 100%;
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }

            .mGrid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
                color: #717171;
            }

            .mGrid th {
                padding: 4px 2px;
                color: #fff;
                background: #000000 url(grd_head.png) repeat-x top;
                border-left: solid 1px #525252;
            }

            .mGrid .alt {
                background: #fcfcfc url(grd_alt.png) repeat-x top;
            }

            .mGrid .pgr {
                background: #424242 url(grd_pgr.png) repeat-x top;
            }

                .mGrid .pgr table {
                    margin: 5px 0;
                }

                .mGrid .pgr td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .mGrid .pgr a {
                    color: #666;
                    text-decoration: none;
                }

                    .mGrid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }
    </style>

    <div id="t-contenido">
        <div class="ui segment">
            <style type="text/css">
                .centrarImage {
                    margin-left: 50px;
                    width: 70px;
                    Height: 70px;
                }
            </style>
            <div class="ui form">
                <div class="field">
                    <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" GridLines="None" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" CssClass="mGrid" DataKeyNames="IdItemCarrito,IdPrestacionArticulo" OnRowDeleting="GvCarrito_RowDeleting" OnRowDataBound="GvCarrito_RowDataBound" OnRowUpdated="GvCarrito_RowUpdated" OnRowUpdating="GvCarrito_RowUpdating" OnRowEditing="GvCarrito_RowEditing" OnRowCancelingEdit="GvCarrito_RowCancelingEdit" ShowFooter="True">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Imagen">
                                <ItemTemplate>
                                    <asp:Image ID="ImgArticulo" runat="server" CssClass="centrarImage" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="LblNombrePresentacionArticulo" runat="server" Text="LblNombrePresentacionArticulo"></asp:Label>
                                    <br />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label ID="LblCantidad" runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DdlCantidad" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField FooterText="Total: " HeaderText="Precio">
                                <ItemTemplate>
                                    <asp:Label ID="LblPrecioUnitario" runat="server" Text="LblPrecioUnitario"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtotal">
                                <ItemTemplate>
                                    <asp:Label ID="LblSubtotal" runat="server" Text="LblSubtotal"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField DeleteText="Eliminar" HeaderText="Eliminar" ShowDeleteButton="True" />
                            <asp:CommandField HeaderText="Actualizar" SelectText="Actualizar" ShowEditButton="True" EditText="Editar" />
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </div>
                <div class="field">
                    <asp:Label ID="LblMensajeAlertaExistenciasInsuficientes" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="Red" Text="LblMensajeAlertaExistenciasInsuficientes" Visible="False"></asp:Label>
                    <br />
                </div>
                <div class="field" style="width: 400px;">
                    <asp:Button CssClass="ui grey button" ID="BtnSeguirComprando" runat="server" OnClick="BtnSeguirComprando_Click" Text="Seguir Comprando" />
                    <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                    <div class="field">
                        <div class="ui buttons">
                            <div id="paypal-button" style="margin-top: 5%;"></div>
                            <div id="mercadopago-button" class="mercadopago-button" style="margin-top: 4%; margin-left: 3%;"></div>
                        </div>
                    </div>
                    <asp:Literal ID="LiteralMP" runat="server"></asp:Literal>
                    <asp:Literal ID="Literal1" Visible="false" runat="server"></asp:Literal>
                </div>
                <div class="field" style="width: 400px;">
                    <div class="ui buttons">
                        <asp:Button CssClass="ui red button" ID="BtnPayPal" runat="server" Text="Pagar con PayPal" OnClick="BtnPayPal_Click" Visible="False" />
                        <div class="or"></div>
                        <asp:Button CssClass="ui red button" ID="BtnMercadoPago" runat="server" Text="Pagar con MercadoPago" OnClick="BtnMercadoPago_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
