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
    /// Lógica de interacción para InsertarProductoBaseView.xaml
    /// </summary>
    public partial class ProductoBaseView : Window
    {
        public ProductoBaseView()
        {
            InitializeComponent();
            DataContext = new ProductoBaseViewModel();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
