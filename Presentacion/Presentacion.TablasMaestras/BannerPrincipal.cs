using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.TablasMaestras
{
    public partial class BannerPrincipal : Form
    {
        public BannerPrincipal()
        {
            InitializeComponent();

            this.ucCargaBigBanner1.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaBigBanner2.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaBigBanner3.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaBigBanner4.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaBigBanner5.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;

            this.ucCargaBigBanner1.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0250").Texto;
            this.ucCargaBigBanner2.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0250").Texto;
            this.ucCargaBigBanner3.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0250").Texto;
            this.ucCargaBigBanner4.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0250").Texto;
            this.ucCargaBigBanner5.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0250").Texto;

            this.ucCargaSmallBanner1.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaSmallBanner2.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaSmallBanner3.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaSmallBanner4.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
            this.ucCargaSmallBanner5.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;

            this.ucCargaSmallBanner1.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0251").Texto;
            this.ucCargaSmallBanner2.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0251").Texto;
            this.ucCargaSmallBanner3.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0251").Texto;
            this.ucCargaSmallBanner4.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0251").Texto;
            this.ucCargaSmallBanner5.ToolTipText = Mensajes.LinqToXml.LeerEtiquetaControles("0251").Texto;

            this.ucCargaImagenVideoMiniatura.MouseHoverControlCargaImagen += this.ucCargaImagenes_MouseHover;
        }

        private void BannerPrincipal_Load(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.BannerPrincipal FachadaBanner = null;
            Entidades.BannerPrincipal ObjBanner = null;

            CbFuenteVideo.DataSource = Enum.GetValues(typeof(Entidades.Enumeraciones.BannerPrincipalVideoDataSource));

            FachadaBanner = new Fachada.TablasMaestras.BannerPrincipal();
            ObjBanner = FachadaBanner.Consultar();

            if (ObjBanner != null)
            {
                this.CargarImagen(this.ucCargaBigBanner1, ObjBanner.BigBanner1, ObjBanner.BigBanner1Binario);
                this.TxtBigBanner1.Text = ObjBanner.UrlPresentacionArticulo1;

                this.CargarImagen(this.ucCargaBigBanner2, ObjBanner.BigBanner2, ObjBanner.BigBanner2Binario);
                this.TxtBigBanner2.Text = ObjBanner.UrlPresentacionArticulo2;

                this.CargarImagen(this.ucCargaBigBanner3, ObjBanner.BigBanner3, ObjBanner.BigBanner3Binario);
                this.TxtBigBanner3.Text = ObjBanner.UrlPresentacionArticulo3;

                this.CargarImagen(this.ucCargaBigBanner4, ObjBanner.BigBanner4, ObjBanner.BigBanner4Binario);
                this.TxtBigBanner4.Text = ObjBanner.UrlPresentacionArticulo4;

                this.CargarImagen(this.ucCargaBigBanner5, ObjBanner.BigBanner5, ObjBanner.BigBanner5Binario);
                this.TxtBigBanner5.Text = ObjBanner.UrlPresentacionArticulo5;

                this.CargarImagen(this.ucCargaSmallBanner1, ObjBanner.SmallBanner1, ObjBanner.SmallBanner1Binario);
                this.TxtSmallBanner1.Text = ObjBanner.UrlPresentacionArticulo6;

                this.CargarImagen(this.ucCargaSmallBanner2, ObjBanner.SmallBanner2, ObjBanner.SmallBanner2Binario);
                this.TxtSmallBanner2.Text = ObjBanner.UrlPresentacionArticulo7;

                this.CargarImagen(this.ucCargaSmallBanner3, ObjBanner.SmallBanner3, ObjBanner.SmallBanner3Binario);
                this.TxtSmallBanner3.Text = ObjBanner.UrlPresentacionArticulo8;

                this.CargarImagen(this.ucCargaSmallBanner4, ObjBanner.SmallBanner4, ObjBanner.SmallBanner4Binario);
                this.TxtSmallBanner4.Text = ObjBanner.UrlPresentacionArticulo9;

                this.CargarImagen(this.ucCargaSmallBanner5, ObjBanner.SmallBanner5, ObjBanner.SmallBanner5Binario);
                this.TxtSmallBanner5.Text = ObjBanner.UrlPresentacionArticulo10;

                this.CbFuenteVideo.SelectedItem = ObjBanner.VideoDataSource;
                this.TxtVideoId.Text = ObjBanner.VideoDataId;
                this.CargarImagen(this.ucCargaImagenVideoMiniatura, ObjBanner.VideoImagenMiniatura, ObjBanner.VideoImagenMiniaturaBinario);

                this.CargarVideo();

                this.CbSegundoAutoplayFotorama.SelectedItem = ObjBanner.SegundoAutoplayFotorama.ToString();
            }
        }

        private void ucCargaImagenes_MouseHover(object sender, EventArgs e)
        {
            Controles.WinForms.UcCargaImagenes UcCargaImagenes = sender as Controles.WinForms.UcCargaImagenes;

            if (UcCargaImagenes.LblUrlimagenes.Text != string.Empty)
            {
                PictureBoxVistaPrevia.ImageLocation = UcCargaImagenes.LblUrlimagenes.Text;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.BannerPrincipal FachadaBanner = null;
            Entidades.BannerPrincipal Banner = null;
            Entidades.ResultadoTransaccion ResultadoTransaccion = null;

            this.errorProvider1.Clear();

            // Se debe gestionar cómo mínimo la pimera imágen de big banner
            if (ucCargaBigBanner1.LblUrlimagenes.Text == string.Empty)
            {
                errorProvider1.SetError(this.ucCargaBigBanner1, Mensajes.LinqToXml.LeerMensaje("0101").Texto);
                return;
            }

            // Se debe gestionar como mínimo la primera imágen de small banner
            if (ucCargaSmallBanner1.LblUrlimagenes.Text == string.Empty)
            {
                errorProvider1.SetError(this.ucCargaSmallBanner1, Mensajes.LinqToXml.LeerMensaje("0102").Texto);
                return;
            }

            // Validar URLs de las páginas
            if (!this.VerificarURLsValidas())
            {
                return;
            }

            // Verificar si hay hay Registro
            FachadaBanner = new Fachada.TablasMaestras.BannerPrincipal();
            Banner = FachadaBanner.Consultar();

            if (Banner == null)
            {
                // Si no hay registro, insertar
                Banner = this.CargarEntidadBanner();
                ResultadoTransaccion = FachadaBanner.Insertar(Banner);
            }
            else
            {
                // Si ya hay registro, actualizar
                Banner = this.CargarEntidadBanner();
                ResultadoTransaccion = FachadaBanner.Actualizar(Banner);
            }

            if (ResultadoTransaccion.RegistrosAfectados == 1)
            {
                MessageBox.Show(ResultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
            else
            {
                MessageBox.Show(ResultadoTransaccion.Mensaje.Texto, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            }
        }

        private void TxtVideoId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar ==  Keys.Enter) 
            {
                e.Handled = true; // Remover Beep

                Entidades.Enumeraciones.BannerPrincipalVideoDataSource enumeracionFuenteVideo = new Entidades.Enumeraciones.BannerPrincipalVideoDataSource();
                enumeracionFuenteVideo = (Entidades.Enumeraciones.BannerPrincipalVideoDataSource) this.CbFuenteVideo.SelectedValue;

                if (enumeracionFuenteVideo == Entidades.Enumeraciones.BannerPrincipalVideoDataSource.youtube)
                {
                    string stringUrl = "https://www.youtube.com/embed/" + this.TxtVideoId.Text;
                    this.webView21.Source = new Uri(stringUrl);
                }

                if (enumeracionFuenteVideo == Entidades.Enumeraciones.BannerPrincipalVideoDataSource.vimeo)
                {
                    string stringUrl = "https://player.vimeo.com/video/" + this.TxtVideoId.Text;
                    this.webView21.Source = new Uri(stringUrl);
                }
            }
        }

        private void CbFuenteVideo_SelectedValueChanged(object sender, EventArgs e)
        {
            this.CargarVideo();
        }

        private void CargarImagen(Controles.WinForms.UcCargaImagenes ucCargaImagen, string NombreImagen, byte[] bytesImagen)
        {
            string rutaTemporal = System.IO.Path.GetTempPath();
            System.IO.MemoryStream ms = null;
            System.IO.FileStream fs = null;

            if (NombreImagen == null || NombreImagen == string.Empty || bytesImagen == null)
            {
                return;
            }

            rutaTemporal = rutaTemporal + NombreImagen;

            if (System.IO.File.Exists(rutaTemporal))
            {
                System.IO.File.Delete(rutaTemporal);
            }

            ms = new System.IO.MemoryStream(bytesImagen);
            fs = new System.IO.FileStream(rutaTemporal, System.IO.FileMode.Create);
            ms.WriteTo(fs);
            fs.Close();
            ms.Close();

            ucCargaImagen.LblUrlimagenes.Text = rutaTemporal;
            ucCargaImagen.PbVistaPreviaImagen.ImageLocation = rutaTemporal;
        }

        private void CargarVideo()
        {
            System.Windows.Forms.KeyPressEventArgs keyPressEventArg = new KeyPressEventArgs(new char());
            keyPressEventArg.KeyChar = (char)Keys.Enter;
            this.TxtVideoId_KeyPress(null, keyPressEventArg);
        }

        private Entidades.BannerPrincipal CargarEntidadBanner()
        {
            Entidades.BannerPrincipal Banner = new Entidades.BannerPrincipal();
            Banner.BigBanner1 = this.ucCargaBigBanner1.Open_File_Dialog.SafeFileName;
            Banner.BigBanner1Binario = System.IO.File.ReadAllBytes(this.ucCargaBigBanner1.LblUrlimagenes.Text);

            if (this.ucCargaBigBanner2.LblUrlimagenes.Text != string.Empty)
            {
                Banner.BigBanner2 = this.ucCargaBigBanner2.Open_File_Dialog.SafeFileName;
                Banner.BigBanner2Binario = System.IO.File.ReadAllBytes(this.ucCargaBigBanner2.LblUrlimagenes.Text);
            }
            else
            {
                Banner.BigBanner2 = string.Empty;
                Banner.BigBanner2Binario = new byte[] { };
            }

            if (this.ucCargaBigBanner3.LblUrlimagenes.Text != string.Empty)
            {
                Banner.BigBanner3 = this.ucCargaBigBanner3.Open_File_Dialog.SafeFileName;
                Banner.BigBanner3Binario = System.IO.File.ReadAllBytes(this.ucCargaBigBanner3.LblUrlimagenes.Text);
            }
            else
            {
                Banner.BigBanner3 = string.Empty;
                Banner.BigBanner3Binario = new byte[] { };
            }

            if (this.ucCargaBigBanner4.LblUrlimagenes.Text != string.Empty)
            {
                Banner.BigBanner4 = this.ucCargaBigBanner4.Open_File_Dialog.SafeFileName;
                Banner.BigBanner4Binario = System.IO.File.ReadAllBytes(this.ucCargaBigBanner4.LblUrlimagenes.Text);
            }
            else
            {
                Banner.BigBanner4 = string.Empty;
                Banner.BigBanner4Binario = new byte[] { };
            }

            if (this.ucCargaBigBanner5.LblUrlimagenes.Text != string.Empty)
            {
                Banner.BigBanner5 = this.ucCargaBigBanner5.Open_File_Dialog.SafeFileName;
                Banner.BigBanner5Binario = System.IO.File.ReadAllBytes(this.ucCargaBigBanner5.LblUrlimagenes.Text);
            }
            else
            {
                Banner.BigBanner5 = string.Empty;
                Banner.BigBanner5Binario = new byte[] { };
            }

            Banner.SmallBanner1 = this.ucCargaSmallBanner1.Open_File_Dialog.SafeFileName;
            Banner.SmallBanner1Binario = System.IO.File.ReadAllBytes(this.ucCargaSmallBanner1.LblUrlimagenes.Text);

            if (this.ucCargaSmallBanner2.LblUrlimagenes.Text != string.Empty)
            {
                Banner.SmallBanner2 = this.ucCargaSmallBanner2.Open_File_Dialog.SafeFileName;
                Banner.SmallBanner2Binario = System.IO.File.ReadAllBytes(this.ucCargaSmallBanner2.LblUrlimagenes.Text);
            }
            else
            {
                Banner.SmallBanner2 = string.Empty;
                Banner.SmallBanner2Binario = new byte[] { };
            }

            if (this.ucCargaSmallBanner3.LblUrlimagenes.Text != string.Empty)
            {
                Banner.SmallBanner3 = this.ucCargaSmallBanner3.Open_File_Dialog.SafeFileName;
                Banner.SmallBanner3Binario = System.IO.File.ReadAllBytes(this.ucCargaSmallBanner3.LblUrlimagenes.Text);
            }
            else
            {
                Banner.SmallBanner3 = string.Empty;
                Banner.SmallBanner3Binario = new byte[] { };
            }

            if (this.ucCargaSmallBanner4.LblUrlimagenes.Text != string.Empty)
            {
                Banner.SmallBanner4 = this.ucCargaSmallBanner4.Open_File_Dialog.SafeFileName;
                Banner.SmallBanner4Binario = System.IO.File.ReadAllBytes(this.ucCargaSmallBanner4.LblUrlimagenes.Text);
            }
            else
            {
                Banner.SmallBanner4 = string.Empty;
                Banner.SmallBanner4Binario = new byte[] { };
            }

            if (this.ucCargaSmallBanner5.LblUrlimagenes.Text != string.Empty)
            {
                Banner.SmallBanner5 = this.ucCargaSmallBanner5.Open_File_Dialog.SafeFileName;
                Banner.SmallBanner5Binario = System.IO.File.ReadAllBytes(this.ucCargaSmallBanner5.LblUrlimagenes.Text);
            }
            else
            {
                Banner.SmallBanner5 = string.Empty;
                Banner.SmallBanner5Binario = new byte[] { };
            }

            Banner.VideoDataSource = (Entidades.Enumeraciones.BannerPrincipalVideoDataSource) this.CbFuenteVideo.SelectedValue;
            Banner.VideoDataId = this.TxtVideoId.Text;
            

            if (this.ucCargaImagenVideoMiniatura.LblUrlimagenes.Text != string.Empty)
            {
                Banner.VideoImagenMiniatura = this.ucCargaImagenVideoMiniatura.Open_File_Dialog.SafeFileName;
                Banner.VideoImagenMiniaturaBinario = System.IO.File.ReadAllBytes(this.ucCargaImagenVideoMiniatura.LblUrlimagenes.Text);
            }
            else
            {
                Banner.VideoImagenMiniatura = string.Empty;
                Banner.VideoImagenMiniaturaBinario = new byte[] { };
            }

            Banner.UrlPresentacionArticulo1 = this.TxtBigBanner1.Text;
            Banner.UrlPresentacionArticulo2 = this.TxtBigBanner2.Text;
            Banner.UrlPresentacionArticulo3 = this.TxtBigBanner3.Text;
            Banner.UrlPresentacionArticulo4 = this.TxtBigBanner4.Text;
            Banner.UrlPresentacionArticulo5 = this.TxtBigBanner5.Text;
            Banner.UrlPresentacionArticulo6 = this.TxtSmallBanner1.Text;
            Banner.UrlPresentacionArticulo7 = this.TxtSmallBanner2.Text;
            Banner.UrlPresentacionArticulo8 = this.TxtSmallBanner3.Text;
            Banner.UrlPresentacionArticulo9 = this.TxtSmallBanner4.Text;
            Banner.UrlPresentacionArticulo10 = this.TxtSmallBanner5.Text;

            Banner.SegundoAutoplayFotorama = int.Parse(this.CbSegundoAutoplayFotorama.SelectedItem.ToString());

            return Banner;
        }

        private bool VerificarURLsValidas()
        {
            ValidacionesComunes.Validacion Val = new ValidacionesComunes.Validacion();

            // Recorrer todos los controles del formulario
            foreach (Control item in this.Controls)
            {
                // procesar únicamente los TextBox que no sean el de video y que tengan contenido
                if (item is TextBox && item != this.TxtVideoId && item.Text.Trim() != string.Empty)
                {
                    if (!Val.EsUrlHttpsValida(item.Text))
                    {
                        errorProvider1.SetError(item, "Dirección URL no válida");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
