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
using Microsoft.Practices.ServiceLocation;
using Moq;

namespace Patterns.Testing.Moq
{
	/// <summary>
	///	 Provides an IoC container designed for maximum configurability
	///	 during tests, and for tight integration with Moq.
	/// </summary>
	public interface IMoqContainer
	{
		/// <summary>
		///	 Gets the default <see cref="MockBehavior"/>.
		/// </summary>
		/// <value>
		///	 The default <see cref="MockBehavior"/>.
		/// </value>
		MockBehavior DefaultBehavior { get; }

		/// <summary>
		///	 Gets the locator.
		/// </summary>
		/// <value>
		///	 The locator.
		/// </value>
		IServiceLocator Locator { get; }

		/// <summary>
		///	 Retrieves the mock for the specified service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		Mock<TService> Mock<TService>() where TService : class;

		/// <summary>
		///	 Retrieves the mock for the specified service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <param name="mockBehavior">
		///	 The <see cref="MockBehavior" /> of mock.
		/// </param>
		Mock<TService> Mock<TService>(MockBehavior mockBehavior) where TService : class;

		/// <summary>
		///	 Creates an instance of the specified service, injecting mocked objects
		///	 for all unregistered dependencies.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		TService Create<TService>() where TService : class;

		/// <summary>
		///	 Creates an instance of the specified implementation (as the specified service),
		///	 injecting mocked objects for all unregistered dependencies.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <typeparam name="TImplementation">The type of the implementation.</typeparam>
		TService Create<TService, TImplementation>() where TService : class where TImplementation : TService;

		/// <summary>
		///	 Updates this instance by registering the implementation type as the service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <typeparam name="TImplementation">The type of the implementation.</typeparam>
		IMoqContainer Update<TService, TImplementation>() where TService : class where TImplementation : TService;

		/// <summary>
		///	 Updates this instance by registering an instance of the specified service.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <param name="instance">The instance.</param>
		IMoqContainer Update<TService>(TService instance) where TService : class;

		/// <summary>
		///	 Updates this instance by registering the specified activator as the service type.
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <param name="activator">The activator.</param>
		IMoqContainer Update<TService>(Func<IMoqContainer, TService> activator) where TService : class;
	}
}