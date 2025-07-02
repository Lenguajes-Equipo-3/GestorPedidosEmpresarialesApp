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
using GestorPedidosEmpresarialesApp.ViewModel;

namespace GestorPedidosEmpresarialesApp.Views
{
    /// <summary>
    /// Lógica de interacción para DepartamentoView.xaml
    /// </summary>
    public partial class DepartamentoView : Window
    {
        public DepartamentoView()
        {
            InitializeComponent();
            DataContext = new DepartamentoViewModel();
        }
    }
}
