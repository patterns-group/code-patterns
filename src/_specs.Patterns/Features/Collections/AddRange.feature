Feature: AddRange for Collections
	As a developer, I want to be able to add a range of items to any
	collection using the same easy syntax that the generic List class
	provides.

Scenario: Add to existing collection
	Given I have a collection with 5 items
	When I add 10 items to the collection using the AddRange extension
	Then the collection should contain 15 items

Scenario: Add to empty collection
	Given I have an empty collection
	When I add 10 items to the collection using the AddRange extension
	Then the collection should contain 10 items

Scenario: Add to null collection
	Given I have a null collection
	When I add 10 items to the collection using the AddRange extension
	Then an ArgumentNullException for the items argument should have been thrown
	And the collection should be null

Scenario: Add nothing to empty collection
	Given I have an empty collection
	When I add 0 items to the collection using the AddRange extension
	Then the collection should contain 0 items

Scenario: Add null to empty collection
	Given I have an empty collection
	When I add a null set to the collection using the AddRange extension
	Then the collection should contain 0 items

Scenario: Add null to existing collection
	Given I have a collection with 5 items
	When I add a null set to the collection using the AddRange extension
	Then the collection should contain 5 items