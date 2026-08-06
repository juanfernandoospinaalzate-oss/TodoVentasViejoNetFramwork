namespace WebPublica.ControlesDeUsuario
{
    using System;


    public partial class WucVistaPreviaArticulo : System.Web.UI.UserControl
    {
        
        public void Cargar(EntidadesWeb.PresentacionArticulo presentacionArticulo)
        {
            string RutaUrlBase = this.Session["UrlBase"].ToString();

            // URL AMIGABLE: Se ensambla  reemplazando los espacios en blanco por "_"
            string Url = RutaUrlBase + "Articulo/" + presentacionArticulo.Categoria.SegmentoAmigableUrlCategoria + "/" + presentacionArticulo.NombreSinEspacios + "-" + presentacionArticulo.Articulo.IdArticulo + "-" + presentacionArticulo.IdPresentacionArticulo + ".aspx";
            // Url = Url.Replace(" ", "_");

            linkImagenPresentacionArticulo.Attributes.Add("href", Url);
            linkPresentacionArticulo.Attributes.Add("href", Url);
            linkPresentacionArticulo.InnerHtml = presentacionArticulo.Nombre;

            Imagen.Attributes.Add("src", RutaUrlBase + "ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "A.jpg");

            LblDescripcionBreve.InnerHtml = presentacionArticulo.DescripcionBreve;

            System.Globalization.CultureInfo Formato = new System.Globalization.CultureInfo("es-CO");
            Formato.NumberFormat.CurrencyDecimalDigits = 0;
            LblPrecio.InnerHtml = presentacionArticulo.Precio.ToString("C", Formato);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}