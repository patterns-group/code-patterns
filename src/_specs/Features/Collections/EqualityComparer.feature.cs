﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18213
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Patterns.Specifications.Features.Collections
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Equality Comparer")]
    public partial class EqualityComparerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "EqualityComparer.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Equality Comparer", "In order to avoid the need to create new equality comparer types for niche use ca" +
                    "ses\r\nAs a developer\r\nI want to be able to use a comparer that lets me override i" +
                    "ts default behavior", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("String Comparisons")]
        [NUnit.Framework.TestCaseAttribute("default", "hello", "HELLO", "false", null)]
        [NUnit.Framework.TestCaseAttribute("default", "hello", "hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("case sensitive", "hello", "HELLO", "false", null)]
        [NUnit.Framework.TestCaseAttribute("case sensitive", "hello", "hello", "true", null)]
        [NUnit.Framework.TestCaseAttribute("case insensitive", "hello", "HELLO", "true", null)]
        [NUnit.Framework.TestCaseAttribute("case insensitive", "hello", "hello", "true", null)]
        public virtual void StringComparisons(string strategy, string left, string right, string result, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("String Comparisons", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given(string.Format("I have created a new equality comparer for strings using the {0} strategy", strategy), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When(string.Format("I compare the {0} string to the {1} string", left, right), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then(string.Format("the result of the \"is equal\" operation should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
