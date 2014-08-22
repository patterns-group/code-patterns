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
using Patterns.Collections.Properties;

namespace Patterns.Collections
{
  /// <summary>
  ///   Provides an exception type for <see cref="KeyNotFoundException" /> scenarios
  ///   that produces a key-specific error message.
  /// </summary>
  public class SpecificKeyNotFoundException<TKey> : KeyNotFoundException
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="SpecificKeyNotFoundException{TKey}" /> class.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="converter">The converter.</param>
    /// <remarks>
    ///   If the converter is specified, it will be used to convert the key value to its
    ///   string representation. If not, <see cref="object.ToString" /> will be used.
    /// </remarks>
    public SpecificKeyNotFoundException(TKey key, Func<TKey, string> converter = null)
      : base(BuildMessage(key, converter))
    {
    }

    private static string BuildMessage(TKey key, Func<TKey, string> converter)
    {
      try
      {
        converter = converter ?? (value => value.ToString());
        return string.Format(Resources.SpecificKeyNotFoundException_MessageFormat, converter(key));
      }
      catch
      {
        return Resources.SpecificKeyNotFoundException_DefaultMessage;
      }
    }
  }
}