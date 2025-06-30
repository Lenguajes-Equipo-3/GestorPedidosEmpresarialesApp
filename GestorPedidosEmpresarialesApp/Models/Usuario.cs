using GestorPedidosEmpresarialesApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Usuario : INotifyPropertyChanged
{
    private int idUsuario;
    public int IdUsuario
    {
        get => idUsuario;
        set { idUsuario = value; OnPropertyChanged(); }
    }

    private Empleado empleado = new(); // Inicializar para evitar null
    public Empleado Empleado
    {
        get => empleado;
        set { empleado = value; OnPropertyChanged(); }
    }

    private string email = string.Empty;
    public string Email
    {
        get => email;
        set { email = value; OnPropertyChanged(); }
    }

    private string contrasena = string.Empty;
    public string Contrasena
    {
        get => contrasena;
        set { contrasena = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
