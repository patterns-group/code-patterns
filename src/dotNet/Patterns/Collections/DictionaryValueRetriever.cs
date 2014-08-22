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
  ///   Defines a default implementation of the <see cref="IDictionaryValueRetriever{TKey,TValue}" /> interface.
  /// </summary>
  /// <typeparam name="TKey">The type of the key.</typeparam>
  /// <typeparam name="TValue">The type of the value.</typeparam>
  public class DictionaryValueRetriever<TKey, TValue> : IDictionaryValueRetriever<TKey, TValue>
  {
    private readonly IDictionary<TKey, TValue> _dictionary;
    private readonly bool _throwKeyNotFoundExceptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="DictionaryValueRetriever{TKey, TValue}" /> class.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public DictionaryValueRetriever(IDictionary<TKey, TValue> dictionary, bool throwKeyNotFoundExceptions)
    {
      _dictionary = dictionary;
      _throwKeyNotFoundExceptions = throwKeyNotFoundExceptions;
    }

    /// <summary>
    ///   Retrieves the value at the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
    public TValue Retrieve(TKey key)
    {
			if (!_dictionary.ContainsKey(key))
			{
				if (_throwKeyNotFoundExceptions) throw new KeyNotFoundException();

      return default(TValue);
    }

			return _dictionary[key];
		}
  }
}