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

using Castle.DynamicProxy;

using Patterns.ExceptionHandling;

namespace Patterns.Interception
{
	/// <summary>
	///    Provides an interceptor that allows its interception logic to be
	///    injected; no-op fall-backs are used when no logic has been specified
	///    for an interception step.
	/// </summary>
	public class DelegateInterceptor : IInterceptor
	{
		/// <summary>
		///    Initializes a new instance of the <see cref="DelegateInterceptor" /> class.
		/// </summary>
		/// <param name="after">
		///    The action to execute after proceeding. This action will not run
		///    if the invocation throws an exception.
		/// </param>
		/// <param name="before">The action to execute before proceeding.</param>
		/// <param name="condition">
		///    The interception condition. If this condition returns <c>false</c>,
		///    the invocation proceeds with no further interception.
		/// </param>
		/// <param name="finally">
		///    The action to execute at the end of the interception, regardless of
		///    whether or not an exception was thrown.
		/// </param>
		/// <param name="onError">The function to execute when an error occurs.</param>
		public DelegateInterceptor(Action<IInvocation> after = null, Action<IInvocation> before = null,
			Func<IInvocation, bool> condition = null, Action<IInvocation> @finally = null,
			Func<IInvocation, Exception, ExceptionState> onError = null)
		{
			Initialize(after, before, condition, @finally, onError);
		}

		protected virtual Action<IInvocation> After { get; set; }

		protected virtual Action<IInvocation> Before { get; set; }

		protected virtual Func<IInvocation, bool> Condition { get; set; }

		protected virtual Action<IInvocation> Finally { get; set; }

		protected virtual Func<IInvocation, Exception, ExceptionState> OnError { get; set; }

		/// <summary>
		///    Intercepts the specified invocation.
		/// </summary>
		/// <param name="invocation">The invocation.</param>
		public virtual void Intercept(IInvocation invocation)
		{
			if (Condition != null && !Condition(invocation))
			{
				invocation.Proceed();
				return;
			}

			try
			{
				if (Before != null) Before(invocation);

				invocation.Proceed();

				if (After != null) After(invocation);
			}
			catch (Exception error)
			{
				Func<IInvocation, Exception, ExceptionState> errorHandler = OnError
					?? ((thisCall, thisBug) => new ExceptionState(thisBug, false));
				ExceptionState state = errorHandler(invocation, error);

				if (state.IsHandled) return;

				if (!ReferenceEquals(error, state.Exception) && state.Exception != null) throw state.Exception;

				throw;
			}
			finally
			{
				if (Finally != null) Finally(invocation);
			}
		}

		private void Initialize(Action<IInvocation> after, Action<IInvocation> before, Func<IInvocation, bool> condition,
			Action<IInvocation> @finally, Func<IInvocation, Exception, ExceptionState> onError)
		{
			Condition = condition;
			Before = before;
			After = after;
			Finally = @finally;
			OnError = onError;
		}
	}
}