
namespace AddSubtractApp;

public partial class ResultPage : ContentPage
{
    public ResultPage(double firstValue, double secondValue,
                      double result, string operation)
    {
        InitializeComponent();

        lblNumbers.Text =
            $"The numbers entered are {firstValue} and {secondValue}.";

        if (operation == "Addition")
        {
            lblResult.Text = $"The sum of the numbers is {result}";
        }
        else
        {
            lblResult.Text = $"The difference of the numbers is {result}";
        }
    }

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
