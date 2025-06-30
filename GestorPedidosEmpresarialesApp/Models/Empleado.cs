using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class Empleado : INotifyPropertyChanged
    {
        private int idEmpleado;
        public int IdEmpleado
        {
            get => idEmpleado;
            set { idEmpleado = value; OnPropertyChanged(); }
        }

        private string nombreEmpleado;
        public string NombreEmpleado
        {
            get => nombreEmpleado;
            set { nombreEmpleado = value; OnPropertyChanged(); }
        }

        private string apellidosEmpleado;
        public string ApellidosEmpleado
        {
            get => apellidosEmpleado;
            set { apellidosEmpleado = value; OnPropertyChanged(); }
        }

        private string puesto;
        public string Puesto
        {
            get => puesto;
            set { puesto = value; OnPropertyChanged(); }
        }

        private string extension;
        public string Extension
        {
            get => extension;
            set { extension = value; OnPropertyChanged(); }
        }

        private string telefonoTrabajo;
        public string TelefonoTrabajo
        {
            get => telefonoTrabajo;
            set { telefonoTrabajo = value; OnPropertyChanged(); }
        }

        private Rol rol;
        public Rol Rol
        {
            get => rol;
            set { rol = value; OnPropertyChanged(); }
        }

        private Departamento departamento;
        public Departamento Departamento
        {
            get => departamento;
            set { departamento = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
