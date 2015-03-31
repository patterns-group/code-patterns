Feature: ResetPosition for a stream
	As a developer, I want to easily reset the position of a stream
	to the beginning so my life is easier.

@stream
Scenario: Reset Postion
	Given I have a memory stream of "This is data"
	And I set the position to be at the end
	When I call reset position
	Then the position should be at the beginning
