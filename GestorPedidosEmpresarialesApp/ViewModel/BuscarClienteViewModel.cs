using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class BuscarClienteViewModel : ObservableObject
    {
        private readonly ClienteService _clienteService = new();
        [ObservableProperty] private string filtro = "";
        [ObservableProperty] private ObservableCollection<Cliente> clientesFiltrados = new();
        [ObservableProperty] private Cliente? clienteSeleccionado;

        public BuscarClienteViewModel()
        {
            _ = CargarClientesAsync();
        }

        private async Task CargarClientesAsync()
        {
            var lista = await _clienteService.GetAllAsync();
            ClientesFiltrados = new(lista);
        }

        [RelayCommand]
        private void Buscar()
        {
            if (string.IsNullOrWhiteSpace(Filtro))
            {
                _ = CargarClientesAsync();
            }
            else
            {
                var filtrados = ClientesFiltrados.Where(c =>
                        (!string.IsNullOrEmpty(c.NombreContacto) && c.NombreContacto.ToLower().Contains(Filtro.ToLower())) ||
                        (!string.IsNullOrEmpty(c.ApellidoContacto) && c.ApellidoContacto.ToLower().Contains(Filtro.ToLower())))
                    .ToList();
                ClientesFiltrados = new ObservableCollection<Cliente>(filtrados);
            }
        }

        [RelayCommand]
        private void Seleccionar()
        {
            // Solo cierra la ventana, el cliente ya está en ClienteSeleccionado
            // El View (Window) debe recoger el valor.
        }
    }
}
