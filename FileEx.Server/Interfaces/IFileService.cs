namespace FileEx.Server.Interfaces
{
    public interface IFileService
    {
        public IEnumerable<string> GetDirectory(string path);
    }
}