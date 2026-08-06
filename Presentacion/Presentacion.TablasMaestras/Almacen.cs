

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class Almacen : Form
    {
        public Almacen()
        {
            this.InitializeComponent();
        }

        private void Almacen_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Almacen Almacen = new Fachada.TablasMaestras.Almacen();
            Fachada.TablasMaestras.Pais Pais = new Fachada.TablasMaestras.Pais();

            this.DgvAlmacen.DataSource = Almacen.Listar();

            this.TxtNombreEmpresa.Enabled = false;
            this.TxtDescripcion.Enabled = false;
            this.TxtDireccion.Enabled = false;
            // CbCiudad.Enabled = false;
            // CbDepartamento.Enabled = false;
            // CbPais.Enabled = false;
            this.TxtTelefono1.Enabled = false;
            this.TxtTelefono2.Enabled = false;
            this.TxtFax.Enabled = false;
            this.TxtNitEmrpesa.Enabled = false;
            this.TxtSitioWeb.Enabled = false;
            this.TxtEmail.Enabled = false;

            this.barraBotonesCrud1.BotonGuardar.Click += this.BotonGuardar_Click;
            this.barraBotonesCrud1.BotonEliminar.Click += this.BotonEliminar_Click;
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Almacen tallas = new Fachada.TablasMaestras.Almacen();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");

                int idAlmacen = int.Parse(DgvAlmacen.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = tallas.Eliminar(idAlmacen);

                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                
                this.DgvAlmacen.Enabled = false;
                this.DgvAlmacen.DataSource = tallas.Listar();
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
                Fachada.TablasMaestras.Almacen Almacen = new Fachada.TablasMaestras.Almacen();

                // Entidades.Pais Pais = new Entidades.Pais();
                // Entidades.Departamento Departamento = new Entidades.Departamento();
                // Entidades.Ciudad Ciudad = new Entidades.Ciudad();

                Entidades.Almacen EntidadAlmacen = new Entidades.Almacen();
                EntidadAlmacen.NombreCompleto = this.TxtNombreEmpresa.Text; 
                EntidadAlmacen.Descripcion = this.TxtDescripcion.Text; 
                EntidadAlmacen.Direccion = this.TxtDireccion.Text;
                EntidadAlmacen.Telefono1 = this.TxtTelefono1.Text;
                EntidadAlmacen.Telefono2 = this.TxtTelefono2.Text;
                EntidadAlmacen.Ciudad.IdCiudad = int.Parse(ucPaisDepartamentoCiudad1.Cbciudad.SelectedValue.ToString()); 
                EntidadAlmacen.Fax = this.TxtFax.Text;
                EntidadAlmacen.Nit = int.Parse(this.TxtNitEmrpesa.Text);
                EntidadAlmacen.SitioWeb = this.TxtSitioWeb.Text;

                Entidades.ResultadoTransaccion resultadoTransaccion = Almacen.Insertar(EntidadAlmacen);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.DgvAlmacen.Enabled = false;
                this.DgvAlmacen.DataSource = Almacen.Listar();

                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
            }
            else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.Almacen Almacen = new Fachada.TablasMaestras.Almacen();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idAlmacen = int.Parse(DgvAlmacen.CurrentRow.Cells[0].Value.ToString(), culture);

                    Entidades.Almacen EntidadAlmacen = new Entidades.Almacen();
                    EntidadAlmacen.IdAlmacen = idAlmacen;
                    EntidadAlmacen.NombreCompleto = this.TxtNombreEmpresa.Text;
                    EntidadAlmacen.Descripcion = this.TxtDescripcion.Text;
                    EntidadAlmacen.Direccion = this.TxtDireccion.Text;
                    EntidadAlmacen.Telefono1 = this.TxtTelefono1.Text;
                    EntidadAlmacen.Telefono2 = this.TxtTelefono2.Text;


                    EntidadAlmacen.Ciudad.IdCiudad = int.Parse(ucPaisDepartamentoCiudad1.Cbciudad.SelectedValue.ToString());
                    EntidadAlmacen.Fax = TxtFax.Text;
                    Entidades.ResultadoTransaccion resultadoTransaccion = Almacen.Actualizar(EntidadAlmacen);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvAlmacen.Enabled = false;
                    this.DgvAlmacen.DataSource = Almacen.Listar();

                    // barraBotonesCrud1.BotonGuardar.Enabled = false;
                }
            }

            // this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;
        }

        private void DgvAlmacen_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvAlmacen.SelectedRows.Count > 0)
            {
                this.TxtNombreEmpresa.Text = this.DgvAlmacen.SelectedRows[0].Cells[1].Value.ToString();
                this.TxtDescripcion.Text = this.DgvAlmacen.SelectedRows[0].Cells[2].Value.ToString();
                this.TxtDireccion.Text = this.DgvAlmacen.SelectedRows[0].Cells[3].Value.ToString();
                this.ucPaisDepartamentoCiudad1.Cbciudad.SelectedItem = this.DgvAlmacen.SelectedRows[0].Cells[4].Value.ToString();
                this.TxtTelefono1.Text = this.DgvAlmacen.SelectedRows[0].Cells[5].Value.ToString();
                this.TxtTelefono2.Text = this.DgvAlmacen.SelectedRows[0].Cells[6].Value.ToString();
                this.TxtFax.Text = this.DgvAlmacen.SelectedRows[0].Cells[7].Value.ToString();
                this.TxtEmail.Text = this.DgvAlmacen.SelectedRows[0].Cells[8].Value.ToString();
                this.TxtNitEmrpesa.Text = this.DgvAlmacen.SelectedRows[0].Cells[9].Value.ToString();
                this.TxtSitioWeb.Text = this.DgvAlmacen.SelectedRows[0].Cells[10].Value.ToString();
            }
        }
    }
}
