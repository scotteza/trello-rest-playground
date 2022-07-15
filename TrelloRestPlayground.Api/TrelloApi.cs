using System.Text.Json;
using TrelloRestPlayground.Authorization;

namespace TrelloRestPlayground.Api;

public class TrelloApi
{
    public async Task<IEnumerable<TrelloBoard>?> FetchBoards()
    {
        var token = new TrelloAuthorizer().GetToken();
        var key = new TrelloAuthorizer().GetKey();
        var url = $"https://api.trello.com/1/members/me/boards?key={key}&token={token}";

        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<TrelloBoard[]>(responseBody, options);

        return result;
    }
}
