

namespace WebPublica.ControlesDeUsuario
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class WucLoginStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MosrtarOcultarViews();

            try
            {
                LblInvitado.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0231").Texto;
                LblIniciarSesion.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0232").Texto;
                lBLRegistrarse.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0233").Texto;
                LblMensajeBienvenida.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0234").Texto;
                LnkBtnCerrarSesion.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0235").Texto;
                // MensajesWeb.LinqToXml.LeerEtiquetaControles("023").Texto;

            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
        }

        protected void LnkBtnCerrarSesion_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon(); 
            MultiView1.ActiveViewIndex = 0;
            this.Page_Load(null, null);
            this.MosrtarOcultarViews();
            (HttpContext.Current.ApplicationInstance as Global).CargarVariableSesionUrlBase();
            Page.Response.Redirect(Page.Request.Url.ToString(), false); // Refresca la página para actualizar el valor total del control de usuario WucBotonTotal 
        }

        private void MosrtarOcultarViews()
        {
            // Si no se ha iniciado sesión, se muestra el view1 (Indice 0)
            if (this.Session["TicketUsuario"] == null)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                EntidadesWeb.Cliente cliente = null;
                Fachada.WebPublica.Cliente objCliente = new Fachada.WebPublica.Cliente();
                int IdUsuario = int.Parse((this.Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);

                cliente = objCliente.SeleccionarClientePorIdCliente(IdUsuario);
                LblNombreCliente.Text = cliente.Nombre;

                MultiView1.ActiveViewIndex = 1;
            }
        }
    }
}