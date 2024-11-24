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
            await Navigation.PushAsync(new UploadPage());
        }
        private async void OnVideosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideosPage());
        }

        private async void OnAudiosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AudiosPage());
        }

    }
}