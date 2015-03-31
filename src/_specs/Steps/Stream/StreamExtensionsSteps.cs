using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Patterns.Specifications.Models.Stream;
using Patterns.Stream;
using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Stream
{
	[Binding]
	public class StreamExtensionsSteps
	{
		private Action _act;
		private DummyUnseekableStream _dummyUnseekableStream;
		private MemoryStream _memoryStream;
		private byte[] _resultData;

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

		[Given(@"I have a DummyUnseekableStream")]
		public void GivenIHaveADummyUnseekableStream()
		{
			_dummyUnseekableStream = new DummyUnseekableStream();
		}

		[Given(@"I advance the position")]
		public void GivenIAdvanceThePosition()
		{
			_dummyUnseekableStream.ReadByte();
		}

		[When(@"I call reset position")]
		public void WhenIPressCallResetPosition()
		{
			_memoryStream.ResetPosition();
		}

		[When(@"I call ToArray on the memory stream")]
		public void WhenICallToArrayOnTheMemoryStream()
		{
			_resultData = ((System.IO.Stream)_memoryStream).ToArray();
		}

		[When(@"I attempt to call ToArray on the DummyUnseekableStream")]
		public void WhenIAttemptToCallToArrayOnTheDummyUnseekableStream()
		{
			_act = () => _dummyUnseekableStream.ToArray();
		}

		[When(@"I call ToArray on the DummyUnseekableStream")]
		public void WhenICallToArrayOnTheDummyUnseekableStream()
		{
			_resultData = _dummyUnseekableStream.ToArray();
		}

		[Then(@"the position should be at the beginning")]
		public void ThenThePositionShouldBeAtTheBeginning()
		{
			_memoryStream.Position.Should().Be(0);
		}

		[Then(@"the result byte array should be ""(.*)""")]
		public void ThenTheResultByteArrayShouldBe(string p0)
		{
			Encoding.UTF8.GetString(_resultData).Should().Be(p0);
		}

		[Then(@"I get an exception with message ""(.*)""")]
		public void ThenIGetAnExceptionWithMessage(string p0)
		{
			_act.ShouldThrow<InvalidOperationException>().WithMessage(p0);
		}

		[Then(@"I get empty result")]
		public void ThenIGetEmptyResult()
		{
			_resultData.Should().BeEmpty();
		}
	}
}