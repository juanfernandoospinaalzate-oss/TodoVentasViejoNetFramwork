<%@ Page Title="" Language="C#" MasterPageFile="~/PlantillaPublicaDetalleArticulo.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="WebPublica.DetalleArticulo" %>

<%@ Register Src="~/ControlesDeUsuario/WucFiltroArticulo.ascx" TagPrefix="uc1" TagName="WucFiltroArticulo" %>
<%@ Register Src="~/ControlesDeUsuario/WucImagenesArticulo.ascx" TagPrefix="uc1" TagName="WucImagenesArticulo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
      .zoom-container {
        position: relative;
        overflow: hidden;
        width: 400px;
        height: 400px;
      }

      .zoom-image {
        width: 100%;
        height: 100%;
        object-fit: contain;
      }

      .zoom-lens {
        position: absolute;
        border: 2px solid #000;
        width: 500px;
        height: 500px;
        visibility: hidden;
        pointer-events: none;
        background-repeat: no-repeat;
        background-size: 800px 800px; /* Tamaño real de tu imagen */
        z-index: 100;
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DisplayAfter="5">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <style type="text/css">
                .EstiloModalPopupExtender {
                    background-color: black;
                    filter: alpha(opacity=90);
                    opacity: 0.8;
                }

                .EstiloPanelActualizando {
                    background-color: white;
                    border-width: 3px;
                    border-style: solid;
                    border-color: black;
                    /*padding-top: 5px;
                    padding-left: 5px;*/
                    width: 106px;
                    height: 106px;
                }
            </style>
            <asp:ModalPopupExtender ID="UpdateProgress1_ModalPopupExtender" BackgroundCssClass="EstiloModalPopupExtender" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="UpdateProgress1" PopupControlID="PanelActualizando">
            </asp:ModalPopupExtender>
            <script>
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

                function beginReq(sender, args) {
                    // muestra el popup
                    $find('ContentPlaceHolder1_UpdateProgress1_ModalPopupExtender').show();
                }

                function endReq(sender, args) {
                    // esconde el popup
                    $find('ContentPlaceHolder1_UpdateProgress1_ModalPopupExtender').hide();
                }
            </script>
            <!--|DIV "t-contenido" - JORGE HURTADO|-->
            <asp:HiddenField ID="HiddenFieldIdPresentacionArticulo" runat="server" />
            <div id="t-contenido">

                <!--|DIV "tcontenedorproducto" - JORGE HURTADO|-->
                <div id="tcontenedorproducto" class="ui stackable grid">

                    <uc1:WucImagenesArticulo runat="server" ID="WucImagenesArticuloPgwSlider"/>
                    <%--<uc1:WucImagenesArticulo01 runat="server" ID="WucImagenesArticuloPgwSlider" />--%>

                    <!--|t-imagenesproducto|-->
                    <!--|DIV "t-operacionesproducto" - JORGE HURTADO|-->
                    <div id="t-operacionesproducto" class="ui six wide column">
                        <h1>
                            <asp:Literal ID="LitTituloArticulo" runat="server"></asp:Literal>
                        </h1>
                        <h2 class="ui small header">
                            <asp:Literal ID="LitDescripcionCortaArticulo" runat="server"></asp:Literal>
                        </h2>
                        <h3 class="ui red large tag label">
                            <asp:Literal ID="LitPrecioArticulo" runat="server"></asp:Literal>
                        </h3>
                        <div class="ui divider"></div>
                        <uc1:WucFiltroArticulo runat="server" ID="WucFiltroArticulo1" />
                        <div class="ui divider"></div>

                        <asp:UpdatePanel ID="UpdatePanelBotonesCantidad" runat="server">
                            <ContentTemplate>
                                <h3 class="ui red large tag label" runat="server" id="H3Cantidad">
                                    <asp:Literal ID="LiteralCantidad" runat="server" Text="Cantidad: "></asp:Literal>
                                    <asp:Label ID="LblMensajeCantidad" runat="server" Visible="false"></asp:Label>
                                </h3>
                                <asp:DropDownList ID="DdlCantidad" runat="server"></asp:DropDownList>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="ui divider"></div>
                        <div class="ui left aligned container">
                            <%--<button  class="ui red icon fluid button" OnClick="BtnAniadirAlCarrito_Click"><i class="add to cart icon"></i>Agregar al carrito </button>--%>
                            <asp:Button CssClass="ui red icon fluid button" ID="BtnAniadirAlCarrito" runat="server" OnClick="BtnAniadirAlCarrito_Click" Text="Añadir al carrito" />
                        </div>
                        <br />

                        <div class="ui left aligned container">
                            <%--<button class="ui red circular icon button"><i class="heart icon"></i></button>--%>
                            <button runat="server" id="BtnFacebook" class="ui circular facebook icon button"><i class="facebook icon"></i></button>
                            <button runat="server" id="BtnGooglePlus" class="ui circular google plus icon button"><i class="google plus icon"></i></button>
                            <button runat="server" id="BtnTwitter" class="ui circular twitter icon button"><i class="twitter icon"></i></button>
                            <%--<button class="ui circular pinterest icon button"><i class="pinterest icon"></i></button>
                            <button class="ui circular instagram icon button"><i class="instagram icon"></i></button>--%>
                        </div>
                        <div class="ui divider"></div>
                    </div>
                    <!--|t-operacionesproducto|-->
                </div>
                <!--|t-contenedorproducto|-->
                <div class="ui basic segment">
                    <div class="ui three top attached buttons">
                        <div class="ui red button active"><i class="browser icon"></i>Descripción</div>
                    </div>
                    <div class="ui bottom attached segment active">
                        <p>
                            <asp:Literal ID="LitDescripcionArticulo" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>

            <!--|t-contenido|-->
            <br>
            <br>
            <asp:Panel ID="PanelActualizando" runat="server" CssClass="EstiloPanelActualizando">
                <asp:Image ID="ImgActualizando" runat="server" ImageUrl="~/Graficas/cargando_01.gif" Width="100px" Height="100px" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
      const img = document.querySelector('#ContentPlaceHolder1_WucImagenesArticuloPgwSlider_ImagenPrincipal');
      const lens = document.getElementById('zoomLens');

      img.addEventListener('mousemove', moveLens);
      img.addEventListener('mouseenter', () => lens.style.visibility = 'visible');
      img.addEventListener('mouseleave', () => lens.style.visibility = 'hidden');

      function moveLens(e) {
        const rect = img.getBoundingClientRect();
        const x = e.clientX - rect.left;
        const y = e.clientY - rect.top;

        const lensWidth = lens.offsetWidth;
        const lensHeight = lens.offsetHeight;

        // Centra la lupa en el puntero
        const lensX = x - lensWidth / 2;
        const lensY = y - lensHeight / 2;

        // Posiciona la lupa
        lens.style.left = `${lensX}px`;
        lens.style.top = `${lensY}px`;

        // Mueve el fondo para hacer el efecto de zoom
        const bgPosX = -(x * 2 - lensWidth / 2);
        const bgPosY = -(y * 2 - lensHeight / 2);
        lens.style.backgroundPosition = `${bgPosX}px ${bgPosY}px`;

        // Establece la imagen como fondo
        lens.style.backgroundImage = `url('${img.src}')`;
      }
    </script>

</asp:Content>
