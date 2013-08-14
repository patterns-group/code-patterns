using FluentAssertions;

using Patterns.Specifications.Models.Mocking;
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
	}
}