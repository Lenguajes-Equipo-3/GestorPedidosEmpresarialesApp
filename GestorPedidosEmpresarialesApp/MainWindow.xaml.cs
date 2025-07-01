using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using GestorPedidosEmpresarialesApp.Utils;
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
         
            Loaded += MainWindow_Loaded; 

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Cargar parámetros del sistema al iniciar
            var parametroService = new ParametroSistemaService();
            ParametroSistema parametros = await parametroService.GetParametrosAsync();


            SesionActual.ParametrosSistema = parametros;

            // Si el usuario logueado no está definido, podrías forzar el login aquí:
            if (SesionActual.UsuarioLogueado == null)
            {
                var loginView = new Views.LoginView();
                loginView.Show();
                this.Close();
                return;
            }

            // Aquí podrías cargar información específica para la sesión, mostrar bienvenida, etc.
            // Ejemplo: this.DataContext = new MainWindowViewModel(); // si usas MVVM
        }

        private void MenuItem_Parametros_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Views.ParametrosView();
        
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
    }
}