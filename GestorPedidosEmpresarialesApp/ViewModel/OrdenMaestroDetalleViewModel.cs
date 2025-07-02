using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class OrdenMaestroDetalleViewModel : ObservableObject
    {
        [ObservableProperty] private Cliente? clienteSeleccionado;
        [ObservableProperty] private DateTime fechaOrden = DateTime.Now;
        [ObservableProperty] private string direccionViaje = "";
        [ObservableProperty] private ObservableCollection<DetalleOrden> detallesOrden = new();
        [ObservableProperty] private DetalleOrden? detalleSeleccionado;
       

        public string NombreCompletoCliente =>
            (Orden.Cliente != null)
            ? $"{Orden.Cliente.NombreContacto} {Orden.Cliente.ApellidoContacto}" // Ajuste a sus propiedades reales
            : string.Empty;

        [ObservableProperty] private orden orden = new();

        public decimal TotalPedido => (decimal)DetallesOrden.Sum(d => d.PrecioLinea);

        // Comandos

      


      
        [RelayCommand]
        private void SeleccionarCliente()
        {
            // Crear e inicializar la ventana de búsqueda
            var win = new BuscarClienteWindow();
            var result = win.ShowDialog();

            if (result == true)
            {
                // Obtener el cliente seleccionado desde el ViewModel de la ventana de búsqueda
                if (win.DataContext is BuscarClienteViewModel vm
                    && vm.ClienteSeleccionado != null)
                {
                    Orden.Cliente = vm.ClienteSeleccionado;

                    // Actualizar NombreCompletoCliente
                    OnPropertyChanged(nameof(NombreCompletoCliente));
                }
            }
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
