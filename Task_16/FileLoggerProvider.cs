using Microsoft.Extensions.Logging;

namespace Task_16
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string _path;

        public FileLoggerProvider(string path) => _path = path;

        public void Dispose() { }

        public ILogger CreateLogger(string categoryName) => new FileLogger(_path);
    }
}