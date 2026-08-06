// -----------------------------------------------------------------------
// <copyright file="ControlTransparente.cs" company="Todo Ventas Colombia">
// Software Exclusivo de Todo Ventas Colombia
// </copyright>
// ----------------------------------------------------------------------

namespace Controles.WinForms
{
    using System;
    using System.Windows.Forms;

    public partial class UcCargaImagenes : UserControl
    {
        public event EventHandler MouseHoverControlCargaImagen;
        private string toolTipText = string.Empty;

        public UcCargaImagenes()
        {
            this.InitializeComponent();

            this.Open_File_Dialog = new OpenFileDialog();
            this.Open_File_Dialog.Filter = "Archivos de Imagen jpg|*.jpg";
            this.Open_File_Dialog.FileName = string.Empty;
            this.Open_File_Dialog.Title = "Examinar...";
        }

        private void UcCargaImagenes_MouseHover(object sender, EventArgs e)
        {
            MouseHoverControlCargaImagen?.Invoke(this, e);
        }
        public Label LblUrlimagenes
        {
            get
            {
                this.Open_File_Dialog.FileName = this.LblUrlimagen1.Text;
                return this.LblUrlimagen1;

            }
            set
            {
                if (value != null)
                {
                    this.LblUrlimagen1 = value;
                }
            }
        }

        public Button BtnExaminarImagenes
        {
            get
            {
                return this.BtnExaminar;
            }
            set
            {
                if (value != null)
                {
                    this.BtnExaminar = value;
                }
            }
        }

        public PictureBox PbVistaPreviaImagen
        {
            get
            {
                return this.pictureBoxImg1;
            }
            set
            {
                if (value != null)
                {
                    this.pictureBoxImg1 = value;
                }
            }
        }

        public OpenFileDialog Open_File_Dialog { get; set; }

        public string ToolTipText
        {
            get
            {
                return this.toolTipText;
            }
            set
            {
                this.toolTipText = value;
                this.ControlToolTip.SetToolTip(this.LblUrlimagen1, toolTipText);
                this.ControlToolTip.SetToolTip(this.BtnExaminar, toolTipText);
                this.ControlToolTip.SetToolTip(this.BtnLimpiar, toolTipText);
                this.ControlToolTip.SetToolTip(this.pictureBoxImg1, toolTipText);
                this.ControlToolTip.SetToolTip(this, toolTipText);
            }
        }

        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            if (this.Open_File_Dialog.ShowDialog() == DialogResult.OK)
            {
                string Direccion = this.Open_File_Dialog.FileName;
                this.pictureBoxImg1.ImageLocation = Direccion;
                pictureBoxImg1.SizeMode = PictureBoxSizeMode.StretchImage;
                LblUrlimagen1.Text = Direccion; this.UcCargaImagenes_MouseHover(null, null);
            }
        }

        public void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LblUrlimagen1.Text = string.Empty;
            this.pictureBoxImg1.ImageLocation = string.Empty;
            this.Open_File_Dialog.FileName = string.Empty;
        }
    }
}
