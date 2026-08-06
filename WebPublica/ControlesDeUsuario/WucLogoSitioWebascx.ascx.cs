

namespace WebPublica.ControlesDeUsuario
{
    using System;

    public partial class WucLogoSitioWebascx : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkLogoInicio.HRef = "/";
            ImgLogo.Src = "/LogoSitioWeb.jpg";
        }
    }
}