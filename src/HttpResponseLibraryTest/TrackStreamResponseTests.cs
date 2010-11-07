using System.IO;
using System.Net;
using HttpResponseLibrary.Track;
using NUnit.Framework;
using Rhino.Mocks;

namespace HttpResponseLibraryTest
{
    public class TrackStreamResponseTests
    {
        [Test]
        public void SuccessCtor()
        {
            var stream = MockRepository.GenerateStub<Stream>();
            var headers = new WebHeaderCollection();

            var trackStreamResponse = new TrackStreamResponse(headers, stream);

            Assert.AreSame(stream, trackStreamResponse.ResponseStream);
            Assert.AreEqual(headers, trackStreamResponse.Headers);
        }

        [Test]
        public void Response_should_be_closed_when_streamresponse_disposed()
        {
            var stream = MockRepository.GenerateStub<Stream>();
            var headers = new WebHeaderCollection();

            using(var trackStreamResponse = new TrackStreamResponse(headers, stream))
            {
                stream.AssertWasNotCalled(x =>x.Close());
            }
            stream.AssertWasCalled(x=>x.Close());
        }
    }


}
