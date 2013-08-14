using Moq;

namespace Patterns.Specifications.Models.Testing.Moq
{
	public class TestContainerContext
	{
		public TestContainerTarget Target { get; set; }

		public Mock<TestContainerTarget> TargetMock { get; set; }
	}
}