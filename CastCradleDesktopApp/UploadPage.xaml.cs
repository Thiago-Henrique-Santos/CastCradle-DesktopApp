namespace CastCradleDesktopApp
{
    public partial class UploadPage : ContentPage
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
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