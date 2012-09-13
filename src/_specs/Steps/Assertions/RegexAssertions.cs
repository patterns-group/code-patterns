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

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using FluentAssertions;

using TechTalk.SpecFlow;

using _specs.Framework;
using _specs.Steps.Factories;
using _specs.Steps.Observations;

namespace _specs.Steps.Assertions
{
	[Binding]
	public class RegexAssertions
	{
		[Then(@"the options should include the compiled option")]
		public void VerifyRegularExpressionIsCompiled()
		{
			RegexOptions compiledOption = RegexObservations.RegularExpressionOptions & RegexOptions.Compiled;
			compiledOption.Should().Be(RegexOptions.Compiled);
		}

		[Then(@"each string in the set should have resulted in a positive match against the pattern")]
		public void VerifyAllInputStringsMatchedRegex()
		{
			RegexObservations.RegularExpressionMatches.Should().HaveSameCount(RegexFactory.RegularExpressionInputStrings);
			RegexObservations.RegularExpressionMatches.Should().OnlyContain(match => match.Success);
		}

		[Then(@"all expected group values \((.+)\) should be found in the resulting dictionary")]
		public void VerifyExpectedGroupValues(string groupValues)
		{
			IDictionary<string, string> expectedValues = TextParser.ParseSimpleDictionaryString(groupValues);
			RegexObservations.RegularExpressionMatchDictionary.Should().HaveCount(expectedValues.Count);
			string[] keys = expectedValues.Keys.ToArray();
			string[] values = expectedValues.Values.ToArray();
			RegexObservations.RegularExpressionMatchDictionary.Should().ContainKeys(keys).And.ContainValues(values);
		}

		[Then(@"the pattern string I read from the CompiledRegex should match the pattern string used to create it")]
		public void VerifyRegexPatternMatchesOriginalPattern()
		{
			RegexObservations.RegularExpressionExtractedPattern.Should().Be(RegexFactory.RegularExpressionPatternString);
		}
	}
}