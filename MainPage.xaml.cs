namespace ShopFrontend;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		Loaded += OnPageLoaded;
	}

	private async void OnPageLoaded(object? sender, EventArgs e)
	{
		Loaded -= OnPageLoaded;
		await Task.Delay(650);
		await blazorWebView.FadeToAsync(1, 350, Easing.CubicOut);
		await loadingScreen.FadeToAsync(0, 300, Easing.CubicIn);
		loadingScreen.IsVisible = false;
	}
}
