using Core.interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dominio.Entidades
{
    public class Clientes:IidentidaID
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public  int Id { get; private set; }
        public  string Nombre { get; private set; }
        public string direccion { get; private set; }
        public string telefono { get; private set; }

        public string email { get; private set; }


        private Clientes()
        {
        }

        public Clientes(string nombre, string direccion, string telefono, string email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            else if (string.IsNullOrWhiteSpace(direccion))
            {
                throw new ArgumentException("La dirección no puede estar vacía.");
            }
            else if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El teléfono no puede estar vacío.");
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email no puede estar vacío.");
            }
            else if (!email.Contains("@"))
            {
                throw new ArgumentException("El email no es válido.");
            }
            Nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
        }


        public void UpdateDetails(string nombre, string direccion, string telefono, string email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            else if (string.IsNullOrWhiteSpace(direccion))
            {
                throw new ArgumentException("La dirección no puede estar vacía.");
            }
            else if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El teléfono no puede estar vacío.");
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email no puede estar vacío.");
            }
            else if (!email.Contains("@"))
            {
                throw new ArgumentException("El email no es válido.");
            }
           

                Nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
        }

        public void Add(string nombre, string direccion, string telefono, string email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
            else if (string.IsNullOrWhiteSpace(direccion))
            {
                throw new ArgumentException("La dirección no puede estar vacía.");
            }
            else if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El teléfono no puede estar vacío.");
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email no puede estar vacío.");
            }
            else if (!email.Contains("@"))
            {
                throw new ArgumentException("El email no es válido.");
            }
            Nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
        }

    }
}
