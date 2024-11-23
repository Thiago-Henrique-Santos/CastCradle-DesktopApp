using CastCradleDesktopApp.Features.Model;
using CastCradleDesktopApp.Features.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CastCradleDesktopApp.ViewModel
{
    public partial class MainViewModel() : ObservableObject
    {
        [ObservableProperty]
        string loginFeedback = string.Empty;

        [ObservableProperty]
        bool isLoginFeedbackVisible = false;

        [ObservableProperty]
        string userEmail = string.Empty;

        [ObservableProperty]
        string pass = string.Empty;

        [RelayCommand]
        public async Task Login()
        {
            if(string.IsNullOrWhiteSpace(UserEmail) ||
               string.IsNullOrWhiteSpace(Pass))
            {
                IsLoginFeedbackVisible = true;
                LoginFeedback = "E-mail ou senha não inseridos!";
                return;
            }

            // Mostra feedback que está processando o login
            IsLoginFeedbackVisible = true;
            LoginFeedback = "Verificando credenciais...";

            var request = new LoginRequest
            {
                Email = UserEmail,
                Senha = Pass
            };
            var loginService = new LoginService();
            var loginSuccess = await loginService.Login(request);

            if (loginSuccess)
            {
                LoginFeedback = "Login bem-sucedido! Carregando seu painel...";
                await Application.Current.MainPage.Navigation.PushAsync(new DashboardPage());
            }
            else
            {
                LoginFeedback = "Nome de usuário ou senha incorretos.";
            }

            UserEmail = string.Empty;
            Pass = string.Empty;
        }
    }
}
