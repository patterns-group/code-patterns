#region FreeBSD

// Copyright (c) 2013, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
// TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;

using Patterns.Specifications.Framework.TestTargets;
using Patterns.Specifications.Steps.Factories;
using Patterns.Specifications.Steps.State;
using Patterns.Testing.SpecFlow;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Observations
{
	[Binding]
	public class TypeUsageObservations
	{
		private static readonly string _readRequestKey = ScenarioContext.Current.NewKey();
		private static readonly string _readResponseKey = ScenarioContext.Current.NewKey();
		private static readonly string _writeRequestKey = ScenarioContext.Current.NewKey();
		private static readonly string _callRequestKey = ScenarioContext.Current.NewKey();
		private static readonly string _callResponseKey = ScenarioContext.Current.NewKey();
		private static readonly string _capturedReadRequestCountKey = ScenarioContext.Current.NewKey();
		private static readonly string _capturedReadResponseCountKey = ScenarioContext.Current.NewKey();
		private static readonly string _capturedWriteRequestCountKey = ScenarioContext.Current.NewKey();
		private static readonly string _capturedCallRequestCountKey = ScenarioContext.Current.NewKey();
		private static readonly string _capturedCallResponseCountKey = ScenarioContext.Current.NewKey();

		public static List<TestEvent> ReadRequests
		{
			get { return ScenarioContext.Current.GetValue<List<TestEvent>>(_readRequestKey); }
			private set { ScenarioContext.Current[_readRequestKey] = value; }
		}

		public static List<TestEvent> ReadResponses
		{
			get { return ScenarioContext.Current.GetValue<List<TestEvent>>(_readResponseKey); }
			private set { ScenarioContext.Current[_readResponseKey] = value; }
		}

		public static List<TestEvent> WriteRequests
		{
			get { return ScenarioContext.Current.GetValue<List<TestEvent>>(_writeRequestKey); }
			private set { ScenarioContext.Current[_writeRequestKey] = value; }
		}

		public static List<TestEvent> CallRequests
		{
			get { return ScenarioContext.Current.GetValue<List<TestEvent>>(_callRequestKey); }
			private set { ScenarioContext.Current[_callRequestKey] = value; }
		}

		public static List<TestEvent> CallResponses
		{
			get { return ScenarioContext.Current.GetValue<List<TestEvent>>(_callResponseKey); }
			private set { ScenarioContext.Current[_callResponseKey] = value; }
		}

		public static int LastCapturedReadRequestCount
		{
			get { return ScenarioContext.Current.GetValue<int>(_capturedReadRequestCountKey); }
			set { ScenarioContext.Current[_capturedReadRequestCountKey] = value; }
		}

		public static int LastCapturedReadResponseCount
		{
			get { return ScenarioContext.Current.GetValue<int>(_capturedReadResponseCountKey); }
			set { ScenarioContext.Current[_capturedReadResponseCountKey] = value; }
		}

		public static int LastCapturedWriteRequestCount
		{
			get { return ScenarioContext.Current.GetValue<int>(_capturedWriteRequestCountKey); }
			set { ScenarioContext.Current[_capturedWriteRequestCountKey] = value; }
		}

		public static int LastCapturedCallRequestCount
		{
			get { return ScenarioContext.Current.GetValue<int>(_capturedCallRequestCountKey); }
			set { ScenarioContext.Current[_capturedCallRequestCountKey] = value; }
		}

		public static int LastCapturedCallResponseCount
		{
			get { return ScenarioContext.Current.GetValue<int>(_capturedCallResponseCountKey); }
			set { ScenarioContext.Current[_capturedCallResponseCountKey] = value; }
		}

		private static void InitializeNullTrackers()
		{
			ReadRequests = ReadRequests ?? new List<TestEvent>();
			ReadResponses = ReadResponses ?? new List<TestEvent>();
			WriteRequests = WriteRequests ?? new List<TestEvent>();
			CallRequests = CallRequests ?? new List<TestEvent>();
			CallResponses = CallResponses ?? new List<TestEvent>();
		}

		[Before("trackCalls")]
		public void LogCallCounts()
		{
			InitializeNullTrackers();
			LastCapturedCallRequestCount = CallRequests.Count;
			LastCapturedCallResponseCount = CallResponses.Count;
		}

		[Before("trackReads")]
		public void LogReadCounts()
		{
			InitializeNullTrackers();
			LastCapturedReadRequestCount = ReadRequests.Count;
			LastCapturedReadResponseCount = ReadResponses.Count;
		}

		[Before("trackWrites")]
		public void LogWriteCounts()
		{
			InitializeNullTrackers();
			LastCapturedWriteRequestCount = WriteRequests.Count;
		}

		[Given(@"I have subscribed to all observable feeds on the subject")]
		public void SubscribeToAll()
		{
			TemperamentalTestSubject subject = TestSubjectFactory.TestySubject;
			subject.CallRequests.Subscribe(CallRequests.Add);
			subject.CallResponses.Subscribe(CallResponses.Add);
			subject.ReadRequests.Subscribe(ReadRequests.Add);
			subject.ReadResponses.Subscribe(ReadResponses.Add);
			subject.WriteRequests.Subscribe(WriteRequests.Add);
		}
	}
}