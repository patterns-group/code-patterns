#region FreeBSD

// Copyright (c) 2014, The Tribe
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

using Patterns.Testing.SpecFlow.Models;

using TechTalk.SpecFlow;

namespace Patterns.Testing.SpecFlow.Steps
{
  /// <summary>
  ///   Provides common transformations for values described in SpecFlow (Gherkin)
  ///   feature files.
  /// </summary>
  [Binding]
  public class CommonTransforms
  {
    /// <summary>
    ///   Converts the phrase to a <see cref="NullStatus" /> object.
    /// </summary>
    /// <param name="modifier">
    ///   The modifier, which will be set to "non-"
    ///   if the return value should be <see cref="NullStatus.NonNull" />.
    /// </param>
    [StepArgumentTransformation(@"(?i)(non-)?null")]
    public NullStatus ToNullStatus(string modifier)
    {
      return string.IsNullOrEmpty(modifier) ? NullStatus.Null : NullStatus.NonNull;
    }

    /// <summary>
    ///   Converts the phrase to a <see cref="EmptySetStatus" /> object.
    /// </summary>
    /// <param name="modifier">
    ///   The modifier, which will be set to "non-"
    ///   if the return value should be <see cref="EmptySetStatus.NonEmpty" />.
    /// </param>
    [StepArgumentTransformation(@"(?i)(non-)?empty")]
    public EmptySetStatus ToEmptySetStatus(string modifier)
    {
      return string.IsNullOrEmpty(modifier) ? EmptySetStatus.Empty : EmptySetStatus.NonEmpty;
    }
  }
}