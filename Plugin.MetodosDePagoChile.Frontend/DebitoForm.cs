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
    public partial class DebitoForm : Form
    {
        private BLogic BL;
        //private string transactionID;
        //private long variableTID;
        
        public DebitoForm()
        {
            InitializeComponent();
        }

        public void SetupForm(BLogic BL)
        {
            this.BL = BL;
            //this.variableTID = variableTID;
            UserInterfaceHelper.CenterWindow(this);
            UserInterfaceHelper.VisibleForms.Add(this);

            txtMonto.Text = SafeConvert.ToString(BL.CurrentTransaction.FoodToPay());
            
        }
        /*
        public bool ingresoDebito()
        {
            DebitoClass debitoDB = new DebitoClass();

            debitoDB.TransacionId = SafeConvert.ToInt32(transactionID);
            debitoDB.TillID = BL.DB.TillCode;
            debitoDB.ShopID = BL.DB.ShopCode;
            debitoDB.TransNum = variableTID;
            debitoDB.NumeroTD = SafeConvert.ToInt32(txtNumTD.Text);
            debitoDB.NumeroOperacion = SafeConvert.ToInt32(txtNumOperacion.Text);
            debitoDB.Monto = SafeConvert.ToInt32(txtMonto.Text);
            debitoDB.Autorizacion = SafeConvert.ToInt32(txtAutorizacion.Text);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO bes_debito (transaction_id,till_id,shop_id,trans_num,num_td,num_operacion,monto,autorizacion) VALUES ({0},{1},{2},{3},{4},{5},{6},{7})",
                debitoDB.TransacionId,
                debitoDB.TillID,
                debitoDB.ShopID,
                debitoDB.TransNum,
                debitoDB.NumeroTD,
                debitoDB.NumeroOperacion,
                debitoDB.Monto,
                debitoDB.Autorizacion);

            int num = BL.DB.ExecuteNonQuery(sb.ToString());
            //BL.DB.InsertRecord(debitoDB);//TRY

            if (num > 0)
            {
                BL.MsgInfo("Se ha Ingresado una Transaccion");
                return true;
            }

            return false;
        }
        */
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String all;
            all = "Manual" + "|"; // [0]
            all += txtNumTD.Text + "|"; // [1]
            all += txtNumOperacion.Text + "|"; // [2]
            all += txtMonto.Text + "|"; // [3]
            all += txtAutorizacion.Text; // [4]

            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
            AddDebito(all);

            if (BL.CurrentTransaction.FoodToPay() == 0 || BL.CurrentTransaction.FoodToPay() < 0) { BL.ProcessTotalKey(); }
            if (BL.CurrentTransaction.FoodToPay() > 0) { BL.RefreshTransactionItems(); }

        }

        public void AddDebito(String all)
        {
            String paymentID = BL.DB.ExecuteScalar("SELECT id  FROM payments WHERE payment_type=6 LIMIT 1").ToString();
            BL.CurrentTransaction.AddPayment(int.Parse(paymentID), 0, 0, SafeConvert.ToDecimal(txtMonto.Text));
            ArrayList payments = BL.CurrentTransaction.GetItems(typeof(TransPayment));
            foreach (TransPayment pay in payments)
            {
                //BL.MsgInfo(pay.Data.Type.ToString());
                if (pay.Data.Type.ToString() == "Debitor")
                {
                    if (pay.Data.Notes == "CLP" || pay.Data.Notes == null)
                    {
                        pay.Data.Notes = all;
                    }
                }

            }
        }

        private void txtNumTD_Click(object sender, EventArgs e)
        {
            txtNumTD.Text = "";
            KeypadParameters param = new KeypadParameters("Numero Tarjeta de Debito");
            param.DefaultValue = txtNumTD.Text;
            param.MaxLength = 20;

            KeypadResult result;
            if (BL.NumericKeypad(param, out result))
                txtNumTD.Text = result.StringValue;
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

        private void setButtonVisibility()
        {
            if ((txtNumTD.Text != string.Empty) && (txtNumOperacion.Text != string.Empty) && (txtMonto.Text != string.Empty) && (txtAutorizacion.Text != string.Empty))
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }

        private void txtNumTD_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void txtNumTD_Validated(object sender, EventArgs e)
        {
            if (txtNumTD.Text.Trim() == "")
            {
                epError.SetError(txtNumTD, "Introduce Numero Tarjeta");
            }
            else
            {
                epError.Clear();
            }
        }

        private void txtNumOperacion_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void txtNumOperacion_Validated(object sender, EventArgs e)
        {
            if (txtNumOperacion.Text.Trim() == "")
            {
                epError.SetError(txtNumOperacion, "Introduce Numero Operacion");
            }
            else
            {
                epError.Clear();
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void txtMonto_Validated(object sender, EventArgs e)
        {
            if (txtMonto.Text.Trim() == "")
            {
                epError.SetError(txtMonto, "Introduce Monto");
            }
            else
            {
                epError.Clear();
            }
        }

        private void txtAutorizacion_TextChanged(object sender, EventArgs e)
        {
            setButtonVisibility();
        }

        private void txtAutorizacion_Validated(object sender, EventArgs e)
        {
            if (txtAutorizacion.Text.Trim() == "")
            {
                epError.SetError(txtAutorizacion, "Introduce Codigo Autorizacion");
            }
            else
            {
                epError.Clear();
            }
        }

        private void DebitoForm_Load(object sender, EventArgs e)
        {
            //txtMonto.Text = SafeConvert.ToString(BL.CurrentTransaction.FoodToPay());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }
    }
}
