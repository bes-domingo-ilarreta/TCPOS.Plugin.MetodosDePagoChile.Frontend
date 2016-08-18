using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPOS.FrontEnd.BusinessLogic;

namespace Plugin.MetodosDePagoChile.Frontend
{
    /* ################################## */
    // [DbTable("bes_cheque")]
    /* ################################## */
    internal class TransTableBesCheque : TransItem
    {
        public int shop_id;
        public int till_id;
        public int trans_num;
        public int bank_id;
        public String rut_cheque;
        public String nro_cta_corriente;
        public String nro_cheque;
        public decimal monto;
        public String code_auth;
        public String nombre_completo;
        public decimal tasas;
        public DateTime fecha;
        ///<summary>
        /// Parameterless class constructor, used by the serialization class.
        ///</summary>
        public TransTableBesCheque() { }

        ///<summary>
        /// Class constructor
        ///</summary>
        ///<param name="owner">The item owner, a Transaction object</param>
        ///<param name="cardNumber">The supercard card number</param>
        public TransTableBesCheque(Transaction owner)
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
            writer.WriteStartElement("trans_bes_cheque");
            writer.WriteField("shop_id", shop_id);
            writer.WriteField("till_id", till_id);
            writer.WriteField("trans_num", trans_num);
            writer.WriteField("bank_id", bank_id);
            writer.WriteField("rut_cheque", rut_cheque);
            writer.WriteField("nro_cta_corriente", nro_cta_corriente);
            writer.WriteField("nro_cheque", nro_cheque);
            writer.WriteField("monto", monto);
            writer.WriteField("code_auth", code_auth);
            writer.WriteField("nombre_completo", nombre_completo);
            writer.WriteField("tasas", tasas);
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
