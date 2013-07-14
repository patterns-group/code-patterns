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
using System.Collections.Generic;

using Autofac.Builder;
using Autofac.Core;

namespace Patterns.Autofac.Sources
{
	/// <summary>
	///    Provides an <see cref="IRegistrationSource" /> implementation that always
	///    builds new registrations for creatable types, negating the need to pre-register
	///    them. Interfaces and abstract classes will still need to be registered in
	///    the normal way.
	/// </summary>
	/// <remarks>
	///    Using this class can have unwanted side effects and is intended for fringe scenarios; use with caution.
	/// </remarks>
	public class ResolveCreatableSource : IRegistrationSource
	{
		#region Implementation of IRegistrationSource

		/// <summary>
		///    Retrieves registrations for an unregistered service, to be used
		///    by the container. If <paramref name="service" /> is a creatable type, a new registration
		///    will be created; otherwise, an empty enumerable is returned.
		/// </summary>
		/// <param name="service">The service that was requested.</param>
		/// <param name="registrationAccessor">A function that will return existing registrations for a service.</param>
		/// <returns>
		///    Registrations providing the service.
		/// </returns>
		public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
		{
			var ts = service as TypedService;
			if (ts == null || ts.ServiceType.IsAbstract || !ts.ServiceType.IsClass) yield break;
			yield return RegistrationBuilder.ForType(ts.ServiceType).CreateRegistration();
		}

		/// <summary>
		///    Gets whether the registrations provided by this source are 1:1 adapters on top of
		///    other components (e.g. Meta, Func, Owned).
		/// </summary>
		/// <remarks>
		///    This implementation always returns true.
		/// </remarks>
		public bool IsAdapterForIndividualComponents
		{
			get { return true; }
		}

		#endregion
	}
}