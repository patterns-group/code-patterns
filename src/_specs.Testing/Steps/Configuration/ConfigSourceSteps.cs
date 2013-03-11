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

using System;

using FluentAssertions;

using Patterns.Configuration;
using Patterns.Specifications.Models;
using Patterns.Specifications.Models.Configuration;
using Patterns.Specifications.Models.Mocking;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Configuration
{
	[Binding]
	public class ConfigSourceSteps
	{
		private readonly ConfigSourceContext _context;
		private readonly MoqContext _moq;
		private readonly ErrorContext _errors;

		public ConfigSourceSteps(ConfigSourceContext context, MoqContext moq, ErrorContext errors)
		{
			_context = context;
			_moq = moq;
			_errors = errors;
		}

		[Given(@"I have a new Configuration Source using the mocked config abstraction")]
		public void CreateSourceUsingMockedAbstraction()
		{
			_context.ConfigSource = new ConfigurationSource(_moq.Container.Mock<IConfigurationManager>().Object, config => new ConfigurationWrapper(config));
		}

		[When(@"I ask for a Configuration Section named ""(.*)"" from the Configuration Source")]
		public void RequestConfigSection(string sectionName)
		{
			try
			{
				_context.ResolvedSection = _context.ConfigSource.GetSection(sectionName);
			}
			catch (Exception error)
			{
				_errors.LastError = error;
			}
		}

		[Then(@"the Configuration Section I retrieved from the Configuration Source should be null")]
		public void VerifyResolvedConfigSectionNull()
		{
			_context.ResolvedSection.Should().BeNull();
		}

		[Then(@"the Configuration Section I retrieved from the Configuration Source should be the expected section")]
		public void VerifyResolvedSectionType()
		{
			_context.ResolvedSection.Should().NotBeNull().And.BeOfType<TestConfigurationSection>();
		}

		[Then(@"the Configuration Section I retrieved from the Configuration Source should not be the expected section")]
		public void VerifyResolveSectionWrongType()
		{
			_context.ResolvedSection.Should().NotBeNull();
			_context.ResolvedSection.GetType().Should().NotBe(typeof (TestConfigurationSection));
		}
	}
}