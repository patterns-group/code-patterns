#region FreeBSD

// Copyright (c) 2013, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
// TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

using Patterns.Configuration;

namespace Patterns.Testing.Configuration
{
	/// <summary>
	///    Provides a configuration source that uses an in-memory configuration rather than a
	///    file-based one.
	/// </summary>
	public class TestConfigurationSource : IConfigurationSource
	{
		private readonly XContainer _configXml;

		/// <summary>
		///    Initializes a new instance of the <see cref="TestConfigurationSource" /> class.
		/// </summary>
		/// <param name="configXml">The config XML.</param>
		public TestConfigurationSource(XContainer configXml)
		{
			_configXml = configXml;
			var appSettings = GetSection<AppSettingsSection>("appSettings");
			if (appSettings != null)
			{
				AppSettings = appSettings.Settings.AllKeys
					.ToDictionary(key => key, key => appSettings.Settings[key].Value);
			}
			var connectionStrings = GetSection<ConnectionStringsSection>("connectionStrings");
			if (connectionStrings != null)
			{
				ConnectionStrings = connectionStrings.ConnectionStrings.OfType<ConnectionStringSettings>()
					.ToDictionary(settings => settings.Name, settings => settings);
			}
		}

		/// <summary>
		///    Gets the app settings.
		/// </summary>
		/// <value>
		///    The app settings.
		/// </value>
		public IDictionary<string, string> AppSettings { get; private set; }

		/// <summary>
		///    Gets the connection strings.
		/// </summary>
		/// <value>
		///    The connection strings.
		/// </value>
		public IDictionary<string, ConnectionStringSettings> ConnectionStrings { get; private set; }

		/// <summary>
		///    Gets the section.
		/// </summary>
		/// <param name="sectionName">Name of the section.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public ConfigurationSection GetSection(string sectionName)
		{
			return DeserializeSection(_configXml, sectionName);
		}

		/// <summary>
		///    Gets the section.
		/// </summary>
		/// <typeparam name="TSection">The type of the section.</typeparam>
		/// <param name="sectionName">Name of the section.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public TSection GetSection<TSection>(string sectionName) where TSection : ConfigurationSection, new()
		{
			return DeserializeSection<TSection>(_configXml, sectionName);
		}

		/// <summary>
		///    Opens the exe configuration.
		/// </summary>
		/// <param name="exePath">The exe path.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IConfiguration OpenExeConfiguration(string exePath)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		///    Opens the machine configuration.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IConfiguration OpenMachineConfiguration()
		{
			throw new NotSupportedException();
		}

		/// <summary>
		///    Refreshes the section.
		/// </summary>
		/// <param name="sectionName">Name of the section.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		public void RefreshSection(string sectionName) {}

		/// <summary>
		///    Opens the mapped exe configuration.
		/// </summary>
		/// <param name="fileMap">The file map.</param>
		/// <param name="userLevel">The user level.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IConfiguration OpenMappedExeConfiguration(ExeConfigurationFileMap fileMap, ConfigurationUserLevel userLevel)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		///    Opens the exe configuration.
		/// </summary>
		/// <param name="userLevel">The user level.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IConfiguration OpenExeConfiguration(ConfigurationUserLevel userLevel)
		{
			throw new NotSupportedException();
		}

		private static ConfigurationSection DeserializeSection(XContainer xml, string name)
		{
			XElement sectionDefinition = xml.Element("configSections")
				.Elements("section")
				.FirstOrDefault(section => section.Attribute("name").Value == name);

			if (sectionDefinition == null) return null;

			Type sectionType = Type.GetType(sectionDefinition.Attribute("type").Value, false);

			if (sectionType == null) return null;

			const BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
			MethodInfo genericFlavor = typeof (TestConfigurationSource).GetMethods(flags)
				.FirstOrDefault(method => method.Name == "DeserializeSection" && method.IsGenericMethod);

			MethodInfo typedGenericFlavor = genericFlavor.MakeGenericMethod(sectionType);

			try
			{
				return (ConfigurationSection) typedGenericFlavor.Invoke(null, new object[] {xml, name});
			}
			catch (TargetInvocationException error)
			{
				throw error.InnerException;
			}
		}

		private static TSection DeserializeSection<TSection>(XContainer xml, string name) where TSection : ConfigurationSection, new()
		{
			var config = new TSection();
			const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
			MethodInfo deserializer = typeof (TSection).GetMethod("DeserializeSection", flags);
			XElement sectionXml = xml.Element(name);
			if (sectionXml == null) return null;

			try
			{
				deserializer.Invoke(config, new object[] {sectionXml.CreateReader()});
			}
			catch (TargetInvocationException error)
			{
				throw error.InnerException;
			}

			return config;
		}
	}
}