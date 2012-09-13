Feature: Date Time Info
	As a developer, I want to be able to use an abstraction to the static
	DateTime class and its Now property, and I want the default implementation
	to provide equivalent information when compared to DateTime.

@dateTimeInfo
Scenario: Now vs GetNow
	Given I have a default DateTime abstraction
	When I store the results of both the DateTime.Now property and the IDateTimeInfo.GetNow method
	Then the results of both "now" DateTime values should be equal