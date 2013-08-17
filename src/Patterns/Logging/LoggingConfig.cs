#region FreeBSD

// Copyright (c) 2013, John Batte
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

using System.Configuration;

namespace Patterns.Logging
{
	/// <summary>
	/// Defines configuration options for the Patterns.Logging namespace.
	/// </summary>
	public class LoggingConfig : ConfigurationSection, ILoggingConfig
	{
		/// <summary>
		/// The default section name.
		/// </summary>
		public const string SectionName = "patterns/logging";
		private const string _trapExceptionsKey = "trapExceptions";

		/// <summary>
		/// Gets or sets a value indicating whether the logging interceptor should trap exceptions
		/// (as opposed to allowing them to bubble up).
		/// </summary>
		/// <value>
		///   <c>true</c> if the logging interceptor should trap exceptions; otherwise, <c>false</c>.
		/// </value>
		[ConfigurationProperty(_trapExceptionsKey)]
		public bool TrapExceptions
		{
			get
			{
				object value = this[_trapExceptionsKey];
				return value is bool ? (bool) value : default(bool);
			}
			set { this[_trapExceptionsKey] = value; }
		}
	}
}