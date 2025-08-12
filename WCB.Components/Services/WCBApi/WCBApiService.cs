using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using WCB.Components.Services.Shared;

public class WCBApiService
{
    private readonly HttpClient _http;

    public WCBApiService(HttpClient http)
    {
        _http = http;
        _http.DefaultRequestHeaders.UserAgent.ParseAdd("WCBPaginationDemo/1.0");
    }

    public async Task<(T? Data, LinkHeader Links)> GetWithHeadersAsync<T>(string url)
    {
        var response = await _http.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var linkHeaderStr = response.Headers.Contains("Link")
            ? string.Join(",", response.Headers.GetValues("Link"))
            : null;

        var links = LinkHeader.FromHeader(linkHeaderStr);

        return (data, links);
    }
}
