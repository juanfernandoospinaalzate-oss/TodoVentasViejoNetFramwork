

namespace Presentacion.Facturacion
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// FORMULARIO MODAL O POPUP ASOCIADO AL FORMULARIO FACTURACIÓN.
    /// </summary>
    public partial class AbonoPresentacionArticulo : Form
    {
        public string ValorAbonado { get; set; }

        public AbonoPresentacionArticulo()
        {
            this.InitializeComponent();
        }

        private void BtnAbonarPago_Click(object sender, EventArgs e)
        {
            this.ValorAbonado = TxtValorAbono.Text;
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();            
        }
    }
}