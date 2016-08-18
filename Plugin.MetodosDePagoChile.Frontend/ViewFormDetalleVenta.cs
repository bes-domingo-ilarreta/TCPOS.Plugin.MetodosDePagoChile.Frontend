using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public partial class ViewFormDetalleVenta : Form
    {
        public ViewFormDetalleVenta()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
