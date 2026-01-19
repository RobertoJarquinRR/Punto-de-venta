using Core.Dominio.Entidades;
using Core.interfaces;
using Core.CasosDeUso;
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

        // 1️⃣ Base de datos
        servicios.AddDbContext<PuntoVentaContex>(options =>
            options.UseSqlite("Data Source=PuntoDeVenta.db"));


        // 2️⃣ Lógica de negocio
        servicios.AddScoped<IUnitOfWork, UnitOfWork>();

        // 3️⃣ Ventana principal
        servicios.AddSingleton<MainWindow>();

        // 4️⃣ Registro automático de repositorios (SEGURO)
        var assembly = typeof(ClientesRepositorio).Assembly;

        var repos = assembly.GetTypes()
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                t.Name.EndsWith("Repositorio"));

        foreach (var impl in repos)
        {
            var interfaces = impl.GetInterfaces()
                .Where(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IRepositorio<>));

            foreach (var itf in interfaces)
            {
                servicios.AddScoped(itf, impl);
            }
        }

        return servicios.BuildServiceProvider();
    }
}
