namespace Plugin.MetodosDePagoChile.Frontend
{
    partial class ViewFormCreditoDebito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewFormCreditoDebito));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mensaje = new System.Windows.Forms.Label();
            this.aceptar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.x_monto = new System.Windows.Forms.TextBox();
            this.pin_pad_integrado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 33);
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // mensaje
            // 
            this.mensaje.AutoSize = true;
            this.mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje.Location = new System.Drawing.Point(93, 250);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(94, 20);
            this.mensaje.TabIndex = 113;
            this.mensaje.Text = "lorem ipsum";
            this.mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.Transparent;
            this.aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aceptar.Location = new System.Drawing.Point(45, 189);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(87, 45);
            this.aceptar.TabIndex = 111;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cancelar
            // 
            this.cancelar.BackColor = System.Drawing.Color.Transparent;
            this.cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelar.Location = new System.Drawing.Point(151, 189);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(94, 45);
            this.cancelar.TabIndex = 112;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(45, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 110;
            this.label2.Text = "Monto";
            // 
            // x_monto
            // 
            this.x_monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_monto.Location = new System.Drawing.Point(45, 121);
            this.x_monto.MaxLength = 9;
            this.x_monto.Name = "x_monto";
            this.x_monto.Size = new System.Drawing.Size(200, 31);
            this.x_monto.TabIndex = 109;
            // 
            // pin_pad_integrado
            // 
            this.pin_pad_integrado.AutoSize = true;
            this.pin_pad_integrado.Checked = true;
            this.pin_pad_integrado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pin_pad_integrado.Location = new System.Drawing.Point(12, 298);
            this.pin_pad_integrado.Name = "pin_pad_integrado";
            this.pin_pad_integrado.Size = new System.Drawing.Size(105, 17);
            this.pin_pad_integrado.TabIndex = 115;
            this.pin_pad_integrado.Text = "PinPadIntegrado";
            this.pin_pad_integrado.UseVisualStyleBackColor = true;
            this.pin_pad_integrado.CheckedChanged += new System.EventHandler(this.pin_pad_integrado_CheckedChanged);
            // 
            // ViewFormCreditoDebito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(290, 327);
            this.Controls.Add(this.pin_pad_integrado);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.x_monto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewFormCreditoDebito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewFormCreditoDebito";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mensaje;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox x_monto;
        private System.Windows.Forms.CheckBox pin_pad_integrado;
    }
}