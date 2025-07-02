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
    public class OrdenService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = AppConfig.GetApiBaseUrl();

        public OrdenService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(_baseUrl))
                _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        // GET: Obtener todas las órdenes
        public async Task<List<orden>?> GetOrdenesAsync()
        {
            var response = await _httpClient.GetAsync("/api/Orden");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<orden>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return null;
        }

        

        // POST: Crear nueva orden
        public async Task<string> AddOrdenAsync(orden orden)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Orden", orden);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}