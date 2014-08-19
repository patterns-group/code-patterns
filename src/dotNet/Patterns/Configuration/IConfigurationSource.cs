using System.Collections.Generic;
using System.Configuration;

namespace Patterns.Configuration
{
	public interface IConfigurationSource
	{
		IDictionary<string, string> AppSettings { get; }

		IDictionary<string, ConnectionStringSettings> ConnectionStrings { get; }

		ConfigurationSection GetSection(string sectionName);

		TSection GetSection<TSection>(string sectionName) where TSection : ConfigurationSection, new();

		IConfiguration OpenExeConfiguration(string exePath);

		IConfiguration OpenExeConfiguration(ConfigurationUserLevel userLevel);

		IConfiguration OpenMachineConfiguration();

		IConfiguration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel);

		void RefreshSection(string sectionName);
	}
}