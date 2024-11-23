namespace CastCradleDesktopApp;

public partial class UploadPage : ContentPage
{
	public UploadPage()
	{
		InitializeComponent();
	}

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        // Navegar para a página de registro
        await Navigation.PopAsync();
    }

    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        // Navegar para a página de registro
        await Navigation.PushAsync(new DashboardPage());
    }

    private async void OnVideosClicked(object sender, EventArgs e)
    {
        // Navegar para a página de registro
        await Navigation.PushAsync(new VideosPage());
    }
}