using System.Windows;
using System.Windows.Input;

namespace GestorPedidosEmpresarialesApp.Views
{
    public partial class RolView : Window
    {
        public RolView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}