using GestorPedidosEmpresarialesApp.Views;
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
    }
}