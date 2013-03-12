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

using Castle.DynamicProxy;

using Moq;

using Patterns.Specifications.Models.Interception;
using Patterns.Specifications.Models.Mocking;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Interception
{
	[Binding]
	public class InvocationSteps
	{
		private readonly InterceptionContext _context;
		private readonly MoqContext _moq;

		public InvocationSteps(InterceptionContext context, MoqContext moq)
		{
			_context = context;
			_moq = moq;
		}

		[Given(@"I have a mocked invocation")]
		public void CreateMockedInvocation()
		{
			Mock<IInvocation> mockCall = _moq.Container.Mock<IInvocation>();
			SetInvocationToObjectToString(mockCall);
			_context.Invocation = mockCall.Object;
		}

		[Given(@"I have a mocked invocation that returns a value")]
		public void CreateMockedInvocationWithReturn()
		{
			Mock<IInvocation> mockCall = _moq.Container.Mock<IInvocation>();
			SetInvocationToObjectToString(mockCall);
			mockCall.SetupGet(call => call.ReturnValue).Returns("hello world");
			_context.Invocation = mockCall.Object;
		}

		[Given(@"I have a mocked invocation that throws an Exception")]
		public void CreateMockedInvocationWithException()
		{
			Mock<IInvocation> mockCall = _moq.Container.Mock<IInvocation>();
			SetInvocationToObjectToString(mockCall);
			mockCall.Setup(call => call.Proceed()).Throws(new Exception());
			_context.Invocation = mockCall.Object;
		}

		[Then(@"the mocked invocation should have been instructed to proceed")]
		public void VerifyMockInvocationProceed()
		{
			_moq.Container.Mock<IInvocation>().Verify(call => call.Proceed(), Times.Once());
		}

		private static void SetInvocationToObjectToString(Mock<IInvocation> mockCall)
		{
			mockCall.SetupGet(call => call.TargetType).Returns(typeof (object));
			mockCall.SetupGet(call => call.Method).Returns(typeof (object).GetMethod("ToString"));
		}
	}
}