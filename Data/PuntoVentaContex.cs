using Core.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PuntoVentaContex : DbContext
    {
        public PuntoVentaContex(DbContextOptions<PuntoVentaContex> Opciones)
            : base(Opciones)
        {


        }

        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Facturas> facturas { get; set; }
        public DbSet<Propietarios> propietarios { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<Productos> productos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>().ToTable("Cliente");
            modelBuilder.Entity<Facturas>().ToTable("Factura");
            modelBuilder.Entity<Propietarios>().ToTable("Propietario");
            modelBuilder.Entity<Ventas>().ToTable("Venta");
            modelBuilder.Entity<Productos>().ToTable("Producto");

        }
        
    }
}
        

