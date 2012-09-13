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

using System.Linq;

using TechTalk.SpecFlow;

using _specs.Steps.Factories;
using _specs.Steps.Observations;

namespace _specs.Steps.Automation
{
	[Binding]
	public class RegexAutomation
	{
		[When(@"I read the options of the CompiledRegex")]
		public void ReadCompiledRegexOptions()
		{
			RegexObservations.RegularExpressionOptions = RegexFactory.RegularExpression.Options;
		}

		[When(@"I use the CompiledRegex against each string in the set")]
		public void TestRegexAgainstInputStrings()
		{
			RegexObservations.RegularExpressionMatches = RegexFactory.RegularExpressionInputStrings.Select(item => RegexFactory.RegularExpression.Match(item));
		}

		[When(@"I retrieve a dictionary match of the string using the CompiledRegex")]
		public void RegexDictionaryMatchAgainstSingleInput()
		{
			RegexObservations.RegularExpressionMatchDictionary = RegexFactory.RegularExpression.DictionaryMatch(RegexFactory.RegularExpressionSingleInputString);
		}

		[When(@"I read the pattern string from the CompiledRegex")]
		public void ReadRegexPatternString()
		{
			RegexObservations.RegularExpressionExtractedPattern = RegexFactory.RegularExpression.ToString();
		}
	}
}