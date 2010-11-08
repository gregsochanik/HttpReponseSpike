using System.Net;
using HttpResponseLibrary;
using HttpResponseLibrary.Track;
using NUnit.Framework;

namespace HttpResponseLibraryTest
{
    public class TrackStreamerTests
    {
        [Test]
        [Category("Integration")]
        public void Should_return_correct_response_when_passed_filename()
        {
            var expectedHeaders = new WebHeaderCollection
                                      {
                                          {HttpResponseHeader.ContentType, "audio/mpeg"},
                                          {HttpResponseHeader.ContentLength, "11636864"},
                                          {"Content-Disposition", string.Format("attachment; filename={0}","06_Siberian_Breaks.mp3")}
                                      };

            using (var trackStreamResponse = new TrackStreamer(new StreamFactory()).StreamTrack("mediapool/06 Siberian Breaks.mp3"))
            {
                Assert.AreEqual(expectedHeaders, trackStreamResponse.Headers);
                Assert.Greater(trackStreamResponse.ResponseStream.Length, 0);
                Assert.AreEqual(trackStreamResponse.ResponseStream.Length, 11636864);
            }
        }
    }
}