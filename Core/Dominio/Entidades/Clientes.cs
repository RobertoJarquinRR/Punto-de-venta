using Core.interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Core.Dominio.Entidades
{
    public class Clientes : IidentidaID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string direccion { get; private set; } = null!;
        public string telefono { get; private set; } = null!;
        public string email { get; private set; } = null!;

        private Clientes()
        {
        }

        public Clientes(string nombre, string direccion, string telefono, string email)
        {
            Validar(nombre, direccion, telefono, email);

            Nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
        }

        public void UpdateDetails(string nombre, string direccion, string telefono, string email)
        {
            Validar(nombre, direccion, telefono, email);

            Nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
        }

        private static void Validar(string nombre, string direccion, string telefono, string email)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));

            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección no puede estar vacía.", nameof(direccion));

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede estar vacío.", nameof(telefono));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.", nameof(email));

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El email no es válido.", nameof(email));
        }
    }
}
