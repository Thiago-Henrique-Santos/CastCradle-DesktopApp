using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CastCradleDesktopApp.Features.Model;
using CastCradleDesktopApp.Features.Storage;

namespace CastCradleDesktopApp.Features.Services
{
    public class ConteudoService() : ApiBaseService
    {
        public async Task<List<ConteudoBuscaResponse>> Buscar(string termo)
        {
            var request = new
            {
                termo
            };
            var response = await Get<List<ConteudoBuscaResponse>, object>("/conteudo/criador", request);
            if (response == null)
            {
                return [];
            }
            return response;
        }

        public async Task<ConteudoPorIdResponse?> PegarPorId(int id)
        {
            return await Get<ConteudoPorIdResponse>("/conteudo/criador", id);
        }

        public async Task<StatusObject?> Apagar(int id)
        {
            return await Delete<StatusObject>("/conteudo/criador", id);
        }

        public async Task<StatusObject?> Salvar(ConteudoSalvarRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"${_apiEndpoint}/conteudo/criador");
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", JWTStore.GetToken());

            var formData = new MultipartFormDataContent
            {
                { new StringContent(request.Id.ToString()), "Id" },
                { new StringContent(request.Titulo), "Titulo" },
                { new StringContent(request.Descricao), "Descricao" },
                { new StringContent(request.TipoConteudo), "TipoConteudo" }
            };

            requestMessage.Content = formData;

            var result = await _httpClient.SendAsync(requestMessage);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<StatusObject>();
            }
            else
            {
                var errorContent = await result.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"Erro ao chamar o endpoint '{_apiEndpoint}'. Código: {result.StatusCode}. Conteúdo: {errorContent}"
                );
            }
        }
    }
}
