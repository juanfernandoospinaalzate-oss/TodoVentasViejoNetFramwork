

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI.WebControls;

    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblMensaje.Text = string.Empty;

            this.LblIdentificacion.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0202").Texto;
            this.RfvLblIdentificacion.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0203").Texto;

            this.LblNombre.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0204").Texto;
            this.RfvTxtNombre.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0205").Texto;

            this.LblApellido.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0206").Texto;
            this.RfvTxtApellido.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0207").Texto;

            this.LblEmail.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0208").Texto;
            this.RfvTxtEmail.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0209").Texto;

            this.LblContrasena.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0210").Texto;
            this.RfvTxtContrasena.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0211").Texto;

            this.LblConfirmarContrasena.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0212").Texto;
            this.RfvTxtConfirmarContrasena.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0213").Texto;

            this.LblTelefono1.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0214").Texto;
            this.RfvTxtTelefono1.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0215").Texto;

            this.LblTelefono2.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0216").Texto;
            this.RfvTxtTelefono2.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0217").Texto;

            this.LblNomDestinatario.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0218").Texto;
            this.RfvTxtNomDestinatario.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0219").Texto;

            this.LblTelefonoDestinatario.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0220").Texto;
            this.RfvTxtTelefonoDestinatario.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0221").Texto;

            this.LblDireccion.Text = MensajesWeb.LinqToXml.LeerEtiquetaControles("0222").Texto;
            this.RfvTxtDireccion.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0223").Texto;

            this.CvTxtContrasenaTxtConfirmarContrasena.ErrorMessage = MensajesWeb.LinqToXml.LeerEtiquetaControles("0224").Texto;
        }

        public void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Cliente Cliente = new Fachada.WebPublica.Cliente();

            EntidadesWeb.Cliente cliente = new EntidadesWeb.Cliente()
            {
                Nombre = this.TxtNombre.Text,
                Apellido = this.TxtApellido.Text,
                Telefono1 = TxtTelefono1.Text,
                Telefono2 = TxtTelefono2.Text,
                Email = TxtEmail.Text,
                Contrasena = this.TxtContrasena.Text,
                ConfirmarContrasena = this.TxtConfirmarContrasena.Text,
                DocCliente = int.Parse(this.TxtIdCliente.Text)
            };
            EntidadesWeb.Direccion direccion = new EntidadesWeb.Direccion();

            direccion.NombreDestinatario = this.TxtNomDestinatario.Text;
            direccion.DireccionEnvio = this.TxtDireccion.Text;
            direccion.Telefono = this.TxtTelefonoDestinatario.Text;
            direccion.Pais.IdPais = Convert.ToInt32(WucPaisDepartamentoCiudad.Ddl_Pais.SelectedValue);
            direccion.Departamento.IdDepartamento = Convert.ToInt32(WucPaisDepartamentoCiudad.Ddl_Departamento.SelectedValue);
            direccion.Ciudad.IdCiudad = Convert.ToInt32(WucPaisDepartamentoCiudad.Ddl_Ciudad.SelectedValue);

            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = Cliente.Insertar(cliente, direccion);

            if (resultadoTransaccion.RegistrosAfectados == 0)
            {
                LblMensaje.Text = resultadoTransaccion.Mensaje.Texto;                
            }
            else
            {
                EntidadesWeb.Login login = new EntidadesWeb.Login();
                login.Usuario = TxtEmail.Text;
                login.Contrasena = TxtContrasena.Text;

                cliente = Cliente.SeleccionarClientePorEmail(login.Usuario);
                string userData = cliente.IdCliente.ToString();

                Fachada.WebPublica.Login Login = new Fachada.WebPublica.Login();
                EntidadesWeb.ResultadoTransaccion ResultadoAutenticacion = Login.Ingresar(login);
                bool isPersistent = false;

                System.Web.Security.FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(
                    1,
                    login.Usuario,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    isPersistent,
                    userData,
                    System.Web.Security.FormsAuthentication.FormsCookiePath);

                string encTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                this.Response.Cookies.Add(new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encTicket));

                this.Session["TicketUsuario"] = ticket;

                this.UnirCarritos(cliente);

                // Redirect back to original URL.
                this.Response.Redirect(System.Web.Security.FormsAuthentication.GetRedirectUrl(login.Usuario, isPersistent), false);
            }
        }

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
    }
}