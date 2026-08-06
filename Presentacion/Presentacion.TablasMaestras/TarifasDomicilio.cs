

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class TarifasDomicilio : Form
    {
        public TarifasDomicilio()
        {
            this.InitializeComponent();
        }

        private void TarifasDomicilio_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.TarifasDomicilio TarifasDomicilio = new Fachada.TablasMaestras.TarifasDomicilio();
            this.dgvTarifasDomicilio.DataSource = TarifasDomicilio.Listar();

            this.barraBotonesCrud1.BotonNuevo.Click += this.BotonNuevo_Click;
            this.barraBotonesCrud1.BotonGuardar.Click += this.BotonGuardar_Click;
            this.barraBotonesCrud1.BotonEliminar.Click += this.BotonEliminar_Click;

            this.barraBotonesCrud1.BotonCancelar.Click += this.BotonCancelar_Click;

            this.dgvTarifasDomicilio.Columns[0].Visible = false;
            this.dgvTarifasDomicilio.Columns[1].HeaderText = "Ubicación domicilio";
            this.dgvTarifasDomicilio.Columns[2].HeaderText = "Valor domicilio";

            this.TxtTarifaDomicilioNuevo.Enabled = false;
            this.TxtValorTarifaDomicilio.Enabled = false;

        }

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.TxtTarifaDomicilioNuevo.Enabled = false;
            this.TxtValorTarifaDomicilio.Enabled = false;
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.TarifasDomicilio EstadoDeLaVenta = new Fachada.TablasMaestras.TarifasDomicilio();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idTarifasDomicilio = int.Parse(this.dgvTarifasDomicilio.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = EstadoDeLaVenta.Eliminar(idTarifasDomicilio);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.dgvTarifasDomicilio.DataSource = EstadoDeLaVenta.Listar();
                this.dgvTarifasDomicilio.Enabled = false;

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
                // MODO INSERCIÓN
                // Si es una inserción, ingresar el dato a la base de datos                
                Fachada.TablasMaestras.TarifasDomicilio TarifasDomicilio = new Fachada.TablasMaestras.TarifasDomicilio();
                Entidades.TarifasDomicilio tfDomicilio = new Entidades.TarifasDomicilio() {
                    TarifaDomicilioNuevo = this.TxtTarifaDomicilioNuevo.Text,
                    ValorDomicilio = double.Parse(this.TxtValorTarifaDomicilio.Text)
                };
                Entidades.ResultadoTransaccion resultadoTransaccion = TarifasDomicilio.Insertar(tfDomicilio);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.dgvTarifasDomicilio.DataSource = TarifasDomicilio.Listar();

                this.TxtTarifaDomicilioNuevo.Enabled = false;
                this.TxtTarifaDomicilioNuevo.Text = string.Empty;

                this.TxtValorTarifaDomicilio.Enabled = false;
                this.TxtValorTarifaDomicilio.Text = string.Empty;

                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.TarifasDomicilio TarifasDomicilio = new Fachada.TablasMaestras.TarifasDomicilio();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idTarifasDomicilio = int.Parse(this.dgvTarifasDomicilio.CurrentRow.Cells[0].Value.ToString(), culture);

                    Entidades.TarifasDomicilio tfDomicilio = new Entidades.TarifasDomicilio()
                    {
                        IdTarifasDomicilio = idTarifasDomicilio,
                        TarifaDomicilioNuevo = this.TxtTarifaDomicilioNuevo.Text,
                        ValorDomicilio = double.Parse(this.TxtValorTarifaDomicilio.Text)
                    };

                    Entidades.ResultadoTransaccion resultadoTransaccion = TarifasDomicilio.Actualizar(tfDomicilio);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.dgvTarifasDomicilio.DataSource = TarifasDomicilio.Listar();

                    this.TxtTarifaDomicilioNuevo.Enabled = false;
                    this.TxtTarifaDomicilioNuevo.Text = string.Empty;

                    this.TxtValorTarifaDomicilio.Enabled = false;
                    this.TxtValorTarifaDomicilio.Text = string.Empty;

                    this.barraBotonesCrud1.BotonGuardar.Enabled = false;
                }
            }
        }

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            this.TxtTarifaDomicilioNuevo.Enabled = true;
            this.TxtValorTarifaDomicilio.Enabled = true;
        }

        private void DgvTarifasDomicilio_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvTarifasDomicilio.SelectedRows.Count > 0)
            {
                DataGridViewRow filaActual = this.dgvTarifasDomicilio.SelectedRows[0];
                this.TxtTarifaDomicilioNuevo.Text = filaActual.Cells[1].Value.ToString();
                this.TxtValorTarifaDomicilio.Text = filaActual.Cells[2].Value.ToString();
            }
        }
    }
}
