<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucFooter.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucFooter" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div id="footer">
            <div class="ui stackable grid">
                <div class="grey five wide column">
                    <h3>
                        <i class="info circle icon"></i>
                        Servicio al cliente
                    </h3>
                    <div class="ui divider"></div>
                    <div class="ui fluid">
                        <h5 class="ui inverted title">
                            <img runat="server" id="ImgSkype" style="width: 25px; height: 25px;" src="Graficas/Iconos/skype_logo.jpg" />
                            Atención Skype
                            <br/>
                            <asp:Label ID="LblAtencionSkype" runat="server"></asp:Label>
                        </h5>
                        <h5 class="ui inverted title">
                            <img runat="server" id="ImgTelefono" style="width: 25px; height: 25px;" src="Graficas/Iconos/telefono_logo.jpg" />
                            Línea telefónica<br/>
                            <asp:Label ID="LblLineaTelefonica" runat="server"></asp:Label>
                        </h5>
                        <h5 class="ui inverted title">
                            <img runat="server" id="ImgWhatsapp" style="width: 25px; height: 25px;" src="Graficas/Iconos/WhatsapLogo.png" />
                            Línea celular Whatsapp<br/>
                            <a id="LinkLineaCelularWhatsapp" href="#" runat="server" style="color:white" target="_blank">
                                <asp:Label ID="LblLineaCelular" runat="server"></asp:Label>
                            </a>
                        </h5>
                        <h5 class="ui inverted title">
                            <img runat="server" id="ImgEmail" style="width: 25px; height: 25px;" src="Graficas/Iconos/email_logo.jpg" />
                            Correo electrónico<br/>
                            <asp:Label ID="LblCorreoElectronico" runat="server"></asp:Label>
                        </h5>
                    </div>
                </div>
                <div class="grey five wide column" style="margin-bottom: 2em !important;">
                    <h3>
                        <i class="settings icon"></i>
                        Políticas del sitio
                    </h3>
                    <div class="ui divider"></div>
                    <h5 id="controldevoluciones">Devoluciones (Click para ver)<br />
                        <asp:Panel ID="PanelDevoluciones" runat="server">
                            <asp:Label ID="LblDevoluciones" runat="server"></asp:Label><br />
                        </asp:Panel>
                        <asp:CollapsiblePanelExtender ID="CPEdevoluciones" runat="server" Enabled="True" TargetControlID="PanelDevoluciones" ExpandControlID="controldevoluciones" CollapseControlID="controldevoluciones" Collapsed="true" ExpandedSize="150" CollapsedSize="17" ScrollContents="true"/>
                    </h5>
                    <h5 id="controlComoPagar">Como pagar (Click para ver)<br />
                        <asp:Panel ID="PanelComoPagar" runat="server">
                            <asp:Label ID="LblComoPagar" runat="server"></asp:Label>
                        </asp:Panel>
                    <asp:CollapsiblePanelExtender ID="CPEComoPagar" runat="server" Enabled="True" TargetControlID="PanelComoPagar" ExpandControlID="controlComoPagar" CollapseControlID="controlComoPagar" Collapsed="true" ExpandedSize="150" CollapsedSize="17" ScrollContents="true"/>
                    </h5>
                    <h5>Envíos<br />
                        <asp:Label ID="LblEnvios" runat="server"></asp:Label>
                    </h5>
                </div>
                <div class="grey six wide column" style="margin-bottom: 2em !important;">
                    <h3>
                        <i class="mail icon"></i>
                        Suscribirse al catálogo
                    </h3>
                    <div class="ui divider"></div>
                    <br />
                    <div class="left aligned column">
                        <img runat="server" id="ImgEmail2" style="width: 25px; height: 25px;" src="Graficas/Iconos/email_logo.jpg" />
                        <a class="cambioColor" target="_blank" href="">Actualizaciones de cat&aacute;logo
                        </a>
                    </div>
                    <br />
                    <style>
                        /* Definimos el color inicial */
                        .cambioColor {
                            color: white;
                        }
                            /* Definimos el color al pasar el mouse por encima */
                            .cambioColor:hover {
                                color: cornflowerblue;
                            }
                    </style>
                    <div class="ui fluid action input">
                        <input type="text" placeholder="Ingrese su correo..." />
                        <select class="ui inverted compact selection dropdown">
                            <option value="all">A todo</option>
                            <option value="articles">Catálogo</option>
                            <option value="products">Correo semanal</option>
                        </select>
                        <div type="submit" class="ui inverted grey button">Suscribir</div>
                    </div>
                    <br/>
                    <p>
                        <i class="warning circle icon"></i>
                        La información es confidencial y no será empleada en beneficio propio o de terceros. A no ser que haya una autorización para cualquier publicación relacionada a la misma.
                    </p>
                </div>
            </div>
        </div>