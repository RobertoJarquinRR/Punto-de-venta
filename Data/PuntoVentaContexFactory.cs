using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class PuntoVentaContexFactory : IDesignTimeDbContextFactory<PuntoVentaContex>
    {
        public PuntoVentaContex CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<PuntoVentaContex>()
                .UseSqlite("Data Source=PuntoDeVenta.db")
                .Options;

            return new PuntoVentaContex(options);
        }
    }
}
