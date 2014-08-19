#region FreeBSD

// Copyright (c) 2013, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
// TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;

using FluentAssertions;

using Patterns.Collections;
using Patterns.Collections.Strategies;
using Patterns.Specifications.Models.Collections;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Collections
{
	[Binding]
	public class EqualityComparerSteps
	{
		private readonly EqualityComparerContext _context;

		private static readonly FuncStrategies<string, IEqualityComparer<string>> _stringComparerConstructors
			= new FuncStrategies<string, IEqualityComparer<string>>
			{
				{"default", () => new ConfigurableEqualityComparer<string>()},
				{"case sensitive", () => new ConfigurableEqualityComparer<string>((left, right) => left == right)},
				{"case insensitive", () => new ConfigurableEqualityComparer<string>(StringComparer.OrdinalIgnoreCase.Equals)}
			};

		public EqualityComparerSteps(EqualityComparerContext context)
		{
			_context = context;
		}

		[Given(@"I have created a new equality comparer for strings using the (.+) strategy")]
		public void CreateStringComparer(string strategy)
		{
			_stringComparerConstructors.Should().ContainKey(strategy);
			_context.StringComparer = _stringComparerConstructors.Execute(strategy);
		}

		[When(@"I compare the (.+) string to the (.+) string")]
		public void CompareStrings(string left, string right)
		{
			_context.ComparisonResult = _context.StringComparer.Equals(left, right);
		}

		[Then(@"the result of the ""is equal"" operation should be (.+)")]
		public void AssertComparisonResult(bool expected)
		{
			_context.ComparisonResult.Should().Be(expected);
		}
	}
}