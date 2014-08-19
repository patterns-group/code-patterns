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

using System.Linq;

using AutoMapper;

using FluentAssertions;

using Patterns.Reflection;
using Patterns.Specifications.Models;
using Patterns.Specifications.Models.Reflection;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Patterns.Specifications.Steps.Reflection
{
	[Binding]
	public class PropertyValueSteps
	{
		private readonly ObjectContext _objectContext;
		private readonly PropertyValueContext _valueContext;

		public PropertyValueSteps(ObjectContext objectContext, PropertyValueContext valueContext)
		{
			_objectContext = objectContext;
			_valueContext = valueContext;
		}

		[Given(@"my object is a test object with the following values:")]
		public void CreateTestObject(Table values)
		{
			_objectContext.Target = values.CreateInstance<PropertyValueTestSubject>();
		}

		[When(@"I get the property values of my object")]
		public void GetPropertyValues()
		{
			_valueContext.Values = _objectContext.Target.GetPropertyValues();
		}

		[Then(@"the property values should be equivalent to:")]
		public void AssertPropertyValues(Table values)
		{
			PropertyValue[] actualValues = _valueContext.Values.ToArray();
			actualValues.Length.Should().Be(values.RowCount);

			foreach (PropertyValue property in actualValues)
			{
				property.Should().NotBeNull();

				string expectedText = values.Rows
					.Where(row => row["name"] == property.Name)
					.Select(row => row["value"])
					.FirstOrDefault();

				object expected = Mapper.Map(expectedText, typeof (string), property.Value.GetType());

				property.Value.Should().Be(expected);
			}
		}

		[Then(@"the property values should be empty")]
		public void AssertEmptyPropertyValues()
		{
			_valueContext.Values.Should().BeEmpty();
		}
	}
}