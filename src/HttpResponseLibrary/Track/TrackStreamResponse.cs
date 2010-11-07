using System;
using System.IO;
using System.Net;

namespace HttpResponseLibrary.Track
{
    public class TrackStreamResponse : IDisposable
    {
        public WebHeaderCollection Headers { get; set; }
        public Stream ResponseStream { get; set; }

        public TrackStreamResponse(Stream responseStream, WebHeaderCollection headers)
        {
            ResponseStream = responseStream;
            Headers = headers;
        }

        public void Dispose()
        {
            if (ResponseStream == null)
                return;

            ResponseStream.Close();
        }
    }
}

