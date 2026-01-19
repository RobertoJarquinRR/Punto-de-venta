using Core.CasosDeUso.Common;
using Core.Dominio.Entidades;
using Core.interfaces;

namespace Core.CasosDeUso.ProductoUsecase
{
    public class EliminarUsecase
    {
        private readonly IRepositorio<Productos> _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarUsecase(IRepositorio<Productos> productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Resultados> EliminarProductoAsync(int productoId)
        {
            
            try
            {
                await _productoRepository.DeleteAsync(productoId);
                await _unitOfWork.SaveChangesAsync();
                return new Resultados
                {
                    Exitosa = true,
                    mensaje = "Producto eliminado exitosamente"
                };
            }
            catch (Exception ex)
            {
                return new Resultados
                {
                    Exitosa = false,
                    mensaje = ex.Message
                };
            }
        }


    }
}
