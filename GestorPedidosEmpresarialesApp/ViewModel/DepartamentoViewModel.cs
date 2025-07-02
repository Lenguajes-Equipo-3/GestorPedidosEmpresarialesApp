using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class DepartamentoViewModel : ObservableObject
    {
        private readonly DepartamentoService _departamentoService = new();

        [ObservableProperty]
        private Departamento? departamentoSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Departamento> departamentos;

        public IRelayCommand CargarDepartamentosCommand { get; }
        public IRelayCommand GuardarDepartamentoCommand { get; }
        public IRelayCommand EliminarDepartamentoCommand { get; }

        public DepartamentoViewModel()
        {
            departamentos = new ObservableCollection<Departamento>();

            CargarDepartamentosCommand = new AsyncRelayCommand(CargarDepartamentosAsync);
            GuardarDepartamentoCommand = new AsyncRelayCommand(GuardarDepartamentoAsync);
            EliminarDepartamentoCommand = new AsyncRelayCommand(EliminarDepartamentoAsync);

            _ = CargarDepartamentosAsync();
        }

        private async Task CargarDepartamentosAsync()
        {
            var departamentosObtenidos = await _departamentoService.GetAllAsync();
            if (departamentosObtenidos != null)
            {
                departamentos.Clear();
                foreach (var departamento in departamentosObtenidos)
                {
                    departamentos.Add(departamento);
                }
            }
            else
            {
                MessageBox.Show("Error al cargar los departamentos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task GuardarDepartamentoAsync()
        {
            if (departamentoSeleccionado != null)
            {
                bool resultado;
                if (departamentoSeleccionado.IdDepartamento == 0)
                {
                    resultado = await _departamentoService.CreateAsync(departamentoSeleccionado);
                }
                else
                {
                    resultado = await _departamentoService.UpdateAsync(departamentoSeleccionado.IdDepartamento, departamentoSeleccionado);
                }

                if (resultado)
                {
                    MessageBox.Show("Departamento guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    await CargarDepartamentosAsync();
                }
                else
                {
                    MessageBox.Show("Error al guardar el departamento.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task EliminarDepartamentoAsync()
        {
            if (departamentoSeleccionado != null)
            {
                var resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el departamento '{departamentoSeleccionado.NombreDepartamento}'?",
                                                "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    bool eliminado = await _departamentoService.DeleteAsync(departamentoSeleccionado.IdDepartamento);
                    if (eliminado)
                    {
                        MessageBox.Show("Departamento eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        await CargarDepartamentosAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el departamento.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}