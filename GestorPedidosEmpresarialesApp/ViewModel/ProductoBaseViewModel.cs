using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class ProductoBaseViewModel : ObservableObject
    {
        private readonly ProductoBaseService _productoBaseService = new();

        [ObservableProperty]
        private ProductoBase producto;

        [ObservableProperty]
        private ProductoBase? productoSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Categoria> categorias;

        [ObservableProperty]
        private ObservableCollection<ProductoBase> productosCargados;

        public IRelayCommand GuardarProductoCommand { get; }
        public IRelayCommand<ProductoBase> EliminarProductoCommand { get; }

        public ProductoBaseViewModel()
        {
            producto = new ProductoBase();
            categorias = new ObservableCollection<Categoria>();
            productosCargados = new ObservableCollection<ProductoBase>();

            GuardarProductoCommand = new AsyncRelayCommand(GuardarProductoAsync);
            EliminarProductoCommand = new AsyncRelayCommand<ProductoBase>(EliminarProductoAsync);

            CargarCategoriasAsync();
            CargarProductosAsync();
        }

        partial void OnProductoSeleccionadoChanged(ProductoBase? value)
        {
            if (value != null)
            {
                Producto = new ProductoBase
                {
                    IdProductoBase = value.IdProductoBase,
                    NombreProducto = value.NombreProducto,
                    Categoria = value.Categoria,
                    Eliminado = value.Eliminado
                };
            }
        }

        private async Task CargarCategoriasAsync()
        {
            var categoriasObtenidas = await _productoBaseService.GetAllCategoriasAsync();
            if (categoriasObtenidas != null)
            {
                categorias.Clear();
                foreach (var categoria in categoriasObtenidas)
                {
                    categorias.Add(categoria);
                }
            }
            else
            {
                MessageBox.Show("Error al cargar las categor�as.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task CargarProductosAsync()
        {
            var productosObtenidos = await _productoBaseService.GetAllAsync();
            if (productosObtenidos != null)
            {
                productosCargados.Clear();
                foreach (var producto in productosObtenidos)
                {
                    productosCargados.Add(producto);
                }
            }
            else
            {
                MessageBox.Show("Error al cargar los productos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task GuardarProductoAsync()
        {
            bool resultado;
            if (Producto.IdProductoBase == 0)
            {
                resultado = await _productoBaseService.CreateAsync(Producto);
            }
            else
            {
                resultado = await _productoBaseService.UpdateAsync(Producto.IdProductoBase, Producto);
            }

            if (resultado)
            {
                await CargarProductosAsync();
                MessageBox.Show("Producto guardado correctamente.", "�xito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task EliminarProductoAsync(ProductoBase? producto)
        {
            if (producto != null)
            {
                var resultado = MessageBox.Show($"�Est�s seguro de que deseas eliminar el producto '{producto.NombreProducto}'?",
                                                "Confirmar eliminaci�n", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    bool eliminado = await _productoBaseService.DeleteAsync(producto.IdProductoBase);
                    if (eliminado)
                    {
                        productosCargados.Remove(producto);
                        MessageBox.Show("Producto eliminado correctamente.", "�xito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}