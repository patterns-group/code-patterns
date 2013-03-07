Feature: GetPropertyValues for objects
	As a developer, I want to quickly access the properties of an object
	and their values without needing to access the clunky Reflection API.

Scenario: Value Type
	Given my object is an integer with the value 47
	When I get the property values of my object
	Then the property values should be empty

Scenario: Reference Type
	Given my object is a test object with the following values:
		| name | value |
		| Id   | 47    |
		| Data | ABC   |
	When I get the property values of my object
	Then the property values should be equivalent to:
		| name | value |
		| Id   | 47    |
		| Data | ABC   |