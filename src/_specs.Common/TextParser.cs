using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.Specifications.Common
{
	public class TextParser
	{
		private const string _simpleStringDictionaryParseErrorFormat = "Could not parse {0} as a simple string dictionary. Format must be: key1:value1;key2:value2";

		public static IDictionary<string, string> ParseSimpleDictionaryString(string text)
		{
			try
			{
				return text.Split(';').Select(pair => pair.Split(':')).ToDictionary(item => item[0], item => item[1]);
			}
			catch
			{
				throw new Exception(string.Format(_simpleStringDictionaryParseErrorFormat, text));
			}
		}
	}
}