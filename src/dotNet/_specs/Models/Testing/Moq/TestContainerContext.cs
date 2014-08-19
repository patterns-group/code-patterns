using Moq;

namespace Patterns.Specifications.Models.Testing.Moq
{
	public class TestContainerContext
	{
		public ITestContainerTarget Target { get; set; }

		public Mock<ITestContainerTarget> TargetMock { get; set; }
	}
}