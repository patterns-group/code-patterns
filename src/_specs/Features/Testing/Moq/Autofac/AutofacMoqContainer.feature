Feature: Autofac Moq Container
	In order to be able to easily get a mixture of mocked and registered objects
	As a unit or integration test developer
	I want to have a container that seamlessly blends Autofac with Moq

Background: 
	Given I have an Autofac/Moq test container
	Then the Autofac/Moq test container should have 0 registrations for my test interface

Scenario: Create an unregistered interface
	When I create an instance of an interface using the test container
	Then the test container should have given me an object
	And the Autofac/Moq test container should have 1 registration for my test interface
	And the object retrieved by the test container should be a mock-based type

Scenario: Create an unregistered creatable class
	When I create an instance of a creatable class using the test container
	Then the test container should have given me an object
	And the Autofac/Moq test container should have 1 registration for my test interface
	And the object retrieved by the test container should not be a mock-based type

Scenario: Create a registered object
	When I register an object with the test container
	And I create an instance of an interface using the test container
	Then the Autofac/Moq test container should have 1 registration for my test interface
	And the test container should have given me an object
	And the object retrieved by the test container should not be a mock-based type

Scenario: Override a registered object
	When I register an object with the test container
	And I create an instance of an interface using the test container
	Then the Autofac/Moq test container should have 1 registration for my test interface
	And the test container should have given me an object
	And the object retrieved by the test container should not be a mock-based type

	When I create a mock of the object using the test container
	And I create an instance of an interface using the test container
	Then the Autofac/Moq test container should have 2 registrations for my test interface
	And the test container should have given me an object
	And the test container should have given me a mock of the object
	And the object retrieved by the test container should be a mock-based type