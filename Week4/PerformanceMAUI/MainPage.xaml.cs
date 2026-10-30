
using PerformanceMAUI.ViewModels;

namespace PerformanceMAUI;

public partial class MainPage : ContentPage
{
	private readonly LoginViewModel _viewModel = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		bool success = await _viewModel.LoginAsync();

		if (success)
		{
			await Navigation.PushAsync(new Views.DataEntryPage());
		}
	}

	private void OnCancelClicked(object sender, EventArgs e)
	{
		_viewModel.Cancel();
	}
}
