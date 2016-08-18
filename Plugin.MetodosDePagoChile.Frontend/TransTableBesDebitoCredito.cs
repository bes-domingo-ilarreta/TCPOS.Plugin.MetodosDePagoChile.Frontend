using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPOS.FrontEnd.BusinessLogic;

namespace Plugin.MetodosDePagoChile.Frontend
{
    /* ################################## */
    // [DbTable("trans_bes_debito_credito")]
    /* ################################## */
    internal class TransTableBesDebitoCredito : TransItem
    {
        public int shop_id;
        public int till_id;
        public int trans_num;
        public int last_digits;
        public long codigo_comercio;
        public int terminal_id;
        public String code_auth;
        public decimal monto;
        public int cuotas;
        public int nro_operacion;
        public String abrev_tipo_tarjeta;
        //public DateTime fecha_contable;
        public String abrev_marca_tarjeta;
        public DateTime fecha;
        ///<summary>
        /// Parameterless class constructor, used by the serialization class.
        ///</summary>
        public TransTableBesDebitoCredito() { }

        ///<summary>
        /// Class constructor
        ///</summary>
        ///<param name="owner">The item owner, a Transaction object</param>
        ///<param name="cardNumber">The supercard card number</param>
        public TransTableBesDebitoCredito(Transaction owner)
        {
            BL = owner.BL;
            Owner = owner;
        }
        /*
         XML
         Los datos son utilizados para almacenar la transacción en la base de datos
         tanto local como central.
        */
        public override void SerializeToDB(XmlStringWriter writer)
        {
            writer.WriteStartElement("trans_bes_debito_credito");
            writer.WriteField("shop_id", shop_id);
            writer.WriteField("till_id", till_id);
            writer.WriteField("trans_num", trans_num);
            writer.WriteField("last_digits", last_digits);
            writer.WriteField("codigo_comercio", codigo_comercio);
            writer.WriteField("terminal_id", terminal_id);
            writer.WriteField("code_auth", code_auth);
            writer.WriteField("monto", monto);
            writer.WriteField("cuotas", cuotas);
            writer.WriteField("nro_operacion", nro_operacion);
            writer.WriteField("abrev_tipo_tarjeta", abrev_tipo_tarjeta);
            //writer.WriteField("fecha_contable", fecha_contable);
            writer.WriteField("abrev_marca_tarjeta", abrev_marca_tarjeta);
            writer.WriteField("fecha", fecha);
            /*
            if (shopMulti != null)
              writer.WriteField("shops_multi_id", shopMulti.ID);
            writer.WriteField("shops_multi_points", shopMultiPoints);
            */
            writer.WriteEndElement();
            base.SerializeToDB(writer);
        }
    }
}
