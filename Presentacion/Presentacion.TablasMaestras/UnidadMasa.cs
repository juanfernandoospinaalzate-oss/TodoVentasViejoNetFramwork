// -----------------------------------------------------------------------
// <copyright file="UnidadMasa.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de unidades de masa en la base de datos por operaciones CRUD
    /// </summary>
    public partial class UnidadMasa : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public UnidadMasa()
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
                Fachada.TablasMaestras.UnidadMasa unidadesMasa = new Fachada.TablasMaestras.UnidadMasa();
                Entidades.UnidadMasa unidadMasa = new Entidades.UnidadMasa() { Nombre = this.TxtUnidadMasa.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = unidadesMasa.Insertar(unidadMasa);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvUnidadDeMasa.Enabled = false;
                this.DgvUnidadDeMasa.DataSource = unidadesMasa.Listar();
                this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                this.TxtUnidadMasa.Text = string.Empty;
                this.TxtUnidadMasa.Enabled = false;
                this.DgvUnidadDeMasa.Enabled = true;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.UnidadMasa unidadesMasa = new Fachada.TablasMaestras.UnidadMasa();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idmasa = int.Parse(this.DgvUnidadDeMasa.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.UnidadMasa unidadMasa = new Entidades.UnidadMasa() { IdUnidadMasa = idmasa, Nombre = this.TxtUnidadMasa.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = unidadesMasa.Actualizar(unidadMasa);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvUnidadDeMasa.Enabled = false;
                    this.DgvUnidadDeMasa.DataSource = unidadesMasa.Listar();
                    this.barraBotonesCRUD1.BotonGuardar.Enabled = false;
                    this.TxtUnidadMasa.Text = string.Empty;
                    this.TxtUnidadMasa.Enabled = false;
                    this.DgvUnidadDeMasa.Enabled = true;
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
            // Eliminar el registro
            // Si la transacción fué exitosa
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.UnidadMasa unidadesMasa = new Fachada.TablasMaestras.UnidadMasa();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idmasa = int.Parse(this.DgvUnidadDeMasa.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = unidadesMasa.Eliminar(idmasa);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvUnidadDeMasa.Enabled = false;
                this.DgvUnidadDeMasa.DataSource = unidadesMasa.Listar();
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
            this.DgvUnidadDeMasa.Enabled = false;
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
            this.DgvUnidadDeMasa.Enabled = true;
        }

        #endregion

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void UnidadesDeMasa_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0060");
            this.LblUnidadDeMasa.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0061");
            this.IdUnidadMasa.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0062");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0095");
            this.Text = etiqueta.Texto;

            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);

            Fachada.TablasMaestras.UnidadMasa unidadesMasa = new Fachada.TablasMaestras.UnidadMasa();
            this.DgvUnidadDeMasa.DataSource = unidadesMasa.Listar();
            TxtUnidadMasa.Enabled = false;
        }
    }
}
