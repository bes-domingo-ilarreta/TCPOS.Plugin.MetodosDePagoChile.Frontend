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

namespace Plugin.MetodosDePagoChile.Frontend
{
    public partial class ViewFormCheque : Form
    {
        private BLogic BL;

        // Variables Cheque              
        public String CampoBanco;
        public long CampoNroCheque;
        public decimal CampoMonto;
        public decimal CampoTasaInteres;
        public String CampoRutCheque;  // 10
        public String CampoNombre;
        public DateTime CampoFechaCheque;
        public long CampoNroCuentaCte;
        public long CampoCodigoAuthCheque;


        public void SetupForm(BLogic BL)
        {
            this.BL = BL;
            UserInterfaceHelper.TranslateForm(this);
            UserInterfaceHelper.CenterWindow(this);
            UserInterfaceHelper.VisibleForms.Add(this);

            DataTable bancos = BL.DB.ExecuteDataTable("SELECT id, description FROM bes_banks WHERE status=0 ORDER BY description");
            int contador = bancos.Rows.Count;
            var dataSource = new List<TestObject>();
            foreach (DataRow banco in bancos.Rows)
            {
                String description = banco["description"].ToString();
                int id = SafeConvert.ToInt32(banco["id"]);
                dataSource.Add(new TestObject() { Name = description, Value = id });
            }
            this.x_banco_cheque.DataSource = dataSource;
            this.x_banco_cheque.DisplayMember = "Name";
            this.x_banco_cheque.ValueMember = "Value";
            this.x_banco_cheque.DropDownStyle = ComboBoxStyle.DropDownList;

            // Dia
            for (int i = 1; i <= 31; i++) { x_dia_cheque.Items.Add(i.ToString()); }
            // Mes
            for (int i = 1; i <= 12; i++) { x_mes_cheque.Items.Add(i.ToString()); }
            // Año
            int anio_actual = int.Parse(DateTime.Now.ToString("yyyy"));
            //for (int i = 2016; i <= 2018; i++) { x_anio_cheque.Items.Add(i.ToString()); }
            for (int i = (anio_actual - 1); i <= (anio_actual + 1); i++) { x_anio_cheque.Items.Add(i.ToString()); }
            // Colores --> Verde: #2a9800 - Rojo: #d74a2b - Naranja: #ffa909
            aceptar.BackColor = ColorTranslator.FromHtml("#2a9800");
            cancelar.BackColor = ColorTranslator.FromHtml("#d74a2b");
            // Valores de Prueba por Defecto                       
            /*
            x_numero_cheque.Text = "0987654";            
            x_tasas_interes.Text = "2";
            rut_cheque.Text = "12345678A";
            x_nombre_completo_cheque.Text = "Domingo José Ilarreta Heydras";            
            nro_cta_corriente.Text = "09876543";
            x_cod_auth_cheque.Text = "098768000000";
            */
            x_dia_cheque.Text = DateTime.Now.ToString("dd");
            x_mes_cheque.Text = DateTime.Now.ToString("MM");
            x_anio_cheque.Text = DateTime.Now.ToString("yyyy");

            x_monto.Text = BL.CurrentTransaction.FoodToPay().ToString();

        }

        public ViewFormCheque()
        {
            InitializeComponent();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            String linea;
            bool valor = true;
            String color_valido = "#FFFFFF";
            String color_invalido = "#d74a2b";

            // 1 Nombre Banco 
            if (x_banco_cheque.Text == "" || x_banco_cheque.Text == null)
            {
                valor = false;
                x_banco_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);
            }
            else
            {
                CampoBanco = x_banco_cheque.SelectedValue.ToString();
                x_banco_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
            }

