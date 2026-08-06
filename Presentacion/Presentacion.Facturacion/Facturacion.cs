

namespace Presentacion.Facturacion
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class Facturacion : Form
    {
        List<Entidades.PresentacionArticulo> ListaPresentacionPorCodigoEAN = new List<Entidades.PresentacionArticulo>();
        private int m_currentPageIndex;
        private IList<System.IO.Stream> m_streams;
        private Entidades.Cliente cliente = null;
        string ValorAbonado = string.Empty;

        public Facturacion()
        {
            this.InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.MedioDePago medioPago = new Fachada.TablasMaestras.MedioDePago();
            this.cmbMediosDePago.DataSource = medioPago.Listar();
            this.cmbMediosDePago.DisplayMember = "Nombre";
            this.cmbMediosDePago.ValueMember = "IdMetodoDePago";

            Fachada.TablasMaestras.EstadoDELAVenta estadoVenta = new Fachada.TablasMaestras.EstadoDELAVenta();
            this.cmbEstadoDeLaVenta.DataSource = estadoVenta.Listar();
            this.cmbEstadoDeLaVenta.DisplayMember = "EstadoNuevo";
            this.cmbEstadoDeLaVenta.ValueMember = "IdEstadoDeLaVenta";

            // this.TxtCodigoEAN.Select();
            this.TxtNombre.Enabled = false;
            this.TxtDireccion.Enabled = false;
            this.TxtTelefono.Enabled = false;
            this.TxtEmail.Enabled = false;

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.TxtIdentificacion.Select();
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
                int ExistenciasEnBaseDeDatos = int.MinValue;

                // si el grid contiene registros, se recupera el indice de la fila seleccionada
                if (DgvFacturacion.Rows.Count > 0)
                {
                    IndiceFilaSeleccionada = DgvFacturacion.SelectedRows[0].Index;
                }

                // verificar si la presentacion del articulo ya se encuentra en el grid para incrementar
                foreach (Entidades.PresentacionArticulo presentacionArticulo in this.ListaPresentacionPorCodigoEAN)
                {
                    if (presentacionArticulo.CodigoEAN.ToLower() == TxtCodigoEAN.Text.ToLower())
                    {
                        ValidacionesComunes.Validacion ValidacionesComunes = new ValidacionesComunes.Validacion();
                        ExistenciasEnBaseDeDatos = Facturacion.ConsultarExistenciasPresentacionArticulo(presentacionArticulo.IdPresentacionArticulo);
                        presentacionArticulo.Existencias = ValidacionesComunes.ControlCantidadDisponible(ExistenciasEnBaseDeDatos, 1, presentacionArticulo.Existencias); // Se usa como (Cantidad) de articulos a comprar

                        if (presentacionArticulo.Existencias >= ExistenciasEnBaseDeDatos)
                        {
                            MessageBox.Show("No se pueden agregar más artículos, verificar disponibilidad de las existencias.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                        }

                        presentacionArticulo.CostoArticulo = presentacionArticulo.Existencias * presentacionArticulo.Precio; // CostoArticulo se utiliza para calcular y mostrar el subtotal por linea en el grid
                        BanderaPresentacionArticuloGrid = true;
                        break; // Salir del ciclo
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
                        // Verificar Existencias
                        if (presentacionArticulo.Existencias > 0)
                        {
                            // Verificar si se encuentra activo en la Base de Datos
                            if (presentacionArticulo.Activo == true)
                            {
                                presentacionArticulo.Existencias = 1; // Se usa como (Cantidad) de articulos a comprar
                                presentacionArticulo.CostoArticulo = presentacionArticulo.Existencias * presentacionArticulo.Precio; // CostoArticulo se utiliza para calcular y mostrar el subtotal en el grid
                                this.ListaPresentacionPorCodigoEAN.Add(presentacionArticulo);
                                BanderaPresentacionArticuloNuevoGid = true;
                            }
                            else
                            {
                                // En caso de no encontrarse activo en la base de datos
                                MessageBox.Show("El articulo se encuentra Inactivo y no será facturado", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El producto consultado no posee existencias disponibles.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (this.DgvFacturacion.Rows.Count > 0 && IndiceFilaSeleccionada != int.MinValue)
                {
                    this.DgvFacturacion.Rows[IndiceFilaSeleccionada].Selected = true; // Mantener la fila actualmente seleccionada (cambia con cada recarga del grid)
                }

                // Si se añadió una linea nueva al grid, se selecciona la última fila.
                if (BanderaPresentacionArticuloNuevoGid == true)
                {
                    IndiceFilaSeleccionada = this.DgvFacturacion.Rows.Count - 1;
                    this.DgvFacturacion.Rows[IndiceFilaSeleccionada].Selected = true;
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
                            if (this.ListaPresentacionPorCodigoEAN[i].CodigoEAN.ToLower() == TxtCodigoEAN.Text.ToLower())
                            {
                                IndiceFilaSeleccionada = i;
                                this.DgvFacturacion.Rows[IndiceFilaSeleccionada].Selected = true;
                            }
                        }
                    }
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                TxtCodigoEAN.Text = string.Empty;

                this.MostrarTotalFactura();
            }
        }

        private void ConfigurarColumnasDataGrid()
        {
            this.DgvFacturacion.Columns[0].Visible = false;
            this.DgvFacturacion.Columns[1].Visible = false;
            // this.DgvFacturacion.Columns[2].Visible = false;
            // this.DgvFacturacion.Columns[3].Visible = false;
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

            // this.DgvFacturacion.Columns[25].Visible = false;
            this.DgvFacturacion.Columns[25].Width = 60; // reducir el ancho de columna para el precio
            this.DgvFacturacion.Columns[25].DefaultCellStyle.Format = "C";
            // this.DgvFacturacion.Columns[26].Visible = false;
            this.DgvFacturacion.Columns[26].Width = 60; // reducir el ancho de columna para la cantidad de artículos a comprar
            this.DgvFacturacion.Columns[26].HeaderText = "Cantidad"; // mostrar la etiqueta como Cantidad en vez de Existencias
            this.DgvFacturacion.Columns[27].Visible = false;
            // this.DgvFacturacion.Columns[28].Visible = false;
            this.DgvFacturacion.Columns[28].HeaderText = "Subtotal"; // mostrar la etiqueta como Subtotal en vez de CostoArticulo
            this.DgvFacturacion.Columns[28].DefaultCellStyle.Format = "C";
            this.DgvFacturacion.Columns[29].Visible = false;
            this.DgvFacturacion.Columns[30].Visible = false;
            this.DgvFacturacion.Columns[31].Visible = false;
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

                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen);
                System.IO.FileStream fs = new System.IO.FileStream(rutaImagen, System.IO.FileMode.Create);
                ms.WriteTo(fs);
                fs.Close();
                ms.Close();

                PbImgPresentacionArticulo.ImageLocation = rutaImagen;
            }
        }

        private void TxtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Fachada.TablasMaestras.Cliente Cliente = new Fachada.TablasMaestras.Cliente();
                Fachada.TablasMaestras.Direccion Direccion = new Fachada.TablasMaestras.Direccion();
                int Identificacion = int.Parse(this.TxtIdentificacion.Text);
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

                e.Handled = true;
                e.SuppressKeyPress = true;
                TxtCodigoEAN.Focus();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvFacturacion.SelectedRows.Count > 0)
            {
                int indice = int.MinValue;
                indice = int.Parse(this.DgvFacturacion.SelectedRows[0].Index.ToString());
                this.DgvFacturacion.DataSource = null;
                this.ListaPresentacionPorCodigoEAN.RemoveAt(indice);
                this.DgvFacturacion.DataSource = this.ListaPresentacionPorCodigoEAN;
                this.ConfigurarColumnasDataGrid();
            }

            this.MostrarTotalFactura();
        }

        private void BtnGuardarImprimir_Click(object sender, EventArgs e)
        {
            // int CantidadPaginas = this.ListaPresentacionPorCodigoEAN.Count / 10;
            int CantidadElementosFaltantesDecena = 10 - (this.ListaPresentacionPorCodigoEAN.Count % 10);
            System.Collections.Generic.List<Microsoft.Reporting.WinForms.ReportParameter> ListaParametros = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            int NumeroFactura = int.MinValue;

            // Si es la última página totalizar para todas las páginas la factura el total a cobrar y el total de artículos
            double TotalFactura = 0;
            int TotalCantidadArticulos = 0;
            Microsoft.Reporting.WinForms.ReportParameter ParametroTotalFacturaEtiqueta = null;
            Microsoft.Reporting.WinForms.ReportParameter ParametroTotalFacturaValor = null;
            Microsoft.Reporting.WinForms.ReportParameter ParametroTotalArticulosValor = null;

            for (int k = 0; k < this.ListaPresentacionPorCodigoEAN.Count; k++)
            {
                TotalFactura = TotalFactura + this.ListaPresentacionPorCodigoEAN[k].Existencias * this.ListaPresentacionPorCodigoEAN[k].Precio;
                TotalCantidadArticulos = TotalCantidadArticulos + this.ListaPresentacionPorCodigoEAN[k].Existencias;
            }

            ParametroTotalFacturaEtiqueta = new Microsoft.Reporting.WinForms.ReportParameter("ParametroTotalFacturaEtiqueta", "Total: ");
            ParametroTotalFacturaValor = new Microsoft.Reporting.WinForms.ReportParameter("ParametroTotalFacturaValor", TotalFactura.ToString());
            ParametroTotalArticulosValor = new Microsoft.Reporting.WinForms.ReportParameter("ParametroTotalArticulosValor", TotalCantidadArticulos.ToString());
            ListaParametros.Add(ParametroTotalFacturaEtiqueta);
            ListaParametros.Add(ParametroTotalFacturaValor);
            ListaParametros.Add(ParametroTotalArticulosValor);

            this.reportViewer1.LocalReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings["RutaReportes"] + "\\FacturaPOS.rdlc";
            Microsoft.Reporting.WinForms.ReportDataSource FuenteDatos = new Microsoft.Reporting.WinForms.ReportDataSource("FacturaPOS1", this.ListaPresentacionPorCodigoEAN);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(FuenteDatos);
            this.reportViewer1.RefreshReport();

            // Guardar los datos de la venta (Solo se envían los Ids de las presentaciones, CódigoEAN  el Id del Artículo correspondiente)
            Fachada.Facturacion.Facturacion Factura = new Fachada.Facturacion.Facturacion();
            List<Entidades.PresentacionArticulo> IdsPresentaciones = new List<Entidades.PresentacionArticulo>();

            Entidades.MetodoDePago medioDePago = new Entidades.MetodoDePago();
            medioDePago.Nombre = cmbMediosDePago.Text;

            Entidades.EstadoVenta estadoDeLaVenta = new Entidades.EstadoVenta();
            estadoDeLaVenta.EstadoNuevo = cmbEstadoDeLaVenta.Text;

            foreach (Entidades.PresentacionArticulo itemPresentacion in this.ListaPresentacionPorCodigoEAN)
            {
                Entidades.PresentacionArticulo presentacionArticulo = new Entidades.PresentacionArticulo();
                presentacionArticulo.IdPresentacionArticulo = itemPresentacion.IdPresentacionArticulo;
                presentacionArticulo.CodigoEAN = itemPresentacion.CodigoEAN;
                presentacionArticulo.Articulo.IdArticulo = itemPresentacion.Articulo.IdArticulo;
                presentacionArticulo.Existencias = itemPresentacion.Existencias;
                IdsPresentaciones.Add(presentacionArticulo);
            }

            NumeroFactura = Factura.GenerarFactura(IdsPresentaciones, this.cliente, medioDePago, estadoDeLaVenta);
            LblNumeroDeFactura.Text = NumeroFactura.ToString();

            // Parametros del reporte
            this.reportViewer2.LocalReport.EnableExternalImages = true;
            Zen.Barcode.Code128BarcodeDraw BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

            PbImgCodigoBarras.Image = BarcodeDraw.Draw(NumeroFactura.ToString(), 50);
            PbImgCodigoBarras.Image.Save(System.IO.Path.GetTempPath() + "ImagenNumeroFactura.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            Microsoft.Reporting.WinForms.ReportParameter ParametroNombreCliente = new Microsoft.Reporting.WinForms.ReportParameter("ParametroNombreCliente", TxtNombre.Text + " " + TxtDireccion.Text);
            Microsoft.Reporting.WinForms.ReportParameter ParametroCedulaNitCliente = new Microsoft.Reporting.WinForms.ReportParameter("ParametroCedulaNitCliente", TxtIdentificacion.Text);
            Microsoft.Reporting.WinForms.ReportParameter ParametroTelefonosCliente = new Microsoft.Reporting.WinForms.ReportParameter("ParametroTelefonosCliente", TxtTelefono.Text);
            Microsoft.Reporting.WinForms.ReportParameter ParametroDireccionCliente = new Microsoft.Reporting.WinForms.ReportParameter("ParametroDireccionCliente", TxtDireccion.Text);
            Microsoft.Reporting.WinForms.ReportParameter ParametroEmailCliente = new Microsoft.Reporting.WinForms.ReportParameter("ParametroEmailCliente", TxtEmail.Text);
            Microsoft.Reporting.WinForms.ReportParameter ParametroObservaciones = new Microsoft.Reporting.WinForms.ReportParameter("ParametroObservaciones", "Bla bla bla bla bla blab lablabla bla blabla blab bla");
            Microsoft.Reporting.WinForms.ReportParameter ParametroImagenCodigoBarras = new Microsoft.Reporting.WinForms.ReportParameter("ParametroImagenCodigoBarras", "File:" + System.IO.Path.GetTempPath() + "ImagenNumeroFactura.jpg");
            Microsoft.Reporting.WinForms.ReportParameter ParametroNroFactura = new Microsoft.Reporting.WinForms.ReportParameter("ParametroNroFactura", NumeroFactura.ToString());
            // Microsoft.Reporting.WinForms.ReportParameter ParametroFechaHora = new Microsoft.Reporting.WinForms.ReportParameter("ParametroFechaHora", DateTime.Now.ToString("MMM d yyyy hh:mmtt "));
            Microsoft.Reporting.WinForms.ReportParameter ParametroFechaHora = new Microsoft.Reporting.WinForms.ReportParameter("ParametroFechaHora", string.Format("{0:f}", DateTime.Now));
            Microsoft.Reporting.WinForms.ReportParameter ParametroTelefonosVendedor = new Microsoft.Reporting.WinForms.ReportParameter("ParametroTelefonosVendedor", "");
            Microsoft.Reporting.WinForms.ReportParameter ParametroEmailVendedor = new Microsoft.Reporting.WinForms.ReportParameter("ParametroEmailVendedor", "");

            ListaParametros.Add(ParametroNombreCliente);
            ListaParametros.Add(ParametroCedulaNitCliente);
            ListaParametros.Add(ParametroTelefonosCliente);
            ListaParametros.Add(ParametroDireccionCliente);
            ListaParametros.Add(ParametroEmailCliente);
            ListaParametros.Add(ParametroObservaciones);
            ListaParametros.Add(ParametroImagenCodigoBarras);
            ListaParametros.Add(ParametroNroFactura);
            ListaParametros.Add(ParametroFechaHora);
            ListaParametros.Add(ParametroTelefonosVendedor);
            ListaParametros.Add(ParametroEmailVendedor);

            reportViewer2.LocalReport.ReportPath = System.Configuration.ConfigurationManager.AppSettings["RutaReportes"] + "\\FacturaPosMediaCarta.rdlc";
            Microsoft.Reporting.WinForms.ReportDataSource FuenteDatos2 = new Microsoft.Reporting.WinForms.ReportDataSource("FacturaPosMediaCarta", this.ListaPresentacionPorCodigoEAN);
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(FuenteDatos2);
            this.reportViewer2.LocalReport.SetParameters(ListaParametros);

            this.reportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer2.RefreshReport();

            // El reporte directo a impresora sin usar el report viewer
            if (ChkImprimirDirecto.Checked)
            {
                this.ExportCarta(this.reportViewer2.LocalReport);
                this.Print();
            }

            this.GuardarKardex();
        }

        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private System.IO.Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            System.IO.Stream stream = new System.IO.MemoryStream();
            this.m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(Microsoft.Reporting.WinForms.LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>5.5cm</PageWidth>
                <PageHeight>7cm</PageHeight>
                <MarginTop>0.5cm</MarginTop>
                <MarginLeft>0.2cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>0.5cm</MarginBottom>
            </DeviceInfo>";
            Microsoft.Reporting.WinForms.Warning[] warnings;
            this.m_streams = new List<System.IO.Stream>();
            report.Render("Image", deviceInfo, this.CreateStream, out warnings);
            foreach (System.IO.Stream stream in this.m_streams)
                stream.Position = 0;
        }

        private void ExportCarta(Microsoft.Reporting.WinForms.LocalReport report)
        {
            // MOVER CUALQUIER VALOR CAUSA DESBALANCE EN LA PAGINACION DE LA FACTURA
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8,5in</PageWidth>
                <PageHeight>9in</PageHeight>
                <MarginTop>0cm</MarginTop>
                <MarginLeft>0cm</MarginLeft>
                <MarginRight>0cm</MarginRight>
                <MarginBottom>3cm</MarginBottom>
            </DeviceInfo>";
            Microsoft.Reporting.WinForms.Warning[] warnings;
            this.m_streams = new List<System.IO.Stream>();
            report.Render("Image", deviceInfo, this.CreateStream, out warnings);
            foreach (System.IO.Stream stream in this.m_streams)
                stream.Position = 0;
        }

        // Handler for PrintPageEvents
        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            System.Drawing.Imaging.Metafile pageImage = new
               System.Drawing.Imaging.Metafile(this.m_streams[this.m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            this.m_currentPageIndex++;
            ev.HasMorePages = this.m_currentPageIndex < this.m_streams.Count;
        }

        private void Print()
        {
            if (this.m_streams == null || this.m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintPage);
                this.m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public new void Dispose()
        {
            if (this.m_streams != null)
            {
                foreach (System.IO.Stream stream in this.m_streams)
                    stream.Close();
                this.m_streams = null;
            }
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
                this.ListaPresentacionPorCodigoEAN[this.DgvFacturacion.SelectedRows[0].Index] = presentacionArticulo;
                this.DgvFacturacion.Refresh();
            }

            this.MostrarTotalFactura();
        }

        private void AgregarCantidad_Click(object sender, EventArgs e)
        {
            // Verificar que se encuentre un elemento seleccionado en el grid
            if (DgvFacturacion.SelectedRows.Count > 0)
            {
                Entidades.PresentacionArticulo presentacionArticulo = DgvFacturacion.SelectedRows[0].DataBoundItem as Entidades.PresentacionArticulo;
                Fachada.Facturacion.Facturacion Factura = new Fachada.Facturacion.Facturacion();
                int ExistenciaEnBaseDeDatos = int.MinValue;

                ExistenciaEnBaseDeDatos = Factura.ConsultarExistenciasPresentacionArticulo(presentacionArticulo.IdPresentacionArticulo);

                if (presentacionArticulo.Existencias < ExistenciaEnBaseDeDatos)
                {
                    presentacionArticulo.Existencias++; // el campo existencias, se usa para la cantidada de artículos por línea que se facturan 
                }
                else
                {
                    MessageBox.Show("No se pueden agregar más artículos, verificar disponibilidad de las existencias.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                }

                presentacionArticulo.CostoArticulo = presentacionArticulo.Existencias * presentacionArticulo.Precio; // CostoArticulo se utiliza para calcular y mostrar el subtotal en el grid
                this.ListaPresentacionPorCodigoEAN[this.DgvFacturacion.SelectedRows[0].Index] = presentacionArticulo;
                this.DgvFacturacion.Refresh();
            }

            this.MostrarTotalFactura();
        }

        /// <summary>
        /// Evento de Formulario, ocurre al presionar una venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Facturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                BtnGuardarImprimir.PerformClick();
            }

            if (e.Control && e.KeyCode == Keys.N)
            {
                BtnGuardarImprimir.PerformClick();
            }
        }

        private void BtnConsultarOrdenesCompra_Click(object sender, EventArgs e)
        {
            DetalleOrdenesCompra formularioDetalleOrdenesCompra = new DetalleOrdenesCompra();
            formularioDetalleOrdenesCompra.Show();

        }

        private void ReportViewer2_RenderingComplete(object sender, Microsoft.Reporting.WinForms.RenderingCompleteEventArgs e)
        {
            // this.reportViewer2.PrintDialog();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.ListaPresentacionPorCodigoEAN = new List<Entidades.PresentacionArticulo>();

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.RefreshReport();

            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.RefreshReport();

            this.DgvFacturacion.DataSource = null;

            PbImgPresentacionArticulo.ImageLocation = string.Empty;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }

            this.MostrarTotalFactura();
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

        private void GuardarKardex()
        {
            // Insertar los registros del detalle de venta en el kardex
            Fachada.Inventario.Kardex Kardex = new Fachada.Inventario.Kardex();

            foreach (Entidades.PresentacionArticulo itemPresentacion in this.ListaPresentacionPorCodigoEAN)
            {
                int NumeroFactura = int.MinValue;
                Fachada.Facturacion.Facturacion Facturacion = new Fachada.Facturacion.Facturacion();

                int.TryParse(LblNumeroDeFactura.Text, out NumeroFactura);

                Entidades.Kardex RegistroKardex = new Entidades.Kardex
                {
                    IdPresentacionArticulo = itemPresentacion.IdPresentacionArticulo,
                    Nombre = itemPresentacion.Nombre,
                    Fecha = DateTime.Now,
                    CostoUnitario = itemPresentacion.CostoArticulo,
                    PrecioUnitario = itemPresentacion.Precio,
                    TotalExistencias = Facturacion.ConsultarExistenciasPresentacionArticulo(itemPresentacion.IdPresentacionArticulo),
                    CantidadEntrada = 0,
                    CantidadSalida = itemPresentacion.Existencias,
                    CostoTotal = itemPresentacion.CostoArticulo * itemPresentacion.Existencias,
                    PrecioTotal = itemPresentacion.Precio * itemPresentacion.Existencias,
                    Detalle = "Factura: " + NumeroFactura.ToString()
                };

                Kardex.Insertar(RegistroKardex);
            }
        }
    }
}

