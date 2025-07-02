using System;
using System.Globalization;
using System.Windows.Data;

namespace GestorPedidosEmpresarialesApp.Converters
{
    public class NewItemPlaceholderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Si el valor es {NewItemPlaceholder}, devuelve null
            if (value?.ToString() == "{NewItemPlaceholder}")
                return null;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // No se necesita lógica para ConvertBack en este caso
            return value;
        }
    }
}