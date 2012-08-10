using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Patterns.Text.RegularExpressions
{
	///<summary>
	///	Provides a <see cref = "Regex" /> implementation that is easier to instantiate.
	///</summary>
	///<remarks>
	///	Instances of the <see cref = "CompiledRegex" /> type are always "compiled";
	///	that is, their <see cref = "RegexOptions" /> always include the <see cref = "RegexOptions.Compiled" /> option.
	///</remarks>
	public class CompiledRegex : Regex
	{
		///<summary>
		///	Initializes a new instance of the <see cref = "CompiledRegex" /> class.
		///</summary>
		///<param name = "pattern">The regular expression.</param>
		///<param name = "options">The options (optional).</param>
		public CompiledRegex(string pattern, RegexOptions options = RegexOptions.None) : base(pattern, GetOptions(options))
		{
			GroupDetails = GetGroupNumbers().ToDictionary(i => i, GroupNameFromNumber);
		}

		/// <summary>
		/// 	Gets the group details.
		/// </summary>
		/// <value>The group details.</value>
		public IDictionary<int, string> GroupDetails { get; private set; }

		///<summary>
		///	Gets the first pattern match as a key-value dictionary.
		///	Useful with patterns that use named groups.
		///</summary>
		///<param name = "input">The input.</param>
		///<param name = "removeSystemGroups">True to remove system-added groups (such as group "0", "1", etc.) 
		///	before extracting dictionary values.  The default is true.</param>
		///<returns>The dictionary of matches.</returns>
		public IDictionary<string, string> DictionaryMatch(string input, bool removeSystemGroups = true)
		{
			Match match = Match(input);
			return ConvertMatchToDictionary(match, removeSystemGroups);
		}

		///<summary>
		///	Gets the pattern matches as key-value dictionaries.
		///	Useful with patterns that use named groups.
		///</summary>
		///<param name = "input">The input.</param>
		///<param name = "removeSystemGroups">True to remove system-added groups (such as group "0") before extracting
		///	dictionary values.  The default is true.</param>
		///<returns>A collection of matches formatted as key-value dictionaries.</returns>
		public IEnumerable<IDictionary<string, string>> DictionaryMatches(string input, bool removeSystemGroups = true)
		{
			MatchCollection matches = Matches(input);
			return matches.Cast<Match>().Select(m => ConvertMatchToDictionary(m, removeSystemGroups));
		}

		private IDictionary<string, string> ConvertMatchToDictionary(Match match, bool removeSystemGroups)
		{
			Dictionary<string, string> allValues = GroupDetails.Values
				.ToDictionary(s => s, s => match.Groups[s].Value);

			return removeSystemGroups
			       	? allValues.SkipWhile(IsSystemGroup).ToDictionary(p => p.Key, p => p.Value)
			       	: allValues;
		}

		///<summary>
		///	Implicitly converts strings into instances of <see cref = "CompiledRegex" />.
		///</summary>
		///<param name = "pattern">The regular expression.</param>
		///<returns>The compiled regular expression.</returns>
		public static implicit operator CompiledRegex(string pattern)
		{
			return new CompiledRegex(pattern);
		}

		/// <summary>
		/// Builds a new <see cref="CompiledRegex"/> instance from the specified raw text.  Reserved characters are automatically escaped,
		/// causing them to serve as required components of the resulting pattern.  Whitespace is always interpreted to be of variable length (i.e. all
		/// contiguous whitespace blocks are replaced with the \s+ search term).  Useful in scenarios were existing text is used to match against
		/// other values.
		/// </summary>
		/// <param name="text">The raw text.</param>
		/// <param name="options">The options (optional).</param>
		/// <returns></returns>
		public static CompiledRegex BuildFrom(string text, RegexOptions options = RegexOptions.None)
		{
			const string whiteSpace = @"\s+";
			string escapedText = string.Join(whiteSpace, Split(text, whiteSpace).Select(Escape).ToArray());
			return new CompiledRegex(escapedText, options);
		}

		private static RegexOptions GetOptions(RegexOptions originalOptions)
		{
			if ((originalOptions & RegexOptions.Compiled) != RegexOptions.Compiled) originalOptions |= RegexOptions.Compiled;
			return originalOptions;
		}

		private static bool IsSystemGroup(KeyValuePair<string, string> pair)
		{
			int value;
			return int.TryParse(pair.Key, out value);
		}
	}
}