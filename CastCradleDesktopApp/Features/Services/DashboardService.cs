using System.Threading.Tasks;
using CastCradleDesktopApp.Features.Model;
using CastCradleDesktopApp.Features.Storage;

namespace CastCradleDesktopApp.Features.Services
{
    public class DashboardService() : ApiBaseService
    {
        public async Task<DashboardResponse?> Load()
        {
            return await Get<DashboardResponse>("/dashboard::criador");
        }
    }
}
