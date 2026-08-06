// -----------------------------------------------------------------------
// <copyright file="UnidadLongitud.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// --------------------------------------------------------------------
namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de unidades de longitud en la base de datos por operaciones CRUD
    /// </summary>
    public partial class UnidadLongitud : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public UnidadLongitud()
        {
            this.InitializeComponent();
        }

        #region "Eventos de la barra de botones"
        /// <summary>
        /// Inserta los datos nuevos en modo edición, o guarda los datos modificados en modo edición
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si se está insertando ó actualizando
            if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                // MODO INSERCIÓN
                // Si es una inserción, ingresar el dato a la base de datos                                
                Fachada.TablasMaestras.UnidadLongitud unidadesLongitud = new Fachada.TablasMaestras.UnidadLongitud();

                Entidades.UnidadLongitud unidadLongitud = new Entidades.UnidadLongitud() { Nombre = this.TxtNombre.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = unidadesLongitud.Insertar(unidadLongitud);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvUndLongitud.Enabled = false;
                this.DgvUndLongitud.DataSource = unidadesLongitud.Listar();
                this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                this.TxtNombre.Text = string.Empty;
                this.TxtNombre.Enabled = false;
                this.DgvUndLongitud.Enabled = true;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.UnidadLongitud unidadesLongitud = new Fachada.TablasMaestras.UnidadLongitud();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idlongitud = int.Parse(this.DgvUndLongitud.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.UnidadLongitud unidadLongitud = new Entidades.UnidadLongitud() { IdUnidadLongitud = idlongitud, Nombre = this.TxtNombre.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = unidadesLongitud.Actualizar(unidadLongitud);
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvUndLongitud.Enabled = false;
                    this.DgvUndLongitud.DataSource = unidadesLongitud.Listar();
                    this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                    this.TxtNombre.Text = string.Empty;
                    this.TxtNombre.Enabled = false;
                    this.DgvUndLongitud.Enabled = true;
                }
            }

            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
        }

        /// <summary>
        /// Elimina el color seleccionado de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.UnidadLongitud unidadesLongitud = new Fachada.TablasMaestras.UnidadLongitud();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idlongitud = int.Parse(this.DgvUndLongitud.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = unidadesLongitud.Eliminar(idlongitud);

                // Si la transacción fué exitosa
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvUndLongitud.Enabled = false;
                this.DgvUndLongitud.DataSource = unidadesLongitud.Listar();

                this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
                this.barraBotonesCRUD1.BotonEditar.Enabled = false;
                this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
            }
        }

        /// <summary>
        /// Inicia el modo de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.DgvUndLongitud.Enabled = false;
        }

        /// <summary>
        /// Cancela cualquier operación de inserción y edición en curso.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Usado al cancelar una edición
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
            this.DgvUndLongitud.Enabled = true;
        }
        #endregion

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void UnidadLongitud_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0057");
            this.LblUnidadLongitud.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0058");
            this.IdUnidadLongitud.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0059");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0094");
            this.Text = etiqueta.Texto;

            TxtNombre.Enabled = false;
            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);

            Fachada.TablasMaestras.UnidadLongitud unidadesLongitud = new Fachada.TablasMaestras.UnidadLongitud();
            this.DgvUndLongitud.DataSource = unidadesLongitud.Listar();
        }
    }
}
