using System;
using System.Configuration;
using System.Runtime.Versioning;

namespace Patterns.Configuration
{
	public class ConfigurationWrapper : IConfiguration
	{
		private readonly System.Configuration.Configuration _config;

		public ConfigurationWrapper(System.Configuration.Configuration config)
		{
			_config = config;
		}

		public virtual AppSettingsSection AppSettings
		{
			get { return _config.AppSettings; }
		}

		public virtual ConnectionStringsSection ConnectionStrings
		{
			get { return _config.ConnectionStrings; }
		}

		public virtual string FilePath
		{
			get { return _config.FilePath; }
		}

		public virtual bool HasFile
		{
			get { return _config.HasFile; }
		}

		public virtual ConfigurationLocationCollection Locations
		{
			get { return _config.Locations; }
		}

		public virtual ContextInformation EvaluationContext
		{
			get { return _config.EvaluationContext; }
		}

		public virtual ConfigurationSectionGroup RootSectionGroup
		{
			get { return _config.RootSectionGroup; }
		}

		public virtual ConfigurationSectionCollection Sections
		{
			get { return _config.Sections; }
		}

		public virtual ConfigurationSectionGroupCollection SectionGroups
		{
			get { return _config.SectionGroups; }
		}

		public virtual bool NamespaceDeclared
		{
			get { return _config.NamespaceDeclared; }

			set { _config.NamespaceDeclared = value; }
		}

		public virtual Func<string, string> TypeStringTransformer
		{
			get { return _config.TypeStringTransformer; }

			set { _config.TypeStringTransformer = value; }
		}

		public virtual Func<string, string> AssemblyStringTransformer
		{
			get { return _config.AssemblyStringTransformer; }

			set { _config.AssemblyStringTransformer = value; }
		}

		public virtual FrameworkName TargetFramework
		{
			get { return _config.TargetFramework; }

			set { _config.TargetFramework = value; }
		}

		public virtual ConfigurationSection GetSection(string sectionName)
		{
			return _config.GetSection(sectionName);
		}

		public virtual ConfigurationSectionGroup GetSectionGroup(string sectionGroupName)
		{
			return _config.GetSectionGroup(sectionGroupName);
		}

		public virtual void Save()
		{
			_config.Save();
		}

		public virtual void Save(ConfigurationSaveMode saveMode)
		{
			_config.Save(saveMode);
		}

		public virtual void Save(ConfigurationSaveMode saveMode, bool forceSaveAll)
		{
			_config.Save(saveMode, forceSaveAll);
		}

		public virtual void SaveAs(string filename)
		{
			_config.SaveAs(filename);
		}

		public virtual void SaveAs(string filename, ConfigurationSaveMode saveMode)
		{
			_config.SaveAs(filename, saveMode);
		}

		public virtual void SaveAs(string filename, ConfigurationSaveMode saveMode, bool forceSaveAll)
		{
			_config.SaveAs(filename, saveMode, forceSaveAll);
		}
	}
}