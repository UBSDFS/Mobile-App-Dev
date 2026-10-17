
namespace AddSubtractApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnAdditionClicked(object sender, EventArgs e)
	{
		string firstInput = txtFirstValue.Text;
		string secondInput = txtSecondValue.Text;

		if (double.TryParse(firstInput, out double firstValue) &&
			double.TryParse(secondInput, out double secondValue))
		{
			double result = firstValue + secondValue;
			await Navigation.PushAsync(
	new ResultPage(firstValue, secondValue, result, "Addition")
);
		}
		else
		{
			await DisplayAlertAsync("Invalid Input", "Please enter valid numbers.", "OK");
		}
	}


	private async void OnSubtractionClicked(object sender, EventArgs e)
	{
		string firstInput = txtFirstValue.Text;
		string secondInput = txtSecondValue.Text;

		if (double.TryParse(firstInput, out double firstValue) &&
			double.TryParse(secondInput, out double secondValue))
		{
			double result = firstValue - secondValue;

			await Navigation.PushAsync(
				new ResultPage(firstValue, secondValue, result, "Subtraction")
			);
		}
		else
		{
			await DisplayAlertAsync("Invalid Input", "Please enter valid numbers.", "OK");
		}
	}
}
