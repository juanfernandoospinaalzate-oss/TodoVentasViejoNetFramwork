

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class MedioDePago : Form
    {
        public MedioDePago()
        {
            this.InitializeComponent();
        }

        private void MedioDePago_Load(object sender, EventArgs e)
        {
            this.TxtNombre.Enabled = false;
            this.TxtDescripcion.Enabled = false;

            Fachada.TablasMaestras.MedioDePago medioPago = new Fachada.TablasMaestras.MedioDePago();
            this.dgvMetodoDePago.DataSource = medioPago.Listar();

            this.dgvMetodoDePago.Columns[1].Width = 180;
            this.dgvMetodoDePago.Columns[2].Width = 200;

            this.barraBotonesCrud1.BotonNuevo.Click += new EventHandler(this.BotonNuevo_Click);
            this.barraBotonesCrud1.BotonGuardar.Click += new EventHandler(this.BotonGuardar_Click);
            this.barraBotonesCrud1.BotonEliminar.Click += new EventHandler(this.BotonEliminar_Click);
            this.barraBotonesCrud1.BotonCancelar.Click += new EventHandler(this.BotonCancelar_Click);
        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.TxtNombre.Enabled = false;
            this.TxtDescripcion.Enabled = false;
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.MedioDePago metodoDePago = new Fachada.TablasMaestras.MedioDePago();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idMetodoDePago = int.Parse(this.dgvMetodoDePago.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = metodoDePago.Eliminar(idMetodoDePago);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.dgvMetodoDePago.Enabled = false;
                this.dgvMetodoDePago.DataSource = metodoDePago.Listar();
                this.barraBotonesCrud1.BotonNuevo.Enabled = false;
                this.barraBotonesCrud1.BotonEditar.Enabled = false;
                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
                this.barraBotonesCrud1.BotonEliminar.Enabled = false;
            }
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                Fachada.TablasMaestras.MedioDePago metodoDePago = new Fachada.TablasMaestras.MedioDePago();
                Entidades.MetodoDePago medioDePago = new Entidades.MetodoDePago() {
                    Nombre = this.TxtNombre.Text,
                    Descripcion = this.TxtDescripcion.Text
                };
                Entidades.ResultadoTransaccion resultadoTransaccion = metodoDePago.Insertar(medioDePago);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.dgvMetodoDePago.DataSource = metodoDePago.Listar();
                this.TxtNombre.Enabled = false;
                this.TxtDescripcion.Enabled = false;
                this.TxtNombre.Text = string.Empty;
                this.TxtDescripcion.Text = string.Empty;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.MedioDePago metodoDePago = new Fachada.TablasMaestras.MedioDePago();

                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idMetodoDePago = int.Parse(this.dgvMetodoDePago.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.MetodoDePago medioDePago = new Entidades.MetodoDePago() {
                        IdMetodoDePago = idMetodoDePago,
                        Nombre = this.TxtNombre.Text,
                        Descripcion = this.TxtDescripcion.Text
                    };
                    Entidades.ResultadoTransaccion resultadoTransaccion = metodoDePago.Actualizar(medioDePago);
                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.dgvMetodoDePago.DataSource = metodoDePago.Listar();
                    this.TxtNombre.Enabled = false;
                    this.TxtDescripcion.Enabled = false;
                    this.TxtNombre.Text = string.Empty;
                    this.TxtDescripcion.Text = string.Empty;
                }
            }

            this.barraBotonesCrud1.BotonNuevo.Enabled = true;
            this.barraBotonesCrud1.BotonEditar.Enabled = true;
            this.barraBotonesCrud1.BotonGuardar.Enabled = false;
            this.barraBotonesCrud1.BotonEliminar.Enabled = true;

            if (dgvMetodoDePago.Rows.Count > 0)
            {
                this.dgvMetodoDePago.Rows[0].Selected = false;
                this.dgvMetodoDePago.Rows[0].Selected = true;
            }
        }

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            this.TxtNombre.Enabled = true;
            this.TxtDescripcion.Enabled = true;
            this.TxtNombre.Focus();
        }

        private void DgvMetodoDePago_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMetodoDePago.SelectedRows.Count > 0)
            {
                DataGridViewRow filaActual = this.dgvMetodoDePago.SelectedRows[0];
                this.TxtNombre.Text = filaActual.Cells[1].Value.ToString();
                this.TxtDescripcion.Text = filaActual.Cells[2].Value.ToString();
            }
        }
    }
}
