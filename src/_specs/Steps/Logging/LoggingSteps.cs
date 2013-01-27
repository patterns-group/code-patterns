#region New BSD License

// // Copyright (c) 2013, John Batte
// // All rights reserved.
// // 
// // Redistribution and use in source and binary forms, with or without modification, are permitted
// // provided that the following conditions are met:
// // 
// // Redistributions of source code must retain the above copyright notice, this list of conditions
// // and the following disclaimer.
// // 
// // Redistributions in binary form must reproduce the above copyright notice, this list of conditions
// // and the following disclaimer in the documentation and/or other materials provided with the distribution.
// // 
// // THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// // WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// // PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// // ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// // TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// // HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// // NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// // POSSIBILITY OF SUCH DAMAGE.

#endregion

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Logging
{
    [Binding]
    [Scope(Feature = "Logging")]
    public class LoggingSteps
    {
        [Given(@"I have configured a new container")]
        public void ConfigureContainer()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have registered the LoggingModule")]
        public void RegisterLoggingModule()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have registered a test type with a dependency on ILog")]
        public void RegisterILogDependantTestType()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have resolved an instance of the test type")]
        public void ResolveTestType()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I inspect the ILog instance the test type is using")]
        public void GetILogImplementation()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the ILog instance should be configured correctly for the test type")]
        public void AssertILogInstanceConfiguration()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have registered an intercepted test type")]
        public void RegisterInterceptedTestType()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call a method on the test type")]
        public void CallTestTypeMethod()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the ILog instance should be called as expected using the happy path")]
        public void AssertILogHappyPathCallPattern()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the ILog instance should be called as expected using the error path")]
        public void AssertILogErrorPathCallPattern()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have created a LoggingInterceptor instance")]
        public void CreateLoggingInterceptor()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I tell the interceptor to intercept an invocation")]
        public void InterceptInvocation()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the IInvocation instance should be called as expected")]
        public void AssertIInvocationCallPattern()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have configured my mock IInvocation instance to throw an error when proceeding")]
        public void ConfigureIInvocationThrowException()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have created a manual interceptor proxy to a test type, using the LoggingInterceptor")]
        public void CreateManualLoggingInterceptorProxy()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I call a volatile method on the test type")]
        public void CallVolatileTestTypeMethod()
        {
            ScenarioContext.Current.Pending();
        }
    }
}