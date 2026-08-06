

namespace WebPublica.PasarelasDePago
{
    using ContratosWeb;
    using EntidadesWeb;
    using System;
    using System.Collections.Generic;

    public partial class Paypal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito ObjCarrito = new Fachada.WebPublica.Carrito();
            Fachada.WebPublica.Direccion ObjDireccion = new Fachada.WebPublica.Direccion();

            List<ItemCarrito> ListadoCarrito = null;

            int IdUsuario = 0;
            if (this.Session["TicketUsuario"] != null)
            {
                IdUsuario = int.Parse((this.Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            }

            if (IdUsuario == 0)
            {
                ListadoCarrito = this.Session["ListaCarritoModoInvitado"] as System.Collections.Generic.List<EntidadesWeb.ItemCarrito>;
                this.Panel1.Visible = true;
                this.Panel2.Visible = false;
            }
            else
            {
                ListadoCarrito = new List<ItemCarrito>(ObjCarrito.Listar(IdUsuario));
                this.DdlDirecciones.DataSource = ObjDireccion.ListarPorIdUsuario(IdUsuario);
                this.DdlDirecciones.DataTextField = "DireccionEnvio";
                this.DdlDirecciones.DataValueField = "IdDireccion";
                this.DdlDirecciones.DataBind();
                this.Panel1.Visible = false;
                this.Panel2.Visible = true;
            }

            double PrecioTotalDelCarrito = this.CalcularTotalCarrito(ListadoCarrito);
            LblTotal.Text = "$ " + PrecioTotalDelCarrito.ToString("N0");

            this.gvCarrito.Columns[0].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0174").Texto;
            this.gvCarrito.Columns[1].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0175").Texto;
            this.gvCarrito.Columns[2].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0176").Texto;
            this.gvCarrito.Columns[3].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0177").Texto;

            this.gvCarrito.DataSource = ListadoCarrito;
            this.gvCarrito.DataBind();

            this.Session["ValorTrmDolarCop"] = PasarelasPago.SuperFinanciera.Wwwexchangerateapicom();
        }

        private double CalcularTotalCarrito(List<EntidadesWeb.ItemCarrito> l_objListaCarritoModoInvitado)
        {
            double PrecioTotalDelCarrito = 0.0;
            // Calcular el total contenido en el carrito
            if (l_objListaCarritoModoInvitado != null)
            {
                foreach (EntidadesWeb.ItemCarrito item in l_objListaCarritoModoInvitado)
                {
                    PrecioTotalDelCarrito += item.Cantidad * item.Precio;
                } 
            }
            if (PrecioTotalDelCarrito == 0.0)
            {
                Response.Redirect(this.Session["UrlBase"].ToString() + "Carrito.aspx", false);
            }
            return PrecioTotalDelCarrito;
        }

        protected void BtnConfirmacionPayPal_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito ObjCarrito = new Fachada.WebPublica.Carrito();
            Fachada.WebPublica.Cliente ObjCliente = new Fachada.WebPublica.Cliente();
            Fachada.WebPublica.Direccion ObjDireccion = new Fachada.WebPublica.Direccion();
            System.Collections.Generic.List<EntidadesWeb.ItemCarrito> ListadoCarrito = null;
            EntidadesWeb.Direccion EntidadDireccion = new EntidadesWeb.Direccion();
            EntidadesWeb.Cliente EntidadCliente = new EntidadesWeb.Cliente();
            double TasaCambioTrmUsdCop = double.Parse(Session["ValorTrmDolarCop"].ToString());
            string urlBase = this.Session["UrlBase"].ToString();

            int IdUsuario = 0;
            if (this.Session["TicketUsuario"] != null)
            {
                IdUsuario = int.Parse((this.Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            }

            if (IdUsuario == 0)
            {
                ListadoCarrito = this.Session["ListaCarritoModoInvitado"] as System.Collections.Generic.List<EntidadesWeb.ItemCarrito>;

                EntidadDireccion.IdCliente = 0;
                EntidadDireccion.NombreDestinatario = TxtNomDestinatario.Text;
                EntidadDireccion.DireccionEnvio = TxtDireccion.Text;
                EntidadDireccion.Telefono = TxtTelefonoDestinatario.Text;
                EntidadDireccion.Pais.Nombre = WucPaisDepartamentoCiudad.Ddl_Pais.SelectedItem.Text;
                EntidadDireccion.Departamento.Nombre = WucPaisDepartamentoCiudad.Ddl_Departamento.SelectedItem.Text;
                EntidadDireccion.Ciudad.Nombre = WucPaisDepartamentoCiudad.Ddl_Ciudad.SelectedItem.Text;

                EntidadCliente.IdCliente = 0;
                EntidadCliente.DocCliente = int.Parse(TxtDocIdentificacion.Text);
                EntidadCliente.Nombre = TxtNombre.Text;
                EntidadCliente.Apellido = TxtApellidos.Text;
                EntidadCliente.Telefono1 = TxtTelefonoUno.Text;
                EntidadCliente.Telefono2 = TxtTelefonoDos.Text;
                EntidadCliente.Email = TxtEmail.Text;
            }
            else
            {
                ListadoCarrito = new List<ItemCarrito>(ObjCarrito.Listar(IdUsuario));
                EntidadCliente = ObjCliente.SeleccionarClientePorIdCliente(IdUsuario);
                System.Collections.Generic.IReadOnlyCollection<EntidadesWeb.DireccionParaGrid> lista = ObjDireccion.ListarPorIdUsuario(IdUsuario);
                foreach (EntidadesWeb.DireccionParaGrid item in lista)
                {
                    EntidadDireccion.IdCliente = IdUsuario;
                    EntidadDireccion.NombreDestinatario = item.NombreDestinatario;
                    EntidadDireccion.DireccionEnvio = item.DireccionEnvio;
                    EntidadDireccion.Telefono = item.Telefono;
                    EntidadDireccion.Pais.Nombre = item.NombrePais;
                    EntidadDireccion.Departamento.Nombre = item.NombreDepartamento;
                    EntidadDireccion.Ciudad.Nombre = item.NombreCiudad;
                }

            }

            string RespuestaSitio = ObjCarrito.GenerarPreferenciaPago(ListadoCarrito, EntidadCliente, EntidadDireccion, EntidadesWeb.Enumeraciones.MedioPago.PayPal, TasaCambioTrmUsdCop, urlBase);

            Response.Redirect(RespuestaSitio, false);
        }

        protected void BtnRedirectPageDirecciones_Click(object sender, EventArgs e)
        {
            Response.Redirect(this.Session["UrlBase"].ToString() + "SitioAnterior/AdminUsuario/Direcciones.aspx", false);
        }
    }
}