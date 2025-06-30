using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class Rol : INotifyPropertyChanged
    {
        private int idRol;
        public int IdRol
        {
            get => idRol;
            set { idRol = value; OnPropertyChanged(); }
        }

        private string nombreRol;
        public string NombreRol
        {
            get => nombreRol;
            set { nombreRol = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}