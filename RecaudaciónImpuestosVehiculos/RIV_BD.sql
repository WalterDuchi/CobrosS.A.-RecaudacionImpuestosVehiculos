--EJECUTAR PRIMERO
CREATE DATABASE RIV_BD;


-- Creaci�n de la tabla Persona
use RIV_BD;
CREATE TABLE Persona (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Nombres NVARCHAR(100),
    Apellidos NVARCHAR(100),
    Correo_Electronico NVARCHAR(100),
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(200),
    DNI NVARCHAR(10) UNIQUE,--Cedula unica
    Mes_Pago INT
);

-- Creaci�n de la tabla Vehiculo
CREATE TABLE Vehiculo (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Valor DECIMAL(10,2), --10000
    A�o INT, --2024
    Cilindrada INT, --1500 
    Modelo NVARCHAR(50), -- HYNDAI ACCENT SPORT EDITION
	Placa NVARCHAR(8) UNIQUE, -- AAC0123 (Placa unica)
	id_persona INT FOREIGN KEY REFERENCES Persona(id)
);

-- Creaci�n de la tabla Deuda
CREATE TABLE Deuda (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha_Convocatoria DATE,--se coloca en el dia 1 del mes correspondiente al id y en el a�o actual
    Fecha_pago DATE, --si es null no se ah pagado, si tiene fecha es porque ya se pag�.
	Impuesto DECIMAL(10,2),
    Recargo DECIMAL(10,2),
    Total AS Impuesto + Recargo,
    id_persona INT FOREIGN KEY REFERENCES Persona(id),
    id_vehiculo INT FOREIGN KEY REFERENCES Vehiculo(id)
);

-- Creaci�n de la tabla Pago
CREATE TABLE Pago (
    id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo INT, -- 1 es Ventanilla, 2 es Deposito Bancario(Domiciliado)
    Fecha_pago DATE,
    id_deuda INT FOREIGN KEY REFERENCES Deuda(id)
);








--EJECUTAR SEGUNDO
-- Creaci�n del disparador para actualizar la fecha de pago en la tabla Deuda
CREATE TRIGGER ActualizarFechaPago
ON Pago
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @id_deuda INT;
    DECLARE @Fecha_pago DATE;
    -- Obtener los valores de la fila reci�n insertada en la tabla Pago
    SELECT @id_deuda = inserted.id_deuda, @Fecha_pago = inserted.Fecha_pago
    FROM inserted;
    -- Actualizar la fecha de pago en la tabla Deuda
    UPDATE Deuda SET Fecha_pago = @Fecha_pago WHERE id = @id_deuda;
END;








--EJECUTAR TERCERO
-- Calcula el mes de pago basado en la primera letra del apellido
CREATE PROCEDURE InsertarPersona
    @Nombres NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @Correo_Electronico NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Direccion NVARCHAR(200),
    @DNI NVARCHAR(10)
AS
BEGIN
    -- Calcula el mes de pago basado en la primera letra del apellido
    DECLARE @Mes_Pago INT;
    SET @Mes_Pago = CASE 
        WHEN LEFT(@Apellidos, 1) IN ('a', 'b') THEN 1
        WHEN LEFT(@Apellidos, 1) IN ('c', 'd') THEN 2
        WHEN LEFT(@Apellidos, 1) IN ('e', 'f') THEN 3
        WHEN LEFT(@Apellidos, 1) IN ('g', 'h') THEN 4
        WHEN LEFT(@Apellidos, 1) IN ('i', 'j') THEN 5
        WHEN LEFT(@Apellidos, 1) IN ('k', 'l') THEN 6
        WHEN LEFT(@Apellidos, 1) IN ('m', 'n') THEN 7
        WHEN LEFT(@Apellidos, 1) IN ('�', 'o') THEN 8
        WHEN LEFT(@Apellidos, 1) IN ('p', 'q') THEN 9
        WHEN LEFT(@Apellidos, 1) IN ('r', 's', 't') THEN 10
        WHEN LEFT(@Apellidos, 1) IN ('u', 'v', 'w') THEN 11
        WHEN LEFT(@Apellidos, 1) IN ('x', 'y', 'z') THEN 12
    END;
    -- Inserta la nueva persona en la tabla Persona
    INSERT INTO Persona (Nombres, Apellidos, Correo_Electronico, Telefono, Direccion, DNI, Mes_Pago)
    VALUES (@Nombres, @Apellidos, @Correo_Electronico, @Telefono, @Direccion, @DNI, @Mes_Pago);
