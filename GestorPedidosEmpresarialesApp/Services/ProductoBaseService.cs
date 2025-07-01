using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using GestorPedidosEmpresarialesApp.Models;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class ProductoBaseService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = AppConfig.GetApiBaseUrl();

        public ProductoBaseService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(baseUrl))
                _httpClient.BaseAddress = new Uri(baseUrl);
        }

        // Obtener todos los productos base
        public async Task<IEnumerable<ProductoBase>?> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<ProductoBase>>($"{baseUrl}/api/ProductoBase");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener productos base: {ex.Message}");
                return null;
            }
        }

        // Obtener un producto base por ID
        public async Task<ProductoBase?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductoBase>($"{baseUrl}/api/ProductoBase/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener el producto base con ID {id}: {ex.Message}");
                return null;
            }
        }

        // Crear un nuevo producto base
        public async Task<bool> CreateAsync(ProductoBase productoBase)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseUrl}/api/ProductoBase", productoBase);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear el producto base: {ex.Message}");
                return false;
            }
        }

        // Actualizar un producto base existente
        public async Task<bool> UpdateAsync(int id, ProductoBase productoBase)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{baseUrl}/api/ProductoBase/{id}", productoBase);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar el producto base con ID {id}: {ex.Message}");
                return false;
            }
        }

        // Eliminar un producto base por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseUrl}/api/ProductoBase/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar el producto base con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}