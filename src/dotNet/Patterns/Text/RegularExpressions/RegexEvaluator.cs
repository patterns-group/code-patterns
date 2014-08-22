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

using System.Text.RegularExpressions;

namespace Patterns.Text.RegularExpressions
{
  /// <summary>
  ///   Defines a default implementation of the <see cref="IRegexEvaluator" /> interface.
  /// </summary>
  public class RegexEvaluator : IRegexEvaluator
  {
    /// <summary>
    ///   Indicates whether the regular expression finds a match in the input string.
    /// </summary>
    /// <param name="input">The string to search for a match.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>
    ///   <c>true</c> if the regular expression finds a match; otherwise, <c>false</c>.
    /// </returns>
    public bool IsMatch(string input, CompiledRegex pattern)
    {
      return pattern.IsMatch(input);
    }

    /// <summary>
    ///   Searches the specified input string for the first occurrence of the specified regular expression.
    /// </summary>
    /// <param name="input">The string to search for a match.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>
    ///   An object that contains information about the match.
    /// </returns>
    public Match Match(string input, CompiledRegex pattern)
    {
      return pattern.Match(input);
    }

    /// <summary>
    ///   Searches the specified input string for all occurrences of a specified regular expression.
    /// </summary>
    /// <param name="input">The string to search for a match.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>
    ///   A collection of the <see cref="Match" /> objects found by the search.
    ///   If no matches are found, the method returns an empty collection object.
    /// </returns>
    public MatchCollection Matches(string input, CompiledRegex pattern)
    {
      return pattern.Matches(input);
    }

    /// <summary>
    ///   In a specified input string, replaces all strings that match a specified
    ///   regular expression with a specified replacement string.
    /// </summary>
    /// <param name="input">The string to search for a match.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <param name="replacement">The replacement string.</param>
    /// <returns>
    ///   A new string that is identical to the input string, except that the replacement
    ///   string takes the place of each matched string.
    /// </returns>
    public string Replace(string input, CompiledRegex pattern, string replacement)
    {
      return pattern.Replace(input, replacement);
    }

    /// <summary>
    ///   Splits an input string into an array of substrings at the positions defined by a regular expression pattern.
    /// </summary>
    /// <param name="input">The string to search for a match.</param>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>
    ///   An array of strings.
    /// </returns>
    public string[] Split(string input, CompiledRegex pattern)
    {
      return pattern.Split(input);
    }
  }
}