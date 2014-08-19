Feature: Equality Comparer
	In order to avoid the need to create new equality comparer types for niche use cases
	As a developer
	I want to be able to use a comparer that lets me override its default behavior

Scenario Outline: String Comparisons
	Given I have created a new equality comparer for strings using the <strategy> strategy
	When I compare the <left> string to the <right> string
	Then the result of the "is equal" operation should be <result>
Examples: 
	| strategy         | left  | right | result |
	| default          | hello | HELLO | false  |
	| default          | hello | hello | true   |
	| case sensitive   | hello | HELLO | false  |
	| case sensitive   | hello | hello | true   |
	| case insensitive | hello | HELLO | true   |
	| case insensitive | hello | hello | true   |