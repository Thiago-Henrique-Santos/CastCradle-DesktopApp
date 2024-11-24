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

        private async void OnPlaylistsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlaylistsPage());
        }

        private async void OnCanalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CanalPage());
        }

        private async void OnSairClicked(object sender, EventArgs e)
        {
            var mainViewModel = new ViewModel.MainViewModel();
            await Navigation.PushAsync(new MainPage(mainViewModel));
        }

    }
}