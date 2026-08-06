<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucCarruselArtEst.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucCarruselArtEst" %>

<div class="left aligned column">
    <img class="ui fluid bordered image" src="files/images/productos/buzo01.jpg">
    <a href="#" class="tituloproducto ui medium header"><asp:Literal ID="LitTituloArticulo" runat="server"></asp:Literal></a>
    <p class="descripcion small header"><asp:Literal ID="LitDescripcionArticulo" runat="server"></asp:Literal></p>
    <p class="precio ui medium header"><asp:Literal ID="LitPrecioArticulo" runat="server"></asp:Literal></p>
    <div class="ui red divider"></div>
    <div class="ui center aligned container">
        <button class="ui red big circular icon button"><i class="heart icon"></i></button>
        <button class="ui red big circular icon button"><i class="add to cart icon"></i></button>
    </div>
</div>

