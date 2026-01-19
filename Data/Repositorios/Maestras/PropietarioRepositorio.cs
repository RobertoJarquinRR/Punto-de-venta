using Core.Dominio.Entidades;
using Core.interfaces;


namespace Data.Repositorios.Maestras
{
    public class PropietarioRepositorio : RepositorioBase<Propietarios>
    {
        public PropietarioRepositorio(PuntoVentaContex context) : base(context) { }
        protected override void MapearCambios(Propietarios existingEntity, Propietarios newEntity)
        {
           existingEntity.UpdateDetails(
                newEntity.nombreUsuario,
                newEntity.contrasena,
                newEntity.telefono
                
            );

        }
    }
}
