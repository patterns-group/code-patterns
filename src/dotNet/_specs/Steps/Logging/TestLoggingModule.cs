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

using Autofac;
using Autofac.Extras.DynamicProxy2;

using Common.Logging;

using Moq;

using Patterns.Configuration;
using Patterns.Logging;
using Patterns.Specifications.Models.Logging;
using Patterns.Specifications.Models.Mocking;

namespace Patterns.Specifications.Steps.Logging
{
	public class TestLoggingModule : Module
	{
		private readonly MoqContext _moq;
		private readonly bool _trapExceptions;

		public TestLoggingModule(MoqContext moq, bool trapExceptions)
		{
			_moq = moq;
			_trapExceptions = trapExceptions;
		}

		protected override void Load(ContainerBuilder builder)
		{
			Mock<IConfigurationSource> mockSource = _moq.Container.Mock<IConfigurationSource>();

			LoggingConfig config = _trapExceptions ? LoggingConfigs.ErrorTrappingConfig : LoggingConfigs.DefaultConfig;
			mockSource.Setup(source => source.GetSection(LoggingConfig.SectionName)).Returns(config);
			mockSource.Setup(source => source.GetSection<LoggingConfig>(LoggingConfig.SectionName)).Returns(config);
			builder.RegisterInstance(mockSource.Object);

			builder.Register<Func<Type, ILog>>(context => type => _moq.CreateMockLog().Object);

			builder.RegisterType<LoggingTestSubject>().EnableClassInterceptors().InterceptedBy(typeof(LoggingInterceptor));
		}
	}
}