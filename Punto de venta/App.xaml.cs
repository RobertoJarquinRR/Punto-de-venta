using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Punto_de_venta
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = default!;
        private IServiceScope? _uiScope;
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            try
            {

                ServiceProvider = AdministradorDependencias.ConfigurarServicios();
                
                using (var scope = ServiceProvider.CreateScope())
                {
                  
                    var context = scope.ServiceProvider.GetRequiredService<PuntoVentaContex>();
                   

                   
                    context.Database.OpenConnection();
                   
                    context.Database.CloseConnection();

                
                    context.Database.Migrate();
            

                }

                _uiScope  = ServiceProvider.CreateScope();
               
                var mainwindows = _uiScope.ServiceProvider.GetRequiredService<MainWindow>();
                
                this.MainWindow = mainwindows;
                mainwindows.Show();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error al iniciar");
               
            }
        }


        protected override void OnExit(ExitEventArgs e)
        {
            
            base.OnExit(e);
        }

    }
}