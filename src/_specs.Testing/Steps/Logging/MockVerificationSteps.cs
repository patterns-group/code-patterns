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

using Common.Logging;

using Moq;

using Patterns.Specifications.Models.Mocking;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Logging
{
	[Binding]
	public class MockVerificationSteps
	{
		private readonly MoqContext _moq;

		public MockVerificationSteps(MoqContext moq)
		{
			_moq = moq;
		}

		[Then(@"the mocked ILog should have been called using the normal no-return execution path")]
		public void VerifyLogNormalExecutionNoReturn()
		{
			Mock<ILog> mockLog = _moq.Container.Mock<ILog>();
			mockLog.Verify(log => log.Trace(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(2));
			mockLog.Verify(log => log.Debug(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
			mockLog.Verify(log => log.Info(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
		}

		[Then(@"the mocked ILog should have been called using the normal execution path")]
		public void VerifyLogNormalExecution()
		{
			Mock<ILog> mockLog = _moq.Container.Mock<ILog>();
			mockLog.Verify(log => log.Trace(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(2));
			mockLog.Verify(log => log.Debug(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(2));
			mockLog.Verify(log => log.Info(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
		}

		[Then(@"the mocked ILog should have been called using the broken execution path")]
		public void VerifyLogBrokenExecution()
		{
			Mock<ILog> mockLog = _moq.Container.Mock<ILog>();
			mockLog.Verify(log => log.Trace(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
			mockLog.Verify(log => log.Debug(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
			mockLog.Verify(log => log.Info(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
			mockLog.Verify(log => log.Error(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
		}

		[Then(@"the mocked ILog should have been called using the trapped-error execution path")]
		public void VerifyLogTrappedErrorExecution()
		{
			Mock<ILog> mockLog = _moq.Container.Mock<ILog>();
			mockLog.Verify(log => log.Trace(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(2));
			mockLog.Verify(log => log.Debug(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
			mockLog.Verify(log => log.Info(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
			mockLog.Verify(log => log.Error(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
		}
	}
}