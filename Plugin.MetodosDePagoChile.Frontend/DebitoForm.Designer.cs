namespace Plugin.MetodosDePagoChile.Frontend
{
    partial class DebitoForm
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
            this.txtNumOperacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAutorizacion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtNumTD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumOperacion
            // 
            this.txtNumOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOperacion.Location = new System.Drawing.Point(109, 156);
            this.txtNumOperacion.Name = "txtNumOperacion";
            this.txtNumOperacion.Size = new System.Drawing.Size(282, 38);
            this.txtNumOperacion.TabIndex = 2;
            this.txtNumOperacion.Text = "00087654";
            this.txtNumOperacion.Click += new System.EventHandler(this.txtNumOperacion_Click);
            this.txtNumOperacion.TextChanged += new System.EventHandler(this.txtNumOperacion_TextChanged);
            this.txtNumOperacion.Validated += new System.EventHandler(this.txtNumOperacion_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 31);
            this.label4.TabIndex = 53;
            this.label4.Text = "Numero Operacion";
            // 
            // txtAutorizacion
            // 
            this.txtAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutorizacion.Location = new System.Drawing.Point(109, 306);
            this.txtAutorizacion.Name = "txtAutorizacion";
            this.txtAutorizacion.Size = new System.Drawing.Size(282, 38);
            this.txtAutorizacion.TabIndex = 4;
            this.txtAutorizacion.Text = "1234999";
            this.txtAutorizacion.Click += new System.EventHandler(this.txtAutorizacion_Click);
            this.txtAutorizacion.TextChanged += new System.EventHandler(this.txtAutorizacion_TextChanged);
            this.txtAutorizacion.Validated += new System.EventHandler(this.txtAutorizacion_Validated);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(123, 361);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 83);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(263, 361);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 83);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(109, 231);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(282, 38);
            this.txtMonto.TabIndex = 3;
            this.txtMonto.Text = "5000";
            this.txtMonto.Click += new System.EventHandler(this.txtMonto_Click);
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            this.txtMonto.Validated += new System.EventHandler(this.txtMonto_Validated);
            // 
            // txtNumTD
            // 
            this.txtNumTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumTD.Location = new System.Drawing.Point(109, 81);
            this.txtNumTD.Name = "txtNumTD";
            this.txtNumTD.Size = new System.Drawing.Size(282, 38);
            this.txtNumTD.TabIndex = 1;
            this.txtNumTD.Text = "9876";
            this.txtNumTD.Click += new System.EventHandler(this.txtNumTD_Click);
            this.txtNumTD.TextChanged += new System.EventHandler(this.txtNumTD_TextChanged);
            this.txtNumTD.Validated += new System.EventHandler(this.txtNumTD_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(168, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 31);
            this.label6.TabIndex = 47;
            this.label6.Text = "Autorizacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 31);
            this.label5.TabIndex = 46;
            this.label5.Text = "Monto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 31);
            this.label1.TabIndex = 45;
            this.label1.Text = "4 Ultimos Digitos";
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // DebitoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.txtNumOperacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAutorizacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtNumTD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DebitoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DebitoForm";
            this.Load += new System.EventHandler(this.DebitoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumOperacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAutorizacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtNumTD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider epError;
    }
}