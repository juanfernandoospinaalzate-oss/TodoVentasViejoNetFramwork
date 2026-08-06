// -----------------------------------------------------------------------
// <copyright file="UnidadVolumen.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// --------------------------------------------------------------------

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de unidades de volúmen en la base de datos por operaciones CRUD
    /// </summary>
    public partial class UnidadVolumen : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public UnidadVolumen()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void UnidadVolumen_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0063");
            this.IdUnidadVolumen.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0064");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0065");
            this.LblUnidadVolumen.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0096");
            this.Text = etiqueta.Texto;

            TxtNombre.Enabled = false;
            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);

            Fachada.TablasMaestras.UnidadVolumen unidadesVolumen = new Fachada.TablasMaestras.UnidadVolumen();
            this.DgvUndVolumen.DataSource = unidadesVolumen.Listar();
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
                Fachada.TablasMaestras.UnidadVolumen unidadesVolumen = new Fachada.TablasMaestras.UnidadVolumen();
                Entidades.UnidadVolumen unidadVolumen = new Entidades.UnidadVolumen() { Nombre = this.TxtNombre.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = unidadesVolumen.Insertar(unidadVolumen);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.DgvUndVolumen.Enabled = false;
                this.DgvUndVolumen.DataSource = unidadesVolumen.Listar();
                this.TxtNombre.Enabled = false;
                this.TxtNombre.Text = string.Empty;
                this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
                this.barraBotonesCRUD1.BotonEditar.Enabled = false;
                this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.UnidadVolumen unidadesVolumen = new Fachada.TablasMaestras.UnidadVolumen();

                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idvolumen = int.Parse(DgvUndVolumen.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.UnidadVolumen unidadVolumen = new Entidades.UnidadVolumen() { IdUnidadVolumen = idvolumen, Nombre = this.TxtNombre.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = unidadesVolumen.Actualizar(unidadVolumen);
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvUndVolumen.Enabled = false;
                    this.DgvUndVolumen.DataSource = unidadesVolumen.Listar();
                    this.TxtNombre.Enabled = false;
                    this.TxtNombre.Text = string.Empty;
                    this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
                    this.barraBotonesCRUD1.BotonEditar.Enabled = false;
                    this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                    this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
                }
            }

            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
        }

        /// <summary>
        /// Elimina una unidad de volúmen de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar el registro
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.UnidadVolumen unidadesVolumen = new Fachada.TablasMaestras.UnidadVolumen();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idvolumen = int.Parse(this.DgvUndVolumen.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = unidadesVolumen.Eliminar(idvolumen);

                // Si la transacción fué exitosa
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvUndVolumen.Enabled = false;
                this.DgvUndVolumen.DataSource = unidadesVolumen.Listar();
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
            this.DgvUndVolumen.Enabled = false;
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
            this.DgvUndVolumen.Enabled = true;
        }



        #endregion

        private void DgvUndVolumen_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvUndVolumen.SelectedRows.Count > 0)
            {
                DataGridViewRow filaActual = this.DgvUndVolumen.SelectedRows[0];
                this.TxtNombre.Text = filaActual.Cells[1].Value.ToString();
            }
        }
    }
}
