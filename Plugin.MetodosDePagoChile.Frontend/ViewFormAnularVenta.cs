using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCPOS.FrontEnd.UserInterface;
using Plugin.PosIntegradoCreditoDebitoTransbanks.Frontend;
using TCPOS.FrontEnd.BusinessLogic;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public partial class ViewFormAnularVenta : Form
    {
        private BLogic BL;

        public void SetupForm(BLogic BL)
        {
            this.BL = BL;
            UserInterfaceHelper.TranslateForm(this);
            UserInterfaceHelper.CenterWindow(this);
            UserInterfaceHelper.VisibleForms.Add(this);
            x_nro_operacion.Text = "000000";
            mensaje.Text = "";
            // Colores --> Verde: #2a9800 - Rojo: #d74a2b - Naranja: #ffa909
            aceptar.BackColor = ColorTranslator.FromHtml("#2a9800");
            cancelar.BackColor = ColorTranslator.FromHtml("#d74a2b");
        }

        public ViewFormAnularVenta()
        {
            InitializeComponent();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            mensaje.Text = "";
            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (x_nro_operacion.Text == "000000" || x_nro_operacion.Text == "" || x_nro_operacion.Text == null || (x_nro_operacion.Text.Length < 4))
            {
                mensaje.Text = "Valor no válido";

            }
            else
            {
                mensaje.Text = "Continue desde el PinPad...";
                BL.MsgInfo(Methods.TransaccionAnulacionVenta(x_nro_operacion.Text));
                this.DialogResult = DialogResult.OK;
                UserInterfaceHelper.VisibleForms.Remove(this);
            }
        }
    }
}
