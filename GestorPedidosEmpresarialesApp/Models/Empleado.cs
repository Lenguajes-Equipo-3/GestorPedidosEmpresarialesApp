using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace GestorPedidosEmpresarialesApp.Models
{

    public partial class Empleado : ObservableObject
    {
        [ObservableProperty]
        private int _idEmpleado;

        [ObservableProperty]
        private string _nombreEmpleado = "";

        [ObservableProperty]
        private string _apellidosEmpleado = "";

        [ObservableProperty]
        private string? _puesto;

        [ObservableProperty]
        private string? _extension;

        [ObservableProperty]
        private string? _telefonoTrabajo;

        private Departamento? _departamento;
        public Departamento? Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }

        private Rol? _rol;
        public Rol? Rol
        {
            get => _rol;
            set => SetProperty(ref _rol, value);
        }
    }
}