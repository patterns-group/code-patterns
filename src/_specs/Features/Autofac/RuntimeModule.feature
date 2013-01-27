Feature: Runtime Module
	As a developer, I want to be able to register a module for Patterns.Runtime
	and get the default implementations of each public interface defined in
	the Patterns.Runtime namespace.

@autofac
@refreshContainer
Scenario: Runtime - IDateTimeInfo
	Given I have registered the runtime module
	And I have created the container
	When I try to resolve the IDateTimeInfo interface
	Then the resolved object should be an instance of DefaultDateTimeInfo