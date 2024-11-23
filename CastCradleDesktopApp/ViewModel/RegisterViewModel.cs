using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IntelliJ.Lang.Annotations;

namespace CastCradleDesktopApp.ViewModel
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        public RegisterViewModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string userEmail;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string confirmPassword;

        [ObservableProperty]
        string securityQuestion;

        [ObservableProperty]
        string securityAnswer;

        [ObservableProperty]
        string feedbackMessage;

        [ObservableProperty]
        bool isFeedbackVisible;

        [ObservableProperty]
        bool isBusy;

        [RelayCommand]
        public async Task RegisterAsync()
        {
            if (IsBusy) return; // Previne múltiplos cliques
            IsBusy = true;

            try
            {
                // Exibe a mensagem de cadastro em andamento
                FeedbackMessage = "Realizando cadastro...";
                IsFeedbackVisible = true;

                // Validação de campos
                if (string.IsNullOrWhiteSpace(UserName) ||
                    string.IsNullOrWhiteSpace(UserEmail) ||
                    string.IsNullOrWhiteSpace(Password) ||
                    string.IsNullOrWhiteSpace(ConfirmPassword) ||
                    string.IsNullOrWhiteSpace(SecurityQuestion) ||
                    string.IsNullOrWhiteSpace(SecurityAnswer))
                {
                    FeedbackMessage = "Há campo(s) não preenchido(s)!";
                    IsFeedbackVisible = true;
                    return;
                }

                if (Password != ConfirmPassword)
                {
                    FeedbackMessage = "As senhas não coincidem!";
                    IsFeedbackVisible = true;
                    return;
                }

                // Chamada ao serviço para cadastro
                var isSuccess = await _apiService.RegisterUserAsync(
                    UserName,
                    UserEmail,
                    Password,
                    SecurityQuestion,
                    SecurityAnswer
                );

                if (isSuccess)
                {
                    FeedbackMessage = "Cadastro realizado com sucesso!";
                    IsFeedbackVisible = true;

                    // Aguarda 5 segundos antes de voltar à tela de login
                    await Task.Delay(5000);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    FeedbackMessage = "Erro ao realizar o cadastro. Tente novamente!";
                    IsFeedbackVisible = true;
                }
            }
            finally
            {
                IsBusy = false; // Garante que o estado de carregamento seja desativado
            }
        }
    }
}
