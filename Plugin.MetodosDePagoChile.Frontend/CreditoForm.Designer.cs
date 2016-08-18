namespace Plugin.MetodosDePagoChile.Frontend
{
    partial class CreditoForm
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
            this.numericCuotas = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumOperacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAutorizacion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtNumTC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // numericCuotas
            // 
            this.numericCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCuotas.Location = new System.Drawing.Point(204, 189);
            this.numericCuotas.Name = "numericCuotas";
            this.numericCuotas.Size = new System.Drawing.Size(120, 30);
            this.numericCuotas.TabIndex = 2;
            this.numericCuotas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 31);
            this.label3.TabIndex = 69;
            this.label3.Text = "Cuotas";
            // 
            // txtNumOperacion
            // 
            this.txtNumOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOperacion.Location = new System.Drawing.Point(125, 263);
            this.txtNumOperacion.Name = "txtNumOperacion";
            this.txtNumOperacion.Size = new System.Drawing.Size(282, 38);
            this.txtNumOperacion.TabIndex = 3;
            this.txtNumOperacion.Click += new System.EventHandler(this.txtNumOperacion_Click);
            this.txtNumOperacion.TextChanged += new System.EventHandler(this.txtNumOperacion_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(145, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 31);
            this.label4.TabIndex = 67;
            this.label4.Text = "Numero Operacion";
            // 
            // txtAutorizacion
            // 
            this.txtAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutorizacion.Location = new System.Drawing.Point(125, 413);
            this.txtAutorizacion.Name = "txtAutorizacion";
            this.txtAutorizacion.Size = new System.Drawing.Size(282, 38);
            this.txtAutorizacion.TabIndex = 5;
            this.txtAutorizacion.Click += new System.EventHandler(this.txtAutorizacion_Click);
            this.txtAutorizacion.TextChanged += new System.EventHandler(this.txtAutorizacion_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(136, 466);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 83);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(276, 466);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(120, 83);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(125, 338);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(282, 38);
            this.txtMonto.TabIndex = 4;
            this.txtMonto.Click += new System.EventHandler(this.txtMonto_Click);
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // txtNumTC
            // 
            this.txtNumTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumTC.Location = new System.Drawing.Point(204, 114);
            this.txtNumTC.Name = "txtNumTC";
            this.txtNumTC.Size = new System.Drawing.Size(115, 38);
            this.txtNumTC.TabIndex = 1;
            this.txtNumTC.Click += new System.EventHandler(this.txtNumTC_Click);
            this.txtNumTC.TextChanged += new System.EventHandler(this.txtNumTC_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(184, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 31);
            this.label6.TabIndex = 61;
            this.label6.Text = "Autorizacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(222, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 31);
            this.label5.TabIndex = 60;
            this.label5.Text = "Monto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 31);
            this.label1.TabIndex = 59;
            this.label1.Text = "4 Ultimos Digitos";
            // 
            // CreditoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(532, 664);
            this.Controls.Add(this.numericCuotas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumOperacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAutorizacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtNumTC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreditoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreditoForm";
            this.Load += new System.EventHandler(this.CreditoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericCuotas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumOperacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAutorizacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtNumTC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}