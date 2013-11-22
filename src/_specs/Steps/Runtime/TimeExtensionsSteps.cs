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

using Patterns.Runtime;
using Patterns.Specifications.Models.Runtime;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Runtime
{
	[Binding]
	public class TimeExtensionsSteps
	{
		private readonly TimeExtensionsContext _context;

		public TimeExtensionsSteps(TimeExtensionsContext context)
		{
			_context = context;
		}

		[Given(@"I have a( second)? DateTime representation of (.+)")]
		public void CreateSpecifiedDateTime(string valueSwitch, DateTime dateTime)
		{
			if (string.IsNullOrWhiteSpace(valueSwitch))
				_context.SecondValue = dateTime;
			else
				_context.FirstValue = dateTime;
		}

		[When(@"I adjust the accuracy of each DateTime value to one second")]
		public void AdjustAccuracyToOneSecond()
		{
			_context.FirstValue = _context.FirstValue.AccurateToOneSecond();
			_context.SecondValue = _context.SecondValue.AccurateToOneSecond();
		}

		[When(@"I compare the first and second DateTime values")]
		public void CompareDateTimeValues()
		{
			_context.CalculateDifference();
		}

		[Then(@"the resulting difference should be (\d+) seconds")]
		public void AssertDifference(int seconds)
		{
			_context.Difference.Should().Be(TimeSpan.FromSeconds(seconds));
		}
	}
}