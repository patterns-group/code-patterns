Feature: Test Configuration Source
	As a developer
	I want to be able to inject my dependencies for configuration using test values
	So that I can test my component logic using various configuration scenarios

Scenario: GetSection (normal)
	Given I have a new Configuration Source using the canned config called "TestConfig1"
	When I ask for a Configuration Section named "settings" from the Configuration Source
	Then the Configuration Section I retrieved from the Configuration Source should be the expected section