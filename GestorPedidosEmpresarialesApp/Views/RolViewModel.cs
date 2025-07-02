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
    public partial class RolViewModel : ObservableObject
    {
        private readonly RolService _rolService = new();

        public ObservableCollection<Rol> Roles { get; } = new();

        [ObservableProperty]
        private string _guardarButtonText = "Guardar";

        private Rol? _selectedRol;
        public Rol? SelectedRol
        {
            get => _selectedRol;
            set
            {
                if (_selectedRol != null)
                {
                    _selectedRol.PropertyChanged -= OnSelectedRolPropertyChanged;
                }

                SetProperty(ref _selectedRol, value);

                if (_selectedRol != null)
                {
                    GuardarButtonText = (_selectedRol.IdRol == 0) ? "Guardar" : "Actualizar";
                    _selectedRol.PropertyChanged += OnSelectedRolPropertyChanged;
                }

                GuardarCommand.NotifyCanExecuteChanged();
                EliminarCommand.NotifyCanExecuteChanged();
            }
        }

        public IAsyncRelayCommand GuardarCommand { get; }
        public IAsyncRelayCommand EliminarCommand { get; }
        public IRelayCommand NuevoCommand { get; }

        public RolViewModel()
        {
            NuevoCommand = new RelayCommand(Nuevo);
            GuardarCommand = new AsyncRelayCommand(GuardarAsync, PuedeGuardar);
            EliminarCommand = new AsyncRelayCommand(EliminarAsync, PuedeEliminar);
            _ = CargarDatosAsync();
        }

        private void OnSelectedRolPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            GuardarCommand.NotifyCanExecuteChanged();
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                var rolesList = await _rolService.GetAll() ?? new();
                Roles.Clear();
                foreach (var rol in rolesList)
                {
                    Roles.Add(rol);
                }
                Nuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los roles: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Nuevo()
        {
            SelectedRol = new Rol();
        }

        private bool PuedeGuardar()
        {
            return SelectedRol != null && !string.IsNullOrWhiteSpace(SelectedRol.NombreRol);
        }

        private async Task GuardarAsync()
        {
            if (SelectedRol == null) return;
            try
            {
                if (SelectedRol.IdRol == 0)
                {
                    var nuevoRol = await _rolService.Create(SelectedRol);
                    if (nuevoRol != null)
                    {
                        Roles.Add(nuevoRol);
                        SelectedRol = nuevoRol;
                        MessageBox.Show("Rol creado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    await _rolService.Update(SelectedRol);
                    MessageBox.Show("Rol actualizado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    await CargarDatosAsync(); // Recargar para reflejar cambios
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el rol: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool PuedeEliminar()
        {
            return SelectedRol != null && SelectedRol.IdRol != 0;
        }

        private async Task EliminarAsync()
        {
            if (SelectedRol == null) return;
            if (MessageBox.Show($"¿Está seguro de eliminar el rol '{SelectedRol.NombreRol}'?", "Confirmar Eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    await _rolService.Delete(SelectedRol.IdRol);
                    Roles.Remove(SelectedRol);
                    Nuevo();
                    MessageBox.Show("Rol eliminado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el rol: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}