<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublica.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="WebPublica.Articulo" %>

<%@ Register Src="ControlesDeUsuario/WucFiltroArticulo.ascx" TagName="WucFiltroArticulo" TagPrefix="uc1" %>
<%@ Register Src="ControlesDeUsuario/WucImagenesArticulo.ascx" TagPrefix="uc1" TagName="WucImagenesArticulo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <uc1:WucImagenesArticulo runat="server" ID="WucImagenesArticulo" />
            <br />

            <label id="LblDescripcionBreve" runat="server"></label>
            <br />

            <label id="LblPrecio" runat="server"></label>
            <asp:HiddenField ID="HiddenFieldIdPresentacionArticulo" runat="server" />
            <br />

            <uc1:WucFiltroArticulo ID="WucFiltroArticulo1" runat="server" />
            <br />

            <asp:Button ID="BtnAnadirAlCarrito" runat="server" OnClick="BtnAnadirAlCarrito_Click" Text="Añadir al Carrito" />
            <br />

            <asp:TextBox ID="TxtCantidad" runat="server" Width="242px">1</asp:TextBox>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
