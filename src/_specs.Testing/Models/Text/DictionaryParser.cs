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
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Patterns.Specifications.Models.Text
{
	public class DictionaryParser : IDictionaryParser
	{
		private static readonly string _pairFormat = TextModelResources.DictionaryParseExamplePairFormat;
		private static readonly string _exampleFormat = TextModelResources.DictionaryParseExampleFormat;
		private static readonly string _errorFormat = TextModelResources.DictionaryParseErrorFormat;
		private readonly Regex _columnPattern;
		private readonly DictionaryParserConfig _config;
		private readonly Regex _rowPattern;

		public DictionaryParser(DictionaryParserConfig config)
		{
			_config = config;
			_columnPattern = new Regex(Regex.Escape(_config.ColumnDelimiter), RegexOptions.Compiled);
			_rowPattern = new Regex(Regex.Escape(_config.RowDelimiter), RegexOptions.Compiled);
		}

		public IDictionary<string, string> ParseKeyValuePairs(string text)
		{
			try
			{
				return _rowPattern.Split(text)
					.Select(row => _columnPattern.Split(row))
					.ToDictionary(item => item[0], item => item[1]);
			}
			catch (Exception error)
			{
				string message = BuildErrorMessage(text);
				throw new Exception(message, error);
			}
		}

		private string BuildErrorMessage(string text)
		{
			string firstPair = string.Format(_pairFormat, 1, _config.ColumnDelimiter);
			string secondPair = string.Format(_pairFormat, 2, _config.ColumnDelimiter);
			string example = string.Format(_exampleFormat, firstPair, _config.RowDelimiter, secondPair);
			string message = string.Format(_errorFormat, text, example);
			return message;
		}
	}
}