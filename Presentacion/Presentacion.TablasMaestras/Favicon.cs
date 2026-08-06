

namespace Presentacion.TablasMaestras
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Favicon : Form
    {
        public Favicon()
        {
            Fachada.TablasMaestras.Favicon Favicon = null;
            byte[] IconoFavicon = null;
            System.IO.MemoryStream ImageStream = null;

            this.InitializeComponent();
            this.ucCargaImagenes1.Open_File_Dialog.Filter = "iconos (*.ico)|*.ico";

            Favicon = new Fachada.TablasMaestras.Favicon();
            IconoFavicon = Favicon.DescargarIcono();

            if (IconoFavicon != null)
            {
                ImageStream = new System.IO.MemoryStream(IconoFavicon);
                this.pictureBox1.Image = System.Drawing.Image.FromStream(ImageStream);
            }

            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Fachada.TablasMaestras.Favicon Favicon = new Fachada.TablasMaestras.Favicon();
            bool Resultado = Favicon.EliminarIcono();

            if (Resultado == true)
            {
                MessageBox.Show("El icono ha sido eliminado exitosamente del sitio web", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.pictureBox1.Image = null;
                this.pictureBox1.ImageLocation = string.Empty;
            }
            else
            {
                MessageBox.Show("La operación de borrado no pudo completarse, contacte al administrador del sistema", "Operación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCargarIcono_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.ucCargaImagenes1.LblUrlimagenes.Text))
            {
                byte[] IconoFavicon = null;
                Fachada.TablasMaestras.Favicon favicon = null;
                double PesoEnBytes = double.MinValue;
                bool Resultado = false;

                IconoFavicon  = System.IO.File.ReadAllBytes(this.ucCargaImagenes1.LblUrlimagenes.Text);

                PesoEnBytes = IconoFavicon.Count();
                if (PesoEnBytes > 5120)
                {
                    MessageBox.Show("El icono debe tener un peso máximo de 5 Kilo bytes", "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                System.Drawing.Image imagen = System.Drawing.Image.FromFile(this.ucCargaImagenes1.LblUrlimagenes.Text);
                int alto = imagen.Size.Height;
                int ancho = imagen.Size.Width;
                if (alto != 32 || ancho != 32)
                {
                    MessageBox.Show("el icono debe tener dimensiones de 32 x 32 Pixeles", "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                favicon = new Fachada.TablasMaestras.Favicon();
                Resultado = favicon.CargarIcono(IconoFavicon);

                if (Resultado == true)
                {
                    // Mostrar la imágen una vez haya sido cargada con éxito en el sitio web
                    this.pictureBox1.ImageLocation = this.ucCargaImagenes1.LblUrlimagenes.Text;
                    this.ucCargaImagenes1.LblUrlimagenes.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Hubo un error al cargar el achivo, contacte al administrador del sistema", "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un archivo para cargar en formato .ico", "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
