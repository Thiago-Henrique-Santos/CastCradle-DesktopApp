using CastCradleDesktopApp.ViewModel;

namespace CastCradleDesktopApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Cria o ApiService com o HttpClient já configurado
            var apiService = new ApiService(App.HttpClient);

            // Passa o ApiService para o MainViewModel
            BindingContext = new MainViewModel(apiService);
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Navegar para a página de registro
            await Navigation.PushAsync(new RegisterPage());
        }

    }

}
