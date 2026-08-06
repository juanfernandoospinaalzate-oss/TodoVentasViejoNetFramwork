<%@ Page Title="" Language="C#" MasterPageFile="~/SitioAnterior/AdminUsuario/PlantillaCuentaUsuario.Master" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="WebPublica.AdminUsuario.CambioPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 182px;
        }
        .auto-style2 {
            width: 182px;
            height: 29px;
        }
        .auto-style3 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 45%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="LblPswdActual" runat="server" Text="Contraseña Actual"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtPswdActual" runat="server" Height="21px" Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="LblPswdNueva" runat="server" Text="Nueva Contraseña"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtPswdNueva" runat="server" Height="16px" Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LblPswdConfirmar" runat="server" Text="Confirmar Contraseña"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TxtPswdConfirmar" runat="server" Height="19px" Width="270px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="BtnCambiarContrasena" runat="server" OnClick="BtnCambiarContrasena_Click" Text="Cambiar Contraseña" Width="275px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
