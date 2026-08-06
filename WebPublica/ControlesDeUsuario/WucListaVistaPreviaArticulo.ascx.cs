

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Web.UI.WebControls;

    public partial class WucListaVistaPreviaArticulo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public GridView GridListaPresentacionArticulo
        {
            get
            {
                return this.GridView1;
            }

            set
            {
                this.GridView1 = value;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.FindControl("WucVistaPreviaArticulo1") != null)
            {
                WucVistaPreviaArticulo PresentacionArticulo = e.Row.FindControl("WucVistaPreviaArticulo1") as WucVistaPreviaArticulo;

                EntidadesWeb.PresentacionArticulo presentacionArticulo = e.Row.DataItem as EntidadesWeb.PresentacionArticulo;
                PresentacionArticulo.Cargar(presentacionArticulo);
            }
        }
    }
}