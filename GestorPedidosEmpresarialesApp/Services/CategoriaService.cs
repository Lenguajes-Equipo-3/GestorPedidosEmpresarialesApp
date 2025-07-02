using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GestorPedidosEmpresarialesApp.Models;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class CategoriaService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = AppConfig.GetApiBaseUrl();

        public CategoriaService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(baseUrl))
                _httpClient.BaseAddress = new Uri(baseUrl);
        }

        // Obtener todas las categorías
        public async Task<IEnumerable<Categoria>?> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Categoria>>($"{baseUrl}/api/Categoria");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener categorías: {ex.Message}");
                return null;
            }
        }

        // Obtener una categoría por ID
        public async Task<Categoria?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Categoria>($"{baseUrl}/api/Categoria/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener la categoría con ID {id}: {ex.Message}");
                return null;
            }
        }

        // Crear una nueva categoría
        public async Task<bool> CreateAsync(Categoria categoria)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseUrl}/api/Categoria", categoria);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear la categoría: {ex.Message}");
                return false;
            }
        }

        // Actualizar una categoría existente
        public async Task<bool> UpdateAsync(int id, Categoria categoria)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{baseUrl}/api/Categoria/{id}", categoria);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar la categoría con ID {id}: {ex.Message}");
                return false;
            }
        }

        // Eliminar una categoría por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseUrl}/api/Categoria/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar la categoría con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}