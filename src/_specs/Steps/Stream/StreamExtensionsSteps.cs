using System.IO;
using System.Text;
using FluentAssertions;
using Patterns.Stream;
using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Stream
{
	[Binding]
	public class StreamExtensionsSteps
	{

		private MemoryStream _memoryStream;

		[Given(@"I have a memory stream of ""(.*)""")]
		public void GivenIHaveAMemoryStreamOf(string p0)
		{
			_memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(p0));
		}

		[Given(@"I set the position to be at the end")]
		public void GivenISetThePositionToBeAtTheEnd()
		{
			_memoryStream.Seek(0, SeekOrigin.End);
		}

		[When(@"I call reset position")]
		public void WhenIPressCallResetPosition()
		{
			_memoryStream.ResetPosition();
		}

		[Then(@"the position should be at the beginning")]
		public void ThenThePositionShouldBeAtTheBeginning()
		{
			_memoryStream.Position.Should().Be(0);
		}
		


		//private System.IO.Stream _stream;
		//private byte[] _conversionResult;

		//[Given(@"I have a memory stream of ""(.*)""")]
		//public void GivenIHaveAMemoryStreamOf(string p0)
		//{
		//	_stream = new MemoryStream(Encoding.UTF8.GetBytes(p0));
		//}
		


		//[Given(@"I set the position to be at the end")]
		//public void GivenISetThePositionToBeAtTheEnd()
		//{
		//	_stream.Seek(0, SeekOrigin.End);
		//}
		
		//[When(@"I call reset position")]
		//public void WhenIPressCallResetPosition()
		//{
		//	_stream.ResetPosition();
		//}

		//[Then(@"the position should be at the beginning")]
		//public void ThenThePositionShouldBeAtTheBeginning()
		//{
		//	_stream.Position.Should().Be(0);
		//}

		//[When(@"I call ToArray")]
		//public void WhenICallToArray()
		//{
		//	_conversionResult = _stream.ToArray();
		//}


		//[Then(@"the result byte array should be ""(.*)""")]
		//public void ThenTheResultByteArrayShouldBe(string p0)
		//{
		//	ScenarioContext.Current.Pending();
		//}
	}
}