using Escalas.Components.Classes;
using Microsoft.EntityFrameworkCore;

namespace Escalas.Components.Services
{
    public class InstituicaoService
    {
        private readonly HttpClient _httpClient;

        public InstituicaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Instituicao>> ObterTodos()
        {
            return await _httpClient.GetFromJsonAsync<List<Instituicao>>("https://localhost:7046/Instituicao");
        }

        public async Task<Instituicao> ObterPorId(int id)
        {
            return await _httpClient.GetFromJsonAsync<Instituicao>($"https://localhost:7046/Instituicao/{id}");
        }

        public async Task<Instituicao> Salvar(Instituicao instituicao)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7046/Instituicao", instituicao);

            if (response.IsSuccessStatusCode)
            {
                return null;
            }

            return null;
        }

        public async Task Excluir(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7046/Instituicao/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao excluir a instituição.");
            }
        }

    }


}
