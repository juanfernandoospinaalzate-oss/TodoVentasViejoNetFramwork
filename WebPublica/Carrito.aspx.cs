// -----------------------------------------------------------------------
// <copyright file="Carrito.aspx.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace WebPublica
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using EntidadesWeb;

    /// <summary>
    /// Administración del carrito por parte del usuario
    /// </summary>
    public partial class Carrito : System.Web.UI.Page
    {
        /// <summary>
        /// Configuración inicial de las etiquetas
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito carrito = new Fachada.WebPublica.Carrito();
            this.LoadComplete += this.Carrito_LoadComplete;
                       
            this.gvCarrito.EmptyDataText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0163").Texto;

            this.gvCarrito.Columns[0].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0236").Texto;
            this.gvCarrito.Columns[1].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0174").Texto;
            this.gvCarrito.Columns[2].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0175").Texto;
            this.gvCarrito.Columns[3].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0176").Texto;
            this.gvCarrito.Columns[4].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0177").Texto;
            this.gvCarrito.Columns[5].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0178").Texto;
            this.gvCarrito.Columns[6].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0179").Texto;

        }

        /// <summary>
        /// Llenado de carrito a disposición del usuario
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void Carrito_LoadComplete(object sender, EventArgs e)
        {
            List<EntidadesWeb.ItemCarrito> listaCarrito = null;
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulo = null;
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb busquedaBinaria = null;
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-co");
            culture.NumberFormat.CurrencyDecimalDigits = 0; // para dar formato al precio
            double totalCarrito = double.MinValue;
            double precioArticuloConDescuento = double.MinValue; // Utilizado para almacenar el precio resultado del descuento progamado para el artículo

            ControlesDeUsuario.WucBotonTotal botonTotal = this.Page.Master.FindControl("WucBotonTotal") as ControlesDeUsuario.WucBotonTotal;
            botonTotal.Visible = false;

            // Cuando se agregan elementos al carrito sin haberse logueado (IdUsuario es nulo).
            if (this.Session["TicketUsuario"] == null)
            {
                if (this.Session["ListaCarritoModoInvitado"] == null)
                {
                    // Cargar la variable de session nula con una instancia nueva
                    listaCarrito = new List<EntidadesWeb.ItemCarrito>();
                    this.Session["ListaCarritoModoInvitado"] = listaCarrito;
                }
                else
                {
                    // Usar la lista que ya se encuentra cargada en session
                    listaCarrito = Session["ListaCarritoModoInvitado"] as List<EntidadesWeb.ItemCarrito>;
                }
            }
            else
            {
                // el usuario ya hizo login, se usa el carrito almacenado en la base de datos y no el almacenado en variable de session
                Fachada.WebPublica.Carrito fachadaCarrito = new Fachada.WebPublica.Carrito();
                int IdUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
                listaCarrito = new List<ItemCarrito>(fachadaCarrito.Listar(IdUsuario));
            }

            // existencias en BD, reducir según existencias y elliminar bajando a cero las presentaciones sin existencias y mostrando mensaje
            busquedaBinaria = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            listaPresentacionArticulo = this.Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            totalCarrito = 0.0;
            foreach (EntidadesWeb.ItemCarrito itemcarrito in listaCarrito)
            {
                // buscar las existencias y reducir las cantidades para el carrito si es necesario
                EntidadesWeb.PresentacionArticulo presentacionArticulo = busquedaBinaria.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(listaPresentacionArticulo, itemcarrito.IdPrestacionArticulo);
                if (presentacionArticulo != null)
                {
                    if (itemcarrito.Cantidad > presentacionArticulo.Existencias)
                    {
                        itemcarrito.Cantidad = presentacionArticulo.Existencias;
                        this.LblMensajeAlertaExistenciasInsuficientes.Text = "Las cantidades fueron ajustadas por disponibilidad";
                        this.LblMensajeAlertaExistenciasInsuficientes.Visible = true;
                    }

                    // Calcular los descuentos programados, si los hay
                    if (presentacionArticulo.UsarDescuento == true && presentacionArticulo.FechaInicioDescuento < DateTime.Now && presentacionArticulo.FechaFinalDescuento > DateTime.Now)
                    {
                        if (presentacionArticulo.UsarPorcentajeDescuento == true)
                        {
                            precioArticuloConDescuento = presentacionArticulo.Precio * (100 - presentacionArticulo.ValorPorcentajeDescuento) / 100;
                        }

                        if (presentacionArticulo.UsarValorFijoDescuento == true)
                        {
                            precioArticuloConDescuento = presentacionArticulo.Precio - presentacionArticulo.ValorFijoDescuento;
                        }
                    }
                    else
                    {
                        precioArticuloConDescuento = presentacionArticulo.Precio;
                    }

                    totalCarrito += itemcarrito.Cantidad * precioArticuloConDescuento;
                }
                else
                {
                    // no se encontró la presentación de artículo
                    itemcarrito.Cantidad = 0;
                    this.LblMensajeAlertaExistenciasInsuficientes.Text = "Las cantidades fueron ajustadas por disponibilidad";
                    this.LblMensajeAlertaExistenciasInsuficientes.Visible = true;
                }
            }

            this.gvCarrito.Columns[4].FooterText = totalCarrito.ToString("C", culture);

            this.gvCarrito.DataSource = listaCarrito;
            this.gvCarrito.DataBind();
        }

        protected void GvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.Session["TicketUsuario"] == null)
            {
                // El usuario no ha iniciado sesión
                System.Collections.Generic.IList<EntidadesWeb.ItemCarrito> carrito = Session["ListaCarritoModoInvitado"] as System.Collections.Generic.IList<EntidadesWeb.ItemCarrito>;
                carrito.RemoveAt(e.RowIndex);
            }
            else
            {
                // El usuario si ha iniciado sesión
                Fachada.WebPublica.Carrito carrito = new Fachada.WebPublica.Carrito();
                carrito.Eliminar(int.Parse(e.Keys[0].ToString()));
                string iditemcarrito = this.gvCarrito.DataKeys[0].Value.ToString();
            }

            // Refresca la página para actualizar el valor total del control de usuario WucBotonTotal 
            this.Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }

        protected void GvCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem == null)
                return;

            int idPresentacionArticulo = (e.Row.DataItem as EntidadesWeb.ItemCarrito).IdPrestacionArticulo;
            System.Web.UI.WebControls.Image imageArticulo = e.Row.FindControl("ImgArticulo") as System.Web.UI.WebControls.Image;
            System.Web.UI.WebControls.Label lblNombrePresentacionArticulo = e.Row.FindControl("LblNombrePresentacionArticulo") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lblCantidad = e.Row.FindControl("LblCantidad") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.DropDownList ddlListaCantidades = e.Row.FindControl("DdlCantidad") as System.Web.UI.WebControls.DropDownList;
            System.Web.UI.WebControls.Label lblPrecioUnitario = e.Row.FindControl("LblPrecioUnitario") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label lblSubTotal = e.Row.FindControl("LblSubTotal") as System.Web.UI.WebControls.Label;
            List<EntidadesWeb.PresentacionArticulo> listaPresentacionArticulos = Application["ListaPresentacionArticulo"] as List<EntidadesWeb.PresentacionArticulo>;
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-co");
            culture.NumberFormat.CurrencyDecimalDigits = 0; // para dar formato al precio
            BusquedasBinariasSecuenciales.BusquedasBinariasWeb BusquedasBinariasWeb = new BusquedasBinariasSecuenciales.BusquedasBinariasWeb();
            double precioUnitario = double.MinValue;
            double cantidad = double.MinValue;

            EntidadesWeb.PresentacionArticulo presentacionArticulo = BusquedasBinariasWeb.BusquedaBinariaPresentacionArticuloPorIdPresentacionArticulo(listaPresentacionArticulos, idPresentacionArticulo);

            if (presentacionArticulo != null)
            {
                imageArticulo.ImageUrl = "/ImagenesArticulo/" + presentacionArticulo.Fecha.ToString("yyyy-MM-dd") + "/" + presentacionArticulo.IdPresentacionArticulo + "A.jpg";
                lblNombrePresentacionArticulo.Text = presentacionArticulo.Nombre;

                if (lblCantidad != null)
                {
                    // Modo vista del Gridview
                    if (presentacionArticulo.Existencias == 0)
                    {
                        cantidad = presentacionArticulo.Existencias;
                        lblCantidad.Text = presentacionArticulo.Existencias.ToString();
                    }

                    cantidad = (e.Row.DataItem as EntidadesWeb.ItemCarrito).Cantidad;
                    lblCantidad.Text = (e.Row.DataItem as EntidadesWeb.ItemCarrito).Cantidad.ToString();
                }
                else
                {
                    // Modo edición del Gridview, Cargar el DropDownList según las cantidades disponibles
                    if (ddlListaCantidades != null)
                    {
                        // Cargar el Dropdown con la disponibilidad
                        for (int i = 0; i <= presentacionArticulo.Existencias; i++)
                        {
                            ddlListaCantidades.Items.Add(i.ToString());
                            if (ddlListaCantidades.Items.Count == 6)
                                break;
                        }

                        ddlListaCantidades.SelectedIndex = (e.Row.DataItem as EntidadesWeb.ItemCarrito).Cantidad;
                    }
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
            }

            lblSubTotal.Text = (precioUnitario * cantidad).ToString("C", culture);
        }

        protected void GvCarrito_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            Fachada.WebPublica.Carrito Carrito = new Fachada.WebPublica.Carrito();
        }

        protected void GvCarrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.WebPublica.Carrito Carrito = new Fachada.WebPublica.Carrito();
            GridViewRow FilaSeleccionada = this.gvCarrito.SelectedRow;
            int NuevoValor = int.Parse((FilaSeleccionada.FindControl("TxtCantidad") as TextBox).Text);
            int idItemCarrito = int.Parse(this.gvCarrito.DataKeys[FilaSeleccionada.RowIndex]["IdItemCarrito"].ToString());

            // llamar al actualizar
            EntidadesWeb.ItemCarrito EntidadCarrito = new EntidadesWeb.ItemCarrito();
            EntidadCarrito.IdItemCarrito = idItemCarrito;
            EntidadCarrito.Cantidad = NuevoValor;

            Carrito.Actualizar(EntidadCarrito);
        }

        protected void BtnPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SitioAnterior/MediosDePagos.aspx", false);
        }

        protected void BtnSeguirComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Index.aspx", false);
        }

        protected void GvCarrito_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // llevar el control sobre si se usará IdPresentaciónArtículo (no se ha iniciado sesión y el carrito está en las cookies del navegador),
            // o si se usará IdItemCarrito (ya se ha iniciado sesión y este se encuentra en base de datos a nombre del cliente)
            int IdItem = int.Parse(this.gvCarrito.DataKeys[e.RowIndex]["IdItemCarrito"].ToString());
            System.Collections.Generic.IList<EntidadesWeb.ItemCarrito> Listadocarrito = null;
            System.Web.UI.WebControls.DropDownList DdlListaCantidades = this.gvCarrito.Rows[e.RowIndex].FindControl("DdlCantidad") as System.Web.UI.WebControls.DropDownList;

            if (IdItem == 0)
            {
                // el usuario no ha iniciado sesión por lo que se debe hacer la directamente del grid (variable de session que lo alimento)
                // y se hace la actualización directamente en el carrito en cookies
                // string NuevoValorCantidad = e.NewValues["Cantidad"].ToString();
                Listadocarrito = Session["ListaCarritoModoInvitado"] as System.Collections.Generic.IList<EntidadesWeb.ItemCarrito>;
                Listadocarrito[e.RowIndex].Cantidad = int.Parse(DdlListaCantidades.SelectedValue);
            }
            else
            {
                // El usuario si ha iniciado sesión por lo que ya se tiene el IdItemCarrito en la variable IdItem y hacer la actualización en la base de datos
                Fachada.WebPublica.Carrito carrito = new Fachada.WebPublica.Carrito();

                EntidadesWeb.ItemCarrito itemCarrito = new EntidadesWeb.ItemCarrito();
                itemCarrito.IdItemCarrito = IdItem;
                itemCarrito.Cantidad = int.Parse(DdlListaCantidades.SelectedValue);

                // Actualizar solo la cantidad
                carrito.Actualizar(itemCarrito);
            }
            this.gvCarrito.EditIndex = -1;
            // Refresca la página para actualizar el valor total del control de usuario WucBotonTotal 
            Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }

        protected void GvCarrito_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GvCarrito_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gvCarrito.EditIndex = -1;
        }

        protected void BtnPayPal_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PasarelasDePago/Paypal.aspx", false);
        }

        protected void BtnMercadoPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PasarelasDePago/Mercadopago.aspx", false);
        }
    }
}