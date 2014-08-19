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

using FluentAssertions;

using Patterns.Runtime;
using Patterns.Specifications.Models.Autofac;
using Patterns.Specifications.Models.Runtime;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Runtime
{
	[Binding]
	public class DateTimeInfoSteps
	{
		private readonly AutofacContext _autofac;
		private readonly DateTimeInfoContext _context;

		public DateTimeInfoSteps(DateTimeInfoContext context, AutofacContext autofac)
		{
			_context = context;
			_autofac = autofac;
		}

		[Given(@"I have a default DateTime abstraction")]
		public void CreateDefaultDateTimeInfo()
		{
			_context.DateTimeInfo = new DefaultDateTimeInfo();
		}

		[When(@"I try to resolve an IDateTimeInfo instance")]
		public void ResolveIDateTimeInfo()
		{
			_context.DateTimeInfo = _autofac.Container.Resolve<IDateTimeInfo>();
		}

		[When(@"I store the results of both the DateTime\.Now property and the IDateTimeInfo\.GetNow method")]
		public void StoreBothDateTimeResults()
		{
			_context.CustomNow = _context.DateTimeInfo.GetNow();
			_context.SystemNow = DateTime.Now;
		}

		[When(@"I store the results of both the DateTime\.UtcNow property and the IDateTimeInfo\.GetUtcNow method")]
		public void StoreBothUtcDateTimeResults()
		{
			_context.CustomNow = _context.DateTimeInfo.GetUtcNow();
			_context.SystemNow = DateTime.UtcNow;
		}

		[Then(@"the resolved IDateTimeInfo object should be an instance of DefaultDateTimeInfo")]
		public void AssertResolvedIDateTimeInfoIsDefault()
		{
			_context.DateTimeInfo.Should().NotBeNull();
			_context.DateTimeInfo.GetType().Should().Be(typeof (DefaultDateTimeInfo));
		}

		[Then(@"the results of both ""now"" DateTime values should be equal")]
		public void BothDateTimeResultsShouldEqual()
		{
			_context.CustomNow.AccurateToOneSecond().Should().Be(_context.SystemNow.AccurateToOneSecond());
		}
	}
}