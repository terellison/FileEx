
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
        _connectionInfo = config.Get<string>();
    }
    public async Task<IEnumerable<string>> GetDirectory(string path)
    {
        var response = await _client.PostAsync($"{_connectionInfo}/{nameof(GetDirectory)}?path={path}", null);

        return null;
    }
}
