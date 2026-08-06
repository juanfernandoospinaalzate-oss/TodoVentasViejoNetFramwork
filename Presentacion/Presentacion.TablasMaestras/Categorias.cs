// -----------------------------------------------------------------------
// <copyright file="Categorias.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de categorías en la base de datos por operaciones CRUD
    /// </summary>
    public partial class Categorias : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public Categorias()
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
            Entidades.ResultadoTransaccion resultadoTransaccion = null;
            Entidades.Categoria entidadCategoria = null;
            int idCategoria = int.MinValue;


            if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                // MODO INSERCIÓN

                if (this.UcTrCategorias1.TreeViewCategorias.SelectedNode == null)
                {
                    MessageBox.Show(Mensajes.LinqToXml.LeerMensaje("0019").Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.barraBotonesCRUD1.BotonCancelar.PerformClick();
                    return;
                }

                // Si es una inserción, ingresar el dato a la base de datos
                Fachada.TablasMaestras.Categoria categoria = new Fachada.TablasMaestras.Categoria();
                int idCategoriaPadre = (this.UcTrCategorias1.TreeViewCategorias.SelectedNode.Tag as Entidades.Categoria).IdCategoria;
                entidadCategoria = new Entidades.Categoria() { IdCategoriaPadre = idCategoriaPadre, Nombre = this.TxtNombre.Text, Descripcion = this.TxtDescripcion.Text, PalabrasClave = this.TxtPalabrasClave.Text };
                resultadoTransaccion = categoria.Insertar(entidadCategoria);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                if (resultadoTransaccion.RegistrosAfectados == 1)
                {
                    idCategoria = int.Parse(resultadoTransaccion.ValorAuxiliar.ToString());
                }
                else
                {
                    this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
                    this.barraBotonesCRUD1.BotonEditar.Enabled = false;
                    this.barraBotonesCRUD1.BotonGuardar.Enabled = true;
                    this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
                }
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.Categoria categoria = new Fachada.TablasMaestras.Categoria();
                    idCategoria = (this.UcTrCategorias1.TreeViewCategorias.SelectedNode.Tag as Entidades.Categoria).IdCategoria;
                    int idCategoriaPadre = (this.UcTrCategorias1.TreeViewCategorias.SelectedNode.Tag as Entidades.Categoria).IdCategoriaPadre;
                    entidadCategoria = new Entidades.Categoria() { IdCategoria = idCategoria, IdCategoriaPadre = idCategoriaPadre, Nombre = this.TxtNombre.Text, Descripcion = this.TxtDescripcion.Text, PalabrasClave = this.TxtPalabrasClave.Text };
                    resultadoTransaccion = categoria.Actualizar(entidadCategoria);
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
            }

            if (resultadoTransaccion.RegistrosAfectados == 1)
            {
                UcTrCategorias1.CargarCategorias();
                UcTrCategorias1.BuscarNodo(idCategoria);
                entidadCategoria = UcTrCategorias1.TreeViewCategorias.SelectedNode.Tag as Entidades.Categoria;
                this.barraBotonesCRUD1.BotonCancelar.PerformClick();

                this.TxtNombre.Text = entidadCategoria.Nombre;
                this.TxtDescripcion.Text = entidadCategoria.Descripcion;
                this.TxtPalabrasClave.Text = entidadCategoria.PalabrasClave;
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
            this.UcTrCategorias1.HabilitarInhabilitar(Entidades.Enumeraciones.Estado.Habilitado);
            this.UcTrCategorias1.TreeViewCategorías.SelectedNode = null;

        }

        /// <summary>
        /// Inicia el modo de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (this.UcTrCategorias1.TreeViewCategorias.SelectedNode == null)
            {
                MessageBox.Show(Mensajes.LinqToXml.LeerMensaje("0018").Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.barraBotonesCRUD1.BotonCancelar.PerformClick();
                return;
            }

            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Edición;
            this.UcTrCategorias1.HabilitarInhabilitar(Entidades.Enumeraciones.Estado.Inhabilitado);
        }

        /// <summary>
        /// Elimina la categoría seleccionado de la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCRUD1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Categoria Categoria = new Fachada.TablasMaestras.Categoria();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idCategoria = (this.UcTrCategorias1.TreeViewCategorias.SelectedNode.Tag as Entidades.Categoria).IdCategoria;
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = Categoria.Eliminar(idCategoria);

                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            }
        }

        #endregion

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void Categorias_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0045");
            this.LblPalabraClave.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0044");
            this.LblDescripcion.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0043");
            this.LblNombre.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0091");
            this.Text = etiqueta.Texto;

            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);
            this.UcTrCategorias1.TreeViewCategorias.AfterSelect += this.TreeViewCategorias_AfterSelect;

            this.UcTrCategorias1.HabilitarInhabilitar(Entidades.Enumeraciones.Estado.Habilitado);
        }

        void TreeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Entidades.Categoria categoria = e.Node.Tag as Entidades.Categoria;
            this.TxtDescripcion.Text = categoria.Descripcion;
            this.TxtNombre.Text = categoria.Nombre;
            this.TxtPalabrasClave.Text = categoria.PalabrasClave;
        }
    }
}
