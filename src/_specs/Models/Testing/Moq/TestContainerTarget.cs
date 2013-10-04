namespace Patterns.Specifications.Models.Testing.Moq
{
	public interface ITestContainerTarget {}

	public interface ITestContainerDependency1{}
	public interface ITestContainerDependency2{}

	public class TestContainerTarget : ITestContainerTarget
	{
		public ITestContainerDependency1 Dependency1 { get; set; }
		public ITestContainerDependency2 Dependency2 { get; set; }

		public TestContainerTarget(ITestContainerDependency1 dependency1, ITestContainerDependency2 dependency2)
		{
			Dependency1 = dependency1;
			Dependency2 = dependency2;
		}
	}
}