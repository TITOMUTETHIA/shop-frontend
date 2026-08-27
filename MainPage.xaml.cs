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
		try
		{
			await Task.Delay(650);
			await loadingScreen.FadeToAsync(0, 300, Easing.CubicIn);
		}
		finally
		{
			loadingScreen.IsVisible = false;
		}
	}
}
