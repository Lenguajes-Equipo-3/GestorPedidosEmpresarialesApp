using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GestorPedidosEmpresarialesApp.Models;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class EmpleadoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public EmpleadoService()
        {
            _httpClient = new HttpClient();
            _baseUrl = AppConfig.GetApiBaseUrl() ?? "http://localhost:5140";
        }

        public async Task<List<Empleado>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/Empleados");
                response.EnsureSuccessStatusCode();
                var empleados = await response.Content.ReadFromJsonAsync<List<Empleado>>();

                return empleados ?? new List<Empleado>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener los empleados: {ex.Message}");
                return new List<Empleado>();
            }
        }

        public async Task<Empleado?> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/Empleados/{id}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Empleado>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener el empleado con ID {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<Empleado?> Create(Empleado empleado)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Empleados", empleado);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Empleado>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear el empleado: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Update(Empleado empleado)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Empleados/{empleado.IdEmpleado}", empleado);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar el empleado con ID {empleado.IdEmpleado}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Empleados/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar el empleado con ID {id}: {ex.Message}");
                return false;
            }
        }
    }
}