

namespace WebPublica.ControlesDeUsuario
{
    using System;

    public partial class WucImagenesArticulo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Asignacion_Inicial_Imagenes(EntidadesWeb.PresentacionArticulo presentacionArticulo)
        {
            // Verificar si la presentación no está disponible para informar al usuario
            if (presentacionArticulo == null)
            {
                string urlImagen = "/ImagenesArticulo/Articulo_No_Disponible.jpg";
                ImagenPrincipal.Attributes.Add("src", urlImagen);
                Imagen1.Attributes.Add("src", urlImagen);

                Imagen1.Visible = true;
                Imagen2.Visible = false;
                Imagen3.Visible = false;
                Imagen4.Visible = false;
                Imagen5.Visible = false;
                Imagen6.Visible = false;

                return;
            }

            if (presentacionArticulo.Imagen1 == true)
            {
                string urlImagen = "/ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "A.jpg";

                ImagenPrincipal.Attributes.Add("src", urlImagen);
                ImagenPrincipal.Attributes.Add("alt", presentacionArticulo.Nombre);
                Imagen1.Attributes.Add("src", urlImagen);
                Imagen1.Attributes.Add("alt", presentacionArticulo.Nombre + "_1");
                Imagen1.Visible = true;
            }
            else
            {
                Imagen1.Visible = false;
            }

            if (presentacionArticulo.Imagen2 == true)
            {
                Imagen2.Attributes.Add("src", "/ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "B.jpg");
                Imagen2.Attributes.Add("alt", presentacionArticulo.Nombre + "_2");
                Imagen2.Visible = true;
            }
            else
            {
                Imagen2.Visible = false;
            }

            if (presentacionArticulo.Imagen3 == true)
            {
                Imagen3.Attributes.Add("src", "/ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "C.jpg");
                Imagen3.Attributes.Add("alt", presentacionArticulo.Nombre + "_3");
                Imagen3.Visible = true;
            }
            else
            {
                Imagen3.Visible = false;
            }

            if (presentacionArticulo.Imagen4 == true)
            {
                Imagen4.Attributes.Add("src", "/ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "D.jpg");
                Imagen4.Attributes.Add("alt", presentacionArticulo.Nombre + "_4");
                Imagen4.Visible = true;
            }
            else
            {
                Imagen4.Visible = false;
            }

            if (presentacionArticulo.Imagen5 == true)
            {
                Imagen5.Attributes.Add("src", "/ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "E.jpg");
                Imagen5.Attributes.Add("alt", presentacionArticulo.Nombre + "_5");
                Imagen5.Visible = true;
            }
            else
            {
                Imagen5.Visible = false;
            }

            if (presentacionArticulo.Imagen6 == true)
            {
                Imagen6.Attributes.Add("src", "/ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "F.jpg");
                Imagen6.Attributes.Add("alt", presentacionArticulo.Nombre + "_6");
                Imagen6.Visible = true;
            }
            else
            {
                Imagen6.Visible = false;
            }
        }
    }
}