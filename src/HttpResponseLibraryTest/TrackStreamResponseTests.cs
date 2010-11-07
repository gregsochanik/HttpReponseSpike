using System.IO;
using System.Net;
using HttpResponseLibrary;
using HttpResponseLibrary.Track;
using NUnit.Framework;
using Rhino.Mocks;

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

            using (var response = new TrackStreamer(new StreamFactory()).StreamTrack("mediapool/06 Siberian Breaks.mp3"))
            {
                Assert.AreEqual(expectedHeaders, response.Headers);
                Assert.Greater(response.ResponseStream.Length, 0);
                Assert.AreEqual(response.ResponseStream.Length, 11636864);
            }
        }
    }

    public class TrackStreamResponseTests
    {
        [Test]
        public void SuccessCtor()
        {
            var stream = MockRepository.GenerateStub<Stream>();
            var headers = new WebHeaderCollection();

            var trackStreamResponse = new TrackStreamResponse(stream, headers);

            Assert.AreSame(stream, trackStreamResponse.ResponseStream);
            Assert.AreEqual(headers, trackStreamResponse.Headers);
        }

        [Test]
        public void Response_should_be_closed_when_streamresponse_disposed()
        {
            var stream = MockRepository.GenerateStub<Stream>();
            var headers = new WebHeaderCollection();

            using(var trackStreamResponse = new TrackStreamResponse(stream, headers))
            {
                stream.AssertWasNotCalled(x =>x.Close());
            }
            stream.AssertWasCalled(x=>x.Close());
        }
    }


}
