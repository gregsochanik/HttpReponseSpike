using System;
using System.Collections.Specialized;
using System.IO;

namespace HttpResponseLibrary.Track
{
    public class TrackStreamResponse : IDisposable
    {
        public NameValueCollection Headers { get; set; }
        public Stream ResponseStream { get; set; }

        public TrackStreamResponse(NameValueCollection headers, Stream responseStream)
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

