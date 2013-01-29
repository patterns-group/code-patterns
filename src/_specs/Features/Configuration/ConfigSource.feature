Feature: Configuration Source
	As a developer
	I want to be able to inject my dependencies for configuration
	So that I can separate my component logic from the act of manually loading config

Scenario: GetSection (normal)
	Given I have a fresh mock container
	And I have a mocked config abstraction
	And I have set the mocked config abstraction to return a Configuration Section when the section name is "settings"
	And I have a new Configuration Source using the mocked config abstraction
	When I ask for a Configuration Section named "settings" from the Configuration Source
	Then the mocked config abstraction should have been asked for a Configuration Section named "settings" exactly 1 time
	And the Configuration Section I retrieved from the Configuration Source should be the expected section

Scenario: GetSection (missing)
	Given I have a fresh mock container
	And I have a mocked config abstraction
	And I have set the mocked config abstraction to return a null Configuration Section when the section name is "settings"
	And I have a new Configuration Source using the mocked config abstraction
	When I ask for a Configuration Section named "settings" from the Configuration Source
	Then the mocked config abstraction should have been asked for a Configuration Section named "settings" exactly 1 time
	And the Configuration Section I retrieved from the Configuration Source should be null

Scenario: GetSection (wrong type)
	Given I have a fresh mock container
	And I have a mocked config abstraction
	And I have set the mocked config abstraction to return a different Configuration Section when the section name is "settings"
	And I have a new Configuration Source using the mocked config abstraction
	When I ask for a Configuration Section named "settings" from the Configuration Source
	Then the mocked config abstraction should have been asked for a Configuration Section named "settings" exactly 1 time
	And the Configuration Section I retrieved from the Configuration Source should not be the expected section

Scenario: GetSection (config exception)
	Given I have a fresh mock container
	And I have a mocked config abstraction
	And I have set the mocked config abstraction to throw an exception when asked for a Configuration Section with the section name "settings"
	And I have a new Configuration Source using the mocked config abstraction
	When I ask for a Configuration Section named "settings" from the Configuration Source
	Then the mocked config abstraction should have been asked for a Configuration Section named "settings" exactly 1 time
	And a configuration exception should have been thrown
	And the Configuration Section I retrieved from the Configuration Source should be null