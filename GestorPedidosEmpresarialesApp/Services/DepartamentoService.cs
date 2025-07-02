using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GestorPedidosEmpresarialesApp.Models;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class DepartamentoService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseUrl = AppConfig.GetApiBaseUrl();

        public DepartamentoService()
        {
            if (_httpClient.BaseAddress == null && !string.IsNullOrEmpty(baseUrl))
                _httpClient.BaseAddress = new Uri(baseUrl);
        }

        // Obtener todos los departamentos
        public async Task<IEnumerable<Departamento>?> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Departamento>>($"{baseUrl}/api/Departamentos");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener departamentos: {ex.Message}");
                return null;
            }
        }

        // Obtener un departamento por ID
        public async Task<Departamento?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Departamento>($"{baseUrl}/api/Departamentos/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener el departamento con ID {id}: {ex.Message}");
                return null;
            }
        }

        // Crear un nuevo departamento
        public async Task<bool> CreateAsync(Departamento departamento)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{baseUrl}/api/Departamentos", departamento);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear el departamento: {ex.Message}");
                return false;
            }
        }

        // Actualizar un departamento existente
        public async Task<bool> UpdateAsync(int id, Departamento departamento)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{baseUrl}/api/Departamentos/{id}", departamento);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar el departamento con ID {id}: {ex.Message}");
                return false;
            }
        }

        // Eliminar un departamento por ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{baseUrl}/api/Departamentos/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar el departamento con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}