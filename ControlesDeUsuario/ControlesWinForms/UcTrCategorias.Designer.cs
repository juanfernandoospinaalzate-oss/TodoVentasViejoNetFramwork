namespace Controles.WinForms
{
    partial class UctrCategorias
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.LblLoading = new System.Windows.Forms.Label();
            this.controlTransparente1 = new Controles.WinForms.ControlTransparente();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(393, 162);
            this.treeView1.TabIndex = 0;
            // 
            // LblLoading
            // 
            this.LblLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblLoading.AutoSize = true;
            this.LblLoading.Location = new System.Drawing.Point(45, 63);
            this.LblLoading.Name = "LblLoading";
            this.LblLoading.Size = new System.Drawing.Size(0, 13);
            this.LblLoading.TabIndex = 1;
            this.LblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblLoading.Visible = false;
            // 
            // controlTransparente1
            // 
            this.controlTransparente1.Location = new System.Drawing.Point(0, 0);
            this.controlTransparente1.Name = "controlTransparente1";
            this.controlTransparente1.Size = new System.Drawing.Size(393, 159);
            this.controlTransparente1.TabIndex = 2;
            this.controlTransparente1.Text = "controlTransparente1";
            // 
            // UctrCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlTransparente1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.LblLoading);
            this.Name = "UctrCategorias";
            this.Size = new System.Drawing.Size(393, 162);
            this.Load += new System.EventHandler(this.TRCategoriasLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label LblLoading;
        private ControlTransparente controlTransparente1;
    }
}
