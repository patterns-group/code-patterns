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
			if (ConfigurationProvider.FindTypeMapFor(typeof (TSource), typeof (TDestination)) == null)
				Configuration.CreateMap<TSource, TDestination>();

			return Engine.Map<TSource, TDestination>(source);
		}
	}
}