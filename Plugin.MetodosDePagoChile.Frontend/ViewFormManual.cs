using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCPOS.FrontEnd.BusinessLogic;
using TCPOS.FrontEnd.UserInterface;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public partial class ViewFormManual : Form
    {
        private BLogic BL;
        public ViewFormManual()
        {
            InitializeComponent();
        }

        public void SetupForm(BLogic BL)
        {
            this.BL = BL;
            UserInterfaceHelper.CenterWindow(this);
            UserInterfaceHelper.VisibleForms.Add(this);
            // Colores --> Verde: #2a9800 - Rojo: #d74a2b - Naranja: #ffa909            
            cancelar.BackColor = ColorTranslator.FromHtml("#d74a2b");
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {

            using (CreditoForm creditoForm = new CreditoForm())
            {
                creditoForm.SetupForm(BL);
                creditoForm.Focus();
                creditoForm.ShowDialog();

            }

            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }

        private void btnDebito_Click(object sender, EventArgs e)
        {
            using (DebitoForm debitoForm = new DebitoForm())
            {
                debitoForm.SetupForm(BL);
                debitoForm.Focus();
                debitoForm.ShowDialog();

            }

            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
             
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }
    }
}
