using System;
using System.Collections.Specialized;
using System.IO;
using HttpResponseLibrary;
using HttpResponseLibrary.Track;

namespace HttpResponseSpike
{
    public partial class _Default : System.Web.UI.Page, IFlushable
    {
        private TrackStreamer _trackStreamer;

        protected void Page_Load(object sender, EventArgs e)
        {
            _trackStreamer = new TrackStreamer(new StreamFactory());
        }

        protected void LinkButton1Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/mediapool/06 Siberian Breaks.mp3");
            OutputResponse(filePath);
        }

        protected void LinkButton2Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/mediapool/08 Of Moons, Birds & Monsters.mp3");
            OutputResponse(filePath);
        }

        private void OutputResponse(string filePath)
        {
            var autoFlushStream = new AutoFlushStreamDecorator(this, Response.OutputStream);

            using (var response = _trackStreamer.StreamTrack(filePath))
            {
                CopyHeaders(response.Headers);
                CopyStream(response.ResponseStream, autoFlushStream);
            }
        }

        private void CopyHeaders(NameValueCollection input)
        {
            foreach (string headerKey in input.Keys)
            {
                Response.AddHeader(headerKey, input[headerKey]);
            }
        }

        private static void CopyStream(Stream input, Stream output)
        {
            var buffer = new byte[32768];
            while (true)
            {
                int read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return;
                output.Write(buffer, 0, read);
            }
        }

        public void Flush()
        {
            Response.Flush();

            if (Response.IsClientConnected == false)
            {
                Response.End();
            }
        }
    }
}
