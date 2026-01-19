using Core.Dominio.Entidades;
using Core.interfaces;


namespace Data.Repositorios.Transaccionales
{
    public class FacturaRepositorio : RepositorioBase<Facturas>
        {
        public FacturaRepositorio(PuntoVentaContex context) : base(context) { }
        protected override void MapearCambios(Facturas existingEntity, Facturas newEntity)
        {
          existingEntity.UpdateDetails(newEntity.propietarioId, newEntity.clienteId, newEntity.fecha, newEntity.total);
        }
    }
   
}
