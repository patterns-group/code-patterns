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

using System.Collections.Generic;
using FluentAssertions;
using Patterns.Specifications.Models.Text;
using Patterns.Specifications.Models.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Text.RegularExpressions
{
	[Binding]
	public class DictionaryMatchSteps
	{
		private readonly CompiledRegexContext _context;
		private readonly DictionaryParserContext _dictionaries;

		public DictionaryMatchSteps(CompiledRegexContext context, DictionaryParserContext dictionaries)
		{
			_context = context;
			_dictionaries = dictionaries;
		}

		[When(@"I retrieve a dictionary match of the string using the CompiledRegex")]
		public void GetDictionaryMatch()
		{
			_context.DictionaryMatch = _context.Pattern.DictionaryMatch(_context.PatternTarget);
		}

		[Then(@"all expected group values \((.*)\) should be found in the resulting dictionary")]
		public void AssertGroupValues(string groupValues)
		{
			IDictionary<string, string> expected = _dictionaries.Parser.ParseKeyValuePairs(groupValues);
			_context.DictionaryMatch.ShouldAllBeEquivalentTo(expected);
		}
	}
}