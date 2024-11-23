﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CastCradleDesktopApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        public MainViewModel(ApiService apiService)
        {
            _apiService = apiService;
            IsLoginFeedbackVisible = false;
            LoginFeedback = string.Empty;
        }

        [ObservableProperty]
        string loginFeedback;

        [ObservableProperty]
        bool isLoginFeedbackVisible;

        [ObservableProperty]
        string userEmail;

        [ObservableProperty]
        string pass;

        [RelayCommand]
        async void Login()
        {
            // Mostra feedback que está processando o login
            IsLoginFeedbackVisible = true;
            LoginFeedback = "Verificando credenciais...";

            // Chama o ApiService para realizar o login
            var loginSuccess = await _apiService.LoginAsync(UserEmail, Pass);

            if (loginSuccess)
            {
                LoginFeedback = "Login bem-sucedido!";
            }
            else
            {
                LoginFeedback = "Nome de usuário ou senha incorretos.";
            }

            // Opcional: Limpar os campos após o login
            UserEmail = string.Empty;
            Pass = string.Empty;
        }
    }
}