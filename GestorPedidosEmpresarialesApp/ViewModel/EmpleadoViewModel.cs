using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class EmpleadoViewModel : ObservableObject
    {
        private readonly EmpleadoService _empleadoService = new();
        private readonly DepartamentoService _departamentoService = new();
        private readonly RolService _rolService = new();

        public ObservableCollection<Empleado> Empleados { get; } = new();
        public ObservableCollection<Departamento> Departamentos { get; } = new();
        public ObservableCollection<Rol> Roles { get; } = new();

        // Propiedad para el texto dinámico del botón
        [ObservableProperty]
        private string _guardarButtonText = "Guardar";

        private Empleado? _selectedEmpleado;
        public Empleado? SelectedEmpleado
        {
            get => _selectedEmpleado;
            set
            {
                if (_selectedEmpleado != null)
                {
                    _selectedEmpleado.PropertyChanged -= OnSelectedEmpleadoPropertyChanged;
                }

                SetProperty(ref _selectedEmpleado, value);

                if (_selectedEmpleado != null)
                {
                    // Lógica para cambiar el texto del botón
                    GuardarButtonText = (_selectedEmpleado.IdEmpleado == 0) ? "Guardar" : "Actualizar";

                    _selectedEmpleado.Departamento = Departamentos.FirstOrDefault(d => d.IdDepartamento == _selectedEmpleado.Departamento?.IdDepartamento);
                    _selectedEmpleado.Rol = Roles.FirstOrDefault(r => r.IdRol == _selectedEmpleado.Rol?.IdRol);

                    _selectedEmpleado.PropertyChanged += OnSelectedEmpleadoPropertyChanged;
                }

                GuardarCommand.NotifyCanExecuteChanged();
                EliminarCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand GuardarCommand { get; }
        public IAsyncRelayCommand EliminarCommand { get; }
        public IRelayCommand NuevoCommand { get; }

        public EmpleadoViewModel()
        {
            NuevoCommand = new RelayCommand(Nuevo);
            GuardarCommand = new AsyncRelayCommand(GuardarAsync, PuedeGuardar);
            EliminarCommand = new AsyncRelayCommand(EliminarAsync, PuedeEliminar);
            _ = CargarDatosAsync();
        }

        private void OnSelectedEmpleadoPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            GuardarCommand.NotifyCanExecuteChanged();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                var departamentosList = await _departamentoService.GetAllAsync();
                Departamentos.Clear();
                foreach (var dep in departamentosList) Departamentos.Add(dep);

                var rolesList = await _rolService.GetAll() ?? new();
                Roles.Clear();
                foreach (var rol in rolesList) Roles.Add(rol);

                var empleadosList = await _empleadoService.GetAll() ?? new();
                Empleados.Clear();
                foreach (var emp in empleadosList) Empleados.Add(emp);

                Nuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error de Conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Nuevo()
        {
            SelectedEmpleado = new Empleado();
        }

        private bool PuedeGuardar()
        {
            if (SelectedEmpleado == null) return false;
            return !string.IsNullOrWhiteSpace(SelectedEmpleado.NombreEmpleado) &&
                   !string.IsNullOrWhiteSpace(SelectedEmpleado.ApellidosEmpleado) &&
                   !string.IsNullOrWhiteSpace(SelectedEmpleado.Puesto) &&
                   SelectedEmpleado.Departamento != null &&
                   SelectedEmpleado.Rol != null;
        }

        private async Task GuardarAsync()
        {
            if (SelectedEmpleado == null) return;
            try
            {
                if (SelectedEmpleado.IdEmpleado == 0)
                {
                    var nuevoEmpleado = await _empleadoService.Create(SelectedEmpleado);
                    if (nuevoEmpleado != null)
                    {
                        Empleados.Add(nuevoEmpleado);
                        SelectedEmpleado = nuevoEmpleado;
                        MessageBox.Show("Empleado creado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    bool actualizado = await _empleadoService.Update(SelectedEmpleado);
                    if (actualizado)
                    {
                        MessageBox.Show("Empleado actualizado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        await CargarDatosAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool PuedeEliminar()
        {
            return SelectedEmpleado != null && SelectedEmpleado.IdEmpleado != 0;
        }

        private async Task EliminarAsync()
        {
            if (SelectedEmpleado == null) return;
            if (MessageBox.Show($"¿Está seguro de eliminar a {SelectedEmpleado.NombreEmpleado}?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    bool eliminado = await _empleadoService.Delete(SelectedEmpleado.IdEmpleado);
                    if (eliminado)
                    {
                        Empleados.Remove(SelectedEmpleado);
                        Nuevo();
                        MessageBox.Show("Empleado eliminado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}