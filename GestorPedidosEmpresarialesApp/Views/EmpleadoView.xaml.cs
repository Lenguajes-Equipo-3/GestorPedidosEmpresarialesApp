using System.Windows;
using System.Windows.Input;

namespace GestorPedidosEmpresarialesApp.Views
{
    public partial class EmpleadoView : Window
    {
        public EmpleadoView()
        {
            InitializeComponent();
        }

        // Permite que la ventana se pueda mover haciendo clic en el borde superior
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        // Cierra la ventana al hacer clic en el botón 'X'
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}