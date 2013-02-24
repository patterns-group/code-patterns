#region FreeBSD

// Copyright (c) 2013, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
// TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

using Autofac;
using Autofac.Extras.CommonServiceLocator;

using Microsoft.Practices.ServiceLocation;

using Moq;

using Patterns.Autofac;

namespace Patterns.Testing.Moq
{
	/// <summary>
	///    Provides a default implementation of the <see cref="IMoqContainer" /> interface.
	/// </summary>
	public sealed class MoqContainer : AccessibleContainer, IMoqContainer
	{
		public MoqContainer(IContainer container) : base(container)
		{
			Locator = new AutofacServiceLocator(this);
			ComponentRegistry.AddRegistrationSource(new MoqRegistrationSource());
		}

		public MoqContainer() : this(new ContainerBuilder().Build()) {}

		public IServiceLocator Locator { get; private set; }

		public Mock<TService> Mock<TService>() where TService : class
		{
			var obj = (IMocked<TService>) Create<TService>();
			return obj.Mock;
		}

		public TService Create<TService>(Func<IMoqContainer, TService> activator = null) where TService : class
		{
			Action<ContainerBuilder> defaultRegistration = builder => builder.RegisterType<TService>()
				.PropertiesAutowired(PropertyWiringOptions.PreserveSetValues);

			Action<ContainerBuilder> activatorRegistration = builder => builder.Register(c => activator(this))
				.PropertiesAutowired(PropertyWiringOptions.PreserveSetValues);

			return ResolveOrCreate<TService>(activator == null ? defaultRegistration : activatorRegistration);
		}

		public IMoqContainer Update<TService, TImplementation>() where TService : class where TImplementation : TService
		{
			Update(builder => builder.RegisterType<TImplementation>().As<TService>()
				.PropertiesAutowired(PropertyWiringOptions.PreserveSetValues));

			return this;
		}

		public IMoqContainer Update<TService>(TService instance) where TService : class
		{
			Update(builder => builder.RegisterInstance(instance).As<TService>()
				.PropertiesAutowired(PropertyWiringOptions.PreserveSetValues));

			return this;
		}

		public IMoqContainer Update<TService>(Func<IMoqContainer, TService> activator) where TService : class
		{
			Update(builder => builder.Register<TService>(c => activator(this)).As<TService>().PropertiesAutowired(PropertyWiringOptions.PreserveSetValues));

			return this;
		}

		private void Update(Action<ContainerBuilder> registration)
		{
			var builder = new ContainerBuilder();
			registration(builder);
			builder.Update(Container);
		}

		private T ResolveOrCreate<T>(Action<ContainerBuilder> registration)
		{
			if (!Container.IsRegistered<T>()) Update(registration);
			return Container.Resolve<T>();
		}
	}
}