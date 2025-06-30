using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class Usuario : INotifyPropertyChanged
    {
        private int idUsuario;
        public int IdUsuario
        {
            get => idUsuario;
            set { idUsuario = value; OnPropertyChanged(); }
        }

        private Empleado empleado;
        public Empleado Empleado
        {
            get => empleado;
            set { empleado = value; OnPropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }

        private string contrasena;
        public string Contrasena
        {
            get => contrasena;
            set { contrasena = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

