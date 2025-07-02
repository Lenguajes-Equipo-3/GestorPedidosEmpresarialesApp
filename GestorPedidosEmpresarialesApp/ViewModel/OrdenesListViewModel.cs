using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using GestorPedidosEmpresarialesApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class OrdenesListViewModel : ObservableObject
    {
        private readonly OrdenService _ordenService = new();

        [ObservableProperty]
        private string filtroNombreCliente = "";

        [ObservableProperty]
        private ObservableCollection<orden> ordenes = new(); 

        [ObservableProperty]
        private orden? ordenSeleccionada;

        // Buscar por nombre de cliente
        [RelayCommand]
        public async Task BuscarAsync()
        {
            Ordenes.Clear();
            var lista = await _ordenService.GetOrdenesAsync();
            if (!string.IsNullOrWhiteSpace(FiltroNombreCliente))
            {
                lista = lista?.FindAll(o => o.Cliente != null &&
                                            o.Cliente.NombreCompania.ToLower().Contains(FiltroNombreCliente.ToLower()));
            }
            if (lista != null)
                foreach (var o in lista) Ordenes.Add(o);
        }

        // Ver todas las órdenes sin filtro
        [RelayCommand]
        public async Task VerTodasAsync()
        {
            FiltroNombreCliente = "";
            Ordenes.Clear();
            var lista = await _ordenService.GetOrdenesAsync();
            if (lista != null)
                foreach (var o in lista) Ordenes.Add(o);
        }

        // Comando para generar reporte individual
        [RelayCommand]
        public void ReporteOrden()
        {
            if (OrdenSeleccionada == null)
            {
                MessageBox.Show("Seleccione una orden.");
                return;
            }
            // Lógica para mostrar/generar el reporte de la orden seleccionada
            // Puede abrir una ventana o exportar a PDF
            // ...
        }

        // Comando para generar reporte de todas las órdenes mostradas
        [RelayCommand]
        public void ReporteTodas()
        {
            // Lógica para generar el reporte de todas las órdenes actualmente en el ObservableCollection
            // ...
        }

        // Constructor: carga inicial
        public OrdenesListViewModel()
        {
            _ = VerTodasAsync();
        }

        [RelayCommand]
        public void NuevaOrden()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MainWindow.Instance.MainContent.Content = new OrdenMaestroDetalleUcView();
            });
        }

    }
}

