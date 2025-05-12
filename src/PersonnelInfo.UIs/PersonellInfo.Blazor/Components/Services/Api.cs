using Microsoft.Identity.Client;
using System.Text.Json;

namespace PersonellInfo.Blazor.Components.Services;

public interface IApi
{
    Task<T> ApiGetAsync<T>(string controller, string action, CancellationToken cancellationToken = default);
    Task<T> ApiPostAsync<T>(string controller, string action, Type valueType, object value, CancellationToken cancellationToken = default);
}

public class Api : IApi
{
    private readonly string baseUrl;
    private readonly HttpClient client;
    private readonly ApiConfiguration apiConfig;

    public Api(ApiConfiguration apiConfig, HttpClient client)
    {
        this.apiConfig = apiConfig;
        baseUrl = apiConfig.Url;
        this.client = client;
        this.client.BaseAddress = new Uri(baseUrl);
    }

    public async Task<T> ApiGetAsync<T>(string controller, string action, CancellationToken cancellationToken = default)
    {
        var path = Path.Combine("api", controller, action).Replace("\\", "/");

        var response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {

        }
    }

    public async Task<T> ApiPostAsync<T>(string controller, string action, object value, CancellationToken cancellationToken = default)
    {
        var path = Path.Combine("api", controller, action).Replace("\\", "/");

        var json = JsonSerializer.Serialize(value, valueType);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var response = await client.PostAsync(path, content, cancellationToken);
    }
}
