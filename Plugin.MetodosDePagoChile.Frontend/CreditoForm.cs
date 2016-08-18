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
using TCPOS.DbHelper;
using System.Collections;
using TCPOS.FrontEnd.UserInterface.Interfaces;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public partial class CreditoForm : Form
    {
        private BLogic BL;
        public CreditoForm()
        {
            InitializeComponent();
        }

        public void SetupForm(BLogic BL)
        {
            this.BL = BL;
            UserInterfaceHelper.CenterWindow(this);
            UserInterfaceHelper.VisibleForms.Add(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ingresoCredito())
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        UserInterfaceHelper.VisibleForms.Remove(this);
            //    }
            //    else
            //    {
            //        this.DialogResult = DialogResult.Cancel;
            //        UserInterfaceHelper.VisibleForms.Remove(this);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Trace.LogException(ex);
            //}
            String all;
            all = "Manual" + "|"; // [0]
            all += txtNumTC.Text + "|"; // [1]
            all += numericCuotas.Value + "|"; // [2]
            all += txtNumOperacion.Text + "|"; // [3]
            all += txtMonto.Text + "|"; // [4]
            all += txtAutorizacion.Text; // [5]

            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
            AddCredito(all);

            if (BL.CurrentTransaction.FoodToPay() == 0 || BL.CurrentTransaction.FoodToPay() < 0) { BL.ProcessTotalKey(); }
            if (BL.CurrentTransaction.FoodToPay() > 0) { BL.RefreshTransactionItems(); }
        }

        public bool ingresoCredito()
        {
            CreditoClass creditoDB = new CreditoClass();

            creditoDB.TransacionId = 1;
            creditoDB.NumeroTC = SafeConvert.ToInt32(txtNumTC.Text);
            creditoDB.TipoTC = "TC";
            creditoDB.Cuotas = SafeConvert.ToInt32(numericCuotas.Value);
            creditoDB.NumeroOperacion = SafeConvert.ToInt32(txtNumOperacion.Text);
            creditoDB.Monto = SafeConvert.ToInt32(txtMonto.Text);
            creditoDB.Autorizacion = SafeConvert.ToInt32(txtAutorizacion.Text);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO bes_credito (transaction_id,num_tc,tipo_tc,cuotas,num_operacion,monto,autorizacion) VALUES ({0},{1},{2},{3},{4},{5},{6})",
                creditoDB.TransacionId,
                creditoDB.NumeroTC,
                SqlHelper.Quote(creditoDB.TipoTC),
                creditoDB.Cuotas,
                creditoDB.NumeroOperacion,
                creditoDB.Monto,
                creditoDB.Autorizacion);

            int num = BL.DB.ExecuteNonQuery(sb.ToString());

            if (num > 0)
            {
                BL.MsgInfo("Se ha Ingresado una Transaccion");
                return true;
            }

            return false;
        }
        public void AddCredito(String all)
        {
            String paymentID = BL.DB.ExecuteScalar("SELECT id  FROM payments WHERE payment_type=3 LIMIT 1").ToString();
            BL.CurrentTransaction.AddPayment(int.Parse(paymentID), 0, 0, SafeConvert.ToDecimal(txtMonto.Text));
            ArrayList payments = BL.CurrentTransaction.GetItems(typeof(TransPayment));
            foreach (TransPayment pay in payments)
            {
                if (pay.Data.Type.ToString() == "CreditCard")
                {
                    if (pay.Data.Notes == "CLP" || pay.Data.Notes == null)
                    {
                        pay.Data.Notes = all;
                    }
                }

            }
        }

        private void setButtonVisibility()
        {
            if ((txtNumTC.Text != string.Empty) && (txtNumOperacion.Text != string.Empty) && (txtMonto.Text != string.Empty) && (txtAutorizacion.Text != string.Empty))
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }

        private void txtNumTC_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void txtNumOperacion_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void txtAutorizacion_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void CreditoForm_Load(object sender, EventArgs e)
        {
            txtMonto.Text = SafeConvert.ToString(BL.CurrentTransaction.FoodToPay());
        }

        private void txtNumTC_Click(object sender, EventArgs e)
        {
            txtNumTC.Text = "";
            KeypadParameters param = new KeypadParameters("Numero Tarjeta de Debito");
            param.DefaultValue = txtNumTC.Text;
            param.MaxLength = 20;

            KeypadResult result;
            if (BL.NumericKeypad(param, out result))
                txtNumTC.Text = result.StringValue;
        }

        private void txtNumOperacion_Click(object sender, EventArgs e)
        {
            KeypadParameters param = new KeypadParameters("Numero Operacion");
            param.DefaultValue = txtNumOperacion.Text;
            param.MaxLength = 20;

            KeypadResult result;
            if (BL.NumericKeypad(param, out result))
                txtNumOperacion.Text = result.StringValue;
        }

        private void txtMonto_Click(object sender, EventArgs e)
        {
            KeypadParameters param = new KeypadParameters("Monto");
            param.DefaultValue = txtMonto.Text;
            param.MaxLength = 20;

            KeypadResult result;
            if (BL.NumericKeypad(param, out result))
                txtMonto.Text = result.StringValue;
        }

        private void txtAutorizacion_Click(object sender, EventArgs e)
        {
            KeypadParameters param = new KeypadParameters("Codigo Autorizacion");
            param.DefaultValue = txtAutorizacion.Text;
            param.MaxLength = 20;

            KeypadResult result;
            if (BL.NumericKeypad(param, out result))
                txtAutorizacion.Text = result.StringValue;
        }
    }
}
