Feature: Exception Handling
	As a developer, I want to be able to isolate the scope of error-prone code,
	and I want the ability to either rely on a basic error handling policy,
	or provide my own logic to respond to exceptions.

Background: 
	Given I have prepared a test subject
	And I have subscribed to all observable feeds on the subject
	And I have set the default error handling behavior to record all errors for the test
	And I have created an observable feed for test errors

@trackReads
@trackErrors
Scenario: normal property read
	When I try to read a property value from the subject
	Then the value that I read should be the value I expected
	And the feed for property read requests should have returned 1 item
	And the feed for property read responses should have returned 1 item
	And the feed for errors should have returned 0 items

@trackWrites
@trackErrors
Scenario: normal property write
	When I try to write to a property value on the subject
	And I try to read a property value from the subject
	Then the value that I read should be the value I wrote
	And the feed for property write requests should have returned 1 item
	And the feed for errors should have returned 0 items

@trackCalls
@trackErrors
Scenario: normal method call
	When I try to call a method on the subject
	Then the method call should complete with no errors
	And the feed for method call requests should have returned 1 item
	And the feed for method call responses should have returned 1 item
	And the feed for errors should have returned 0 items

@trackReads
@trackErrors
Scenario: angry property read
	When I try to read a value that throws an exception from the subject
	Then the value I read should be the default value for the return type
	And the feed for property read requests should have returned 1 item
	And the feed for property read responses should have returned 0 items
	And the feed for errors should have returned 1 item

@trackWrites
@trackErrors
Scenario: angry property write
	When I try to write to a property value that throws an exception on the subject
	And I try to read a property value from the subject
	Then the value that I read should be the value I expected
	And the feed for property write requests should have returned 1 item
	And the feed for errors should have returned 1 item

@trackCalls
@trackErrors
Scenario: angry method call
	When I try to call a method that throws an exception on the subject
	Then the method call should abort
	And the feed for method call requests should have returned 1 item
	And the feed for method call responses should have returned 0 items
	And the feed for errors should have returned 1 item

@trackReads
@trackErrors
Scenario: angry property read with error handling
	Given I have a custom error handler that does not write to the error feed
	When I try to read a value that throws an exception from the subject
	Then the value I read should be the default value for the return type
	And the feed for property read requests should have returned 1 item
	And the feed for property read responses should have returned 0 items
	And the feed for errors should have returned 0 items

@trackWrites
@trackErrors
Scenario: angry property write with error handling
	Given I have a custom error handler that does not write to the error feed
	When I try to write to a property value that throws an exception on the subject
	And I try to read a property value from the subject
	Then the value that I read should be the value I expected
	And the feed for property write requests should have returned 1 item
	And the feed for errors should have returned 0 items

@trackCalls
@trackErrors
Scenario: angry method call with error handling
	Given I have a custom error handler that does not write to the error feed
	When I try to call a method that throws an exception on the subject
	Then the method call should abort
	And the feed for method call requests should have returned 1 item
	And the feed for method call responses should have returned 0 items
	And the feed for errors should have returned 0 items