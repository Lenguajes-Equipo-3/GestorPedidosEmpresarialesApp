using GestorPedidosEmpresarialesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Utils
{
    public static class SesionActual
    {
        public static Usuario UsuarioLogueado { get; set; }  // Inicializar para evitar null
        public static ParametroSistema? ParametrosSistema { get; set; }

    }



}
