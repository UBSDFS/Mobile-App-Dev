
using PerformanceMAUI.ViewModels;

namespace PerformanceMAUI.Views;

public partial class DataEntryPage : ContentPage
{
    private readonly ItemViewModel _viewModel = new();

    public DataEntryPage()
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        try
        {
            await _viewModel.LoadItemsAsync();
        }
        catch (HttpRequestException)
        {
            await DisplayAlertAsync("Error", "Unable to load items.", "OK");
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string message = await _viewModel.SaveAsync();
        await DisplayAlertAsync("Result", message, "OK");
    }
}
