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

using System;

using FluentAssertions;

using Patterns.Specifications.Steps.Observations;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Assertions
{
	[Binding]
	public class TimeAssertions
	{
		[Then(@"the results of both ""now"" DateTime values should be equal")]
		public void VerifyBothNowValuesMatch()
		{
			var custom = TimeObservations.PrimaryDateTime;
			var customValue = new DateTime(custom.Year, custom.Month, custom.Day, custom.Hour, custom.Minute, custom.Second);
			var system = TimeObservations.SecondaryDateTime;
			var systemValue = new DateTime(system.Year, system.Month, system.Day, system.Hour, system.Minute, system.Second);
			customValue.Should().Be(systemValue);
		}

		[Given(@"the DateTime values vary by millisecond")]
		public void VerifyBothNowValuesVaryByMillisecond()
		{
			var primary = TimeObservations.PrimaryDateTime;
			var secondary = TimeObservations.SecondaryDateTime;
			primary.Should().NotBe(secondary);
			primary.Year.Should().Be(secondary.Year);
			primary.Month.Should().Be(secondary.Month);
			primary.Day.Should().Be(secondary.Day);
			primary.Hour.Should().Be(secondary.Hour);
			primary.Minute.Should().Be(secondary.Minute);
			primary.Second.Should().Be(secondary.Second);
			primary.Millisecond.Should().NotBe(secondary.Millisecond);
		}

		[Then(@"the resulting difference should be zero")]
		public void VerifyDateTimeDeltaIsZero()
		{
			TimeObservations.DateTimeDelta.Should().Be(TimeSpan.Zero);
		}
	}
}