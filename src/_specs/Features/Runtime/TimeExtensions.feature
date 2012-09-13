Feature: Time Extensions
	As a developer, I want to have access to extensions that
	allow me to manipulate and access date and time information
	more easily than I can with standard methods.

@timeExtensions
Scenario: DateTime Accuracy to One Second
	Given I have a primary DateTime value
	And I have a secondary DateTime value
	And the DateTime values vary by millisecond
	When I adjust the accuracy of each DateTime value to one second
	And I compare the DateTime values
	Then the resulting difference should be zero