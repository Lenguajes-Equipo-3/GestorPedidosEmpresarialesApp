using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GestorPedidosEmpresarialesApp.Models;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class ProductoVarianteService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = AppConfig.GetApiBaseUrl();

        public ProductoVarianteService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(baseUrl))
                _httpClient.BaseAddress = new Uri(baseUrl);
        }

        // Obtener todas las variantes de producto
        public async Task<IEnumerable<ProductoVariante>?> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<ProductoVariante>>($"{baseUrl}/api/ProductoVariante");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener variantes de producto: {ex.Message}");
                return null;
            }
        }

        // Obtener una variante de producto por ID
        public async Task<ProductoVariante?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductoVariante>($"{baseUrl}/api/ProductoVariante/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener la variante de producto con ID {id}: {ex.Message}");
                return null;
            }
        }

        // Crear una nueva variante de producto
        public async Task<bool> CreateAsync(ProductoVariante productoVariante)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseUrl}/api/ProductoVariante", productoVariante);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear la variante de producto: {ex.Message}");
                return false;
            }
        }

        // Actualizar una variante de producto existente
        public async Task<bool> UpdateAsync(int id, ProductoVariante productoVariante)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{baseUrl}/api/ProductoVariante/{id}", productoVariante);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar la variante de producto con ID {id}: {ex.Message}");
                return false;
            }
        }

        // Eliminar una variante de producto por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseUrl}/api/ProductoVariante/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar la variante de producto con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}