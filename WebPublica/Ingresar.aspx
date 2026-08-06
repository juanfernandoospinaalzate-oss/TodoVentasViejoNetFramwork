<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="WebPublica.Ingresar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="t-contenido">
        <div class="ui very padded segment">
            <div class="ui two column middle aligned very relaxed stackable grid">
                <div class="column">
                    <asp:Label ID="LblMensaje" runat="server" Text="LblMensaje" ForeColor="Red" EnableViewState="false"></asp:Label>
                    <div class="ui form">
                        <div class="field">
                            <asp:Label ID="LblNombreDeUsuario" runat="server" Text="Nombre de Usuario / Email"></asp:Label>
                            <div class="ui left icon input">
                                <asp:TextBox ID="TxtNombreDeUsuario" runat="server" autocomplete="on" onKeydown="Javascript: if(event.keyCode==13) {return false;}"></asp:TextBox><br />
                                <i class="user icon"></i>
                            </div>
                            <asp:RequiredFieldValidator ID="RfvTxtNombreDeUsuario" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TxtNombreDeUsuario" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="field">
                            <asp:Label ID="LblContrasena" runat="server" Text="Contraseña"></asp:Label>
                            <div class="ui left icon input">
                                <asp:TextBox ID="TxtContrasena" TextMode="Password" runat="server" onKeydown="Javascript: if(event.keyCode==13) {document.getElementById('ContentPlaceHolder1_LinkButtonIngresar').click(); return false/*return; permite el correcto postback, no borrar*/;}"></asp:TextBox>
                                <i class="lock icon"></i>
                            </div>
                            <asp:RequiredFieldValidator ID="RfvTxtContrasena" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TxtContrasena" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="ui red submit button">
                            <asp:LinkButton ID="LinkButtonIngresar" runat="server" ForeColor="White" OnClick="LinkButtonIngresar_Click" Text="LinkButtonIngresar"></asp:LinkButton></div>
                        <asp:LinkButton ID="LinkButtonRecuperarClave" runat="server" OnClick="LinkButtonRecuperarClave_Click" CausesValidation="False">¿Olvidaste la contraseña?</asp:LinkButton>

                    </div>
                </div>
                <div class="ui vertical divider">
                    o
                </div>
                <div class="center aligned column">
                    <div class="ui big red labeled icon button">
                        <i class="add user icon"></i>
                        <asp:LinkButton ID="LinkButtonRegistro" runat="server" ForeColor="White" CausesValidation="false" Text="LinkButtonRegistro" OnClick="LinkButtonRegistro_Click"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br>
    <br>
</asp:Content>



