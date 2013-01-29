#region New BSD License

// Copyright (c) 2012, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions
// and the following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions
// and the following disclaimer in the documentation and/or other materials provided with the distribution.
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

using Patterns.Runtime;

namespace Patterns.Testing.Runtime
{
	/// <summary>
	/// Provides an implementation of the <see cref="IDateTimeInfo"/> interface
	/// with customizable behavior. This type was created to aid in unit testing
	/// scenarios where time information needs to be simulated.
	/// </summary>
	public class TestDateTimeInfo : IDateTimeInfo
	{
		private DateTime? _staticTime;

		#region IDateTimeInfo Members

		/// <summary>
		/// Gets the <see cref="DateTime"/> value representing "now".
		/// </summary>
		public DateTime GetNow()
		{
			return _staticTime.HasValue ? _staticTime.Value : DateTime.Now;
		}

		#endregion

		/// <summary>
		/// Sets this instance's value to a static time.
		/// </summary>
		/// <param name="staticTime">The static time.</param>
		public void SetAlways(DateTime staticTime)
		{
			_staticTime = staticTime;
		}
	}
}