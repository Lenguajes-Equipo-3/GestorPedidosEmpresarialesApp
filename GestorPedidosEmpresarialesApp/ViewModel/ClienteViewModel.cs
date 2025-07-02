using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class ClienteViewModel : ObservableObject
    {
        private readonly ClienteService _clienteService = new();

        [ObservableProperty]
        private Cliente cliente = new();

        [ObservableProperty]
        private Cliente? clienteSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Cliente> clientesCargados = new();

        public IRelayCommand GuardarClienteCommand { get; }
        public IRelayCommand<Cliente> EliminarClienteCommand { get; }

        public ClienteViewModel()
        {
            GuardarClienteCommand = new AsyncRelayCommand(GuardarClienteAsync);
            EliminarClienteCommand = new AsyncRelayCommand<Cliente>(EliminarClienteAsync);

            _ = CargarClientesAsync();
        }

        partial void OnClienteSeleccionadoChanged(Cliente? value)
        {
            if (value != null)
            {
                Cliente = new Cliente
                {
                    IdCliente = value.IdCliente,
                    NombreCompania = value.NombreCompania,
                    NombreContacto = value.NombreContacto,
                    ApellidoContacto = value.ApellidoContacto,
                    PuestoContacto = value.PuestoContacto,
                    Direccion = value.Direccion,
                    Ciudad = value.Ciudad,
                    Provincia = value.Provincia,
                    CodigoPostal = value.CodigoPostal,
                    Pais = value.Pais,
                    Telefono = value.Telefono,
                    //Eliminado = value.Eliminado
                };
            }
        }


        private async Task CargarClientesAsync()
        {
            var clientes = await _clienteService.GetAllAsync();
            if (clientes != null)
            {
                clientesCargados.Clear();
                foreach (var c in clientes)
                    clientesCargados.Add(c);
            }
            else
            {
                MessageBox.Show("Error al cargar los clientes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task GuardarClienteAsync()
        {
            bool resultado;
            if (cliente.IdCliente == 0)
                resultado = await _clienteService.CreateAsync(cliente);
            else
                resultado = await _clienteService.UpdateAsync(cliente.IdCliente, cliente);

            if (resultado)
            {
                await CargarClientesAsync();
                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error al guardar el cliente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task EliminarClienteAsync(Cliente? cliente)
        {
            if (cliente != null)
            {
                var resultado = MessageBox.Show($"¿Está seguro que desea eliminar al cliente '{cliente.NombreCompania}'?",
                                                "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    bool eliminado = await _clienteService.DeleteAsync(cliente.IdCliente);
                    if (eliminado)
                    {
                        clientesCargados.Remove(cliente);
                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


    }
}
