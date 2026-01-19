using Core.CasosDeUso.Common;
using Core.Dominio.Entidades;
using Core.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CasosDeUso.ProductoUsecase
{
    public class OptenerUseCase
    {
        readonly IRepositorio<Productos> _productoRepository;
        readonly IUnitOfWork _unitOfWork;

        public OptenerUseCase(IRepositorio<Productos> productoRepository, IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

     
        public Task<Resultados> OptenerBaseDatosAsync()
        {
            try
            {
                var productos =  _productoRepository.GetAllAsync();
                return Task.FromResult(new Resultados
                {
                    Exitosa = true,
                    mensaje = "Productos obtenidos exitosamente",
                   
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Resultados
                {
                    Exitosa = false,
                    mensaje = ex.Message
                });
            }
        }

        public Task<Resultados> OptenerPorIdAsync(int productoId)
        {
            if (productoId <= 0)
            {
                return Task.FromResult(new Resultados
                {
                    Exitosa = false,
                    mensaje = "El ID del producto no es válido."
                });
            }

            try
            {
                var producto =  _productoRepository.GetByIdAsync(productoId);

                return Task.FromResult(new Resultados
                {
                    Exitosa = true,
                    mensaje = "Producto obtenido exitosamente",
                   
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Resultados
                {
                    Exitosa = false,
                    mensaje = ex.Message
                });
            }
        }






    }
}
