using System;
using System.IO;
using System.Net;

namespace HttpResponseLibrary.Track
{
    public class TrackStreamResponse : IDisposable
    {
        public WebHeaderCollection Headers { get; set; }
        public Stream ResponseStream { get; set; }

        public TrackStreamResponse(WebHeaderCollection headers, Stream responseStream)
        {
            Headers = headers;
            ResponseStream = responseStream;
        }

        public void Dispose()
        {
            if (ResponseStream == null)
                return;

            ResponseStream.Close();
        }
    }
}

