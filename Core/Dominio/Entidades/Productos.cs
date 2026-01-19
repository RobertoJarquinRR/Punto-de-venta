using Core.interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dominio.Entidades
{
    public class Productos: IidentidaID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string nombre { get; private set; }
        public string descripcion { get; private set; }
        public decimal precio { get; private set; }
        public int stock { get; private set; }


        private Productos()
        {
        }

        public Productos(string nombre, string descripcion, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            else if (precio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo.");
            }
            else if (stock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }
            else if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");

            }


            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }


        public void UpdateDetails(string nombre, string descripcion, decimal precio, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            else if (precio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo.");
            }
            else if (stock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }
            else if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");

            }


            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }


        public void ReduceStock(int cantidad)
        {
            if (cantidad > stock)
            {
                throw new InvalidOperationException("No hay suficiente stock disponible.");
            }
            stock -= cantidad;
        }

        public void IncreaseStock(int cantidad)
        {
            stock += cantidad;
        }

       


    }

    
}
