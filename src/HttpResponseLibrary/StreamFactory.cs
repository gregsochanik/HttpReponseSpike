using System.IO;

namespace HttpResponseLibrary
{
    public class StreamFactory : IStreamFactory
    {
        public Stream GetStream(string filePath)
        {
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
    }
}