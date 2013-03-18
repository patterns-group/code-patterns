#region FreeBSD

// Copyright (c) 2013, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that
// the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the
//    following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the
//    following disclaimer in the documentation and/or other materials provided with the distribution.
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

using System.Configuration;

using Moq;

using Patterns.Configuration;
using Patterns.Specifications.Models.Configuration;
using Patterns.Specifications.Models.Mocking;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Configuration
{
	[Binding]
	public class MockedConfigAbstractionSteps
	{
		private readonly MoqContext _moq;

		public MockedConfigAbstractionSteps(MoqContext moq)
		{
			_moq = moq;
		}

		[Given(@"I have set the mocked config abstraction to throw an exception when asked for a Configuration Section with the section name ""(.*)""")]
		public void ThrowExceptionForSectionName(string sectionName)
		{
			_moq.Container.Mock<IConfigurationManager>().Setup(manager => manager.GetSection(sectionName)).Throws(new ConfigurationErrorsException());
		}

		[Given(@"I have set the mocked config abstraction to return a null Configuration Section when the section name is ""(.*)""")]
		public void ReturnNullForSectionName(string sectionName)
		{
			_moq.Container.Mock<IConfigurationManager>().Setup(manager => manager.GetSection(sectionName)).Returns(null);
		}

		[Given(@"I have set the mocked config abstraction to return a Configuration Section when the section name is ""(.*)""")]
		public void ReturnSectionForSectionName(string sectionName)
		{
			_moq.Container.Mock<IConfigurationManager>().Setup(manager => manager.GetSection(sectionName)).Returns(new TestConfigurationSection());
		}

		[Given(@"I have set the mocked config abstraction to return a different Configuration Section when the section name is ""(.*)""")]
		public void ReturnWrongSectionForSectionName(string sectionName)
		{
			_moq.Container.Mock<IConfigurationManager>().Setup(manager => manager.GetSection(sectionName)).Returns(new InvalidConfigurationSection());
		}

		[Then(@"the mocked config abstraction should have been asked for a Configuration Section named ""(.*)"" exactly (.*) time")]
		public void VerifyGetSectionCalls(string sectionName, int count)
		{
			_moq.Container.Mock<IConfigurationManager>().Verify(manager => manager.GetSection(sectionName), Times.Exactly(count));
		}
	}
}