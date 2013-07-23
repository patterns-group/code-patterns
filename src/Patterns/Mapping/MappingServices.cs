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

using AutoMapper;

namespace Patterns.Mapping
{
	/// <summary>
	/// Provides a DI-driven implementation of <see cref="IMappingServices"/>
	/// </summary>
	public class MappingServices : IMappingServices
	{
		private readonly IConfiguration _configuration;
		private readonly IConfigurationProvider _configurationProvider;
		private readonly IMappingEngine _engine;

		/// <summary>
		///    Initializes a new instance of the <see cref="MappingServices" /> class.
		/// </summary>
		/// <param name="engine">The engine.</param>
		/// <param name="configuration">The configuration.</param>
		/// <param name="configurationProvider">The configuration provider.</param>
		public MappingServices(IMappingEngine engine, IConfiguration configuration,
			IConfigurationProvider configurationProvider)
		{
			_engine = engine;
			_configuration = configuration;
			_configurationProvider = configurationProvider;
		}

		/// <summary>
		/// Gets the engine.
		/// </summary>
		/// <value>
		/// The engine.
		/// </value>
		public IMappingEngine Engine
		{
			get { return _engine; }
		}

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <value>
		/// The configuration.
		/// </value>
		public IConfiguration Configuration
		{
			get { return _configuration; }
		}

		/// <summary>
		/// Gets the configuration provider.
		/// </summary>
		/// <value>
		/// The configuration provider.
		/// </value>
		public IConfigurationProvider ConfigurationProvider
		{
			get { return _configurationProvider; }
		}

		/// <summary>
		/// Maps the specified source to the indicated destination.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TDestination">The type of the destination.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public TDestination Map<TSource, TDestination>(TSource source)
		{
			EnsureTypeMapPresence(typeof (TSource), typeof (TDestination));

			return Engine.Map<TSource, TDestination>(source);
		}

		/// <summary>
		///    Maps the specified source to the indicated destination.
		/// </summary>
		/// <typeparam name="TDestination">The type of the destination.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		public TDestination Map<TDestination>(object source)
		{
			EnsureTypeMapPresence(source.GetType(), typeof (TDestination));

			return Engine.Map<TDestination>(source);
		}

		/// <summary>
		///    Maps the specified source to the indicated destination.
		/// </summary>
		/// <typeparam name="TDestination">The type of the destination.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="opts">The opts.</param>
		/// <returns></returns>
		public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
		{
			EnsureTypeMapPresence(source.GetType(), typeof (TDestination));

			return Engine.Map<TDestination>(source, opts);
		}

		/// <summary>
		///    Maps the specified source to the indicated destination.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TDestination">The type of the destination.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="opts">The opts.</param>
		/// <returns></returns>
		public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions> opts)
		{
			EnsureTypeMapPresence(typeof (TSource), typeof (TDestination));

			return Engine.Map<TSource, TDestination>(source, opts);
		}

		/// <summary>
		///    Maps the specified source to the specified destination.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TDestination">The type of the destination.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="destination">The destination.</param>
		/// <returns></returns>
		public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			EnsureTypeMapPresence(typeof (TSource), typeof (TDestination));

			return Engine.Map(source, destination);
		}

		/// <summary>
		///    Maps the specified source to the specified destination.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TDestination">The type of the destination.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="opts">The opts.</param>
		/// <returns></returns>
		public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions> opts)
		{
			EnsureTypeMapPresence(typeof(TSource), typeof(TDestination));

			return Engine.Map(source, destination, opts);
		}

		/// <summary>
		///    Maps the specified source to the indicated destination.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="sourceType">Type of the source.</param>
		/// <param name="destinationType">Type of the destination.</param>
		/// <returns></returns>
		public object Map(object source, Type sourceType, Type destinationType)
		{
			EnsureTypeMapPresence(sourceType, destinationType);

			return Engine.Map(source, sourceType, destinationType);
		}

		/// <summary>
		///    Maps the specified source to the indicated destination.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="sourceType">Type of the source.</param>
		/// <param name="destinationType">Type of the destination.</param>
		/// <param name="opts">The opts.</param>
		/// <returns></returns>
		public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
		{
			EnsureTypeMapPresence(sourceType, destinationType);

			return Engine.Map(source, sourceType, destinationType, opts);
		}

		/// <summary>
		///    Maps the specified source to the specified destination.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="sourceType">Type of the source.</param>
		/// <param name="destinationType">Type of the destination.</param>
		/// <returns></returns>
		public object Map(object source, object destination, Type sourceType, Type destinationType)
		{
			EnsureTypeMapPresence(sourceType, destinationType);

			return Engine.Map(source, destination, sourceType, destinationType);
		}

		/// <summary>
		///    Maps the specified source to the specified destination.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="sourceType">Type of the source.</param>
		/// <param name="destinationType">Type of the destination.</param>
		/// <param name="opts">The opts.</param>
		/// <returns></returns>
		public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
		{
			EnsureTypeMapPresence(sourceType, destinationType);

			return Engine.Map(source, destination, sourceType, destinationType, opts);
		}

		private void EnsureTypeMapPresence(Type sourceType, Type destinationType)
		{
			if (ConfigurationProvider.FindTypeMapFor(sourceType, destinationType) == null)
				Configuration.CreateMap(sourceType, destinationType);
		}
	}
}