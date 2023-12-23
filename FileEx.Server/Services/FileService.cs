using FileEx.Server.Interfaces;

namespace FileEx.Server.Services
{
    internal sealed class FileService : IFileService
    {
        public IEnumerable<string> GetDirectory(string path)
        {
            IEnumerable<string> result;

            var files = Directory.EnumerateFiles(path);
            var directories = Directory.EnumerateDirectories(path);
            result = files.Concat(directories);
            
            return result;
        }
    }
}