

namespace WebPublica
{
    using System;
    using System.Linq;

    public partial class PlantillaPublicaDetalleArticulo : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.linkSemanticMinCss.Href = "/contenido/librerias/semantic/dist/semantic.min.css";
            this.linklightsliderMinCss.Href = "/contenido/librerias/lightslider.min.css";
            this.linkFotoramaCss.Href = "/contenido/librerias/fotorama.css";
            this.pgwsliderMinCss.Href = "/contenido/librerias/pgwslider.min.css";
            this.estilosCss.Href = "/contenido/css/estilos.css";
            this.Favicon.Href = "/Icono_Favicon.ico";
            form1.Action = Request.RawUrl;
        }
    }
}