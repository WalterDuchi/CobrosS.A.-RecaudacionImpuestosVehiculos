using RecaudaciónImpuestosVehiculos.Controlador;
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


namespace RecaudaciónImpuestosVehiculos
{
    public partial class frmGeneracionInformes : Form
    {
        public frmMenuPrincipal FormularioPrincipal { get; set; } = null!;
        private ConeccionSQL conexionSQL;

        public frmGeneracionInformes()
        {
            InitializeComponent();
            this.FormClosing += GeneracionInformes_FormClosing;
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

        private void GeneracionInformes_FormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            if (FormularioPrincipal != null)
            {
                FormularioPrincipal.Show();
            }
        }






        private void cmbTipoInforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionada = cmbTipoInforme.SelectedItem.ToString();

            switch (opcionSeleccionada)
            {
                case "Todos":
                    CargarTodosLosDatos();
                    break;

                case "Pagos Realizados":
                    CargarPagosRealizados();
                    break;
                case "Pagos Atrasados":
                    CargarPagosAtrasados();
                    break;

                default:
                    break;
            }
        }

        private void CargarTodosLosDatos()
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                using (SqlConnection connection = conexionSQL.AbrirConexion())
                using (SqlCommand command = new SqlCommand("SELECT " +
                    "   Pago.id AS Pago_ID, " +
                    "   Pago.Tipo AS Tipo_Pago, " +
                    "   Pago.Fecha_pago AS Fecha_Pago, " +
                    "   Persona.Nombres AS Nombre_Persona, " +
                    "   Persona.Apellidos AS Apellido_Persona, " +
                    "   Persona.DNI AS DNI_Persona, " +
                    "   Deuda.Fecha_Convocatoria AS Fecha_Convocatoria, " +
                    "   Deuda.Fecha_pago AS Fecha_Pago_Deuda, " +
                    "   Deuda.Impuesto AS Impuesto_Deuda, " +
                    "   Deuda.Recargo AS Recargo_Deuda, " +
                    "   Deuda.Total AS Total_Deuda " +
                    "FROM Pago " +
                    "RIGHT JOIN Deuda ON Pago.id_deuda = Deuda.id " +
                    "JOIN Persona ON Deuda.id_persona = Persona.id", connection))
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dgvDatosInforme.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagosRealizados()
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                using (SqlConnection connection = conexionSQL.AbrirConexion())
                using (SqlCommand command = new SqlCommand("SELECT " +
                    "   Pago.id AS Pago_ID, " +
                    "   Pago.Tipo AS Tipo_Pago, " +
                    "   Pago.Fecha_pago AS Fecha_Pago, " +
                    "   Persona.Nombres AS Nombre_Persona, " +
                    "   Persona.Apellidos AS Apellido_Persona, " +
                    "   Persona.DNI AS DNI_Persona, " +
                    "   Deuda.Fecha_Convocatoria AS Fecha_Convocatoria, " +
                    "   Deuda.Fecha_pago AS Fecha_Pago_Deuda, " +
                    "   Deuda.Impuesto AS Impuesto_Deuda, " +
                    "   Deuda.Recargo AS Recargo_Deuda, " +
                    "   Deuda.Total AS Total_Deuda " +
                    "FROM Pago " +
                    "JOIN Deuda ON Pago.id_deuda = Deuda.id " +
                    "JOIN Persona ON Deuda.id_persona = Persona.id", connection))
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dgvDatosInforme.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagosAtrasados()
        {
            try
            {
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                using (SqlConnection connection = conexionSQL.AbrirConexion())
                using (SqlCommand command = new SqlCommand("SELECT " +
                    "   Deuda.id AS Deuda_ID, " +
                    "   Deuda.Fecha_Convocatoria AS Fecha_Convocatoria, " +
                    "   Deuda.Fecha_pago AS Fecha_Pago_Deuda, " +
                    "   Deuda.Impuesto AS Impuesto_Deuda, " +
                    "   Deuda.Recargo AS Recargo_Deuda, " +
                    "   Deuda.Total AS Total_Deuda, " +
                    "   Persona.Nombres AS Nombre_Persona, " +
                    "   Persona.Apellidos AS Apellido_Persona, " +
                    "   Persona.DNI AS DNI_Persona " +
                    "FROM Deuda " +
                    "JOIN Persona ON Deuda.id_persona = Persona.id " +
                    "LEFT JOIN Pago ON Deuda.id = Pago.id_deuda " +
                    "WHERE Pago.id IS NULL", connection))
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    dgvDatosInforme.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnGenerarInforme_Click(object sender, EventArgs e)
        {

        }

        private void dgvDatosInforme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
