using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class ProductoVariante : INotifyPropertyChanged
    {
        private int idVariante;
        public int IdVariante
        {
            get => idVariante;
            set { idVariante = value; OnPropertyChanged(); }
        }

        private ProductoBase productoBase;
        public ProductoBase ProductoBase
        {
            get => productoBase;
            set { productoBase = value; OnPropertyChanged(); }
        }

        private string talla;
        public string Talla
        {
            get => talla;
            set { talla = value; OnPropertyChanged(); }
        }

        private string descripcion;
        public string Descripcion
        {
            get => descripcion;
            set { descripcion = value; OnPropertyChanged(); }
        }

        private decimal precio;
        public decimal Precio
        {
            get => precio;
            set { precio = value; OnPropertyChanged(); }
        }

        private decimal cantidadExistencias;
        public decimal CantidadExistencias
        {
            get => cantidadExistencias;
            set { cantidadExistencias = value; OnPropertyChanged(); }
        }

        private int puntoReorden;
        public int PuntoReorden
        {
            get => puntoReorden;
            set { puntoReorden = value; OnPropertyChanged(); }
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