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
using System.Text.RegularExpressions;
using FluentAssertions;
using Patterns.Specifications.Models.Text.RegularExpressions;
using Patterns.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Text.RegularExpressions
{
	[Binding]
	public class CompiledRegexSteps
	{
		private readonly CompiledRegexContext _context;

		public CompiledRegexSteps(CompiledRegexContext context)
		{
			_context = context;
		}

		[Given(@"I have created a CompiledRegex using a simple, valid pattern string")]
		public void CreateSimpleCompiledRegex()
		{
			_context.Pattern = TextSamples.SimplePattern;
		}

		[Given(@"I have created a CompiledRegex with the pattern: (.*)")]
		public void CreateCompiledRegex(string pattern)
		{
			_context.Pattern = pattern;
		}

		[Given(@"I have created a CompiledRegex using a valid pattern string")]
		public void CreateValidCompiledRegex()
		{
			_context.Pattern = TextSamples.ValidPatternString;
		}

		[Given(@"I have created a string equal to: (.*)")]
		public void SetPatternTarget(string input)
		{
			_context.PatternTarget = input;
		}

		[Given(@"I have a set of strings with various character patterns")]
		public void GetCharacterPatternStrings()
		{
			_context.CharacterPatternStrings = TextSamples.CharacterPatterns;
		}

		[When(@"I use the CompiledRegex\.Build method to create a CompiledRegex using a string containing a common pattern")]
		public void BuildCommonCompiledRegex()
		{
			_context.Pattern = CompiledRegex.BuildFrom(TextSamples.CharacterPatternCommonString);
		}

		[When(@"I read the options of the CompiledRegex")]
		public void ReadCompiledRegexOptions()
		{
			_context.PatternOptions = _context.Pattern.Options;
		}

		[When(@"I use the CompiledRegex against each string in the set")]
		public void MatchEachCharacterPattern()
		{
			_context.CharacterPatternMatches = _context.CharacterPatternStrings.Select(input => _context.Pattern.Match(input));
		}

		[When(@"I read the pattern string from the CompiledRegex")]
		public void WhenIReadThePatternStringFromTheCompiledRegex()
		{
			_context.PatternAsString = _context.Pattern.ToString();
		}

		[Then(@"the options of the CompiledRegex should include the compiled option")]
		public void AssertPatternIsCompiled()
		{
			var isCompiled = (_context.PatternOptions & RegexOptions.Compiled) == RegexOptions.Compiled;
			isCompiled.Should().BeTrue();
		}

		[Then(@"each string in the set should have resulted in a positive match against the pattern")]
		public void AssertAllPositiveMatches()
		{
			_context.CharacterPatternMatches.All(match => match.Success).Should().BeTrue();
		}

		[Then(@"the pattern string I read from the CompiledRegex should be the valid pattern string used to create it")]
		public void AssertPatternMatchesOriginalPattern()
		{
			_context.PatternAsString.Should().Be(TextSamples.ValidPatternString);
		}
	}
}