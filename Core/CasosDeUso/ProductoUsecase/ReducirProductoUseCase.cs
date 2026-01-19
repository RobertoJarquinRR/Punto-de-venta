

using Core.CasosDeUso.Common;
using Core.Dominio.Entidades;
using Core.interfaces;

namespace Core.CasosDeUso.ProductoUsecase
{
    public class ReducirProductoUseCase
    {
        private readonly IRepositorio<Productos> _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ReducirProductoUseCase(IRepositorio<Productos> productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Resultados> ReducirStockProductoAsync(int productoId, int cantidadAReducir)
        {
            

            try
            {
                var productoExistente = await _productoRepository.GetByIdAsync(productoId);
                if (productoExistente == null)
                {
                    return new Resultados
                    {
                        Exitosa = false,
                        mensaje = "Producto no encontrado"
                    };
                }

                productoExistente.ReduceStock(cantidadAReducir);


                await _unitOfWork.SaveChangesAsync();
                return new Resultados
                {
                    Exitosa = true,
                    mensaje = "Stock reducido exitosamente"
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
