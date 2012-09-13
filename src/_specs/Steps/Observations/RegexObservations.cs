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
using System.Text.RegularExpressions;

using TechTalk.SpecFlow;

using _specs.Framework;

namespace _specs.Steps.Observations
{
	public class RegexObservations
	{
		private static readonly string _regexOptionsKey = ScenarioContext.Current.NewKey();
		private static readonly string _regexMatchesKey = ScenarioContext.Current.NewKey();
		private static readonly string _regexMatchDictionaryKey = ScenarioContext.Current.NewKey();
		private static readonly string _regexExtractedPatternKey = ScenarioContext.Current.NewKey();

		public static string RegularExpressionExtractedPattern
		{
			get { return ScenarioContext.Current.SafeGet<string>(_regexExtractedPatternKey); }
			set { ScenarioContext.Current[_regexExtractedPatternKey] = value; }
		}

		public static IDictionary<string, string> RegularExpressionMatchDictionary
		{
			get { return ScenarioContext.Current.SafeGet<IDictionary<string, string>>(_regexMatchDictionaryKey); }
			set { ScenarioContext.Current[_regexMatchDictionaryKey] = value; }
		}

		public static IEnumerable<Match> RegularExpressionMatches
		{
			get { return ScenarioContext.Current.SafeGet<IEnumerable<Match>>(_regexMatchesKey); }
			set { ScenarioContext.Current[_regexMatchesKey] = value; }
		}

		public static RegexOptions RegularExpressionOptions
		{
			get { return ScenarioContext.Current.SafeGet<RegexOptions>(_regexOptionsKey); }
			set { ScenarioContext.Current[_regexOptionsKey] = value; }
		}
	}
}