Feature: Time Extensions
	As a developer, I want to have access to extensions that
	allow me to manipulate and access date and time information
	more easily than I can with standard methods.

Scenario: DateTime Accuracy to One Second
	Given I have a DateTime value
	And I have a second DateTime value that varies from the first by 100 milliseconds
	When I adjust the accuracy of each DateTime value to one second
	And I compare the first and second DateTime values
	Then the resulting difference should be zero