using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPOS.FrontEnd.BusinessLogic.Plugins;
using TCPOS.FrontEnd.BusinessLogic;
using System.Collections;
using Plugin.PosIntegradoCreditoDebitoTransbanks.Frontend;
using System.Drawing;
using TCPOS.FrontEnd.DataClasses;
using TCPOS.Debug;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public class Controller : IPlugin
    {
        private BLogic BL;
        public string transactionID;
        public long variableTID;

        public void Register(TCPOS.FrontEnd.BusinessLogic.BLogic BL, PluginManager PM)
        {
            this.BL = BL;
            PM.OnBeforeKeyPress += PM_OnBeforeKeyPress;
            PM.OnProcessUnknownIniParameter += PM_OnProcessUnknownIniParameter;
            PM.OnBeforeCloseTransaction += PM_OnBeforeCloseTransaction;
            PM.OnBeforeCalculateTransTotal += new BeforeCalculateTransTotalEvent(PM_OnBeforeCalculateTransTotal);
        }

        void PM_OnBeforeCalculateTransTotal(Transaction transaction, ref decimal subtotal, ref bool processed)
        {
            Transaction trans = new Transaction();
            trans = transaction;
            trans.ID.ToString();
            variableTID = transaction.ID;
            processed = false;
        }

        void PM_OnBeforeCloseTransaction(Transaction transaction, ref bool abort)
        {
            // ID de la Till (Caja) --> transaction.TillID.ToString()
            // TransNum de la Caja  --> transaction.TransNum.ToString()
            // ID DE LA Tienda ID --> BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();            

            ArrayList payments = BL.CurrentTransaction.GetItems(typeof(TransPayment));
            foreach (TransPayment pay in payments)
            {
                /*
                    Debitor -> Transbank
                    CreditCard -> Transbank
                    Debitor -> Manual
                    CreditCard -> Manual
                    Cheque -> Manual                                      
                */
                if (pay.Data.Notes != null)
                {
                    string[] misPagos = pay.Data.Notes.Split('|');
                    //BL.MsgInfo(pay.Data.Notes);

                    // Debitor -> Transbank  AND CreditCard -> Transbank
                    if ((pay.Data.Type.ToString() == "Debitor" || pay.Data.Type.ToString() == "CreditCard") && (misPagos[0] == "Transbank"))
                    {
                        // --> 00|cod.Comercio(12)|Terminal.id(8)|nro.ticket/boleta(20)|cod.auth(6)|monto(9)|cuotas(2)|0|ultimos.digitos(4)|nro.operacion(6)|tipo.tarjeta(2)|00-00-00||abrev.marca.tarjeta(2)|fecha.real(8)|hora.real(6)|0|0
                        string[] campo = pay.Data.Notes.Split('|');
                        // shop_id
                        String linea = BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();
                        int shop_id = int.Parse(linea);
                        // till_id
                        int till_id = transaction.TillID;
                        // trans_num
                        int trans_num = transaction.TransNum;
                        // last_digits
                        int last_digits = int.Parse(campo[9]);
                        // codigo_comercio
                        long codigo_comercio = long.Parse(campo[2]);
                        // terminal_id
                        int terminal_id = int.Parse(campo[3]);
                        // code_auth
                        String code_auth = campo[5];
                        // monto
                        decimal monto = decimal.Parse(campo[6]);
                        // cuotas
                        int cuotas = int.Parse(campo[7]);
                        // nro_operacion
                        int nro_operacion = int.Parse(campo[10]);
                        // abrev_tipo_tarjeta
                        String abrev_tipo_tarjeta = campo[11];
                        // fecha_contable                    
                        //DateTime fecha_contable = Convert.ToDateTime(campo[11]);                    
                        // abrev_tipo_tarjeta
                        String abrev_marca_tarjeta = campo[14];
                        // fecha
                        string fecha_real = Methods.fecha(campo[15], '-');
                        string hora_real = Methods.hora(campo[16]);
                        DateTime fecha = Convert.ToDateTime(fecha_real + " " + hora_real + ".000");
                        // 01/08/2008 14:50:50.42

                        // fecha                    
                        //linea = DateTime.Now.ToString("dd") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yyyy");
                        //DateTime fecha = Convert.ToDateTime(linea);                    

                        TransTableBesDebitoCredito BesDebitoCredito = new TransTableBesDebitoCredito(BL.CurrentTransaction);
                        BesDebitoCredito.shop_id = shop_id;
                        BesDebitoCredito.till_id = till_id;
                        BesDebitoCredito.trans_num = trans_num;
                        BesDebitoCredito.last_digits = last_digits;
                        BesDebitoCredito.codigo_comercio = codigo_comercio;
                        BesDebitoCredito.terminal_id = terminal_id;
                        BesDebitoCredito.code_auth = code_auth;
                        BesDebitoCredito.monto = monto;
                        BesDebitoCredito.cuotas = cuotas;
                        BesDebitoCredito.nro_operacion = nro_operacion;
                        BesDebitoCredito.abrev_tipo_tarjeta = abrev_tipo_tarjeta;
                        //BesDebitoCredito.fecha_contable = fecha_contable;
                        BesDebitoCredito.abrev_marca_tarjeta = abrev_marca_tarjeta;
                        BesDebitoCredito.fecha = fecha;
                        BL.CurrentTransaction.AddItem(BesDebitoCredito);

                    }

                    // Debitor -> Manual
                    if ((pay.Data.Type.ToString() == "Debitor") && (misPagos[0] == "Manual"))
                    {
                        // ID DE LA Tienda ID --> BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();                                
                        string[] campo = pay.Data.Notes.Split('|');
                        // shop_id
                        String linea = BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();
                        int shop_id = int.Parse(linea);
                        // till_id
                        int till_id = transaction.TillID;
                        // trans_num
                        int trans_num = transaction.TransNum;
                        // Ultimos 4 Digitos
                        int last_digits = int.Parse(campo[1]);
                        // Numero Operacion
                        int nro_operacion = int.Parse(campo[2]);
                        // monto
                        decimal monto = decimal.Parse(campo[3]);
                        // code_auth
                        int code_auth = int.Parse(campo[4]);

                        TransTableBesDebit BesDebito = new TransTableBesDebit(BL.CurrentTransaction);
                        BesDebito.shop_id = shop_id;
                        BesDebito.till_id = till_id;
                        BesDebito.trans_num = trans_num;
                        BesDebito.last_digits = last_digits;
                        BesDebito.monto = monto;
                        BesDebito.code_auth = code_auth;
                        BesDebito.nro_operacion = nro_operacion;
                        BL.CurrentTransaction.AddItem(BesDebito);
                    }

                    // CreditCard -> Manual
                    if ((pay.Data.Type.ToString() == "CreditCard") && (misPagos[0] == "Manual"))
                    {
                        // ID DE LA Tienda ID --> BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();                                
                        string[] campo = pay.Data.Notes.Split('|');
                        // shop_id
                        String linea = BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();
                        int shop_id = int.Parse(linea);
                        // till_id
                        int till_id = transaction.TillID;
                        // trans_num
                        int trans_num = transaction.TransNum;
                        // Ultimos 4 Digitos
                        int last_digits = int.Parse(campo[1]);
                        // Ultimos 4 Digitos
                        int numCuotas = int.Parse(campo[2]);
                        // Numero Operacion
                        int nro_operacion = int.Parse(campo[3]);
                        // monto
                        decimal monto = decimal.Parse(campo[4]);
                        // code_auth
                        int code_auth = int.Parse(campo[5]);

                        TransTableBesCredit BesCredito = new TransTableBesCredit(BL.CurrentTransaction);
                        BesCredito.shop_id = shop_id;
                        BesCredito.till_id = till_id;
                        BesCredito.trans_num = trans_num;
                        BesCredito.last_digits = last_digits;
                        BesCredito.cuotas = numCuotas;
                        BesCredito.monto = monto;
                        BesCredito.code_auth = code_auth;
                        BesCredito.nro_operacion = nro_operacion;
                        BL.CurrentTransaction.AddItem(BesCredito);
                    }

                    // Cheque -> Manual 
                    if ((pay.Data.Type.ToString() == "Cheque") && (misPagos[0] == "Manual"))
                    {
                        // ID DE LA Tienda ID --> BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();                                
                        string[] campo = pay.Data.Notes.Split('|');
                        // shop_id
                        String linea = BL.DB.ExecuteScalar("SELECT shop_id FROM tills WHERE id=" + transaction.TillID).ToString();
                        int shop_id = int.Parse(linea);
                        // till_id
                        int till_id = transaction.TillID;
                        // trans_num
                        int trans_num = transaction.TransNum;
                        // bank_id
                        int bank_id = int.Parse(campo[1]);
                        // rut_cheque
                        String rut_cheque = campo[2];
                        // nro_cta_corriente
                        String nro_cta_corriente = campo[3];
                        // nro_cheque
                        String nro_cheque = campo[4];
                        // monto
                        decimal monto = decimal.Parse(campo[5]);
                        // code_auth
                        String code_auth = campo[6];
                        // nombre_completo
                        String nombre_completo = campo[7];
                        // tasas
                        decimal tasas = decimal.Parse(campo[8]);
                        // fecha                    
                        //linea = DateTime.Now.ToString("dd") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("yyyy");
                        //DateTime fecha = Convert.ToDateTime(linea);                   
                        DateTime fecha = Convert.ToDateTime(campo[9]);
                        
                        TransTableBesCheque BesCheque = new TransTableBesCheque(BL.CurrentTransaction);
                        BesCheque.shop_id = shop_id;
                        BesCheque.till_id = till_id;
                        BesCheque.trans_num = trans_num;
                        BesCheque.bank_id = bank_id;
                        BesCheque.rut_cheque = rut_cheque;
                        BesCheque.nro_cta_corriente = nro_cta_corriente;
                        BesCheque.nro_cheque = nro_cheque;
                        BesCheque.monto = monto;
                        BesCheque.tasas = tasas;
                        BesCheque.code_auth = code_auth;
                        BesCheque.nombre_completo = nombre_completo;
                        BesCheque.fecha = fecha;
                        BL.CurrentTransaction.AddItem(BesCheque);

                    }
                }
                
            }
        }

        void PM_OnProcessUnknownIniParameter(TCPOS.Utilities.IniValue param, ref bool processed)
        {
            // Obteniendo los valores de TRANSBANK en el archivo "TCPOS.FrontEnd.ini"
            if (param.Name.ToUpper() == "POSTRANSBANK")
            {
                try
                {
                    // Atributos Transbank
                    String PortName, Parity, StopBits, Handshake, atributo;
                    bool RtsEnable, DtrEnable;
                    RtsEnable = true;
                    DtrEnable = true;
                    bool estado = RtsEnable;
                    estado = DtrEnable;

                    int BaudRate, DataBits, ReadTimeout, WriteTimeout;
                    // PortName
                    PortName = param.ValueOf("PortName", "");
                    // BauRate
                    atributo = param.ValueOf("BaudRate", ""); BaudRate = Convert.ToInt32(atributo);
                    // Databits                    
                    atributo = param.ValueOf("DataBits", ""); DataBits = Convert.ToInt32(atributo);
                    // RtsEnable
                    RtsEnable = true; atributo = param.ValueOf("RtsEnable", "").ToUpper(); if (atributo == "FALSE") { RtsEnable = false; }
                    // DtrEnable
                    DtrEnable = true; atributo = param.ValueOf("DtrEnable", "").ToUpper(); if (atributo == "FALSE") { DtrEnable = false; }
                    // ReadTimeout
                    atributo = param.ValueOf("ReadTimeout", ""); ReadTimeout = int.Parse(atributo);
                    // WriteTimeout
                    atributo = param.ValueOf("WriteTimeout", ""); WriteTimeout = int.Parse(atributo);
                    // Parity
                    Parity = param.ValueOf("Parity", "");
                    // StopBits
                    StopBits = param.ValueOf("StopBits", "");
                    // Handshake
                    Handshake = param.ValueOf("Handshake", "");
                }
                catch (Exception ex)
                {
                    param.ErrorDescription = ex.Message;
                    throw (ex);
                }
                processed = true;
            }
            //throw new NotImplementedException();
        }

        

        void PM_OnBeforeKeyPress(KeyData key, ref bool processed)
        {
            // Code 88880 --> Grupo Transbank
            if (key.FunctionCode == 88880)
            {
                // 0 Venta - Débito / Crédito               
                if (key.FunctionParameter == 0)
                {
                    //BL.MsgInfo("0 Venta - Débito / Crédito");
                    using (ViewFormCreditoDebito ViewFormDC = new ViewFormCreditoDebito())
                    {
                        ViewFormDC.SetupForm(BL);
                        ViewFormDC.Focus();
                        ViewFormDC.ShowDialog();
                    }
                    //processed = true;
                }
                // 1 Anulación - Débito / Crédito
                if (key.FunctionParameter == 1)
                {
                    //BL.MsgInfo("1 Anulación - Débito / Crédito");
                    using (ViewFormAnularVenta ViewFormDC = new ViewFormAnularVenta())
                    {
                        ViewFormDC.SetupForm(BL);
                        ViewFormDC.Focus();
                        ViewFormDC.ShowDialog();
                    }
                    /*
                    ViewFormAnularVenta ViewFormAnulacion = new ViewFormAnularVenta();
                    ViewFormAnulacion.Show();
                    */
                }

                // 2 Última Venta
                if (key.FunctionParameter == 2)
                {
                    //BL.MsgInfo("2 Última Venta");
                    BL.MsgInfo(Methods.UltimaVenta());
                }
                // 3 Totales
                if (key.FunctionParameter == 3)
                {
                    //BL.MsgInfo("3 Totales");
                    BL.MsgInfo(Methods.TransaccionTotales());
                }
                // 4 Cierre
                if (key.FunctionParameter == 4)
                {
                    //BL.MsgInfo("4 Cierre");
                    BL.MsgInfo(Methods.TransaccionCierre());
                }
                // 5 Carga Llave
                if (key.FunctionParameter == 5)
                {
                    //BL.MsgInfo("5 Carga Llave");
                    BL.MsgInfo(Methods.TransaccionCargaLlaves());
                }
                // 6 Pooling
                if (key.FunctionParameter == 6)
                {
                    //BL.MsgInfo("6 Pooling");
                    BL.MsgInfo(Methods.Pooling());
                }
                // 7 Cambio a Modo Manual
                if (key.FunctionParameter == 7)
                {
                    //BL.MsgInfo("7 Cambio a Modo Manual");
                    BL.MsgInfo(Methods.CambioModalidadPOSNormal());
                }
                // 8 Detalle Venta
                if (key.FunctionParameter == 8)
                {                

                    ViewFormDetalleVenta ViewFormDV = new ViewFormDetalleVenta();
                    ViewFormDV.Show();
                    ViewFormDV.respuesta.Text = "Cargando...";
                    ViewFormDV.cerrar.BackColor = ColorTranslator.FromHtml("#d74a2b");
                    string TransaccionDetalleVentas = Methods.TransaccionDetalleVentas();

                    string[] linea = TransaccionDetalleVentas.Split('#');
                    string[] ln0 = linea[0].Split('@');
                    string res = "";
                    res = "Total de Transacciones Almacenadas: " + ln0[0] + "\r\n";
                    res += "Monto Total Almacenado: " + ln0[1] + "\r\n";
                    res += "Total Ventas Positivas: " + ln0[2] + "\r\n";
                    res += "Monto Total Ventas Positivas: " + ln0[3] + "\r\n";
                    res += "Ventas Anuladas: " + ln0[4] + "\r\n";
                    res += "Monto Total Ventas Anuladas: " + ln0[5] + "\r\n";
                    res += "Venta(s) Crédito: " + ln0[6] + "\r\n";
                    res += "Monto Venta(s) Crédito: " + ln0[7] + "\r\n";
                    res += "Venta(s) Débito: " + ln0[8] + "\r\n";
                    res += "Monto Venta(s) Débito: " + ln0[9] + "\r\n";
                    ViewFormDV.respuesta.Text = res;

                    string[] transacciones = linea[1].Split('@');

                    for (int i = 0; i < (transacciones.Length - 1); i++)
                    {
                        string[] ln = transacciones[i].Split('|');
                        ViewFormDV.dataGridView1.Rows.Add();
                        ViewFormDV.dataGridView1[0, i].Value = (i + 1).ToString();
                        ViewFormDV.dataGridView1[1, i].Value = ln[0];  // Cod.Comercio
                        ViewFormDV.dataGridView1[2, i].Value = ln[1];  // ID.Terminal
                        //ViewFormDV.dataGridView1[3, i].Value = ln[2];  // Nro.Boleta
                        ViewFormDV.dataGridView1[3, i].Value = ln[3];  // Cod.Auth
                        ViewFormDV.dataGridView1[4, i].Value = ln[4];  // Monto
                        ViewFormDV.dataGridView1[5, i].Value = ln[5];  // Last.4.Digits

                        ViewFormDV.dataGridView1[6, i].Value = ln[7];  // Card.Type
                        ViewFormDV.dataGridView1[7, i].Value = ln[8];  // Abrev.Marca.Tarjeta
                        ViewFormDV.dataGridView1[8, i].Value = ln[9];  // Fecha.Contable
                        ViewFormDV.dataGridView1[9, i].Value = ln[10];// Fecha.Real.Transaccion
                        ViewFormDV.dataGridView1[10, i].Value = ln[6]; // Hora.Real.Transaccion

                    }

                }
                // Transaccion Detalle Ventas desde PinPad - Transbank
                if (key.FunctionParameter == 9)
                {
                    //BL.MsgInfo("9 Transaccion Detalle Ventas desde PinPad - Transbank");
                    BL.MsgInfo(Methods.PrintTransaccionDetalleVentas());
                }
            }

            if (key.FunctionCode == KeyData.KeyPayment)
            {
                /*
                String mostrar = "";                
                mostrar += "Function Code = " + key.FunctionCode.ToString();
                mostrar += " KeyPayment = " + KeyData.KeyPayment.ToString();
                mostrar += " key.FunctionParameter = " + key.FunctionParameter.ToString();
                
                Tipos de Pago
                (payment_id)
                    1 --> Cash
                    2 --> Customer Card
                    3 --> Credit Card
                    4 --> Vouchers
                    5 --> Cheques
                    6 --> Debitor
                    7 --> Subsidy
               */
                // Obtiene el id del Boton Payment
                int PayId = key.FunctionParameter;
                // Obtiene el ID del Tipo de Pago
                String Query;
                Query = BL.DB.ExecuteScalar("SELECT payment_type FROM payments WHERE id=" + PayId + " LIMIT 1").ToString();
                int PaymentType = int.Parse(Query);

                if (PaymentType == 5)
                {
                    using (ViewFormCheque ViewFormCheque = new ViewFormCheque())
                    {
                        ViewFormCheque.SetupForm(BL);
                        ViewFormCheque.Focus();
                        ViewFormCheque.ShowDialog();
                    }
                    processed = true;
                }

                if (PaymentType == 6)
                {
                    //BL.MsgInfo("Debito");
                    try
                    {
                        using (DebitoForm debitoForm = new DebitoForm())
                        {
                            debitoForm.SetupForm(BL);
                            debitoForm.Focus();
                            debitoForm.ShowDialog();
                            
                        }
                        processed = true;
                    }
                    catch (Exception ex)
                    {
                        Trace.LogException(ex);
                        processed = true;
                    }

                }

                if (PaymentType == 3)
                {
                    //BL.MsgInfo("Credito");
                    using (CreditoForm creditoForm = new CreditoForm())
                    {
                        creditoForm.SetupForm(BL);
                        creditoForm.Focus();
                        creditoForm.ShowDialog();                        
                    }
                    processed = true;
                }
            }

            return;
        }
    }
}
