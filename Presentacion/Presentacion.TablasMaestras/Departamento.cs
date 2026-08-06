

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class Departamento : Form
    {
        public Departamento()
        {
            this.InitializeComponent();
        }

        private void Departamento_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Departamento Departamento = new Fachada.TablasMaestras.Departamento();
            Fachada.TablasMaestras.Pais Pais = new Fachada.TablasMaestras.Pais();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");

            this.CbPais.ValueMember = "IdPais";
            this.CbPais.DisplayMember = "Nombre";
            this.CbPais.DataSource = Pais.Listar();
            this.CbPais.SelectedValue = 52;

            int idPais = int.Parse(CbPais.SelectedValue.ToString());
            if (idPais != 0)
            {                
                this.DgvDepartamento.DataSource = Departamento.Listar(idPais);                
            }

            this.barraBotonesCrud1.BotonGuardar.Click += new EventHandler(this.BotonGuardarClick);
            this.barraBotonesCrud1.BotonEliminar.Click += new EventHandler(this.BotonEliminarClick);


            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0154");
            this.LblDepartamento.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0155");
            this.LblPais.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0156");
            this.IdDepartamento.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0157");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0158");
            this.Text = etiqueta.Texto;

            this.DgvDepartamento.Columns[1].Visible = false;

        }

        public void BotonEliminarClick(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Departamento Departamento = new Fachada.TablasMaestras.Departamento();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idDepartamento = int.Parse(this.DgvDepartamento.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = Departamento.Eliminar(idDepartamento);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvDepartamento.Enabled = false;
                this.DgvDepartamento.DataSource = Departamento.Listar(idDepartamento);
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
                Fachada.TablasMaestras.Departamento Departamento = new Fachada.TablasMaestras.Departamento();

                Entidades.Departamento departamento = new Entidades.Departamento();
                departamento.Nombre = this.TxtDepartamento.Text;
                departamento.Pais.IdPais = (this.CbPais.SelectedItem as Entidades.Pais).IdPais;

                Entidades.ResultadoTransaccion resultadoTransaccion = Departamento.Insertar(departamento);
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.Departamento Departamento = new Fachada.TablasMaestras.Departamento();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idDepartamento = int.Parse(this.DgvDepartamento.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.Departamento departamento = new Entidades.Departamento() { IdDepartamento = idDepartamento, Nombre = this.TxtDepartamento.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = Departamento.Actualizar(departamento);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvDepartamento.Enabled = false;
                    this.DgvDepartamento.DataSource = Departamento.Listar(idDepartamento);

                    this.barraBotonesCrud1.BotonGuardar.Enabled = false;
                }

            }
        }

        private void CbPais_SelectedIndexChanged(object sender, EventArgs e)
        {     
                        
        }
    }
}