END;








--EJECUTAR CUARTO
CREATE PROCEDURE CalcularPagoDeuda
    @id_persona INT,
    @id_vehiculo INT
AS
BEGIN
    -- Obtener informaci�n del veh�culo y su propietario
    DECLARE @Valor_Vehiculo DECIMAL(10,2);
    DECLARE @A�o_Vehiculo INT;
    DECLARE @Cilindrada_Vehiculo INT;
    SELECT @Valor_Vehiculo = Valor, @A�o_Vehiculo = A�o, @Cilindrada_Vehiculo = Cilindrada
    FROM Vehiculo
    WHERE id = @id_vehiculo;
    -- Obtener el mes de pago del propietario
    DECLARE @Mes_Pago INT;
    SELECT @Mes_Pago = Mes_Pago
    FROM Persona
    WHERE id = @id_persona;
    -- Obtener la fecha actual
    DECLARE @FechaHoy DATE = GETDATE();
    -- Calcular la fecha de convocatoria
    DECLARE @Fecha_Convocatoria DATE = CONVERT(DATE, '01/' + CAST(@Mes_Pago AS NVARCHAR(2)) + '/' + CAST(YEAR(@FechaHoy) AS NVARCHAR(4)), 103);
    -- Calcular el impuesto (ajustado para generar valores m�s peque�os)
    DECLARE @Impuesto DECIMAL(10,2);
    SET @Impuesto = ((@Valor_Vehiculo * 0.001) + (@A�o_Vehiculo / 20) + (@Cilindrada_Vehiculo / 400));
    -- Calcular el a�o de atraso
    DECLARE @A�o_de_atraso INT;
    SET @A�o_de_atraso = DATEDIFF(YEAR, @Fecha_Convocatoria, @FechaHoy);
    -- Calcular el recargo (ajustado para generar valores m�s peque�os)
    DECLARE @Recargo DECIMAL(10,2);
    SET @Recargo = (POWER((@Impuesto * 0.2), POWER(@A�o_de_atraso, 1/2.0)))-1;
    -- Calcular el total
    DECLARE @Total DECIMAL(10,2);
    SET @Total = @Impuesto + @Recargo;
    -- Insertar la nueva deuda sin incluir la columna Total
    INSERT INTO Deuda (Fecha_Convocatoria, Impuesto, Recargo, id_persona, id_vehiculo)
    VALUES (@Fecha_Convocatoria, @Impuesto, @Recargo, @id_persona, @id_vehiculo);
END;
















-- Creaci�n del procedimiento almacenado
CREATE PROCEDURE ObtenerInformacionPago
    @id_pago INT
AS
BEGIN
    -- Obtener informaci�n de la deuda asociada al id_pago
    SELECT
        D.id AS id_deuda,
        P.Nombres,
        P.Apellidos,
        P.Correo_Electronico,
        P.DNI,
        V.Modelo,
        V.Placa,
        V.A�o
    FROM
        Pago AS Pg
        INNER JOIN Deuda AS D ON Pg.id_deuda = D.id
        INNER JOIN Persona AS P ON D.id_persona = P.id
        INNER JOIN Vehiculo AS V ON D.id_vehiculo = V.id
    WHERE
        Pg.id = @id_pago;
END;















--EJECUTAR QUINTO
-- Inserci�n 1 a 1 en la tabla Personas
EXEC InsertarPersona @Nombres = 'Walter', @Apellidos = 'Duchi', @Correo_Electronico = 'walterduchiriv@outlook.es', @Telefono = '0912345611', @Direccion = 'Calle Sucre, 100', @DNI = '0912345622';
EXEC InsertarPersona @Nombres = 'Kenneth', @Apellidos = 'Armijos', @Correo_Electronico = 'kenneth.armijosmor@outlook.es', @Telefono = '0912345633', @Direccion = 'Calle Loja, 200', @DNI = '09123456144';
EXEC InsertarPersona @Nombres = 'Mois�s', @Apellidos = 'Infante', @Correo_Electronico = 'moises.infantebar@outlook.es', @Telefono = '0912345655', @Direccion = 'Calle Chimborazo, 300', @DNI = '0912345666';
EXEC InsertarPersona @Nombres = 'C�sar', @Apellidos = 'Mendoza', @Correo_Electronico = 'cesar.mendozamen@outlook.es', @Telefono = '0912345677', @Direccion = 'Calle Ambato, 400', @DNI = '0912345688';
Select * from Persona;







