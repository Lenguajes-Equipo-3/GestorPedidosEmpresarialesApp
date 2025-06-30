using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class UsuarioService
    {

        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = AppConfig.GetApiBaseUrl();

        public UsuarioService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(baseUrl))
                _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<Usuario?> LoginAsync(string email, string contrasena)
        {
            var credenciales = new
            {
                email = email,
                contrasenna = contrasena
            };

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseUrl}/api/auth/login", credenciales);

                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Log o manejo de error
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return null;
            }
        }
    }
}
