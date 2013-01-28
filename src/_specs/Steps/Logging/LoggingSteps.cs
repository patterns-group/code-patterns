#region New BSD License

// // Copyright (c) 2013, John Batte
// // All rights reserved.
// // 
// // Redistribution and use in source and binary forms, with or without modification, are permitted
// // provided that the following conditions are met:
// // 
// // Redistributions of source code must retain the above copyright notice, this list of conditions
// // and the following disclaimer.
// // 
// // Redistributions in binary form must reproduce the above copyright notice, this list of conditions
// // and the following disclaimer in the documentation and/or other materials provided with the distribution.
// // 
// // THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// // WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// // PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// // ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// // TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// // HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// // NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// // POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Diagnostics;
using System.Reflection;

using Castle.DynamicProxy;

using Common.Logging;

using Moq;

using Patterns.Logging;
using Patterns.Specifications.Framework;

using TechTalk.SpecFlow;

using MockFactory = Patterns.Specifications.Steps.Factories.MockFactory;

namespace Patterns.Specifications.Steps.Logging
{
	[Binding]
	[Scope(Feature = "Logging")]
	public class LoggingSteps
	{
		private static readonly string _loggingInterceptorKey = ScenarioContext.Current.NewKey();

		#region Given
		[Given(@"I have created a new container builder")]
		public void ConfigureContainer()
		{
			ScenarioContext.Current.Pending();
		}

		[Given(@"I have registered the LoggingModule")]
		public void RegisterLoggingModule()
		{
			ScenarioContext.Current.Pending();
		}

		[Given(@"I have registered a test type with a dependency on ILog")]
		public void RegisterILogDependantTestType()
		{
			ScenarioContext.Current.Pending();
		}

		[Given(@"I have resolved an instance of the test type")]
		public void ResolveTestType()
		{
			ScenarioContext.Current.Pending();
		}

		[Given(@"I have registered an intercepted test type")]
		public void RegisterInterceptedTestType()
		{
			ScenarioContext.Current.Pending();
		}

		[Given(@"I have created a LoggingInterceptor instance")]
		public void CreateLoggingInterceptor()
		{
			Mock<ILog> mockLog = MockFactory.Mocks.GetMock<ILog>();
			mockLog.Setup(log => log.Trace(It.IsAny<Action<FormatMessageHandler>>())).Callback(GetLoggingHandlerAction());
			mockLog.Setup(log => log.Debug(It.IsAny<Action<FormatMessageHandler>>())).Callback(GetLoggingHandlerAction());
			mockLog.Setup(log => log.Info(It.IsAny<Action<FormatMessageHandler>>())).Callback(GetLoggingHandlerAction());
			mockLog.Setup(log => log.Error(It.IsAny<Action<FormatMessageHandler>>())).Callback(GetLoggingHandlerAction());
			ScenarioContext.Current[_loggingInterceptorKey] = new LoggingInterceptor(true, type => mockLog.Object);
		}

		[Given(@"I have configured my mock IInvocation instance to throw an error when proceeding")]
		public void ConfigureIInvocationThrowException()
		{
			ScenarioContext.Current.Pending();
		}

		[Given(@"I have created a manual interceptor proxy to a test type, using the LoggingInterceptor")]
		public void CreateManualLoggingInterceptorProxy()
		{
			ScenarioContext.Current.Pending();
		}
		#endregion

		#region When
		[When(@"I inspect the ILog instance the test type is using")]
		public void GetILogImplementation()
		{
			ScenarioContext.Current.Pending();
		}

		[When(@"I call a method on the test type")]
		public void CallTestTypeMethod()
		{
			ScenarioContext.Current.Pending();
		}

		[When(@"I tell the interceptor to intercept an invocation")]
		public void InterceptInvocation()
		{
			Mock<IInvocation> mockInvocation = MockFactory.Mocks.GetMock<IInvocation>();
			mockInvocation.SetupGet(call => call.TargetType).Returns(typeof (object));
			MethodInfo toStringInfo = typeof (object).GetMethod("ToString");
			Debug.Assert(toStringInfo != null);
			mockInvocation.SetupGet(call => call.Method).Returns(toStringInfo);
			mockInvocation.SetupGet(call => call.Arguments).Returns(new object[] {});
			mockInvocation.SetupGet(call => call.ReturnValue).Returns("THIS IS A TEST");

			var interceptor = ScenarioContext.Current.Pull<IInterceptor>(_loggingInterceptorKey);
			interceptor.Intercept(mockInvocation.Object);
		}

		[When(@"I call a volatile method on the test type")]
		public void CallVolatileTestTypeMethod()
		{
			ScenarioContext.Current.Pending();
		}
		#endregion

		#region Then
		[Then(@"the ILog instance should be configured correctly for the test type")]
		public void AssertILogInstanceConfiguration()
		{
			ScenarioContext.Current.Pending();
		}

		[Then(@"the ILog instance should be called as expected using the happy path")]
		public void AssertILogHappyPathCallPattern()
		{
			Mock<ILog> mockLog = MockFactory.Mocks.GetMock<ILog>();
			mockLog.Verify(log => log.Trace(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(2));
			mockLog.Verify(log => log.Debug(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(2));
			mockLog.Verify(log => log.Info(It.IsAny<Action<FormatMessageHandler>>()), Times.Exactly(1));
		}

		[Then(@"the ILog instance should be called as expected using the error path")]
		public void AssertILogErrorPathCallPattern()
		{
			ScenarioContext.Current.Pending();
		}

		[Then(@"the IInvocation instance should be called as expected")]
		public void AssertIInvocationCallPattern()
		{
			Mock<IInvocation> mockInvocation = MockFactory.Mocks.GetMock<IInvocation>();

			mockInvocation.VerifyGet(call => call.TargetType, Times.Exactly(3));
			mockInvocation.VerifyGet(call => call.Method, Times.Exactly(5));
			mockInvocation.VerifyGet(call => call.Arguments, Times.Exactly(1));
			mockInvocation.VerifyGet(call => call.ReturnValue, Times.Exactly(2));
		}
		#endregion

		private static Action<Action<FormatMessageHandler>> GetLoggingHandlerAction()
		{
			return action => action((format, args) =>
			{
				string message = string.Format(format, args);
				Debug.WriteLine(message);
				return message;
			});
		}
	}
}