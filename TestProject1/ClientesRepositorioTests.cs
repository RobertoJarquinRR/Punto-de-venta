/*using Xunit;
using Core.Dominio.Entidades;
using Data.Repositorios.Maestras;

public class ClientesRepositorioTests
{
    [Fact]
    public void Add_GuardaCliente()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);

            // Uso del constructor en lugar de inicializador de objetos
            var cliente = new Clientes("Ana", "X", "123", "a@a.com");

            var r = repo.Add(cliente);

            Assert.True(r.Exitosa, r.mensaje);
            Assert.True(cliente.Id > 0);
            Assert.NotNull(ctx.clientes.Find(cliente.Id));
        }
    }

    
    [Fact]
    public void Update_ActualizaCliente_DeFormaReal()
    {
        // 1. Arrange: Guardar en un contexto
        using (var context = DbTestFactory.CreateContext().ctx)
        {
            var repo = new ClientesRepositorio(context);
            var cliente = new Clientes("Ana", "X", "123", "a@a.com");
            repo.Add(cliente);
            context.SaveChanges();
        }

        // 2. Act: Modificar en otro contexto (simulando una nueva petición)
        using (var context = DbTestFactory.CreateContext().ctx)
        {
            var repo = new ClientesRepositorio(context);
            var cliente = repo.GetById(1); // El ID 1
            cliente.UpdateDetails("Ana Maria", "X", "123", "a@a.com");
            repo.Update(cliente);
            context.SaveChanges();
        }

        // 3. Assert: Verificar en un TERCER contexto
        using (var context = DbTestFactory.CreateContext().ctx)
        {
            var clienteDb = context.clientes.Find(1);
            Assert.Equal("Ana Maria", clienteDb.Nombre);
        }
    }

    [Fact]
    public void Delete_EliminaCliente()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);

            var cliente = new Clientes("Ana", "X", "123", "a@a.com");
            var add = repo.Add(cliente);
            Assert.True(add.Exitosa, add.mensaje);

            var r = repo.Delete(cliente);

            Assert.True(r.Exitosa, r.mensaje);
            Assert.Null(ctx.clientes.Find(cliente.Id));
        }
    }

    [Fact]
    public void GetById_SiNoExiste_RetornaNull()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);

            var cliente = repo.GetById(999999);

            Assert.Null(cliente);
        }
    }

    [Fact]
    public void GetAll_RetornaLista()
    {
        var (ctx, conn) = DbTestFactory.CreateContext();
        using (conn)
        using (ctx)
        {
            var repo = new ClientesRepositorio(ctx);

            // Creamos instancias mediante el constructor
            var clienteA = new Clientes("Ana", "X", "123", "a@a.com");
            var clienteB = new Clientes("Luis", "Y", "456", "l@l.com");

            repo.Add(clienteA);
            repo.Add(clienteB);

            var lista = repo.GetAll();

            Assert.NotNull(lista);
            Assert.Equal(2, lista.Count);
        }
    }
}*/