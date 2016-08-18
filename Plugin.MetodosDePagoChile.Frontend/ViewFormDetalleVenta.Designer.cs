namespace Plugin.MetodosDePagoChile.Frontend
{
    partial class ViewFormDetalleVenta
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
            this.cerrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_comercio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminal_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_auth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_4_digits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_tarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abrev_marca_tarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_contable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_transaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_transaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respuesta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cerrar
            // 
            this.cerrar.BackColor = System.Drawing.Color.Transparent;
            this.cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cerrar.Location = new System.Drawing.Point(586, 18);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(94, 45);
            this.cerrar.TabIndex = 111;
            this.cerrar.Text = "Cerrar";
            this.cerrar.UseVisualStyleBackColor = false;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nro,
            this.codigo_comercio,
            this.terminal_id,
            this.codigo_auth,
            this.monto,
            this.last_4_digits,
            this.tipo_tarjeta,
            this.abrev_marca_tarjeta,
            this.fecha_contable,
            this.fecha_transaccion,
            this.hora_transaccion});
            this.dataGridView1.Location = new System.Drawing.Point(20, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 150);
            this.dataGridView1.TabIndex = 110;
            // 
            // nro
            // 
            this.nro.HeaderText = "N°";
            this.nro.Name = "nro";
            // 
            // codigo_comercio
            // 
            this.codigo_comercio.HeaderText = "codigo_comercio";
            this.codigo_comercio.Name = "codigo_comercio";
            // 
            // terminal_id
            // 
            this.terminal_id.HeaderText = "terminal_id";
            this.terminal_id.Name = "terminal_id";
            // 
            // codigo_auth
            // 
            this.codigo_auth.HeaderText = "codigo_auth";
            this.codigo_auth.Name = "codigo_auth";
            // 
            // monto
            // 
            this.monto.HeaderText = "monto";
            this.monto.Name = "monto";
            // 
            // last_4_digits
            // 
            this.last_4_digits.HeaderText = "last_4_digits";
            this.last_4_digits.Name = "last_4_digits";
            // 
            // tipo_tarjeta
            // 
            this.tipo_tarjeta.HeaderText = "tipo_tarjeta";
            this.tipo_tarjeta.Name = "tipo_tarjeta";
            // 
            // abrev_marca_tarjeta
            // 
            this.abrev_marca_tarjeta.HeaderText = "abrev_marca_tarjeta";
            this.abrev_marca_tarjeta.Name = "abrev_marca_tarjeta";
            // 
            // fecha_contable
            // 
            this.fecha_contable.HeaderText = "fecha_contable";
            this.fecha_contable.Name = "fecha_contable";
            // 
            // fecha_transaccion
            // 
            this.fecha_transaccion.HeaderText = "fecha_transaccion";
            this.fecha_transaccion.Name = "fecha_transaccion";
            // 
            // hora_transaccion
            // 
            this.hora_transaccion.HeaderText = "hora_transaccion";
            this.hora_transaccion.Name = "hora_transaccion";
            // 
            // respuesta
            // 
            this.respuesta.Location = new System.Drawing.Point(20, 73);
            this.respuesta.Multiline = true;
            this.respuesta.Name = "respuesta";
            this.respuesta.ReadOnly = true;
            this.respuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.respuesta.Size = new System.Drawing.Size(660, 110);
            this.respuesta.TabIndex = 109;
            // 
            // ViewFormDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(700, 370);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.respuesta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewFormDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewFormDetalleVenta";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cerrar;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_comercio;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminal_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_auth;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_4_digits;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_tarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn abrev_marca_tarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_contable;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_transaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_transaccion;
        public System.Windows.Forms.TextBox respuesta;
    }
}