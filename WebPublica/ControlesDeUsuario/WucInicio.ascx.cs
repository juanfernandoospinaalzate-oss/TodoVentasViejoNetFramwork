

namespace WebPublica.ControlesDeUsuario
{
    using System;

    public partial class WucInicio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkBotonInicio.HRef = "/";
        }
    }
}