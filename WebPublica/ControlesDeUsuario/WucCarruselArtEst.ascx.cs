

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;

    public partial class WucCarruselArtEst : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private double idpresentacionarticulo = double.MinValue;
        
        public double idPresentacionArticulo
        {
            get {
                return this.idpresentacionarticulo;
            }

            set {
                EntidadesWeb.PresentacionArticulo PresentacionArticulo = null;
                this.idpresentacionarticulo = value;
                BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
                PresentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>, this.idpresentacionarticulo);
                LitTituloArticulo.Text = PresentacionArticulo.Nombre;
                LitDescripcionArticulo.Text = PresentacionArticulo.DescripcionBreve;
                LitPrecioArticulo.Text = PresentacionArticulo.Precio.ToString();
            }
        }
    }
}