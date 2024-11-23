using CastCradleDesktopApp.Features.Model;
using CastCradleDesktopApp.Features.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CastCradleDesktopApp.ViewModel
{
    public partial class RegisterViewModel(CriadorService criadorService) : ObservableObject
    {
        private readonly CriadorService _criadorService = criadorService;
        [ObservableProperty]
        string? userName;

        [ObservableProperty]
        string? userEmail;

        [ObservableProperty]
        string? password;

        [ObservableProperty]
        string? confirmPassword;

        [ObservableProperty]
        string? securityQuestion;

        [ObservableProperty]
        string? securityAnswer;

        [ObservableProperty]
        string? feedbackMessage;

        [ObservableProperty]
        bool isFeedbackVisible;

        [ObservableProperty]
        bool isBusy;

        [RelayCommand]
        public async Task RegisterAsync()
        {
            if (IsBusy) return;
            IsBusy = true;

            FeedbackMessage = "Realizando cadastro...";
            IsFeedbackVisible = true;

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

            var request = new CriadorCadastroRequest
            {
                Email = UserEmail,
                Nome = UserName,
                Senha = Password,
                Pergunta = SecurityQuestion,
                Resposta = SecurityAnswer
            };

            try
            {
                await _criadorService.Register(request);
                FeedbackMessage = "Cadastro realizado com sucesso!";
                IsFeedbackVisible = true;
                IsBusy = false;
            }
            catch (Exception)
            {
                FeedbackMessage = "Erro ao realizar o cadastro. Tente novamente!";
                IsFeedbackVisible = true;
                IsBusy = false;
            }
        }
    }
}
