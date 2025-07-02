using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class ProductoBase : INotifyPropertyChanged
    {
        private int idProductoBase;
        public int IdProductoBase
        {
            get => idProductoBase;
            set { idProductoBase = value; OnPropertyChanged(); }
        }

        private string nombreProducto;
        public string NombreProducto
        {
            get => nombreProducto;
            set { nombreProducto = value; OnPropertyChanged(); }
        }

        private Categoria categoria;
        public Categoria Categoria
        {
            get => categoria;
            set { categoria = value; OnPropertyChanged(); }
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