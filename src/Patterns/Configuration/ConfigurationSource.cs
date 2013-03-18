#region FreeBSD

// Copyright (c) 2013, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that
// the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the
//    following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the
//    following disclaimer in the documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace Patterns.Configuration
{
	public class ConfigurationSource : IConfigurationSource
	{
		private readonly Func<System.Configuration.Configuration, IConfiguration> _configFactory;
		private readonly IConfigurationManager _configManager;

		public ConfigurationSource(IConfigurationManager configManager, Func<System.Configuration.Configuration, IConfiguration> configFactory)
		{
			_configManager = configManager;
			_configFactory = configFactory;
			NameValueCollection appSettings = _configManager.AppSettings;
			if (appSettings != null) AppSettings = appSettings.AllKeys.ToDictionary(key => key, key => appSettings[key]);
			ConnectionStringSettingsCollection connectionStrings = _configManager.ConnectionStrings;
			if (connectionStrings != null) ConnectionStrings = connectionStrings.OfType<ConnectionStringSettings>().ToDictionary(settings => settings.Name, settings => settings);
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