Feature: AddRange for Collections
	As a developer, I want to be able to add a range of items to any
	collection using the same easy syntax that the generic List class
	provides.

@collections
Scenario: Add to existing collection
	Given I have an object collection with 5 items
	When I add 10 items to the object collection using the AddRange extension
	Then the object collection should contain 15 items

@collections
Scenario: Add to empty collection
	Given I have an empty object collection
	When I add 10 items to the object collection using the AddRange extension
	Then the object collection should contain 10 items

@collections
Scenario: Add to null collection
	Given I have a null object collection
	When I add 10 items to the object collection using the AddRange extension
	Then an ArgumentNullException for the items argument should have been thrown
	And the object collection should be null

@collections
Scenario: Add nothing to empty collection
	Given I have an empty object collection
	When I add 0 items to the object collection using the AddRange extension
	Then the object collection should contain 0 items

@collections
Scenario: Add null to empty collection
	Given I have an empty object collection
	When I add a null set to the object collection using the AddRange extension
	Then the object collection should contain 0 items

@collections
Scenario: Add null to existing collection
	Given I have an object collection with 5 items
	When I add a null set to the object collection using the AddRange extension
	Then the object collection should contain 5 items