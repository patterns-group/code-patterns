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

using Moq;
using Moq.Contrib.Indy;

using TechTalk.SpecFlow;

using _specs.Framework;
using _specs.Framework.TestTargets;

namespace _specs.Steps.Factories
{
	[Binding]
	public class MockFactory : TechTalk.SpecFlow.Steps
	{
		private static readonly string _mocksKey = ScenarioContext.Current.NewKey();

		public static IMockContainer Mocks
		{
			get { return ScenarioContext.Current.SafeGet<IMockContainer>(_mocksKey); }
			private set { ScenarioContext.Current[_mocksKey] = value; }
		}

		[Given(@"I have a fresh mock container")]
		public void ResetMocks()
		{
			Mocks = new AutoMockContainer(new MockRepository(MockBehavior.Loose));
		}

		[Given(@"I have a mocked test bucket that is prepared to verify calls")]
		public void CreateMockedTestBucket()
		{
			Given("I have a collection with 0 items");
			Mocks.GetMock<ITestBucket>().Setup(bucket => bucket.Add(It.IsAny<TestSubject>())).Callback<TestSubject>(TestSubjectFactory.SubjectCollection.Add);
		}
	}
}