using System.Net.Http.Headers;
using System.Text.Json;
using TrelloRestPlayground.Authorization;

namespace TrelloRestPlayground.Api.Lists;

public class TrelloListFetcher
{
    public async Task<IEnumerable<TrelloList>?> FetchLists(string? boardId)
    {
        var url = GetUrl(boardId!);
        var responseBody = await GetHttpResponse(url);
        var result = DeserializeHttpResponse(responseBody);
        return result;
    }

    private string GetUrl(string boardId)
    {
        var token = new TrelloAuthorizer().GetToken();
        var key = new TrelloAuthorizer().GetKey();
        var url = $"https://api.trello.com/1/boards/{boardId}/lists?key={key}&token={token}";
        return url;
    }

    private async Task<string> GetHttpResponse(string url)
    {
        var httpClient = new HttpClient();
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
        var response = await httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }

    private IEnumerable<TrelloList>? DeserializeHttpResponse(string responseBody)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<TrelloList[]>(responseBody, options);
        return result;
    }
}
