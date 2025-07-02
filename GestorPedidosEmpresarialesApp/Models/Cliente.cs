using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Cliente : INotifyPropertyChanged
{
    private int idCliente;
    private string nombreCompania = "";
    private string nombreContacto = "";
    private string apellidoContacto = "";
    private string puestoContacto = "";
    private string direccion = "";
    private string ciudad = "";
    private string provincia = "";
    private string codigoPostal = "";
    private string pais = "";
    private string telefono = "";
    private bool eliminado;

    public int IdCliente
    {
        get => idCliente;
        set { idCliente = value; OnPropertyChanged(); }
    }
    public string NombreCompania
    {
        get => nombreCompania;
        set { nombreCompania = value; OnPropertyChanged(); }
    }
    public string NombreContacto
    {
        get => nombreContacto;
        set { nombreContacto = value; OnPropertyChanged(); }
    }
    public string ApellidoContacto
    {
        get => apellidoContacto;
        set { apellidoContacto = value; OnPropertyChanged(); }
    }
    public string PuestoContacto
    {
        get => puestoContacto;
        set { puestoContacto = value; OnPropertyChanged(); }
    }
    public string Direccion
    {
        get => direccion;
        set { direccion = value; OnPropertyChanged(); }
    }
    public string Ciudad
    {
        get => ciudad;
        set { ciudad = value; OnPropertyChanged(); }
    }
    public string Provincia
    {
        get => provincia;
        set { provincia = value; OnPropertyChanged(); }
    }
    public string CodigoPostal
    {
        get => codigoPostal;
        set { codigoPostal = value; OnPropertyChanged(); }
    }
    public string Pais
    {
        get => pais;
        set { pais = value; OnPropertyChanged(); }
    }
    public string Telefono
    {
        get => telefono;
        set { telefono = value; OnPropertyChanged(); }
    }
    public bool Eliminado
    {
        get => eliminado;
        set { eliminado = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
