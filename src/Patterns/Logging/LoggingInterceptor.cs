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
using System.Linq;

using Castle.DynamicProxy;

using Common.Logging;

namespace Patterns.Logging
{
	public class LoggingInterceptor : IInterceptor
	{
		private const string _nullArgument = "[NULL]";
		private const string _argumentListFormat = "({0})";
		private const string _argumentListSeparator = ",";
		private readonly bool _trapInterceptedExceptions;

		public LoggingInterceptor(bool trapInterceptedExceptions)
		{
			_trapInterceptedExceptions = trapInterceptedExceptions;
		}

		public void Intercept(IInvocation invocation)
		{
			ILog log = LogManager.GetLogger(invocation.TargetType);
			log.Trace(handler => handler(LoggingResources.MethodStartTraceFormat, invocation.TargetType, invocation.Method.Name));
			log.Debug(handler => handler(LoggingResources.MethodArgsDebugFormat, invocation.Method.Name, GetMethodArguments(invocation)));

			try
			{
				invocation.Proceed();
				log.Info(handler => handler(LoggingResources.MethodInfoFormat, LoggingResources.MethodInfoPass));
			}
			catch (Exception error)
			{
				log.Info(handler => handler(LoggingResources.MethodInfoFormat, LoggingResources.MethodInfoFail));
				log.Error(handler => handler(LoggingResources.ExceptionErrorFormat, invocation.Method.Name, error.ToFullString()));
				if (!_trapInterceptedExceptions) throw;
			}

			log.Trace(handler => handler(LoggingResources.MethodStopTraceFormat, invocation.TargetType.Name, invocation.Method.Name));

			if (invocation.ReturnValue != null) log.Debug(handler => handler(LoggingResources.MethodReturnDebugFormat, invocation.Method.Name, invocation.ReturnValue));
		}

		private static string GetMethodArguments(IInvocation invocation)
		{
			object[] arguments = invocation.Arguments.Select(a => a ?? _nullArgument).ToArray();
			return string.Format(_argumentListFormat, string.Join(_argumentListSeparator, arguments));
		}
	}
}