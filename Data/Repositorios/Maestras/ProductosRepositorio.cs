using Core.Dominio.Entidades;
using Core.interfaces;

namespace Data.Repositorios.Maestras
{
    public class ProductosRepositorio : RepositorioBase<Productos>
    {
       public ProductosRepositorio(PuntoVentaContex context) : base(context) { }

        protected override void MapearCambios(Productos existingEntity, Productos newEntity)
        {
            existingEntity.UpdateDetails(
                newEntity.nombre,
                newEntity.descripcion,
                newEntity.precio,
                newEntity.stock
            );
        }
    }
}
