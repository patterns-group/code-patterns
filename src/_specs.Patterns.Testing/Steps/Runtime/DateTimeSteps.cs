#region New BSD License

// Copyright (c) 2012, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions
// and the following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions
// and the following disclaimer in the documentation and/or other materials provided with the distribution.
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

using FluentAssertions;

using Patterns.Runtime;
using Patterns.Specifications.Common;
using Patterns.Testing.Runtime;

using TechTalk.SpecFlow;

namespace _specs.Patterns.Testing.Steps.Runtime
{
	[Binding]
	public class DateTimeSteps
	{
		public static readonly DateTime StaticTime = DateTime.Now.AddDays(1);
		private static readonly string _dateTimeInfoKey = ScenarioContext.Current.NewKey();
		private static readonly string _getNowResultKey = ScenarioContext.Current.NewKey();

		public static IDateTimeInfo DateTimeInfo
		{
			get { return ScenarioContext.Current.SafeGet<IDateTimeInfo>(_dateTimeInfoKey); }
			set { ScenarioContext.Current[_dateTimeInfoKey] = value; }
		}

		public static DateTime GetNowResult
		{
			get { return ScenarioContext.Current.SafeGet<DateTime>(_getNowResultKey); }
			set { ScenarioContext.Current[_getNowResultKey] = value; }
		}

		[Given(@"I have a DateTime info provider for testing")]
		public void CreateDateTimeInfo()
		{
			DateTimeInfo = new TestDateTimeInfo();
		}

		[Given(@"I have configured the test DateTime info provider to use a static time")]
		public void UseStaticTime()
		{
			var info = (TestDateTimeInfo) DateTimeInfo;
			info.SetAlways(StaticTime);
		}

		[When(@"I store the return value of the DateTime info provider's ""GetNow"" method")]
		public void StoreGetNowResult()
		{
			GetNowResult = DateTimeInfo.GetNow();
		}

		[Then(@"the stored DateTime value should be equal to the static time I used")]
		public void VerifyGetNowResultEqualsStaticTime()
		{
			GetNowResult.Should().Be(StaticTime);
		}
	}
}