/*
Creando la Tabla bes_banks
*/
CREATE TABLE bes_banks (
id                  INTEGER         
						IDENTITY(1,1)
                        CONSTRAINT pk_bes_banks_id
                        PRIMARY KEY
                        CONSTRAINT ck_bes_banks_id
                        CHECK (id > 0),
description			VARCHAR(40)		NOT NULL,
status				NUMERIC(1)      
						CONSTRAINT bit_bes_banks_status
                        CHECK (status IN (0,1))
)
GO

/*
Creando la Tabla trans_bes_cheque
*/
CREATE TABLE trans_bes_cheque (
transaction_id		INTEGER         NOT NULL
						CONSTRAINT fk_trans_bes_cheque_transactions
                        REFERENCES transactions(id)
                        ON DELETE CASCADE,
shop_id				INTEGER			NOT NULL
						CONSTRAINT fk_trans_bes_cheque_shops
						REFERENCES shops(id),
till_id				INTEGER			NOT NULL
						CONSTRAINT fk_trans_bes_cheque_tills
						REFERENCES tills(id),
trans_num			NUMERIC(9)      NOT NULL,
bank_id				INTEGER			NOT NULL
						CONSTRAINT fk_trans_bes_cheque_bes_banks
						REFERENCES bes_banks(id),
rut_cheque			VARCHAR(10)		NOT NULL,
nro_cta_corriente	VARCHAR(15)		NOT NULL,
nro_cheque			VARCHAR(15)		NOT NULL,
monto				NUMERIC(15,3)	NOT NULL,
code_auth			VARCHAR(20)		NOT NULL,
nombre_completo		VARCHAR(50)		NOT NULL,
tasas				NUMERIC(4),
fecha				DATETIME		NOT NULL
)
GO

/*
Creando la Tabla trans_bes_debito_credito
*/

CREATE TABLE trans_bes_debito_credito (
transaction_id		INTEGER         NOT NULL /* ID de la Transacción */
						CONSTRAINT fk_trans_bes_debito_credito_transactions
                        REFERENCES transactions(id)
                        ON DELETE CASCADE,
shop_id				INTEGER			NOT NULL /* ID de la Tienda  */
						CONSTRAINT fk_trans_bes_debito_credito_shops
						REFERENCES shops(id),
till_id				INTEGER			NOT NULL /* ID del Punto de Venta */
						CONSTRAINT fk_trans_bes_debito_credito_tills
						REFERENCES tills(id),
trans_num			NUMERIC(9)      NOT NULL, /* nro.ticket/boleta(20) */
last_digits			NUMERIC(4)      NOT NULL, /* Últimos 4 Digitos de la Tarjeta */
codigo_comercio		NUMERIC(12)     NOT NULL, /* Código de Comercio Transbank */
terminal_id			NUMERIC(8)		NOT NULL, /* Terminal ID Transbank  */
code_auth			NUMERIC(6)		NOT NULL, /* Codigo de Autorización  */
monto				NUMERIC(15,3)	NOT NULL, /* Monto  */
cuotas				NUMERIC(2)		NOT NULL  /* Cuotas  */
					DEFAULT 0,
nro_operacion		NUMERIC(6)		NOT NULL, /* Número de Operación  */
abrev_tipo_tarjeta	VARCHAR(2)		NOT NULL, /* Abreviatura Tipo Tarjeta  */
fecha_contable		DATETIME		NOT NULL, /* Fecha Contable - DB */
abrev_marca_tarjeta VARCHAR(2)		NOT NULL, /* Abreviatura Marca Tarjeta */
fecha				DATETIME		NOT NULL  /* Fecha y Hora Real de la Transacción */
)
GO

/*
Creando la Tabla trans_bes_debito
*/
CREATE TABLE trans_bes_debito(
transaction_id		INTEGER         NOT NULL /* ID de la Transacción */
						CONSTRAINT fk_trans_bes_debito_transactions
                        REFERENCES transactions(id)
                        ON DELETE CASCADE,
shop_id				INTEGER			NOT NULL /* ID de la Tienda  */
						CONSTRAINT fk_trans_bes_debito_shops
						REFERENCES shops(id),
till_id				INTEGER			NOT NULL /* ID del Punto de Venta */
						CONSTRAINT fk_trans_bes_debito_tills
						REFERENCES tills(id),
trans_num			NUMERIC(9)      NOT NULL, /* nro.ticket/boleta(20) */
last_digits			NUMERIC(4)      NOT NULL, /* Últimos 4 Digitos de la Tarjeta */
nro_operacion		NUMERIC(6)		NOT NULL, /* Número de Operación  */
monto				NUMERIC(15,3)	NOT NULL, /* Monto  */
code_auth			NUMERIC(6)		NOT NULL, /* Codigo de Autorización  */
)


/*
Creando la Tabla trans_bes_credito
*/
CREATE TABLE trans_bes_credito(
transaction_id		INTEGER         NOT NULL /* ID de la Transacción */
						CONSTRAINT fk_trans_bes_credito_transactions
                        REFERENCES transactions(id)
                        ON DELETE CASCADE,
shop_id				INTEGER			NOT NULL /* ID de la Tienda  */
						CONSTRAINT fk_trans_bes_credito_shops
						REFERENCES shops(id),
till_id				INTEGER			NOT NULL /* ID del Punto de Venta */
						CONSTRAINT fk_trans_bes_credito_tills
						REFERENCES tills(id),
trans_num			NUMERIC(9)      NOT NULL, /* nro.ticket/boleta(20) */
last_digits			NUMERIC(4)      NOT NULL, /* Últimos 4 Digitos de la Tarjeta */
nro_operacion		NUMERIC(6)		NOT NULL, /* Número de Operación  */
monto				NUMERIC(15,3)	NOT NULL, /* Monto  */
code_auth			NUMERIC(6)		NOT NULL, /* Codigo de Autorización  */
cuotas				NUMERIC(2)		NOT NULL  /* Cuotas  */
)

UPDATE payments SET notes1=null