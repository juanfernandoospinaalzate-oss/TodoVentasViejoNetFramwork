

namespace Presentacion.Busquedas
{
    using System;
    using System.Windows.Forms;

    public partial class Color : Form
    {
        public Color()
        {
            this.InitializeComponent();
        }

        public Entidades.Color ColorSeleccionado { get; set; }

        private void Color_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Color color = new Fachada.TablasMaestras.Color();
            dataGridView1.DataSource = color.Listar();

            // Pintar las celdas del DataGridView.
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                DataGridViewRow filaActual = this.dataGridView1.Rows[i];
                System.Drawing.Color colorCelda = System.Drawing.ColorTranslator.FromHtml("#" + filaActual.Cells[1].Value.ToString());
                filaActual.Cells[2].Style.BackColor = colorCelda;

                // Cambiar el estilo de la celda seleccionada (color) porel mismo color para no cambiar el color de fondo al seleccionar
                filaActual.Cells[2].Style.SelectionBackColor = colorCelda;
            }

            // Ocultar la primera columna
            dataGridView1.Columns[0].Visible = false;

            // modificar el ancho de la columna del nombre para dejar ver el texto completo
            dataGridView1.Columns[2].Width = 200;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ColorSeleccionado = dataGridView1.Rows[e.RowIndex].DataBoundItem as Entidades.Color;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
