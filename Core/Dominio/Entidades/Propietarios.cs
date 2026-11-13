using Core.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Dominio.Entidades
{
    public class Propietarios: IidentidaID
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string nombreUsuario { get; private set; } = null!;
        public string contrasena { get; private set; } = null!;
        public int telefono { get; private set; }


        private Propietarios()
        {
        }

        public Propietarios(string nombreUsuario, string contrasena, int telefono)
        {
            this.nombreUsuario = nombreUsuario;
            this.contrasena = contrasena;
            this.telefono = telefono;
        }


        public void UpdateDetails(string nombreUsuario, string contrasena, int telefono)
        {
            this.nombreUsuario = nombreUsuario;
            this.contrasena = contrasena;
            this.telefono = telefono;
        }
    }
}
