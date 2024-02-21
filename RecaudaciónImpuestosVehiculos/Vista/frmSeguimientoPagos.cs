using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RecaudaciónImpuestosVehiculos.Controlador;

namespace RecaudaciónImpuestosVehiculos
{
    public partial class frmSeguimientoPagos : Form
    {

        public frmMenuPrincipal FormularioPrincipal { get; set; } = null!;
        private ConeccionSQL conexionSQL;

        public frmSeguimientoPagos()
        {
            InitializeComponent();
            this.FormClosing += SeguimientoPagos_FormClosing;
            conexionSQL = new ConeccionSQL();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }

        private void SeguimientoPagos_FormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }

        private void btnGuardarPDF_Click(object sender, EventArgs e)
        {

        }
        private void BuscarDeudasPorDNI(string dniABuscar)
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                using (SqlConnection connection = conexionSQL.AbrirConexion())
                {
                    string consulta = "SELECT COALESCE(CONVERT(VARCHAR, P.Fecha_pago, 103), '') AS Fecha_Pago, Per.DNI, V.Placa AS Matricula, Per.Nombres AS Nombre, Per.Apellidos, D.Impuesto, D.Recargo, D.Total " +
                                      "FROM Persona Per " +
                                      "LEFT JOIN Deuda D ON Per.id = D.id_persona " +
                                      "LEFT JOIN Vehiculo V ON D.id_vehiculo = V.id " +
                                      "LEFT JOIN Pago P ON D.id = P.id_deuda " +
                                      "WHERE Per.DNI LIKE @dniBuscado " +
                                      "ORDER BY COALESCE(P.Fecha_pago, '99991231')";

                    using (SqlCommand command = new SqlCommand(consulta, connection))
                    {
                        command.Parameters.AddWithValue("@dniBuscado", "%" + dniABuscar + "%");

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            dataAdapter.Fill(dt);
                            DatosInforme.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar deudas por DNI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarDeudasPorMatricula(string matriculaABuscar)
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                using (SqlConnection connection = conexionSQL.AbrirConexion())
                {
                    string consulta = "SELECT COALESCE(CONVERT(VARCHAR, P.Fecha_pago, 103), '') AS Fecha_Pago, Per.DNI, V.Placa AS Matricula, Per.Nombres AS Nombre, Per.Apellidos, D.Impuesto, D.Recargo, D.Total " +
                                      "FROM Vehiculo V " +
                                      "LEFT JOIN Deuda D ON V.id = D.id_vehiculo " +
                                      "LEFT JOIN Persona Per ON D.id_persona = Per.id " +
                                      "LEFT JOIN Pago P ON D.id = P.id_deuda " +
                                      "WHERE V.Placa LIKE @matriculaBuscado " +
                                      "ORDER BY COALESCE(P.Fecha_pago, '99991231')";

                    using (SqlCommand command = new SqlCommand(consulta, connection))
                    {
                        command.Parameters.AddWithValue("@matriculaBuscado", "%" + matriculaABuscar + "%");

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            dataAdapter.Fill(dt);
                            DatosInforme.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar deudas por matrícula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarDeudasPorNombre(string nombreABuscar)
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                using (SqlConnection connection = conexionSQL.AbrirConexion())
                {
                    string consulta = "SELECT COALESCE(CONVERT(VARCHAR, P.Fecha_pago, 103), '') AS Fecha_Pago, Per.DNI, V.Placa AS Matricula, Per.Nombres AS Nombre, Per.Apellidos, D.Impuesto, D.Recargo, D.Total " +
                                      "FROM Persona Per " +
                                      "LEFT JOIN Deuda D ON Per.id = D.id_persona " +
                                      "LEFT JOIN Vehiculo V ON D.id_vehiculo = V.id " +
                                      "LEFT JOIN Pago P ON D.id = P.id_deuda " +
                                      "WHERE Per.Nombres LIKE @NombreBuscado OR Per.Apellidos LIKE @NombreBuscado " +
                                      "ORDER BY COALESCE(P.Fecha_pago, '99991231')";

                    using (SqlCommand command = new SqlCommand(consulta, connection))
                    {
                        command.Parameters.AddWithValue("@NombreBuscado", "%" + nombreABuscar + "%");

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            dataAdapter.Fill(dt);
                            DatosInforme.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar deudas por nombre: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsultarPagos_Click(object sender, EventArgs e)
        {
            string opcionSeleccionada = cmbTipoPago.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "DNI":
                    BuscarDeudasPorDNI(txtNombrePropietario.Text);
                    break;

                case "Matrícula":
                    BuscarDeudasPorMatricula(txtNombrePropietario.Text);
                    break;

                case "Nombre del Dueño":
                    BuscarDeudasPorNombre(txtNombrePropietario.Text);
                    break;

                default:
                    MessageBox.Show("Por favor, seleccione una opción de búsqueda válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
