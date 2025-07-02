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
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            CargarInicio();
             Instance = this; 
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

        private void MenuParametros_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new ParametrosView();
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


        
        private void AbrirOrdenesView_Click(object sender, RoutedEventArgs e)
        {
            this.MainContent.Content = new OrdenesListView();

        }

        private void AbrirDepartamentoView_Click(object sender, RoutedEventArgs e)
        {
            var departamentoView = new DepartamentoView();
            departamentoView.Show();
        }

        private void AbrirClienteView_Click(object sender, RoutedEventArgs e)
        {
            var clienteView = new ClienteView();
            clienteView.Show();
        }

        private void MenuItem_Empleados_Click(object sender, RoutedEventArgs e)
        {
            var empleadosView = new EmpleadoView();
            empleadosView.Show();
        }

        private void MenuItem_Roles_Click(object sender, RoutedEventArgs e)
        {
            var rolView = new RolView();
            rolView.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}