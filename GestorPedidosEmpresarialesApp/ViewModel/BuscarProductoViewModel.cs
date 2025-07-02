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
    public partial class BuscarProductoViewModel : ObservableObject
    {
        private readonly ProductoVarianteService _productoService = new();

        [ObservableProperty]
        private string filtroNombre = "";

        [ObservableProperty]
        private ObservableCollection<ProductoVariante> productosFiltrados = new();

        [ObservableProperty]
        private ProductoVariante? productoSeleccionado;

        private List<ProductoVariante> todosLosProductos = new();

        // Constructor
        public BuscarProductoViewModel()
        {
            _ = CargarProductosAsync();
        }

        // Método para cargar productos del API
        public async Task CargarProductosAsync()
        {
            var productos = await _productoService.GetAllAsync();
            if (productos != null)
            {
                todosLosProductos = productos.ToList();
                ProductosFiltrados = new ObservableCollection<ProductoVariante>(todosLosProductos);
            }
        }

        [RelayCommand]
        public void Buscar()
        {
            if (string.IsNullOrWhiteSpace(FiltroNombre))
            {
                ProductosFiltrados = new ObservableCollection<ProductoVariante>(todosLosProductos);
            }
            else
            {
                var filtrados = todosLosProductos
                    .Where(p => !string.IsNullOrWhiteSpace(p.ProductoBase.NombreProducto)
                        && p.ProductoBase.NombreProducto.ToLower().Contains(FiltroNombre.ToLower()))
                    .ToList();
                ProductosFiltrados = new ObservableCollection<ProductoVariante>(filtrados);
            }
        }
    }