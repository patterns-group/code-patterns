using System.Linq;

using Autofac.Core;

using FluentAssertions;

using Patterns.Specifications.Models.Mocking;
using Patterns.Specifications.Models.Testing.Moq;
using Patterns.Testing.Autofac.Moq;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Testing.Moq.Autofac
{
	[Binding]
	public class AutofacTestContainerSteps
	{
		private readonly MoqContext _moq;

		public AutofacTestContainerSteps(MoqContext moq)
		{
			_moq = moq;
		}

		[Given(@"I have an Autofac/Moq test container")]
		public void AssertMoqContainerIsAutofac()
		{
			_moq.Container.Should().NotBeNull().And.BeOfType<AutofacMoqContainer>();
		}

		[Then(@"the Autofac/Moq test container should have (.*) registration(?:s)? for my test object")]
		public void AssertRegistrationCount(int expectedRegistrations)
		{
			IComponentRegistry registry = _moq.Container.As<IAutofacMoqContainer>().ComponentRegistry;

			int registrationCount = registry.Registrations
				.Count(registration => registration.Services.Any(RegistrationMatchesType<TestContainerTarget>));

			registrationCount.Should().Be(expectedRegistrations);
		}

		private static bool RegistrationMatchesType<TService>(Service service)
		{
			return service is TypedService && ((TypedService)service).ServiceType == typeof(TService);
		}
	}
}