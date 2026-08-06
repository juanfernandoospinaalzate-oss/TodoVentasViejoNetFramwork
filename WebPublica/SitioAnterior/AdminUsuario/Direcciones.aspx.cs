//-----------------------------------------------------------------------
// <copyright file="Direcciones.aspx.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
//-----------------------------------------------------------------------

namespace WebPublica.AdminUsuario
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Página de administración de direcciones del usuario
    /// </summary>
    public partial class Direcciones : System.Web.UI.Page
    {
        /// <summary>
        /// Insertar una dirección nueva para el usuario
        /// </summary>
        /// <param name="sender">Objeto que desata el procedimiento</param>
        /// <param name="e">Argumentos del evento</param>
        public void BtnAgregar_Click(object sender, EventArgs e)
        {
            Fachada.WebPublica.Direccion direccion = new Fachada.WebPublica.Direccion();

            int idUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);

            EntidadesWeb.Direccion entidadDireccion = new EntidadesWeb.Direccion();
            entidadDireccion.NombreDestinatario = this.TxtNomDestinatario.Text;
            entidadDireccion.DireccionEnvio = this.TxtDireccion.Text;
            entidadDireccion.Telefono = this.TxtTelefono.Text;
            entidadDireccion.Pais.IdPais = Convert.ToInt32(this.WucPaisDepartamentoCiudad1.Ddl_Pais.SelectedValue);
            entidadDireccion.Departamento.IdDepartamento = Convert.ToInt32(this.WucPaisDepartamentoCiudad1.Ddl_Departamento.SelectedValue);
            entidadDireccion.Ciudad.IdCiudad = Convert.ToInt32(this.WucPaisDepartamentoCiudad1.Ddl_Ciudad.SelectedValue);
            entidadDireccion.IdCliente = idUsuario;
            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = direccion.Insertar(entidadDireccion);

            this.DgvDireccion.DataSource = direccion.ListarPorIdUsuario(idUsuario);
            this.DgvDireccion.DataBind();
        }

        /// <summary>
        /// Configura los controles antre de mostrarlos
        /// </summary>
        /// <param name="sender">Objeto que desata el procedimiento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Fachada.WebPublica.Direccion direccion = new Fachada.WebPublica.Direccion();

            EntidadesWeb.EtiquetaControles etiqueta = null;
            etiqueta = new EntidadesWeb.EtiquetaControles();

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0165");
            this.LblNombreDestinatario.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0166");
            this.LblDireccionEnvio.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0167");
            this.LblTelefono.Text = etiqueta.Texto;

            //// etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0168");
            //// this.LblIdCliente.Text = etiqueta.Texto;

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0169");
            this.BtnAgregar.Text = etiqueta.Texto;

            this.DgvDireccion.Columns[0].HeaderText = MensajesWeb.LinqToXml.LeerEtiquetaControles("0170").Texto; // UBICACION

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0171");
            this.DgvDireccion.Columns[1].HeaderText = etiqueta.Texto.ToString(); // DESTINATARIO

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0172");
            this.DgvDireccion.Columns[2].HeaderText = etiqueta.Texto.ToString(); // DIRECCION DE ENVIO

            etiqueta = MensajesWeb.LinqToXml.LeerEtiquetaControles("0173");
            this.DgvDireccion.Columns[3].HeaderText = etiqueta.Texto.ToString(); // TELEFONO

            if (Page.IsPostBack == false)
            {
                int idUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
                this.DgvDireccion.DataSource = direccion.ListarPorIdUsuario(idUsuario);
                this.DgvDireccion.DataBind();
            }
        }

        /// <summary>
        /// Inicia el modo de edición para el GridView
        /// </summary>
        /// <param name="sender">Objeto que desata el procedimiento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void DgvDireccion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DgvDireccion.EditIndex = e.NewEditIndex;
            Fachada.WebPublica.Direccion direccion = new Fachada.WebPublica.Direccion();
            int idUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            this.DgvDireccion.DataSource = direccion.ListarPorIdUsuario(idUsuario);
            this.DgvDireccion.DataBind();
        }

        /// <summary>
        /// Se produce cuando se hace clic en el botón Actualizar de una fila, pero antes de que el control GridView actualice la fila
        /// </summary>
        /// <param name="sender">Objeto que desata el procedimiento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void DgvDireccion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Fachada.WebPublica.Direccion direccion = new Fachada.WebPublica.Direccion();
            EntidadesWeb.DireccionParaGrid entidadDireccion = new EntidadesWeb.DireccionParaGrid();

            entidadDireccion.NombreDestinatario = e.NewValues["NombreDestinatario"].ToString();
            entidadDireccion.DireccionEnvio = e.NewValues["DireccionEnvio"].ToString();
            entidadDireccion.Telefono = e.NewValues["Telefono"].ToString();

            DropDownList paises = (DgvDireccion.Rows[e.RowIndex].FindControl("WucPaisDepartamentoCiudad2") as ControlesDeUsuario.WucPaisDepartamentoCiudad).Ddl_Pais;
            entidadDireccion.IdPais = int.Parse(paises.SelectedValue);

            DropDownList departamentos = (DgvDireccion.Rows[e.RowIndex].FindControl("WucPaisDepartamentoCiudad2") as ControlesDeUsuario.WucPaisDepartamentoCiudad).Ddl_Departamento;
            entidadDireccion.IdDepartamento = int.Parse(departamentos.SelectedValue);

            DropDownList ciudades = (DgvDireccion.Rows[e.RowIndex].FindControl("WucPaisDepartamentoCiudad2") as ControlesDeUsuario.WucPaisDepartamentoCiudad).Ddl_Ciudad;
            entidadDireccion.IdCiudad = int.Parse(ciudades.SelectedValue);

            entidadDireccion.IdDireccion = int.Parse(DgvDireccion.DataKeys[e.RowIndex]["IdDireccion"].ToString());

            EntidadesWeb.ResultadoTransaccion resultadoTransaccion = direccion.Actualizar(entidadDireccion);

            DgvDireccion.EditIndex = -1;
            int idUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            this.DgvDireccion.DataSource = direccion.ListarPorIdUsuario(idUsuario);
            this.DgvDireccion.DataBind();
        }

        /// <summary>
        /// Ocurre cuando una fila de datos es enlazada a un registro de dirección y carga los datos en los controles correspondientes
        /// </summary>
        /// <param name="sender">Objeto que desata el procedimiento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void DgvDireccion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.FindControl("WucPaisDepartamentoCiudad2") != null)
            {
                ControlesDeUsuario.WucPaisDepartamentoCiudad ddlUbicacion = e.Row.FindControl("WucPaisDepartamentoCiudad2") as ControlesDeUsuario.WucPaisDepartamentoCiudad;
                ddlUbicacion.Ddl_Pais.SelectedValue = DgvDireccion.DataKeys[e.Row.RowIndex]["IdPais"].ToString();
                ddlUbicacion.DdlPais_SelectedIndexChanged(null, null);
                ddlUbicacion.Ddl_Departamento.SelectedValue = DgvDireccion.DataKeys[e.Row.RowIndex]["IdDepartamento"].ToString();
                ddlUbicacion.DdlDepartamento_SelectedIndexChanged(null, null);
                ddlUbicacion.Ddl_Ciudad.SelectedValue = DgvDireccion.DataKeys[e.Row.RowIndex]["IdCiudad"].ToString();
            }
        }

        /// <summary>
        /// Ocurre cuando se hace clic en el botón Cancelar de una fila en modo de edición, pero antes de que la fila salga del modo de edición.
        /// carga los datos correspondientes al usuario
        /// </summary>
        /// <param name="sender">Objeto que desata el procedimiento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void DgvDireccion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Fachada.WebPublica.Direccion direccion = new Fachada.WebPublica.Direccion();
            DgvDireccion.EditIndex = -1;
            int idUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            this.DgvDireccion.DataSource = direccion.ListarPorIdUsuario(idUsuario);
            this.DgvDireccion.DataBind();
        }

        /// <summary>
        /// e produce cuando se hace clic en el botón Eliminar de una fila eliminando de la base de datos el registro correspondiente
        /// </summary>
        /// <param name="sender">Objeto que desata el procedimiento</param>
        /// <param name="e">Argumentos del evento</param>
        protected void DgvDireccion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Fachada.WebPublica.Direccion direccion = new Fachada.WebPublica.Direccion();
            direccion.Eliminar(int.Parse(e.Keys["IdDireccion"].ToString()));
            int idUsuario = int.Parse((Session["TicketUsuario"] as System.Web.Security.FormsAuthenticationTicket).UserData);
            this.DgvDireccion.DataSource = direccion.ListarPorIdUsuario(idUsuario);
            this.DgvDireccion.DataBind();
        }
    }
}