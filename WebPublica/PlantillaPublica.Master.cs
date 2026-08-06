// -----------------------------------------------------------------------
// <copyright file="PlantillaPublica.Master.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;

    public partial class PlantillaPublica : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EntidadesWeb.ConfiguracionPieDePagina> listaConfiguracionPieDePagina = (Application["ListaConfiguracionPieDePagina"] as System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina>).ToList();
            this.LblLineaCelular.Text = listaConfiguracionPieDePagina[0].LineaCelular + " (Click para abrir)";
            this.LinkLineaCelularWhatsapp.HRef = "https://wa.me/" + listaConfiguracionPieDePagina[0].LineaCelular;

            this.linkSemanticMinCss.Href = "/contenido/librerias/semantic/dist/semantic.min.css";
            this.linklightsliderMinCss.Href = "/contenido/librerias/lightslider.min.css";
            this.linkFotoramaCss.Href = "/contenido/librerias/fotorama.css";
            this.pgwsliderMinCss.Href = "/contenido/librerias/pgwslider.min.css";
            this.estilosCss.Href = "/contenido/css/estilos.css";
            this.StyleSheetTreeview.Href = "/ControlesDeUsuario/StyleSheets/StyleSheetTreeview.css";
            this.IframeFormularioMailChimp.Src = "/FormularioMailChimp.html";

            System.Web.UI.HtmlControls.HtmlGenericControl scriptJquery = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            scriptJquery.Attributes.Add("type", "text/javascript");
            scriptJquery.Attributes.Add("src", "/contenido/librerias/jquery.min.js");
            this.Page.Header.Controls.Add(scriptJquery);

            System.Web.UI.HtmlControls.HtmlGenericControl scriptSemantic = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            scriptSemantic.Attributes.Add("type", "text/javascript");
            scriptSemantic.Attributes.Add("src", "/contenido/librerias/semantic/dist/semantic.min.js");
            this.Page.Header.Controls.Add(scriptSemantic);

            System.Web.UI.HtmlControls.HtmlGenericControl scriptLightslider = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            scriptLightslider.Attributes.Add("type", "text/javascript");
            scriptLightslider.Attributes.Add("src", "/contenido/librerias/lightslider.min.js");
            this.Page.Header.Controls.Add(scriptLightslider);

            System.Web.UI.HtmlControls.HtmlGenericControl scriptFotorama = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            scriptFotorama.Attributes.Add("type", "text/javascript");
            scriptFotorama.Attributes.Add("src", "/contenido/librerias/fotorama.js");
            this.Page.Header.Controls.Add(scriptFotorama);

            System.Web.UI.HtmlControls.HtmlGenericControl scriptJqueryZoom = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            scriptJqueryZoom.Attributes.Add("type", "text/javascript");
            scriptJqueryZoom.Attributes.Add("src", "/contenido/librerias/jquery.zoom.min.js");
            this.Page.Header.Controls.Add(scriptJqueryZoom);

            System.Web.UI.HtmlControls.HtmlGenericControl scriptPgwslider = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            scriptPgwslider.Attributes.Add("type", "text/javascript");
            scriptPgwslider.Attributes.Add("src", "/contenido/librerias/pgwslider.min.js");
            this.Page.Header.Controls.Add(scriptPgwslider);

            System.Web.UI.HtmlControls.HtmlGenericControl scriptJavascript = new System.Web.UI.HtmlControls.HtmlGenericControl("script");
            scriptJavascript.Attributes.Add("type", "text/javascript");
            scriptJavascript.Attributes.Add("src", "/contenido/js/javascript.js");
            this.Page.Header.Controls.Add(scriptJavascript);

            this.Favicon.Href = "/Icono_Favicon.ico";
            this.ImgAdobeReader.Src = "/Graficas/Iconos/adobe_reader_logo.jpg";
            this.LinkCatalogo.HRef = "/CATALOGO_DE_PRODUCTOS.pdf";
            this.ImgEmail.Src = "/Graficas/Iconos/email_logo.jpg";
            this.ImgSkype.Src = "/Graficas/Iconos/skype_logo.jpg";
            this.ImgFacebook.Src = "/Graficas/Iconos/facebook_logo.jpg";
            this.ImgWhatsapp.Src = "/Graficas/Iconos/WhatsapLogo.png";
            this.ImgTelefono.Src = "/Graficas/Iconos/telefono_logo.jpg";

            form1.Action = Request.RawUrl;
            DateTime FechaExpiracionPopUp = DateTime.MinValue;
            int DiasPopUpMailChimp = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DiasPopUpMailChimp"]);            

            // Gestionar el popup para suscripción de MailChimp
            // Si la cookie ya existe
            if (Request.Cookies["CookiesMailChimp"] != null)
            {
                DateTime FechaActual = DateTime.Now;
                DateTime.TryParse(Request.Cookies["CookiesMailChimp"]["FechaExpiracionPopUp"], out FechaExpiracionPopUp);
                TimeSpan Diferencia = FechaActual - FechaExpiracionPopUp;
                int DiasTotales = Diferencia.Days;

                // Si ya pasó la cantidad de días configurados en el Web.config, se elimina la cookie
                if (DiasTotales >= DiasPopUpMailChimp)
                {
                    FechaExpiracionPopUp = DateTime.Now.AddDays(-10);
                    HttpCookie CookieMailChimp = new HttpCookie("CookiesMailChimp");
                    CookieMailChimp.Expires = FechaExpiracionPopUp;
                    Response.Cookies["CookiesMailChimp"]["FechaExpiracionPopUp"] = FechaExpiracionPopUp.ToString();
                    Response.Cookies.Add(CookieMailChimp);
                } 
            }
            else
            {
                // Si la cookie no existe, ser crea una nueva y se almacena la información
                HttpCookie CookieMailChimp = new HttpCookie("CookiesMailChimp");
                FechaExpiracionPopUp = DateTime.Now.AddDays(DiasPopUpMailChimp);
                // CookieMailChimp.Expires = FechaExpiracionPopUp; // Si se establece fecha de expiración se deshabilita la cookie en multiples navegadores
                CookieMailChimp["FechaExpiracionPopUp"] = FechaExpiracionPopUp.ToString();
                Response.Cookies.Add(CookieMailChimp);
                ModalPopupExtender1.Show();
            }
        }
    }
}