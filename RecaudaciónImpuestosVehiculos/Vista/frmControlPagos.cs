using RecaudaciónImpuestosVehiculos.Controlador;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Windows.Forms;

namespace RecaudaciónImpuestosVehiculos
{
    public partial class frmControlPagos : Form
    {
        public frmMenuPrincipal FormularioPrincipal { get; set; } = null!;
        private ConeccionSQL conexionSQL;
        private bool pagoRegistrado = false;


        public frmControlPagos()
        {
            InitializeComponent();
            this.FormClosing += ControlPagos_FormClosing;

            // Inicializa la conexión aquí
            conexionSQL = new ConeccionSQL();


        }

        private void ControlPagos_FormClosing(object? sender, FormClosingEventArgs e)
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


        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposPago())
                {
                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            MessageBox.Show("Error: La conexión no está abierta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Obtener valores de los controles
                        int idDeuda = Convert.ToInt32(txtID_Deuda.Text);
                        string tipoPagoTexto = cmbTipoDePago.SelectedItem.ToString();
                        int tipoPago = ObtenerTipoPagoDesdeTexto(tipoPagoTexto);
                        DateTime fechaPago = dtpFechaPago.Value;

                        // Ejemplo de cómo obtener el ID de persona por DNI
                        using (SqlCommand command = new SqlCommand("INSERT INTO Pago (id_deuda, Tipo, Fecha_Pago) VALUES (@idDeuda, @TipoPago, @FechaPago)", connection))
                        {
                            command.Parameters.AddWithValue("@idDeuda", idDeuda);
                            command.Parameters.AddWithValue("@TipoPago", tipoPago);
                            command.Parameters.AddWithValue("@FechaPago", fechaPago);

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Pago registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pagoRegistrado = true;

                        // Obtener información del pago para enviar el correo
                        EnviarCorreo(idDeuda);

                        // Permitir imprimir a PDF
                        ImprimirPago(idDeuda);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Función para convertir el texto del ComboBox a un número según tus especificaciones
        private int ObtenerTipoPagoDesdeTexto(string tipoPagoTexto)
        {
            // Aquí puedes ajustar según las opciones que hay en el ComboBox
            switch (tipoPagoTexto)
            {
                case "1. Pago realizado en ventanilla":
                    return 1;
                case "2. Pago mediante deposito bancario (domiciliado)":
                    return 2;
                default:
                    throw new ArgumentException("Opción de tipo de pago no válida");
            }
        }



        private void EnviarCorreo(int idDeuda)
        {
            try
            {
                // Obtener información del pago
                string cuerpoCorreo = ObtenerInformacionPago(idDeuda);

                if (string.IsNullOrEmpty(cuerpoCorreo))
                {
                    MessageBox.Show("No se pudo obtener la información del pago para enviar el correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener la dirección de correo electrónico del propietario
                string destinatario = ObtenerCorreoPropietario(idDeuda);

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
                        mailMessage.Subject = "Confirmación de Pago";
                        mailMessage.Body = cuerpoCorreo;

                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerInformacionPago(int idDeuda)
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                {
                    string informacionPagoQuery = "SELECT Pago.id, Deuda.id AS id_deuda, Persona.Nombres, Persona.Apellidos, Persona.DNI, " +
                                                  "Vehiculo.Placa, Vehiculo.Modelo, Pago.Tipo, Pago.Fecha_Pago " + // Cambiado Tipo a Tipo
                                                  "FROM Pago " +
                                                  "JOIN Deuda ON Pago.id_deuda = Deuda.id " +
                                                  "JOIN Vehiculo ON Deuda.id_vehiculo = Vehiculo.id " +
                                                  "JOIN Persona ON Vehiculo.id_persona = Persona.id " +
                                                  "WHERE Pago.id_deuda = @idDeuda";

                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        using (SqlCommand informacionPagoCommand = new SqlCommand(informacionPagoQuery, connection))
                        {
                            informacionPagoCommand.Parameters.AddWithValue("@idDeuda", idDeuda);

                            using (SqlDataReader reader = informacionPagoCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nombreCompleto = $"{reader["Nombres"]} {reader["Apellidos"]}";

                                    string informacion = $"¡Estimado/a {nombreCompleto}!\n\n" +
                                                         "Le informamos que su pago ha sido procesado con éxito.\nA continuación, encontrará los detalles:\n\n" +
                                                         $"ID del Pago: {reader["id"]}\n" +
                                                         $"ID de la Deuda: {reader["id_deuda"]}\n" +
                                                         $"Nombre del Propietario: {nombreCompleto}\n" +
                                                         $"DNI del Propietario: {reader["DNI"]}\n" +
                                                         $"Placa del vehículo: {reader["Placa"]}\n" +
                                                         $"Modelo del vehículo: {reader["Modelo"]}\n" +
                                                         $"Tipo de Pago: {ObtenerTipoPagoTexto(Convert.ToInt32(reader["Tipo"]))}\n" + // Utiliza la función para obtener el texto del tipo de pago
                                                         $"Fecha de Pago: {Convert.ToDateTime(reader["Fecha_Pago"]).ToString("dd/MM/yyyy HH:mm:ss")}\n\n" +
                                                         "Gracias por utilizar nuestro servicio.\n" +
                                                         "Atentamente,\n" +
                                                         "COBROS S.A.";

                                    return informacion;
                                }

                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL al obtener información del pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al obtener información del pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }


        private string ObtenerTipoPagoTexto(int tipoPago)
        {
            switch (tipoPago)
            {
                case 1:
                    return "Pago realizado en ventanilla";
                case 2:
                    return "Pago mediante depósito bancario (domiciliado)";
                default:
                    return "Tipo de pago no especificado";
            }
        }


        private string ObtenerCorreoPropietario(int idDeuda)
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                {
                    string correoPropietarioQuery = "SELECT Persona.Correo_Electronico " +
                                                    "FROM Pago " +
                                                    "JOIN Deuda ON Pago.id_deuda = Deuda.id " +
                                                    "JOIN Vehiculo ON Deuda.id_vehiculo = Vehiculo.id " +
                                                    "JOIN Persona ON Vehiculo.id_persona = Persona.id " +
                                                    "WHERE Pago.id_deuda = @idDeuda";

                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        using (SqlCommand correoPropietarioCommand = new SqlCommand(correoPropietarioQuery, connection))
                        {
                            correoPropietarioCommand.Parameters.AddWithValue("@idDeuda", idDeuda);
                            object result = correoPropietarioCommand.ExecuteScalar();

                            return result != null ? result.ToString() : null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL al obtener correo del propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al obtener correo del propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }

        private void ImprimirPago(int idDeuda)
        {
            try
            {
                // Obtener información del pago
                string informacionPago = ObtenerInformacionPago(idDeuda);

                if (string.IsNullOrEmpty(informacionPago))
                {
                    MessageBox.Show("No se pudo obtener la información del pago para imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mostrar el cuadro de diálogo de impresión
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = new PrintDocument();

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Configurar el documento para la impresión
                    printDialog.Document.PrintPage += (s, args) =>
                    {
                        // Configurar la fuente y posición
                        Font fuente = new Font("Arial", 15);//opcion 1
                        PointF posicion = new PointF(10, 10);

                        // Imprimir la información del pago
                        args.Graphics.DrawString(informacionPago, fuente, Brushes.Black, posicion);

                        // Crear el documento PDF
                        CrearDocumentoPDF(informacionPago, printDialog.Document.PrinterSettings.PrinterName);
                    };

                    // Imprimir el documento
                    printDialog.Document.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearDocumentoPDF(string informacionPago, string impresora)
        {
            try
            {
                // Crear el documento PDF
                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pago.pdf");

                using (PdfWriter writer = new PdfWriter(rutaPDF))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);
                        document.Add(new Paragraph(informacionPago));
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private string CrearDocumentoPDF(string informacionPago)
        {
            try
            {
                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Pago.pdf");

                using (StreamWriter sw = new StreamWriter(rutaPDF))
                {
                    sw.WriteLine(informacionPago);
                }

                return rutaPDF;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el documento PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private bool ValidarCamposPago()
        {
            if (string.IsNullOrWhiteSpace(txtID_Deuda.Text) || cmbTipoDePago.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnImprimirPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (pagoRegistrado)
                {
                    // Obtener el ID de la última deuda
                    int idDeuda = ObtenerUltimaDeuda();

                    // Obtener información del pago para imprimir
                    string informacionPago = ObtenerInformacionPago(idDeuda);

                    // Mostrar el cuadro de diálogo de impresión
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = new PrintDocument();

                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Configurar el documento para la impresión
                        printDialog.Document.PrintPage += (s, args) =>
                        {
                            // Configurar la fuente y posición
                            Font fuente = new Font("Arial", 12);// opcion 2
                            PointF posicion = new PointF(10, 10);

                            // Imprimir la información del pago
                            args.Graphics.DrawString(informacionPago, fuente, Brushes.Black, posicion);
                        };

                        // Imprimir el documento
                        printDialog.Document.Print();
                    }
                }
                else
                {
                    MessageBox.Show("Primero registre un pago antes de intentar imprimir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int ObtenerUltimaDeuda()
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                {
                    string ultimaDeudaQuery = "SELECT TOP 1 id FROM Deuda ORDER BY id DESC";

                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        using (SqlCommand ultimaDeudaCommand = new SqlCommand(ultimaDeudaQuery, connection))
                        {
                            object result = ultimaDeudaCommand.ExecuteScalar();

                            return result != null ? Convert.ToInt32(result) : -1;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL al obtener la última deuda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al obtener la última deuda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1;
        }


        private void btnAbrirPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID de la última deuda ingresada
                int idUltimaDeuda = ObtenerUltimaDeuda();

                if (idUltimaDeuda != -1)
                {
                    // Obtener la ruta del PDF de la última deuda
                    string rutaPDF = ObtenerRutaPDF(idUltimaDeuda);

                    if (!string.IsNullOrEmpty(rutaPDF) && File.Exists(rutaPDF))
                    {
                        // Abrir el PDF
                        Process.Start(rutaPDF);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el archivo PDF de la última deuda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron deudas para abrir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el PDF de la deuda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerRutaPDF(int idDeuda)
        {
            try
            {
                // Obtener información del pago
                string informacionPago = ObtenerInformacionPago(idDeuda);

                if (string.IsNullOrEmpty(informacionPago))
                {
                    MessageBox.Show("No se pudo obtener la información del pago para abrir el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }

                // Crear el documento PDF
                string rutaPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Pago_{idDeuda}.pdf");

                using (StreamWriter sw = new StreamWriter(rutaPDF))
                {
                    sw.WriteLine(informacionPago);
                }

                return rutaPDF;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la ruta del PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}

