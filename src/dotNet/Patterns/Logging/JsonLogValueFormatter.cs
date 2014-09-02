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
using System.Web.Script.Serialization;

namespace Patterns.Logging
{
  /// <summary>
  ///   Provides a JSON formatter for log values.
  /// </summary>
  public class JsonLogValueFormatter : LogValueFormatterBase
  {
    /// <summary>
    ///   The default recursion limit.
    /// </summary>
    public const int DefaultRecursionLimit = 50;

    private readonly JavaScriptSerializer _jsonSerializer;

    /// <summary>
    ///   Initializes a new instance of the <see cref="JsonLogValueFormatter" /> class.
    /// </summary>
    /// <param name="maxLength">The maximum length.</param>
    /// <param name="recursionLimit">The recursion limit.</param>
    public JsonLogValueFormatter(int maxLength = int.MaxValue, int recursionLimit = DefaultRecursionLimit)
    {
      _jsonSerializer = new JavaScriptSerializer
      {
        MaxJsonLength = maxLength,
        RecursionLimit = recursionLimit
      };
    }

    /// <summary>
    ///   Formats the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    public override string Format(object value)
    {
      return base.Format(value) ?? SerializeValue(value);
    }

    private string SerializeValue(object value)
    {
      try
      {
        return _jsonSerializer.Serialize(value);
      }
      catch (InvalidOperationException)
      {
        return string.Format(SpecialValueFormat, LoggingResources.ILogValueFormatter_ValueTooLarge);
      }
    }
  }
}