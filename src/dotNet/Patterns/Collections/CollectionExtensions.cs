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
using System.Threading.Tasks;

namespace Patterns.Collections
{
  /// <summary>
  ///   Provides extensions for common collection types.
  /// </summary>
  public static class CollectionExtensions
  {
    /// <summary>
    ///   Adds the specified set of items to the collection.
    /// </summary>
    /// <typeparam name="TItem"> The type of the item. </typeparam>
    /// <param name="items"> The items. </param>
    /// <param name="newItems"> The new items. </param>
    public static void AddRange<TItem>(this ICollection<TItem> items, IEnumerable<TItem> newItems)
    {
      if (items == null) throw new ArgumentNullException("items");
      if (newItems == null) return;
      foreach (TItem item in newItems) items.Add(item);
    }

    /// <summary>
    ///   Runs the specified action against each item in the set.
    /// </summary>
    /// <typeparam name="TItem"> The type of the item. </typeparam>
    /// <param name="items"> The items. </param>
    /// <param name="action"> The action. </param>
    /// <param name="parallel">
    ///   if set to <c>true</c> , run in parallel.
    /// </param>
    public static void Each<TItem>(this IEnumerable<TItem> items, Action<TItem> action, bool parallel = false)
    {
      if (parallel) Parallel.ForEach(items, action);
      else
      {
        foreach (TItem item in items)
        {
          TItem currentItem = item;
          action(currentItem);
        }
      }
    }

    /// <summary>
    ///   Guarantees that the specified set is not null. If the set is null, an empty set is returned.
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <param name="set">The set.</param>
    public static IEnumerable<TItem> EmptyIfNull<TItem>(this IEnumerable<TItem> set)
    {
      return set ?? Enumerable.Empty<TItem>();
    }

    /// <summary>
    ///   Compacts the specified set by removing all null items.
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <param name="set">The set.</param>
    public static IEnumerable<TItem> Compact<TItem>(this IEnumerable<TItem> set) where TItem : class
    {
      return set.Where(item => item != null);
    }
  }
}