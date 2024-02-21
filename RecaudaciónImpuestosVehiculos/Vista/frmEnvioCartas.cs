using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RecaudaciónImpuestosVehiculos.Controlador;

namespace RecaudaciónImpuestosVehiculos
{
    public partial class frmEnvioCartas : Form
    {
        public frmMenuPrincipal FormularioPrincipal { get; set; } = null!;


        public frmEnvioCartas()
        {
            InitializeComponent();
            this.FormClosing += EnvioCartas_FormClosing;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }

        private void EnvioCartas_FormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string placaVehiculo = txtPlaca.Text;

                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                {
                    string vehiculoQuery = "SELECT id_persona FROM Vehiculo WHERE Placa = @Placa";
                    string notificacionQuery = "SELECT Persona.Nombres, Persona.Apellidos, Persona.DNI, Vehiculo.Placa, Vehiculo.Modelo, Deuda.Total " +
                                "FROM Persona " +
                                "JOIN Vehiculo ON Persona.id = Vehiculo.id_persona " +
                                "JOIN Deuda ON Vehiculo.id = Deuda.id_vehiculo " +
                                "WHERE Persona.id = @id_persona AND Vehiculo.Placa = @Placa";

                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        int idPersona;
                        using (SqlCommand getIdPersonaCommand = new SqlCommand(vehiculoQuery, connection))
                        {
                            getIdPersonaCommand.Parameters.AddWithValue("@Placa", placaVehiculo);
                            idPersona = (int)getIdPersonaCommand.ExecuteScalar();
                        }

                        using (SqlCommand notificacionCommand = new SqlCommand(notificacionQuery, connection))
                        {
                            notificacionCommand.Parameters.AddWithValue("@id_persona", idPersona);
                            notificacionCommand.Parameters.AddWithValue("@Placa", placaVehiculo);

                            using (SqlDataReader reader = notificacionCommand.ExecuteReader())
                            {
                                richTextBox.Clear();

                                while (reader.Read())
                                {
                                    string nombreCompleto = $"{reader["Nombres"]} {reader["Apellidos"]}";
                                    richTextBox.AppendText($"Estimado Sr(a) {nombreCompleto}\n");
                                    richTextBox.AppendText($"Le informamos que tiene una deuda pendiente por el impuesto de su vehículo.\n");
                                    richTextBox.AppendText($"Por favor, realice el pago correspondiente para evitar recargos adicionales.\n\n");
                                    richTextBox.AppendText($"Detalles del pago:\n");
                                    richTextBox.AppendText($"DNI del Propietario: {reader["DNI"]}\n");
                                    richTextBox.AppendText($"Placa del vehículo: {placaVehiculo}\n");
                                    richTextBox.AppendText($"Modelo del vehículo: {reader["Modelo"]}\n");
                                    richTextBox.AppendText($"Total a pagar: ${reader["Total"]:N}\n\n");
                                    richTextBox.AppendText($"Gracias por confiar en COBROS S.A.\n");
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string contenido = richTextBox.Text;

            Font fuenteTitulo = new Font("Arial", 20, FontStyle.Bold);
            PointF posicionTitulo = new PointF(10, 10);

            Font fuenteContenido = new Font("Arial", 14);
            PointF posicionContenido = new PointF(25, 55);

            e.Graphics.DrawString("COBROS S.A. - Notificación de Pago", fuenteTitulo, Brushes.Black, posicionTitulo);

            e.Graphics.DrawString(contenido, fuenteContenido, Brushes.Black, posicionContenido);
        }
    }
}
