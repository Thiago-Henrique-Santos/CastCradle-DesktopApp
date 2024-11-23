namespace CastCradleDesktopApp
{
    public partial class App : Application
    {

        public static HttpClient HttpClient { get; private set; }
        public App()
        {
            InitializeComponent();

            HttpClient = new HttpClient
            {
                BaseAddress = new Uri("https://dev.azure.com/marvinborges770/PIM_Aleph/_git/CastCradleAPI/")
            };

            var apiService = new ApiService(HttpClient);

            // Passa o ApiService para o MainViewModel
            MainPage = new MainPage
            {
                BindingContext = new MainViewModel(apiService)
            };

            // Envolvendo a MainPage com a NavigationPage para permitir navegação
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
