<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebPublica.Registro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlesDeUsuario/WucPaisDepartamentoCiudad.ascx" TagPrefix="uc1" TagName="WucPaisDepartamentoCiudad" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--|DIV "t-contenido" - JORGE HURTADO|-->
    <div id="t-contenido">
        <br>
        <!--|DIV "tcontenedorproducto" - JORGE HURTADO|-->
        <div class="ui segment">

            <div class="ui form">
                <h4 class="ui dividing header">
                    <asp:Label ID="LblDatosUsuario" runat="server" Text="Datos de usuario"></asp:Label>
                </h4>
                <div style="text-align:center">
                    <asp:Label ID="LblMensaje" runat="server" Text="LblMensaje" ForeColor="Red" EnableViewState="false"></asp:Label>
                </div>
                

                <div class="ui two fields">
                    <div class="field">

                        <asp:Label ID="LblIdentificacion" runat="server" Text="Identificación Cliente"></asp:Label>
                        <asp:TextBox ID="TxtIdCliente" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvLblIdentificacion" runat="server" ControlToValidate="TxtIdCliente" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtNombre" runat="server" ControlToValidate="TxtNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                        <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtApellido" runat="server" ControlToValidate="TxtApellido" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                        <uc1:WucPaisDepartamentoCiudad runat="server" ID="WucPaisDepartamentoCiudad" />
                    </div>

                    <div class="field">


                        <asp:Label ID="LblEmail" runat="server" Text="Correo Electrónico"></asp:Label>
                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RfvTxtEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                        <asp:Label ID="LblContrasena" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="TxtContrasena" runat="server" TextMode="Password">123456+-</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtContrasena" runat="server" ControlToValidate="TxtContrasena" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                        <asp:PasswordStrength ID="TxtContrasena_PasswordStrength" runat="server" TargetControlID="TxtContrasena"></asp:PasswordStrength>

                        <asp:Label ID="LblConfirmarContrasena" runat="server" Text="Repetir Contraseña"></asp:Label>
                        <asp:TextBox ID="TxtConfirmarContrasena" runat="server" TextMode="Password">123456+-</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtConfirmarContrasena" runat="server" ControlToValidate="TxtConfirmarContrasena" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                        <asp:CompareValidator ID="CvTxtContrasenaTxtConfirmarContrasena" runat="server" ErrorMessage="*" ControlToCompare="TxtContrasena" ControlToValidate="TxtConfirmarContrasena" Operator="Equal" ForeColor="Red"></asp:CompareValidator>
                        <br />

                        <asp:Label ID="LblTelefono1" runat="server" Text="Telefono Fijo"></asp:Label>
                        <asp:TextBox ID="TxtTelefono1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtTelefono1" runat="server" ControlToValidate="TxtTelefono1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                        <asp:Label ID="LblTelefono2" runat="server" Text="Telefono Movil"></asp:Label>
                        <asp:TextBox ID="TxtTelefono2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtTelefono2" runat="server" ControlToValidate="TxtTelefono2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    </div>
                </div>

                <h4 class="ui dividing header">Datos de un destinatario</h4>
                <div class="two fields">

                    <div class="field">
                        <asp:Label ID="LblNomDestinatario" runat="server" Text="Nombre Destinatario"></asp:Label>
                        <asp:TextBox ID="TxtNomDestinatario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtNomDestinatario" runat="server" ControlToValidate="TxtNomDestinatario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />

                        <asp:Label ID="LblTelefonoDestinatario" runat="server" Text="Teléfono"></asp:Label>
                        <asp:TextBox ID="TxtTelefonoDestinatario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtTelefonoDestinatario" runat="server" ControlToValidate="TxtTelefonoDestinatario" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    </div>

                    <div class="field">
                        <asp:Label ID="LblDireccion" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvTxtDireccion" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    </div>

                </div>



                <%--<h4 class="ui dividing header">Datos de pago</h4>--%>
                <%--                <div class="field">
                    <label>Tipo de tarjeta</label>
                    <div class="ui selection dropdown">
                        <input type="hidden" name="card[type]">
                        <div class="default text">Selecciona</div>
                        <i class="dropdown icon"></i>
                        <div class="menu">
                            <div class="item" data-value="visa">
                                <i class="visa icon"></i>
                                Visa
             
                            </div>
                            <div class="item" data-value="amex">
                                <i class="amex icon"></i>
                                American Express
             
                            </div>
                            <div class="item" data-value="discover">
                                <i class="discover icon"></i>
                                Discover
             
                            </div>
                        </div>
                    </div>
                </div>
                <div class="fields">
                    <div class="seven wide field">
                        <label>Número de tarjeta</label>
                        <input type="text" name="card[number]" maxlength="16" placeholder="Tarjeta #">
                    </div>
                    <div class="three wide field">
                        <label>CVC</label>
                        <input type="text" name="card[cvc]" maxlength="3" placeholder="CVC">
                    </div>
                    <div class="six wide field">
                        <label>Expira el:</label>
                        <div class="two fields">
                            <div class="field">
                                <select class="ui fluid search dropdown" name="card[expire-month]">
                                    <option value="">Mes</option>
                                    <option value="1">Enero</option>
                                    <option value="2">Febrero</option>
                                    <option value="3">Marzo</option>
                                    <option value="4">Abril</option>
                                    <option value="5">Mayo</option>
                                    <option value="6">Junio</option>
                                    <option value="7">Julio</option>
                                    <option value="8">Agosto</option>
                                    <option value="9">Septiembre</option>
                                    <option value="10">Octubre</option>
                                    <option value="11">Noviembre</option>
                                    <option value="12">Diciembre</option>
                                </select>
                            </div>
                            <div class="field">
                                <input type="text" name="card[expire-year]" maxlength="4" placeholder="Año">
                            </div>
                        </div>
                    </div>
                </div>

                <div class="ui segment">
                    <div class="field">
                        <div class="field">
                            <div class="ui toggle checkbox">
                                <input type="checkbox" name="public">
                                <label>Dirección de facturación igual a la de envío</label>
                            </div>
                        </div>
                    </div>
                </div>--%>
                <%--<div class="ui red button" tabindex="0">Crear usuario</div>--%>
                <asp:Button CssClass="ui red button" ID="BtnRegistrar" runat="server" Text="Registrarse" TabIndex="0" OnClick="BtnRegistrar_Click" />
            </div>

        </div>

    </div>
    <!--|t-contenido|-->
    <br>
    <br>
</asp:Content>
