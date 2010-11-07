using System.IO;

namespace HttpResponseLibrary
{
    public interface IStreamFactory
    {
        Stream GetStream(string filePath);
    }
}