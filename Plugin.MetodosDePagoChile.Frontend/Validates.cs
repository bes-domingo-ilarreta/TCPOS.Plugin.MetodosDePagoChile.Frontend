using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plugin.MetodosDePagoChile.Frontend
{
    class Validates
    {
        public static void SoloNumeros(KeyPressEventArgs pE)
        {
            if (char.IsDigit(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }




        public static void SoloLetras(KeyPressEventArgs pE)
        {
            if (char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
        }

        public static void DesactivaTeclado(KeyPressEventArgs pE)
        {
            pE.Handled = true;
        }


        public static void SoloNumerosDecimales(KeyPressEventArgs e, String TextValue)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TextValue.Length; i++)
            {
                if (TextValue[i] == '.') { IsDec = true; }
                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 46)
            {
                e.Handled = (IsDec) ? true : false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }

    public class TestObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
