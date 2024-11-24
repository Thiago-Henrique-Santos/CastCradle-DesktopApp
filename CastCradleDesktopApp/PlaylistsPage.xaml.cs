namespace CastCradleDesktopApp
{

    public partial class PlaylistsPage : ContentPage
    {
        public PlaylistsPage()
        {
            InitializeComponent();
        }

        private async void OnPublicarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UploadPage());
        }

        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage());
        }

        private async void OnVideosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideosPage());
        }

        private async void OnAudiosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AudiosPage());
        }

        private async void OnCanalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CanalPage());
        }

    }

}