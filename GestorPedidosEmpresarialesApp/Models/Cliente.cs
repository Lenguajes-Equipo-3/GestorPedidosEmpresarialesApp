using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class Cliente : INotifyPropertyChanged
    {
        private int idCliente;
        public int IdCliente
        {
            get => idCliente;
            set { idCliente = value; OnPropertyChanged(); }
        }

        private string nombreCompania = string.Empty;
        public string NombreCompania
        {
            get => nombreCompania;
            set { nombreCompania = value; OnPropertyChanged(); }
        }

        private string nombreContacto = string.Empty;
        public string NombreContacto
        {
            get => nombreContacto;
            set { nombreContacto = value; OnPropertyChanged(); }
        }

        private string apellidoContacto = string.Empty;
        public string ApellidoContacto
        {
            get => apellidoContacto;
            set { apellidoContacto = value; OnPropertyChanged(); }
        }

        private string puestoContacto = string.Empty;
        public string PuestoContacto
        {
            get => puestoContacto;
            set { puestoContacto = value; OnPropertyChanged(); }
        }

        private string direccion = string.Empty;
        public string Direccion
        {
            get => direccion;
            set { direccion = value; OnPropertyChanged(); }
        }

        private string ciudad = string.Empty;
        public string Ciudad
        {
            get => ciudad;
            set { ciudad = value; OnPropertyChanged(); }
        }

        private string provincia = string.Empty;
        public string Provincia
        {
            get => provincia;
            set { provincia = value; OnPropertyChanged(); }
        }

        private string codigoPostal = string.Empty;
        public string CodigoPostal
        {
            get => codigoPostal;
            set { codigoPostal = value; OnPropertyChanged(); }
        }

        private string pais = string.Empty;
        public string Pais
        {
            get => pais;
            set { pais = value; OnPropertyChanged(); }
        }

        private string telefono = string.Empty;
        public string Telefono
        {
            get => telefono;
            set { telefono = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
