using System.Collections;

namespace FileEx.Client;

public interface IFileService
{
    public Task<IEnumerable<string>> GetDirectory(string path);
}
