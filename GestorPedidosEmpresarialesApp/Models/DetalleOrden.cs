using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class DetalleOrden : INotifyPropertyChanged
    {
        private int idDetalleOrden;
        public int IdDetalleOrden
        {
            get => idDetalleOrden;
            set { idDetalleOrden = value; OnPropertyChanged(); }
        }

        private ProductoVariante varianteProducto;
        public ProductoVariante VarianteProducto
        {
            get => varianteProducto;
            set { varianteProducto = value; OnPropertyChanged(); }
        }

        private int cantidad;
        public int Cantidad
        {
            get => cantidad;
            set { cantidad = value; OnPropertyChanged(); }
        }

        private double precioLinea;
        public double PrecioLinea
        {
            get => precioLinea;
            set { precioLinea = value; OnPropertyChanged(); }
        }

        private bool eliminado;
        public bool Eliminado
        {
            get => eliminado;
            set { eliminado = value; OnPropertyChanged(); }
        }

        // Notificación de cambios para WPF
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
