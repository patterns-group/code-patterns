Feature: Core Module
	As a developer, I want to be able to register a single module for Patterns
	and get the default implementations of each public interface defined in
	the core library.

@autofac
@refreshContainer
Scenario: Runtime - IDateTimeInfo
	Given I have registered the core module
	And I have created the container
	When I try to resolve the IDateTimeInfo interface
	Then the resolved object should be an instance of DefaultDateTimeInfo