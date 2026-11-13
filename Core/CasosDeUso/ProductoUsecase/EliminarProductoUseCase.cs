using Core.CasosDeUso.Common;
using Core.Dominio.Entidades;
using Core.interfaces;

namespace Core.CasosDeUso.ProductoUsecase
{
    public class EliminarProductoUseCase
    {
        private readonly IRepositorio<Productos> _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarProductoUseCase(IRepositorio<Productos> productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Resultados> EliminarProductoAsync(int productoId, CancellationToken ct = default)
        {
            if (productoId <= 0)
            {
                return new Resultados
                {
                    Exitosa = false,
                    mensaje = "El ID del producto no es válido."
                };
            }

            try
            {
                await _productoRepository.DeleteAsync(productoId, ct);
                await _unitOfWork.SaveChangesAsync(ct);

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
