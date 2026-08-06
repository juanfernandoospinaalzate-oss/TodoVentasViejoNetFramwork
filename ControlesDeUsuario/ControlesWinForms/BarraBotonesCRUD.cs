// -----------------------------------------------------------------------
// <copyright file="BarraBotonesCRUD.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------
namespace Controles.WinForms
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Barra de botones para trabajar formularios con operaciones CRUD
    /// </summary>
    public partial class BarraBotonesCrud : UserControl
    {
        /// <summary>
        /// Constructor de la barra de botones
        /// </summary>
        public BarraBotonesCrud()
        {
            this.InitializeComponent();
        }
        
        /// <summary>
        /// propiedad de acceso público a Botón Nuevo
        /// </summary>
        public Button BotonNuevo
        {
            get
            {
                return this.BtnNuevo;
            }

            set
            {
                this.BtnNuevo = value;
            }
        }

        /// <summary>
        /// propiedad de acceso público a Botón Editar 
        /// </summary>
        public Button BotonEditar
        {
            get
            {
                return this.BtnEditar;
            }

            set
            {
                this.BtnEditar = value;
            }
        }

        /// <summary>
        /// propiedad de acceso público a Botón Guardar
        /// </summary>
        public Button BotonGuardar
        {
            get
            {
                return this.BtnGuardar;
            }

            set
            {
                this.BtnGuardar = value;
            }
        }

        /// <summary>
        /// propiedad de acceso público a Botón Eliminar
        /// </summary>
        public Button BotonEliminar
        {
            get
            {
                return this.BtnEliminar;
            }

            set
            {
                this.BtnEliminar = value;
            }
        }

        /// <summary>
        /// propiedad de acceso público a Botón Cancelar
        /// </summary>
        public Button BotonCancelar
        {
            get
            {
                return this.BtnCancelar;
            }

            set
            {
                this.BtnCancelar = value;
            }
        }

        /// <summary>
        /// Expone al formulario contenedor la operación CRUD que se está ejecutando.
        /// </summary>
        public Entidades.Enumeraciones.Operacion OperacionCrud { get; set; }

        /// <summary>
        /// Pinta los botones de la BarraBotonesCRUD
        /// </summary>
        /// <param name="sender">Objeto que provoca el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        public void BarraBotonesCrudActivated(object sender, EventArgs e)
        {
            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0001");
            this.BtnNuevo.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0002");
            this.BtnEditar.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0003");
            this.BtnEliminar.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0004");
            this.BtnGuardar.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0005");
            this.BtnCancelar.Text = etiqueta.Texto;
        }

        // Reconfigura los botones habilitando el botón Guardar e inhabilitando, los botones nuevo, Editar y eliminar
        public void MantenerModoGuardado()
        {
            this.BotonGuardar.Enabled = true;
            this.BotonNuevo.Enabled = false;
            this.BotonEditar.Enabled = false;
            this.BotonEliminar.Enabled = false;
        }

        /// <summary>
        /// Pide confirmación antes de disparar las ejecuciones de eliminación.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            this.BotonEliminar.DialogResult = MessageBox.Show(Mensajes.LinqToXml.LeerMensaje("0001").Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
        }

        /// <summary>
        /// Prepara el formulario contenedor para comenzar con una operación de inserción de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.VaciarTextBox();
            this.VaciarCheckBox();
            this.VaciarRadioButton();
            this.HabilitarIhabilitarControles(Entidades.Enumeraciones.Estado.Habilitado);
            this.BtnNuevo.Enabled = false;
            this.BtnEditar.Enabled = false;
            this.BtnGuardar.Enabled = true;
            this.BtnEliminar.Enabled = false;
            this.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
        }

        /// <summary>
        /// Reinicia la barra de botones, vacía e inhabilita los textBox.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.VaciarTextBox();
            this.HabilitarIhabilitarControles(Entidades.Enumeraciones.Estado.Inhabilitado);
            this.BtnNuevo.Enabled = true;
            this.BtnEditar.Enabled = true;
            this.BtnGuardar.Enabled = false;
            this.BtnEliminar.Enabled = true;
            this.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
        }

        /// <summary>
        /// Borrar los datos de todos los textBox del formulario que contiene a esta barra.
        /// </summary>
        private void VaciarTextBox()
        {
            foreach (Control control in this.Parent.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }

                if (control is GroupBox)
                {
                    foreach (Control item in control.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = string.Empty;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Borrar los datos de todos los CheckBox del formulario que contiene a esta barra.
        /// </summary>
        private void VaciarCheckBox()
        {
            foreach (Control control in this.Parent.Controls)
            {
                CheckBox chk = control as CheckBox;
                if (chk != null)
                {
                    chk.Checked = false;
                }

                // En caso que el control sea un GroupBox se limpian los CheckBox internos
                if (control is GroupBox)
                {
                    foreach (Control item in control.Controls)
                    {
                        chk = item as CheckBox;
                        if (chk != null)
                        {
                            chk.Checked = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Borrar los datos de todos los RadioButton del formulario que contiene a esta barra.
        /// </summary>
        private void VaciarRadioButton()
        {
            foreach (Control control in this.Parent.Controls)
            {
                RadioButton RadioB = control as RadioButton;
                if (RadioB != null)
                {
                    RadioB.Checked = false;
                }

                // En caso que el control sea un GroupBox se limpian los CheckBox internos
                if (control is GroupBox)
                {
                    foreach (Control item in control.Controls)
                    {
                        RadioB = item as RadioButton;
                        if (RadioB != null)
                        {
                            RadioB.Checked = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Habilita o Inhabilita todos los textBox del formulario que contiene a esta barra.
        /// </summary>
        /// <param name="estado"> incida si se habilitan o se inhabilitan los controles</param>
        private void HabilitarIhabilitarControles(Entidades.Enumeraciones.Estado estado)
        {
            foreach (Control control in this.Parent.Controls)
            {
                if (control is TextBox || control is Button || control is ComboBox || control is CheckBox || control is UcCargaImagenes || control is RadioButton || control is DateTimePicker)
                {
                    if (estado == Entidades.Enumeraciones.Estado.Habilitado)
                    {
                        control.Enabled = true;
                    }
                    else
                    {
                        control.Enabled = false;
                    }
                }

                if (control is UctrCategorias)
                {
                    if (estado == Entidades.Enumeraciones.Estado.Habilitado)
                    {
                        (control as UctrCategorias).HabilitarInhabilitar(Entidades.Enumeraciones.Estado.Habilitado);
                    }
                    else
                    {
                        (control as UctrCategorias).HabilitarInhabilitar(Entidades.Enumeraciones.Estado.Inhabilitado);
                    }
                }

                if (control is GroupBox)
                {
                    // Recorrer los controles del groupBox
                    foreach (Control item in control.Controls)
                    {
                        // Si el control es un CheckBox
                        if (item is CheckBox || item is DateTimePicker || item is RadioButton || item is TextBox)
                        {
                            // Se habilita o inhabilita
                            if (estado == Entidades.Enumeraciones.Estado.Habilitado)
                            {
                                item.Enabled = true;
                            }
                            else
                            {
                                item.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Prepara el formulario contenedor para comenzar con una operación de actualización de datos.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.HabilitarIhabilitarControles(Entidades.Enumeraciones.Estado.Habilitado);
            this.BtnNuevo.Enabled = false;
            this.BtnEditar.Enabled = false;
            this.BtnGuardar.Enabled = true;
            this.BtnEliminar.Enabled = false;
            this.OperacionCrud = Entidades.Enumeraciones.Operacion.Edición;
        }

        /// <summary>
        /// Reservado para posible futuro uso, no modifica estados de los controles del formulario que contiene la barra.
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento click</param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            this.BtnNuevo.Enabled = true;
            this.BtnEditar.Enabled = true;
            this.BtnGuardar.Enabled = false;
            this.BtnEliminar.Enabled = true;
        }

        /// <summary>
        /// inicia la BarraBotonesCRUD
        /// </summary>
        /// <param name="sender">Objeto que provocó el llamado</param>
        /// <param name="e">Argumentos del evento</param>
        private void BarraBotonesCrud_Load(object sender, EventArgs e)
        {
            (this.Parent as Form).Activated += this.BarraBotonesCrudActivated;
        }
    }
}
