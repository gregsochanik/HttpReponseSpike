using System.IO;

namespace HttpResponseLibrary
{
    public class AutoFlushStreamDecorator : Stream
    {
        private readonly IFlushable _flushable;
        private readonly Stream _innerStream;

        public AutoFlushStreamDecorator(IFlushable flushable, Stream innerStream)
        {
            _flushable = flushable;
            _innerStream = innerStream;
        }

        public override void Flush()
        {
            _innerStream.Flush();
            _flushable.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _innerStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _innerStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _innerStream.Write(buffer, offset, count);
        }

        public override bool CanRead
        {
            get { return _innerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _innerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _innerStream.CanWrite; }
        }

        public override long Length
        {
            get { return _innerStream.Length; }
        }

        public override long Position
        {
            get { return _innerStream.Position; }
            set { _innerStream.Position = value; }
        }
    }
}
