using Core.Dominio.Entidades;
using Data.Repositorios.Maestras;

public class ClientesTests
{
    [Fact]
    public void Constructor_ConDatosValidos_CreaCliente()
    {
        var cliente = new Clientes("Ana", "Calle 1", "555-1234", "ana@example.com");

        Assert.Equal("Ana", cliente.Nombre);
        Assert.Equal("Calle 1", cliente.direccion);
        Assert.Equal("555-1234", cliente.telefono);
        Assert.Equal("ana@example.com", cliente.email);
    }

    [Theory]
    [InlineData("correo")]
    [InlineData("ana@")]
    [InlineData("ana@example")]
    [InlineData("@example.com")]
    [InlineData("ana @example.com")]
    public void Constructor_ConEmailInvalido_LanzaArgumentException(string email)
    {
        Assert.Throws<ArgumentException>(
            () => new Clientes("Ana", "Calle 1", "555-1234", email));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_ConNombreVacio_LanzaArgumentException(string nombre)
    {
        Assert.Throws<ArgumentException>(
            () => new Clientes(nombre, "Calle 1", "555-1234", "ana@example.com"));
    }

    [Fact]
    public void UpdateDetails_ConEmailInvalido_LanzaArgumentException()
    {
        var cliente = new Clientes("Ana", "Calle 1", "555-1234", "ana@example.com");

        Assert.Throws<ArgumentException>(
            () => cliente.UpdateDetails("Ana", "Calle 1", "555-1234", "correo"));
    }
}

public class ClientesRepositorioTests
{
    [Fact]
    public async Task AddAsync_GuardaCliente()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);
            var cliente = new Clientes("Ana", "Calle 1", "555-1234", "ana@example.com");

            await repo.AddAsync(cliente);
            await ctx.SaveChangesAsync();

            Assert.True(cliente.Id > 0);
            Assert.NotNull(await ctx.clientes.FindAsync(cliente.Id));
        }
    }

    [Fact]
    public async Task GetByIdAsync_CuandoNoExiste_RetornaNull()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);

            var cliente = await repo.GetByIdAsync(999999);

            Assert.Null(cliente);
        }
    }

    [Fact]
    public async Task GetAllAsync_RetornaTodosLosClientes()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);

            await repo.AddAsync(new Clientes("Ana", "Calle 1", "555-1234", "ana@example.com"));
            await repo.AddAsync(new Clientes("Luis", "Calle 2", "555-5678", "luis@example.com"));
            await ctx.SaveChangesAsync();

            var lista = await repo.GetAllAsync();

            Assert.Equal(2, lista.Count);
        }
    }

    [Fact]
    public async Task UpdateDetails_PersisteCambios()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        {
            int clienteId;

            using (ctx)
            {
                var repo = new ClientesRepositorio(ctx);
                var cliente = new Clientes("Ana", "Calle 1", "555-1234", "ana@example.com");
                await repo.AddAsync(cliente);
                await ctx.SaveChangesAsync();
                clienteId = cliente.Id;
            }

            using (var ctxUpdate = DbTestFactory.CreateContext(conn))
            {
                var repo = new ClientesRepositorio(ctxUpdate);
                var cliente = await repo.GetByIdAsync(clienteId);

                Assert.NotNull(cliente);
                cliente.UpdateDetails("Ana Maria", "Calle 1", "555-9999", "ana.maria@example.com");
                await ctxUpdate.SaveChangesAsync();
            }

            using (var ctxAssert = DbTestFactory.CreateContext(conn))
            {
                var cliente = await ctxAssert.clientes.FindAsync(clienteId);

                Assert.NotNull(cliente);
                Assert.Equal("Ana Maria", cliente.Nombre);
                Assert.Equal("ana.maria@example.com", cliente.email);
            }
        }
    }

    [Fact]
    public async Task DeleteAsync_EliminaCliente()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);
            var cliente = new Clientes("Ana", "Calle 1", "555-1234", "ana@example.com");

            await repo.AddAsync(cliente);
            await ctx.SaveChangesAsync();

            await repo.DeleteAsync(cliente.Id);
            await ctx.SaveChangesAsync();

            Assert.Null(await ctx.clientes.FindAsync(cliente.Id));
        }
    }

    [Fact]
    public async Task DeleteAsync_CuandoNoExiste_NoLanza()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);

            await repo.DeleteAsync(999999);
            await ctx.SaveChangesAsync();
        }
    }
}
