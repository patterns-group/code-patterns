using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Autofac.Builder;
using Autofac.Core;

using Moq;

namespace Patterns.Testing.Moq
{
	public class MoqRegistrationSource : IRegistrationSource
	{
		private static readonly MockRepository _repository = new MockRepository(MockBehavior.Default);
		private static readonly MethodInfo _createMethod = typeof(MoqRegistrationSource)
			.GetMethod("CreateUsingRepository", BindingFlags.NonPublic | BindingFlags.Instance)
			.GetGenericMethodDefinition();

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