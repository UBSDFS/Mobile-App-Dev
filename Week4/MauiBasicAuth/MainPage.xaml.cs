
namespace MauiBasicAuth
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void OnLoginClicked(object sender, EventArgs e)
		{
			// Retrieve credentials from the UI
			string username = txtUserId.Text ?? "";
			string password = txtPassword.Text ?? "";

			// Validate input
			if (string.IsNullOrWhiteSpace(username) ||
				string.IsNullOrWhiteSpace(password))
			{
				await DisplayAlertAsync(
					"Error",
					"Please enter a username and password.",
					"OK");
				return;
			}

			// Create authentication service
			var userAuth = new DataAccess.UserAuthentication();

			try
			{
				// Authenticate user through Web API
				bool isAuthenticated =
					await userAuth.AuthenticateUserAsync(username, password);

				// Display authentication result
				if (isAuthenticated)
				{
					await DisplayAlertAsync(
						"Success",
						"User authenticated successfully!",
						"OK");
				}
				else
				{
					await DisplayAlertAsync(
						"Error",
						"Invalid username or password.",
						"OK");
				}
			}
			catch (HttpRequestException)
			{
				await DisplayAlertAsync(
					"Connection Error",
					"Unable to connect to the authentication server.",
					"OK");
			}
		}
	}
}
