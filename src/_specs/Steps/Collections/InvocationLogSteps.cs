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

using System.Linq;

using FluentAssertions;

using Patterns.Specifications.Models.Collections;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Collections
{
	[Binding]
	public class InvocationLogSteps
	{
		private readonly EachContext _context;

		public InvocationLogSteps(EachContext context)
		{
			_context = context;
		}

		[Then(@"the invocation log should contain (.*) items")]
		public void AssertLogCount(int count)
		{
			_context.InvocationLog.Count.Should().Be(count);
		}

		[Then(@"there should be more than one unique Thread ID in the invocation log")]
		public void AssertMultipleThreadsInLog()
		{
			_context.InvocationLog.Select(log => log.ThreadId).Distinct().Count().Should().BeGreaterThan(1);
		}

		[Then(@"each Thread ID in the invocation log should be the same")]
		public void AssertSingleThreadInLog()
		{
			_context.InvocationLog.Select(log => log.ThreadId).Distinct().Count().Should().Be(1);
		}
	}
}