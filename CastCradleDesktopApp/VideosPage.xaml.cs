namespace CastCradleDesktopApp;

public partial class VideosPage : ContentPage
{
	public VideosPage()
	{
		InitializeComponent();
	}

    private async void OnPublicarClicked(object sender, EventArgs e)
    {
        // Navegar para a página de registro
        await Navigation.PushAsync(new UploadPage());
    }

    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        // Navegar para a página de registro
        await Navigation.PushAsync(new DashboardPage());
    }
}