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

using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using FluentAssertions;

using Patterns.Reflection;
using Patterns.Testing.SpecFlow;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Reflection
{
	[Binding]
	[Scope(Feature = "GetPropertyValues for objects")]
	public class GetPropertyValuesSteps
	{
		private const string _objectKey = "GetPropertyValues::Target";
		private const string _resultKey = "GetPropertyValues::Result";

		[Given(@"my object is an integer with the value (.*)")]
		public void SetObjectValue(int value)
		{
			ScenarioContext.Current[_objectKey] = value;
		}

		[When(@"I get the property values of my object")]
		public void GetPropertyValues()
		{
			object value = ScenarioContext.Current.GetValue(_objectKey);
			ScenarioContext.Current[_resultKey] = value.GetPropertyValues();
		}

		[Then(@"the property values should be empty")]
		public void AssertEmptyPropertyValues()
		{
			var actualValues = ScenarioContext.Current.GetValue<IEnumerable<PropertyValue>>(_resultKey);
			actualValues.Should().NotBeNull();
			actualValues.Should().BeEmpty();
		}

		[Given(@"my object is a test object with the following values:")]
		public void CreateTestObject(Table values)
		{
			ScenarioContext.Current[_objectKey] = values.CreateAndMapValues<TestClass>();
		}

		[Then(@"the property values should be equivalent to:")]
		public void AssertPropertyValues(Table values)
		{
			var actualValues = ScenarioContext.Current.GetValue<IEnumerable<PropertyValue>>(_resultKey);
			actualValues.Should().NotBeNull();

			PropertyValue[] actualValueArray = actualValues.ToArray();
			actualValueArray.Length.Should().Be(values.RowCount);

			foreach (PropertyValue property in actualValueArray)
			{
				property.Should().NotBeNull();

				string expected = values.Rows
					.Where(row => row["name"] == property.Name)
					.Select(row => row["value"])
					.FirstOrDefault();

				object expectedValue = Mapper.Map(expected, typeof (string), property.Value.GetType());
				property.Value.Should().Be(expectedValue);
			}
		}

		// ReSharper disable UnusedMember.Local

		private class TestClass
		{
			public int Id { get; set; }
			public string Data { get; set; }
		}

		// ReSharper restore UnusedMember.Local
	}
}