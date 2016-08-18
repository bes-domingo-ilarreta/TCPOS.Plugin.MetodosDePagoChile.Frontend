using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPOS.FrontEnd.DataClasses;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public class CreditoClass : LocalDBClassBase
    {
       
        [DbField("transaction_id")]
        public int TransacionId;
        [DbField("num_tc")]
        public int NumeroTC;
        [DbField("tipo_tc")]
        public string TipoTC;
        [DbField("cuotas")]
        public int Cuotas;
        [DbField("num_operacion")]
        public int NumeroOperacion;
        [DbField("monto")]
        public int Monto;
        [DbField("autorizacion")]
        public double Autorizacion;
    }
}
