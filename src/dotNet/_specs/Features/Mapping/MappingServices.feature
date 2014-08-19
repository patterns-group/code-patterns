Feature: Mapping Services
	In order to perform simple mapping operations
	As a developer
	I want to map from type to type without creating a map first, and without using dynamic mapping

Scenario: Automatic single type to single type mapping
	Given I have a source object for mapping
	When I map the object to a destination type
	Then the original object should have the same values as the mapped object

Scenario: Automatic collection to collection mapping
	Given I have a source object collection with 10 items for mapping
	When I map the collection to another type
	Then the mapped collection should have 10 items
	And all of the original objects should have the same values as the mapped objects