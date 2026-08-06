<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucBannerPrincipal.ascx.cs" Inherits="WebPublica.ControlesDeUsuario.WucBannerPrincipal" %>

<!--|DIV BANNER TODOS - JORGE HURTADO|-->
<div id="banner">

    <!--|DIV D-BANNER ESCRITORIO - JORGE HURTADO|-->
    <div id="d-banner">
        <div style="width: 67%; margin: 0 auto; float: left;">
                <div runat="server" id="DesktopBigBanner"
                    class="fotorama"
                    data-autoplay="3000"
                    data-width="100%"
                    data-loop="true"
                    data-arrows="true"
                    data-click="false"
                    data-swipe="true"
                    data-stopautoplayontouch="false">
                </div>
        </div>
        
        <div style="width: 33%; margin: 0 auto; float: right;">
            <div  runat="server" id="DesktopSmallBanner"
                class="fotorama"
                data-autoplay="3000" 
                data-width="100%" 
                data-loop="true"
                data-arrows="true"
                data-click="false"
                data-swipe="true"
                data-stopautoplayontouch="false">
            </div>
        </div>
        <div style="width: 33%; margin: 0 auto; float: right;">
            <div runat="server" id="DesktopVideo" class="ui embed" data-source="" data-id="" data-placeholder=""></div>
        </div>
    </div>
    <!--|d-banner|-->
</div>
<!--|banner|-->
<br>
<br>
