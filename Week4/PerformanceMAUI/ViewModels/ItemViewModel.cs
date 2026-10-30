
using System.Collections.ObjectModel;
using PerformanceMAUI.DataAccess;
using PerformanceMAUI.Models;

namespace PerformanceMAUI.ViewModels;

public class ItemViewModel
{
    private readonly ApiService _api = new();

    public string ItemId { get; set; } = "";
    public string ItemName { get; set; } = "";
    public string ItemDescription { get; set; } = "";

    public ObservableCollection<Item> Items { get; } = new();

    public async Task<string> SaveAsync()
    {
        if (!int.TryParse(ItemId, out int id) || id <= 0 ||
            string.IsNullOrWhiteSpace(ItemName) ||
            string.IsNullOrWhiteSpace(ItemDescription))
        {
            return "Please enter a valid Item ID, name, and description.";
        }

        try
        {
            var item = new Item
            {
                ItemId = id,
                ItemName = ItemName,
                ItemDescription = ItemDescription
            };

            bool saved = await _api.SaveItemAsync(item);

            if (!saved)
                return "Unable to save item. Check that the ID is unique.";

            await LoadItemsAsync();
            return "Item saved successfully.";
        }
        catch (HttpRequestException)
        {
            return "Unable to connect to the web service.";
        }
    }

    public async Task LoadItemsAsync()
    {
        var items = await _api.GetItemsAsync();

        Items.Clear();

        foreach (var item in items)
            Items.Add(item);
    }
}
