namespace Plugin.MetodosDePagoChile.Frontend
{
    partial class ViewFormManual
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
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnDebito = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCredito
            // 
            this.btnCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredito.Location = new System.Drawing.Point(12, 120);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(120, 83);
            this.btnCredito.TabIndex = 1;
            this.btnCredito.Text = "Crédito";
            this.btnCredito.UseVisualStyleBackColor = true;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // btnDebito
            // 
            this.btnDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebito.Location = new System.Drawing.Point(152, 120);
            this.btnDebito.Name = "btnDebito";
            this.btnDebito.Size = new System.Drawing.Size(120, 83);
            this.btnDebito.TabIndex = 2;
            this.btnDebito.Text = "Débito";
            this.btnDebito.UseVisualStyleBackColor = true;
            this.btnDebito.Click += new System.EventHandler(this.btnDebito_Click);
            // 
            // cancelar
            // 
            this.cancelar.BackColor = System.Drawing.Color.Transparent;
            this.cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelar.Location = new System.Drawing.Point(184, 12);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(94, 45);
            this.cancelar.TabIndex = 3;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // ViewFormManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(290, 327);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.btnDebito);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewFormManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewFormManual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCredito;
        private System.Windows.Forms.Button btnDebito;
        private System.Windows.Forms.Button cancelar;
    }
}