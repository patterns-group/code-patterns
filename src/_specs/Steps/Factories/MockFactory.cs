#region New BSD License

// // Copyright (c) 2013, John Batte
// // All rights reserved.
// // 
// // Redistribution and use in source and binary forms, with or without modification, are permitted
// // provided that the following conditions are met:
// // 
// // Redistributions of source code must retain the above copyright notice, this list of conditions
// // and the following disclaimer.
// // 
// // Redistributions in binary form must reproduce the above copyright notice, this list of conditions
// // and the following disclaimer in the documentation and/or other materials provided with the distribution.
// // 
// // THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// // WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// // PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// // ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// // TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// // HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// // NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// // POSSIBILITY OF SUCH DAMAGE.

#endregion

using System.Configuration;

using FluentAssertions;

using Moq;

using Patterns.Configuration;
using Patterns.Specifications.Framework;
using Patterns.Specifications.Framework.TestTargets;
using Patterns.Specifications.Steps.Observations;
using Patterns.Testing.Moq;
using Patterns.Testing.SpecFlow;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Factories
{
	[Binding]
	public class MockFactory : TechTalk.SpecFlow.Steps
	{
		private static readonly string _mocksKey = ScenarioContext.Current.NewKey();

		public static IMoqContainer Mocks
		{
			get { return ScenarioContext.Current.GetValue<IMoqContainer>(_mocksKey); }
			private set { ScenarioContext.Current[_mocksKey] = value; }
		}

		[Given(@"I have a fresh mock container")]
		public void ResetMocks()
		{
			Init(true);
		}

		public static void Init(bool force = false)
		{
			if (Mocks != null && !force) return;
			Mocks = new MoqContainer();
		}

		[Given(@"I have a mocked test bucket that is prepared to verify calls")]
		public void CreateMockedTestBucket()
		{
			Given("I have a collection with 0 items");
			Mocks.Mock<ITestBucket>().Setup(bucket => bucket.Add(It.IsAny<TestSubject>())).Callback<TestSubject>(TestSubjectFactory.SubjectCollection.Add);
		}

		[Given(@"I have a mocked config abstraction")]
		public void CreateConfigAbstractionMocks()
		{
			Mocks.Mock<IConfigurationManager>().Should().NotBeNull();
		}

		[Given(@"I have set the mocked config abstraction to return a (null )?Configuration Section when the section name is ""(.*)""")]
		public void SetupConfigAbstractionMockGetSection(string isNull, string sectionName)
		{
			ConfigObservations.ExpectedConfig = new TestConfigSection();
			bool useNull = !string.IsNullOrEmpty(isNull);
			Mocks.Mock<IConfigurationManager>().Setup(manager => manager.GetSection(sectionName)).Returns(useNull ? null : ConfigObservations.ExpectedConfig);
		}

		[Given(@"I have set the mocked config abstraction to throw an exception when asked for a Configuration Section with the section name ""(.*)""")]
		public void SetupConfigAbstractionMockGetSectionThrowException(string sectionName)
		{
			Mocks.Mock<IConfigurationManager>().Setup(manager => manager.GetSection(sectionName)).Throws(new ConfigurationErrorsException());
		}

		[Given(@"I have set the mocked config abstraction to return a different Configuration Section when the section name is ""(.*)""")]
		public void SetupConfigAbstractionGetExceptionWrongType(string sectionName)
		{
			ConfigObservations.ExpectedConfig = new TestConfigSection();
			Mocks.Mock<IConfigurationManager>().Setup(manager => manager.GetSection(sectionName)).Returns(new AlternateTestConfigSection());
		}
	}
}