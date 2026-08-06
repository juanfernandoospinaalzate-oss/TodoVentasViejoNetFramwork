// -----------------------------------------------------------------------
// <copyright file="DetalleOrdenesCompra.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// -----------------------------------------------------------------------

namespace Presentacion.Facturacion
{
    using Entidades.Enumeraciones;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class DetalleOrdenesCompra : Form
    {
        private Entidades.Cliente cliente = null;

        public DetalleOrdenesCompra()
        {
            this.InitializeComponent();
        }

        private void BtnFacurarOrdenCompra_Click(object sender, EventArgs e)
        {
            Fachada.Facturacion.OrdenesCompra objOrdenesCompra = new Fachada.Facturacion.OrdenesCompra();
            Fachada.TablasMaestras.Cliente Cliente = new Fachada.TablasMaestras.Cliente();
            List<Entidades.PresentacionArticulo> ListaPresentaciones = new List<Entidades.PresentacionArticulo>();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListaDetalleOrdenesCompra = dgvDetalleOrdenCompra.DataSource as System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompraDetalle>;
            int IdAlbaran = int.Parse(dgvOrdenesCompra.SelectedRows[0].Cells[7].Value.ToString());
            int Identificacion = int.Parse(dgvOrdenesCompra.SelectedRows[0].Cells[2].Value.ToString());
            this.cliente = Cliente.BuscarClientePorDocCliente(Identificacion);


            for (int i = 0; i < ListaDetalleOrdenesCompra.Count; i++)
            {
                int auxExistencias = ListaDetalleOrdenesCompra[i].Cantidad;
                Fachada.TablasMaestras.PresentacionArticulo ObjPresentacionArticulo = new Fachada.TablasMaestras.PresentacionArticulo();
                ListaPresentaciones.Add(ObjPresentacionArticulo.ConsultarPorId(ListaDetalleOrdenesCompra[i].IdPresentacionArticulo));
                ListaPresentaciones[i].Existencias = auxExistencias;
                
            }
            Entidades.ResultadoTransaccion resultado = objOrdenesCompra.ConfirmarOrdenCompra(ListaPresentaciones, this.cliente, IdAlbaran);

            if (resultado.RegistrosAfectados == 0)
            {
                MessageBox.Show("Orden de compra facturada con éxito!.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                string filtroBusqueda = string.Empty;

                if (rbNumeroOrden.Checked == true)
                {
                    filtroBusqueda = TxtOrdenCompra.Text;
                    this.dgvOrdenesCompra.DataSource = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NumeroOrdenCompra, filtroBusqueda);
                }
                if (rbNumeroIdentificacion.Checked == true)
                {
                    filtroBusqueda = txtNumeroIdentificacion.Text;
                    this.dgvOrdenesCompra.DataSource = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NumeroIdentificacion, filtroBusqueda);
                }
                if (rbNombreCliente.Checked == true)
                {
                    filtroBusqueda = txtNombreCliente.Text;
                    this.dgvOrdenesCompra.DataSource = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NombreCliente, filtroBusqueda);
                }
            }

