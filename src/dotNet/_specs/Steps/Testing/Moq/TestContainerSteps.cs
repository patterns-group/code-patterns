using FluentAssertions;

using Moq;

using Patterns.Specifications.Models.Mocking;
using Patterns.Specifications.Models.Testing.Moq;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Testing.Moq
{
	[Binding]
	public class TestContainerSteps
	{
		private readonly TestContainerContext _context;
		private readonly MoqContext _moq;

		public TestContainerSteps(TestContainerContext context, MoqContext moq)
		{
			_context = context;
			_moq = moq;
		}

		[When(@"I create an instance of an interface using the test container")]
		public void CreateTestContainerInterface()
		{
			_context.Target = _moq.Container.Create<ITestContainerTarget>();
		}

		[When(@"I create an instance of a creatable class using the test container")]
		public void CreateTestContainerObject()
		{
			_context.Target = _moq.Container.Create<ITestContainerTarget, TestContainerTarget>();
		}

		[Then(@"the test container should have given me an object")]
		public void AssertTestContainerObjectExists()
		{
			_context.Target.Should().NotBeNull();
		}

		[Then(@"the object retrieved by the test container should (.+)?be a mock-based type")]
		public void AssertTestContainerObjectMockness(string notModifier)
		{
			_context.Target.GetType().Implements(typeof (IMocked)).Should().Be(string.IsNullOrEmpty(notModifier));
		}

		[When(@"I register an object with the test container")]
		public void RegisterTestContainerObject()
		{
			_moq.Container.Update<ITestContainerTarget, TestContainerTarget>();
		}

		[When(@"I create a mock of the object using the test container(?: with the container's mock behavior)?")]
		public void MockTestContainerObjectWithContainersBehavior()
		{
			_context.TargetMock = _moq.Container.Mock<ITestContainerTarget>();
		}

		[When(@"I create a mock of the object using the test container with (default|loose|strict) mock behavior")]
		public void MockTestContainerObject(MockBehavior behavior)
		{
			_context.TargetMock = _moq.Container.Mock<ITestContainerTarget>(behavior);
		}

		[Then(@"the test container should have given me a mock of the object")]
		public void ThenTheTestContainerShouldHaveGivenMeAMockOfTheObject()
		{
			_context.TargetMock.Should().NotBeNull();
		}

		[Then(@"the object retrieved by the test container should have the container's mock behavior")]
		public void AssertMockObjectWithContainersBehavior()
		{
			_context.TargetMock.Behavior.Should().Be(_moq.Container.DefaultBehavior);
		}

		[Then(@"the object retrieved by the test container should have (default|loose|strict) mock behavior")]
		public void AssertMockObjectBehavior(MockBehavior behavior)
		{
			_context.TargetMock.Behavior.Should().Be(behavior);
		}
	}
}