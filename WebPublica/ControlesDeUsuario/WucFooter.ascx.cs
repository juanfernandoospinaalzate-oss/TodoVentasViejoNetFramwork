

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class WucFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EntidadesWeb.ConfiguracionPieDePagina> listaConfiguracionPieDePagina = (Application["ListaConfiguracionPieDePagina"] as System.Collections.ObjectModel.ReadOnlyCollection<EntidadesWeb.ConfiguracionPieDePagina>).ToList();
            this.LblAtencionSkype.Text = listaConfiguracionPieDePagina[0].AtencionSkype;
            this.LblLineaTelefonica.Text = listaConfiguracionPieDePagina[0].LineaTelefonica;
            this.LblLineaCelular.Text = listaConfiguracionPieDePagina[0].LineaCelular + " (Click para abrir)";
            this.LinkLineaCelularWhatsapp.HRef = "https://wa.me/" + listaConfiguracionPieDePagina[0].LineaCelular;
            this.LblCorreoElectronico.Text = listaConfiguracionPieDePagina[0].CorreoElectronico;
            this.LblDevoluciones.Text = listaConfiguracionPieDePagina[0].Devoluciones;
            this.CPEdevoluciones.ExpandedText = listaConfiguracionPieDePagina[0].Devoluciones;
            this.LblComoPagar.Text = listaConfiguracionPieDePagina[0].ComoPagar;
            this.LblEnvios.Text = listaConfiguracionPieDePagina[0].Envios;
            this.ImgSkype.Src = "/Graficas/Iconos/skype_logo.jpg";
            this.ImgTelefono.Src = "/Graficas/Iconos/telefono_logo.jpg";
            this.ImgWhatsapp.Src = "/Graficas/Iconos/WhatsapLogo.png";
            this.ImgEmail.Src = "/Graficas/Iconos/email_logo.jpg";
            this.ImgEmail2.Src = "/Graficas/Iconos/email_logo.jpg";
        }
    }
}