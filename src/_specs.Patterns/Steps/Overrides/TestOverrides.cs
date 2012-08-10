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

using System.Diagnostics;
using System.Threading;

using Patterns.ExceptionHandling;
using Patterns.Specifications.Steps.Automation;
using Patterns.Specifications.Steps.Observations;
using Patterns.Specifications.Steps.State;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Overrides
{
	[Binding]
	public class TestOverrides
	{
		[Given(@"I have set the default error handling behavior to record all errors for the test")]
		public void RecordAllErrors()
		{
			Try.HandleErrors.DefaultStrategy = exception =>
			{
				TestObservations.ObserveError(new TestEvent());
				return new ExceptionState(exception, true);
			};
		}

		[Given(@"I have a custom error handler that does not write to the error feed")]
		public void WriteErrorsToDebug()
		{
			Try.HandleErrors.DefaultStrategy = exception =>
			{
				Debug.WriteLine(exception);
				return new ExceptionState(exception, true);
			};
		}

		[Given(@"I set my ""add to test bucket"" logic to set the thread Id on the item and then call Add")]
		public void SetTestBucketAddLogicToParallel()
		{
			TestBucketAutomation.AddToTestBucketLogic = (bucket, subject) =>
			{
				subject.ThreadId = Thread.CurrentThread.ManagedThreadId;
				bucket.Add(subject);
			};
		}

		[Given(@"I set my ""add to test bucket"" logic to be a simple call to Add")]
		public void SetTestBucketAddLogicToSerial()
		{
			TestBucketAutomation.AddToTestBucketLogic = (bucket, subject) => bucket.Add(subject);
		}
	}
}