            if (x_numero_cheque.Text == "" || x_numero_cheque.Text == null)
            {
                valor = false;
                x_numero_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);
            }
            else
            {
                CampoNroCheque = long.Parse(x_numero_cheque.Text);
                x_numero_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
            }
            if (x_monto.Text == "" || x_monto.Text == null)
            {
                valor = false;
                x_monto.BackColor = ColorTranslator.FromHtml(color_invalido);
            }
            else
            {
                CampoMonto = decimal.Parse(x_monto.Text);
                x_monto.BackColor = ColorTranslator.FromHtml(color_valido);
            }
            if (x_tasas_interes.Text == "" || x_tasas_interes.Text == null)
            {
                CampoTasaInteres = 0;
            }
            else
            {
                CampoTasaInteres = decimal.Parse(x_tasas_interes.Text);
            }
            if (rut_cheque.Text == "" || rut_cheque.Text == null)
            {
                valor = false;
                rut_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);
            }
            else
            {
                CampoRutCheque = rut_cheque.Text;
                rut_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
            }
            if (x_nombre_completo_cheque.Text == "" || x_nombre_completo_cheque.Text == null)
            {
                valor = false;
                x_nombre_completo_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);
            }
            else
            {
                CampoNombre = x_nombre_completo_cheque.Text;
                x_nombre_completo_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
            }
            if ((x_dia_cheque.Text == "" || x_dia_cheque.Text == null) || (x_mes_cheque.Text == "" || x_mes_cheque.Text == null) || (x_anio_cheque.Text == "" || x_anio_cheque.Text == null))
            {
                valor = false;
                x_dia_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);
                x_mes_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);
                x_anio_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);

            }
            else
            {
                x_dia_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
                x_mes_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
                x_anio_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
                linea = x_dia_cheque.Text + "-" + x_mes_cheque.Text + "-" + x_anio_cheque.Text;
                CampoFechaCheque = Convert.ToDateTime(linea);
            }
            if (nro_cta_corriente.Text == "" || nro_cta_corriente.Text == null)
            {
                valor = false;
                nro_cta_corriente.BackColor = ColorTranslator.FromHtml(color_invalido);
            }
            else
            {
                CampoNroCuentaCte = long.Parse(nro_cta_corriente.Text);
                nro_cta_corriente.BackColor = ColorTranslator.FromHtml(color_valido);
            }
            if (x_cod_auth_cheque.Text == "" || x_cod_auth_cheque.Text == null)
            {
                valor = false;
                x_cod_auth_cheque.BackColor = ColorTranslator.FromHtml(color_invalido);
            }
            else
            {
                CampoCodigoAuthCheque = long.Parse(x_cod_auth_cheque.Text);
                x_cod_auth_cheque.BackColor = ColorTranslator.FromHtml(color_valido);
            }

            if (valor == true)
            {
                String all;
                all = "Manual" + "|"; // [0]
                all += CampoBanco + "|"; // [1]
                all += CampoRutCheque + "|"; // [2]
                all += CampoNroCuentaCte.ToString() + "|"; // [3]
                all += CampoNroCheque.ToString() + "|"; // [4]
                all += CampoMonto.ToString() + "|"; // [5]
                all += CampoCodigoAuthCheque.ToString() + "|"; // [6]
                all += CampoNombre + "|"; // [7]
                all += CampoTasaInteres.ToString() + "|"; // [8]
                all += CampoFechaCheque.ToString() + ""; // [9]

                //BL.MsgInfo(BL.CurrentTransaction.FoodToPay().ToString());
                // Cerrar Formulario Emergente "Datos Cheque"
                this.DialogResult = DialogResult.OK;
                UserInterfaceHelper.VisibleForms.Remove(this);
                AddCheque(all);

                if (BL.CurrentTransaction.FoodToPay() == 0 || BL.CurrentTransaction.FoodToPay() < 0) { BL.ProcessTotalKey(); }
                if (BL.CurrentTransaction.FoodToPay() > 0) { BL.RefreshTransactionItems(); }
            }
        }

        public void AddCheque(String all)
        {
            // Obtiene el Payment ID -- Cheque (El Payment type Cheque en el Kernel siempre será 5)
            String paymentID = BL.DB.ExecuteScalar("SELECT id  FROM payments WHERE payment_type=5 LIMIT 1").ToString();
            BL.CurrentTransaction.AddPayment(int.Parse(paymentID), 0, 0, SafeConvert.ToDecimal(x_monto.Text));
            ArrayList payments = BL.CurrentTransaction.GetItems(typeof(TransPayment));
            //pay.Data.Notes = payments.Count.ToString();
            foreach (TransPayment pay in payments)
            {
                if (pay.Data.Type.ToString() == "Cheque")
                {
                    if (pay.Data.Notes == "" || pay.Data.Notes == null)
                    {
                        pay.Data.Notes = all;
                        //pay.Data.Description = "PAY Type: " + pay.Data.Type.ToString() + ") " + pay.Data.Description + "\n" + campos[0];
                    }
                }

            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            UserInterfaceHelper.VisibleForms.Remove(this);
        }

        private void nro_cta_corriente_KeyPress(object sender, KeyPressEventArgs e) { Validates.SoloNumeros(e); }
        private void x_numero_cheque_KeyPress(object sender, KeyPressEventArgs e) { Validates.SoloNumeros(e); }
        private void x_cod_auth_cheque_KeyPress(object sender, KeyPressEventArgs e) { Validates.SoloNumeros(e); }
        private void x_nombre_completo_cheque_KeyPress(object sender, KeyPressEventArgs e) { Validates.SoloLetras(e); }
        private void x_monto_KeyPress(object sender, KeyPressEventArgs e) { Validates.SoloNumeros(e); }
        private void x_tasas_interes_KeyPress(object sender, KeyPressEventArgs e) { Validates.SoloNumeros(e); }
        private void x_dia_cheque_KeyPress(object sender, KeyPressEventArgs e) { Validates.DesactivaTeclado(e); }
        private void x_mes_cheque_KeyPress(object sender, KeyPressEventArgs e) { Validates.DesactivaTeclado(e); }
        private void x_anio_cheque_KeyPress(object sender, KeyPressEventArgs e) { Validates.DesactivaTeclado(e); }

    }
}
