
using System.Collections.ObjectModel;
using ItemStorage.DataAccess;
using ItemStorage.Models;

namespace ItemStorage;

public partial class MainPage : ContentPage
{
	private readonly ItemData itemData = new();

	public ObservableCollection<Item> Items { get; } = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await LoadItemsAsync();
	}

	private async Task LoadItemsAsync()
	{
		var savedItems = await itemData.GetItemsAsync();

		Items.Clear();

		foreach (var item in savedItems)
			Items.Add(item);
	}

	private async void OnSaveClicked(object? sender, EventArgs e)
	{
		string id = txtItemID.Text?.Trim() ?? "";
		string name = txtItemName.Text?.Trim() ?? "";
		string description = txtItemDescription.Text?.Trim() ?? "";

		if (string.IsNullOrWhiteSpace(id) ||
			string.IsNullOrWhiteSpace(name) ||
			string.IsNullOrWhiteSpace(description))
		{
			await DisplayAlertAsync(
				"Missing Information",
				"All fields are required.",
				"OK");
			return;
		}

		var item = new Item
		{
			ItemID = id,
			ItemName = name,
			ItemDescription = description
		};

		try
		{
			await itemData.SaveItemAsync(item);
			await LoadItemsAsync();

			txtItemID.Text = "";
			txtItemName.Text = "";
			txtItemDescription.Text = "";

			await DisplayAlertAsync(
				"Success",
				"Item saved successfully.",
				"OK");
		}
		catch (SQLite.SQLiteException)
		{
			await DisplayAlertAsync(
				"Save Error",
				"Unable to save item. Check whether the Item ID already exists.",
				"OK");
		}
	}
}
