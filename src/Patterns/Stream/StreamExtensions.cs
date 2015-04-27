using System;
using System.IO;

namespace Patterns.Stream
{
	/// <summary>
	///    Provides extensions for streams
	/// </summary>
	public static class StreamExtensions
	{
		/// <summary>
		///    Convert a stream to a byte array
		/// </summary>
		/// <param name="self">The stream to convert</param>
		/// <returns>The byte array which this stream contains</returns>
		/// <exception cref="InvalidOperationException">When stream is not at beginning and stream.CanSeek == false</exception>
		public static byte[] ToArray(this System.IO.Stream self)
		{
			var memoryStream = self as MemoryStream;
			if (memoryStream == null)
			{
				long position, length;
				try
				{
					position = self.Position;
					length = self.Length;
				}
				catch (NotSupportedException)
				{
					memoryStream = new MemoryStream();
					self.CopyTo(memoryStream);
					return memoryStream.ToArray();
				}

				//Attempts to fail early
				if (position != 0)
				{
					if (!self.CanSeek)
					{
						throw new InvalidOperationException("Input stream is not at beginning and cannot seek. Conversion will lose data");
					}
					self.Seek(0, SeekOrigin.Begin);
				}
				memoryStream = new MemoryStream(Convert.ToInt32(length));
				self.CopyTo(memoryStream);
			}
			return memoryStream.ToArray();
		}

		/// <summary>
		///    Reset the stream to be at the beginning
		/// </summary>
		/// <param name="self">The stream to reset</param>
		public static void ResetPosition(this MemoryStream self)
		{
			self.Seek(0, SeekOrigin.Begin);
		}
	}
}