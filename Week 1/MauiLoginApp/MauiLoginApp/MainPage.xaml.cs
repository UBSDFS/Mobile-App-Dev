
namespace MauiLoginApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	// Event handler for the Login button click
	private void OnLoginClicked(object sender, EventArgs e)
	{
		string username = txtUsername.Text;
		string password = txtPassword.Text;

		if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
		{
			lblMessage.Text = "Please enter both username and password.";
			return;
		}
		if (username == "Burden" && password == "Password1")
		{
			// Perform login logic here
			lblMessage.Text = $"Welcome, {username}!";
		}
		else
		{
			lblMessage.Text = "Invalid username or password.";
		}
	}

	// Event handler for the Cancel button click
	private void OnCancelClicked(object sender, EventArgs e)
	{
		txtUsername.Text = string.Empty;
		txtPassword.Text = string.Empty;
		lblMessage.Text = string.Empty;
	}
}
