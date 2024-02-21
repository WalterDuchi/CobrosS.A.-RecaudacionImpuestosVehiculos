using System;
using System.Windows.Forms;

namespace RecaudaciónImpuestosVehiculos
{
    internal static class SuperMain
    {
        [STAThread]
        static void Main()
        {
            // Inicializar configuraciones de la aplicación
            ApplicationConfiguration.Initialize();

            // Crear el formulario principal
            frmMenuPrincipal generalForm = new frmMenuPrincipal();

            // Configurar la posición inicial del formulario en el centro de la pantalla
            generalForm.StartPosition = FormStartPosition.CenterScreen;

            // Iniciar la aplicación y pasar el formulario principal
            Application.Run(generalForm);
        }
    }
}
