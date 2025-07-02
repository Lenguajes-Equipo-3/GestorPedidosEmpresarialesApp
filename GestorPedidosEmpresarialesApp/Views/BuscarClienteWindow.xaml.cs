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
    /// Lógica de interacción para BuscarClienteWindow.xaml
    /// </summary>
    public partial class BuscarClienteWindow : Window
    {
        public BuscarClienteWindow()
        {
            InitializeComponent();
        }
        private void Seleccionar_Click(object sender, RoutedEventArgs e)
        {
            // Verifica si hay un cliente seleccionado
            if (DataContext is BuscarClienteViewModel vm && vm.ClienteSeleccionado != null)
            {
                this.DialogResult = true; // Señala selección exitosa
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
