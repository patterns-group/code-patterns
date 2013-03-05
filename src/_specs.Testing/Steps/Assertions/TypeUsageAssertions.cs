#region New BSD License

// Copyright (c) 2012, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions
// and the following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions
// and the following disclaimer in the documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

#endregion

using FluentAssertions;

using Patterns.Specifications.Framework;
using Patterns.Specifications.Framework.TestTargets;
using Patterns.Specifications.Steps.Automation;
using Patterns.Specifications.Steps.Observations;
using Patterns.Testing.Values;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Assertions
{
	[Binding]
	public class TypeUsageAssertions
	{
		[Then(@"the method call should abort")]
		public void CheckEmptyCallResult()
		{
			TestObservations.CallResult.Should().BeNull();
		}

		[Then(@"the method call should complete with no errors")]
		public void CheckValidCallResult()
		{
			TestObservations.CallResult.Should().Be(TypeUsageAutomation.Finish);
		}

		[Then(@"the feed for method call requests should have returned (.+) item")]
		public void CheckCallRequestCount(int count)
		{
			int actual = TypeUsageObservations.CallRequests.Count;
			int expected = TypeUsageObservations.LastCapturedReadRequestCount + count;
			actual.Should().Be(expected);
		}

		[Then(@"the feed for method call responses should have returned (.+) item(.+)?")]
		public void CheckCallResponseCount(int count, string trailingS)
		{
			int actual = TypeUsageObservations.CallResponses.Count;
			int expected = TypeUsageObservations.LastCapturedCallResponseCount + count;
			actual.Should().Be(expected);
		}

		[Then(@"the feed for property read requests should have returned (.+) item")]
		public void CheckReadRequestCount(int count)
		{
			int actual = TypeUsageObservations.ReadRequests.Count;
			int expected = TypeUsageObservations.LastCapturedReadRequestCount + count;
			actual.Should().Be(expected);
		}

		[Then(@"the feed for property read responses should have returned (.+) item(.+)?")]
		public void CheckReadResponseCount(int count, string trailingS)
		{
			int actual = TypeUsageObservations.ReadResponses.Count;
			int expected = TypeUsageObservations.LastCapturedReadResponseCount + count;
			actual.Should().Be(expected);
		}

		[Then(@"the feed for property write requests should have returned (.+) item(.+)?")]
		public void CheckWriteRequestCount(int count, string trailingS)
		{
			int actual = TypeUsageObservations.WriteRequests.Count;
			int expected = TypeUsageObservations.LastCapturedWriteRequestCount + count;
			actual.Should().Be(expected);
		}

		[Then(@"the feed for errors should have returned (.+) item(s)?")]
		public void CheckErrorCount(int count, string trailingS)
		{
			int actual = TestObservations.Errors.Count;
			int expected = TestObservations.LastCapturedErrorCount + count;
			actual.Should().Be(expected);
		}

		[Then(@"the value I read should be the default value for the return type")]
		public void CheckPropertyReadResultIsDefault()
		{
			object defaultPropertyValue = TemperamentalTestSubject.TestPropertyType.GetDefault();
			TestObservations.CallResult.Should().Be(defaultPropertyValue);
		}

		[Then(@"the value that I read should be the value I expected")]
		public void CheckPropertyReadResult()
		{
			object expectedPropertyValue = TemperamentalTestSubject.DefaultPropertyValue;
			TestObservations.CallResult.Should().Be(expectedPropertyValue);
		}

		[Then(@"the value that I read should be the value I wrote")]
		public void CheckPropertyWriteResult()
		{
			object expectedPropertyValue = TypeUsageAutomation.PropertyWriteValue;
			TestObservations.CallResult.Should().Be(expectedPropertyValue);
		}
	}
}