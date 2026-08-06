<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucPaisDepartamentoCiudad.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucPaisDepartamentoCiudad" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="field">
            <asp:Label ID="LblPaís" runat="server" Text="País"></asp:Label>
            <asp:DropDownList ID="DdlPais" runat="server" Height="20%" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="DdlPais_SelectedIndexChanged"></asp:DropDownList>

            <asp:Label ID="LblDepartamento" runat="server" Text="Departamento"></asp:Label>
            <asp:DropDownList ID="DdlDepartamento" runat="server" Height="20%" Width="100%" OnSelectedIndexChanged="DdlDepartamento_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>


            <asp:Label ID="LblCiudad" runat="server" Text="Ciudad"></asp:Label>
            <asp:DropDownList ID="DdlCiudad" runat="server" Height="20%" Width="100%" AutoPostBack="True"></asp:DropDownList>


        </div>
        <%--CssClass="ui fluid selection dropdown"--%>

        <%--<table>
            <tr>
                <td>
                    <asp:Label ID="LblPaís" runat="server" Text="País"></asp:Label>
                    <asp:DropDownList ID="DdlPais" runat="server" Height="20px" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="DdlPais_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblDepartamento" runat="server" Text="Departamento"></asp:Label>
                    <asp:DropDownList ID="DdlDepartamento" runat="server" Height="20px" Width="250px" OnSelectedIndexChanged="DdlDepartamento_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblCiudad" runat="server" Text="Ciudad"></asp:Label>
                    <asp:DropDownList ID="DdlCiudad" runat="server" CssClass="ui fluid selection dropdown" Height="20%" Width="100%" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
        </table>--%>
    </ContentTemplate>
</asp:UpdatePanel>
