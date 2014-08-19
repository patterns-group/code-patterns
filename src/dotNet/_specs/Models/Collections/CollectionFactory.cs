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

using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;
using Patterns.Collections.Strategies;

namespace Patterns.Specifications.Models.Collections
{
  public class CollectionFactory
  {
    private static readonly RandomGenerator _generator = new RandomGenerator();
    private static readonly Random _random = new MersenneTwister(true);

    private static readonly FuncStrategies<Type, Func<object>> _defaultFactoryBuilders
      = new FuncStrategies<Type, Func<object>>
      {
        {typeof (string), () => () => _generator.Phrase(20)}
      };

    public static IEnumerable<TItem> CreateSet<TItem>(int count, int defaultItemCount = 0,
      Func<TItem> itemFactory = null, bool randomize = true)
    {
      itemFactory = itemFactory ?? ResolveItemFactory<TItem>();

      IEnumerable<int> defaultRange = Enumerable.Range(0, defaultItemCount);
      IEnumerable<int> range = Enumerable.Range(0, count - defaultItemCount);
      var items = new List<TItem>(range.Select(_ => itemFactory())
        .Concat(defaultRange.Select(_ => default(TItem))));

      return randomize ? Randomize(items) : items;
    }

    private static Func<TItem> ResolveItemFactory<TItem>()
    {
      Type itemType = typeof (TItem);
      Func<object> factory = _defaultFactoryBuilders.Execute(itemType);

      if (factory == null)
      {
        string message = string.Format(CollectionModelResources.DefaultFactoryNotFound, itemType);
        throw new NotImplementedException(message);
      }

      return () => (TItem) factory();
    }

    private static IEnumerable<TItem> Randomize<TItem>(IList<TItem> items)
    {
      return DiscreteUniform.Samples(_random, 0, items.Count - 1)
        .Distinct().Take(items.Count)
        .Select(position => items[position])
        .ToArray();
    }
  }
}