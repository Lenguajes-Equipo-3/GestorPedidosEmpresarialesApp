using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class Categoria : INotifyPropertyChanged
    {
        private int idCategoria;
        public int IdCategoria
        {
            get => idCategoria;
            set { idCategoria = value; OnPropertyChanged(); }
        }

        private string descripcion;
        public string Descripcion
        {
            get => descripcion;
            set { descripcion = value; OnPropertyChanged(); }
        }

        private bool eliminado;
        public bool Eliminado
        {
            get => eliminado;
            set { eliminado = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}