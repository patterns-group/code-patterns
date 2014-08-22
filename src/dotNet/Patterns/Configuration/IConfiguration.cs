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