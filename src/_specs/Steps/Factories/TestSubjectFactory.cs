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
using System.Linq;

using FizzWare.NBuilder;

using TechTalk.SpecFlow;

using _specs.Framework;
using _specs.Framework.TestTargets;

namespace _specs.Steps.Factories
{
	[Binding]
	public class TestSubjectFactory : TechTalk.SpecFlow.Steps
	{
		private static readonly string _testSubjectKey = ScenarioContext.Current.NewKey();
		private static readonly string _testSubjectCollectionKey = ScenarioContext.Current.NewKey();
		private static readonly string _testSubjectSetKey = ScenarioContext.Current.NewKey();

		public static TemperamentalTestSubject TestySubject
		{
			get { return ScenarioContext.Current.SafeGet<TemperamentalTestSubject>(_testSubjectKey); }
			private set { ScenarioContext.Current[_testSubjectKey] = value; }
		}

		public static ICollection<TestSubject> SubjectCollection
		{
			get { return ScenarioContext.Current.SafeGet<ICollection<TestSubject>>(_testSubjectCollectionKey); }
			private set { ScenarioContext.Current[_testSubjectCollectionKey] = value; }
		}

		public static IEnumerable<TestSubject> SubjectSet
		{
			get { return ScenarioContext.Current.SafeGet<IEnumerable<TestSubject>>(_testSubjectSetKey); }
			private set { ScenarioContext.Current[_testSubjectSetKey] = value; }
		}

		[Given(@"I have prepared a test subject")]
		public void CreateTestSubject()
		{
			TestySubject = new TemperamentalTestSubject();
		}

		[Given(@"I have an empty collection")]
		public void CreateEmptyCollection()
		{
			SubjectCollection = new List<TestSubject>();
		}

		[Given(@"I have a collection with (.+) item(s)?")]
		public void CreateCollection(int count, string trailingS)
		{
			SubjectCollection = count <= 0 ? new List<TestSubject>() : Builder<TestSubject>.CreateListOfSize(count).Build();
		}

		[Given(@"I have a null collection")]
		public void CreateNullCollection()
		{
			SubjectCollection = null;
		}

		[Given(@"I have a set with (.+) item(s)?")]
		public void CreateSet(int count, string trailingS)
		{
			SubjectSet = count <= 0 ? Enumerable.Empty<TestSubject>() : Builder<TestSubject>.CreateListOfSize(count).Build();
		}
	}
}