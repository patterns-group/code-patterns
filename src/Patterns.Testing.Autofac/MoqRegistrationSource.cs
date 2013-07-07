using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Autofac.Builder;
using Autofac.Core;

using Moq;

namespace Patterns.Testing.Autofac
{
	/// <summary>
	/// Provides a registration source for Autofac using Moq's MockRepository as a service factory.
	/// </summary>
	public class MoqRegistrationSource : IRegistrationSource
	{
		private static readonly MockRepository _repository = new MockRepository(MockBehavior.Default);
		private static readonly MethodInfo _createMethod = typeof(MoqRegistrationSource)
			.GetMethod("CreateUsingRepository", BindingFlags.NonPublic | BindingFlags.Instance)
			.GetGenericMethodDefinition();

		/// <summary>
		/// Retrieve registrations for an unregistered service, to be used
		/// by the container.
		/// </summary>
		/// <param name="service">The service that was requested.</param>
		/// <param name="registrationAccessor">A function that will return existing registrations for a service.</param>
		/// <returns>
		/// Registrations providing the service.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">service</exception>
		/// <remarks>
		/// If the source is queried for service s, and it returns a component that implements both s and s', then it
		/// will not be queried again for either s or s'. This means that if the source can return other implementations
		/// of s', it should return these, plus the transitive closure of other components implementing their
		/// additional services, along with the implementation of s. It is not an error to return components
		/// that do not implement <paramref name="service" />.
		/// </remarks>
		public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
		{
			if (service == null) throw new ArgumentNullException("service");

			IComponentRegistration[] existingRegistrations = registrationAccessor(service).ToArray();
			if (existingRegistrations.Length > 0) return existingRegistrations;

			var typedService = service as TypedService;
			return typedService == null
				? Enumerable.Empty<IComponentRegistration>()
				: new[]
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

		/// <summary>
		/// Gets whether the registrations provided by this source are 1:1 adapters on top
		/// of other components (I.e. like Meta, Func or Owned.)
		/// </summary>
		public bool IsAdapterForIndividualComponents
		{
			get { return false; }
		}

		// ReSharper disable UnusedMember.Local
		/// <summary>
		/// Creates the desired mock using repository logic. This abstraction exists to simplify the process of using
		/// reflection to call a generic method; the repository Create method has several overloads that would cause
		/// the resulting reflection code to be more complex.
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