

namespace WebPublica
{
    using System;
    using System.Linq;

    public partial class PlantillaPublicaDetalleArticulo : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] segmentos = Request.RawUrl.Split('/');
            int cantidadSegmentos = segmentos.Count() - 1;
            string estructuraPuntos = string.Empty;

            for (int i = 1; i < cantidadSegmentos; i++)
            {
                estructuraPuntos = estructuraPuntos + "../";
            }

            LinkStyle1.Attributes["href"] = estructuraPuntos + "contenido/librerias/semantic/dist/semantic.min.css";
            LinkStyle2.Attributes["href"] = estructuraPuntos + "contenido/librerias/lightslider.min.css";
            LinkStyle3.Attributes["href"] = estructuraPuntos + "contenido/librerias/fotorama.css";
            LinkStyle4.Attributes["href"] = estructuraPuntos + "contenido/librerias/pgwslider.min.css";
            LinkStyle5.Attributes["href"] = estructuraPuntos + "contenido/css/estilos.css";
            form1.Action = Request.RawUrl;
        }
    }
}