Feature: Runtime Module
	As a developer, I want to be able to register an Autofac module for Patterns.Runtime
	and get the default implementations of each public interface defined in
	the Patterns.Runtime namespace.

@autofac
Scenario: Runtime - IDateTimeInfo
	Given I have registered the runtime module
	And I have created the Autofac container
	When I try to resolve an IDateTimeInfo instance
	Then the resolved IDateTimeInfo object should be an instance of DefaultDateTimeInfo