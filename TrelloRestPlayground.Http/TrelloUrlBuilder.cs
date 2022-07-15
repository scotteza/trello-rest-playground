using TrelloRestPlayground.Authorization;

namespace TrelloRestPlayground.Http
{
    public class TrelloUrlBuilder
    {
        public string BuildUrl(string queryPortion)
        {
            var authorizer = new TrelloAuthorizer();
            var token = authorizer.GetToken();
            var key = authorizer.GetKey();
            var url = $"https://api.trello.com/1/{queryPortion}?key={key}&token={token}";
            return url;
        }
    }
}
