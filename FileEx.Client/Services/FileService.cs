
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FileEx.Client;

public class FileService : IFileService
{
    private readonly HttpClient _client;
    private readonly string _connectionInfo;

    public FileService(HttpClient client, IConfiguration config)
    {
        _client = client;
        _connectionInfo = config.GetValue<string>("ConnectionInfo");
    }
    public async Task<IEnumerable<string>> GetDirectory(string path)
    {
        var response = await _client.PostAsync($"{_connectionInfo}/{nameof(GetDirectory)}?path={path}", null);

        return null;
    }

    public async Task<HttpStatusCode> HealthCheck()
    {
        return (await _client.GetAsync(_connectionInfo)).StatusCode;
    }
}
