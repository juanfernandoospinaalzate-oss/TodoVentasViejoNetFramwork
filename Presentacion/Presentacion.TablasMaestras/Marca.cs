// -----------------------------------------------------------------------
// <copyright file="Marca.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de marcas en la base de datos por operaciones CRUD
    /// </summary>
    public partial class Marca : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public Marca()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void Marca_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0087");
            this.LblMarca.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0088");
            this.IdMarca.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0089");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0098");
            this.Text = etiqueta.Texto;

            Fachada.TablasMaestras.Marca marcas = new Fachada.TablasMaestras.Marca();
            DgvMarca.DataSource = marcas.Listar();


            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);
        }

        #region "Eventos de la barra de botones"

        /// <summary>
        /// Cancela cualquier operación de inserción y edición en curso.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DgvMarca.Enabled = true;
        }

        /// <summary>
        /// Inicia el modo de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.DgvMarca.Enabled = false;
        }

        /// <summary>
        /// Elimina una Marca de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Marca marcas = new Fachada.TablasMaestras.Marca();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idmarca = int.Parse(DgvMarca.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = marcas.Eliminar(idmarca);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvMarca.Enabled = false;
                this.DgvMarca.DataSource = marcas.Listar();
                this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
                this.barraBotonesCRUD1.BotonEditar.Enabled = false;
                this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
            }
        }

        /// <summary>
        /// Inserta los datos nuevos en modo de edición, o guarda los datos modificados en modo edición
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumento para el evento</param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                Fachada.TablasMaestras.Marca marcas = new Fachada.TablasMaestras.Marca();
                Entidades.Marca marca = new Entidades.Marca() { Nombre = this.TxtMarca.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = marcas.Insertar(marca);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvMarca.DataSource = marcas.Listar();
                this.TxtMarca.Enabled = false;
                this.TxtMarca.Text = string.Empty;
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
                    Fachada.TablasMaestras.Marca marcas = new Fachada.TablasMaestras.Marca();

                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idmarca = int.Parse(DgvMarca.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.Marca marca = new Entidades.Marca() { IdMarca = idmarca, Nombre = this.TxtMarca.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = marcas.Actualizar(marca);
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvMarca.DataSource = marcas.Listar();
                    this.TxtMarca.Enabled = false;
                    this.TxtMarca.Text = string.Empty;
                    this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
                    this.barraBotonesCRUD1.BotonEditar.Enabled = false;
                    this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                    this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
                }
            }
        #endregion
        }

        private void DgvMarca_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DgvMarca.SelectedRows.Count > 0)
            {
                DataGridViewRow filaActual = this.DgvMarca.SelectedRows[0];
                this.TxtMarca.Text = filaActual.Cells[1].Value.ToString();
            }
        }
    }
}
