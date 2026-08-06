

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class Ciudad : Form
    {
        public Ciudad()
        {
            this.InitializeComponent();
        }

        private void Ciudad_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();
            Fachada.TablasMaestras.Departamento Departamento = new Fachada.TablasMaestras.Departamento();
            Fachada.TablasMaestras.Pais Pais = new Fachada.TablasMaestras.Pais();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");

            this.CmbPais.ValueMember = "IdPais";
            this.CmbPais.DisplayMember = "Nombre";
            this.CmbPais.DataSource = Pais.Listar();
            this.CmbPais.SelectedValue = 52;

            this.CmbDepartamento.ValueMember = "IdDepartamento";
            this.CmbDepartamento.DisplayMember = "Nombre";
            int idPais = (CmbPais.SelectedItem as Entidades.Pais).IdPais;
            this.CmbDepartamento.DataSource = Departamento.Listar(idPais);

            int idDpto = int.Parse(CmbDepartamento.SelectedValue.ToString());
            if (idDpto != 0)
            {
                this.DgvCiudad.DataSource = Ciudad.Listar(idDpto);
            }

            this.barraBotonesCrud1.BotonGuardar.Click += new EventHandler(this.BotonGuardarClick);
            this.barraBotonesCrud1.BotonEliminar.Click += new EventHandler(this.BotonEliminarClick);

            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0149");
            this.LblCiudad.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0150");
            this.LblDepartamento.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0151");
            this.IdCiudad.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0152");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0153");
            this.Text = etiqueta.Texto;

            this.DgvCiudad.Columns[1].Visible = false;
        }

        public void BotonEliminarClick(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idDepartamento = int.Parse(this.DgvCiudad.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = Ciudad.Eliminar(idDepartamento);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvCiudad.Enabled = false;
                int idDpto = (CmbDepartamento.SelectedItem as Entidades.Departamento).IdDepartamento;
                this.DgvCiudad.DataSource = Ciudad.Listar(idDpto);
                this.barraBotonesCrud1.BotonNuevo.Enabled = false;
                this.barraBotonesCrud1.BotonEditar.Enabled = false;
                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
                this.barraBotonesCrud1.BotonEliminar.Enabled = false;
            }
        }

        public void BotonGuardarClick(object sender, EventArgs e)
        {
            if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();

                Entidades.Ciudad ciudad = new Entidades.Ciudad();
                ciudad.Nombre = TxtCiudad.Text;
                ciudad.Departamento.IdDepartamento = (this.CmbDepartamento.SelectedItem as Entidades.Departamento).IdDepartamento;

                Entidades.ResultadoTransaccion resultadoTransaccion = Ciudad.Insertar(ciudad);
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idciudad = int.Parse(this.DgvCiudad.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.Ciudad ciudad = new Entidades.Ciudad() { IdCiudad = idciudad, Nombre = this.TxtCiudad.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = Ciudad.Actualizar(ciudad);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvCiudad.Enabled = false;
                    int idDpto = (this.CmbDepartamento.SelectedItem as Entidades.Departamento).IdDepartamento;
                    this.DgvCiudad.DataSource = Ciudad.Listar(idDpto);

                    barraBotonesCrud1.BotonGuardar.Enabled = false;
                }
            }
        }

        private void CmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Ciudad Ciudad = new Fachada.TablasMaestras.Ciudad();
            int idDpto = int.Parse(CmbDepartamento.SelectedValue.ToString());
            if (idDpto != 0)
            {
                this.DgvCiudad.DataSource = Ciudad.Listar(idDpto);
            }
        }


                   
    }
}
