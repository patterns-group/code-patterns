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

using System.Linq;

using FluentAssertions;

using Patterns.Collections;
using Patterns.Specifications.Models.Collections;
using Patterns.Testing.SpecFlow.Models;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Collections
{
  [Binding]
  public class NullSafeCollectionSteps
  {
    private readonly CollectionOperationsContext<string> _strings;

    public NullSafeCollectionSteps(CollectionOperationsContext<string> strings)
    {
      _strings = strings;
    }

    [Given(@"I have (\d+) strings with (\d+) null items")]
    public void SetupStrings(int itemCount, int nullCount)
    {
      _strings.RequestSet = CollectionFactory.CreateSet<string>(itemCount, nullCount);
      _strings.RequestSet.DebugWriteLine(CollectionModelResources.OriginalStringsLabel);
    }

    [Given(@"I have a set of strings set to (null|non-null)")]
    public void SetupStrings(NullStatus status)
    {
      _strings.RequestSet = status == NullStatus.NonNull
        ? CollectionFactory.CreateSet<string>(10, randomize: false)
        : null;

      _strings.RequestSet.DebugWriteLine(CollectionModelResources.OriginalStringsLabel);
    }

    [When(@"I compact the set of strings")]
    public void CompactStringSet()
    {
      _strings.ResponseSet = _strings.RequestSet.Compact();
      _strings.ResponseSet.DebugWriteLine(CollectionModelResources.ResultStringsLabel);
    }

    [When(@"I guarantee that the set of strings is non-null")]
    public void EmptyStringSetIfNull()
    {
      _strings.ResponseSet = _strings.RequestSet.EmptyIfNull();
      _strings.ResponseSet.DebugWriteLine(CollectionModelResources.ResultStringsLabel);
    }

    [Then(@"the resulting set of strings should have (\d+) items")]
    public void AssertResultStringSetCount(int expected)
    {
      _strings.ResponseSet.Should().HaveCount(expected);
    }

    [Then(@"all items in the resulting set of strings should be non-null")]
    public void AssertResultStringSetAllNonNull()
    {
      string reason = CollectionModelResources.AssertResultStringSetAllNonNull_Reason;
      _strings.ResponseSet.All(item => item != null).Should().BeTrue(reason);
    }

    [Then(@"the result should be a non-null, (empty|non-empty) set of strings")]
    public void AssertResultStringSetNonNullOrEmpty(EmptySetStatus status)
    {
      string nonNullReason = CollectionModelResources.AssertResultStringSetNonNull_Reason;
      string nonEmptyReason = CollectionModelResources.AssertResultStringSetNonEmpty_Reason;
      string emptyReason = CollectionModelResources.AssertResultStringSetEmpty_Reason;

      _strings.ResponseSet.Should().NotBeNull(nonNullReason);

      if (status == EmptySetStatus.Empty) _strings.ResponseSet.Should().BeEmpty(emptyReason);
      else _strings.ResponseSet.Should().NotBeEmpty(nonEmptyReason);
    }
  }
}