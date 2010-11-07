using System.Net;

namespace HttpResponseLibrary
{
    public class WebHeaderBuilder
    {
        readonly WebHeaderCollection _headers;

        public WebHeaderBuilder()
        {
            _headers = new WebHeaderCollection();
        }

        public WebHeaderBuilder AddHeader(string name, string value)
        {
            _headers.Add(name, value);
            return this;
        }

        public WebHeaderCollection Build()
        {
            return _headers;
        }
    }
}
