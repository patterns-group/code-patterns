Feature: Logging
	As a developer
	I want a way to automatically log any method call
	And I want a way to automatically get instances of the logger I should use

# by following the manual path to creating a Castle DynamicProxy2 interceptor
# and using the LoggingInterceptor type
# when we intercept instances of classes that we define
# then we should see that interception takes place as expected
# this applies to all logical paths that exist within the interceptor
# therefore, we should mock both the IInvocation instance
# and the ILog instance. This means that the method used to retrieve an ILog
# instance should be injected.
Scenario: Logging Interceptor
	Given I have a fresh mock container
	And I have created a LoggingInterceptor instance
	When I tell the interceptor to intercept an invocation
	Then the ILog instance should be called as expected using the happy path
	And the IInvocation instance should be called as expected

Scenario: Logging Interceptor with no return
	Given I have a fresh mock container
	And I have created a LoggingInterceptor instance
	When I tell the interceptor to intercept an invocation with no return value
	Then the ILog instance should be called as expected using the happy path for no returns
	And the IInvocation instance should be called as expected using the path for no returns

Scenario: Logging Interceptor with Exception
	Given I have a fresh mock container
	And I have created a LoggingInterceptor instance
	And I have configured my mock IInvocation instance to throw an error when proceeding
	When I tell the interceptor to intercept an invocation
	Then the IInvocation instance should be called as expected using the error path
	And the ILog instance should be called as expected using the error path

Scenario: Logging Interceptor with Untrapped Exception
	Given I have a fresh mock container
	And I have created a LoggingInterceptor instance that does not trap exceptions
	And I have configured my mock IInvocation instance to throw an error when proceeding
	When I tell the interceptor to intercept an invocation
	Then the IInvocation instance should be called as expected using the error path
	And the ILog instance should be called as expected using the error path

Scenario: Manual Logging Interceptor
	Given I have created a manual interceptor proxy to a test type, using the LoggingInterceptor
	When I call a method on the test type
	Then the ILog instance should be called as expected using the happy path

Scenario: Manual Logging Interceptor with Exception
	Given I have created a manual interceptor proxy to a test type, using the LoggingInterceptor
	When I call a volatile method on the test type
	Then the ILog instance should be called as expected using the error path

# by using the Autofac path to retrieving an intercepted type
# when we intercept instances of types that we define
# then we should see that interception takes place as expected
# this applies to all logical paths that exist within the interceptor
# (see above)
Scenario: Autofac Interceptor
	Given I have created a new container builder
	And I have registered the LoggingModule
	And I have registered an intercepted test type
	And I have resolved an instance of the test type
	When I call a method on the test type
	Then the ILog instance should be called as expected using the happy path

Scenario: Autofac Interceptor with Exception
	Given I have created a new container builder
	And I have registered the LoggingModule
	And I have registered an intercepted test type
	And I have resolved an instance of the test type
	When I call a method on the test type
	Then the ILog instance should be called as expected using the error path

# by using the Autofac path to retrieving a registered type
# when we retrieve instances of types that depend on ILog
# then we should see that the retrieved instances have the expected ILog references
Scenario: Autofac ILog Provider
	Given I have created a new container builder
	And I have registered the LoggingModule
	And I have registered a test type with a dependency on ILog
	And I have resolved an instance of the test type
	When I inspect the ILog instance the test type is using
	Then the ILog instance should be configured correctly for the test type