

namespace WebPublica.PasarelasDePago
{
    using ContratosWeb;
    using EntidadesWeb;
    using System;
    using System.Collections.Generic;

    public partial class Mercadopago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito carrito = new Fachada.WebPublica.Carrito();
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
                PanelFormularioClienteDestinatario.Visible = true;
                PanelSeleccionAdminDirecciones.Visible = false;
            }
            else
            {
                ListadoCarrito = new List<ItemCarrito>(carrito.Listar(IdUsuario));                
                DdlDirecciones.DataSource = ObjDireccion.ListarPorIdUsuario(IdUsuario);
                DdlDirecciones.DataTextField = "DireccionEnvio";
                DdlDirecciones.DataValueField = "IdDireccion";
                DdlDirecciones.DataBind();
                PanelFormularioClienteDestinatario.Visible = false;
                PanelSeleccionAdminDirecciones.Visible = true;
            }

            double PrecioTotalDelCarrito = this.CalcularTotalCarrito(ListadoCarrito);
            LblTotal.Text = "$ " + PrecioTotalDelCarrito.ToString("N0");

            this.gvCarrito.Columns[0].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0174").Texto;
            this.gvCarrito.Columns[1].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0175").Texto;
            this.gvCarrito.Columns[2].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0176").Texto;
            this.gvCarrito.Columns[3].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0177").Texto;

             this.gvCarrito.DataSource = ListadoCarrito;
            this.gvCarrito.DataBind();
        }

        private double CalcularTotalCarrito(List<EntidadesWeb.ItemCarrito> listaCarrito)
        {
            double PrecioTotalDelCarrito = 0.0;
            double precioUnitario = double.MinValue;
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            EntidadesWeb.PresentacionArticulo presentacionArticulo = null;
            

            if (listaCarrito != null)
            {
                foreach (EntidadesWeb.ItemCarrito itemcarrito in listaCarrito)
                {
                    presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(listaPresentacionArticulos, itemcarrito.IdPrestacionArticulo);

                    if (presentacionArticulo.UsarDescuento == true && presentacionArticulo.FechaInicioDescuento < DateTime.Now && presentacionArticulo.FechaFinalDescuento > DateTime.Now)
                    {
                        if (presentacionArticulo.UsarPorcentajeDescuento == true)
                        {
                            precioUnitario = presentacionArticulo.Precio * (100 - presentacionArticulo.ValorPorcentajeDescuento) / 100;
                        }

                        if (presentacionArticulo.UsarValorFijoDescuento == true)
                        {
                            precioUnitario = presentacionArticulo.Precio - presentacionArticulo.ValorFijoDescuento;
                        }
                    }
                    else
                    {
                        precioUnitario = presentacionArticulo.Precio;
                    }

                    if (itemcarrito.Cantidad > presentacionArticulo.Existencias)
                    {
                        itemcarrito.Cantidad = presentacionArticulo.Existencias;
                    }

                    PrecioTotalDelCarrito += precioUnitario * itemcarrito.Cantidad;
                } 
            }

            // Si la suma resulta en cero, retornamos al carrito
            if (PrecioTotalDelCarrito == 0.0)
            {
                Response.Redirect("/Carrito.aspx", false);
            }

            return PrecioTotalDelCarrito;
        }

        protected void BtnConfirmacionPagoMercadoPago_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito ObjCarrito = new Fachada.WebPublica.Carrito();
            Fachada.WebPublica.Cliente ObjCliente = new Fachada.WebPublica.Cliente();
            Fachada.WebPublica.Direccion ObjDireccion = new Fachada.WebPublica.Direccion();
            System.Collections.Generic.List<EntidadesWeb.ItemCarrito> ListadoCarrito = null;            
            EntidadesWeb.Direccion EntidadDireccion = new EntidadesWeb.Direccion();            
            EntidadesWeb.Cliente EntidadCliente = new EntidadesWeb.Cliente();
            string RespuestaSitio = string.Empty;

            int IdUsuario = 0;
            if (this.Session["TicketUsuario"] != null)
            {
                IdUsuario = int.Parse((this.Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            }

            if (IdUsuario == 0)
            {
                ListadoCarrito = this.Session["ListaCarritoModoInvitado"] as System.Collections.Generic.List<EntidadesWeb.ItemCarrito>;

                EntidadDireccion.IdCliente = 1;
                EntidadDireccion.NombreDestinatario = TxtNomDestinatario.Text;
                EntidadDireccion.DireccionEnvio = TxtDireccion.Text;
                EntidadDireccion.Telefono = TxtTelefonoDestinatario.Text;
                EntidadDireccion.Pais.Nombre = WucPaisDepartamentoCiudad1.Ddl_Pais.SelectedItem.Text;
                EntidadDireccion.Departamento.Nombre = WucPaisDepartamentoCiudad1.Ddl_Departamento.SelectedItem.Text;
                EntidadDireccion.Ciudad.Nombre = WucPaisDepartamentoCiudad1.Ddl_Ciudad.SelectedItem.Text;

                EntidadCliente.IdCliente = 1;
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
                    if (item.IdDireccion == int.Parse(DdlDirecciones.SelectedValue))
                    {
                        EntidadDireccion.IdDireccion = item.IdDireccion;
                        EntidadDireccion.IdCliente = IdUsuario;
                        EntidadDireccion.NombreDestinatario = item.NombreDestinatario;
                        EntidadDireccion.DireccionEnvio = item.DireccionEnvio;
                        EntidadDireccion.Telefono = item.Telefono;
                        EntidadDireccion.Pais.Nombre = item.NombrePais;
                        EntidadDireccion.Departamento.Nombre = item.NombreDepartamento;
                        EntidadDireccion.Ciudad.Nombre = item.NombreCiudad; 
                    }
                }
            }

            try
            {
                Fachada.WebPublica.Carrito CarritoAccesoDatos = new Fachada.WebPublica.Carrito();
                RespuestaSitio = CarritoAccesoDatos.GenerarPreferenciaPago(ListadoCarrito, EntidadCliente, EntidadDireccion, EntidadesWeb.Enumeraciones.MedioPago.MercadoPago, 0, string.Empty);

                Response.Redirect(RespuestaSitio, false);
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
        }

        protected void BtnRedirectPageDirecciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SitioAnterior/AdminUsuario/Direcciones.aspx", false);
        }

        protected void gvCarrito_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
                return;

            int idPresentacionArticulo = (e.Row.DataItem as EntidadesWeb.ItemCarrito).IdPrestacionArticulo;
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            System.Web.UI.WebControls.Label lblPrecioUnitario = e.Row.FindControl("LblPrecioUnitario") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lblCantidad = e.Row.FindControl("LblCantidad") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lblSubTotal = e.Row.FindControl("LblSubTotal") as System.Web.UI.WebControls.Label;
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-co");
            culture.NumberFormat.CurrencyDecimalDigits = 0; // para dar formato al precio
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            EntidadesWeb.ItemCarrito ItemActual = null;
            double precioUnitario = double.MinValue;
            double cantidad = double.MinValue;
            ItemActual = e.Row.DataItem as EntidadesWeb.ItemCarrito;

            EntidadesWeb.PresentacionArticulo presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(listaPresentacionArticulos, idPresentacionArticulo);

            if (lblCantidad != null)
            {
                if (presentacionArticulo.Existencias == 0)
                {
                    cantidad = presentacionArticulo.Existencias;
                    lblCantidad.Text = presentacionArticulo.Existencias.ToString();
                }

                cantidad = (e.Row.DataItem as EntidadesWeb.ItemCarrito).Cantidad;
                lblCantidad.Text = (e.Row.DataItem as EntidadesWeb.ItemCarrito).Cantidad.ToString();
            }

            if (presentacionArticulo.UsarDescuento == true && presentacionArticulo.FechaInicioDescuento < DateTime.Now && presentacionArticulo.FechaFinalDescuento > DateTime.Now)
            {
                lblPrecioUnitario.Text = "<span style=\"text-decoration: line-through double;\">" + presentacionArticulo.Precio.ToString("C", culture) + " </span>/ ";
                if (presentacionArticulo.UsarPorcentajeDescuento == true)
                {
                    precioUnitario = presentacionArticulo.Precio * (100 - presentacionArticulo.ValorPorcentajeDescuento) / 100;
                    lblPrecioUnitario.Text += precioUnitario.ToString("C", culture);
                }

                if (presentacionArticulo.UsarValorFijoDescuento == true)
                {
                    precioUnitario = presentacionArticulo.Precio - presentacionArticulo.ValorFijoDescuento;
                    lblPrecioUnitario.Text += precioUnitario.ToString("C", culture);
                }
            }
            else
            {
                precioUnitario = presentacionArticulo.Precio;
                lblPrecioUnitario.Text = presentacionArticulo.Precio.ToString("C", culture);
            }

            lblSubTotal.Text = (precioUnitario * cantidad).ToString("C", culture);
        }
    }
}