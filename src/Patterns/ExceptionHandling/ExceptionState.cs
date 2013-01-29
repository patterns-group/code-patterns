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

namespace Patterns.ExceptionHandling
{
	/// <summary>
	/// 	Encapsulates the state of an exception being handled by the <see cref="Try" /> class.
	/// </summary>
	public class ExceptionState
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref="ExceptionState" /> class.
		/// </summary>
		/// <param name="exception"> The exception. </param>
		/// <param name="isHandled"> if set to <c>true</c> , the exception is handled. </param>
		public ExceptionState(Exception exception, bool isHandled)
		{
			Exception = exception;
			IsHandled = isHandled;
		}

		/// <summary>
		/// 	Gets or sets the exception.
		/// </summary>
		/// <value> The exception. </value>
		public Exception Exception{ get; set; }

		/// <summary>
		/// 	Gets or sets a value indicating whether the exception is handled.
		/// </summary>
		/// <value> <c>true</c> if the exception is handled; otherwise, <c>false</c> . </value>
		public bool IsHandled{ get; set; }
	}
}