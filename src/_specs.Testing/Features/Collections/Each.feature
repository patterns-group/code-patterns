Feature: Each for Enumerables
	As a developer, I want to be able to easily run a delegate,
	method group, or lambda expression across a set of items, while
	optionally setting the actions to run in parallel.

Scenario: Serial
	Given I have a set of objects with 5 items
	And my Each logic for objects logs invocations with Thread IDs
	When I run my Each logic against each object in the set using Each
	Then the invocation log should contain 5 items
	And each Thread ID in the invocation log should be the same

Scenario: Parallel
	Given I have a set of objects with 5 items
	And my Each logic for objects logs invocations with Thread IDs
	When I run my Each logic against each object in the set using Each with parallel set to true
	Then the invocation log should contain 5 items
	And there should be more than one unique Thread ID in the invocation log