
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FileEx.Client;

public class FileService : IFileService
{
    private readonly HttpClient _client;
    private readonly string _connectionInfo;

    public FileService(HttpClient client, IOptions<Settings> options)
    {
        _client = client;
        _connectionInfo = options.Value.ConnectionInfo ?? 
            throw new NullReferenceException("Loading ConnectionInfo from appsettings.json failed.");
        
    }
    public async Task<IEnumerable<string>> GetDirectory(string path)
    {
        var response = await _client.PostAsync($"{_connectionInfo}/{nameof(GetDirectory)}?path={path}", null);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        if(response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<IEnumerable<string>>(jsonResponse) ??
                new List<string>();
        }
        else
        {
            throw new InvalidOperationException($"Fetching {path} failed with error {jsonResponse}");
        }
    }

    public async Task<HttpStatusCode> HealthCheck()
    {
        return (await _client.GetAsync(_connectionInfo)).StatusCode;
    }
}
