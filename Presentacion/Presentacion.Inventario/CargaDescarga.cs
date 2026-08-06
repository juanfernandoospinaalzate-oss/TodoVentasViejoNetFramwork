

namespace Presentacion.Inventario
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CargaDescarga : Form
    {
        public CargaDescarga()
        {
            this.InitializeComponent();
        }

        private System.Collections.Generic.List<Entidades.PresentacionArticulo> ListaPresentacionArticulo = new List<Entidades.PresentacionArticulo>();
        private System.Collections.ArrayList ArrayPresentacionArticulo = new System.Collections.ArrayList();

        private void TxtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Entidades.Mensaje Mensaje = null;
            int cantidad = int.MinValue;
            int cantidadEntrada = int.MinValue;
            int cantidadSalida = int.MinValue;
            Fachada.Inventario.CargaDescargaInventario FachadaInventario = null;
            Fachada.TablasMaestras.PresentacionArticulo FachadaPresentacionArticulo = null;
            Entidades.ResultadoTransaccion ResultadoTransacción = null;
            Entidades.PresentacionArticulo PresentacionArticulo = null;
            Entidades.Kardex RegistroKardex = null;
            errorProvider1.Clear();

            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            if (this.TxtCodigoBarras.Text == string.Empty && RbDescarga.Checked == true)
            {
                // Codigo de barras vacío en la descarga de inventario
                Mensaje = Mensajes.LinqToXml.LeerMensaje("0063");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                errorProvider1.SetError(this.TxtCodigoBarras, Mensaje.Texto);
                MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                return;
            }

            if (this.TxtCodigoBarras.Text == string.Empty && RbCarga.Checked == true)
            {
                // Codigo de barras vacío en la Carga de inventario
                Mensaje = Mensajes.LinqToXml.LeerMensaje("0064");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                errorProvider1.SetError(this.TxtCodigoBarras, Mensaje.Texto);
                MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                return;
            }

            if (this.TxtCantidad.Text == "0" && RbDescarga.Checked == true)
            {
                // Cantidad cero en la descarga de inventario
                Mensaje = Mensajes.LinqToXml.LeerMensaje("0065");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                errorProvider1.SetError(this.TxtCantidad, Mensaje.Texto);
                MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                return;
            }

            if (TxtCantidad.Text == "0"  && RbCarga.Checked == true)
            {
                // Cantidad cero en la carga de inventario
                Mensaje = Mensajes.LinqToXml.LeerMensaje("0066");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                errorProvider1.SetError(this.TxtCantidad, Mensaje.Texto);
                MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                return;
            }

            if (this.TxtCantidad.Text == string.Empty && RbDescarga.Checked == true)
            {
                // Cantidad vacia en la descarga de inventario (en presentación)
                Mensaje = Mensajes.LinqToXml.LeerMensaje("0067");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                errorProvider1.SetError(this.TxtCantidad, Mensaje.Texto);
                MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                return;
            }

            if (this.TxtCantidad.Text == string.Empty && RbCarga.Checked == true)
            {
                // Cantidad vacía en la carga de inventario (en presentación)
                Mensaje = Mensajes.LinqToXml.LeerMensaje("0068");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                errorProvider1.SetError(this.TxtCantidad, Mensaje.Texto);
                MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                return;
            }

            if (int.TryParse(this.TxtCantidad.Text, out cantidad) == false)
            {
                // Cantidad tiene que ser numérica (en presentacion)
                Mensaje = Mensajes.LinqToXml.LeerMensaje("0069");
                Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                errorProvider1.SetError(this.TxtCantidad, Mensaje.Texto);
                MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                return;
            }

            if (int.TryParse(this.TxtCantidad.Text, out cantidad) == true && RbDescarga.Checked == true)
            {
                if (cantidad < 0)
                {
                    // Cantidad negativa en la descarga de inventario
                    Mensaje = Mensajes.LinqToXml.LeerMensaje("0070");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                    errorProvider1.SetError(this.TxtCantidad, Mensaje.Texto);
                    MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                    return;
                }
            }

            if (int.TryParse(this.TxtCantidad.Text, out cantidad) == true && RbCarga.Checked == true)
            {
                if (cantidad < 0)
                {
                    // cantidad negativa en al carga de inventario
                    Mensaje = Mensajes.LinqToXml.LeerMensaje("0071");
                    Logging.ErrorGeneral.Guardar(new Entidades.Excepciones.ExceptionErrorTransaccion(Mensaje.Texto));
                    errorProvider1.SetError(this.TxtCantidad, Mensaje.Texto);
                    MessageBox.Show(Mensaje.Texto, Mensaje.Evento, MessageBoxButtons.OK);
                    return;
                }
            }

            if (this.RbCarga.Checked == true) 
            {
                // Configurar el registro del kardex si es una cantidad de entrada
                cantidadEntrada = cantidad;
                cantidadSalida = 0;
            }

            if (this.RbDescarga.Checked == true) 
            {
                // Configurar el registro del kardex si es una cantidad de salida
                cantidadEntrada = 0;
                cantidadSalida = cantidad;
            }

            FachadaInventario = new Fachada.Inventario.CargaDescargaInventario();
            RegistroKardex = new Entidades.Kardex();
            FachadaPresentacionArticulo = new Fachada.TablasMaestras.PresentacionArticulo();
            PresentacionArticulo = FachadaPresentacionArticulo.ConsultarPresentacionPorCodigoEAN(TxtCodigoBarras.Text);
            RegistroKardex.IdPresentacionArticulo = PresentacionArticulo.IdPresentacionArticulo;
            RegistroKardex.Nombre = PresentacionArticulo.Nombre;
            RegistroKardex.Fecha = DateTime.Now;
            RegistroKardex.CostoUnitario = PresentacionArticulo.CostoArticulo;
            RegistroKardex.PrecioUnitario = PresentacionArticulo.Precio;
            RegistroKardex.TotalExistencias = PresentacionArticulo.Existencias;
            RegistroKardex.CantidadEntrada = cantidadEntrada;
            RegistroKardex.CantidadSalida = cantidadSalida;
            RegistroKardex.CostoTotal = PresentacionArticulo.CostoArticulo * PresentacionArticulo.Existencias;
            RegistroKardex.PrecioTotal = PresentacionArticulo.Precio * PresentacionArticulo.Existencias;
            RegistroKardex.Detalle = TxtDetalles.Text;
            ResultadoTransacción = new Entidades.ResultadoTransaccion();

            if (this.RbCarga.Checked == true)
            {
                RegistroKardex.TotalExistencias = PresentacionArticulo.Existencias + cantidad;

                if (PresentacionArticulo.Activo == false)
                {
                    if (MessageBox.Show("El artículo se encuentra desactivado ¿Desea activarlo?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ResultadoTransacción = FachadaInventario.Cargar(this.TxtCodigoBarras.Text, cantidad, RegistroKardex, true);
                    }
                }
                else
                {
                    ResultadoTransacción = FachadaInventario.Cargar(this.TxtCodigoBarras.Text, cantidad, RegistroKardex, false);
                } 
            }

            if (this.RbDescarga.Checked == true)
            {
                RegistroKardex.TotalExistencias = PresentacionArticulo.Existencias - cantidad;
                ResultadoTransacción = FachadaInventario.Descargar(this.TxtCodigoBarras.Text, cantidad, RegistroKardex);
            }

            // Si la actualización es exitosa, se recuperan inserta el registro en GridView
            // Es 2 por dos procedimientos almacenados que se ejecutan en una transacción
            if (ResultadoTransacción.RegistrosAfectados == 2) 
            {
                System.IO.Stream stream = new System.IO.MemoryStream(PresentacionArticulo.Imagen1);
                PresentacionArticulo.Existencias = FachadaPresentacionArticulo.ConsultarExistenciasPresentacionArticulo(RegistroKardex.IdPresentacionArticulo);

                this.PictureBoxPresentacionArticulo.Image = Image.FromStream(stream);
                this.LblArticulo.Text = PresentacionArticulo.Nombre;
                this.LblExistencias.Text = "Existencias " + PresentacionArticulo.Existencias.ToString();

                this.TxtCodigoBarras.Text = string.Empty;
                this.timer1.Enabled = true;

                PresentacionArticulo.DescripcionBreve = TxtDetalles.Text;
                PresentacionArticulo.Fecha = DateTime.Now;
                this.ListaPresentacionArticulo.Insert(0, PresentacionArticulo);
                this.DgvArtículos.AutoGenerateColumns = false;
                this.DgvArtículos.DataSource = null;
                this.DgvArtículos.DataSource = this.ListaPresentacionArticulo;
            }
            else
            {
                MessageBox.Show(ResultadoTransacción.Mensaje.Texto, ResultadoTransacción.Mensaje.Evento, MessageBoxButtons.OK);
            }

            e.Handled = true;
        }

        private void CargaDescarga_Activated(object sender, EventArgs e)
        {
            this.TxtCodigoBarras.Focus();
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.TxtCodigoBarras_KeyPress(sender, e);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.LimpiarPantalla();
            this.timer1.Enabled = false;
        }

        private void LimpiarPantalla()
        {
            this.LblArticulo.Text = string.Empty;
            this.LblExistencias.Text = string.Empty;
            this.TxtCantidad.Text = "1";

            this.TxtCodigoBarras.Focus();
            this.PictureBoxPresentacionArticulo.Image = null;
        }

        private void CargaDescarga_Load(object sender, EventArgs e)
        {
            this.TxtCodigoBarras.Focus();
        }

        private void RbCarga_Click(object sender, EventArgs e)
        {
            this.TxtCodigoBarras.Focus();
        }

        private void RbDescarga_Click(object sender, EventArgs e)
        {
            this.TxtCodigoBarras.Focus();
        }
    }
}
