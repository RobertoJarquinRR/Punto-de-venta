using Core.Dominio.Entidades;
using Core.interfaces;


namespace Data.Repositorios.Transaccionales
{
    public class VentasRepositorio : RepositorioBase<Ventas>
    {
      public VentasRepositorio(PuntoVentaContex context) : base(context) { }
        protected override void MapearCambios(Ventas existingEntity, Ventas newEntity)
        {
           existingEntity.UpdateDetails(
               newEntity.facturaId,
               newEntity.productoId,
               newEntity.cantidad,
               newEntity.precioUnitario,
               newEntity.total
           );

        }
    }
}
