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

using FizzWare.NBuilder;

using FluentAssertions;

using Patterns.Collections;
using Patterns.Specifications.Models;
using Patterns.Specifications.Models.Collections;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Collections
{
	[Binding]
	public class ObjectCollectionSteps
	{
		private readonly CollectionContext _context;
		private readonly ErrorContext _errorContext;

		public ObjectCollectionSteps(CollectionContext context, ErrorContext errorContext)
		{
			_context = context;
			_errorContext = errorContext;
		}

		[Given(@"I have an empty object collection")]
		public void CreateEmptyObjectCollection()
		{
			_context.InitializeObjectCollection(0);
		}

		[Given(@"I have an object collection with (.*) items")]
		public void CreateObjectCollection(int itemCount)
		{
			_context.InitializeObjectCollection(itemCount);
		}

		[Given(@"I have a null object collection")]
		public void GivenIHaveANullObjectCollection()
		{
			_context.NullifyObjectCollection();
		}

		[When(@"I add (.*) items to the object collection using the AddRange extension")]
		public void AddRangeToObjectCollection(int itemCount)
		{
			IList<object> items = itemCount > 0 ? Builder<object>.CreateListOfSize(itemCount).Build() : new List<object>();

			try
			{
				_context.ObjectCollection.AddRange(items);
			}
			catch (Exception error)
			{
				_errorContext.LastError = error;
			}
		}

		[When(@"I add a null set to the object collection using the AddRange extension")]
		public void AddRangeNullSetToObjectCollection()
		{
			_context.ObjectCollection.AddRange(null);
		}

		[Then(@"the object collection should contain (.*) items")]
		public void AssertObjectCollectionCount(int count)
		{
			_context.ObjectCollection.Count.Should().Be(count);
		}

		[Then(@"the object collection should be null")]
		public void ThenTheCollectionShouldBeNull()
		{
			_context.ObjectCollection.Should().BeNull();
		}
	}
}