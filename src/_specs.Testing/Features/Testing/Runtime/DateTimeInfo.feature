Feature: Using DateTime Values During Unit Tests
	As a developer, I want to be able to initialize a test
	implementation of the DateTime abstraction defined in
	Patterns.Runtime that seeds or overrides time-based values,
	allowing me to simulate time-centric scenarios during tests.

Scenario: Static Time
	Given I have a DateTime info provider for testing
	And I have configured the test DateTime info provider to use a static time
	When I store the return value of the DateTime info provider's "GetNow" method
	Then the stored DateTime value should be equal to the static time I used