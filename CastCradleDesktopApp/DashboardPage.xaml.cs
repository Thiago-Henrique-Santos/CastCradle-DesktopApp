namespace CastCradleDesktopApp
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void OnPublicarClicked(object sender, EventArgs e)
        {
            // Navegar para a p�gina de registro
            await Navigation.PushAsync(new UploadPage());
        }
        private async void OnVideosClicked(object sender, EventArgs e)
        {
            // Navegar para a p�gina de registro
            await Navigation.PushAsync(new VideosPage());
        }
    }
}