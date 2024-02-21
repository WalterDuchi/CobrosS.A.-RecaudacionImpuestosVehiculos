using System;
using System.Data;
using System.Data.SqlClient;

namespace RecaudaciónImpuestosVehiculos.Controlador
{
    internal class ManageSQL
    {
        private ConeccionSQL connn = new ConeccionSQL();

        public bool EjecutarSQL(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                using (SqlConnection connection = connn.AbrirConexion())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;

                        // Agregar parámetros si se proporcionan
                        if (parametros != null)
                        {
                            command.Parameters.AddRange(parametros);
                        }

                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (SqlException sqlEx)
            {
                // Manejar excepciones específicas de SQL
                Console.WriteLine($"Error SQL al ejecutar consulta: {sqlEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción
                Console.WriteLine($"Error al ejecutar SQL: {ex.Message}");
                return false;
            }
            finally
            {
                connn.CerrarConexion();
            }
        }

        public DataTable ObtenerDatos(string sql, SqlParameter[] parametros = null)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = connn.AbrirConexion())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;

                        // Agregar parámetros si se proporcionan
                        if (parametros != null)
                        {
                            command.Parameters.AddRange(parametros);
                        }

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    }
                }

                return dataTable;
            }
            catch (SqlException sqlEx)
            {
                // Manejar excepciones específicas de SQL
                Console.WriteLine($"Error SQL al obtener datos: {sqlEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
                return null;
            }
            finally
            {
                connn.CerrarConexion();
            }
        }
    }
}
