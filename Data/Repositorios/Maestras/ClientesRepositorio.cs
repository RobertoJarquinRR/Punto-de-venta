using Core.interfaces;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Core.Dominio.Entidades;

namespace Data.Repositorios.Maestras
{
    public class ClientesRepositorio : RepositorioBase<Clientes>
    {

        public ClientesRepositorio(PuntoVentaContex context) : base(context) { }

        protected override void MapearCambios(Clientes existingEntity, Clientes newEntity)
        {
            existingEntity.UpdateDetails(
                newEntity.Nombre,
                newEntity.direccion,
                newEntity.telefono,
                newEntity.email
            );
            

        }
    }
}
