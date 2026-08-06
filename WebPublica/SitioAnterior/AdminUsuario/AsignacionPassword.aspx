<%@ Page Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="AsignacionPassword.aspx.cs" Inherits="WebPublica.SitioAnterior.AdminUsuario.AsignacionPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .cssColor {
            color: white !important;
        }
    </style>



    <div id="t-contenido">

        <asp:Panel ID="PanelMensaje" runat="server">
            <div class="ui green message">
                <asp:Label ID="LblResultadoOperacion" runat="server"></asp:Label>
            </div>
        </asp:Panel>

        <div class="ui very padded segment">
            <div class="ui two column middle aligned very relaxed stackable grid">

                <div class="column">

                    <div class="ui form">
                        <div class="field">

                            <asp:Label ID="LblNuevaContrasena" runat="server" Text="Nueva contraseña"></asp:Label>
                            <div class="ui left icon input">
                                <asp:TextBox ID="TxtPasswordNuevo" TextMode="Password" runat="server" autocomplete="on" onKeydown="Javascript: if(event.keyCode==13) {return false;}"></asp:TextBox><br />
                                <i class="user icon"></i>
                            </div>
                            <asp:Label ID="LblRepetirContrasena" runat="server" Text="Vuelva a escribir la contraseña"></asp:Label>
                            <div class="ui left icon input">
                                <asp:TextBox ID="TxtPasswordNuevoVerificacion" TextMode="Password"  runat="server" autocomplete="on" onKeydown="Javascript: if(event.keyCode==13) {return false;}"></asp:TextBox><br />
                                <i class="user icon"></i>
                            </div>
                            <asp:RequiredFieldValidator ID="RfvTxtPasswordNuevo" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TxtPasswordNuevo" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="ui red submit button">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="cssColor">Guadar</asp:LinkButton>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
    <br />
    <br />
    <br />

</asp:Content>
