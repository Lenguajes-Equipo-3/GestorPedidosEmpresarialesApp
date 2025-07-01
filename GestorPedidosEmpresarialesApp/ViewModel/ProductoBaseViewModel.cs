using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using GestorPedidosEmpresarialesApp.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class ProductoBaseViewModel : ObservableObject
    {
        private readonly ProductoBaseService _productoBaseService = new();

        [ObservableProperty]
        private ObservableCollection<ProductoBase> productosBase;

        [ObservableProperty]
        private ProductoBase? productoSeleccionado;

        public IRelayCommand CargarProductosCommand { get; }
        public IRelayCommand EliminarProductoCommand { get; }
        public IRelayCommand ActualizarProductoCommand { get; }
        public IRelayCommand EditarProductoCommand { get; }

        public ProductoBaseViewModel()
        {
            productosBase = new ObservableCollection<ProductoBase>();
            CargarProductosAsync(); // Carga los productos al inicializar el ViewModel
            EliminarProductoCommand = new AsyncRelayCommand<ProductoBase>(EliminarProductoAsync);
            EditarProductoCommand = new RelayCommand<ProductoBase>(EditarProducto);
        }

        private async Task CargarProductosAsync()
        {
            var productos = await _productoBaseService.GetAllAsync();
            if (productos != null)
            {
                ProductosBase.Clear();
                foreach (var producto in productos)
                {
                    ProductosBase.Add(producto);
                }
            }
        }

        private async Task EliminarProductoAsync(ProductoBase? producto)
        {
            if (producto != null)
            {
                var resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el producto '{producto.NombreProducto}'?", 
                                                "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    bool eliminado = await _productoBaseService.DeleteAsync(producto.IdProductoBase);
                    if (eliminado)
                    {
                        MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        await CargarProductosAsync(); // Recarga los productos después de eliminar
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void EditarProducto(ProductoBase? producto)
        {
            if (producto != null)
            {
               
                CargarProductosAsync(); // Recarga los productos después de editar
            }
        }
    }
}