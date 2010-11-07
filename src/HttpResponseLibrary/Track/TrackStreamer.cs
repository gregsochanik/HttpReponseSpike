﻿using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace HttpResponseLibrary.Track
{
    public class TrackStreamer : IStreamer
    {
        private readonly IStreamFactory _streamFactory;

        public TrackStreamer(IStreamFactory streamFactory)
        {
            _streamFactory = streamFactory;
        }

        public TrackStreamResponse StreamTrack(string filePath)
        {
            var stream = _streamFactory.GetStream(filePath) as FileStream;
            string downloadFlename = CleanFilename(filePath);
            long fileLength = RegisterFileLength(stream);
            WebHeaderCollection headers = SetResponseHeaders(fileLength, downloadFlename);
            return new TrackStreamResponse(stream, headers);
        }

        private static long RegisterFileLength(FileStream stream)
        {
            if (stream == null)
                return 0;
            return stream.Length;
        }

        private static string CleanFilename(string filePath)
        {
            string fileName = Path.GetFileName(filePath) ?? filePath;
            return Regex.Replace(fileName, " ", "_");
        }

        private static WebHeaderCollection SetResponseHeaders(long fileLength, string downloadFlename)
        {
            return new WebHeaderCollection
                       {
                           {HttpResponseHeader.ContentType, "audio/mpeg"},
                           {HttpResponseHeader.ContentLength, fileLength.ToString()},
                           {"Content-Disposition", string.Format("attachment; filename={0}", downloadFlename)}
                       };
        }
    }
}