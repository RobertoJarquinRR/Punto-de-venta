using Core.interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dominio.Entidades
{
    public class Productos : IidentidaID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string nombre { get; private set; } = null!;
        public string descripcion { get; private set; } = null!;
        public decimal precio { get; private set; }
        public int stock { get; private set; }

        private Productos()
        {
        }

        public Productos(string nombre, string descripcion, decimal precio, int stock)
        {
            Validar(nombre, descripcion, precio, stock);

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }

        public void UpdateDetails(string nombre, string descripcion, decimal precio, int stock)
        {
            Validar(nombre, descripcion, precio, stock);

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }

        public void ReduceStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad a reducir debe ser mayor que cero.");

            if (cantidad > stock)
                throw new InvalidOperationException("No hay suficiente stock disponible.");

            stock -= cantidad;
        }

        public void IncreaseStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad a aumentar debe ser mayor que cero.");

            stock += cantidad;
        }

        private static void Validar(string nombre, string descripcion, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));

            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo.", nameof(precio));

            if (stock < 0)
                throw new ArgumentException("El stock no puede ser negativo.", nameof(stock));

            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción no puede estar vacía.", nameof(descripcion));
        }
    }
}
