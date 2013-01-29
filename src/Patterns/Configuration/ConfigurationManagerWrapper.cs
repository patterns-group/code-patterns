using System.Collections.Specialized;
using System.Configuration;

namespace Patterns.Configuration
{
	public class ConfigurationManagerWrapper : IConfigurationManager
	{
		public virtual object GetSection(string sectionName)
		{
			return ConfigurationManager.GetSection(sectionName);
		}

		public virtual System.Configuration.Configuration OpenExeConfiguration(string exePath)
		{
			return ConfigurationManager.OpenExeConfiguration(exePath);
		}

		public virtual System.Configuration.Configuration OpenExeConfiguration(ConfigurationUserLevel userLevel)
		{
			return ConfigurationManager.OpenExeConfiguration(userLevel);
		}

		public virtual System.Configuration.Configuration OpenMachineConfiguration()
		{
			return ConfigurationManager.OpenMachineConfiguration();
		}

		public virtual System.Configuration.Configuration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel)
		{
			return ConfigurationManager.OpenMappedExeConfiguration(fileMap, userLevel);
		}

		public virtual void RefreshSection(string sectionName)
		{
			ConfigurationManager.RefreshSection(sectionName);
		}

		public virtual NameValueCollection AppSettings { get { return ConfigurationManager.AppSettings; } }
		public virtual ConnectionStringSettingsCollection ConnectionStrings { get { return ConfigurationManager.ConnectionStrings; } }
	}
}