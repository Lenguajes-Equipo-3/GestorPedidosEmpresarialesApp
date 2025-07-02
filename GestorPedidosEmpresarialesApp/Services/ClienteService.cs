using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GestorPedidosEmpresarialesApp.Models;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class ClienteService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = AppConfig.GetApiBaseUrl();

        public ClienteService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(baseUrl))
                _httpClient.BaseAddress = new Uri(baseUrl);
        }

        // Obtener todos los clientes
        public async Task<IEnumerable<Cliente>?> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Cliente>>($"{baseUrl}/api/Clientes");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener los clientes: {ex.Message}");
                return null;
            }
        }

        // Obtener un cliente por ID
        public async Task<Cliente?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cliente>($"{baseUrl}/api/Clientes/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener el cliente con ID {id}: {ex.Message}");
                return null;
            }
        }

        // Crear un nuevo cliente
        public async Task<bool> CreateAsync(Cliente cliente)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{baseUrl}/api/Clientes", cliente);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear el cliente: {ex.Message}");
                return false;
            }
        }

        // Actualizar un cliente existente
        public async Task<bool> UpdateAsync(int id, Cliente cliente)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{baseUrl}/api/Clientes/{id}", cliente);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar el cliente con ID {id}: {ex.Message}");
                return false;
            }
        }

        // Eliminar un cliente por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{baseUrl}/api/Clientes/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar el cliente con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}
