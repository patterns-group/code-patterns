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

using Patterns.Runtime;
using Patterns.Specifications.Steps.Observations;
using Patterns.Testing.SpecFlow;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Factories
{
	[Binding]
	public class TimeFactory
	{
		private static readonly string _dateTimeInfoKey = ScenarioContext.Current.NewKey();

		public static IDateTimeInfo DateTimeInfo
		{
			get { return ScenarioContext.Current.GetValue<IDateTimeInfo>(_dateTimeInfoKey); }
			private set { ScenarioContext.Current[_dateTimeInfoKey] = value; }
		}

		[Given(@"I have a default DateTime abstraction")]
		public void CreateDefaultDateTimeInfo()
		{
			DateTimeInfo = new DefaultDateTimeInfo();
		}

		[Given(@"I have a primary DateTime value")]
		public void CreatePrimaryDateTime()
		{
			TimeObservations.PrimaryDateTime = new DateTime(1979, 8, 27, 23, 45, 32, 5);
		}

		[Given(@"I have a secondary DateTime value")]
		public void CreateSecondaryDateTime()
		{
			TimeObservations.SecondaryDateTime = new DateTime(1979, 8, 27, 23, 45, 32, 50);
		}
	}
}