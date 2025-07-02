using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System.Threading.Tasks;
using System.Windows;

public partial class EditarProductoBaseViewModel : ObservableObject
{
    private readonly ProductoBaseService _productoBaseService = new();

    [ObservableProperty]
    private ProductoBase producto;

    public IRelayCommand GuardarCambiosCommand { get; }

    public EditarProductoBaseViewModel(ProductoBase producto)
    {
        this.producto = producto;
        GuardarCambiosCommand = new AsyncRelayCommand(GuardarCambiosAsync);
    }

    private async Task GuardarCambiosAsync()
    {
        bool actualizado = await _productoBaseService.UpdateAsync(producto.IdProductoBase, producto);
        if (actualizado)
        {
            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Error al actualizar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}