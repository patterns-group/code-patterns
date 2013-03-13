Feature: Logging
	As a developer
	I want a way to automatically log any method call
	And I want a way to automatically get instances of the logger I should use

# when an invocation has been mocked, using an interceptor directly 
# should cause log calls to take place, and the invocation should be
# instructed to proceed.

Scenario: Logging Interceptor
	Given I have a default log config
	And I have a log factory that returns a mocked ILog
	And I have a mocked invocation
	And I have a logging interceptor
	When I call the interceptor directly
	Then the mocked ILog should have been called using the normal no-return execution path
	And the mocked invocation should have been instructed to proceed

Scenario: Logging Interceptor with return value
	Given I have a default log config
	And I have a log factory that returns a mocked ILog
	And I have a mocked invocation that returns a value
	And I have a logging interceptor
	When I call the interceptor directly
	Then the mocked ILog should have been called using the normal execution path
	And the mocked invocation should have been instructed to proceed

Scenario: Logging Interceptor with Exception
	Given I have a default log config
	And I have a log factory that returns a mocked ILog
	And I have a mocked invocation that throws an Exception
	And I have a logging interceptor
	When I call the interceptor directly
	Then the mocked ILog should have been called using the broken execution path
	And the mocked invocation should have been instructed to proceed
	And there should be an error

Scenario: Logging Interceptor with trapped Exception
	Given I have a log config set to trap errors
	And I have a log factory that returns a mocked ILog
	And I have a mocked invocation that throws an Exception
	And I have a logging interceptor
	When I call the interceptor directly
	Then the mocked ILog should have been called using the trapped-error execution path
	And the mocked invocation should have been instructed to proceed
	And there should not be an error

# when a dynamic proxy has been manually created using our interceptor,
# log calls should take place, and the proxied method should execute.

Scenario: Manual Logging Interceptor
	Given I have a default log config
	And I have a log factory that returns a mocked ILog
	And I have a logging interceptor
	And I have a dynamic proxy to the logging test subject
	When I call a normal void method on the logging test subject
	Then the mocked ILog should have been called using the normal no-return execution path

Scenario: Manual Logging Interceptor with return value
	Given I have a default log config
	And I have a log factory that returns a mocked ILog
	And I have a logging interceptor
	And I have a dynamic proxy to the logging test subject
	When I call a normal method with a return value on the logging test subject
	Then the mocked ILog should have been called using the normal execution path

Scenario: Manual Logging Interceptor with Exception
	Given I have a default log config
	And I have a log factory that returns a mocked ILog
	And I have a logging interceptor
	And I have a dynamic proxy to the logging test subject
	When I call a method that throws an Exception on the logging test subject
	Then the mocked ILog should have been called using the broken execution path
	And there should be an error

Scenario: Manual Logging Interceptor with trapped Exception
	Given I have a log config set to trap errors
	And I have a log factory that returns a mocked ILog
	And I have a logging interceptor
	And I have a dynamic proxy to the logging test subject
	When I call a method that throws an Exception on the logging test subject
	Then the mocked ILog should have been called using the trapped-error execution path
	And there should not be an error

# when an intercepted instance has been retrieved,
# log calls should take place, and the proxied method should execute.

Scenario: Autofac Interceptor
	Given I have registered the logging module
	And I have registered the default test logging module
	And I have created the Autofac container
	And I have resolved an instance of the logging test subject
	When I call a normal void method on the logging test subject
	Then the mocked ILog should have been called using the normal no-return execution path

Scenario: Autofac Interceptor with return value
	Given I have registered the logging module
	And I have registered the default test logging module
	And I have created the Autofac container
	And I have resolved an instance of the logging test subject
	When I call a normal method with a return value on the logging test subject
	Then the mocked ILog should have been called using the normal execution path

Scenario: Autofac Interceptor with Exception
	Given I have registered the logging module
	And I have registered the default test logging module
	And I have created the Autofac container
	And I have resolved an instance of the logging test subject
	When I call a method that throws an Exception on the logging test subject
	Then the mocked ILog should have been called using the broken execution path
	And there should be an error

Scenario: Autofac Interceptor with trapped Exception
	Given I have registered the logging module
	And I have registered the error trapping test logging module
	And I have created the Autofac container
	And I have resolved an instance of the logging test subject
	When I call a method that throws an Exception on the logging test subject
	Then the mocked ILog should have been called using the trapped-error execution path
	And there should not be an error

# when components ask for ILog directly, the instances retrieved
# should be correctly type-bound to the requesting components

Scenario: Autofac ILog Provider
	Given I have registered the logging module with a trackable log factory
	And I have registered the manual logging test subject
	And I have created the Autofac container
	When I have resolved an instance of the manual logging test subject
	Then the resolved ILog should be type-bound to the manual logging test subject