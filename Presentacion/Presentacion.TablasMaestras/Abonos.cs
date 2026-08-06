

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class Abonos : Form
    {
        List<Entidades.Abonos> LstGlobalAbonos = new List<Entidades.Abonos>();  
        public Abonos()
        {
            this.InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Abonos objAbonos = new Fachada.TablasMaestras.Abonos();            
            string criterioBusqueda = txtBusqueda.Text;

            // List<Entidades.Abonos> ListaFiltrada = new List<Entidades.Abonos>(objAbonos.Listar(criterioBusqueda));
            this.dgvAbonos.DataSource = objAbonos.Listar(criterioBusqueda);
            // LstGlobalAbonos.AddRange(ListaFiltrada);
        }

        private void Abonos_Load(object sender, EventArgs e)
        {
            this.txtBusqueda.Text = "Ejemplo: Nro.Factura, documento de identificación o nombre y apellido. etcétera...";
            this.txtBusqueda.GotFocus += this.TxtBuscarFactura_GotFocus;
            this.txtBusqueda.LostFocus += this.TxtBuscarFactura_LostFocus;

            Fachada.TablasMaestras.Abonos objAbonos = new Fachada.TablasMaestras.Abonos();
            string criterioBusqueda = this.txtBusqueda.Text;
            this.dgvAbonos.DataSource = this.LstGlobalAbonos;

        }

        private void TxtBuscarFactura_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                this.txtBusqueda.Text = "Ejemplo: Nro.Factura, documento de identificación o nombre y apellido. etcétera...";
            }
        }

        private void TxtBuscarFactura_GotFocus(object sender, EventArgs e)
        {
            this.txtBusqueda.Text = string.Empty;
        }
    }
}
