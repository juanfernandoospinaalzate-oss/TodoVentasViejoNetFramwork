<%@ Page Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="Paypal.aspx.cs" Inherits="WebPublica.PasarelasDePago.Paypal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlesDeUsuario/WucPaisDepartamentoCiudad.ascx" TagPrefix="uc1" TagName="WucPaisDepartamentoCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="t-contenido">
        <br />
        <div class="ui segment">

            <div class="ui form">
                <h3 class="ui dividing header">
                    <asp:Label ID="LblTitulo" runat="server" Text="Página Paypal"></asp:Label>
                </h3>
                <div>
                    <div class="field">
                        <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" DataKeyNames="IdItemCarrito,IdPrestacionArticulo">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" />
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Panel ID="Panel1" runat="server">
                            <h4 class="ui dividing header">Datos del cliente</h4>
                            <div class="ui two fields">
                                <div class="field">
                                    <div class="field">
                                        <asp:Label ID="LblDocIdentificacion" runat="server" Text="Documento de Identificación "></asp:Label>
                                        <asp:TextBox ID="TxtDocIdentificacion" runat="server" MaxLength="10"></asp:TextBox>
                                    </div>
                                    <div class="field">
                                        <asp:Label ID="LblNombre" runat="server" Text="Nombre(s) "></asp:Label>
                                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="field">
                                        <asp:Label ID="LblApellidos" runat="server" Text="Apellidos "></asp:Label>
                                        <asp:TextBox ID="TxtApellidos" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="field">
                                    <div class="field">
                                        <asp:Label ID="LblTelefonoUno" runat="server" Text="Teléfono Principal "></asp:Label>
                                        <asp:TextBox ID="TxtTelefonoUno" runat="server" MaxLength="10"></asp:TextBox>
                                    </div>

                                    <div class="field">
                                        <asp:Label ID="LblTelefonoDos" runat="server" Text="Teléfono Secundario "></asp:Label>
                                        <asp:TextBox ID="TxtTelefonoDos" runat="server" MaxLength="10"></asp:TextBox>
                                    </div>

                                    <div class="field">
                                        <asp:Label ID="LblEmail" runat="server" Text="Correo electrónico "></asp:Label>
                                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <h4 class="ui dividing header">Datos del destinatario</h4>
                            <div class="ui two fields">
                                <div class="field">
                                    <asp:Label ID="LblNomDestinatario" runat="server" Text="Nombre Destinatario"></asp:Label>
                                    <asp:TextBox ID="TxtNomDestinatario" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvTxtNomDestinatario" runat="server" ControlToValidate="TxtNomDestinatario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                                    <uc1:WucPaisDepartamentoCiudad runat="server" ID="WucPaisDepartamentoCiudad" />
                                    <br />
                                    <br />
                                    <br />
                                </div>
                              <div class="field">
                                    <asp:Label ID="LblDireccion" runat="server" Text="Direccion"></asp:Label>
                                    <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvTxtDireccion" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                                    <asp:Label ID="LblTelefonoDestinatario" runat="server" Text="Teléfono"></asp:Label>
                                    <asp:TextBox ID="TxtTelefonoDestinatario" runat="server" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvTxtTelefonoDestinatario" runat="server" ControlToValidate="TxtTelefonoDestinatario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server">
                            <h4 class="ui dividing header">Dirección de envío</h4>
                            <div class="ui two fields">

                                <div class="field">
                                    <asp:DropDownList ID="DdlDirecciones" runat="server"></asp:DropDownList>
                                </div>

                                <div class="field">
                                    <asp:Button CssClass="ui red button" ID="BtnRedirectPageDirecciones" runat="server" Text="Agregar dirección" OnClick="BtnRedirectPageDirecciones_Click"  />
                                </div>
                            </div>
                            <br />
                            <br />
                        </asp:Panel>
                        <style>
                            .ClassJoined {
                                font-weight: normal;
                                font-size: 50px;
                                color: darkcyan;
                            }
                        </style>
                        <div class="field" style="text-align: end; margin-top: -7%; margin-right: 1%">
                            <asp:Label ID="LblTotal" CssClass="ClassJoined" runat="server" Text="Label"></asp:Label><br />
                        </div>
                        <br />
                        <div>
                            <asp:Button CssClass="ui red button" ID="BtnConfirmacionPayPal" runat="server" Text="Pagar con PayPal" OnClick="BtnConfirmacionPayPal_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
