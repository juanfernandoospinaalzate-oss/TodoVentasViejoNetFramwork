// -----------------------------------------------------------------------
// <copyright file="Cliente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para operaciones crud para clientes y usuarios del sitio web
    /// </summary>
    public partial class Cliente : Form
    {
        /// <summary>
        /// Inicializa el formulario
        /// </summary>
        public Cliente()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Reestablece el estado inicial de la barra de botones y desactiva los controles
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            ucPaisDepartamentoCiudad1.Enabled = false;
            this.DgvClientes.Enabled = true;

            if (this.DgvClientes.Rows.Count > 0)
            {
                this.DgvClientes.Rows[0].Selected = true; // seleccionar la primera fila del grid
            }

            TxtBusqueda.Enabled = true;
        }

        /// <summary>
        /// Inserta un nuevo registro, o hace la modificación dependiendo del modod de operación del formulario
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            #if Pruebas
            this.TxtIdentificacion.Text = "0001";
            this.TxtNombres.Text = "Juan Fernando";
            this.TxtApellidos.Text = "Ospina Alzate";
            this.TxtCorreoElectronico.Text = "juan_fernando_ospina@hotmail.com";

            if (barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                this.TxtContraseña.Text = "12345";
                this.TxtRepetirContrasena.Text = "123456";
            }

            this.TxtTelefonoFijo.Text = "2657498";
            this.TxtTelefonoMovil.Text = "301 458 80 62";
            this.TxtDireccion.Text = "Carrera 70 # 30A 87 piso 2";
            this.TxtNombreDestinatario.Text = "juanfer";
            this.TxtTelefonoDestinatario.Text = "305 338 28 52"; 
            #endif

            Fachada.TablasMaestras.Cliente fachadaCliente = null;
            Entidades.Cliente cliente = null;
            Entidades.Direccion direccion = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = null;

            if (this.ValidarFormulario() == false)
            {
                this.barraBotonesCrud1.MantenerModoGuardado();
                return;
            }

            fachadaCliente = new Fachada.TablasMaestras.Cliente();

            cliente = new Entidades.Cliente();
            cliente.DocCliente = int.Parse(this.TxtIdentificacion.Text);
            cliente.Nombre = this.TxtNombres.Text;
            cliente.Apellido = this.TxtApellidos.Text;
            cliente.Email = this.TxtCorreoElectronico.Text;
            cliente.Contrasena = this.TxtContraseña.Text;
            cliente.Telefono1 = this.TxtTelefonoFijo.Text;
            cliente.Telefono2 = this.TxtTelefonoMovil.Text;
            cliente.Direcciones = new List<Entidades.Direccion>();

            direccion = new Entidades.Direccion();
            direccion.Pais = this.ucPaisDepartamentoCiudad1.Cbpais.SelectedItem as Entidades.Pais;
            direccion.Departamento = this.ucPaisDepartamentoCiudad1.Cbdepartamento.SelectedItem as Entidades.Departamento;
            direccion.Ciudad = this.ucPaisDepartamentoCiudad1.Cbciudad.SelectedItem as Entidades.Ciudad;
            direccion.NombreDestinatario = this.TxtNombreDestinatario.Text;
            direccion.Telefono = this.TxtNombreDestinatario.Text;
            direccion.DireccionEnvio = this.TxtDireccion.Text;

            cliente.Direcciones.Add(direccion);

            if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                resultadoTransaccion = fachadaCliente.Insertar(cliente);

                if (resultadoTransaccion.RegistrosAfectados == 0)
                {
                    this.barraBotonesCrud1.MantenerModoGuardado();
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto);
                    return;
                }
            }

            if (barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
            {
                DataGridViewRow filaActual = this.DgvClientes.SelectedRows[0];
                cliente = filaActual.DataBoundItem as Entidades.Cliente;

                direccion.IdCliente = cliente.IdCliente;
                direccion.IdDireccion = cliente.Direcciones[0].IdDireccion;

                resultadoTransaccion = fachadaCliente.Actualizar(cliente);

                if (resultadoTransaccion.RegistrosAfectados == 0)
                {
                    this.barraBotonesCrud1.MantenerModoGuardado();
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto);
                    return;
                }
            }

            if (resultadoTransaccion.RegistrosAfectados == 1)
            {
                MessageBox.Show(Mensajes.LinqToXml.LeerMensaje("0009").Texto);
            }
        }

        /// <summary>
        /// Elimina un usuario de la base de datos sino tiene registros asociados
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// inicia el modo de operación de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void BotonEditar_Click(object sender, EventArgs e)
        {
            this.ucPaisDepartamentoCiudad1.Enabled = true;
            this.DgvClientes.Enabled = false;
            this.TxtBusqueda.Enabled = false;
        }

        /// <summary>
        /// Inicio al modo de inserción del formulario
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            this.ucPaisDepartamentoCiudad1.Enabled = true;
            this.DgvClientes.Enabled = false;

            if (this.DgvClientes.Rows.Count > 0)
            {
                // remover selección de la primera fila del grid
                // por si se cancelan la operación poder seleccionar desde botón cancelar
                this.DgvClientes.Rows[0].Selected = false;
            }

            this.TxtBusqueda.Enabled = false;
        }

        /// <summary>
        /// Configura los eventos asociados a la barra de botones y lista todos los clientes
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void Cliente_Load(object sender, EventArgs e)
        {
            this.barraBotonesCrud1.BotonEditar.Click += this.BotonEditar_Click;
            this.barraBotonesCrud1.BotonEliminar.Click += this.BotonEliminar_Click;
            this.barraBotonesCrud1.BotonGuardar.Click += this.BotonGuardar_Click;
            this.barraBotonesCrud1.BotonCancelar.Click += this.BotonCancelar_Click;
            this.barraBotonesCrud1.BotonNuevo.Click += this.BotonNuevo_Click;

            Fachada.TablasMaestras.Cliente cliente = new Fachada.TablasMaestras.Cliente();
            this.DgvClientes.DataSource = cliente.Listar();
        }

        /// <summary>
        /// Monta los datos de la línea seleccionada en sus correspondientes controles
        /// </summary>
        /// <param name="sender">Objeto que dispara el procedimiento de evento</param>
        /// <param name="e">contiene varias propiedades que dan información del evento</param>
        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvClientes.SelectedRows.Count > 0)
            {
                Entidades.Cliente cliente = null;
                DataGridViewRow filaActual = null;
                Fachada.TablasMaestras.Direccion Direcciones = new Fachada.TablasMaestras.Direccion();

                filaActual = this.DgvClientes.SelectedRows[0];
                this.TxtIdentificacion.Text = filaActual.Cells[1].Value.ToString();
                this.TxtNombres.Text = filaActual.Cells[2].Value.ToString();
                this.TxtApellidos.Text = filaActual.Cells[3].Value.ToString();
                this.TxtTelefonoFijo.Text = filaActual.Cells[4].Value.ToString();
                this.TxtTelefonoMovil.Text = filaActual.Cells[5].Value.ToString();
                this.TxtCorreoElectronico.Text = filaActual.Cells[6].Value.ToString();
                cliente = filaActual.DataBoundItem as Entidades.Cliente;

                cliente.Direcciones = Direcciones.ConsultarDireccionPorId(cliente.IdCliente).ToList();

                if (cliente.Direcciones.Count > 0)
                {
                    this.TxtNombreDestinatario.Text = cliente.Direcciones[0].NombreDestinatario;
                    this.TxtDireccion.Text = cliente.Direcciones[0].DireccionEnvio;
                    this.TxtTelefonoDestinatario.Text = cliente.Direcciones[0].Telefono;
                    this.ucPaisDepartamentoCiudad1.Cbpais.SelectedValue = cliente.Direcciones[0].Pais.IdPais;
                    this.ucPaisDepartamentoCiudad1.Cbdepartamento.SelectedValue = cliente.Direcciones[0].Departamento.IdDepartamento;
                    this.ucPaisDepartamentoCiudad1.Cbciudad.SelectedValue = cliente.Direcciones[0].Ciudad.IdCiudad;
                }
            }
        }

        /// <summary>
        /// Valida los datos ingresado en el formulario
        /// </summary>
        /// <returns>true si toso los datos son válidos, false si hay algún dato no válido</returns>
        private bool ValidarFormulario()
        {
            if (string.IsNullOrEmpty(this.TxtIdentificacion.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtIdentificacion, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtNombres.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtNombres, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtApellidos.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtApellidos, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtDireccion.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtDireccion, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtCorreoElectronico.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtCorreoElectronico, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtContraseña.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtContraseña, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtRepetirContrasena.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtRepetirContrasena, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtTelefonoFijo.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtTelefonoFijo, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtTelefonoMovil.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtTelefonoMovil, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtNombreDestinatario.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtNombreDestinatario, mensaje.Texto);
                return false;
            }

            if (string.IsNullOrEmpty(this.TxtTelefonoDestinatario.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.TxtTelefonoDestinatario, mensaje.Texto);
                return false;
            }

            if (ucPaisDepartamentoCiudad1.Cbciudad.SelectedItem == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.ucPaisDepartamentoCiudad1, mensaje.Texto);
                return false;
            }

            if (ucPaisDepartamentoCiudad1.Cbdepartamento.SelectedItem == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.ucPaisDepartamentoCiudad1, mensaje.Texto);
                return false;
            }

            if (ucPaisDepartamentoCiudad1.Cbpais.SelectedItem == null)
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.errorProvider1.SetError(this.ucPaisDepartamentoCiudad1, mensaje.Texto);
                return false;
            }

            int IdentificacionCliente = int.MinValue;
            if (int.TryParse(this.TxtIdentificacion.Text, out IdentificacionCliente) == false)
            {
                string mensaje = "La identificación del cliente debe ser numérica";
                this.errorProvider1.SetError(this.TxtIdentificacion, mensaje);
                return false;
            }

            System.Text.RegularExpressions.Regex Email = new System.Text.RegularExpressions.Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            if (Email.IsMatch(TxtCorreoElectronico.Text) == false)
            {
                string mensaje = "La direccion de correo debe tener el formato correcto";
                this.errorProvider1.SetError(this.TxtCorreoElectronico, mensaje);
                return false;
            }

            if (this.TxtIdentificacion.Text != this.TxtIdentificacion.Text)
            {
                string mensaje = "La contraseña y la confirmación deben ser iguales";
                this.errorProvider1.SetError(this.TxtIdentificacion, mensaje);
                return false;
            }

            return true;
        }
    }
}
