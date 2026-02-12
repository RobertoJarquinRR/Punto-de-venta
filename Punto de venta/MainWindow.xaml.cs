using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using Core.CasosDeUso.ProductoUsecase;
using Core.CasosDeUso.Common;


namespace Punto_de_venta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly OptenerUseCase _optener;
        private readonly EliminarUsecase _eliminar;

        public MainWindow(OptenerUseCase todo, EliminarUsecase eliminar)
        {
            InitializeComponent();
            _optener = todo;
            _eliminar = eliminar;
            cargardatos();



        }
   

        async public void cargardatos()
        {
            var (resultado, listaProductos) = await _optener.ObtenerProductosAsync();
            
           var resultados = await _eliminar.EliminarProductoAsync(3);
            MessageBox.Show(resultados.mensaje);
        }
    }

}
