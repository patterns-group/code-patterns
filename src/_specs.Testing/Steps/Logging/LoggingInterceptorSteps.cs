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

using System;

using Patterns.Specifications.Models;
using Patterns.Specifications.Models.Interception;
using Patterns.Specifications.Models.Logging;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Logging
{
	[Binding]
	public class LoggingInterceptorSteps
	{
		private readonly LoggingContext _logging;
		private readonly InterceptionContext _interception;
		private readonly ErrorContext _errors;

		public LoggingInterceptorSteps(LoggingContext logging, InterceptionContext interception, ErrorContext errors)
		{
			_logging = logging;
			_interception = interception;
			_errors = errors;
		}

		[When(@"I call the interceptor directly")]
		public void DirectIntercept()
		{
			try
			{
				_interception.Interceptor.Intercept(_interception.Invocation);
			}
			catch (Exception error)
			{
				_errors.LastError = error;
			}
		}

		[When(@"I call a normal void method on the logging test subject")]
		public void CallNormalVoid()
		{
			_logging.TestSubject.NormalVoidMethod();
		}

		[When(@"I call a normal method with a return value on the logging test subject")]
		public void CallNormalWithReturn()
		{
			_logging.TestSubject.NormalMethod();
		}

		[When(@"I call a method that throws an Exception on the logging test subject")]
		public void CallMethodWithError()
		{
			try
			{
				_logging.TestSubject.ExceptionalMethod();
			}
			catch (Exception error)
			{
				_errors.LastError = error;
			}
		}
	}
}