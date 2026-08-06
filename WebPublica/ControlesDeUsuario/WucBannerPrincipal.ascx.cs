

namespace WebPublica.ControlesDeUsuario
{
    using System;

    public partial class WucBannerPrincipal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string RutaImagnesBanner = this.Application["RutaImagenesBanner"].ToString();
            string RutaDirectorio = "/" + RutaImagnesBanner;
            string MiliSegundoAutoplayFotorama = string.Empty;
            EntidadesWeb.BannerPrincipal datosBannerPrincipal = this.Application["BannerPrincipal"] as EntidadesWeb.BannerPrincipal;

            // Si no hay datos para mostrar se oculta la totalidad del banner
            if (datosBannerPrincipal == null)
            {
                this.Visible = false;
                return;
            }

            this.DesktopBigBanner.InnerHtml = this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.BigBanner1, datosBannerPrincipal.UrlPresentacionArticulo1);

            if (datosBannerPrincipal.BigBanner2 != string.Empty)
            {
                this.DesktopBigBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.BigBanner2, datosBannerPrincipal.UrlPresentacionArticulo2);
            } 

            if (datosBannerPrincipal.BigBanner3 != string.Empty)
            {
                this.DesktopBigBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.BigBanner3, datosBannerPrincipal.UrlPresentacionArticulo3);
            }

            if (datosBannerPrincipal.BigBanner4 != string.Empty)
            {
                this.DesktopBigBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.BigBanner4, datosBannerPrincipal.UrlPresentacionArticulo4);
            }

            if (datosBannerPrincipal.BigBanner5 != string.Empty)
            {
                this.DesktopBigBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.BigBanner5, datosBannerPrincipal.UrlPresentacionArticulo5);
            }

            this.DesktopSmallBanner.InnerHtml = this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.SmallBanner1, datosBannerPrincipal.UrlPresentacionArticulo6);

            if (datosBannerPrincipal.SmallBanner2 != string.Empty)
            {
                this.DesktopSmallBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.SmallBanner2, datosBannerPrincipal.UrlPresentacionArticulo7);
            }

            if (datosBannerPrincipal.SmallBanner3 != string.Empty)
            {
                this.DesktopSmallBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.SmallBanner3, datosBannerPrincipal.UrlPresentacionArticulo8);
            }

            if (datosBannerPrincipal.SmallBanner4 != string.Empty)
            {
                this.DesktopSmallBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.SmallBanner4, datosBannerPrincipal.UrlPresentacionArticulo9);
            }

            if (datosBannerPrincipal.SmallBanner5 != string.Empty)
            {
                this.DesktopSmallBanner.InnerHtml += this.GenerarBanner(RutaDirectorio, datosBannerPrincipal.SmallBanner5, datosBannerPrincipal.UrlPresentacionArticulo10);
            }

            if (datosBannerPrincipal.VideoImagenMiniatura != string.Empty)
            {
                this.DesktopVideo.Attributes["data-source"] = datosBannerPrincipal.VideoDataSource.ToString();
                this.DesktopVideo.Attributes["data-id"] = datosBannerPrincipal.VideoDataId;
                this.DesktopVideo.Attributes["data-placeholder"] = RutaImagnesBanner + datosBannerPrincipal.VideoImagenMiniatura;
            }

            MiliSegundoAutoplayFotorama = (datosBannerPrincipal.SegundoAutoplayFotorama * 1000).ToString();
            this.DesktopBigBanner.Attributes["data-autoplay"] = MiliSegundoAutoplayFotorama;
            this.DesktopSmallBanner.Attributes["data-autoplay"] = MiliSegundoAutoplayFotorama;
        }

        private string GenerarBanner(string RutaDirectorio, string NombreImagen, string UrlDestino)
        {
            return $@"
            <div data-img=""{RutaDirectorio}{NombreImagen}"">
                <a href=""{UrlDestino}"" 
                    style=""display: block; position: absolute; top: 0; left: 0; width: 100%; height: 100%; z-index: 999;"">
                    <!-- Un espacio invisible para forzar el renderizado del área -->
                    &nbsp;
                </a>
            </div>";
        }
    }
}