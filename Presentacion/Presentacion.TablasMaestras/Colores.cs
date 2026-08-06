// -----------------------------------------------------------------------
// <copyright file="Colores.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Formulario para la administración de colores en la base de datos por operaciones CRUD
    /// </summary>
    public partial class Colores : Form
    {
        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public Colores()
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
            Fachada.TablasMaestras.Color colores = null;
            Entidades.ResultadoTransaccion resultadoTransaccion = null;

            if (string.IsNullOrEmpty(TxtCodigoHexadecimal.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.ValidarFormColores.SetError(this.TxtCodigoHexadecimal, mensaje.Texto);
                this.barraBotonesCRUD1.MantenerModoGuardado();
                return;
            }

            if (string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                Entidades.Mensaje mensaje = Mensajes.LinqToXml.LeerMensaje("0010");
                this.ValidarFormColores.SetError(this.TxtNombre, mensaje.Texto);
                this.barraBotonesCRUD1.MantenerModoGuardado();
                return;
            }

            // Verificar si se está insertando ó actualizando
            if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                // MODO INSERCIÓN
                // Si es una inserción, ingresar el dato a la base de datos
                colores = new Fachada.TablasMaestras.Color();
                Entidades.Color color = new Entidades.Color() { Codigo = this.TxtCodigoHexadecimal.Text, Nombre = this.TxtNombre.Text };
                resultadoTransaccion = colores.Insertar(color);

                if (resultadoTransaccion.RegistrosAfectados == 1)
                {
                    this.DgvColor.Enabled = true;
                    this.DgvColor.DataSource = colores.Listar();
                    this.Colores_Activated(null, null);
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
                else
                {
                    this.ResetearBotonesOperacionGuardar();
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    colores = new Fachada.TablasMaestras.Color();
                    DataGridViewRow filaSeleccionada = DgvColor.CurrentRow;
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idColor = Convert.ToInt32(filaSeleccionada.Cells[0].Value, culture);
                    Entidades.Color color = new Entidades.Color() { IdColor = idColor, Codigo = this.TxtCodigoHexadecimal.Text, Nombre = this.TxtNombre.Text };
                    resultadoTransaccion = colores.Actualizar(color);

                    if (resultadoTransaccion.RegistrosAfectados == 1)
                    {
                        this.DgvColor.Enabled = true;
                        this.DgvColor.DataSource = colores.Listar();
                        this.Colores_Activated(null, null);
                    }
                    else
                    {
                        this.ResetearBotonesOperacionGuardar();
                    }

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
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
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
            this.DgvColor.Enabled = true;

            // restaurar los datos de selección en los TextBox
            if (this.DgvColor.SelectedRows.Count > 0)
            {
                DataGridViewRow filaActual = this.DgvColor.SelectedRows[0];
                this.TxtCodigoHexadecimal.Text = filaActual.Cells[1].Value.ToString();
                this.TxtNombre.Text = filaActual.Cells[2].Value.ToString();
            }
        }

        /// <summary>
        /// Inicia el modo de edición del formulario
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.DgvColor.Enabled = false;
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
                Fachada.TablasMaestras.Color color = new Fachada.TablasMaestras.Color();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idColor = Convert.ToInt32(this.DgvColor.SelectedRows[0].Cells[0].Value, culture);

                // Eliminar el registro
                Entidades.ResultadoTransaccion resultadoTransaccion = null;
                resultadoTransaccion = color.Eliminar(idColor);

                // Si la transacción fué exitosa
                if (resultadoTransaccion.RegistrosAfectados == 1)
                {
                    // Si la transacción fué exitosa se recarga el grid con los colores
                    this.DgvColor.DataSource = color.Listar();
                }
                else
                {
                    // Si la transacción NO fué exitosa se muestra el mensaje al usuario
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
            }
        }

        /// <summary>
        /// Pinta las celdas del DataGridView
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void Colores_Activated(object sender, EventArgs e)
        {
            // Pintar las celdas del DataGridView.
            for (int i = 0; i < this.DgvColor.RowCount; i++)
            {
                DataGridViewRow filaActual = this.DgvColor.Rows[i];
                Color colorCelda = System.Drawing.ColorTranslator.FromHtml("#" + filaActual.Cells[1].Value.ToString());
                filaActual.Cells[2].Style.BackColor = colorCelda;

                // Cambiar el estilo de la celda seleccionada (color) porel mismo color para no cambiar el color de fondo al seleccionar
                filaActual.Cells[2].Style.SelectionBackColor = colorCelda;
            }
        }

        /// <summary>
        /// Configura el formulario para comenzar a trabajar
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void Colores_Load(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0046");
            this.LblCodigoHexadecimal.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0047");
            this.LblNombre.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0048");
            this.BtnShowColorDialog.Text = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0050");
            // this.IdColor.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0051");
            // this.CodigoHexadecimal.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0052");
            // this.Nombre.HeaderText = etiqueta.Texto;

            // etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0053");
            // this.Color.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0092");
            this.Text = etiqueta.Texto;

            this.barraBotonesCRUD1.BotonEliminar.Click += new EventHandler(this.BtnEliminar_Click);
            this.barraBotonesCRUD1.BotonEditar.Click += new EventHandler(this.BtnEditar_Click);
            this.barraBotonesCRUD1.BotonCancelar.Click += new EventHandler(this.BtnCancelar_Click);
            this.barraBotonesCRUD1.BotonGuardar.Click += new EventHandler(this.BtnGuardar_Click);

            // Cargar la lista de colores
            Fachada.TablasMaestras.Color color = new Fachada.TablasMaestras.Color();
            this.DgvColor.DataSource = color.Listar();
        }

        /// <summary>
        /// Al seleccionar una fila, llena los TextBox con los datos respectivos para que puedan ser editados.
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos para el evento</param>
        private void DgvColor_SelectionChanged(object sender, EventArgs e)
        {
            this.ValidarFormColores.Clear();

            if (this.DgvColor.SelectedRows.Count > 0)
            {
            DataGridViewRow filaActual = this.DgvColor.SelectedRows[0];
                this.TxtCodigoHexadecimal.Text = filaActual.Cells[1].Value.ToString();
                this.TxtNombre.Text = filaActual.Cells[2].Value.ToString();
                this.TxtCodigoHexadecimal.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + TxtCodigoHexadecimal.Text);
            }
        }

        /// <summary>
        /// Asigna al cuadro de texto TxtCódigoHexadecimal el código hexadecimal correspondiente al color creado con el cuadro de dialogo de color.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnShowColorDialog_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = null;            
            DialogResult resultado = System.Windows.Forms.DialogResult.OK;
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();

            try
            {
                colorDialog = new ColorDialog();
                resultado = colorDialog.ShowDialog();

                if (resultado == System.Windows.Forms.DialogResult.OK)
                {
                    this.TxtCodigoHexadecimal.BackColor = colorDialog.Color;
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            catch (Entidades.Excepciones.ExceptionErrorTransaccion)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0016");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
            }
            finally
            {
                if (colorDialog != null)
                {
                    ((IDisposable)colorDialog).Dispose();
                }
            }
        }

        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            this.ValidarFormColores.Clear();
        }

        private void ResetearBotonesOperacionGuardar()
        {
            this.barraBotonesCRUD1.BotonNuevo.Enabled = false;
            this.barraBotonesCRUD1.BotonEditar.Enabled = false;
            this.barraBotonesCRUD1.BotonGuardar.Enabled = true;
            this.barraBotonesCRUD1.BotonEliminar.Enabled = false;
        }
    }
}
