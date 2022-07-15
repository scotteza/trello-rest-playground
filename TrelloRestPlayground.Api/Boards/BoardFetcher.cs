using System.Text.Json;
using TrelloRestPlayground.Authorization;

namespace TrelloRestPlayground.Api.Boards;

public class BoardFetcher
{
    public async Task<IEnumerable<Board>?> FetchBoards()
    {
        var url = GetUrl();
        var responseBody = await GetHttpResponse(url);
        var result = DeserializeHttpResponse(responseBody);
        return result;
    }

    private string GetUrl()
    {
        var token = new TrelloAuthorizer().GetToken();
        var key = new TrelloAuthorizer().GetKey();
        var url = $"https://api.trello.com/1/members/me/boards?key={key}&token={token}";
        return url;
    }

    private async Task<string> GetHttpResponse(string url)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }

    private IEnumerable<Board>? DeserializeHttpResponse(string responseBody)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<Board[]>(responseBody, options);
        return result;
    }
}
