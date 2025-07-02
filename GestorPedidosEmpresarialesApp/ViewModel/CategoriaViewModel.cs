using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class CategoriaViewModel : ObservableObject
    {
        private readonly CategoriaService _categoriaService = new();

        [ObservableProperty]
        private ObservableCollection<Categoria> categorias;

        [ObservableProperty]
        private Categoria? categoriaSeleccionada;

        public IRelayCommand CargarCategoriasCommand { get; }
        public IRelayCommand GuardarCategoriaCommand { get; }
        public IRelayCommand EliminarCategoriaCommand { get; }

        public CategoriaViewModel()
        {
            categorias = new ObservableCollection<Categoria>();
            CargarCategoriasCommand = new AsyncRelayCommand(CargarCategoriasAsync);
            GuardarCategoriaCommand = new AsyncRelayCommand(GuardarCategoriaAsync);
            EliminarCategoriaCommand = new AsyncRelayCommand(EliminarCategoriaAsync);
            _ = CargarCategoriasAsync();
        }

        private async Task CargarCategoriasAsync()
        {
            var categoriasObtenidas = await _categoriaService.GetAllAsync();
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

        private async Task GuardarCategoriaAsync()
        {
            if (categoriaSeleccionada != null)
            {
                bool resultado;
                if (categoriaSeleccionada.IdCategoria == 0)
                {
                    resultado = await _categoriaService.CreateAsync(categoriaSeleccionada);
                }
                else
                {
                    resultado = await _categoriaService.UpdateAsync(categoriaSeleccionada.IdCategoria, categoriaSeleccionada);
                }

                if (resultado)
                {
                    MessageBox.Show("Categor�a guardada correctamente.", "�xito", MessageBoxButton.OK, MessageBoxImage.Information);
                    await CargarCategoriasAsync();
                }
                else
                {
                    MessageBox.Show("Error al guardar la categor�a.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task EliminarCategoriaAsync()
        {
            if (categoriaSeleccionada != null)
            {
                var resultado = MessageBox.Show($"�Est�s seguro de que deseas eliminar la categor�a '{categoriaSeleccionada.Descripcion}'?",
                                                "Confirmar eliminaci�n", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    bool eliminado = await _categoriaService.DeleteAsync(categoriaSeleccionada.IdCategoria);
                    if (eliminado)
                    {
                        MessageBox.Show("Categor�a eliminada correctamente.", "�xito", MessageBoxButton.OK, MessageBoxImage.Information);
                        await CargarCategoriasAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la categor�a.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}