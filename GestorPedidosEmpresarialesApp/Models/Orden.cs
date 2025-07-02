using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Models
{
    public class orden : INotifyPropertyChanged
    {
        private int idOrden;
        public int IdOrden
        {
            get => idOrden;
            set { idOrden = value; OnPropertyChanged(); }
        }

        private Cliente cliente;
        public Cliente Cliente
        {
            get => cliente;
            set { cliente = value; OnPropertyChanged(); }
        }

        private Empleado empleado;
        public Empleado Empleado
        {
            get => empleado;
            set { empleado = value; OnPropertyChanged(); }
        }

        private ObservableCollection<DetalleOrden> detallesOrden = new();
        public ObservableCollection<DetalleOrden> DetallesOrden
        {
            get => detallesOrden;
            set { detallesOrden = value; OnPropertyChanged(); }
        }

        private DateTime fechaOrden = DateTime.Now;
        public DateTime FechaOrden
        {
            get => fechaOrden;
            set { fechaOrden = value; OnPropertyChanged(); }
        }

        private string direccionViaje = "";
        public string DireccionViaje
        {
            get => direccionViaje;
            set { direccionViaje = value; OnPropertyChanged(); }
        }

        private string ciudadViaje = "";
        public string CiudadViaje
        {
            get => ciudadViaje;
            set { ciudadViaje = value; OnPropertyChanged(); }
        }

        private string provinciaViaje = "";
        public string ProvinciaViaje
        {
            get => provinciaViaje;
            set { provinciaViaje = value; OnPropertyChanged(); }
        }

        private string paisViaje = "";
        public string PaisViaje
        {
            get => paisViaje;
            set { paisViaje = value; OnPropertyChanged(); }
        }

        private string telefonoViaje = "";
        public string TelefonoViaje
        {
            get => telefonoViaje;
            set { telefonoViaje = value; OnPropertyChanged(); }
        }

        private bool eliminado;
        public bool Eliminado
        {
            get => eliminado;
            set { eliminado = value; OnPropertyChanged(); }
        }

        // Notificación de cambios
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // Métodos auxiliares para la vista
        public void AgregarDetalle(DetalleOrden detalle)
        {
            if (detalle != null)
                DetallesOrden.Add(detalle);
        }
        public void EliminarDetalle(DetalleOrden detalle)
        {
            if (detalle != null)
                DetallesOrden.Remove(detalle);
        }
    }
}