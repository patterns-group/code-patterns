Feature: Autofac Moq Container
	In order to be able to easily get a mixture of mocked and registered objects
	As a unit or integration test developer
	I want to have a container that seamlessly blends Autofac with Moq

Background: 
	Given I have an Autofac/Moq test container

Scenario: Create an unregistered object
	When I create an object using the test container
	Then the test container should have given me an object
	And the object retrieved by the test container should be a mock-based type

Scenario: Create a registered object
	When I register an object with the test container
	And I create an object using the test container
	Then the test container should have given me an object
	And the object retrieved by the test container should not be a mock-based type

Scenario: Override a registered object
	When I register an object with the test container
	And I create an object using the test container
	Then the test container should have given me an object
	And the object retrieved by the test container should not be a mock-based type

	When I create a mock of the object using the test container
	And I create an object using the test container
	Then the test container should have given me an object
	And the test container should have given me a mock of the object
	And the object retrieved by the test container should be a mock-based type