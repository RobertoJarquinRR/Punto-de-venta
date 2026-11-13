using Core.CasosDeUso.Common;
using Core.Dominio.Entidades;
using Core.interfaces;

namespace Core.CasosDeUso.ProductoUsecase
{
    public class ObtenerProductoUseCase
    {
        private readonly IRepositorio<Productos> _productoRepository;

        public ObtenerProductoUseCase(IRepositorio<Productos> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<(Resultados resultado, List<Productos>? productos)> ObtenerProductosAsync(CancellationToken ct = default)
        {
            try
            {
                var productos = await _productoRepository.GetAllAsync(ct);

                return (new Resultados
                {
                    Exitosa = true,
                    mensaje = "Productos obtenidos exitosamente"
                }, productos);
            }
            catch (Exception ex)
            {
                return (new Resultados
                {
                    Exitosa = false,
                    mensaje = ex.Message
                }, null);
            }
        }

        public async Task<(Resultados resultado, Productos? producto)> ObtenerPorIdAsync(int productoId, CancellationToken ct = default)
        {
            if (productoId <= 0)
            {
                return (new Resultados
                {
                    Exitosa = false,
                    mensaje = "El ID del producto no es válido."
                }, null);
            }

            try
            {
                var producto = await _productoRepository.GetByIdAsync(productoId, ct);

                if (producto is null)
                {
                    return (new Resultados
                    {
                        Exitosa = false,
                        mensaje = "Producto no encontrado"
                    }, null);
                }

                return (new Resultados
                {
                    Exitosa = true,
                    mensaje = "Producto obtenido exitosamente"
                }, producto);
            }
            catch (Exception ex)
            {
                return (new Resultados
                {
                    Exitosa = false,
                    mensaje = ex.Message
                }, null);
            }
        }
    }
}
