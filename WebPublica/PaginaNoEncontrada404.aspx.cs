

namespace WebPublica
{
    using System;

    public partial class PaginaNoEncontrada404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            Response.TrySkipIisCustomErrors = true;
        }
    }
}