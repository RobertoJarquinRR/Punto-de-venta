using Core.CasosDeUso.Common;
using Core.Dominio.Entidades;
using Core.interfaces;


namespace Core.CasosDeUso.ProductoUsecase
{
    internal class EditarProductoUseCase
    {
        private readonly IRepositorio<Productos> _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        EditarProductoUseCase(IRepositorio<Productos> productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Resultados> EditarProductoAsync(int productoId, string nombre, string descripcion, decimal precio, int stock)
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
                
                productoExistente.UpdateDetails(nombre, descripcion, precio, stock);
                await _unitOfWork.SaveChangesAsync();
                return new Resultados
                {
                    Exitosa = true,
                    mensaje = "Producto editado exitosamente"
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
