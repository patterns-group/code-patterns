using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace Patterns.Configuration
{
	public class ConfigurationSource : IConfigurationSource
	{
		private readonly IConfigurationManager _configManager;
	    private readonly Func<System.Configuration.Configuration, IConfiguration> _configFactory;

	    public ConfigurationSource(IConfigurationManager configManager, Func<System.Configuration.Configuration, IConfiguration> configFactory)
		{
			_configManager = configManager;
		    _configFactory = configFactory;
		    NameValueCollection appSettings = _configManager.AppSettings;
			if(appSettings != null) AppSettings = appSettings.AllKeys.ToDictionary(key => key, key => appSettings[key]);
			var connectionStrings = _configManager.ConnectionStrings;
			if(connectionStrings != null) ConnectionStrings = connectionStrings.OfType<ConnectionStringSettings>().ToDictionary(settings => settings.Name, settings => settings);
		}

		public virtual IDictionary<string, string> AppSettings { get; private set; }

		public virtual IDictionary<string, ConnectionStringSettings> ConnectionStrings { get; private set; }

		public virtual ConfigurationSection GetSection(string sectionName)
		{
			return _configManager.GetSection(sectionName) as ConfigurationSection;
		}

		public virtual TSection GetSection<TSection>(string sectionName) where TSection : ConfigurationSection
		{
			return _configManager.GetSection(sectionName) as TSection;
		}

		public virtual IConfiguration OpenExeConfiguration(string exePath)
		{
            return _configFactory(_configManager.OpenExeConfiguration(exePath));
		}

		public virtual IConfiguration OpenExeConfiguration(ConfigurationUserLevel userLevel)
		{
            return _configFactory(_configManager.OpenExeConfiguration(userLevel));
		}

		public virtual IConfiguration OpenMachineConfiguration()
		{
            return _configFactory(_configManager.OpenMachineConfiguration());
		}

		public virtual IConfiguration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel)
		{
            return _configFactory(_configManager.OpenMappedExeConfiguration(fileMap, userLevel));
		}

		public virtual void RefreshSection(string sectionName)
		{
			_configManager.RefreshSection(sectionName);
		}
	}
}