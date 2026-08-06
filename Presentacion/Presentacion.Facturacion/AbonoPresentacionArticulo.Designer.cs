namespace Presentacion.Facturacion
{
    partial class AbonoPresentacionArticulo
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
            this.TxtValorAbono = new System.Windows.Forms.TextBox();
            this.LblValorAbono = new System.Windows.Forms.Label();
            this.BtnAbonarPago = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtValorAbono
            // 
            this.TxtValorAbono.Location = new System.Drawing.Point(208, 28);
            this.TxtValorAbono.Name = "TxtValorAbono";
            this.TxtValorAbono.Size = new System.Drawing.Size(167, 20);
            this.TxtValorAbono.TabIndex = 0;
            // 
            // LblValorAbono
            // 
            this.LblValorAbono.AutoSize = true;
            this.LblValorAbono.Location = new System.Drawing.Point(30, 31);
            this.LblValorAbono.Name = "LblValorAbono";
            this.LblValorAbono.Size = new System.Drawing.Size(171, 13);
            this.LblValorAbono.TabIndex = 1;
            this.LblValorAbono.Text = "Ingresar el valor del abono a pagar";
            // 
            // BtnAbonarPago
            // 
            this.BtnAbonarPago.Location = new System.Drawing.Point(208, 59);
            this.BtnAbonarPago.Name = "BtnAbonarPago";
            this.BtnAbonarPago.Size = new System.Drawing.Size(75, 23);
            this.BtnAbonarPago.TabIndex = 2;
            this.BtnAbonarPago.Text = "Aceptar";
            this.BtnAbonarPago.UseVisualStyleBackColor = true;
            this.BtnAbonarPago.Click += new System.EventHandler(this.BtnAbonarPago_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(300, 59);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // AbonoPresentacionArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 104);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAbonarPago);
            this.Controls.Add(this.LblValorAbono);
            this.Controls.Add(this.TxtValorAbono);
            this.Name = "AbonoPresentacionArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abonar Pagos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtValorAbono;
        private System.Windows.Forms.Label LblValorAbono;
        private System.Windows.Forms.Button BtnAbonarPago;
        private System.Windows.Forms.Button BtnCancelar;
    }
}