using System.Collections.Specialized;
using System.Configuration;

namespace Patterns.Configuration
{
	public interface IConfigurationManager
	{
		object GetSection(string sectionName);

		System.Configuration.Configuration OpenExeConfiguration(string exePath);

		System.Configuration.Configuration OpenExeConfiguration(ConfigurationUserLevel userLevel);

		System.Configuration.Configuration OpenMachineConfiguration();

		System.Configuration.Configuration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel);

		void RefreshSection(string sectionName);

		NameValueCollection AppSettings { get; }

		ConnectionStringSettingsCollection ConnectionStrings { get; }
	}
}