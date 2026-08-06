<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucImagenesArticulo.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucImagenesArticulo" %>
<script type="text/javascript">
    function CambiarImagen(UrlImagen) {
        document.getElementById("ContentPlaceHolder1_WucImagenesArticuloPgwSlider_ImagenPrincipal").src = UrlImagen;
    }
</script>
<%--ORIGINAL ANCHO DIV width:767.5px--%>
<div style="width:700px; float:right">
    <img alt="" src="imagen.jpg" id="Imagen1" style="width: 100px; height: 100px;" runat="server" onmouseover="CambiarImagen(this.src)" />
    <img alt="" src="imagen.jpg" id="Imagen2" style="width: 100px; height: 100px;" runat="server" onmouseover="CambiarImagen(this.src)" />
    <img alt="" src="imagen.jpg" id="Imagen3" style="width: 100px; height: 100px;" runat="server" onmouseover="CambiarImagen(this.src)" />
    <img alt="" src="imagen.jpg" id="Imagen4" style="width: 100px; height: 100px;" runat="server" onmouseover="CambiarImagen(this.src)" />
    <img alt="" src="imagen.jpg" id="Imagen5" style="width: 100px; height: 100px;" runat="server" onmouseover="CambiarImagen(this.src)" />
    <img alt="" src="imagen.jpg" id="Imagen6" style="width: 100px; height: 100px;" runat="server" onmouseover="CambiarImagen(this.src)" />
    <%--<img alt="" src="imagen.jpg" id="ImagenPrincipal" style="width: 400px; height: 400px;" runat="server" />--%>
    <div class="zoom-container">
        <img alt="" src="imagen.jpg" id="ImagenPrincipal" style="width: 400px; height: 400px;" runat="server" class="zoom-image" />
        <div id="zoomLens" class="zoom-lens"></div>
    </div>
</div>
