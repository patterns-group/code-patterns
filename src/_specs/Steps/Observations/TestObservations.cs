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

using System.Collections.Generic;

using FluentAssertions;

using Patterns.Specifications.Framework;
using Patterns.Specifications.Properties;
using Patterns.Specifications.Steps.State;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Observations
{
	[Binding]
	public class TestObservations
	{
		private static readonly string _resultKey = ScenarioContext.Current.NewKey();
		private static readonly string _errorKey = ScenarioContext.Current.NewKey();
		private static readonly string _capturedErrorCountKey = ScenarioContext.Current.NewKey();

		static TestObservations()
		{
			Initialize();
		}

		private static void Initialize()
		{
			Errors = Errors ?? new List<TestEvent>();
		}

		public static object CallResult
		{
			get { return ScenarioContext.Current.GetValue<object>(_resultKey); }
			set { ScenarioContext.Current[_resultKey] = value; }
		}

		public static List<TestEvent> Errors
		{
			get { return ScenarioContext.Current.GetValue<List<TestEvent>>(_errorKey); }
			private set { ScenarioContext.Current[_errorKey] = value; }
		}

		public static int LastCapturedErrorCount
		{
			get { return ScenarioContext.Current.GetValue<int>(_capturedErrorCountKey); }
			set { ScenarioContext.Current[_capturedErrorCountKey] = value; }
		}

		public static void ObserveError(TestEvent errorEvent)
		{
			Errors.Add(errorEvent);
		}

		[Given(@"I have created an observable feed for test errors")]
		public void CheckErrorFeed()
		{
			Errors.Should().NotBeNull(Resources.CheckErrorFeedReason);
		}

		[Before("trackErrors")]
		public void LogErrorCounts()
		{
			Initialize();
			LastCapturedErrorCount = Errors.Count;
		}
	}
}