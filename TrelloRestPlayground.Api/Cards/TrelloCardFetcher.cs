using System.Text.Json;
using TrelloRestPlayground.Authorization;
using TrelloRestPlayground.Http;

namespace TrelloRestPlayground.Api.Cards
{
    public class TrelloCardFetcher
    {
        public async Task<IEnumerable<TrelloCard>?> FetchCardsForList(string? listId)
        {
            var url = GetUrl(listId!);
            var responseBody = await new HttpGetter().GetHttpResponse(url);
            var result = DeserializeHttpResponse(responseBody);
            return result;
        }

        private string GetUrl(string listId)
        {
            return new TrelloUrlBuilder().BuildUrl($"lists/{listId}/cards");
        }

        private IEnumerable<TrelloCard>? DeserializeHttpResponse(string responseBody)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<TrelloCard[]>(responseBody, options);
            return result;
        }
    }
}
