using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPOS.FrontEnd.DataClasses;

namespace Plugin.MetodosDePagoChile.Frontend
{
    public class TipoPagoCheque : LocalDBClassBase
    {
        /* ################################## */
        // [DbTable("bes_cheque")]
        /* ################################## */
        [DbField("shop_id")]
        public int shop_id;
        [DbField("till_id")]
        public int till_id;
        [DbField("trans_num")]
        public int trans_num;
        [DbField("bank_id")]
        public int bank_id;
        [DbField("rut_cheque")]
        public String rut_cheque;
        [DbField("nro_cta_corriente")]
        public String nro_cta_corriente;
        [DbField("nro_cheque")]
        public String nro_cheque;
        [DbField("monto")]
        public decimal monto;
        [DbField("code_auth")]
        public String code_auth;
        [DbField("nombre_completo")]
        public String nombre_completo;
        [DbField("tasas")]
        public decimal tasas;
        [DbField("fecha")]
        public DateTime fecha;
    }
    public class BesBanks : LocalDBClassBase
    {
        /* ################################## */
        // [DbTable("bes_banks")]
        /* ################################## */
        [DbField("id")]
        public int id;
        [DbField("description")]
        public String description;
        [DbField("status")]
        public int status;
    }
}