--EJECUTAR SEXTO
-- Inserci�n 1 a 1 en la tabla Vehiculo
INSERT INTO Vehiculo (Valor, A�o, Cilindrada, Modelo, Placa, id_persona)
VALUES (10000, 2021, 1600, 'TOYOTA COROLLA', 'AAC0123', (SELECT id FROM Persona WHERE DNI = '0912345622'));
INSERT INTO Vehiculo (Valor, A�o, Cilindrada, Modelo, Placa, id_persona)
VALUES (12000, 2022, 1800, 'HONDA CIVIC', 'AAC0124', (SELECT id FROM Persona WHERE DNI = '09123456144'));
INSERT INTO Vehiculo (Valor, A�o, Cilindrada, Modelo, Placa, id_persona)
VALUES (15000, 2023, 2000, 'FORD FOCUS', 'AAC0125', (SELECT id FROM Persona WHERE DNI = '0912345666'));
INSERT INTO Vehiculo (Valor, A�o, Cilindrada, Modelo, Placa, id_persona)
VALUES (18000, 2024, 2200, 'CHEVROLET MALIBU', 'AAC0126', (SELECT id FROM Persona WHERE DNI = '0912345688'));
Select * from Vehiculo;








--EJECUTAR SEPTIMO
-- Correlaci�n 1 a 1 en la tabla Deuda
-- Obtener el id de la persona y el veh�culo reci�n insertados
DECLARE @id_persona INT;
DECLARE @id_vehiculo INT;
-- Para Walter Alejandro Duchi Rivera
SELECT @id_persona = id FROM Persona WHERE DNI = '0912345622';
SELECT @id_vehiculo = id FROM Vehiculo WHERE Placa = 'AAC0123';
EXEC CalcularPagoDeuda @id_persona, @id_vehiculo;
-- Para Kenneth Fernando Armijos Moreira
SELECT @id_persona = id FROM Persona WHERE DNI = '09123456144';
SELECT @id_vehiculo = id FROM Vehiculo WHERE Placa = 'AAC0124';
EXEC CalcularPagoDeuda @id_persona, @id_vehiculo;
-- Para Mois�s Adri�n Infante Barre
SELECT @id_persona = id FROM Persona WHERE DNI = '0912345666';
SELECT @id_vehiculo = id FROM Vehiculo WHERE Placa = 'AAC0125';
EXEC CalcularPagoDeuda @id_persona, @id_vehiculo;
-- Para C�sar Oscar Mendoza Mendoza
SELECT @id_persona = id FROM Persona WHERE DNI = '0912345688';
SELECT @id_vehiculo = id FROM Vehiculo WHERE Placa = 'AAC0126';
EXEC CalcularPagoDeuda @id_persona, @id_vehiculo;
SELECT * FROM Deuda;







--EJECUTAR OCTAVO
-- REALIZAR PAGOS 
-- Pagar una deuda en ventanilla
INSERT INTO Pago (Tipo, Fecha_pago, id_deuda)
VALUES (1, GETDATE(), 1);--usar el identificador correcto de la deuda a pagar
-- Pagar una deuda con dep�sito bancario (domiciliado)
INSERT INTO Pago (Tipo, Fecha_pago, id_deuda)
VALUES (2, GETDATE(), 2);--usar el identificador correcto de la deuda a pagar
SELECT * FROM Pago;







USE RIV_BD;
--EJECUTAR NOVENO (ULTIMA)
--ver todas las tablas
SELECT * FROM Persona;
SELECT * FROM Vehiculo;
SELECT * FROM Deuda;
SELECT * FROM Pago;
EXEC ObtenerInformacionPago @id_pago = 1; 
--DELETE FROM Pago WHERE id_deuda = 9;






-- ELIMINAR TODO EL CONTENIDO DE RIV_BD !!MUCHO CUIDADO!! EJECUTARLO SOLO SI ES ESTRICTAMENTE NECESARIO
DROP TRIGGER ActualizarFechaPago;
DROP PROCEDURE InsertarPersona;
DROP PROCEDURE CalcularPagoDeuda;
DROP TABLE Pago;
DROP TABLE Deuda;
DROP TABLE Vehiculo;
DROP TABLE Persona;