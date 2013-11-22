Feature: Time Extensions
	As a developer, I want to have access to extensions that
	allow me to manipulate and access date and time information
	more easily than I can with standard methods.

Scenario Outline: DateTime Accuracy to One Second
	Given I have a DateTime representation of <first time>
	And I have a second DateTime representation of <second time>
	When I adjust the accuracy of each DateTime value to one second
	And I compare the first and second DateTime values
	Then the resulting difference should be <difference> seconds

	Examples:
	| first time            | second time           | difference |
	| 1/1/2000 00:00:00.123 | 1/1/2000 00:00:00.456 | 0          |
	| 1/1/2000 00:00:00.950 | 1/1/2000 00:00:01.050 | 1          |
	| 1/1/2000 00:00:00.789 | 1/1/2000 00:00:15.012 | 15         |
