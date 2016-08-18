namespace Plugin.MetodosDePagoChile.Frontend
{
    partial class ViewFormAnularVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewFormAnularVenta));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mensaje = new System.Windows.Forms.Label();
            this.aceptar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.lbl_x_nro_operacion = new System.Windows.Forms.Label();
            this.x_nro_operacion = new System.Windows.Forms.TextBox();
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
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // mensaje
            // 
            this.mensaje.AutoSize = true;
            this.mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mensaje.Location = new System.Drawing.Point(49, 251);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(94, 20);
            this.mensaje.TabIndex = 120;
            this.mensaje.Text = "lorem ipsum";
            this.mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.Transparent;
            this.aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aceptar.Location = new System.Drawing.Point(45, 190);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(87, 45);
            this.aceptar.TabIndex = 118;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cancelar
            // 
            this.cancelar.BackColor = System.Drawing.Color.Transparent;
            this.cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelar.Location = new System.Drawing.Point(151, 190);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(94, 45);
            this.cancelar.TabIndex = 119;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // lbl_x_nro_operacion
            // 
            this.lbl_x_nro_operacion.AutoSize = true;
            this.lbl_x_nro_operacion.BackColor = System.Drawing.Color.Transparent;
            this.lbl_x_nro_operacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_x_nro_operacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_x_nro_operacion.Location = new System.Drawing.Point(45, 92);
            this.lbl_x_nro_operacion.Name = "lbl_x_nro_operacion";
            this.lbl_x_nro_operacion.Size = new System.Drawing.Size(151, 24);
            this.lbl_x_nro_operacion.TabIndex = 117;
            this.lbl_x_nro_operacion.Text = "N° de Operación";
            // 
            // x_nro_operacion
            // 
            this.x_nro_operacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_nro_operacion.Location = new System.Drawing.Point(45, 122);
            this.x_nro_operacion.MaxLength = 6;
            this.x_nro_operacion.Name = "x_nro_operacion";
            this.x_nro_operacion.Size = new System.Drawing.Size(200, 31);
            this.x_nro_operacion.TabIndex = 116;
            // 
            // ViewFormAnularVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(290, 290);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.lbl_x_nro_operacion);
            this.Controls.Add(this.x_nro_operacion);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewFormAnularVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewFormAnularVenta";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label mensaje;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label lbl_x_nro_operacion;
        private System.Windows.Forms.TextBox x_nro_operacion;
    }
}