#region FreeBSD

// Copyright (c) 2013, The Tribe
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

using FizzWare.NBuilder;

using FluentAssertions;

using Patterns.Specifications.Models.Mapping;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Mapping
{
	[Binding]
	public class MappingSteps
	{
		private readonly MappingContext _context;

		public MappingSteps(MappingContext context)
		{
			_context = context;
		}

		[Given(@"I have a source object for mapping")]
		public void CreateSingleSourceObject()
		{
			_context.SingleSource = Builder<MappingSource>.CreateNew().Build();
		}

		[When(@"I map the object to a destination type")]
		public void MapToDestinationObject()
		{
			_context.SingleDestination = _context.MappingServices.Map<MappingDestination>(_context.SingleSource);
		}

		[Then(@"the original object should have the same values as the mapped object")]
		public void AssertSourceMatchesDestination()
		{
			_context.SingleDestination.Id.Should().Be(_context.SingleSource.Id);
			_context.SingleDestination.Data.Should().Be(_context.SingleSource.Data);
		}

		[Given(@"I have a source object collection with (.*) items for mapping")]
		public void CreateSourceObjectCollection(int count)
		{
			_context.MultiSource = Builder<MappingSource>.CreateListOfSize(count).Build();
		}

		[When(@"I map the collection to another type")]
		public void MapToDestinationCollection()
		{
			_context.MultiDestination = _context.MappingServices.Map<IList<MappingDestination>>(_context.MultiSource);
		}

		[Then(@"the mapped collection should have (.*) items")]
		public void AssertMappedCollectionCount(int count)
		{
			_context.MultiDestination.Should().HaveCount(count);
		}

		[Then(@"all of the original objects should have the same values as the mapped objects")]
		public void AssertSourceCollectionMatchesDestination()
		{
			_context.MultiDestination.Should().HaveSameCount(_context.MultiSource);

			for (int index = 0; index < _context.MultiDestination.Count; index ++)
			{
				_context.MultiDestination[index].Id.Should().Be(_context.MultiSource[index].Id);
				_context.MultiDestination[index].Data.Should().Be(_context.MultiSource[index].Data);
			}
		}
	}
}