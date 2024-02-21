using RecaudaciónImpuestosVehiculos.Controlador;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace RecaudaciónImpuestosVehiculos.Vista
{
    public partial class FrmVehiculos : Form
    {
        public frmMenuPrincipal FormularioPrincipal { get; set; } = null!;
        private ConeccionSQL conexionSQL;

        public FrmVehiculos()
        {
            InitializeComponent();
            this.FormClosing += Vehiculo_FormClosing;

            // Inicializa la conexión aquí
            conexionSQL = new ConeccionSQL();
        }

        private void Vehiculo_FormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }

        private void btnGuardarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposVehiculo())
                {
                    using (ConeccionSQL conexionSQL = new ConeccionSQL())
                    {
                        using (SqlConnection connection = conexionSQL.AbrirConexion())
                        {
                            if (connection.State != ConnectionState.Open)
                            {
                                MessageBox.Show("Error: La conexión no está abierta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Obtener valores de los controles
                            decimal valor = Convert.ToDecimal(ValorTextBox.Text);
                            int año = Convert.ToInt32(AñoTextBox.Text);
                            int cilindrada = Convert.ToInt32(CilindradaTextBox.Text);
                            string modelo = ModeloTextBox.Text;
                            string placa = PlacaTextBox.Text;
                            string dniPropietario = DNIPersonaTextBox.Text;

                            // Ejemplo de cómo obtener el ID de persona por DNI
                            int idPropietario = ObtenerIdPersonaPorDNI(dniPropietario, connection);

                            if (idPropietario == -1)
                            {
                                MessageBox.Show("No se encontró el propietario asociado al DNI especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            using (SqlCommand command = new SqlCommand("INSERT INTO Vehiculo (Valor, Año, Cilindrada, Modelo, Placa, id_persona) VALUES (@Valor, @Año, @Cilindrada, @Modelo, @Placa, @idPropietario)", connection))
                            {
                                command.Parameters.AddWithValue("@Valor", valor);
                                command.Parameters.AddWithValue("@Año", año);
                                command.Parameters.AddWithValue("@Cilindrada", cilindrada);
                                command.Parameters.AddWithValue("@Modelo", modelo);
                                command.Parameters.AddWithValue("@Placa", placa);
                                command.Parameters.AddWithValue("@idPropietario", idPropietario);

                                command.ExecuteNonQuery();
                            }

                            MessageBox.Show("Vehículo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarControlesVehiculo();

                            // Llamar al procedimiento CalcularPagoDeuda
                            LlamarProcedimientoCalcularPagoDeuda(idPropietario, placa, connection);

                            string cuerpoCorreo = ObtenerCuerpoCorreo(idPropietario, placa);
                            EnviarCorreo(idPropietario,"Notificación de Pago", cuerpoCorreo);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al guardar vehículo: {ex.Message}", "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al guardar vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Asegúrate de cerrar la conexión después de utilizarla
                // No es necesario llamar a conexionSQL.CerrarConexion() ya que Dispose ya lo hace
            }
        }

        private void LlamarProcedimientoCalcularPagoDeuda(int idPersona, string placa, SqlConnection connection)
        {
            try
            {
                using (SqlCommand calcularPagoDeudaCommand = new SqlCommand("CalcularPagoDeuda", connection))
                {
                    calcularPagoDeudaCommand.CommandType = CommandType.StoredProcedure;

                    calcularPagoDeudaCommand.Parameters.AddWithValue("@id_persona", idPersona);

                    using (SqlCommand getIdVehiculoCommand = new SqlCommand("SELECT id FROM Vehiculo WHERE Placa = @Placa", connection))
                    {
                        getIdVehiculoCommand.Parameters.AddWithValue("@Placa", placa);
                        int idVehiculo = (int)getIdVehiculoCommand.ExecuteScalar();
                        calcularPagoDeudaCommand.Parameters.AddWithValue("@id_vehiculo", idVehiculo);
                    }

                    calcularPagoDeudaCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llamar al procedimiento CalcularPagoDeuda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerIdPersonaPorDNI(string dni, SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Error: La conexión no está abierta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            using (SqlCommand command = new SqlCommand("SELECT id FROM Persona WHERE DNI = @DNI", connection))
            {
                command.Parameters.AddWithValue("@DNI", dni);
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return -1;
            }
        }

        private void LimpiarControlesVehiculo()
        {
            ValorTextBox.Clear();
            AñoTextBox.Clear();
            CilindradaTextBox.Clear();
            ModeloTextBox.Clear();
            PlacaTextBox.Clear();
            DNIPersonaTextBox.Clear();
        }

        private bool ValidarCamposVehiculo()
        {
            if (string.IsNullOrWhiteSpace(ValorTextBox.Text) ||
                string.IsNullOrWhiteSpace(AñoTextBox.Text) ||
                string.IsNullOrWhiteSpace(CilindradaTextBox.Text) ||
                string.IsNullOrWhiteSpace(ModeloTextBox.Text) ||
                string.IsNullOrWhiteSpace(PlacaTextBox.Text) ||
                string.IsNullOrWhiteSpace(DNIPersonaTextBox.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void EnviarCorreo(int idPersona, string asunto, string cuerpo)
        {
            try
            {
                // Obtener la dirección de correo electrónico del propietario
                string destinatario = ObtenerCorreoElectronico(idPersona);

                if (string.IsNullOrEmpty(destinatario))
                {
                    MessageBox.Show("No se encontró la dirección de correo electrónico del propietario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string nombreEmpresa = "COBROS S.A.";
                string remitente = "grupo6.cobross.a@gmail.com"; // Ingresa tu dirección de correo aquí
                string contraseña = "udduasrdkjobffqf"; // Ingresa tu contraseña aquí

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587; // Puerto estándar para conexiones TLS
                    smtpClient.Credentials = new NetworkCredential(remitente, contraseña);
                    smtpClient.EnableSsl = true; // Habilitar SSL/TLS

                    // Configurar el tipo de seguridad SSL/TLS
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;

                    smtpClient.TargetName = "smtp.gmail.com";
                    smtpClient.Host = "smtp.gmail.com";

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(remitente, nombreEmpresa);
                        mailMessage.To.Add(destinatario);
                        mailMessage.Subject = asunto;
                        mailMessage.Body = cuerpo;

                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Función para obtener la dirección de correo electrónico del propietario
        private string ObtenerCorreoElectronico(int idPersona)
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                {
                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        using (SqlCommand command = new SqlCommand("SELECT Correo_Electronico FROM Persona WHERE id = @idPersona", connection))
                        {
                            command.Parameters.AddWithValue("@idPersona", idPersona);
                            object result = command.ExecuteScalar();

                            return result != null ? result.ToString() : null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la dirección de correo electrónico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private string ObtenerCuerpoCorreo(int idPersona, string placaVehiculo)
        {
            string cuerpoCorreo = string.Empty;

            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                {
                    string notificacionQuery = "SELECT Persona.Nombres, Persona.Apellidos, Persona.DNI, Vehiculo.Placa, Vehiculo.Modelo, Deuda.id AS id_deuda, Deuda.Impuesto, Deuda.Recargo, Deuda.Total " +
                                "FROM Persona " +
                                "JOIN Vehiculo ON Persona.id = Vehiculo.id_persona " +
                                "JOIN Deuda ON Persona.id = Deuda.id_persona " +
                                "WHERE Persona.id = @id_persona AND Vehiculo.Placa = @Placa " +
                                "ORDER BY Deuda.id_vehiculo DESC " +
                                "OFFSET 0 ROWS FETCH NEXT 1 ROW ONLY";

                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        using (SqlCommand notificacionCommand = new SqlCommand(notificacionQuery, connection))
                        {
                            notificacionCommand.Parameters.AddWithValue("@id_persona", idPersona);
                            notificacionCommand.Parameters.AddWithValue("@Placa", placaVehiculo);

                            using (SqlDataReader reader = notificacionCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string nombreCompleto = $"{reader["Nombres"]} {reader["Apellidos"]}";

                                    cuerpoCorreo += $"Estimado Sr(a) {nombreCompleto}\n";
                                    cuerpoCorreo += "Le informamos que tiene una deuda pendiente por el impuesto de su vehículo.\n";
                                    cuerpoCorreo += "Por favor, realice el pago correspondiente para evitar recargos adicionales.\n\n";
                                    cuerpoCorreo += "Detalles del pago:\n";
                                    cuerpoCorreo += $"DEBE CANCELAR AL SIGUIENTE NUMERO DE DEUDA: {reader["id_deuda"]}\n";
                                    cuerpoCorreo += $"DNI del Propietario: {reader["DNI"]}\n";
                                    cuerpoCorreo += $"Placa del vehículo: {placaVehiculo}\n";
                                    cuerpoCorreo += $"Modelo del vehículo: {reader["Modelo"]}\n";
                                    cuerpoCorreo += $"Impuesto: ${reader["Impuesto"]:N}\n";
                                    cuerpoCorreo += $"Recargo: ${reader["Recargo"]:N}\n";
                                    cuerpoCorreo += $"Total a pagar: ${reader["Total"]:N}\n\n";
                                    cuerpoCorreo += "Gracias por confiar en COBROS S.A.\n";
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL al obtener datos para el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al obtener datos para el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return cuerpoCorreo;
        }
    }
}
