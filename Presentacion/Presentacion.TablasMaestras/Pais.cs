

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class Pais : Form
    {
        public Pais()
        {
            this.InitializeComponent();
        }

        private void Pais_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Pais Pais = new Fachada.TablasMaestras.Pais();

            Entidades.EtiquetaControles etiqueta = null;
            etiqueta = new Entidades.EtiquetaControles();

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0159");
            this.LblNombre.Text = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0160");
            this.IdPais.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0161");
            this.Nombre.HeaderText = etiqueta.Texto;

            etiqueta = Mensajes.LinqToXml.LeerEtiquetaControles("0162");
            this.Text = etiqueta.Texto;

            this.barraBotonesCrud1.BotonGuardar.Click += new EventHandler(this.BotonGuardar_Click);
            this.barraBotonesCrud1.BotonEliminar.Click += new EventHandler(this.BotonEliminar_Click);

            this.DgvPais.DataSource = Pais.Listar();

        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            // Si la transacción fué exitosa
            if (this.barraBotonesCrud1.BotonEliminar.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Fachada.TablasMaestras.Pais Pais = new Fachada.TablasMaestras.Pais();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                int idpais = int.Parse(this.DgvPais.CurrentRow.Cells[0].Value.ToString(), culture);
                Entidades.ResultadoTransaccion resultadoEliminar = null;
                resultadoEliminar = Pais.Eliminar(idpais);
                MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DgvPais.Enabled = false;
                this.DgvPais.DataSource = Pais.Listar();
                this.barraBotonesCrud1.BotonNuevo.Enabled = false;
                this.barraBotonesCrud1.BotonEditar.Enabled = false;
                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
                this.barraBotonesCrud1.BotonEliminar.Enabled = false;
            }
        }

        private void BotonGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si se está insertando ó actualizando
            if (this.barraBotonesCrud1.OperacionCrud == Entidades.Enumeraciones.Operacion.Insercion)
            {
                // MODO INSERCIÓN
                // Si es una inserción, ingresar el dato a la base de datos                
                Fachada.TablasMaestras.Pais Pais = new Fachada.TablasMaestras.Pais();
                Entidades.Pais pais = new Entidades.Pais() { Nombre = this.TxtNombre.Text };
                Entidades.ResultadoTransaccion resultadoTransaccion = Pais.Insertar(pais);

                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

                this.DgvPais.Enabled = false;
                this.DgvPais.DataSource = Pais.Listar();

                this.barraBotonesCrud1.BotonGuardar.Enabled = false;
            }
            /*else
            {
                // MODO ACTUALIZACIÓN
                if (this.barraBotonesCRUD1.OperacionCrud == Entidades.Enumeraciones.Operacion.Edición)
                {
                    Fachada.TablasMaestras.Talla tallas = new Fachada.TablasMaestras.Talla();
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
                    int idtalla = int.Parse(DgvTalla.CurrentRow.Cells[0].Value.ToString(), culture);
                    Entidades.Talla talla = new Entidades.Talla() { IdTalla = idtalla, Nombre = this.TxtTalla.Text };
                    Entidades.ResultadoTransaccion resultadoTransaccion = tallas.Actualizar(talla);

                    MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                    this.DgvTalla.Enabled = false;
                    this.DgvTalla.DataSource = tallas.Listar();

                    barraBotonesCRUD1.BotonGuardar.Enabled = false;
                }
            }

            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Indeterminada;*/
        }
    }
}
