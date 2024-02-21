# Instrucciones para ejecutar la base de datos

Este archivo describe los pasos necesarios para ejecutar la base de datos proporcionada.

## Requisitos previos

- Tener acceso a un servidor de bases de datos SQL Server.
- Tener permisos para ejecutar scripts de bases de datos en el servidor.
- Tener instalado un cliente de SQL Server, como SQL Server Management Studio (SSMS), para ejecutar los scripts.

## Pasos para la ejecución

1. **Crear la base de datos**: 
   Ejecute el siguiente comando SQL en el cliente de SQL Server para crear la base de datos `RIV_BD`:

   ```sql
   CREATE DATABASE RIV_BD;
   ```

2. **Ejecutar los scripts**:
   Copie y ejecute cada bloque de código SQL en orden secuencial. Cada bloque de código está etiquetado con un comentario que indica cuándo ejecutarlo (`--EJECUTAR PRIMERO`, `--EJECUTAR SEGUNDO`, etc.).

3. **Verificar la ejecución**:
   Una vez que haya ejecutado todos los bloques de código, puede verificar que la base de datos y las tablas se hayan creado correctamente ejecutando consultas como:

   ```sql
   SELECT * FROM Persona;
   SELECT * FROM Vehiculo;
   SELECT * FROM Deuda;
   SELECT * FROM Pago;
   ```

4. **Eliminar el contenido** (opcional):
   Si desea limpiar la base de datos, puede ejecutar el último bloque de código que contiene las instrucciones `DROP`. **¡Tenga cuidado al ejecutar este paso, ya que eliminará todos los datos y objetos de la base de datos!**

## Notas adicionales

- Asegúrese de ajustar cualquier valor predeterminado en los scripts según sea necesario, como las fechas o los identificadores de las deudas a pagar.
- Si encuentra algún error durante la ejecución, verifique la sintaxis del script y los mensajes de error proporcionados por SQL Server.
