using GestorPedidosEmpresarialesApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestorPedidosEmpresarialesApp.Views
{
    /// <summary>
    /// Lógica de interacción para BuscarProductoWindow.xaml
    /// </summary>
    public partial class BuscarProductoWindow : Window
    {
        public BuscarProductoWindow()
        {
            InitializeComponent();
        }


        private void Seleccionar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si hay un cliente seleccionado
            if (DataContext is BuscarProductoViewModel vm && vm.ProductoSeleccionado != null)
            {
                this.DialogResult = true; // Señala selección exitosa
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Producto.", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
