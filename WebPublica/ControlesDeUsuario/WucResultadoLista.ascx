<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucResultadoLista.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucResultadoLista" %>


<div class="ui divider"></div>
<div class="item">
    <div class="ui center aligned basic segment">
        <div class="ui small image">
            <img src="" id="AspxImgArticulo" runat="server">
        </div>
        <div class="ui center aligned basic segment">
            <button class="ui circular big red icon button"><i class="heart icon"></i></button>
            <button class="ui circular big red icon button"><i class="add to cart icon"></i></button>
        </div>
    </div>
    <div class="ui left aligned basic segment">
        <a href="#" class="tituloproducto ui medium header">
            <asp:Literal ID="LitTituloArticulo" runat="server"></asp:Literal></a>
        <p class="precio ui medium header">
            $<asp:Literal ID="LitPrecioArticulo" runat="server"></asp:Literal>
        </p>
        <div class="description">
            <p><asp:Literal ID="LitDescripcionArticulo" runat="server"></asp:Literal></p>
        </div>
    </div>
</div>
