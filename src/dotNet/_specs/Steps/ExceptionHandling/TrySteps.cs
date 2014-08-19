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

using FluentAssertions;

using Patterns.ExceptionHandling;
using Patterns.Specifications.Models;
using Patterns.Specifications.Models.ExceptionHandling;
using Patterns.Testing.Values;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.ExceptionHandling
{
	[Binding]
	public class TrySteps
	{
		private readonly ExceptionHandlingContext _context;
		private readonly ErrorContext _errorContext;

		public TrySteps(ExceptionHandlingContext context, ErrorContext errorContext)
		{
			_context = context;
			_errorContext = errorContext;
		}

		[Given(@"I have mapped the default error strategy to store exceptions")]
		public void DefaultStrategyStoreExceptions()
		{
			Try.HandleErrors.DefaultStrategy = exception =>
			{
				_errorContext.LastError = exception;
				return new ExceptionState(exception, true);
			};
		}

		[Given(@"I have mapped the custom error strategy to store exceptions")]
		public void CustomStrategyStoreExceptions()
		{
			_context.CustomErrorHandler = exception =>
			{
				_errorContext.LastError = exception;
				return new ExceptionState(exception, true);
			};
		}

		[When(@"I try to run an action that throws an exception(, providing the custom strategy)?")]
		public void RunExceptionalAction(string useCustom)
		{
			bool custom = !string.IsNullOrEmpty(useCustom);
			Try.Do(_context.TestSubject.ActionWithException, custom ? _context.CustomErrorHandler : null);
		}

		[When(@"I try to run a normal action")]
		public void RunNormalAction()
		{
			Try.Do(_context.TestSubject.NormalAction);
		}

		[When(@"I try to get the return value of a function that throws an exception(, providing the custom strategy)?")]
		public void RunExceptionalFunction(string useCustom)
		{
			bool custom = !string.IsNullOrEmpty(useCustom);
			_context.ReturnValue = Try.Get(_context.TestSubject.FuncWithException, custom ? _context.CustomErrorHandler : null);
		}

		[When(@"I try to get the return value of a normal function")]
		public void RunNormalFunction()
		{
			_context.ReturnValue = Try.Get(_context.TestSubject.NormalFunc);
		}

		[Then(@"the return value should be the default value for that type")]
		public void AssertDefaultReturnValue()
		{
			_context.ReturnValue.Should().Be(ExceptionTestSubject.ReturnType.GetDefault());
		}

		[Then(@"the return value should be the expected return value")]
		public void AssertReturnValue()
		{
			_context.ReturnValue.Should().Be(ExceptionTestSubject.NormalReturnValue);
		}
	}
}