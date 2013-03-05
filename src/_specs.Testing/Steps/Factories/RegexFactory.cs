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

using Patterns.Specifications.Framework;
using Patterns.Testing.SpecFlow;
using Patterns.Text.RegularExpressions;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Factories
{
	[Binding]
	public class RegexFactory
	{
		private static readonly string _regexSingleInputStringKey = ScenarioContext.Current.NewKey();
		private static readonly string _regexPatternStringKey = ScenarioContext.Current.NewKey();
		private static readonly string _regexInputStringsKey = ScenarioContext.Current.NewKey();
		private static readonly string _compiledRegexKey = ScenarioContext.Current.NewKey();

		public static string RegularExpressionSingleInputString
		{
			get { return ScenarioContext.Current.GetValue<string>(_regexSingleInputStringKey); }
			set { ScenarioContext.Current[_regexSingleInputStringKey] = value; }
		}

		public static string RegularExpressionPatternString
		{
			get { return ScenarioContext.Current.GetValue<string>(_regexPatternStringKey); }
			set { ScenarioContext.Current[_regexPatternStringKey] = value; }
		}

		public static IEnumerable<string> RegularExpressionInputStrings
		{
			get { return ScenarioContext.Current.GetValue<IEnumerable<string>>(_regexInputStringsKey); }
			set { ScenarioContext.Current[_regexInputStringsKey] = value; }
		}

		public static CompiledRegex RegularExpression
		{
			get { return ScenarioContext.Current.GetValue<CompiledRegex>(_compiledRegexKey); }
			set { ScenarioContext.Current[_compiledRegexKey] = value; }
		}

		[Given(@"I have created a CompiledRegex using a simple, valid pattern string")]
		public void CreateSimpleRegex()
		{
			RegularExpression = @"(\s+|\d+)+";
		}

		[Given(@"I have created a CompiledRegex using a valid pattern string")]
		public void CreateNormalRegex()
		{
			RegularExpressionPatternString = @"^\w+@[a-z]{1}(\w+)?\.[a-z]{1}(\w+)?$";
			RegularExpression = RegularExpressionPatternString;
		}

		[Given(@"I have a set of strings with various character patterns")]
		public void CreateRegexInputStrings()
		{
			RegularExpressionInputStrings = new[]
			{
				"person1@gmail.com",
				"second_person@gmail.com",
				"person_the_3rd@gmail.com"
			};
		}

		[Given(@"I have a sample string that contains a pattern that is common to all strings in the set")]
		public void CreateRegexSampleString()
		{
			RegularExpressionPatternString = "@gmail.com";
		}

		[Given(@"I have created a string equal to: (.+)")]
		public void CreateSingleRegexInputString(string contents)
		{
			RegularExpressionSingleInputString = contents;
		}

		[Given(@"I have created a CompiledRegex with the pattern: (.+)")]
		public void CreateRegex(string pattern)
		{
			RegularExpression = pattern;
		}

		[When(@"I use the CompiledRegex\.Build method to create a CompiledRegex using the sample string")]
		public void BuildRegexFromSampleString()
		{
			RegularExpression = CompiledRegex.BuildFrom(RegularExpressionPatternString);
		}
	}
}