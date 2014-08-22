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

namespace Patterns.Collections
{
  /// <summary>
  ///   Provides an implementation of <see cref="IEqualityComparer{T}" /> that
  ///   allows default object-based comparison and hash retrieval logic to be
  ///   configured at construction.
  /// </summary>
  /// <typeparam name="TValue">The type of the value.</typeparam>
  public class ConfigurableEqualityComparer<TValue> : IEqualityComparer<TValue>
  {
    private readonly Func<TValue, TValue, bool> _comparison;

    private readonly Func<TValue, int> _hashCreator;

    /// <summary>
    ///   Initializes a new instance of the <see cref="ConfigurableEqualityComparer{TValue}" /> class.
    /// </summary>
    /// <param name="comparison">The optional comparison algorithm.</param>
    /// <param name="hashCreator">The optional hash code retrieval algorithm.</param>
    public ConfigurableEqualityComparer(Func<TValue, TValue, bool> comparison = null,
      Func<TValue, int> hashCreator = null)
    {
      _comparison = comparison;
      _hashCreator = hashCreator;
    }

    #region IEqualityComparer<T> Members

    /// <summary>
    ///   Determines whether the specified objects are equal.
    /// </summary>
    /// <returns>
    ///   <c>true</c> if the specified objects are equal; otherwise, <c>false</c>.
    /// </returns>
    /// <param name="x">
    ///   The first object of type <typeparamref name="TValue" /> to compare.
    /// </param>
    /// <param name="y">
    ///   The second object of type <typeparamref name="TValue" /> to compare.
    /// </param>
    public virtual bool Equals(TValue x, TValue y)
    {
      return _comparison == null
        ? object.Equals(x, y)
        : _comparison(x, y);
    }

    /// <summary>
    ///   Returns a hash code for the specified object.
    /// </summary>
    /// <returns>
    ///   A hash code for the specified object.
    /// </returns>
    /// <param name="obj">
    ///   The <see cref="T:System.Object" /> for which a hash code is to be returned.
    /// </param>
    /// <exception cref="T:System.NullReferenceException">
    ///   The type of <paramref name="obj" /> is a reference type and
    ///   <paramref
    ///     name="obj" />
    ///   is null.
    /// </exception>
    public virtual int GetHashCode(TValue obj)
    {
      return _hashCreator == null
        ? obj.GetHashCode()
        : _hashCreator(obj);
    }

    #endregion
  }
}