

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI.WebControls;

    public partial class Ingresar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LblNombreDeUsuario.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0225").Texto;
            this.TxtNombreDeUsuario.Attributes.Add("placeholder", LblNombreDeUsuario.Text);
            this.RfvTxtNombreDeUsuario.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0226").Texto;
            this.LblContrasena.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0227").Texto;
            this.TxtContrasena.Attributes.Add("placeholder", LblContrasena.Text);
            this.RfvTxtContrasena.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0228").Texto;
            this.LinkButtonIngresar.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0229").Texto;
            this.LinkButtonRegistro.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0230").Texto;
            this.LblMensaje.Text = string.Empty;
            (this.Master.FindControl("ModalPopupExtender1") as AjaxControlToolkit.ModalPopupExtender).Enabled = false; // Deshabilitar popup mailchimp
        }

        protected void LinkButtonIngresar_Click(object sender, EventArgs e)
        {
            EntidadesWeb.Login login = new EntidadesWeb.Login();
            login.Usuario = TxtNombreDeUsuario.Text;
            login.Contrasena = TxtContrasena.Text;

            EntidadesWeb.Cliente cliente = new EntidadesWeb.Cliente();
            Fachada.WebPublica.Cliente Cliente = new Fachada.WebPublica.Cliente();

            cliente = Cliente.SeleccionarClientePorEmail(login.Usuario);
            string userData = cliente.IdCliente.ToString();

            Fachada.WebPublica.Login Login = new Fachada.WebPublica.Login();
            EntidadesWeb.ResultadoTransaccion ResultadoAutenticacion = Login.Ingresar(login);
            bool isPersistent = false;

            if (int.Parse(ResultadoAutenticacion.ValorAuxiliar.ToString()) != 0)
            {
                System.Web.Security.FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(
                    1,
                    login.Usuario,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    isPersistent,
                    userData,
                    System.Web.Security.FormsAuthentication.FormsCookiePath);

                string encTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encTicket));

                this.Session["TicketUsuario"] = ticket;

                this.UnirCarritos(cliente);

                // Redirect back to original URL.
                this.Response.Redirect(System.Web.Security.FormsAuthentication.GetRedirectUrl(login.Usuario, isPersistent), false);
            }
            else
            {
                this.LblMensaje.Text = MensajesWeb.LinqToXml.LeerMensaje("0062").Texto;
                // Cerrar sesión en caso de tener una abierta
                System.Web.Security.FormsAuthentication.SignOut();
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
            }
        }

        protected void LinkButtonRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect(this.Session["UrlBase"].ToString() + "Registro.aspx", false);
        }

        /// <summary>
        /// Añade los elementos del carrito en variable de sesión al carrito de base de datos, 
        /// siempre que sean elementos no existentes en el carrito de base de datos
        /// </summary>
        private void UnirCarritos(EntidadesWeb.Cliente cliente)
        {
            // verificar si ya hay un carrito en "modo invitado"
            if (this.Session["ListaCarritoModoInvitado"] != null)
            {
                Fachada.WebPublica.Login Login = new Fachada.WebPublica.Login();
                List<EntidadesWeb.ItemCarrito> ListaCarritoModoInvitado = new List<EntidadesWeb.ItemCarrito>();
                ListaCarritoModoInvitado = this.Session["ListaCarritoModoInvitado"] as List<EntidadesWeb.ItemCarrito>;

                foreach (EntidadesWeb.ItemCarrito item in ListaCarritoModoInvitado)
                {
                    item.IdUsuario = cliente.IdCliente;
                }

                Login.InsertarItemCarrito(ListaCarritoModoInvitado);

                // Limpiar el carrito de la sessión
                this.Session["ListaCarritoModoInvitado"] = null;
            }
        }

        protected void LinkButtonRecuperarClave_Click(object sender, EventArgs e)
        {
            Response.Redirect(this.Session["UrlBase"].ToString() + "RecuperarClave.aspx", false);
        }
    }
}