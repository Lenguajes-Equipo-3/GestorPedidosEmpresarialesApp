using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class Departamento : INotifyPropertyChanged
    {
        private int idDepartamento;
        public int IdDepartamento
        {
            get => idDepartamento;
            set { idDepartamento = value; OnPropertyChanged(); }
        }

        private string nombreDepartamento;
        public string NombreDepartamento
        {
            get => nombreDepartamento;
            set { nombreDepartamento = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}