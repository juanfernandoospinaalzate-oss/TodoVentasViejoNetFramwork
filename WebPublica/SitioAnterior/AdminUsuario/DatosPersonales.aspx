<%@ Page Title="" Language="C#" MasterPageFile="~/SitioAnterior/AdminUsuario/PlantillaCuentaUsuario.Master" AutoEventWireup="true" CodeBehind="DatosPersonales.aspx.cs" Inherits="WebPublica.AdminUsuario.DatosPersonales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 155px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 30%;">
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>
            <asp:Label ID="LblUser" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblDocCliente" runat="server" Text="Documento Cliente"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtDocCliente" runat="server" Height="20px" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtNombre" runat="server" Height="20px" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtApellido" runat="server" Height="20px" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblTelefono1" runat="server" Text="Teléfono Fijo"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtTelefono1" runat="server" Height="20px" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblTelefono2" runat="server" Text="Teléfono Móvil"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtTelefono2" runat="server" Height="20px" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Label ID="LblEmail" runat="server" Text="Correo Electrónico"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TxtEmail" runat="server" Height="20px" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="BtnEditar" runat="server" Height="23px" OnClick="BtnEditar_Click" style="margin-bottom: 0px" Text="Editar" Width="140px" />
        </td>
        <td>
            <asp:Button ID="BtnGuardar" runat="server" Height="22px" OnClick="BtnGuardar_Click" Text="Guardar" Width="255px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style1">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
