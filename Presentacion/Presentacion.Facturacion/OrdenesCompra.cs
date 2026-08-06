

namespace Presentacion.Facturacion
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class OrdenesCompra : Form
    {
        List<Entidades.PresentacionArticulo> ListaPresentacionPorCodigoEAN = new List<Entidades.PresentacionArticulo>();
        private Entidades.Cliente cliente = null;
        string ValorAbonado = string.Empty;

        public OrdenesCompra()
        {
            this.InitializeComponent();
        }

        private void OrdenesCompra_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.MedioDePago medioPago = new Fachada.TablasMaestras.MedioDePago();
            
            this.cmbMediosDePago.DataSource = medioPago.Listar();
            this.cmbMediosDePago.DisplayMember = "Nombre";
            this.cmbMediosDePago.ValueMember = "IdMetodoDePago";

            // Fachada.TablasMaestras.EstadoDELAVenta estadoVenta = new Fachada.TablasMaestras.EstadoDELAVenta();
            // this.cmbEstadoDeLaVenta.DataSource = estadoVenta.Listar();
            // this.cmbEstadoDeLaVenta.DisplayMember = "EstadoNuevo";
            // this.cmbEstadoDeLaVenta.ValueMember = "IdEstadoDeLaVenta";

            this.TxtCodigoEAN.Enabled = false;
            this.TxtCodigoEAN.Select();
            this.TxtDireccion.Enabled = false;
            this.TxtTelefono.Enabled = false;
            this.TxtEmail.Enabled = false;
            this.TxtValorAbonado.Enabled = false;
            this.cmbMediosDePago.Enabled = false;

            this.MostrarTotalFactura();
        }

        private void ConfigurarColumnasDataGrid()
        {
            this.DgvFacturacion.Columns[0].Visible = false;
            this.DgvFacturacion.Columns[1].Visible = false;
            this.DgvFacturacion.Columns[3].Width = 400; // Ampliar el ancho de columna para el nombre del artículo
            this.DgvFacturacion.Columns[4].Visible = false;
            this.DgvFacturacion.Columns[5].Visible = false;
            this.DgvFacturacion.Columns[6].Visible = false;
            this.DgvFacturacion.Columns[7].Visible = false;
            this.DgvFacturacion.Columns[8].Visible = false;
            this.DgvFacturacion.Columns[9].Visible = false;
            this.DgvFacturacion.Columns[10].Visible = false;
            this.DgvFacturacion.Columns[11].Visible = false;
            this.DgvFacturacion.Columns[12].Visible = false;
            this.DgvFacturacion.Columns[13].Visible = false;
            this.DgvFacturacion.Columns[14].Visible = false;
            this.DgvFacturacion.Columns[15].Visible = false;
            this.DgvFacturacion.Columns[16].Visible = false;
            this.DgvFacturacion.Columns[17].Visible = false;
            this.DgvFacturacion.Columns[18].Visible = false;
            this.DgvFacturacion.Columns[19].Visible = false;
            this.DgvFacturacion.Columns[20].Visible = false;
            this.DgvFacturacion.Columns[21].Visible = false;
            this.DgvFacturacion.Columns[22].Visible = false;
            this.DgvFacturacion.Columns[23].Visible = false;
            this.DgvFacturacion.Columns[24].Visible = false;
            this.DgvFacturacion.Columns[25].Width = 60; // reducir el ancho de columna para el precio
            this.DgvFacturacion.Columns[26].Width = 60; // reducir el ancho de columna para la cantidad de artículos a comprar
            this.DgvFacturacion.Columns[26].HeaderText = "Cantidad"; // mostrar la etiqueta como Cantidad en vez de Existencias
            this.DgvFacturacion.Columns[27].Visible = false;
            this.DgvFacturacion.Columns[28].HeaderText = "Subtotal"; // mostrar la etiqueta como Subtotal en vez de CostoArticulo
            this.DgvFacturacion.Columns[29].Visible = false;
            this.DgvFacturacion.Columns[30].Visible = false;
            this.DgvFacturacion.Columns[31].Visible = false;
        }

        private void TxtCodigoEAN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (TxtCodigoEAN.Text == string.Empty)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }

                Fachada.Facturacion.Facturacion Facturacion = new Fachada.Facturacion.Facturacion();
                bool BanderaPresentacionArticuloGrid = false; // indica si la presentación de articulo que se busca ya se encuentra en el grid
                bool BanderaPresentacionArticuloNuevoGid = false;  // Indica si la presentación de articulo se acaba de añadir al grid como una linea nueva
                int IndiceFilaSeleccionada = int.MinValue;

                // si el grid contiene registros, se recupera el indice de la fila seleccionada
                if (DgvFacturacion.Rows.Count > 0)
                {
                    IndiceFilaSeleccionada = DgvFacturacion.SelectedRows[0].Index;
                }

                // verificar si la presentacion del articulo ya se encuentra en el grid para incrementar la cantidad sin consultar la base de datos
                foreach (Entidades.PresentacionArticulo presentacionArticulo in this.ListaPresentacionPorCodigoEAN)
                {
                    if (presentacionArticulo.CodigoEAN.ToLower() == TxtCodigoEAN.Text.ToLower())
                    {
                        presentacionArticulo.Existencias++; // Se usa como (Cantidad) de articulos a comprar
                        presentacionArticulo.CostoArticulo = presentacionArticulo.Existencias * presentacionArticulo.Precio; // CostoArticulo se utiliza para calcular y mostrar el subtotal por linea en el grid
                        BanderaPresentacionArticuloGrid = true;
                        break;
                    }
                    else
                    {
                        BanderaPresentacionArticuloGrid = false; // marcar la presentación de articulo como no encontrada
                    }
                }

                // si la presentación de artículo no se encuentra en el grid, consultar la base de datos y añadir al grid
                if (BanderaPresentacionArticuloGrid == false)
                {
                    Entidades.PresentacionArticulo presentacionArticulo = Facturacion.ConsultarPresentacionPorCodigoEAN(TxtCodigoEAN.Text);

                    // Si se encuentra la presentación de artículo en la base de datos
                    if (presentacionArticulo.Articulo.IdArticulo != 0)
                    {
                        if (presentacionArticulo.Existencias != 0)
                        {
                            presentacionArticulo.Existencias = 1; // Se usa como (Cantidad) de articulos a comprar
                            presentacionArticulo.CostoArticulo = presentacionArticulo.Existencias * presentacionArticulo.Precio; // CostoArticulo se utiliza para calcular y mostrar el subtotal en el grid
                            this.ListaPresentacionPorCodigoEAN.Add(presentacionArticulo);
                            BanderaPresentacionArticuloNuevoGid = true;
                        }
                        else
                        {
                            MessageBox.Show("El producto consultado no posee existencias disponibles.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                        }
                    }
                    else
                    {
                        // TODO: Mostrar mensaje de error al no encontrar él código de la presentación
                    }
                }

                this.DgvFacturacion.DataSource = null;
                this.DgvFacturacion.DataSource = this.ListaPresentacionPorCodigoEAN;
                this.ConfigurarColumnasDataGrid();
                if (DgvFacturacion.Rows.Count > 0 && IndiceFilaSeleccionada != int.MinValue)
                {
                    DgvFacturacion.Rows[IndiceFilaSeleccionada].Selected = true; // Mantener la fila actualmente seleccionada (cambia con cada recarga del grid)
                }


                // Si se añadió una linea nueva al grid, se selecciona la última fila.
                if (BanderaPresentacionArticuloNuevoGid == true)
                {
                    IndiceFilaSeleccionada = DgvFacturacion.Rows.Count - 1;
                    DgvFacturacion.Rows[IndiceFilaSeleccionada].Selected = true;
                }
                else 
                {
                    // si no se añádió una linea nueva al grid
                    // se verifica si fue una actualización de cantidad en el grid para seleccionar la línea correspondiente.
                    if (BanderaPresentacionArticuloGrid == true)
                    {
                        // buscar el indice de la presentación de artículo para seleccionar la fila correspondiente en el grid
                        for (int i = 0; i < this.ListaPresentacionPorCodigoEAN.Count; i++)
                        {
                            // al encuentrar el indice, seleccionamos la fila.
                            if (this.ListaPresentacionPorCodigoEAN[i].CodigoEAN.ToLower() == this.TxtCodigoEAN.Text.ToLower())
                            {
                                IndiceFilaSeleccionada = i;
                                DgvFacturacion.Rows[IndiceFilaSeleccionada].Selected = true;
                            }
                        }
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                TxtCodigoEAN.Text = string.Empty;
            }
            this.MostrarTotalFactura();
        }

        private void TxtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Fachada.TablasMaestras.Cliente Cliente = new Fachada.TablasMaestras.Cliente();
                Fachada.TablasMaestras.Direccion Direccion = new Fachada.TablasMaestras.Direccion();
                int Identificacion = int.Parse(TxtIdentificacion.Text);
                this.cliente = Cliente.BuscarClientePorDocCliente(Identificacion);

                int IdCliente = this.cliente.IdCliente;
                this.TxtNombre.Text = this.cliente.Nombre + " " + this.cliente.Apellido;

                this.TxtTelefono.Text = this.cliente.Telefono1 + ", " + this.cliente.Telefono2;

                if (this.cliente.Direcciones.Count > 0)
                {
                    if (this.cliente.Direcciones != null)
                    {
                        this.TxtDireccion.Text = this.cliente.Direcciones[0].DireccionEnvio + ", " + this.cliente.Direcciones[0].Ciudad.Nombre + " - " + this.cliente.Direcciones[0].Departamento.Nombre;
                    }
                }

                this.TxtEmail.Text = this.cliente.Email;

                this.TxtCodigoEAN.Enabled = true;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void DgvFacturacion_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvFacturacion.SelectedRows.Count > 0)
            {
                Entidades.PresentacionArticulo PresentacionArticulo = new Entidades.PresentacionArticulo();
                PresentacionArticulo = DgvFacturacion.SelectedRows[0].DataBoundItem as Entidades.PresentacionArticulo;

                string rutaTemporal = System.IO.Path.GetTempPath();
                int idPresentacionArticulo = int.Parse(DgvFacturacion.SelectedRows[0].Cells[0].Value.ToString());
                string rutaImagen = rutaTemporal + idPresentacionArticulo + "A.jpg";

                byte[] imagen = this.DgvFacturacion.SelectedRows[0].Cells[7].Value as byte[];

                if (System.IO.File.Exists(rutaImagen))
                {
                    System.IO.File.Delete(rutaImagen);
                }

                System.IO.MemoryStream MemoryStream = new System.IO.MemoryStream(imagen);
                PbImgPresentacionArticulo.Image = System.Drawing.Image.FromStream(MemoryStream);
            }
        }

        private void BtnOrdenCompra_Click(object sender, EventArgs e)
        {
            try
            {
                Fachada.Facturacion.OrdenesCompra ObjOrdenCompra = new Fachada.Facturacion.OrdenesCompra();
                List<Entidades.PresentacionArticulo> IdsPresentaciones = new List<Entidades.PresentacionArticulo>();              

                foreach (Entidades.PresentacionArticulo itemPresentacion in this.ListaPresentacionPorCodigoEAN)
                {
                    Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();
                    presentacionArticulo.IdPresentacionArticulo = itemPresentacion.IdPresentacionArticulo;
                    presentacionArticulo.CodigoEAN = itemPresentacion.CodigoEAN;
                    presentacionArticulo.Articulo.IdArticulo = itemPresentacion.Articulo.IdArticulo;
                    presentacionArticulo.Existencias = itemPresentacion.Existencias;
                    presentacionArticulo.Precio = itemPresentacion.Precio;
                    IdsPresentaciones.Add(presentacionArticulo);
                }

                int resultado = ObjOrdenCompra.GenerarOrdenCompra(IdsPresentaciones, this.cliente);
                if (resultado == 0)
                {
                    MessageBox.Show("Orden de compra generada con éxito!.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorGeneral.Guardar(ex);
            }
        }

        private void ChkActivarValorAbonado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkActivarValorAbonado.Checked)
            {
                TxtValorAbonado.Enabled = true;
                cmbMediosDePago.Enabled = true;
                TxtValorAbonado.Focus();
            }
            else
            {
                TxtValorAbonado.Enabled = false;
                cmbMediosDePago.Enabled = false;
            }
        }

        private void MostrarTotalFactura()
        {
            double TotalFactura = 0;
            int TotalCantidadArticulos = 0;

            for (int k = 0; k < this.ListaPresentacionPorCodigoEAN.Count; k++)
            {
                TotalFactura = TotalFactura + this.ListaPresentacionPorCodigoEAN[k].Existencias * this.ListaPresentacionPorCodigoEAN[k].Precio;
                TotalCantidadArticulos = TotalCantidadArticulos + this.ListaPresentacionPorCodigoEAN[k].Existencias;
            }

            this.TxtTotalFactura.Text = string.Format("{0:C}", TotalFactura);
            this.TxtCantidadArticulos.Text = TotalCantidadArticulos.ToString();
        }

        private void TxtValorAbonado_Leave(object sender, EventArgs e)
        {
            decimal valor = 0;

            if (decimal.TryParse(TxtValorAbonado.Text, out valor))
            {
                TxtValorAbonado.Text = string.Format("{0:C2}", valor).Replace('$', ' ');
            }
        }

        private void AgregarCantidad_Click(object sender, EventArgs e)
        {
            if (DgvFacturacion.SelectedRows.Count > 0)
            {
                Entidades.PresentacionArticulo presentacionArticulo = DgvFacturacion.SelectedRows[0].DataBoundItem as Entidades.PresentacionArticulo;
                Fachada.Facturacion.Facturacion Factura = new Fachada.Facturacion.Facturacion();
                string paramsPresentaciones = string.Empty;

                foreach (Entidades.PresentacionArticulo itemPresentacion in this.ListaPresentacionPorCodigoEAN)
                {
                    Entidades.PresentacionArticulo elementoPresentacionArticulo = new Entidades.PresentacionArticulo();
                    elementoPresentacionArticulo.CodigoEAN = itemPresentacion.CodigoEAN;
                    paramsPresentaciones = elementoPresentacionArticulo.CodigoEAN.ToString();
                }

                Entidades.PresentacionArticulo validarExistencias = Factura.ConsultarPresentacionPorCodigoEAN(paramsPresentaciones);

                if (presentacionArticulo.Existencias != validarExistencias.Existencias)
                {
                    presentacionArticulo.Existencias++; // el campo existencias, se usa para la cantidada de artículos por línea que se facturan 
                }
                else
                {
                    MessageBox.Show("No se pueden agregar más artículos, verificar disponibilidad de las existencias.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }

                presentacionArticulo.CostoArticulo = presentacionArticulo.Existencias * presentacionArticulo.Precio; // CostoArticulo se utiliza para calcular y mostrar el subtotal en el grid
                this.ListaPresentacionPorCodigoEAN[DgvFacturacion.SelectedRows[0].Index] = presentacionArticulo;
                DgvFacturacion.Refresh();
            }
            this.MostrarTotalFactura();
        }

        private void BtnConsultarOrdenesCompra_Click(object sender, EventArgs e)
        {
            this.Hide();
            DetalleOrdenesCompra formularioDetalleOrdenesCompra = null;
            formularioDetalleOrdenesCompra = new DetalleOrdenesCompra();
            formularioDetalleOrdenesCompra.Show();
        }

        private void QuitarCantidad_Click(object sender, EventArgs e)
        {
            if (DgvFacturacion.SelectedRows.Count > 0)
            {
                Entidades.PresentacionArticulo presentacionArticulo = DgvFacturacion.SelectedRows[0].DataBoundItem as Entidades.PresentacionArticulo;

                if (presentacionArticulo.Existencias > 1)
                {
                    presentacionArticulo.Existencias--; // el campo existencias, se usa para la cantidada de artículos por línea que se facturan
                }

                presentacionArticulo.CostoArticulo = presentacionArticulo.Existencias * presentacionArticulo.Precio; // CostoArticulo se utiliza para calcular y mostrar el subtotal en el grid
                this.ListaPresentacionPorCodigoEAN[DgvFacturacion.SelectedRows[0].Index] = presentacionArticulo;
                DgvFacturacion.Refresh();
            }

            this.MostrarTotalFactura();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvFacturacion.SelectedRows.Count > 0)
            {
                int indice = int.MinValue;
                indice = int.Parse(DgvFacturacion.SelectedRows[0].Index.ToString());
                this.DgvFacturacion.DataSource = null;
                this.ListaPresentacionPorCodigoEAN.RemoveAt(indice);
                this.DgvFacturacion.DataSource = this.ListaPresentacionPorCodigoEAN;
                this.ConfigurarColumnasDataGrid();
            }
        }
    }
}
