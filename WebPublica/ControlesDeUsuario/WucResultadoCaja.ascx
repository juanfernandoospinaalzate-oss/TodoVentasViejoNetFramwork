<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucResultadoCaja.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucResultadoCaja" %>

<div id="WucResultadoCajaDivColumnaVistaPreviaProducto" class="left aligned column">
    <a href="" id="AspxLinkImgArticulo" runat="server" style="border:0">
        <img class="ui fluid bordered image" src="" id="AspxImgArticulo" runat="server">
    </a>
    <h2 id="WucResultadoCajaH2TituloArticulo" class="tituloproducto ui medium header" style="margin-top:0px; margin-bottom:0px;">
        <asp:Literal ID="LitTituloArticulo" runat="server"></asp:Literal>
    </h2>
    <h3 class="precio ui medium header" style="margin-top:0px; margin-bottom:0px;">
        <asp:Literal ID="LitPrecioArticulo" runat="server"></asp:Literal>
    </h3>
    <p id="WucResultadoCajaPDescripcionArticulo" class="descripcion small header" style="margin-bottom:0px;">
        <asp:Literal ID="LitDescripcionArticulo" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="LitFechaVencimiento" runat="server"></asp:Literal>
    </p>
    <div class="ui red divider"></div>
</div>
