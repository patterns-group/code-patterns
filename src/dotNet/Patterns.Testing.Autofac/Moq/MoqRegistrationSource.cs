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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Autofac.Builder;
using Autofac.Core;

using Common.Logging;

using Moq;

using Patterns.Testing.Autofac.Moq.Properties;

namespace Patterns.Testing.Autofac.Moq
{
  /// <summary>
  ///   Provides a registration source for Autofac using Moq's MockRepository as a service factory.
  /// </summary>
  public class MoqRegistrationSource : IRegistrationSource
  {
    private static readonly ILog _log = LogManager.GetLogger(typeof (MoqRegistrationSource));

    private static readonly MethodInfo _createMethod = typeof (MoqRegistrationSource)
      .GetMethod("CreateUsingRepository", BindingFlags.NonPublic | BindingFlags.Instance)
      .GetGenericMethodDefinition();

    private readonly MockRepository _repository;

    /// <summary>
    ///   Initializes an instance of <see cref="MoqRegistrationSource" /> with the specified <see cref="MockBehavior" />
    ///   behavior.
    /// </summary>
    /// <param name="defaultBehavior">The default <see cref="MockBehavior" />.</param>
    public MoqRegistrationSource(MockBehavior defaultBehavior)
    {
      _repository = new MockRepository(defaultBehavior);
    }

    /// <summary>
    ///   Initializes an instance of <see cref="MoqRegistrationSource" /> with the <see cref="MockBehavior.Default" />
    ///   behavior.
    /// </summary>
    public MoqRegistrationSource() : this(MockBehavior.Default)
    {
    }

    /// <summary>
    ///   Gets the repository.
    /// </summary>
    /// <value>
    ///   The repository.
    /// </value>
    public MockRepository Repository
    {
      get { return _repository; }
    }

    /// <summary>
    ///   Retrieve registrations for an unregistered service, to be used
    ///   by the container.
    /// </summary>
    /// <param name="service">The service that was requested.</param>
    /// <param name="registrationAccessor">A function that will return existing registrations for a service.</param>
    /// <returns>
    ///   Registrations providing the service.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">service</exception>
    /// <remarks>
    ///   If the source is queried for service s, and it returns a component that implements both s and s', then it
    ///   will not be queried again for either s or s'. This means that if the source can return other implementations
    ///   of s', it should return these, plus the transitive closure of other components implementing their
    ///   additional services, along with the implementation of s. It is not an error to return components
    ///   that do not implement <paramref name="service" />.
    /// </remarks>
    public IEnumerable<IComponentRegistration> RegistrationsFor(Service service,
      Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
    {
      if (service == null) throw new ArgumentNullException("service");

      _log.Info(format => format(Resources.MoqRegistrationSource_RegistrationsFor_InfoFormat, service.Description));

      IComponentRegistration[] existingRegistrations = registrationAccessor(service).ToArray();
      if (existingRegistrations.Length > 0) return Enumerable.Empty<IComponentRegistration>();

      var typedService = service as TypedService;
      bool canMock = typedService != null &&
                     (typedService.ServiceType.IsInterface || typedService.ServiceType.IsAbstract ||
                      !typedService.ServiceType.IsSealed);

      if (canMock)
      {
        _log.Debug(
          format => format(Resources.MoqRegistrationSource_RegistrationsFor_PreMockCreateFormat, service.Description));
        return new[]
        {
          RegistrationBuilder
            .ForDelegate((context, parameters) =>
            {
              MethodInfo typedMethod = _createMethod.MakeGenericMethod(new[] {typedService.ServiceType});
              var mock = (Mock) typedMethod.Invoke(this, null);
              return mock.Object;
            })
            .As(typedService)
            .SingleInstance()
            .CreateRegistration()
        };
      }

      return Enumerable.Empty<IComponentRegistration>();
    }

    /// <summary>
    ///   Gets whether the registrations provided by this source are 1:1 adapters on top
    ///   of other components (I.e. like Meta, Func or Owned.)
    /// </summary>
    public bool IsAdapterForIndividualComponents
    {
      get { return false; }
    }

    // ReSharper disable UnusedMember.Local
    /// <summary>
    ///   Creates the desired mock using repository logic. This abstraction exists to simplify the process of using
    ///   reflection to call a generic method; the repository Create method has several overloads that would cause
    ///   the resulting reflection code to be more complex.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private Mock<T> CreateUsingRepository<T>() where T : class
    {
      return _repository.Create<T>();
    }

    // ReSharper restore UnusedMember.Local
  }
}