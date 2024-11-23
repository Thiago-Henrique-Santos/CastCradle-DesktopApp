using System.Net.Http.Headers;
using System.Net.Http.Json;
using CastCradleDesktopApp.Features.Model;
using CastCradleDesktopApp.Features.Storage;

namespace CastCradleDesktopApp.Features.Services
{
    public class CriadorService() : ApiBaseService
    {
        public async Task Register(CriadorCadastroRequest criadorRequest)
        {
            await Post<CriadorCadastroRequest, object>("/criador", criadorRequest);
        }

        public async Task<CriadorResponse?> GetData()
        {
            return await Get<CriadorResponse>("/criador");
        }

        public async Task<CriadorCadastroResponse?> AtualizarCanal(CriadorCanalRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"${_apiEndpoint}/criador");
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", JWTStore.GetToken());

            var list = new List<SimpleObject>
            {
                new() {
                    Key = "Resposta",
                    Value = request.Resposta
                },
                new() {
                    Key = "NomeCanal",
                    Value = request.NomeCanal
                },
                new() {
                    Key = "Descricao",
                    Value = request.Descricao
                },
                new() {
                    Key = "Pergunta",
                    Value = request.Pergunta
                },
                new() {
                    Key = "Senha",
                    Value = request.Senha
                },
                new() {
                    Key = "Nome",
                    Value = request.Nome
                },
                new() {
                    Key = "Email",
                    Value = request.Email
                }
            };

            var formData = new MultipartFormDataContent();
            foreach (var campo in list)
            {
                if (campo.Value != null)
                {
                    formData.Add(new StringContent(campo.Value), campo.Key);
                }
            }

            if (request.Avatar != null)
            {
                var avatarContent = new StreamContent(request.Avatar);
                avatarContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                formData.Add(avatarContent, "Avatar", "avatar.png");
            }

            if (request.Banner != null)
            {
                var bannerContent = new StreamContent(request.Banner);
                bannerContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                formData.Add(bannerContent, "Banner", "banner.png");
            }

            requestMessage.Content = formData;

            var result = await _httpClient.SendAsync(requestMessage);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<CriadorCadastroResponse>();
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
