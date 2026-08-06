//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Caja base con datos de la presentación de articulo con las que se cargan los listados presentados en el sitio web
    /// </summary>
    public partial class WucResultadoCaja : System.Web.UI.UserControl
    {
        private EntidadesWeb.PresentacionArticulo presentacionArticulo = new EntidadesWeb.PresentacionArticulo();
        public EntidadesWeb.PresentacionArticulo PresentacionArticulo
        {
            get
            {
                return this.presentacionArticulo;
            }
            set
            {
                this.presentacionArticulo = value;
                double precio = double.MinValue;
                string SegmentoAmigablesUrl = Global.CargaSegmentosAmigablesUrl(this.presentacionArticulo.Categoria, this.Application["ListaCategorias"] as List<EntidadesWeb.Categoria>);
                string UrlPresentacionArticulo = "/Articulo/" + SegmentoAmigablesUrl + "/" + this.presentacionArticulo.NombreSinEspacios + "-" + this.presentacionArticulo.Articulo.IdArticulo + "-" + this.presentacionArticulo.IdPresentacionArticulo + ".aspx";

                this.AspxLinkImgArticulo.HRef = UrlPresentacionArticulo;
                this.LitTituloArticulo.Text = "<a href='" + UrlPresentacionArticulo + "'>" + this.presentacionArticulo.NombreRecortado + "</a>";
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-co");
                culture.NumberFormat.CurrencyDecimalDigits = 0;
                precio = this.presentacionArticulo.Precio;

                if (this.presentacionArticulo.UsarDescuento == true && this.presentacionArticulo.FechaInicioDescuento < DateTime.Now && this.presentacionArticulo.FechaFinalDescuento > DateTime.Now)
                {
                    this.LitPrecioArticulo.Text = "<span style=\"text-decoration: line-through double;\">" + precio.ToString("C", culture) + " </span>/ ";
                    if (this.presentacionArticulo.UsarPorcentajeDescuento == true)
                    {
                        this.LitPrecioArticulo.Text += (precio * (100 - this.presentacionArticulo.ValorPorcentajeDescuento) / 100).ToString("C", culture);
                    }

                    if (this.presentacionArticulo.UsarValorFijoDescuento == true)
                    {
                        this.LitPrecioArticulo.Text += (precio - this.presentacionArticulo.ValorFijoDescuento).ToString("C", culture);
                    }
                }
                else
                {
                    this.LitPrecioArticulo.Text = precio.ToString("C", culture);
                }

                this.LitDescripcionArticulo.Text = this.presentacionArticulo.DescripcionBreveRecortada;

                if (this.presentacionArticulo.UsarFechaProximoVencimiento == true)
                {
                    this.LitFechaVencimiento.Text = "Prox Expiración: " + this.presentacionArticulo.FechaProximoVencimiento.ToShortDateString();
                }

                string Url = "/ImagenesArticulo/" + this.presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + this.presentacionArticulo.IdPresentacionArticulo + "A.jpg";
                this.AspxImgArticulo.Src = Url;
                this.AspxImgArticulo.Alt = this.presentacionArticulo.Nombre;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}