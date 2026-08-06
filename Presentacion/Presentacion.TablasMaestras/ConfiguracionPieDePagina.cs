

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Windows.Forms;

    public partial class ConfiguracionPieDePagina : Form
    {
        public ConfiguracionPieDePagina()
        {
            this.InitializeComponent();
        }

        private void ConfiguracionPieDePagina_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new Fachada.TablasMaestras.ConfiguracionPieDePagina();
            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> ListaPieDePaginaConElementos = ConfigPieDePagina.Listar();


            Entidades.ConfiguracionPieDePagina PieDePagina = new Entidades.ConfiguracionPieDePagina()
            {
                AtencionSkype = this.TxtAtencionSkype.Text,
                LineaTelefonica = this.TxtLineaTelefonica.Text,
                LineaCelular = this.TxtLineaCelular.Text,
                CorreoElectronico = this.TxtCorreoElectronico.Text,
                Devoluciones = this.TxtDevoluciones.Text,
                ComoPagar = this.TxtComoPagar.Text,
                Envios = this.TxtEnvios.Text
            };

            if (ListaPieDePaginaConElementos.Count > 0)
            {
                foreach (Entidades.ConfiguracionPieDePagina item in ListaPieDePaginaConElementos)
                {
                    this.TxtAtencionSkype.Text = item.AtencionSkype;
                    this.TxtLineaTelefonica.Text = item.LineaTelefonica;
                    this.TxtLineaCelular.Text = item.LineaCelular;
                    this.TxtCorreoElectronico.Text = item.CorreoElectronico;
                    this.TxtDevoluciones.Text = item.Devoluciones;
                    this.TxtComoPagar.Text = item.ComoPagar;
                    this.TxtEnvios.Text = item.Envios;
                }
                this.DeshabilitarControlesFormulario();
                this.BtnGuardar.Enabled = false;
            }
            else
            {
                this.BtnActualizar.Enabled = false;
            }

        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.ConfiguracionPieDePagina ConfigPieDePagina = new Fachada.TablasMaestras.ConfiguracionPieDePagina();
            Entidades.ResultadoTransaccion resultadoTransaccion = null;
            Entidades.ConfiguracionPieDePagina PieDePagina = new Entidades.ConfiguracionPieDePagina();

            System.Collections.ObjectModel.ReadOnlyCollection<Entidades.ConfiguracionPieDePagina> ListaPieDePaginaConElementos = ConfigPieDePagina.Listar();

            if (ListaPieDePaginaConElementos.Count > 0)
            {
                // Actualizar
                int IdPieDePagina = int.Parse(ListaPieDePaginaConElementos[0].Id.ToString());

                PieDePagina.Id = IdPieDePagina;
                PieDePagina.AtencionSkype = this.TxtAtencionSkype.Text;
                PieDePagina.LineaTelefonica = this.TxtLineaTelefonica.Text;
                PieDePagina.LineaCelular = this.TxtLineaCelular.Text;
                PieDePagina.CorreoElectronico = this.TxtCorreoElectronico.Text;
                PieDePagina.Devoluciones = this.TxtDevoluciones.Text;
                PieDePagina.ComoPagar = this.TxtComoPagar.Text;
                PieDePagina.Envios = this.TxtEnvios.Text;

                resultadoTransaccion = ConfigPieDePagina.Actualizar(PieDePagina);
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DeshabilitarControlesFormulario();
                BtnGuardar.Enabled = false;
            }
            else
            {
                // Insertar
                PieDePagina.AtencionSkype = this.TxtAtencionSkype.Text;
                PieDePagina.LineaTelefonica = this.TxtLineaTelefonica.Text;
                PieDePagina.LineaCelular = this.TxtLineaCelular.Text;
                PieDePagina.CorreoElectronico = this.TxtCorreoElectronico.Text;
                PieDePagina.Devoluciones = this.TxtDevoluciones.Text;
                PieDePagina.ComoPagar = this.TxtComoPagar.Text;
                PieDePagina.Envios = this.TxtEnvios.Text;

                resultadoTransaccion = ConfigPieDePagina.Insertar(PieDePagina);
                MessageBox.Show(resultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                this.DeshabilitarControlesFormulario();
                BtnGuardar.Enabled = false;
            }

        }


        private void DeshabilitarControlesFormulario()
        {
            this.TxtAtencionSkype.Enabled = false;
            this.TxtLineaTelefonica.Enabled = false;
            this.TxtLineaCelular.Enabled = false;
            this.TxtCorreoElectronico.Enabled = false;
            this.TxtDevoluciones.Enabled = false;
            this.TxtComoPagar.Enabled = false;
            this.TxtEnvios.Enabled = false;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.HabilitarControlesFormulario();
            this.BtnActualizar.Enabled = false;
            this.BtnGuardar.Enabled = true;
        }

        private void HabilitarControlesFormulario()
        {
            this.TxtAtencionSkype.Enabled = true;
            this.TxtLineaTelefonica.Enabled = true;
            this.TxtLineaCelular.Enabled = true;
            this.TxtCorreoElectronico.Enabled = true;
            this.TxtDevoluciones.Enabled = true;
            this.TxtComoPagar.Enabled = true;
            this.TxtEnvios.Enabled = true;
            this.BtnGuardar.Enabled = true;
        }
    }
}
