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
            var token = new TrelloAuthorizer().GetToken();
            var key = new TrelloAuthorizer().GetKey();
            var url = $"https://api.trello.com/1/lists/{listId}/cards?key={key}&token={token}";
            return url;
        }

        private IEnumerable<TrelloCard>? DeserializeHttpResponse(string responseBody)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<TrelloCard[]>(responseBody, options);
            return result;
        }
    }
}
