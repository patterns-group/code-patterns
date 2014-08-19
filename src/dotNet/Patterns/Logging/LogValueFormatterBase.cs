#region FreeBSD

// Copyright (c) 2013, The Tribe
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
using System.Linq;

using Patterns.Collections.Strategies;

namespace Patterns.Logging
{
	/// <summary>
	///    Provides a base class for log value formatters.
	/// </summary>
	public abstract class LogValueFormatterBase : ILogValueFormatter
	{
		/// <summary>
		///    The special value format.
		/// </summary>
		protected const string SpecialValueFormat = "[{0}]";

		/// <summary>
		///    The argument list format.
		/// </summary>
		protected const string ArgumentListFormat = "({0})";

		/// <summary>
		///    The argument list separator.
		/// </summary>
		protected const string ArgumentListSeparator = ",";

		/// <summary>
		///    The string display format.
		/// </summary>
		protected const string StringDisplayFormat = @"""{0}""";

		private static readonly FuncStrategies<Type, object, object> _displayStrategies
			= new FuncStrategies<Type, object, object>
			{
				{typeof (string), value => string.Format(StringDisplayFormat, value)}
			};

		/// <summary>
		/// Formats the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		public virtual string Format(object value)
		{
			object valueForDisplay = ConvertValueForDisplay(value);
			return valueForDisplay != null ? valueForDisplay.ToString() : null;
		}

		/// <summary>
		/// Formats the specified values.
		/// </summary>
		/// <param name="values">The values.</param>
		public virtual string Format(object[] values)
		{
			string[] convertedValues = values.Select(Format).ToArray();
			return string.Format(ArgumentListFormat, string.Join(ArgumentListSeparator, convertedValues));
		}

		/// <summary>
		///    Converts the value for display.
		/// </summary>
		/// <param name="value">The value.</param>
		protected virtual object ConvertValueForDisplay(object value)
		{
			if (value == null) return string.Format(SpecialValueFormat, LoggingResources.ILogValueFormatter_NullValue);

			Type valueType = value.GetType();

			return _displayStrategies.Execute(valueType, value);
		}
	}
}