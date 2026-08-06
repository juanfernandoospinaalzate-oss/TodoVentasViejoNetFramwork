

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class UnidadPresentacion : Form
    {
        public UnidadPresentacion()
        {
            this.InitializeComponent();
        }

        private void UnidadPresentacion_Load(object sender, EventArgs e)
        {
            this.barraBotonesCrud1.BotonGuardar.Click += this.BotonGuardar_Click;
            this.barraBotonesCrud1.BotonEliminar.Click += this.BotonEliminar_Click;
            Fachada.TablasMaestras.UnidadPresentacion unidadesPresentacion = new Fachada.TablasMaestras.UnidadPresentacion();
            this.dgvUnidadPresentacion.DataSource = unidadesPresentacion.Listar();
            this.txtNombre.Enabled = false;

        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.UnidadPresentacion unidadesPresentacion = new Fachada.TablasMaestras.UnidadPresentacion();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idUnidadPresentacion = int.Parse(this.dgvUnidadPresentacion.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = unidadesPresentacion.Eliminar(idUnidadPresentacion);

                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.dgvUnidadPresentacion.DataSource = unidadesPresentacion.Listar();

            }
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si se está insertando ó actualizando
            if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                // MODO INSERCIÓN
                // Si es una inserción, ingresar el dato a la base de datos                
                Fachada.TablasMaestras.UnidadPresentacion unidadesPresentacion = new Fachada.TablasMaestras.UnidadPresentacion();
                Entidades.UnidadPresentacion unidadPresentacion = new Entidades.UnidadPresentacion() { Nombre = this.txtNombre.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = unidadesPresentacion.Insertar(unidadPresentacion);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.dgvUnidadPresentacion.DataSource = unidadesPresentacion.Listar();
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.UnidadPresentacion unidadesPresentacion = new Fachada.TablasMaestras.UnidadPresentacion();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idUnidadPresentacion = int.Parse(this.dgvUnidadPresentacion.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.UnidadPresentacion unidadPresentacion = new Entidades.UnidadPresentacion() { IdUnidadPresentacion = idUnidadPresentacion, Nombre = this.txtNombre.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = unidadesPresentacion.Actualizar(unidadPresentacion);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.dgvUnidadPresentacion.DataSource = unidadesPresentacion.Listar();
                }
            }

        }
    }
}
