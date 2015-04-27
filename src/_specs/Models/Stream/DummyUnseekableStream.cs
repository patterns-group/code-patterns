using System;
using System.IO;

namespace Patterns.Specifications.Models.Stream
{
	public class DummyUnseekableStream : System.IO.Stream
	{
		private long _position;

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return false; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override long Length
		{
			get { return 0; }
		}

		public override long Position
		{
			get { return _position; }
			set { throw new NotSupportedException(); }
		}

		public override void Flush()
		{
			throw new NotSupportedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			_position += buffer.Length;
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}
	}
}