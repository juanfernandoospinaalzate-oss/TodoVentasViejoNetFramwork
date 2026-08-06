

namespace Presentacion.Facturacion
{
    using System;
    using System.Windows.Forms;

    public partial class ConfiguracionFactura : Form
    {
        public ConfiguracionFactura()
        {
            this.InitializeComponent();
        }

        private void ConfiguracionFactura_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Almacen Almacen = new Fachada.TablasMaestras.Almacen();
            
            this.CbAlmacen.DataSource = Almacen.Listar();
            this.CbAlmacen.DisplayMember = "NombreCompleto";
            this.CbAlmacen.ValueMember = "IdAlmacen";

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Fachada.Facturacion.ConfiguracionFactura ConfiguracionFactura = new Fachada.Facturacion.ConfiguracionFactura();
            Entidades.ConfiguracionFactura EntidadConfiguracionFactura = new Entidades.ConfiguracionFactura();
            EntidadConfiguracionFactura.NIT = this.TxtNIT.Text;
            EntidadConfiguracionFactura.TextoPieDePagina = this.TxtPiePagina.Text;
            EntidadConfiguracionFactura.UrlPaginaWeb = this.TxtUrlPaginaWeb.Text;

            Entidades.ResultadoTransaccion resultadoTransaccion = ConfiguracionFactura.Guardar(EntidadConfiguracionFactura);
            MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
        }

        private void BtnActualizarNroFactura_Click(object sender, EventArgs e)
        {
            Fachada.Facturacion.ConfiguracionFactura ConfiguracionFactura = new Fachada.Facturacion.ConfiguracionFactura();
            int NroFactura = int.Parse(TxtNroFactura.Text);
            Entidades.ResultadoTransaccion resultadoTransaccion = ConfiguracionFactura.Actualizar(NroFactura);
            MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
        }
    }
}
