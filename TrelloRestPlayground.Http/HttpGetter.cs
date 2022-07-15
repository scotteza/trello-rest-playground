using System.Net.Http.Headers;

namespace TrelloRestPlayground.Http
{
    public class HttpGetter
    {
        public async Task<string> GetHttpResponse(string url)
        {
            var httpClient = new HttpClient();
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
            var response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
