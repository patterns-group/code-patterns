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
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using Moq;
using Patterns.Autofac;
using Patterns.Autofac.Core;
using Patterns.ExceptionHandling;
using Patterns.Testing.Moq;

namespace Patterns.Testing.Autofac.Moq
{
	/// <summary>
	///	 Provides a default implementation of the <see cref="IAutofacMoqContainer" /> interface.
	/// </summary>
	public sealed class AutofacMoqContainer : AccessibleContainer, IAutofacMoqContainer
	{
		private readonly MockBehavior _defaultBehavior;
		private readonly MoqRegistrationSource _registrationSource;

		/// <summary>
		///	 Initializes a new instance of the <see cref="AutofacMoqContainer" /> class with 
		/// </summary>
		/// <param name="defaultBehavior">The default <see cref="MockBehavior"/>.</param>
		public AutofacMoqContainer(IContainer container, MockBehavior behavior) : base(container)
		{
			_defaultBehavior = behavior;
			Locator = new AutofacServiceLocator(this);
			ComponentRegistry.AddRegistrationSource(_registrationSource = new MoqRegistrationSource(_defaultBehavior));
		}

		/// <summary>
		///	 Initializes a new instance of the <see cref="AutofacMoqContainer" /> class.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="defaultBehavior">The default <see cref="MockBehavior"/>.</param>
		public AutofacMoqContainer(IContainer container) : this(container, MockBehavior.Default)
		{
		}

		/// <summary>
		///	 Initializes a new instance of the <see cref="AutofacMoqContainer" /> class.
		/// </summary>
		public AutofacMoqContainer() : this(new ContainerBuilder().Build())
		{
		}

		/// <summary>
		///	 Gets the default <see cref="MockBehavior"/>.
		/// </summary>
		/// <value>
		///	 The default <see cref="MockBehavior"/>.
		/// </value>
		public MockBehavior DefaultBehavior { get { return _defaultBehavior; } }

		/// <summary>
		///	 Gets the locator.
		/// </summary>
		/// <value>
		///	 The locator.
		/// </value>
		public IServiceLocator Locator { get; private set; }

		/// <summary>
		///	 Retrieves the mock for the specified service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <returns>
		///	 The service mock.
		/// </returns>
		public Mock<TService> Mock<TService>() where TService : class
		{
		    return Mock<TService>(_defaultBehavior);
		}

		/// <summary>
		///	 Retrieves the mock for the specified service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <param name="mockBehavior">
		///	 The <see cref="MockBehavior" /> of the mock.
		/// </param>
		/// <returns>
		///	 The service mock.
		/// </returns>
		public Mock<TService> Mock<TService>(MockBehavior mockBehavior) where TService : class
		{
			TService service = Try.Get(Create<TService>);
			var existingMock = service as IMocked<TService>;
			if (existingMock != null) return existingMock.Mock;

			Mock<TService> mock = _registrationSource.Repository.Create<TService>(mockBehavior);
			Update(mock.Object);
			return mock;
		}

		/// <summary>
		///	 Creates an instance of the specified service, injecting mocked objects
		///	 for all unregistered dependencies.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <returns>
		///	 The service instance.
		/// </returns>
		public TService Create<TService>() where TService : class
		{
			return Container.Resolve<TService>();
		}

		/// <summary>
		///	 Creates an instance of the specified implementation (as the specified service),
		///	 injecting mocked objects for all unregistered dependencies.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <typeparam name="TImplementation">The type of the implementation.</typeparam>
		/// <returns></returns>
		public TService Create<TService, TImplementation>() where TService : class where TImplementation : TService
		{
			Update<TService, TImplementation>();
			return Create<TService>();
		}

		/// <summary>
		///	 Updates this instance by registering the implementation type as the service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <typeparam name="TImplementation">The type of the implementation.</typeparam>
		/// <returns>
		///	 The container.
		/// </returns>
		public IMoqContainer Update<TService, TImplementation>() where TService : class where TImplementation : TService
		{
			UpdateWithBuilder(builder => builder.RegisterType<TImplementation>().As<TService>()
												.PropertiesAutowired(PropertyWiringOptions.PreserveSetValues));

			return this;
		}

		/// <summary>
		///	 Updates this instance by registering an instance of the specified service.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <param name="instance">The instance.</param>
		/// <returns>
		///	 The container.
		/// </returns>
		public IMoqContainer Update<TService>(TService instance) where TService : class
		{
			UpdateWithBuilder(builder => builder.RegisterInstance(instance).As<TService>()
												.PropertiesAutowired(PropertyWiringOptions.PreserveSetValues));

			return this;
		}

		/// <summary>
		///	 Updates this instance by registering the specified activator as the service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <param name="activator">The activator.</param>
		/// <returns>
		///	 The container
		/// </returns>
		public IMoqContainer Update<TService>(Func<IMoqContainer, TService> activator) where TService : class
		{
			UpdateWithBuilder(builder => builder.Register(c => activator(this)).As<TService>()
												.PropertiesAutowired(PropertyWiringOptions.PreserveSetValues));

			return this;
		}

		/// <summary>
		///	 Updates the container using the specified module.
		/// </summary>
		/// <param name="module">The module.</param>
		/// <returns>
		///	 The container.
		/// </returns>
		public IAutofacMoqContainer Update(Module module)
		{
			UpdateWithBuilder(builder => builder.RegisterModule(module));
			return this;
		}

		/// <summary>
		///	 Updates the container using the specified registration.
		/// </summary>
		/// <param name="registration">The registration.</param>
		/// <returns>
		///	 The container.
		/// </returns>
		public IAutofacMoqContainer Update(Action<ContainerBuilder> registration)
		{
			UpdateWithBuilder(registration);
			return this;
		}

		private void UpdateWithBuilder(Action<ContainerBuilder> registration)
		{
			var builder = new ContainerBuilder();
			registration(builder);
			builder.Update(Container);
		}
	}
}