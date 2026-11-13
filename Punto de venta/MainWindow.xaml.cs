using System.Windows;
using Core.CasosDeUso.ProductoUsecase;

namespace Punto_de_venta
{
    public partial class MainWindow : Window
    {
        private readonly ObtenerProductoUseCase _obtenerProductos;

        public MainWindow(ObtenerProductoUseCase obtenerProductos)
        {
            InitializeComponent();
            _obtenerProductos = obtenerProductos;
            Loaded += async (_, _) => await CargarProductosAsync();
        }

        private async Task CargarProductosAsync()
        {
            var (resultado, productos) = await _obtenerProductos.ObtenerProductosAsync();

            if (!resultado.Exitosa)
            {
                MessageBox.Show(resultado.mensaje, "Error al cargar productos");
            }
        }
    }
}
