using Core.CasosDeUso;
using Core.CasosDeUso.ProductoUsecase;
using Core.Dominio.Entidades;
using Core.interfaces;
using Data;
using Data.Repositorios.Maestras;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Punto_de_venta;

class AdministradorDependencias
{
    public static ServiceProvider ConfigurarServicios()
    {
        var servicios = new ServiceCollection();
      
        var folder = System.IO.Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "Punto_de_venta");

        System.IO.Directory.CreateDirectory(folder);

        var dbPath = System.IO.Path.Combine(folder, "PuntoDeVenta.db");

        servicios.AddDbContext<PuntoVentaContex>(opt =>
            opt.UseSqlite($"Data Source={dbPath}"));


        var assembly = typeof(ProductosRepositorio).Assembly;

        var repos = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repositorio"));

        foreach (var impl in repos)
        {
            var interfaces = impl.GetInterfaces()
                .Where(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IRepositorio<>));

            foreach (var itf in interfaces)
                servicios.AddScoped(itf, impl);
        }

        var assemblys = typeof(AgregarProductoUseCase).Assembly;
        var usecase = assemblys.GetTypes()
            .Where(i => i.IsClass &&
                       !i.IsAbstract && i.Name.EndsWith("UseCase"));

        foreach(var uc in usecase)
        {
            servicios.AddScoped(uc);
        }

        servicios.AddScoped<IUnitOfWork, UnitOfWork>();

        servicios.AddScoped<MainWindow>();
        return servicios.BuildServiceProvider();
    }
}
    