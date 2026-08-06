//-----------------------------------------------------------------------
// <copyright file="WUcResultadoLista.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace WebPublica.ControlesDeUsuario
{
    using System;

    public partial class WucResultadoLista : System.Web.UI.UserControl
    {
        private EntidadesWeb.PresentacionArticulo presentacionArticulo = new EntidadesWeb.PresentacionArticulo();
        public EntidadesWeb.PresentacionArticulo PresentacionArticulo
        {
            get {
                return this.presentacionArticulo;
            }
            set {
                this.presentacionArticulo = value;
                this.LitTituloArticulo.Text = this.presentacionArticulo.Nombre;
                this.LitPrecioArticulo.Text = this.presentacionArticulo.Precio.ToString();
                this.LitDescripcionArticulo.Text = this.presentacionArticulo.DescripcionBreve;

                string RutaUrlBase = this.Session["UrlBase"].ToString();
                string Url = RutaUrlBase + "ImagenesArticulo/" + this.presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + this.presentacionArticulo.IdPresentacionArticulo + "A.jpg";
                this.AspxImgArticulo.Src = Url;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}