
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http.Json;
using PerformanceMAUI.Models;

namespace PerformanceMAUI.DataAccess;

public class ApiService
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("http://localhost:5150/")
    };

    public async Task<bool> LoginAsync(string username, string password)
    {
        string credentials = Convert.ToBase64String(
            Encoding.UTF8.GetBytes($"{username}:{password}"));

        using var request = new HttpRequestMessage(HttpMethod.Get, "api/auth");

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Basic", credentials);

        using var response = await _client.SendAsync(request);

        return response.IsSuccessStatusCode;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return await _client.GetFromJsonAsync<List<Item>>("api/items") ?? new();
    }

    public async Task<bool> SaveItemAsync(Item item)
    {
        using var response = await _client.PostAsJsonAsync("api/items", item);
        return response.IsSuccessStatusCode;
    }

}
