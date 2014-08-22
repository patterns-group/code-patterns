#region FreeBSD

// Copyright (c) 2014, John Batte
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