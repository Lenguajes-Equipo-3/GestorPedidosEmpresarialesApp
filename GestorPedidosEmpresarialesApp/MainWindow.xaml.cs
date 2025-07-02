using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.ViewModel;
using GestorPedidosEmpresarialesApp.Views;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorPedidosEmpresarialesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarInicio();
        }

        private void CargarInicio()
        {
           // MainContent.Content = new InicioView(); // Una UserControl que debés crear
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
           // MainContent.Content = new InicioView();
        }

        private void BtnPedidos_Click(object sender, RoutedEventArgs e)
        {
          //  MainContent.Content = new PedidosView(); // Otra UserControl
        }
        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para cerrar sesión (por ejemplo, limpiar datos, volver al login)
            var login = new LoginView();
            login.Show();
            this.Close();
        }
        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            var login = new LoginView();
            login.Show();
            this.Close();
        }

        private void Ejemplo_Click(object sender, RoutedEventArgs e)
        {
            // < MenuItem Header = "Clientes" Click = "Ejemplo_Click" /> ejemplo de la etiquertata
            // Instancia la nueva ventana
            //  var ventanaClientes = new ClientesWindow();
            // Muestra la ventana
            // ventanaClientes.Show();

        }

        private void AbrirProductoBaseView_Click(object sender, RoutedEventArgs e)
        {
            var productoBaseView = new ProductoBaseView();

            productoBaseView.Show();
        }

        private void AbrirCategoriaView_Click(object sender, RoutedEventArgs e)
        {
            var categoriaView = new CategoriaView();
            categoriaView.Show();
        }

        private void AbrirProductoVarianteView_Click(object sender, RoutedEventArgs e)
        {
            var productoVarianteView = new ProductoVarianteView();
            productoVarianteView.Show();
        }
    }
}