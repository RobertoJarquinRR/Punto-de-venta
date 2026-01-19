using Core.CasosDeUso.Common;
using Core.Dominio.Entidades;
using Core.interfaces;


namespace Core.CasosDeUso.ProductoUsecase
{
    public class AgregarProductoUseCase
    {   
        private readonly IRepositorio<Productos> _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AgregarProductoUseCase(IRepositorio<Productos> ProductoRepository, IUnitOfWork unitOfWork )
        {
            _productoRepository = ProductoRepository;
            _unitOfWork = unitOfWork;


        }


        public async Task<Resultados> AgregarProductoAsync(string nombre, string descripcion, decimal precio, int stock)
        {
          
            try
            {
                var NuevoProcucto = new Productos(nombre, descripcion, precio, stock);
                await _productoRepository.AddAsync(NuevoProcucto);
                await _unitOfWork.SaveChangesAsync();
                return new Resultados
                {
                    Exitosa = true,
                    mensaje = "Producto agregado exitosamente"
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
