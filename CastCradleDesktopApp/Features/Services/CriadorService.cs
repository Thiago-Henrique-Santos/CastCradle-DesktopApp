using System.Threading.Tasks;
using CastCradleDesktopApp.Features.Model;

namespace CastCradleDesktopApp.Features.Services
{
    public class CriadorService() : ApiBaseService
    {
        public async Task Register(CriadorCadastroRequest criadorRequest)
        {
            await Post<object, object>("/criador", criadorRequest);
        }
    }
}
