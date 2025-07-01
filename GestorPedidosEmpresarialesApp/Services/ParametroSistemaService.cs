using GestorPedidosEmpresarialesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class ParametroSistemaService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = AppConfig.GetApiBaseUrl();

        public ParametroSistemaService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(_baseUrl))
                _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        // GET: Obtener los parámetros
        public async Task<ParametroSistema?> GetParametrosAsync()
        {
            var response = await _httpClient.GetAsync("/api/parametrossistema");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ParametroSistema>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return null;
        }

        // POST: Crear parámetros
        public async Task<string> AddParametrosAsync(ParametroSistema parametros)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/parametrossistema", parametros);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        // PUT: Actualizar parámetros
        public async Task<string> UpdateParametrosAsync(ParametroSistema parametros)
        {
            var response = await _httpClient.PutAsJsonAsync("/api/parametrossistema", parametros);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}