            if (dgvOrdenesCompra.SelectedRows.Count == 0)
            {
                dgvDetalleOrdenCompra.DataSource = null;
                dgvDetalleOrdenCompra.Refresh();
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            Fachada.Facturacion.OrdenesCompra objOrdenesCompra = new Fachada.Facturacion.OrdenesCompra();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompra> ListaEncabezadoOrdenCompra = null;
            dgvOrdenesCompra.DataSource = null;

            string filtroBusqueda = string.Empty;

            if (rbNumeroOrden.Checked == true)
            {
                filtroBusqueda = TxtOrdenCompra.Text;
                ListaEncabezadoOrdenCompra = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NumeroOrdenCompra, filtroBusqueda);
            }
            if (rbNumeroIdentificacion.Checked == true)
            {
                filtroBusqueda = txtNumeroIdentificacion.Text;
                ListaEncabezadoOrdenCompra = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NumeroIdentificacion, filtroBusqueda);
            }
            if (rbNombreCliente.Checked == true)
            {
                filtroBusqueda = txtNombreCliente.Text;
                ListaEncabezadoOrdenCompra = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NombreCliente, filtroBusqueda);
            }
                        
            dgvOrdenesCompra.DataSource = ListaEncabezadoOrdenCompra;

            if (dgvOrdenesCompra.DataSource != null)
            {
                this.dgvOrdenesCompra.Columns[7].Visible = false;
            }
            
        }

        private void DgvOrdenesCompra_SelectionChanged(object sender, EventArgs e)
        {
            Fachada.Facturacion.OrdenesCompra objOrdenesCompra = new Fachada.Facturacion.OrdenesCompra();
            if (dgvOrdenesCompra.SelectedRows.Count > 0)
            {
                int IdAlbaran = int.Parse(dgvOrdenesCompra.SelectedRows[0].Cells[7].Value.ToString());
                System.Collections.ObjectModel.ReadOnlyCollection<Entidades.OrdenesCompraDetalle> ListaDetalleOrdenesCompra = objOrdenesCompra.ListarOrdenesCompraDetallePorIdentificador(IdAlbaran);

                dgvDetalleOrdenCompra.DataSource = ListaDetalleOrdenesCompra;
            }
        }

        private void BtnCancelarOrdenCompra_Click(object sender, EventArgs e)
        {
            Fachada.Facturacion.OrdenesCompra objOrdenesCompra = new Fachada.Facturacion.OrdenesCompra();
            int IdAlbaran = int.Parse(dgvOrdenesCompra.SelectedRows[0].Cells[7].Value.ToString());
            Entidades.ResultadoTransaccion respuesta = objOrdenesCompra.EliminarOrdenCompraLogico(IdAlbaran);

            if (respuesta.RegistrosAfectados == 1)
            {
                MessageBox.Show(respuesta.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                string filtroBusqueda = string.Empty;

                if (rbNumeroOrden.Checked == true)
                {
                    filtroBusqueda = TxtOrdenCompra.Text;
                    this.dgvOrdenesCompra.DataSource = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NumeroOrdenCompra, filtroBusqueda);
                }
                if (rbNumeroIdentificacion.Checked == true)
                {
                    filtroBusqueda = txtNumeroIdentificacion.Text;
                    this.dgvOrdenesCompra.DataSource = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NumeroIdentificacion, filtroBusqueda);
                }
                if (rbNombreCliente.Checked == true)
                {
                    filtroBusqueda = txtNombreCliente.Text;
                    this.dgvOrdenesCompra.DataSource = objOrdenesCompra.ListarEncabezadoOrdenCompraPorIdentificador(OpcionConsultaOrdenCompra.NombreCliente, filtroBusqueda);
                }                
            }

            if (dgvOrdenesCompra.SelectedRows.Count == 0)
            {
                dgvDetalleOrdenCompra.DataSource = null;
                dgvDetalleOrdenCompra.Refresh();
            }
        }

        private void DetalleOrdenesCompra_FormClosed(object sender, FormClosedEventArgs e)
        {
            OrdenesCompra formularioOrdenesCompra = null;
            formularioOrdenesCompra = new OrdenesCompra();
            formularioOrdenesCompra.Show();
        }

        private void RbNumeroOrden_Click(object sender, EventArgs e)
        {
            TxtOrdenCompra.Enabled = true;
            txtNumeroIdentificacion.Enabled = false;
            txtNombreCliente.Enabled = false;

            txtNumeroIdentificacion.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
        }

        private void RbNumeroIdentidad_Click(object sender, EventArgs e)
        {
            txtNumeroIdentificacion.Enabled = true;
            TxtOrdenCompra.Enabled = false;
            txtNombreCliente.Enabled = false;

            TxtOrdenCompra.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
        }

        private void RbNombreCliente_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Enabled = true;
            txtNumeroIdentificacion.Enabled = false;
            TxtOrdenCompra.Enabled = false;

            txtNumeroIdentificacion.Text = string.Empty;
            TxtOrdenCompra.Text = string.Empty;
        }

        private void DetalleOrdenesCompra_Load(object sender, EventArgs e)
        {
            TxtOrdenCompra.Enabled = false;
            txtNumeroIdentificacion.Enabled = false;
            txtNombreCliente.Enabled = false;          
        }
    }

}
