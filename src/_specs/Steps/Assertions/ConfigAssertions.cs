using System.Diagnostics;

using FluentAssertions;

using Moq;

using Patterns.Configuration;
using Patterns.Specifications.Steps.Observations;

using TechTalk.SpecFlow;

using MockFactory = Patterns.Specifications.Steps.Factories.MockFactory;

namespace Patterns.Specifications.Steps.Assertions
{
	[Binding]
	public class ConfigAssertions : TechTalk.SpecFlow.Steps
	{
		[Then(@"the mocked config abstraction should have been asked for a Configuration Section named ""(.*)"" exactly (.*) time(?:s)?")]
		public void VerifyConfigAbstractionGetSection(string sectionName, int numberOfTimes)
		{
		    MockFactory.Mocks.Mock<IConfigurationManager>().Verify(manager => manager.GetSection(sectionName), Times.Exactly(numberOfTimes));
		}

		[Then(@"the Configuration Section I retrieved from the Configuration Source should be the expected section")]
		public void AssertExpectedConfigSection()
		{
		    ConfigObservations.ActualConfig.Should().BeSameAs(ConfigObservations.ExpectedConfig);
		}

        [Then(@"the Configuration Section I retrieved from the Configuration Source should be null")]
        public void AssertNullConfigSection()
        {
            ConfigObservations.ActualConfig.Should().BeNull();
        }

        [Then(@"the Configuration Section I retrieved from the Configuration Source should not be the expected section")]
        public void AssertActualConfigSectionWrongType()
        {
            ConfigObservations.ActualConfig.Should().NotBeNull().And.NotBeSameAs(ConfigObservations.ExpectedConfig);
            Debug.Assert(ConfigObservations.ActualConfig != null);
            Debug.Assert(ConfigObservations.ExpectedConfig != null);
            var expectedType = ConfigObservations.ExpectedConfig.GetType();
            expectedType.IsAssignableFrom(ConfigObservations.ActualConfig.GetType()).Should().BeFalse();
        }
	}
}