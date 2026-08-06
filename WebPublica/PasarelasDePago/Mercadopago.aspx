<%@ Page Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="Mercadopago.aspx.cs" Inherits="WebPublica.PasarelasDePago.Mercadopago" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../ControlesDeUsuario/WucPaisDepartamentoCiudad.ascx" TagName="WucPaisDepartamentoCiudad" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="t-contenido">
        <br />
        <div class="ui segment">
            <div class="ui form">
                <h3 class="ui dividing header">
                    <asp:Label ID="LblTitulo" runat="server" Text="Página MercadoPago"></asp:Label>
                </h3>
                <div>
                    <div class="field">

                        <div class="two fields">
                            <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" DataKeyNames="IdItemCarrito,IdPrestacionArticulo" OnRowDataBound="gvCarrito_RowDataBound" EnableViewState="False">
                                <Columns>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCantidad" runat="server" Text="LblCantidad"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio Unitario">
                                        <ItemTemplate>
                                            <asp:Label ID="LblPrecioUnitario" runat="server" Text="LblPrecioUnitario"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubTotal">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSubTotal" runat="server" Text="LblSubTotal"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                        </div><br /><br />
                        <asp:Panel ID="PanelFormularioClienteDestinatario" runat="server">
                            <h4 class="ui dividing header">Datos del cliente</h4>
                            <div class="ui two fields">
                                <div class="field">
                                    <div class="field">
                                        <asp:Label ID="LblDocIdentificacion" runat="server" Text="Documento de Identificación "></asp:Label>
                                        <asp:TextBox ID="TxtDocIdentificacion" runat="server" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtDocIdentificacion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RevDocIdentificacion" runat="server" ErrorMessage="Debe ser numérico" ValidationExpression="^[1-9]\d*$" ControlToValidate="TxtDocIdentificacion" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <br />
                                    </div>
                                    <div class="field">
                                        <asp:Label ID="LblNombre" runat="server" Text="Nombre(s) "></asp:Label>
                                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    </div>
                                    <div class="field">
                                        <asp:Label ID="LblApellidos" runat="server" Text="Apellidos "></asp:Label>
                                        <asp:TextBox ID="TxtApellidos" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtApellidos" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    </div>
                                </div>
                                <div class="field">
                                    <div class="field">
                                        <asp:Label ID="LblTelefonoUno" runat="server" Text="Teléfono Principal "></asp:Label>
                                        <asp:TextBox ID="TxtTelefonoUno" runat="server" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtTelefonoUno" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    </div>
                                    <div class="field">
                                        <asp:Label ID="LblTelefonoDos" runat="server" Text="Teléfono Secundario "></asp:Label>
                                        <asp:TextBox ID="TxtTelefonoDos" runat="server" MaxLength="10"></asp:TextBox>
                                        <br />
                                    </div>
                                    <div class="field">
                                        <asp:Label ID="LblEmail" runat="server" Text="Correo electrónico "></asp:Label>
                                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Email no válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <h4 class="ui dividing header">Datos del destinatario</h4>
                            <div class="two fields">
                                <div class="field">
                                    <asp:Label ID="LblNomDestinatario" runat="server" Text="Nombre Destinatario"></asp:Label>
                                    <asp:TextBox ID="TxtNomDestinatario" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvTxtNomDestinatario" runat="server" ControlToValidate="TxtNomDestinatario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    <uc1:WucPaisDepartamentoCiudad ID="WucPaisDepartamentoCiudad1" runat="server" />
                                    <br />
                                    <br />
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
                        <asp:Panel ID="PanelSeleccionAdminDirecciones" runat="server">
                            <h4 class="ui dividing header">Dirección de envío</h4>                            
                            <div class="ui two fields">
                                <div class="field">
                                    <asp:DropDownList ID="DdlDirecciones" runat="server"></asp:DropDownList>
                                </div>
                                <div class="field">
                                    <asp:Button CssClass="ui red button" ID="BtnRedirectPageDirecciones" runat="server" Text="Agregar dirección" OnClick="BtnRedirectPageDirecciones_Click" />
                                </div>
                            </div><br /><br />
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
                        <div class="ui buttons">                            
                            <asp:Button CssClass="ui red button" ID="BtnConfirmacionPagoMercadoPago" runat="server" Text="Pagar con MercadoPago" OnClick="BtnConfirmacionPagoMercadoPago_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
