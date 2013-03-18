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

using Autofac;

using FluentAssertions;

using Patterns.Autofac.Logging;
using Patterns.Specifications.Models.Autofac;
using Patterns.Specifications.Models.Logging;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Logging
{
	[Binding]
	public class ManualLoggingSteps
	{
		private readonly AutofacContext _autofac;
		private readonly ManualLoggingContext _context;

		public ManualLoggingSteps(AutofacContext autofac, ManualLoggingContext context)
		{
			_autofac = autofac;
			_context = context;
		}

		[Given(@"I have registered the logging module with a trackable log factory")]
		public void RegisterTrackableLoggingModule()
		{
			_autofac.Builder.RegisterModule(new ManualTestLoggingModule(type =>
			{
				_context.TypeUsedForLoggerRequest = type;
				return LoggingModule.DefaultLogFactory(type);
			}));
		}

		[Given(@"I have registered the manual logging test subject")]
		public void RegisterManualLoggingTestSubject()
		{
			_autofac.Builder.RegisterType<ManualLoggingTestSubject>();
		}

		[When(@"I have resolved an instance of the manual logging test subject")]
		public void ResolveManualLoggingTestSubject()
		{
			_context.TestSubject = _autofac.Container.Resolve<ManualLoggingTestSubject>();
		}

		[Then(@"the resolved ILog should be type-bound to the manual logging test subject")]
		public void AssertLoggerIsCorrectlyTypeBound()
		{
			_context.TestSubject.Log.Should().NotBeNull();
			_context.TypeUsedForLoggerRequest.Should().Be(typeof (ManualLoggingTestSubject));
		}
	}
}