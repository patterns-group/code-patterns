#region FreeBSD

// Copyright (c) 2014, John Batte
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

using Common.Logging;

using Patterns.ExceptionHandling;
using Patterns.Interception;

namespace Patterns.Logging
{
  /// <summary>
  ///   Provides an <see cref="IInterceptor" /> implementation that
  ///   uses <see cref="ILog" /> to log Trace, Debug, Info, and Error
  ///   events throughout the execution of intercepted invocations.
  /// </summary>
  public class LoggingInterceptor : DelegateInterceptor
  {
    private readonly ILoggingConfig _config;
    private readonly ILogValueFormatter _formatter;
    private readonly Func<Type, ILog> _logFactory;

    /// <summary>
    ///   Initializes a new instance of the <see cref="LoggingInterceptor" /> class.
    /// </summary>
    /// <param name="config">The config.</param>
    /// <param name="logFactory">The log factory.</param>
    /// <param name="formatter">The formatter.</param>
    public LoggingInterceptor(ILoggingConfig config, Func<Type, ILog> logFactory, ILogValueFormatter formatter)
      : this(config, logFactory, formatter, null)
    {
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="LoggingInterceptor" /> class.
    /// </summary>
    /// <param name="config">The config.</param>
    /// <param name="logFactory">The log factory.</param>
    /// <param name="formatter">The formatter.</param>
    /// <param name="condition">The intercept condition.</param>
    public LoggingInterceptor(ILoggingConfig config, Func<Type, ILog> logFactory, ILogValueFormatter formatter,
      Func<IInvocation, bool> condition)
    {
      _logFactory = logFactory;
      _formatter = formatter;
      _config = config;
      Initialize(condition);
    }

    private void Initialize(Func<IInvocation, bool> condition)
    {
      Condition = condition;
      Before = LogBefore;
      After = LogAfter;
      OnError = LogError;
      Finally = LogFinally;
    }

    protected virtual void LogBefore(IInvocation invocation)
    {
      ILog log = _logFactory(invocation.TargetType);
      log.Trace(
        handler => handler(LoggingResources.MethodStartTraceFormat, invocation.TargetType, invocation.Method.Name));
      log.Debug(
        handler =>
          handler(LoggingResources.MethodArgsDebugFormat, invocation.Method.Name,
            _formatter.Format(invocation.Arguments)));
    }

    protected virtual void LogAfter(IInvocation invocation)
    {
      ILog log = _logFactory(invocation.TargetType);
      log.Info(
        handler => handler(LoggingResources.MethodInfoFormat, invocation.Method.Name, LoggingResources.MethodInfoPass));
      log.Trace(
        handler => handler(LoggingResources.MethodStopTraceFormat, invocation.TargetType, invocation.Method.Name));
    }

    protected virtual ExceptionState LogError(IInvocation invocation, Exception error)
    {
      ILog log = _logFactory(invocation.TargetType);
      log.Info(
        handler => handler(LoggingResources.MethodInfoFormat, invocation.Method.Name, LoggingResources.MethodInfoFail));
      log.Error(handler => handler(LoggingResources.ExceptionErrorFormat, invocation.Method.Name, error.ToFullString()));
      return new ExceptionState(error, _config.TrapExceptions);
    }

    protected virtual void LogFinally(IInvocation invocation)
    {
      if (invocation.ReturnValue == null) return;

      ILog log = _logFactory(invocation.TargetType);

      log.Debug(handler => handler(LoggingResources.MethodReturnDebugFormat,
        invocation.Method.Name, _formatter.Format(invocation.ReturnValue)));
    }
  }
}