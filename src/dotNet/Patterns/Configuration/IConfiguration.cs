using System;
using System.Configuration;
using System.Runtime.Versioning;

namespace Patterns.Configuration
{
	public interface IConfiguration
	{
		AppSettingsSection AppSettings { get; }

		ConnectionStringsSection ConnectionStrings { get; }

		string FilePath { get; }

		bool HasFile { get; }

		ConfigurationLocationCollection Locations { get; }

		ContextInformation EvaluationContext { get; }

		ConfigurationSectionGroup RootSectionGroup { get; }

		ConfigurationSectionCollection Sections { get; }

		ConfigurationSectionGroupCollection SectionGroups { get; }

		bool NamespaceDeclared { get; set; }

		Func<string, string> TypeStringTransformer { get; set; }

		Func<string, string> AssemblyStringTransformer { get; set; }

		FrameworkName TargetFramework { get; set; }

		ConfigurationSection GetSection(string sectionName);

		ConfigurationSectionGroup GetSectionGroup(string sectionGroupName);

		void Save();

		void Save(ConfigurationSaveMode saveMode);

		void Save(ConfigurationSaveMode saveMode, bool forceSaveAll);

		void SaveAs(string filename);

		void SaveAs(string filename, ConfigurationSaveMode saveMode);

		void SaveAs(string filename, ConfigurationSaveMode saveMode, bool forceSaveAll);
	}
}