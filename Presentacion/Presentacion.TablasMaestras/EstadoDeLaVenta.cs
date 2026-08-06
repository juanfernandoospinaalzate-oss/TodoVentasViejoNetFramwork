

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class EstadoDeLaVenta : Form
    {
        public EstadoDeLaVenta()
        {
            this.InitializeComponent();
        }

        private void EstadoDeLaVenta_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new Fachada.TablasMaestras.EstadoDELAVenta();
            this.DgvEstadoDeLaVenta.DataSource = EstadoDeLaVenta.Listar();

            TxtEstadoNuevo.Enabled = false;

            this.DgvEstadoDeLaVenta.Columns[0].Visible = false;

            this.barraBotonesCrud1.BotonGuardar.Click += this.BotonGuardar_Click;
            this.barraBotonesCrud1.BotonEliminar.Click += this.BotonEliminar_Click;
            this.barraBotonesCrud1.BotonNuevo.Click += this.BotonNuevo_Click;
            this.barraBotonesCrud1.BotonCancelar.Click += this.BotonCancelar_Click;
        }


        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.TxtEstadoNuevo.Enabled = false;
        }

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            this.TxtEstadoNuevo.Enabled = true;
            this.TxtEstadoNuevo.Focus();
        }


        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new Fachada.TablasMaestras.EstadoDELAVenta();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idEstadoVenta = int.Parse(this.DgvEstadoDeLaVenta.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = EstadoDeLaVenta.Eliminar(idEstadoVenta);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvEstadoDeLaVenta.DataSource = EstadoDeLaVenta.Listar();
                this.DgvEstadoDeLaVenta.Enabled = false;

                this.barraBotonesCrud1.BotonNuevo.Enabled = false;
                this.barraBotonesCrud1.BotonEditar.Enabled = false;
                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
                this.barraBotonesCrud1.BotonEliminar.Enabled = false;
            }
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si se está insertando ó actualizando una categoria
            if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                // MODO INSERCIÓN
                // Si es una inserción, ingresar el dato a la base de datos                
                Fachada.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new Fachada.TablasMaestras.EstadoDELAVenta();
                Entidades.EstadoVenta estadoDeLaVenta = new Entidades.EstadoVenta() { EstadoNuevo = this.TxtEstadoNuevo.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = EstadoDeLaVenta.Insertar(estadoDeLaVenta);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvEstadoDeLaVenta.DataSource = EstadoDeLaVenta.Listar();
                this.TxtEstadoNuevo.Enabled = false;
                this.TxtEstadoNuevo.Text = string.Empty;

                // this.DgvIdEstadoDeLaVenta.DataSource = EstadoDeLaVenta.Listar();

                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.EstadoDELAVenta EstadoDeLaVenta = new Fachada.TablasMaestras.EstadoDELAVenta();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idEstadoVenta = int.Parse(DgvEstadoDeLaVenta.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.EstadoVenta EstadoVenta = new Entidades.EstadoVenta() { IdEstadoDeLaVenta = idEstadoVenta, EstadoNuevo = this.TxtEstadoNuevo.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = EstadoDeLaVenta.Actualizar(EstadoVenta);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvEstadoDeLaVenta.DataSource = EstadoDeLaVenta.Listar();
                    this.TxtEstadoNuevo.Enabled = false;
                    this.TxtEstadoNuevo.Text = string.Empty;
                    // this.DgvIdEstadoDeLaVenta.DataSource = EstadoDeLaVenta.Listar();

                    barraBotonesCrud1.BotonGuardar.Enabled = false;
                }
            }
        }

        private void DgvEstadoDeLaVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvEstadoDeLaVenta.SelectedRows.Count > 0)
            {
                DataGridViewRow filaActual = this.DgvEstadoDeLaVenta.SelectedRows[0];
                this.TxtEstadoNuevo.Text = filaActual.Cells[1].Value.ToString();               
            }
        }
    }
}
