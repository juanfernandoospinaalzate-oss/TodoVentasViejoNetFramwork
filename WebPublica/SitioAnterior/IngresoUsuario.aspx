<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="IngresoUsuario.aspx.cs" Inherits="WebPublica.IngresoUsuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/ControlesDeUsuario/WucPaisDepartamentoCiudad.ascx" TagName="WucPaisDepartamentoCiudad" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <style type="text/css">
        .auto-style2 {
        }

        .auto-style3 {
        }

        .auto-style5 {
            width: 342px;
        }

        .MuyPobre {
            background-color: red;
        }

        .Debil {
            background-color: orange;
        }

        .Promedio {
            background-color: yellow;
        }

        .PocoFuerte {
            background-color: #E8F403;
        }

        .Excelente {
            background-color: green;
        }

        .Borde {
            border: solid thin #000000;
            width: 300px;
            height: 100px;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <table style="width: 425px; height: 399px;">
                <tr>
            <td class="auto-style3">
                <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtNombre" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtApellido" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtApellido" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblTelefono1" runat="server" Text="Teléfono Fijo"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtTelefono1" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTelefono1" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblTelefono2" runat="server" Text="Teléfono Móvil"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtTelefono2" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtTelefono2" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblEmail" runat="server" Text="Correo Electrónico"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtEmail" runat="server" Width="293px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtContrasena" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                <asp:PasswordStrength ID="TxtContrasena_PasswordStrength" runat="server" TargetControlID="TxtContrasena" ViewStateMode="Enabled" StrengthIndicatorType="BarIndicator" PrefixText="Seguridad: " RequiresUpperAndLowerCaseCharacters="True" TextStrengthDescriptions="Muy Pobre; Débil; Promedio; Poco Fuerte; Excelente" TextStrengthDescriptionStyles="MuyPobre; Debil; Promedio; PocoFuerte; Excelente" BarBorderCssClass="Borde" PreferredPasswordLength="6" MinimumNumericCharacters="1" MinimumLowerCaseCharacters="1" MinimumUpperCaseCharacters="1">
                </asp:PasswordStrength>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblRepetirContrasena" runat="server" Text="Repetir Contraseña"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtConfirmarContrasena" runat="server" Height="18px" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtConfirmarContrasena" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblNomDestinatario" runat="server" Text="Nombre Destinatario"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtNomDestinatario" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtNomDestinatario" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblDireccion" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtDireccion" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtTelefono" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label1" runat="server" Text="Identificación Cliente"></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="TxtIdCliente" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtIdCliente" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <uc1:WucPaisDepartamentoCiudad runat="server" ID="WucPaisDepartamentoCiudad" />
            </td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">
                <asp:Button ID="BtnRegistrar" runat="server" Text="Registrarse" Width="400px" OnClick="BtnRegistrar_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
    </table>--%>

    <!--|DIV "t-contenido" |-->
    <div id="t-contenido">
        <!--|DIV "tcontenedorproducto"|-->
        <div class="ui segment">

            <div class="ui form">
                <h4 class="ui dividing header">Datos de usuario</h4>

                <div class="two fields">
                    <div class="field">
                        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtNombre" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>

                    <div class="field">
                        <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="TxtApellido" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtApellido" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="two fields">
                    <div class="field">
                        <asp:Label ID="LblTelefono1" runat="server" Text="Telefono Fijo"></asp:Label>
                        <asp:TextBox ID="TxtTelefono1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtTelefono1" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>

                    <div class="field">
                        <asp:Label ID="LblTelefono2" runat="server" Text="Telefono Movil"></asp:Label>
                        <asp:TextBox ID="TxtTelefono2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtTelefono2" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="field">
                    <uc1:WucPaisDepartamentoCiudad runat="server" ID="WucPaisDepartamentoCiudad" />
                </div>

                <div class="field">
                    <asp:Label ID="LblEmail" runat="server" Text="Correo Electrónico"></asp:Label>
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>

                <div class="two fields">
                    <div class="field">
                        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="TxtContrasena" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:PasswordStrength ID="TxtContrasena_PasswordStrength" runat="server" TargetControlID="TxtContrasena" ViewStateMode="Enabled" StrengthIndicatorType="BarIndicator" PrefixText="Seguridad: " RequiresUpperAndLowerCaseCharacters="True" TextStrengthDescriptions="Muy Pobre; Débil; Promedio; Poco Fuerte; Excelente" TextStrengthDescriptionStyles="MuyPobre; Debil; Promedio; PocoFuerte; Excelente" BarBorderCssClass="Borde" PreferredPasswordLength="6" MinimumNumericCharacters="1" MinimumLowerCaseCharacters="1" MinimumUpperCaseCharacters="1">
                        </asp:PasswordStrength>
                    </div>

                    <div class="field">
                        <asp:Label ID="LblRepetirContrasena" runat="server" Text="Repetir Contraseña"></asp:Label>
                        <asp:TextBox ID="TxtConfirmarContrasena" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtConfirmarContrasena" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                </div>




                <div class="two fields">
                    <div class="field">
                        <asp:Label ID="Label1" runat="server" Text="Identificación Cliente"></asp:Label>
                        <asp:TextBox ID="TxtIdCliente" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtIdCliente" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>

                    <div class="field">
                        <asp:Label ID="LblNomDestinatario" runat="server" Text="Nombre Destinatario"></asp:Label>
                        <asp:TextBox ID="TxtNomDestinatario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtNomDestinatario" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                </div>


                <div class="two fields">
                    <div class="field">
                        <asp:Label ID="LblDireccion" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>

                    <div class="field">
                        <asp:Label ID="LblTelefono" runat="server" Text="Teléfono"></asp:Label>
                        <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                </div>


                

                <asp:Button CssClass="ui red button" ID="BtnRegistrar" runat="server" Text="Registrarse" TabIndex="0" OnClick="BtnRegistrar_Click" />

            </div>
        </div>
    </div>

    <!--|t-contenido|-->
<br /><br />
</asp:Content>

