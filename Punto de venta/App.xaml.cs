using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Punto_de_venta
{
    public partial class App : Application
    {
        // Esta es la instancia (el objeto) que necesitamos
        // Agrega el = default!; para decirle al compilador "Yo me encargo, no será null"
        public static IServiceProvider ServiceProvider { get; private set; } = default!;

        private IServiceScope? _uiScope;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider = AdministradorDependencias.ConfigurarServicios();

            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<PuntoVentaContex>();
                context.Database.Migrate();
            }

            _uiScope = ServiceProvider.CreateScope(); // scope que vive toda la app
            var mainWindow = _uiScope.ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _uiScope?.Dispose();
            base.OnExit(e);
        }

    }
}