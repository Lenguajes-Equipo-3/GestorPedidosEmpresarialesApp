using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Models
{
 public class ParametroSistema : INotifyPropertyChanged
    {
        private int idParametro;
        public int IdParametro
        {
            get => idParametro;
            set { idParametro = value; OnPropertyChanged(); }
        }

        private string nombreEmpresa;
        public string NombreEmpresa
        {
            get => nombreEmpresa;
            set { nombreEmpresa = value; OnPropertyChanged(); }
        }

        private string direccion;
        public string Direccion
        {
            get => direccion;
            set { direccion = value; OnPropertyChanged(); }
        }

        private string telefono;
        public string Telefono
        {
            get => telefono;
            set { telefono = value; OnPropertyChanged(); }
        }

        private string correo;
        public string Correo
        {
            get => correo;
            set { correo = value; OnPropertyChanged(); }
        }

        private decimal impuestoVentas;
        public decimal ImpuestoVentas
        {
            get => impuestoVentas;
            set { impuestoVentas = value; OnPropertyChanged(); }
        }

        private string moneda;
        public string Moneda
        {
            get => moneda;
            set { moneda = value; OnPropertyChanged(); }
        }

        private DateTime ultimaActualizacion;
        public DateTime UltimaActualizacion
        {
            get => ultimaActualizacion;
            set { ultimaActualizacion = value; OnPropertyChanged(); }
        }

        private byte[]? logo;
        public byte[]? Logo
        {
            get => logo;
            set { logo = value; OnPropertyChanged(); }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}









