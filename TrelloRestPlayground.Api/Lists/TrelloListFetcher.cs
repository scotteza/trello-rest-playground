using System.Text.Json;
using TrelloRestPlayground.Authorization;
using TrelloRestPlayground.Http;

namespace TrelloRestPlayground.Api.Lists;

public class TrelloListFetcher
{
    public async Task<IEnumerable<TrelloList>?> FetchListsForBoard(string? boardId)
    {
        var url = GetUrl(boardId!);
        var responseBody = await new HttpGetter().GetHttpResponse(url);
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

    private IEnumerable<TrelloList>? DeserializeHttpResponse(string responseBody)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<TrelloList[]>(responseBody, options);
        return result;
    }
}
