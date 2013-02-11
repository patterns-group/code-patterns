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

using Common.Logging;

namespace Patterns.ExceptionHandling
{
	/// <summary>
	///    Runs delegates within try-catch blocks, thus reducing the amount of repetitive code required to handle exceptions.
	/// </summary>
	public static class Try
	{
		/// <summary>
		///    Gets the result of the specified value retriever.
		/// </summary>
		/// <typeparam name="TValue"> The type of the value. </typeparam>
		/// <param name="retriever"> The retriever. </param>
		/// <param name="errorHandler"> The error handler. </param>
		/// <returns> The result of the retriever, or the default value if an exception is thrown but handled. </returns>
		public static TValue Get<TValue>(Func<TValue> retriever, Func<Exception, ExceptionState> errorHandler = null)
		{
			try
			{
				return retriever();
			}
			catch (Exception exception)
			{
				ExceptionState state = errorHandler.Apply(exception);
				if (state.IsHandled) return default(TValue);
				if (!ReferenceEquals(exception, state.Exception) && state.Exception != null) throw state.Exception;
				throw;
			}
		}

		/// <summary>
		///    Executes the specified action.
		/// </summary>
		/// <param name="action"> The action. </param>
		/// <param name="errorHandler"> The error handler. </param>
		public static void Do(Action action, Func<Exception, ExceptionState> errorHandler = null)
		{
			try
			{
				action();
			}
			catch (Exception exception)
			{
				ExceptionState state = errorHandler.Apply(exception);
				if (state.IsHandled) return;
				if (!ReferenceEquals(exception, state.Exception) && state.Exception != null) throw state.Exception;
				throw;
			}
		}

		private static ExceptionState Apply(this Func<Exception, ExceptionState> errorHandler, Exception exception)
		{
			Func<Exception, ExceptionState> handler = errorHandler ?? HandleErrors.DefaultStrategy;
			return handler(exception);
		}

		#region Nested type: HandleErrors

		/// <summary>
		///    Encapsulates the <see cref="Try" /> class's error-handling strategy.
		/// </summary>
		public static class HandleErrors
		{
			private static readonly ILog _log = LogManager.GetLogger(typeof (Try));

			static HandleErrors()
			{
				DefaultStrategy = exception =>
				{
					_log.Error(exception.Message, exception);
					return new ExceptionState(exception, true);
				};
			}

			/// <summary>
			///    Gets or sets the default strategy.
			/// </summary>
			/// <value> The default strategy. </value>
			public static Func<Exception, ExceptionState> DefaultStrategy { get; set; }
		}

		#endregion
	}
}