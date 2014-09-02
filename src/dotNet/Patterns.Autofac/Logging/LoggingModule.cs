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
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;

using Common.Logging;

using Patterns.Autofac.Configuration;
using Patterns.Autofac.Core;
using Patterns.Configuration;
using Patterns.Logging;

namespace Patterns.Autofac.Logging
{
	/// <summary>
	///    Provides packaged registration instructions for the Patterns.Logging namespace.
	/// </summary>
	public class LoggingModule : Module
	{
		private readonly Func<Type, ILog> _logFactory;

		/// <summary>
		///    The default log factory.
		/// </summary>
		public static readonly Func<Type, ILog> DefaultLogFactory = type => LogManager.GetLogger(type);

		/// <summary>
		///    Initializes a new instance of the <see cref="LoggingModule" /> class.
		/// </summary>
		public LoggingModule() : this(DefaultLogFactory) {}

		protected LoggingModule(Func<Type, ILog> logFactory)
		{
			_logFactory = logFactory;
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(context => _logFactory);
			builder.Register(context =>
			{
				try
				{
					var configSource = context.ResolveOptional<IConfigurationSource>();
					var config = configSource != null ? configSource.GetSection<LoggingConfig>(LoggingConfig.SectionName) : null;
					return config ?? new LoggingConfig();
				}
				catch (ComponentNotRegisteredException registrationError)
				{
					throw ErrorBuilder.BuildContainerException(registrationError, ConfigurationResources.MissingConfigSourceErrorHint);
				}
			}).As<ILoggingConfig>();
			builder.RegisterInstance(new JsonLogValueFormatter()).As<ILogValueFormatter>();
			builder.RegisterType<LoggingInterceptor>();
		}

		protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
		{
			registration.Preparing += (sender, args) => args.Parameters = args.Parameters.Concat(new[]
			{
				new ResolvedParameter((info, context) => info.ParameterType == typeof (ILog),
					(info, context) => _logFactory(info.Member.DeclaringType))
			});
		}
	}
}