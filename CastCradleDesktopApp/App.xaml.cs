using CastCradleDesktopApp.Features.Services;
using CastCradleDesktopApp.ViewModel;

namespace CastCradleDesktopApp
{
    public partial class App : Application
    {
        public static HttpClient HttpClient { get; private set; } = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(120)
        };

        public App()
        {
            InitializeComponent();

            HttpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(120)
            };

            var mainViewModel = new MainViewModel();
            MainPage = new NavigationPage(new MainPage(mainViewModel));
        }
    }
}
