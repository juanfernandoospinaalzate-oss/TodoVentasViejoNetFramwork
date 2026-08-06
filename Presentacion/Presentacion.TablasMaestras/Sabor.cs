// -----------------------------------------------------------------------
// <copyright file="Sabor.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------
namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de colores en la base de datos por operaciones CRUD
    /// </summary>
    public partial class Sabor : Form
    {
        /// <summary>
        /// Constructor del formulario
        /// </summary>
        public Sabor()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Elimina el Sabor seleccionado de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        public void BotonEliminarClick(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Sabor Sabor = new Fachada.TablasMaestras.Sabor();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idsabores = int.Parse(this.DgvSabores.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = Sabor.Eliminar(idsabores);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvSabores.Enabled = false;
                this.DgvSabores.DataSource = Sabor.Listar();
                this.barraBotonesCrud1.BotonNuevo.Enabled = false;
                this.barraBotonesCrud1.BotonEditar.Enabled = false;
                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
                this.barraBotonesCrud1.BotonEliminar.Enabled = false;
            }
        }

        /// <summary>
        /// Inserta los datos nuevos en modo edición, o guarda los datos modificados en modo edición
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        public void BotonGuardarClick(object sender, EventArgs e)
        {
            if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                // MODO INSERCIÓN
                // Si es una inserción, ingresar el dato a la base de datos                
                Fachada.TablasMaestras.Sabor Sabor = new Fachada.TablasMaestras.Sabor();
                Entidades.Sabor sabor = new Entidades.Sabor() { Nombre = this.TxtSabores.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = Sabor.Insertar(sabor);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.DgvSabores.Enabled = false;
                this.DgvSabores.DataSource = Sabor.Listar();

                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.Sabor Sabor = new Fachada.TablasMaestras.Sabor();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idsabor = int.Parse(DgvSabores.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.Sabor sabor = new Entidades.Sabor() { IdSabor = idsabor, Nombre = this.TxtSabores.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = Sabor.Actualizar(sabor);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvSabores.Enabled = false;
                    this.DgvSabores.DataSource = Sabor.Listar();

                    barraBotonesCrud1.BotonGuardar.Enabled = false;
                }
            }

            this.barraBotonesCrud1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
        }

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void Sabores_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Sabor Sabor = new Fachada.TablasMaestras.Sabor();

            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0141");
            this.LblSabor.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0142");
            this.IdSabor.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0143");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0144");
            this.Text = etiqueta.Texto;

            this.barraBotonesCrud1.BotonGuardar.Click += new EventHandler(this.BotonGuardarClick);
            this.barraBotonesCrud1.BotonEliminar.Click += new EventHandler(this.BotonEliminarClick);
            this.DgvSabores.DataSource = Sabor.Listar();
        }
    }
}
