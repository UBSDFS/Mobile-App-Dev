
namespace MauiApp2;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnDisplayClicked(object? sender, EventArgs e)
	{
		lblOutput.Text = UserInput.Text;
	}

	private void OnResetClicked(object? sender, EventArgs e)
	{
		UserInput.Text = string.Empty;
		lblOutput.Text = string.Empty;
	}
}
