using RecaudaciónImpuestosVehiculos.Vista;

namespace RecaudaciónImpuestosVehiculos
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            AbrirVentana(new frmControlPagos());
        }

        private void btnEnviarCartas_Click(object sender, EventArgs e)
        {
            AbrirVentana(new frmEnvioCartas());
        }

        private void btnGenerarInformes_Click(object sender, EventArgs e)
        {
            AbrirVentana(new frmGeneracionInformes());
        }

        private void btnSeguimientoPagos_Click(object sender, EventArgs e)
        {
            AbrirVentana(new frmSeguimientoPagos());
        }

        private void AbrirVentana(Form ventana)
        {
            this.Hide();

            if (ventana is frmEnvioCartas envioCartasForm)
            {
                envioCartasForm.FormularioPrincipal = this;
            }

            if (ventana is frmControlPagos controlPagosForm)
            {
                controlPagosForm.FormularioPrincipal = this;
            }

            if (ventana is frmGeneracionInformes generacionInformesForm)
            {
                generacionInformesForm.FormularioPrincipal = this;
            }

            if (ventana is frmSeguimientoPagos seguimientoPagosForm)
            {
                seguimientoPagosForm.FormularioPrincipal = this;
            }
            if (ventana is frmUsuarios usuariosForm)
            {
                usuariosForm.FormularioPrincipal = this;
            }
            if (ventana is FrmVehiculos vehiculosForm)
            {
                vehiculosForm.FormularioPrincipal = this;
            }

            ventana.StartPosition = FormStartPosition.CenterScreen;
            ventana.WindowState = FormWindowState.Maximized;

            ventana.ShowDialog();


        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            AbrirVentana(new frmUsuarios());
        }

        private void btnRegistrarVehiculo_Click(object sender, EventArgs e)
        {
            AbrirVentana(new FrmVehiculos());
        }
    }
}
