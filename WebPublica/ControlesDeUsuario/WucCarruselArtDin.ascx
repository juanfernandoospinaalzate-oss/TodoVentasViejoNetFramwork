<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucCarruselArtDin.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucCarruselArtDin" %>




<li>
    <img class="ui fluid bordered image" src="" ID="AspxImgArticulo" runat="server">
    <a href="#" class="tituloproducto ui medium header">
        <asp:Literal ID="LitTituloArticulo" runat="server"></asp:Literal></a>
    <p class="descripcion small header">
        <asp:Literal ID="LitDescripcionArticulo" runat="server"></asp:Literal></p>
    <p class="precio ui medium header">
        <asp:Literal ID="LitPrecioArticulo" runat="server"></asp:Literal></p>
</li>


