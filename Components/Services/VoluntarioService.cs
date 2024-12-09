using Escalas.Components.Classes;
using Microsoft.EntityFrameworkCore;

namespace Escalas.Components.Services
{
    public class VoluntarioService
    {
        private readonly HttpClient _httpClient;

        public VoluntarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Voluntario>> ObterTodos()
        {
            return await _httpClient.GetFromJsonAsync<List<Voluntario>>("https://localhost:7046/Voluntario");
        }

        public async Task<Voluntario> ObterPorId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Voluntario>($"https://localhost:7046/Voluntario/{id}");
        }

        public async Task<Voluntario> Salvar(Voluntario model)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7046/Voluntario", model);

            if (response.IsSuccessStatusCode)
            {
                return null;
            }

            return null;
        }

        public async Task Excluir(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7046/Voluntario/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao excluir o Voluntario.");
            }
        }
    }

}
