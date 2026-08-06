

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class Catalogo : Form
    {
        public Catalogo()
        {
            this.InitializeComponent();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.ConfiguracionCatalogoPDF ConfiguracionGeneralCatalogoPDF = new Fachada.TablasMaestras.ConfiguracionCatalogoPDF();
            Fachada.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias configuracionCatalogoPDFPorCategorias = new Fachada.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            Entidades.ConfiguracionCatalogoPDF configuracionCatalogoPDF = null;

            configuracionCatalogoPDF = ConfiguracionGeneralCatalogoPDF.Consultar();

            if (configuracionCatalogoPDF != null)
            {
                this.ChkExistencias.Checked = configuracionCatalogoPDF.Existencias;
                this.ChkPrecio.Checked = configuracionCatalogoPDF.Precio;
                this.TxtNroColumnas.Text = configuracionCatalogoPDF.NroDeColumnas.ToString();
            }
            
            this.DgvCatalogo.DataSource = configuracionCatalogoPDFPorCategorias.Consultar();

            uctrCategorias1.HabilitarInhabilitar(Entidades.Enumeraciones.Estado.Habilitado);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new Fachada.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-CO");
            int idCategoria = int.Parse(DgvCatalogo.CurrentRow.Cells[0].Value.ToString(), culture);
            Entidades.ResultadoTransaccion resultadoEliminar = null;
            resultadoEliminar = Catalogo.Eliminar(idCategoria);

            MessageBox.Show(resultadoEliminar.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);

            this.DgvCatalogo.DataSource = Catalogo.Consultar();
        }

        private void BtnGuardarConfiguracionGeneral_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.ConfiguracionCatalogoPDF catalogoPDF = new Fachada.TablasMaestras.ConfiguracionCatalogoPDF();
            Entidades.ConfiguracionCatalogoPDF configuracionCatalogoPDF = new Entidades.ConfiguracionCatalogoPDF();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            int nroColumnas = int.MinValue;

            if (int.TryParse(this.TxtNroColumnas.Text, out nroColumnas) == false)
            {
                if (nroColumnas == 0)
                {
                    this.TxtNroColumnas.Text = nroColumnas.ToString();
                }
            }

            configuracionCatalogoPDF.Existencias = this.ChkExistencias.Checked;
            configuracionCatalogoPDF.Precio = this.ChkPrecio.Checked;
            configuracionCatalogoPDF.NroDeColumnas = nroColumnas;
            catalogoPDF.Insertar(configuracionCatalogoPDF);
        }

        private void BtnAgregarConfiguracionPorCategoria_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias Catalogo = new Fachada.TablasMaestras.ConfiguracionCatalogoPDFPorCategorias();
            Entidades.ConfiguracionCatalogoPorCategorias ConfiguracionCatalogoPorCategorias = new Entidades.ConfiguracionCatalogoPorCategorias();
            Entidades.ResultadoTransaccion resultadoTransaccion = new Entidades.ResultadoTransaccion();
            int nroColumnas = int.MinValue;

            if (this.uctrCategorias1.TreeViewCategorias.SelectedNode == null)
            {
                resultadoTransaccion.Mensaje = Mensajes.LinqToXml.LeerMensaje("0054");
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(resultadoTransaccion.Mensaje.Texto));
                errorProvider1.SetError(this.uctrCategorias1, resultadoTransaccion.Mensaje.Texto);
                return;
            }

            if (int.TryParse(this.txtNroColumnasPorCategoria.Text, out nroColumnas) == false)
            {
                if (nroColumnas == 0)
                {
                    this.txtNroColumnasPorCategoria.Text = nroColumnas.ToString();
                }
            }

            ConfiguracionCatalogoPorCategorias.NroColumnas = nroColumnas;
            ConfiguracionCatalogoPorCategorias.Categoria.IdCategoria = (this.uctrCategorias1.TreeViewCategorias.SelectedNode.Tag as Entidades.Categoria).IdCategoria;
            resultadoTransaccion = Catalogo.Insertar(ConfiguracionCatalogoPorCategorias);
            this.DgvCatalogo.DataSource = Catalogo.Consultar();
        }
    }
}
