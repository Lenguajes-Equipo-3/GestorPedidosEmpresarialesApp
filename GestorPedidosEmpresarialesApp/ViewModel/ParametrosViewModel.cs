using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorPedidosEmpresarialesApp.Models;
using GestorPedidosEmpresarialesApp.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestorPedidosEmpresarialesApp.ViewModel
{
    public partial class ParametrosViewModel : ObservableObject
    {
        private readonly ParametroSistemaService _service = new();

        [ObservableProperty]
        private ParametroSistema parametro = new();

         

        public IRelayCommand GuardarCommand { get; }

        public ParametrosViewModel()
        {
            GuardarCommand = new AsyncRelayCommand(GuardarAsync);
            _ = CargarParametrosAsync();
        }

        private async Task CargarParametrosAsync()
        {
            var existente = await _service.GetParametrosAsync();
            if (existente != null)
                Parametro = existente;
        }

        private async Task GuardarAsync()
        {
            if (Parametro.IdParametro == 0)
                await _service.AddParametrosAsync(Parametro);
            else
                await _service.UpdateParametrosAsync (Parametro);
        }
    }
}
