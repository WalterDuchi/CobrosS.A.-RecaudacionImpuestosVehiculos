using RecaudaciónImpuestosVehiculos.Controlador;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RecaudaciónImpuestosVehiculos.Vista
{
    public partial class frmUsuarios : Form
    {
        private ConeccionSQL conexionSQL = new ConeccionSQL();

        public frmUsuarios()
        {
            InitializeComponent();
            this.FormClosing += Usuario_FormClosing;
        }

        public frmMenuPrincipal FormularioPrincipal { get; set; } = null!;

        private void Usuario_FormClosing(object? sender, FormClosingEventArgs e)
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

        private void GuardarUsuarioButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(NombresTextBox.Text) ||
                    string.IsNullOrWhiteSpace(ApellidosTextBox.Text) ||
                    string.IsNullOrWhiteSpace(CorreoElectronicoTextBox.Text) ||
                    string.IsNullOrWhiteSpace(TelefonoTextBox.Text) ||
                    string.IsNullOrWhiteSpace(DireccionTextBox.Text) ||
                    string.IsNullOrWhiteSpace(DNITextBox.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir la conexión antes de usarla
                using (ConeccionSQL conexionSQL = new ConeccionSQL())
                {
                    // Obtener valores de los TextBox
                    string nombres = NombresTextBox.Text;
                    string apellidos = ApellidosTextBox.Text;
                    string correoElectronico = CorreoElectronicoTextBox.Text;
                    string telefono = TelefonoTextBox.Text;
                    string direccion = DireccionTextBox.Text;
                    string dni = DNITextBox.Text;

                    // Ejecutar procedimiento almacenado para asignar datos del usuario
                    using (SqlConnection connection = conexionSQL.AbrirConexion())
                    {
                        using (SqlCommand command = new SqlCommand("InsertarPersona", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Parámetros del procedimiento almacenado
                            command.Parameters.AddWithValue("@Nombres", nombres);
                            command.Parameters.AddWithValue("@Apellidos", apellidos);
                            command.Parameters.AddWithValue("@Correo_Electronico", correoElectronico);
                            command.Parameters.AddWithValue("@Telefono", telefono);
                            command.Parameters.AddWithValue("@Direccion", direccion);
                            command.Parameters.AddWithValue("@DNI", dni);

                            // Ejecutar el procedimiento almacenado
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los TextBox después de guardar exitosamente
                    NombresTextBox.Clear();
                    ApellidosTextBox.Clear();
                    CorreoElectronicoTextBox.Clear();
                    TelefonoTextBox.Clear();
                    DireccionTextBox.Clear();
                    DNITextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
