
using System.Net.Http.Headers;
using System.Text;

namespace MauiBasicAuth.DataAccess
{
    public class UserAuthentication
    {
        public async Task<bool> AuthenticateUserAsync(
            string username, string password)
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:5144/");

            // Encode username and password in Base64
            var authToken = Convert.ToBase64String(
                Encoding.UTF8.GetBytes($"{username}:{password}"));

            // Add Basic Authentication header
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", authToken);

            // Send GET request to protected endpoint
            var response = await client.GetAsync("api/Values");

            // Return true for successful authentication
            return response.IsSuccessStatusCode;
        }
    }
}
