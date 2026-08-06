<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucLoginStatus.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucLoginStatus" %>
<asp:MultiView ID="MultiView1" runat="server">

    <asp:View ID="View1" runat="server">

        <asp:HyperLink runat="server" CssClass="ui item">
            <i class="ui red circular inverted privacy icon"></i>
            <asp:Label ID="LblInvitado" runat="server" Text="Bienvenido Invitado" CssClass="ui item"></asp:Label>
        </asp:HyperLink>

        <asp:HyperLink ID="LinkInicioSesion" runat="server" NavigateUrl="~/Ingresar.aspx" CssClass="ui item" Text="">
            <i class="ui red circular inverted privacy icon"></i>
            <asp:Label ID="LblIniciarSesion" CssClass="ui item" runat="server" Text="Iniciar Sesión"></asp:Label>
        </asp:HyperLink>

        <asp:HyperLink ID="LinkInscripcion" runat="server" NavigateUrl="~/Registro.aspx" class="ui item">
            <i class="ui red circular inverted user icon"></i>
            <asp:Label ID="lBLRegistrarse" CssClass="ui item" runat="server" Text="Registrarse"></asp:Label>
        </asp:HyperLink>

    </asp:View>

    <asp:View ID="View2" runat="server">

        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="ui item">
            <i class="ui red circular inverted user icon"></i>
            <asp:Label ID="LblMensajeBienvenida" runat="server" Text="Bienvenida" CssClass="ui item"></asp:Label>
            <asp:Label ID="LblNombreCliente" runat="server" Text="Nombre del cliente" CssClass="ui item"></asp:Label>
        </asp:HyperLink>

        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="ui item">
            <i class="ui red circular inverted user icon"></i>
            <asp:LinkButton ID="LnkBtnCerrarSesion" CssClass="ui item" runat="server" OnClick="LnkBtnCerrarSesion_Click" class="ui item">Cerrar Sesion</asp:LinkButton>
        </asp:HyperLink>

    </asp:View>
</asp:MultiView>