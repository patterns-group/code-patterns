using System;

using Patterns.Specifications.Steps.Factories;
using Patterns.Specifications.Steps.Observations;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Automation
{
	[Binding]
	public class ConfigAutomation : TechTalk.SpecFlow.Steps
	{
		[When(@"I ask for a Configuration Section named ""(.*)"" from the Configuration Source")]
		public void ConfigSourceGetSection(string sectionName)
		{
		    try
		    {
		        ConfigObservations.ActualConfig = ConfigFactory.ConfigSource.GetSection(sectionName);
		    }
		    catch (Exception error)
		    {
		        ConfigObservations.ConfigException = error;
		    }
		}
	}
}