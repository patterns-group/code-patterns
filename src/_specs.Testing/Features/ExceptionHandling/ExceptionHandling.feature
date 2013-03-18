Feature: Exception Handling
	As a developer, I want to be able to isolate the scope of error-prone code,
	and I want the ability to either rely on a basic error handling policy,
	or provide my own logic to respond to exceptions.

Scenario: Try.Get (Normal)
	Given I have mapped the default error strategy to store exceptions
	When I try to get the return value of a normal function
	Then the return value should be the expected return value
	And there should not be an error

Scenario: Try.Get (Exception)
	Given I have mapped the default error strategy to store exceptions
	When I try to get the return value of a function that throws an exception
	Then the return value should be the default value for that type
	And there should be an error

Scenario: Try.Get (Exception with Custom Handler)
	Given I have mapped the custom error strategy to store exceptions
	When I try to get the return value of a function that throws an exception, providing the custom strategy
	Then the return value should be the default value for that type
	And there should be an error

Scenario: Try.Do (Normal)
	Given I have mapped the default error strategy to store exceptions
	When I try to run a normal action
	Then there should not be an error

Scenario: Try.Do (Exception)
	Given I have mapped the default error strategy to store exceptions
	When I try to run an action that throws an exception
	Then there should be an error

Scenario: Try.Do (Exception with Custom Handler)
	Given I have mapped the custom error strategy to store exceptions
	When I try to run an action that throws an exception, providing the custom strategy
	Then there should be an error