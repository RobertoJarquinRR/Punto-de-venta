using Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public static class DbTestFactory
{
    public static (PuntoVentaContex ctx, SqliteConnection conn) CreateContext()
    {
        var conn = new SqliteConnection("DataSource=:memory:");
        conn.Open();

        var ctx = CreateContext(conn);
        ctx.Database.Migrate();

        return (ctx, conn);
    }

    public static PuntoVentaContex CreateContext(SqliteConnection conn)
    {
        var options = new DbContextOptionsBuilder<PuntoVentaContex>()
            .UseSqlite(conn)
            .Options;

        return new PuntoVentaContex(options);
    }
}
