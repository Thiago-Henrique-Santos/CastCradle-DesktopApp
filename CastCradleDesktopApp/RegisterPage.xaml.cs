using CastCradleDesktopApp.Features.Services;
using CastCradleDesktopApp.ViewModel;

namespace CastCradleDesktopApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(new CriadorService());
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}