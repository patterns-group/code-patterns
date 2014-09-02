#region FreeBSD

// Copyright (c) 2013, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
// TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

namespace Patterns.Runtime
{
	/// <summary>
	///    Provides a disposable scope with configurable setup and tear-down actions.
	/// </summary>
	public class TemporaryScope : IDisposable
	{
	  private readonly Action _tearDown;

		/// <summary>
		/// Initializes a new instance of the <see cref="TemporaryScope" /> class.
		/// </summary>
		/// <param name="setup">The setup.</param>
		/// <param name="tearDown">The tear down.</param>
		public TemporaryScope(Action setup = null, Action tearDown = null)
		{
			_tearDown = tearDown;

			if (setup != null) setup();
		}

		/// <summary>
		///    Disposes this scope; if a tear-down method exists, it is executed.
		/// </summary>
		public void Dispose()
		{
			if(Disposed) throw new ObjectDisposedException(GetType().Name);

			if (_tearDown != null) _tearDown();

			Disposed = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="TemporaryScope"/> is disposed.
		/// </summary>
		/// <value>
		///   <c>true</c> if disposed; otherwise, <c>false</c>.
		/// </value>
		public bool Disposed { get; set; }
	}
}