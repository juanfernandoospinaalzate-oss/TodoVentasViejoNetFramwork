

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    public partial class ResultadoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionesAticulos = null;
            listaPresentacionesAticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            Repeater1.DataSource = listaPresentacionesAticulos;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            (e.Item.FindControl("WucResultadoLista") as ControlesDeUsuario.WucResultadoLista).PresentacionArticulo = e.Item.DataItem as EntidadesWeb.PresentacionArticulo;
        }
    }
}