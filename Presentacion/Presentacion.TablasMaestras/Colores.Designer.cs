namespace Presentacion.TablasMaestras
{
    partial class Colores
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
            this.components = new System.ComponentModel.Container();
            this.LblCodigoHexadecimal = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.TxtCodigoHexadecimal = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.BtnShowColorDialog = new System.Windows.Forms.Button();
            this.DgvColor = new System.Windows.Forms.DataGridView();
            this.barraBotonesCRUD1 = new Controles.WinForms.BarraBotonesCrud();
            this.ValidarFormColores = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidarFormColores)).BeginInit();
            this.SuspendLayout();
            // 
            // LblCodigoHexadecimal
            // 
            this.LblCodigoHexadecimal.AutoSize = true;
            this.LblCodigoHexadecimal.Location = new System.Drawing.Point(9, 273);
            this.LblCodigoHexadecimal.Name = "LblCodigoHexadecimal";
            this.LblCodigoHexadecimal.Size = new System.Drawing.Size(0, 13);
            this.LblCodigoHexadecimal.TabIndex = 1;
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(9, 303);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(0, 13);
            this.LblNombre.TabIndex = 2;
            // 
            // TxtCodigoHexadecimal
            // 
            this.TxtCodigoHexadecimal.Enabled = false;
            this.TxtCodigoHexadecimal.Location = new System.Drawing.Point(119, 270);
            this.TxtCodigoHexadecimal.MaxLength = 6;
            this.TxtCodigoHexadecimal.Name = "TxtCodigoHexadecimal";
            this.TxtCodigoHexadecimal.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigoHexadecimal.TabIndex = 3;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Location = new System.Drawing.Point(119, 300);
            this.TxtNombre.MaxLength = 20;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(130, 20);
            this.TxtNombre.TabIndex = 4;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            // 
            // BtnShowColorDialog
            // 
            this.BtnShowColorDialog.Enabled = false;
            this.BtnShowColorDialog.Location = new System.Drawing.Point(246, 268);
            this.BtnShowColorDialog.Name = "BtnShowColorDialog";
            this.BtnShowColorDialog.Size = new System.Drawing.Size(24, 23);
            this.BtnShowColorDialog.TabIndex = 5;
            this.BtnShowColorDialog.UseVisualStyleBackColor = true;
            this.BtnShowColorDialog.Click += new System.EventHandler(this.BtnShowColorDialog_Click);
            // 
            // DgvColor
            // 
            this.DgvColor.AllowUserToAddRows = false;
            this.DgvColor.AllowUserToDeleteRows = false;
            this.DgvColor.AllowUserToResizeColumns = false;
            this.DgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvColor.Location = new System.Drawing.Point(12, 22);
            this.DgvColor.MultiSelect = false;
            this.DgvColor.Name = "DgvColor";
            this.DgvColor.ReadOnly = true;
            this.DgvColor.RowHeadersVisible = false;
            this.DgvColor.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvColor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvColor.Size = new System.Drawing.Size(397, 240);
            this.DgvColor.TabIndex = 6;
            this.DgvColor.SelectionChanged += new System.EventHandler(this.DgvColor_SelectionChanged);
            // 
            // barraBotonesCRUD1
            // 
            this.barraBotonesCRUD1.Location = new System.Drawing.Point(9, 342);
            this.barraBotonesCRUD1.Name = "barraBotonesCRUD1";
            this.barraBotonesCRUD1.OperacionCrud = Entidades.Enumeraciones.Operacion.Insercion;
            this.barraBotonesCRUD1.Size = new System.Drawing.Size(400, 27);
            this.barraBotonesCRUD1.TabIndex = 8;
            // 
            // ValidarFormColores
            // 
            this.ValidarFormColores.BlinkRate = 0;
            this.ValidarFormColores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ValidarFormColores.ContainerControl = this;
            // 
            // Colores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 381);
            this.Controls.Add(this.barraBotonesCRUD1);
            this.Controls.Add(this.DgvColor);
            this.Controls.Add(this.BtnShowColorDialog);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.TxtCodigoHexadecimal);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.LblCodigoHexadecimal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Colores";
            this.Activated += new System.EventHandler(this.Colores_Activated);
            this.Load += new System.EventHandler(this.Colores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidarFormColores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controles.WinForms.BarraBotonesCrud barraBotonesCRUD1;
        private System.Windows.Forms.Label LblCodigoHexadecimal;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.TextBox TxtCodigoHexadecimal;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Button BtnShowColorDialog;
        private System.Windows.Forms.DataGridView DgvColor;
        private System.Windows.Forms.ErrorProvider ValidarFormColores;

    }
}