namespace Presentacion.TablasMaestras
{
    partial class Categorias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtPalabrasClave = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblPalabraClave = new System.Windows.Forms.Label();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.barraBotonesCRUD1 = new Controles.WinForms.BarraBotonesCrud();
            this.UcTrCategorias1 = new Controles.WinForms.UctrCategorias();
            this.SuspendLayout();
            // 
            // TxtPalabrasClave
            // 
            this.TxtPalabrasClave.Enabled = false;
            this.TxtPalabrasClave.Location = new System.Drawing.Point(118, 78);
            this.TxtPalabrasClave.Name = "TxtPalabrasClave";
            this.TxtPalabrasClave.Size = new System.Drawing.Size(300, 20);
            this.TxtPalabrasClave.TabIndex = 31;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Enabled = false;
            this.TxtDescripcion.Location = new System.Drawing.Point(118, 45);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(300, 20);
            this.TxtDescripcion.TabIndex = 30;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Location = new System.Drawing.Point(118, 12);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(300, 20);
            this.TxtNombre.TabIndex = 29;
            // 
            // LblPalabraClave
            // 
            this.LblPalabraClave.AutoSize = true;
            this.LblPalabraClave.Location = new System.Drawing.Point(22, 81);
            this.LblPalabraClave.Name = "LblPalabraClave";
            this.LblPalabraClave.Size = new System.Drawing.Size(0, 13);
            this.LblPalabraClave.TabIndex = 28;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.Location = new System.Drawing.Point(22, 48);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(0, 13);
            this.LblDescripcion.TabIndex = 27;
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(22, 15);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(0, 13);
            this.LblNombre.TabIndex = 26;
            // 
            // barraBotonesCRUD1
            // 
            this.barraBotonesCRUD1.Location = new System.Drawing.Point(25, 301);
            this.barraBotonesCRUD1.Name = "barraBotonesCRUD1";
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCRUD1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCRUD1.TabIndex = 32;
            // 
            // UcTrCategorias1
            // 
            this.UcTrCategorias1.Location = new System.Drawing.Point(25, 117);
            this.UcTrCategorias1.Name = "UcTrCategorias1";
            this.UcTrCategorias1.Size = new System.Drawing.Size(393, 162);
            this.UcTrCategorias1.TabIndex = 33;
            // 
            // Categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 355);
            this.Controls.Add(this.UcTrCategorias1);
            this.Controls.Add(this.barraBotonesCRUD1);
            this.Controls.Add(this.TxtPalabrasClave);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblPalabraClave);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.LblNombre);
            this.Name = "Categorias";
            this.Load += new System.EventHandler(this.Categorias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPalabrasClave;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblPalabraClave;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label LblNombre;
        private Controles.WinForms.BarraBotonesCrud barraBotonesCRUD1;
        private Controles.WinForms.UctrCategorias UcTrCategorias1;
    }
}