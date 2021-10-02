using Microsoft.Extensions.Configuration;

namespace Task_11
{
    public class TextConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; set; }

        public TextConfigurationSource(string filename) => FilePath = filename;
        
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filePath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new TextConfigurationProvider(filePath);
        }
    }
}