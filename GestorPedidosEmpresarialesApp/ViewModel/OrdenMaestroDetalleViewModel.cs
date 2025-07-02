using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class OrdenMaestroDetalleViewModel : ObservableObject
    {
        [ObservableProperty] private Cliente? clienteSeleccionado;
        [ObservableProperty] private DateTime fechaOrden = DateTime.Now;
        [ObservableProperty] private string direccionViaje = "";
        [ObservableProperty] private ObservableCollection<DetalleOrden> detallesOrden = new();
        [ObservableProperty] private DetalleOrden? detalleSeleccionado;
        // Propiedades para ciudad, provincia, país, teléfono, etc.

        public decimal TotalPedido => (decimal)DetallesOrden.Sum(d => d.PrecioLinea);

        // Comandos

        [RelayCommand]
        private void BuscarCliente()
        {
            // Abrir ventana/búsqueda de cliente y asignar a ClienteSeleccionado
        }

        [RelayCommand]
        private void AgregarProducto()
        {
            // Abrir diálogo para seleccionar producto y agregar a DetallesOrden
        }

        [RelayCommand]
        private void QuitarProducto()
        {
            if (DetalleSeleccionado != null)
                DetallesOrden.Remove(DetalleSeleccionado);
        }

        [RelayCommand]
        private void GuardarOrden()
        {
            // Validar y guardar la orden usando el servicio correspondiente
            MessageBox.Show("Orden guardada correctamente.");
        }

        [RelayCommand]
        private void Cancelar()
        {
            // Limpiar o cerrar la vista, según su flujo
        }
    }
}
