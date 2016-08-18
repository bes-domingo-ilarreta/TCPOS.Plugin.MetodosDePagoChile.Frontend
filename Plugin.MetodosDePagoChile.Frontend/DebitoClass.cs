using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPOS.FrontEnd.DataClasses;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public class DebitoClass : LocalDBClassBase
    {
        [DbField("transaction_id")]
        public int TransacionId;
        [DbField("till_id")]
        public int TillID;
        [DbField("shop_id")]
        public int ShopID;
        [DbField("trans_num")]
        public long TransNum;
        [DbField("num_td")]
        public int NumeroTD;
        [DbField("num_operacion")]
        public int NumeroOperacion;
        [DbField("monto")]
        public int Monto;
        [DbField("autorizacion")]
        public double Autorizacion;
    }
}
