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
using Plugin.PosIntegradoCreditoDebitoTransbanks.Frontend;
using TCPOS.DbHelper;
using System.Collections;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public partial class ViewFormCreditoDebito : Form
    {
        private BLogic BL;

        public void SetupForm(BLogic BL)
        {
            this.BL = BL;
            UserInterfaceHelper.TranslateForm(this);
            UserInterfaceHelper.CenterWindow(this);
            UserInterfaceHelper.VisibleForms.Add(this);
            x_monto.Text = BL.CurrentTransaction.FoodToPay().ToString();
            mensaje.Text = "";
            //ticket_boleta.Text = BL.DB.Counters.GetNextTransNum().ToString();                        
            // Colores --> Verde: #2a9800 - Rojo: #d74a2b - Naranja: #ffa909
            aceptar.BackColor = ColorTranslator.FromHtml("#2a9800");
            cancelar.BackColor = ColorTranslator.FromHtml("#d74a2b");
        }

        public ViewFormCreditoDebito()
        {
            InitializeComponent();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            mensaje.Text = "Cargando...";
            string respuesta = Methods.TransaccionVentaCreditoDebito22("", x_monto.Text);
            if (respuesta.Substring(0, 2) == "00") // 00 = Codigo de Respuesta Exitoso en Transbank
            {
                //string[] all = respuesta.Split('|');
                respuesta = "Transbank" + '|' + respuesta;
                AddDebitoCredito(respuesta);
                // --> 00|cod.Comercio(12)|Terminal.id(8)|nro.ticket/boleta(20)|cod.auth(6)|monto(9)|cuotas(2)|0|ultimos.digitos(4)|nro.operacion(6)|tipo.tarjeta(2)|00-00-00||abrev.marca.tarjeta(2)|fecha.real(8)|hora.real(6)|0|0
                if (BL.CurrentTransaction.FoodToPay() == 0 || BL.CurrentTransaction.FoodToPay() < 0) { BL.ProcessTotalKey(); }
                if (BL.CurrentTransaction.FoodToPay() > 0) { BL.RefreshTransactionItems(); }
            }
            else
            {
                BL.MsgInfo(respuesta);

            }
            mensaje.Text = "";
            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            mensaje.Text = "";
            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }
        

        public void AddDebitoCredito(String all)
        {
            string[] datos = all.Split('|');
            string payment_type = "3"; // Por Defecto tiene Payment Type 3 (Credito)
            // [11] Abrev Tipo de Pago (CR = Credito y DB = Debito)
            if (datos[11] == "DB")
            {
                payment_type = "6"; // Cambia al Payment Type 6 (Debito) 
            }

            // Obtiene el Payment ID Credito / Débito
            String paymentID = BL.DB.ExecuteScalar("SELECT id  FROM payments WHERE payment_type=" + payment_type + " LIMIT 1").ToString();
            BL.CurrentTransaction.AddPayment(int.Parse(paymentID), 0, 0, SafeConvert.ToDecimal(x_monto.Text));
            ArrayList payments = BL.CurrentTransaction.GetItems(typeof(TransPayment));
            foreach (TransPayment pay in payments)
            {

                if (pay.Data.Type.ToString() == "Debitor" || pay.Data.Type.ToString() == "CreditCard")
                {
                    if (pay.Data.Notes == "CLP" || pay.Data.Notes == null || pay.Data.Notes == "")
                    {
                        pay.Data.Notes = all;
                    }
                }
            }
        }

        private void monto(object sender, KeyPressEventArgs e)
        {
            Validates.SoloNumeros(e);
        }

        private void pin_pad_integrado_CheckedChanged(object sender, EventArgs e)
        {
            x_monto.Visible = false;
            pictureBox1.Visible = false;
            label2.Visible = false;
            aceptar.Visible = false;
            cancelar.Visible = false;
            pin_pad_integrado.Visible = false;        
            
            using (ViewFormManual ViewFormMN = new ViewFormManual())
            {
                ViewFormMN.SetupForm(BL);
                ViewFormMN.Focus();
                ViewFormMN.ShowDialog();
            }
            

            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }

                
    }
}
