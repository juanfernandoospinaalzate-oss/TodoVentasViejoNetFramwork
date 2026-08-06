// -----------------------------------------------------------------------
// <copyright file="Talla.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de talla en la base de datos por operaciones CRUD
    /// </summary>
    public partial class Talla : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public Talla()
        {
            this.InitializeComponent();
        }

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
                Fachada.TablasMaestras.Talla tallas = new Fachada.TablasMaestras.Talla();
                Entidades.Talla talla = new Entidades.Talla() { Nombre = this.TxtTalla.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = tallas.Insertar(talla);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.DgvTalla.DataSource = tallas.Listar();
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.Talla tallas = new Fachada.TablasMaestras.Talla();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idtalla = int.Parse(this.DgvTalla.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.Talla talla = new Entidades.Talla() { IdTalla = idtalla, Nombre = this.TxtTalla.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = tallas.Actualizar(talla);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvTalla.DataSource = tallas.Listar();
                }
            }

            this.DgvTalla.Enabled = true;
            this.TxtTalla.Enabled = false;
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
        }

        /// <summary>
        /// Elimina una unidad de volúmen de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Talla tallas = new Fachada.TablasMaestras.Talla();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idtalla = int.Parse(this.DgvTalla.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = tallas.Eliminar(idtalla);

                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.DgvTalla.DataSource = tallas.Listar();

            }
        }

        /// <summary>
        /// Cancela cualquier operación de inserción y edición en curso.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Usado al cancelar una edición
            this.DgvTalla.Enabled = true;
        }

        /// <summary>
        /// Inicia el modo de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.DgvTalla.Enabled = false;
        }

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void Talla_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0054");
            this.LblTalla.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0055");
            this.IdTalla.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0056");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0093");
            this.Text = etiqueta.Texto;

            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);

            Fachada.TablasMaestras.Talla tallas = new Fachada.TablasMaestras.Talla();
            // this.DgvTalla.ClearSelection();
            this.DgvTalla.DataSource = tallas.Listar();
        }

        /// <summary>
        /// convierte el texto ingresado en Mayúscula
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void TxtTalla_TextChanged(object sender, EventArgs e)
        {
            this.TxtTalla.CharacterCasing = CharacterCasing.Upper;
        }

        private void DgvTalla_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DgvTalla.SelectedRows.Count > 0)
            {
                DataGridViewRow filaActual = this.DgvTalla.SelectedRows[0];
                this.TxtTalla.Text = filaActual.Cells[1].Value.ToString();
            }
        }
    }
}
