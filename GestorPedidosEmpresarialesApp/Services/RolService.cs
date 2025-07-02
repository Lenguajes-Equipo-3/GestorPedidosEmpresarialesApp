using GestorPedidosEmpresarialesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GestorPedidosEmpresarialesApp.Services
{
    public class RolService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = AppConfig.GetApiBaseUrl();

        public RolService()
        {
            _httpClient = new HttpClient();
        }   

        public async Task<List<Rol>> GetAll()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Roles");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Rol>>() ?? new List<Rol>();
        }

        public async Task<Rol> Create(Rol rol)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Roles", rol);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Rol>() ?? new Rol();
        }

        public async Task Update(Rol rol)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Roles/{rol.IdRol}", rol);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Roles/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
