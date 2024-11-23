using System.Threading.Tasks;
using CastCradleDesktopApp.Features.Model;
using CastCradleDesktopApp.Features.Storage;

namespace CastCradleDesktopApp.Features.Services
{
    public class LoginService() : ApiBaseService
    {
        public async Task<bool> Login(LoginRequest loginRequest)
        {
            var response = await Post<object, LoginResponse>("login::criador", loginRequest);
            if (response != null && !string.IsNullOrEmpty(response.JWT))
            {
                JWTStore.SetToken(response.JWT);
                return true;
            }

            return false;
        }
    }
}
