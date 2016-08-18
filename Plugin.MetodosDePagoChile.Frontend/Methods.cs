using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Plugin.PosIntegradoCreditoDebitoTransbanks.Frontend
{
    class Methods
    {
        // Atributos Puerto COM  

        public static String ruta = @"C:\TCPOS.NET\FrontEnd\TCPOS.FrontEnd.ini";
        private static string FullIni() { StreamReader param = new StreamReader(ruta); return param.ReadToEnd(); }
        private static string[] FullIniSplit() { return FullIni().Split('\n'); }
        private static int CountIni() { int count = FullIniSplit().Count(); return count; }
        public static string TransbankLine() { string[] lines = FullIniSplit(); string transbankIni = ""; for (int i = 0; i < CountIni(); i++) { if (lines[i].Contains("POSTRANSBANK")) { transbankIni = lines[i]; i = CountIni(); } } return transbankIni; }
        private static string Atributos(string at) { string linea = TransbankLine(); string valor = ""; int subStringInt = at.Length + 1; string[] attrb = linea.Split(' '); int length = attrb.Count(); for (int i = 0; i < length; i++) { if (attrb[i].Contains(at)) { valor = attrb[i].Substring(subStringInt); i = length; } } return valor; }
        public static string _PortName = Atributos("PortName");
        public static int _BaudRate = Convert.ToInt32(Atributos("BaudRate"));
        public static int _DataBits = Convert.ToInt32(Atributos("DataBits"));
        public static string _RtsEnable = Atributos("RtsEnable");
        public static string _DtrEnable = Atributos("DtrEnable");
        public static int _ReadTimeout = Convert.ToInt32(Atributos("ReadTimeout"));
        public static int _WriteTimeout = Convert.ToInt32(Atributos("WriteTimeout"));
        public static string _Parity = Atributos("Parity");
        public static string _StopBits = Atributos("StopBits");
        public static string _Handshake = Atributos("Handshake");
        public static string _repuesta_negativa = "Configuración Incorrecta del POS Integrado:" + "\n" + "\n" + "* Verifique que esté encendido." + "\n" + "* Verifique que esté Conectado al Punto de Venta." + "\n" + "* Verfique que el Nombre del COM sea el correcto." + "\n" + "* Contacte a un Especialista.";
        public static string _puerto_cerrado = "Puerto Cerrado";

        // Atributos para Transbank
        // Inicio
        private static char Stx = (char)2;
        // Cierre
        private static char Etx = (char)3;
        // --> | <--        
        private static char Sep = (char)124;
        // Ack --> - <--
        private static char Ack = (char)6;
        // Nack
        //private static char Nack = (char)21;
        public static SerialPort mySerialPort = new SerialPort();
        public Methods() { }

        public static void Parametros()
        {
            mySerialPort.PortName = _PortName;
            mySerialPort.BaudRate = _BaudRate;
            mySerialPort.DataBits = _DataBits;
            mySerialPort.RtsEnable = true;
            mySerialPort.DtrEnable = true;
            mySerialPort.DiscardNull = false;
            mySerialPort.ReadTimeout = _ReadTimeout;
            mySerialPort.WriteTimeout = _WriteTimeout;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.Handshake = Handshake.None;

        }

        private static void OpenPort() { mySerialPort.Open(); }
        private static void ClosePort() { mySerialPort.Close(); }
        private static string PortsCOM()
        {
            // Respuesta
            string respuesta = "";
            // Obtiene en un Array los Puertos COM Activos
            string[] ports = SerialPort.GetPortNames();
            // Almacena la Cantidad Total de Puertos COM Activos
            int cantidadPuertos = ports.Length;
            if (cantidadPuertos != 0)
            {
                foreach (string port in ports) { respuesta += port + "\n"; }
            }
            else
            {
                respuesta = "No Existen Puerto Activos";
            }
            return respuesta;
        }
        private static bool GetPorts()
        {
            // Retorna el Valor Final
            Parametros();
            bool valida = false;
            // Obtiene en un Array los Puertos COM Activos
            string[] ports = SerialPort.GetPortNames();
            // Almacena la Cantidad Total de Puertos COM Activos
            int cantidadPuertos = ports.Length;
            if (cantidadPuertos != 0)
            {
                foreach (string port in ports)
                {
                    if (port == mySerialPort.PortName) { valida = true; }
                }
            }
            return valida;
        }

        public static char CalculateLRC(string toEncode)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(toEncode);
            byte LRC = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                LRC ^= bytes[i];
            }
            return Convert.ToChar(LRC);
        }

        public static string tarjeta(string abreviacion)
        {
            switch (abreviacion)
            {
                case "VI": abreviacion = "VISA"; break;
                case "MC": abreviacion = "MASTERCARD"; break;
                case "CA": abreviacion = "CABAL"; break;
                case "CR": abreviacion = "CREDENCIAL"; break;
                case "AX": abreviacion = "AMEX"; break;
                case "CE": abreviacion = "CERRADA"; break;
                case "DC": abreviacion = "DINNERS"; break;
                case "TP": abreviacion = "PRESTO"; break;
                case "MG": abreviacion = "MAGNA"; break;
                case "TM": abreviacion = "MAS"; break;
                case "RP": abreviacion = "RIPLEY"; break;
                case "EX": abreviacion = "EXTRA"; break;
                case "TC": abreviacion = "CMR"; break;
                case "DB": abreviacion = "REDCOMPRA"; break;
            }
            return abreviacion;
        }

        public static string fecha(string fecha, char tipo)
        {
            // fecha = DDMMYYYY ---- tipo = (/) ó (-)
            fecha = fecha.Substring(0, 2) + tipo + fecha.Substring(2, 2) + tipo + fecha.Substring(4, 4);
            return fecha;
        }

        public static string hora(string hora)
        {
            // fecha = HHMMSS
            hora = hora.Substring(0, 2) + ":" + hora.Substring(2, 2) + ":" + hora.Substring(4, 2);
            return hora;
        }

        // ########################################################################## //
        // 0100 POOLING();
        // ########################################################################## //
        public static string Pooling()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros del Pooling                
                Parametros();
                string codigo = "0100";
                string lrc = codigo + Sep + Etx;
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Pooling 
                    mySerialPort.Write(comando);
                    // received                     
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    if (received == Ack) { respuesta = "POS Conectado Exitosamente"; } else { respuesta = _repuesta_negativa; }                    
                    ClosePort();
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }

        // ########################################################################## //
        // 0250 ULTIMA VENTA();
        // ########################################################################## //
        public static string UltimaVenta()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros del Pooling              
                Parametros();
                //bool valido = false;
                string lrc, comando;
                // Funcion
                string codigo = "0250";
                // Uniendo los valores para el LRC
                lrc = codigo + Sep + Etx;
                // Creando el LRC con el Metodo CalculateLRC()
                char metodoLRC = Methods.CalculateLRC(lrc);
                // Comando para Solicitar Ultima Venta 
                comando = Stx + codigo + Sep + Etx + metodoLRC;
                // Abriendo el Puerto
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Total de Transacciones                      
                    mySerialPort.Write(comando);
                    // Respuestas
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();
                    while (received != Etx)
                    {
                        received = Convert.ToChar(mySerialPort.ReadChar());
                        respuesta += received.ToString();
                    }
                    received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();
                    mySerialPort.Write(Ack.ToString());
                    ClosePort();

                    string[] linea = respuesta.Split('|');
                    respuesta = "Información de la Última Venta: " + "\r\n" + "\r\n";
                    respuesta += "* Código del Comercio: " + linea[2] + "\r\n";
                    respuesta += "* ID del Terminal: " + linea[3] + "\r\n";
                    respuesta += "* Número de Ticket / Boleta: " + linea[4] + "\r\n";
                    respuesta += "* Código de Autorización: " + linea[5] + "\n";
                    respuesta += "* Monto: " + linea[6] + " CLP" + "\r\n";
                    respuesta += "* Últimos 4 Dígitos Tarjeta: " + linea[9] + "\r\n";
                    respuesta += "* Número de Operación: " + linea[10] + "\r\n";
                    // Tipo de Tarjeta
                    if (linea[11] == "DB")
                    {
                        respuesta += "* Tipo de Tarjeta: Débito" + "\r\n";
                    }
                    else
                    {
                        respuesta += "* Tipo de Tarjeta: Crédito" + "\r\n";
                    }
                    // La Abreviacion es solo para CR (Crédito)
                    if (linea[11] == "CR")
                    {
                        string abreviacion = tarjeta(linea[14]);
                        respuesta += "* Abreviación Marca Tarjeta: " + abreviacion + "\r\n";
                    }
                    respuesta += "* Fecha de la Transacción: " + fecha(linea[15], '-') + "\r\n";
                    respuesta += "* Hora de la Transacción: " + hora(linea[16]) + "\r\n";
                    //respuesta = respuesta + "\n" + "\n";
                    //respuesta += "0) Función: " + linea[0].Substring(2) + "\n";
                    //respuesta += "1) Código Respuesta: " + linea[1] + "\n";
                    //respuesta += "2) Código Comercio: " + linea[2] + "\n";
                    //respuesta += "3) Terminal id: " + linea[3] + "\n";
                    //respuesta += "4) Número de Ticket / Boleta: " + linea[4] + "\n";
                    //respuesta += "5) Código de Autorización: " + linea[5] + "\n";
                    //respuesta += "6) Monto: " + linea[6] + "\n";
                    //respuesta += "7) Últimos 4 Dígitos Tarjeta: " + linea[9] + "\n";
                    //respuesta += "8) Número de Operación: " + linea[10] + "\n";
                    //respuesta += "9) Tipo de Tarjeta: " + linea[11] + "\n";
                    //respuesta += "10) Fecha Contable: ???" + "\n";
                    //respuesta += "11) Número de Cuenta: ???" + "\n";
                    //respuesta += "12) Abreviación Marca Tarjeta: " + linea[14] + "\n";
                    //respuesta += "13) Fecha Real Transacción: " + linea[15] + "\n";
                    //respuesta += "14) Hora Real Transacción: " + linea[16] + "\n";                    
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }

        // ########################################################################## //
        // 0700 TRANSACCIONES TOTALES();
        // ########################################################################## //
        public static string TransaccionTotales()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros del Pooling              
                Parametros();
                //bool valido = false;
                string lrc, comando;
                // Funcion
                string codigo = "0700";
                // Uniendo los valores para el LRC
                lrc = codigo + Sep + Etx;
                // Creando el LRC con el Metodo CalculateLRC()
                char transaccionTotalesLRC = Methods.CalculateLRC(lrc);
                // Comando para Solicitar Ultima Venta 
                comando = Stx + codigo + Sep + Etx + transaccionTotalesLRC;
                // Abriendo el Puerto
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Total de Transacciones                      
                    mySerialPort.Write(comando);
                    // Respuestas
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();
                    while (received != Etx)
                    {
                        received = Convert.ToChar(mySerialPort.ReadChar());
                        respuesta += received.ToString();
                    }
                    received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();
                    mySerialPort.Write(Ack.ToString());
                    ClosePort();

                    string[] linea = respuesta.Split('|');
                    respuesta = "Caché del POS Integrado : " + "\r\n" + "\r\n";
                    respuesta += "* Transacciones Almacenadas   --> " + linea[2] + " Transacciones" + "\r\n";
                    respuesta += "* Monto Total Acumulado         --> " + linea[3].Substring(0, linea[3].Length - 2) + " CLP";
                    //respuesta = respuesta + "\n" + "\n";
                    //respuesta += "0) Función: " + linea[0].Substring(1) + "\n";
                    //respuesta += "1) Código Respuesta: " + linea[1] + "\n";
                    //respuesta += "2) Número de Tx: " + linea[2] + "\n";
                    //respuesta += "3) Totales: " + linea[3].Substring(0, linea[3].Length - 2) + "\n";
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }

        // ########################################################################## //
        // 0800 TRANSACCION CARGA LLAVES();
        // ########################################################################## //
        public static string TransaccionCargaLlaves()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros - Transaccion Carga Llaves
                Parametros();
                string codigo = "0800";
                string lrc = codigo + Sep + Etx;
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Transaccion Carga Llaves 
                    mySerialPort.Write(comando);
                    // received 
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    if (received == Ack)
                    {
                        respuesta += received.ToString();
                        while (received != Etx)
                        {
                            received = Convert.ToChar(mySerialPort.ReadChar());
                            respuesta += received.ToString();
                        }
                        received = Convert.ToChar(mySerialPort.ReadChar());
                        respuesta += received.ToString();
                        mySerialPort.Write(Ack.ToString());

                        string[] linea = respuesta.Split('|');
                        //respuesta = respuesta + "\n" + "\n";                        
                        respuesta = "Información - Transaccion Carga Llaves: " + "\r\n" + "\r\n";
                        if (linea[1] == "00")
                        {
                            respuesta += "* Transaccion Carga Llaves Aprobada" + "\r\n";
                        }
                        respuesta += "* Código del Comercio: " + linea[2] + "\r\n";
                        respuesta += "* ID del Terminal: " + linea[3] + "\r\n";
                        //respuesta += "0) Función: " + linea[0].Substring(1) + "\n";
                        //respuesta += "1) Código Respuesta: " + linea[1] + "\n";
                        //respuesta += "2) Código de Comercio: " + linea[2] + "\n";
                        //respuesta += "3) Terminal id: " + linea[3] + "\n";
                    }
                    else
                    {
                        respuesta = _repuesta_negativa;
                    }
                    ClosePort();
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }

        // ########################################################################## //
        // 0260 TRANSACCION DETALLE VENTAS DESDE PINPAD - TRANSBANK();
        // ########################################################################## //
        public static string PrintTransaccionDetalleVentas()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros del Pooling                
                Parametros();
                string codigo = "0260";
                string DetalleCaja = "0";
                // Uniendo los valores para el LRC                
                string lrc = codigo + Sep + DetalleCaja + Sep + Etx;
                // Creando el LRC con el Metodo CalculateLRC()
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + DetalleCaja + Sep + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Pooling 
                    mySerialPort.Write(comando);
                    // received 
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    if (received == Ack) { respuesta = "La Solicitud fue Enviada al PinPad Transbank"; } else { respuesta = _repuesta_negativa; }
                    mySerialPort.Write(Ack.ToString());
                    ClosePort();
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }

        // ########################################################################## //
        // 0260 TRANSACCION DETALLE VENTAS DESDE PUNTO DE VENTA();
        // ########################################################################## //
        public static string TransaccionDetalleVentas()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros del Pooling                
                Parametros();
                string codigo = "0260";
                string DetalleCaja = "1";
                // Uniendo los valores para el LRC                
                string lrc = codigo + Sep + DetalleCaja + Sep + Etx;
                // Creando el LRC con el Metodo CalculateLRC()
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + DetalleCaja + Sep + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Enviando el Comando 
                    mySerialPort.Write(comando);
                    //String respuesta = "";
                    // Tomando el 1er Char Recibido
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();

                    bool valido = false;
                    List<string> ventas = new List<string>();

                    while (valido == false)
                    {

                        if (received != Etx)
                        {
                            received = Convert.ToChar(mySerialPort.ReadChar());
                            respuesta += received.ToString();
                        }
                        else
                        {
                            received = Convert.ToChar(mySerialPort.ReadChar());
                            respuesta += received.ToString();
                            // Desglozando los valores de finish
                            string[] linea = respuesta.Split('|');
                            //linea[5] = 
                            string cod_auth = linea[5].Replace(" ", "");
                            if (cod_auth != "")
                            {
                                ventas.Add(respuesta);
                                //valido = true;
                                mySerialPort.Write(Ack.ToString());
                                respuesta = "";
                            }
                            else
                            {
                                valido = true;
                                respuesta = "";
                            }
                        }
                    }
                    //respuesta += ventas.Count.ToString() + "\n" + "\n";                    
                    int credito = 0;
                    int debito = 0;
                    int anulaciones = 0;
                    int ventas_positivas = 0;
                    int montoTotal = 0;
                    int montoAnulada = 0;
                    int montoCredito = 0;
                    int montoDebito = 0;
                    //

                    for (int i = 0; i < ventas.Count; i++)
                    {

                        string[] linea = ventas[i].Split('|');
                        montoTotal = montoTotal + int.Parse(linea[6]);
                        if (linea[9] == "CR")
                        {
                            credito++;
                            montoCredito = montoCredito + int.Parse(linea[6]);
                        }
                        else
                        {
                            debito++;
                            montoDebito = montoDebito + int.Parse(linea[6]);
                        }
                        if (int.Parse(linea[6]) < 0) { anulaciones++; montoAnulada = montoAnulada + int.Parse(linea[6]); }
                        if (int.Parse(linea[6]) > 0) { ventas_positivas++; }
                    }
                    //respuesta = "Información - Detalle de Ventas: " + "@";
                    //respuesta += "* Transacciones Almacenadas: " + ventas.Count.ToString() + " - Monto Total: " + montoTotal.ToString() + " CLP" + "\r\n;
                    //respuesta += "* Ventas Positivas: " + ventas_positivas.ToString() + " - Monto: " + montoTotal.ToString() + " CLP" + "\r\n";
                    //respuesta += "* Ventas Anuladas: " + anulaciones.ToString() + " - Monto: " + montoAnulada.ToString() + " CLP" + "\r\n";
                    //respuesta += "* Venta(s) Crédito: " + credito + " - Monto: " + montoCredito.ToString() + " CLP" + "\r\n";
                    //respuesta += "* Venta(s) Débito: " + debito + " - Monto: " + montoDebito.ToString() + " CLP" + "\r\n";   
                    // Total de Transacciones Almacenadas 
                    respuesta = ventas.Count.ToString() + "@";
                    // Monto Total Almacenado
                    respuesta += montoTotal.ToString() + "@";
                    // Total Ventas Positivas
                    respuesta += ventas_positivas.ToString() + "@";
                    // Monto Total Ventas Positivas
                    respuesta += montoTotal.ToString() + "@";
                    // Ventas Anuladas
                    respuesta += anulaciones.ToString() + "@";
                    // Monto Total Ventas Anuladas
                    respuesta += montoAnulada.ToString() + "@";
                    // Venta(s) Crédito
                    respuesta += credito + "@";
                    // Monto Venta(s) Crédito
                    respuesta += montoCredito.ToString() + "@";
                    // Venta(s) Débito
                    respuesta += debito + "@";
                    // Monto Venta(s) Débito
                    respuesta += montoDebito.ToString() + "@";
                    respuesta += "#";



                    for (int i = 0; i < ventas.Count; i++)
                    {
                        //respuesta += ventas[i] + "\n" + "\n";
                        string[] linea = ventas[i].Split('|');
                        //respuesta += "Transaccion " + (i + 1) + ": ";
                        respuesta += linea[2] + "|";
                        respuesta += linea[3] + "|";
                        respuesta += linea[4] + "|";
                        respuesta += linea[5] + "|";
                        respuesta += linea[6] + "|";
                        respuesta += linea[7] + "|";
                        respuesta += linea[14] + "|";
                        respuesta += linea[9] + "|";
                        respuesta += linea[12] + "|";
                        respuesta += linea[10] + "|";
                        respuesta += linea[13] + "@";
                        /*   
                        respuesta += (i + 1) + ") ";
                        respuesta += "Cod.Comercio: " + linea[2] + ";";
                        respuesta += "ID.Terminal: " + linea[3] + ";";
                        respuesta += "Nro.Boleta: " + linea[4] + ";";
                        respuesta += "Cod.Auth: " + linea[5] + ";";
                        respuesta += "Monto: " + linea[6] + ";";
                        respuesta += "Last.4.Digits: " + linea[7] + ";";
                        respuesta += "Nro.operacion: " + linea[14] + ";";
                        respuesta += "Card.Type: " + linea[9] + ";";
                        respuesta += "Abrev.Marca.Tarjeta: " + linea[12] + ";";
                        respuesta += "Fecha.Contable: " + linea[10] + ";";
                        respuesta += "Fecha.Real.Transaccion: " + fecha(linea[13], '-') + "\n";
                        */
                    }
                    mySerialPort.Write(Ack.ToString());
                    ClosePort();

                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;

            /*
            // 0260
            // Estableciendo parametros del Puerto
            Parametros();            
            string lineLRC, comando;
            // Funcion
            string transaccionTotales = "0260";
            string DetalleCaja = "1";
            // Uniendo los valores para el LRC
            lineLRC = transaccionTotales + Sep + DetalleCaja + Sep + Etx;
            // Creando el LRC con el Metodo CalculateLRC()
            char transaccionTotalesLRC = Methods.CalculateLRC(lineLRC);
            // Comando para Solicitar Ultima Venta 
            comando = Stx + transaccionTotales + Sep + DetalleCaja + Sep + Etx + transaccionTotalesLRC;
            // Abriendo el Puerto
            OpenPort();
            // Enviando el Comando 
            mySerialPort.Write(comando);
            String finish = "";
            // Tomando el 1er Char Recibido
            char Respuesta = Convert.ToChar(mySerialPort.ReadChar());            
            finish += Respuesta.ToString();

            bool valido = false;            
            List<string> ventas = new List<string>(); 
           
            while (valido == false)
            {

                if (Respuesta != Etx)
                {
                    Respuesta = Convert.ToChar(mySerialPort.ReadChar());
                    finish += Respuesta.ToString();
                }
                else
                {
                    Respuesta = Convert.ToChar(mySerialPort.ReadChar());
                    finish += Respuesta.ToString();                    
                    // Desglozando los valores de finish
                    string[] linea = finish.Split('|');
                    //linea[5] = 
                    string cod_auth = linea[5].Replace(" ", "");
                    if (cod_auth != "")
                    {
                        ventas.Add(finish);
                        //valido = true;
                        mySerialPort.Write(Ack.ToString());
                        finish = "";
                    }
                    else
                    {
                        valido = true;
                        finish = "";
                    }
                }
            }

            for (int i = 0; i < ventas.Count; i++)
            {
                finish += ventas[i];
            }
            mySerialPort.Write(Ack.ToString());            
            ClosePort();
            return finish;
            */
        }
        // ########################################################################## //
        // 0200 TRANSACCION VENTA CRÉDITO / DEBITO();
        // ########################################################################## //
        public static string TransaccionVentaCreditoDebito22(string nroTicketBoleta, string monto)
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros - Transaccion Venta Crédtio / Débito 
                // Estableciendo parametros del Puerto
                Parametros();
                string codigo = "0200";
                string DetalleCaja = "0";
                string lrc = codigo + Sep + monto + Sep + nroTicketBoleta + Sep + Sep + Sep + DetalleCaja + Etx;
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + monto + Sep + nroTicketBoleta + Sep + Sep + Sep + DetalleCaja + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd - Transaccion Venta Crédtio / Débito 
                    mySerialPort.Write(comando);
                    // received                     
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();
                    string tablaRespuestas = "";
                    tablaRespuestas += received.ToString();
                    bool valido = false;
                    int contador = 0;
                    while (valido == false)
                    {
                        if (received != Etx)
                        {
                            received = Convert.ToChar(mySerialPort.ReadChar());
                            respuesta += received.ToString();

                            if (contador < 8)
                            {
                                tablaRespuestas += received.ToString();
                                contador = contador + 1;
                            }
                            if (tablaRespuestas.Length == 9)
                            {
                                tablaRespuestas = tablaRespuestas.Substring((tablaRespuestas.Length - 2), 2);
                                if (tablaRespuestas == "24") { valido = true; } // Sin Papel en el POS
                                if (tablaRespuestas == "07") { valido = true; } // Transacción Cancelada desde el POS
                                if (tablaRespuestas == "01") { valido = true; } // Rechazado
                                if (tablaRespuestas == "30") { valido = true; } // Rechazado
                                if (tablaRespuestas == "09") { valido = true; } // Error Lectura Tarjeta
                                if (tablaRespuestas == "14") { valido = true; } // Menu Inválido
                                if (tablaRespuestas == "33") { valido = true; } // Rechazado
                                if (tablaRespuestas == "18") { valido = true; } // Tarjeta Inválida
                                if (tablaRespuestas == "17") { valido = true; } // Error 17
                                if (tablaRespuestas == "03") { valido = true; } // Fallo en la Conexión
                                if (tablaRespuestas == "91") { valido = true; } // 91 Cambie clave ATM
                                if (tablaRespuestas == "22") { valido = true; } // Error 22


                            }
                        }
                        else
                        {
                            received = Convert.ToChar(mySerialPort.ReadChar());
                            respuesta += received.ToString();
                            // '\''                            
                            respuesta = respuesta.Substring(7);
                            respuesta = respuesta.Remove(respuesta.Length - 3);
                            valido = true;
                        }
                    }

                    mySerialPort.Write(Ack.ToString());
                    ClosePort();
                    if (tablaRespuestas == "24") { respuesta = "El POS Integrado No tiene Papel \n No se puede continuar con la operación"; }
                    if (tablaRespuestas == "07") { respuesta = "Transacción Cancelada desde el POS"; }
                    //if (tablaRespuestas == "00") { respuesta = "Respuesta: 00" + "\n" + "Aprobado" + "\n" + respuesta; }
                    if (tablaRespuestas == "09") { respuesta = "Error Lectura Tarjeta"; }
                    if (tablaRespuestas == "14") { respuesta = "Menu Inválido"; }
                    if (tablaRespuestas == "01") { respuesta = "Rechazado"; }
                    if (tablaRespuestas == "30") { respuesta = "Rechazado"; }
                    if (tablaRespuestas == "33") { respuesta = "Rechazado"; }
                    if (tablaRespuestas == "18") { respuesta = "Tarjeta Inválida"; }
                    if (tablaRespuestas == "17") { respuesta = "Error - Intente Nuevamente"; }
                    if (tablaRespuestas == "03") { respuesta = "Fallo en la Conexión"; }
                    if (tablaRespuestas == "91") { respuesta = "Cambie clave ATM"; }
                    if (tablaRespuestas == "22") { respuesta = "Error - Intente Nuevamente"; }

                    /*
                    if (received == Ack) { respuesta = "POS Conectado Exitosamente"; } else { respuesta = _repuesta_negativa; }
                    ClosePort();
                    */
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }
        // ########################################################################## //
        // TRANSACCION VENTA CRÉDITO / DEBITO();
        // ########################################################################## //
        public static string TransaccionVentaCreditoDebito(string nroTicketBoleta, string monto)
        {
            // 0260
            // Estableciendo parametros del Puerto
            Parametros();
            string lineLRC, comando;
            // Funcion
            string TransaccionVentaCreditoDebito = "0200";
            string DetalleCaja = "0";
            // Uniendo los valores para el LRC
            lineLRC = TransaccionVentaCreditoDebito + Sep + monto + Sep + nroTicketBoleta + Sep + Sep + Sep + DetalleCaja + Etx;
            // Creando el LRC con el Metodo CalculateLRC()
            char TransaccionVentaCreditoDebitoLRC = Methods.CalculateLRC(lineLRC);
            // Comando para Solicitar Transacción Crédito - Débito 
            comando = Stx + TransaccionVentaCreditoDebito + Sep + monto + Sep + nroTicketBoleta + Sep + Sep + Sep + DetalleCaja + Etx + TransaccionVentaCreditoDebitoLRC;
            /* Mensajes Intermedios */
            string lrc = "";
            // Lectura de Tarjeta
            // --> 78
            lrc = "0900" + Sep + "78" + Etx; char lrc_lectura_tarjeta = Methods.CalculateLRC(lrc); string c_lectura_tarjeta = Stx + "0900" + Sep + "78" + Etx + lrc_lectura_tarjeta;
            // Confirmación de Monto
            // --> 80
            lrc = "0900" + Sep + "80" + Etx; char lrc_confirmacion_monto = Methods.CalculateLRC(lrc); string c_confirmacion_monto = Stx + "0900" + Sep + "80" + Etx + lrc_confirmacion_monto;
            // Selección de Cuotas
            // --> 79
            lrc = "0900" + Sep + "79" + Etx; char lrc_selecccion_cuotas = Methods.CalculateLRC(lrc); string c_selecccion_cuotas = Stx + "0900" + Sep + "79" + Etx + lrc_selecccion_cuotas;
            // Ingreso de Pinpass
            // --> 81
            lrc = "0900" + Sep + "81" + Etx; char lrc_ingreso_pinpass = Methods.CalculateLRC(lrc); string c_ingreso_pinpass = Stx + "0900" + Sep + "81" + Etx + lrc_ingreso_pinpass;
            // Envío de Tx a Transbank
            // --> 82
            lrc = "0900" + Sep + "82" + Etx; char lrc_tx_transbank = Methods.CalculateLRC(lrc); string c_tx_transbank = Stx + "0900" + Sep + "82" + Etx + lrc_tx_transbank;
            // Abriendo el Puerto
            OpenPort();
            // Enviando el Comando 
            mySerialPort.Write(comando);
            //mySerialPort.Write(Ack.ToString());
            //mySerialPort.Write(c_lectura_tarjeta);
            string finish = "";
            string tablaRespuestas = "";
            // Tomando el 1er Char Recibido
            char Respuesta = Convert.ToChar(mySerialPort.ReadChar());
            finish += Respuesta.ToString();
            tablaRespuestas += Respuesta.ToString();
            bool valido = false;
            int contador = 0;
            while (valido == false)
            {
                if (Respuesta != Etx)
                {
                    Respuesta = Convert.ToChar(mySerialPort.ReadChar());
                    finish += Respuesta.ToString();

                    if (contador < 8)
                    {
                        tablaRespuestas += Respuesta.ToString();
                        contador = contador + 1;
                    }
                    if (tablaRespuestas.Length == 9)
                    {
                        tablaRespuestas = tablaRespuestas.Substring((tablaRespuestas.Length - 2), 2);
                        if (tablaRespuestas == "24") { valido = true; } // Sin Papel en el POS
                        if (tablaRespuestas == "07") { valido = true; } // Transacción Cancelada desde el POS
                        if (tablaRespuestas == "01") { valido = true; } // Rechazado
                        if (tablaRespuestas == "09") { valido = true; } // Error Lectura Tarjeta
                        if (tablaRespuestas == "14") { valido = true; } // Menu Inválido
                        if (tablaRespuestas == "33") { valido = true; } // Rechazado
                        if (tablaRespuestas == "18") { valido = true; } // Tarjeta Inválida
                        if (tablaRespuestas == "17") { valido = true; } // Error 17
                    }
                }
                else
                {
                    Respuesta = Convert.ToChar(mySerialPort.ReadChar());
                    finish += Respuesta.ToString();
                    valido = true;
                }
            }

            mySerialPort.Write(Ack.ToString());
            ClosePort();
            if (tablaRespuestas == "24") { finish = "Respuesta: 24" + "\n" + "El POS Integrado No tiene Papel \n No se puede continuar con la operación"; }
            if (tablaRespuestas == "07") { finish = "Respuesta: 07" + "\n" + "Transacción Cancelada desde el POS"; }
            if (tablaRespuestas == "00") { finish = "Respuesta: 00" + "\n" + "Aprobado" + "\n" + finish; }
            if (tablaRespuestas == "09") { finish = "Respuesta: 09" + "\n" + "Error Lectura Tarjeta"; }
            if (tablaRespuestas == "14") { finish = "Respuesta: 14" + "\n" + "Menu Inválido (?)"; }
            if (tablaRespuestas == "01") { finish = "Respuesta: 01" + "\n" + "Rechazado"; }
            if (tablaRespuestas == "33") { finish = "Respuesta: 33" + "\n" + "Rechazado (?)"; }
            if (tablaRespuestas == "18") { finish = "Respuesta: 18" + "\n" + "Tarjeta Inválida"; }
            if (tablaRespuestas == "17") { finish = "Respuesta: 17" + "\n" + "Error 17"; }

            return finish;
        }

        // ########################################################################## //
        // 0300 CAMBIO MODALIDAD POS NORMAL();
        // ########################################################################## //
        public static string CambioModalidadPOSNormal()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros - Cambio Modalidad POS Normal                
                Parametros();
                string codigo = "0300";
                string lrc = codigo + Sep + Etx;
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Cambio Modalidad POS Normal  
                    mySerialPort.Write(comando);
                    // received 
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    if (received == Ack) { respuesta = "Cambio de Modalidad POS Normal:" + "\r\n" + "\r\n" + "Desactivando POS Integrado..." + "\r\n" + "* El Cambio de Modalidad ha sido exitoso." + "\r\n" + "\r\n" + "Para Activar Nuevamente el POS Integrado Transbank:" + "\r\n" + "\r\n" + "* Presione F2 > F3 > Botón Verde ó Enter > F1 > F1"; } else { respuesta = _repuesta_negativa; }
                    ClosePort();
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }

        // ########################################################################## //
        // 1200 TRANSACCION ANULACION VENTA();
        // ########################################################################## //
        public static string TransaccionAnulacionVenta(string nro_operacion)
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros - Transaccion Anulación Venta
                Parametros();
                string codigo = "1200";
                //string nro_operacion = "000132";
                string lrc = codigo + Sep + nro_operacion + Sep + Etx;
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + nro_operacion + Sep + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Transaccion Anulación Venta 
                    mySerialPort.Write(comando);
                    // received 
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();
                    while (received != Etx)
                    {
                        received = Convert.ToChar(mySerialPort.ReadChar());
                        respuesta += received.ToString();
                    }
                    received = Convert.ToChar(mySerialPort.ReadChar());
                    respuesta += received.ToString();
                    mySerialPort.Write(Ack.ToString());
                    ClosePort();
                    /*
                    if (received == Ack) { respuesta = "POS Conectado Exitosamente"; } else { respuesta = _repuesta_negativa; }
                    ClosePort();
                    */
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            string tablaRespuestas = respuesta.Substring(7, 2); // 00 // 05 // 07 ...
            if (tablaRespuestas == "24") { respuesta = "El POS Integrado No tiene Papel \n No se puede continuar con la operación"; }
            if (tablaRespuestas == "07") { respuesta = "Transacción Cancelada desde el POS"; }
            if (tablaRespuestas == "05") { respuesta = "No existe transaccion para anular"; }
            if (tablaRespuestas == "09") { respuesta = "Error Lectura Tarjeta"; }
            if (tablaRespuestas == "14") { respuesta = "Menu Inválido"; }
            if (tablaRespuestas == "01") { respuesta = "Rechazado"; }
            if (tablaRespuestas == "30") { respuesta = "Rechazado"; }
            if (tablaRespuestas == "33") { respuesta = "Rechazado"; }
            if (tablaRespuestas == "18") { respuesta = "Tarjeta Inválida"; }
            if (tablaRespuestas == "17") { respuesta = "Error - Intente Nuevamente"; } // Ultimos 4 digitos
            if (tablaRespuestas == "21") { respuesta = "Error - Intente Nuevamente"; } // ??
            if (tablaRespuestas == "03") { respuesta = "Fallo en la Conexión"; }
            if (tablaRespuestas == "91") { respuesta = "Cambie clave ATM"; }
            if (tablaRespuestas == "00")
            {
                string[] linea = respuesta.Split('|');
                // respuesta = "Anulacion Realizada Exitosamente" + "\n" + "\n" + respuesta;
                respuesta = "Anulacion Realizada Exitosamente" + "\n" + "\n";
                respuesta += "* Código del Comercio: " + linea[2] + "\r\n";
                respuesta += "* ID del Terminal: " + linea[3] + "\r\n";
                respuesta += "* Código de Autorización: " + linea[4] + "\r\n";
                respuesta += "* N° de Operación: " + (linea[5].Remove(linea[5].Length - 2)) + "\r\n";
            }

            return respuesta;
        }


        // ########################################################################## //
        // 0800 TRANSACCION CARGA LLAVES();
        // ########################################################################## //
        public static string TransaccionCierre()
        {
            // Respuesta del Método
            string respuesta = "";
            // Valida que el Puerto COM del POS Integrado está Conectado
            if (GetPorts() == true)
            {
                // Parámetros - Transaccion Carga Llaves
                Parametros();
                string codigo = "0500";
                string lrc = codigo + Sep + Etx;
                char transform_lrc = Methods.CalculateLRC(lrc);
                string comando = Stx + codigo + Sep + Etx + transform_lrc;
                OpenPort();
                if (mySerialPort.IsOpen)
                {
                    // Solicitd Transaccion Carga Llaves 
                    mySerialPort.Write(comando);
                    // received 
                    char received = Convert.ToChar(mySerialPort.ReadChar());
                    if (received == Ack)
                    {
                        respuesta += received.ToString();
                        while (received != Etx)
                        {
                            received = Convert.ToChar(mySerialPort.ReadChar());
                            respuesta += received.ToString();
                        }
                        received = Convert.ToChar(mySerialPort.ReadChar());
                        respuesta += received.ToString();
                        mySerialPort.Write(Ack.ToString());

                        string[] linea = respuesta.Split('|');
                        //respuesta = respuesta + "\n" + "\n";                        
                        respuesta = "Información - Cierre: " + "\r\n" + "\r\n";
                        if (linea[1] == "00")
                        {
                            respuesta += "* Cierre Realizado Exitosamente" + "\r\n";
                        }
                        respuesta += "* Código del Comercio: " + linea[2] + "\r\n";
                        respuesta += "* ID del Terminal: " + linea[3] + "\r\n";
                        //respuesta += "0) Función: " + linea[0].Substring(1) + "\n";
                        //respuesta += "1) Código Respuesta: " + linea[1] + "\n";
                        //respuesta += "2) Código de Comercio: " + linea[2] + "\n";
                        //respuesta += "3) Terminal id: " + linea[3] + "\n";
                    }
                    else
                    {
                        respuesta = _repuesta_negativa;
                    }
                    ClosePort();
                }
                else
                {
                    respuesta = _puerto_cerrado;
                }
            }
            else
            {
                respuesta = _repuesta_negativa;
            }
            return respuesta;
        }


        public static string Full()
        {
            String pooling = Pooling();
            String pooling2 = Pooling();
            String ultimaVenta = UltimaVenta();
            String ultimaVenta2 = UltimaVenta();
            //String transaccionTotales = TransaccionTotales();
            //String transaccionCargaLlaves = TransaccionCargaLlaves();
            String mensaje = "";
            mensaje = "Pooling()" + "\n" + pooling + "\n";
            mensaje += "Pooling() 2" + "\n" + pooling2 + "\n";
            mensaje += "UltimaVenta()" + "\n" + ultimaVenta + "\n";
            mensaje += "UltimaVenta() 2" + "\n" + ultimaVenta2 + "\n";
            //mensaje += "TransaccionTotales()" + "\n" + transaccionTotales + "\n";
            //mensaje += "TransaccionCargaLlaves()" + "\n" + transaccionCargaLlaves + "\n";

            return mensaje;
        }


    }
}
