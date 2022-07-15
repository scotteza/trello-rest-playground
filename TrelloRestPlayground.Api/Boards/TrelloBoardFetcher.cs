using System.Text.Json;
using TrelloRestPlayground.Http;

namespace TrelloRestPlayground.Api.Boards;

public class TrelloBoardFetcher
{
    public async Task<IEnumerable<TrelloBoard>?> FetchBoards()
    {
        var url = GetUrl();
        var responseBody = await new HttpGetter().GetHttpResponse(url);
        var result = DeserializeHttpResponse(responseBody);
        return result;
    }

    private string GetUrl()
    {
        return new TrelloUrlBuilder().BuildUrl("members/me/boards");
    }

    private IEnumerable<TrelloBoard>? DeserializeHttpResponse(string responseBody)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<TrelloBoard[]>(responseBody, options);
        return result;
    }
}
