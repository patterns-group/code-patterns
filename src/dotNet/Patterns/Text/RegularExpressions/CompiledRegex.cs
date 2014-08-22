#region FreeBSD

// Copyright (c) 2014, John Batte
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

namespace Patterns.Text.RegularExpressions
{
  /// <summary>
  ///   Provides a <see cref="Regex" /> implementation that is easier to instantiate.
  /// </summary>
  /// <remarks>
  ///   Instances of the <see cref="CompiledRegex" /> type are always "compiled";
  ///   that is, their <see cref="RegexOptions" /> always include the <see cref="RegexOptions.Compiled" /> option.
  /// </remarks>
  public class CompiledRegex : Regex
  {
    private static readonly IRegexEvaluator _defaultEvaluator = new RegexEvaluator();

    static CompiledRegex()
    {
      EvaluatorAccessor = () => _defaultEvaluator;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="CompiledRegex" /> class.
    /// </summary>
    /// <param name="pattern">The regular expression.</param>
    /// <param name="options">The options (optional).</param>
    public CompiledRegex(string pattern, RegexOptions options = RegexOptions.None) : base(pattern, GetOptions(options))
    {
      GroupDetails = GetGroupNumbers().ToDictionary(i => i, GroupNameFromNumber);
    }

    /// <summary>
    ///   Gets the group details.
    /// </summary>
    /// <value>The group details.</value>
    public IDictionary<int, string> GroupDetails { get; private set; }

    /// <summary>
    ///   Gets or sets the evaluator accessor.
    /// </summary>
    /// <value>
    ///   The evaluator accessor.
    /// </value>
    public static Func<IRegexEvaluator> EvaluatorAccessor { get; set; }

    /// <summary>
    ///   Gets the evaluator.
    /// </summary>
    /// <value>
    ///   The evaluator.
    /// </value>
    public static IRegexEvaluator Evaluator
    {
      get { return EvaluatorAccessor(); }
    }

    /// <summary>
    ///   Gets the first pattern match as a key-value dictionary.
    ///   Useful with patterns that use named groups.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="removeSystemGroups">
    ///   True to remove system-added groups (such as group "0", "1", etc.)
    ///   before extracting dictionary values.  The default is true.
    /// </param>
    /// <returns>The dictionary of matches.</returns>
    public IDictionary<string, string> DictionaryMatch(string input, bool removeSystemGroups = true)
    {
      Match match = Match(input);
      return ConvertMatchToDictionary(match, removeSystemGroups);
    }

    /// <summary>
    ///   Gets the pattern matches as key-value dictionaries.
    ///   Useful with patterns that use named groups.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="removeSystemGroups">
    ///   True to remove system-added groups (such as group "0") before extracting
    ///   dictionary values.  The default is true.
    /// </param>
    /// <returns>A collection of matches formatted as key-value dictionaries.</returns>
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

    /// <summary>
    ///   Implicitly converts strings into instances of <see cref="CompiledRegex" />.
    /// </summary>
    /// <param name="pattern">The regular expression.</param>
    /// <returns>The compiled regular expression.</returns>
    public static implicit operator CompiledRegex(string pattern)
    {
      return new CompiledRegex(pattern);
    }

    /// <summary>
    ///   Builds a new <see cref="CompiledRegex" /> instance from the specified raw text.  Reserved characters are
    ///   automatically escaped,
    ///   causing them to serve as required components of the resulting pattern.  Whitespace is always interpreted to be of
    ///   variable length (i.e. all
    ///   contiguous whitespace blocks are replaced with the \s+ search term).  Useful in scenarios were existing text is used
    ///   to match against
    ///   other values.
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