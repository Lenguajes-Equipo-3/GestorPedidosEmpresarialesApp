using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class ProductoVarianteViewModel : ObservableObject
    {
        private readonly ProductoVarianteService _productoVarianteService = new();
        private readonly ProductoBaseService _productoBaseService = new();

        [ObservableProperty]
        private ObservableCollection<ProductoVariante> variantes;

        [ObservableProperty]
        private ObservableCollection<ProductoBase> productosBase;

        [ObservableProperty]
        private ProductoVariante? varianteSeleccionada;

        public IRelayCommand CargarVariantesCommand { get; }
        public IRelayCommand CargarProductosBaseCommand { get; }
        public IRelayCommand GuardarVarianteCommand { get; }
        public IRelayCommand EliminarVarianteCommand { get; }

        public ProductoVarianteViewModel()
        {
            variantes = new ObservableCollection<ProductoVariante>();
            productosBase = new ObservableCollection<ProductoBase>();

            CargarVariantesCommand = new AsyncRelayCommand(CargarVariantesAsync);
            CargarProductosBaseCommand = new AsyncRelayCommand(CargarProductosBaseAsync);
            GuardarVarianteCommand = new AsyncRelayCommand(GuardarVarianteAsync);
            EliminarVarianteCommand = new AsyncRelayCommand(EliminarVarianteAsync);

            _ = CargarVariantesAsync();
            _ = CargarProductosBaseAsync();
        }

        private async Task CargarVariantesAsync()
        {
            var variantesObtenidas = await _productoVarianteService.GetAllAsync();
            if (variantesObtenidas != null)
            {
                Variantes.Clear();
                foreach (var variante in variantesObtenidas)
                {
                    Variantes.Add(variante);
                }
            }
            else
            {
                MessageBox.Show("Error al cargar las variantes de producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task CargarProductosBaseAsync()
        {
            var productosObtenidos = await _productoBaseService.GetAllAsync();
            if (productosObtenidos != null)
            {
                ProductosBase.Clear();
                foreach (var producto in productosObtenidos)
                {
                    ProductosBase.Add(producto);
                }
            }
            else
            {
                MessageBox.Show("Error al cargar los productos base.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task GuardarVarianteAsync()
        {
            if (VarianteSeleccionada != null)
            {
                bool resultado;
                if (VarianteSeleccionada.IdVariante == 0)
                {
                    resultado = await _productoVarianteService.CreateAsync(VarianteSeleccionada);
                }
                else
                {
                    resultado = await _productoVarianteService.UpdateAsync(VarianteSeleccionada.IdVariante, VarianteSeleccionada);
                }

                if (resultado)
                {
                    MessageBox.Show("Variante guardada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    await CargarVariantesAsync();
                }
                else
                {
                    MessageBox.Show("Error al guardar la variante.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task EliminarVarianteAsync()
        {
            if (VarianteSeleccionada != null)
            {
                var resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar la variante '{VarianteSeleccionada.Descripcion}'?",
                                                "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    bool eliminado = await _productoVarianteService.DeleteAsync(VarianteSeleccionada.IdVariante);
                    if (eliminado)
                    {
                        MessageBox.Show("Variante eliminada correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        await CargarVariantesAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la variante.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}