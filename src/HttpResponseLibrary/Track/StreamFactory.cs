using System.IO;

namespace HttpResponseLibrary.Track
{
    public class StreamFactory : IStreamFactory
    {
        public Stream GetStream(string filePath)
        {
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
    }
}