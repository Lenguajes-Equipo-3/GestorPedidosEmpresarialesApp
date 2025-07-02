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
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class OrderViewModel : ObservableObject
    {
        private readonly OrdenService _ordenService = new();

        // Propiedades principales del pedido
        [ObservableProperty]
        private Cliente? clienteSeleccionado;

        [ObservableProperty]
        private Empleado? empleadoSeleccionado;

        [ObservableProperty]
        private DateTime fechaOrden = DateTime.Now;

        [ObservableProperty]
        private string direccionViaje = "";

        [ObservableProperty]
        private string ciudadViaje = "";

        [ObservableProperty]
        private string provinciaViaje = "";

        [ObservableProperty]
        private string paisViaje = "";

        [ObservableProperty]
        private string telefonoViaje = "";

        [ObservableProperty]
        private ObservableCollection<DetalleOrden> detallesOrden = new();

        // Para el producto seleccionado desde el popup
        [ObservableProperty]
        private ProductoVariante? productoSeleccionado;

        [ObservableProperty]
        private int cantidadProducto = 1;

        // Comando para agregar producto al pedido
        [RelayCommand]
        private void AgregarProducto()
        {
            if (productoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un producto.");
                return;
            }

            // Puede validar stock aquí si lo desea

            // Agregar detalle
            var detalle = new DetalleOrden
            {
                VarianteProducto = productoSeleccionado,
                Cantidad = cantidadProducto,
                PrecioLinea = (double)(cantidadProducto * productoSeleccionado.Precio),
                Eliminado = false
            };
            detallesOrden.Add(detalle);

            // Limpiar selección de producto
            ProductoSeleccionado = null;
            CantidadProducto = 1;
        }

        // Comando para eliminar detalle
        [RelayCommand]
        private void EliminarDetalle(DetalleOrden detalle)
        {
            if (detalle != null)
                detallesOrden.Remove(detalle);
        }

        // Comando para guardar la orden (enviar al API)
        [RelayCommand]
        public async Task GuardarOrdenAsync()
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }
            if (empleadoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un empleado.");
                return;
            }
            if (detallesOrden.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.");
                return;
            }

            var nuevaOrden = new Orden
            {
                Cliente = clienteSeleccionado,
                Empleado = empleadoSeleccionado,
                FechaOrden = fechaOrden,
                DireccionViaje = direccionViaje,
                CiudadViaje = ciudadViaje,
                ProvinciaViaje = provinciaViaje,
                PaisViaje = paisViaje,
                TelefonoViaje = telefonoViaje,
                DetallesOrden = detallesOrden
            };

            try
            {
                var result = await _ordenService.AddOrdenAsync(nuevaOrden);
                MessageBox.Show("¡Pedido registrado con éxito!\nRespuesta: " + result);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pedido:\n" + ex.Message);
            }
        }

        // Método para limpiar el formulario luego de registrar la orden
        [RelayCommand]
        private void LimpiarFormulario()
        {
            ClienteSeleccionado = null;
            EmpleadoSeleccionado = null;
            FechaOrden = DateTime.Now;
            DireccionViaje = "";
            CiudadViaje = "";
            ProvinciaViaje = "";
            PaisViaje = "";
            TelefonoViaje = "";
            DetallesOrden.Clear();
        }

        // Puede agregar más comandos para incrementar/decrementar cantidad, buscar clientes/productos, etc.
    }
}
