using System.Text.Json;
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
        return new TrelloUrlBuilder().BuildUrl($"boards/{boardId}/lists");
    }

    private IEnumerable<TrelloList>? DeserializeHttpResponse(string responseBody)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<TrelloList[]>(responseBody, options);
        return result;
    }
}
