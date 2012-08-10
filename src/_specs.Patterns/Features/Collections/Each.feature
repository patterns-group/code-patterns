Feature: Each for Enumerables
	As a developer, I want to be able to easily run a delegate,
	method group, or lambda expression across a set of items, while
	optionally setting the actions to run in parallel.

Background:
	Given I have a fresh mock container
	And I have a mocked test bucket that is prepared to verify calls

Scenario: Serial
	Given I have a set with 5 items
	And I set my "add to test bucket" logic to be a simple call to Add
	When I run my "add to test bucket" logic using Each
	Then the mocked test bucket's Add method should have been called 5 times

Scenario: Parallel
	Given I have a set with 5 items
	And I set my "add to test bucket" logic to set the thread Id on the item and then call Add
	When I run my "add to test bucket" logic using Each with parallel set to true
	Then the mocked test bucket's Add method should have been called 5 times
	And each item in the test bucket should have a thread Id
	And there should be more than one distinct thread Id in the test bucket's items