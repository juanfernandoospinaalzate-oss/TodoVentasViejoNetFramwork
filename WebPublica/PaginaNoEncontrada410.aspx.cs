

namespace WebPublica
{
    using System;

    public partial class PaginaNoEncontrada410 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.Gone;
            Response.TrySkipIisCustomErrors = true;
        }
    }
}