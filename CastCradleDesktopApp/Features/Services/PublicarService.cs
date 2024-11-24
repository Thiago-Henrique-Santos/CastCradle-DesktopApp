using System.Net.Http.Headers;
using System.Net.Http.Json;
using CastCradleDesktopApp.Features.Model;
using CastCradleDesktopApp.Features.Storage;

namespace CastCradleDesktopApp.Features.Services
{
    public class PublicarService() : ApiBaseService
    {
        public async Task<PublicarOptionsResponse?> GetOptions()
        {
            return await Get<PublicarOptionsResponse>("/publish::criador");
        }

        public async Task<PublicarResponse?> Salvar(PublicarRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"${_apiEndpoint}/publish::criador");
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", JWTStore.GetToken());

            var formData = new MultipartFormDataContent
            {
                { new StringContent(request.Titulo), "Titulo" },
                { new StringContent(request.Descricao), "Descricao" },
                { new StringContent(request.TipoMedia), "TipoMedia" },
                { new StringContent(request.TipoConteudo), "TipoConteudo" }
            };

            var tipoMedia = request.TipoMedia == "Video" ? "media.mp4" : "media.mp3";
            var mimeType = request.TipoMedia == "Video" ? "video/mp4" : "audio/mpeg";

            if (request.Arquivo != null)
            {
                var arquivoContent = new StreamContent(request.Arquivo);
                arquivoContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);
                formData.Add(arquivoContent, "Arquivo", tipoMedia);
            }

            if (request.Miniatura != null)
            {
                var miniaturaContent = new StreamContent(request.Miniatura);
                miniaturaContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");
                formData.Add(miniaturaContent, "Miniatura", "miniatura.png");
            }

            requestMessage.Content = formData;

            var result = await _httpClient.SendAsync(requestMessage);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<PublicarResponse>();
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
