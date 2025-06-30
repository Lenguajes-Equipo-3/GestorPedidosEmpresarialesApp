using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly UsuarioService _usuarioService = new();

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string contrasena;

        public IRelayCommand IniciarSesionCommand { get; }

        public LoginViewModel()
        {
            IniciarSesionCommand = new AsyncRelayCommand(IniciarSesionAsync);
        }

        private async Task IniciarSesionAsync()
        {
            var usuario = await _usuarioService.LoginAsync(Email, Contrasena);

            if (usuario != null)
            {
                MessageBox.Show($"Bienvenido, {usuario.Empleado.NombreEmpleado}", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                var menu = new MainWindow(); // Cambiar por tu ventana principal si tiene otro nombre
                menu.Show();

                // Cierra la ventana actual de login
                Application.Current.Windows[0]?.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}