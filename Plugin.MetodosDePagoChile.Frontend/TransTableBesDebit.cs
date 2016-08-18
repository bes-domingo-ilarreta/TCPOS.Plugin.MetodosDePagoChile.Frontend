using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPOS.FrontEnd.BusinessLogic;

namespace Plugin.MetodosDePagoChile.Frontend
{
    internal class TransTableBesDebit : TransItem
    {
        public int shop_id;
        public int till_id;
        public int trans_num;
        public decimal monto;
        public int last_digits;
        public int nro_operacion;
        public int code_auth;
        //public BLogic BL;

        public TransTableBesDebit() { }

        public TransTableBesDebit(Transaction owner)
        {
            BL = owner.BL;
            Owner = owner;
        }
        public override void SerializeToDB(XmlStringWriter writer)
        {
            writer.WriteStartElement("trans_bes_debito");
            writer.WriteField("shop_id", shop_id);
            writer.WriteField("till_id", till_id);
            writer.WriteField("trans_num", trans_num);
            writer.WriteField("last_digits", last_digits);
            writer.WriteField("nro_operacion", nro_operacion);
            writer.WriteField("monto", monto);
            writer.WriteField("code_auth", code_auth);
            writer.WriteEndElement();
            base.SerializeToDB(writer);
        }
    }
}
