// DbTestFactory.cs
using Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public static class DbTestFactory
{
    public static (PuntoVentaContex ctx, SqliteConnection conn) CreateContext()
    {
        var conn = new SqliteConnection("DataSource=:memory:");
        conn.Open();

        var options = new DbContextOptionsBuilder<PuntoVentaContex>()
            .UseSqlite(conn)
            .Options;

        var ctx = new PuntoVentaContex(options);
        ctx.Database.EnsureCreated();

        return (ctx, conn);
    }
}
