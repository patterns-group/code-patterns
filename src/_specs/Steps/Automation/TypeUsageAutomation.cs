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

using Patterns.ExceptionHandling;
using Patterns.Specifications.Steps.Factories;
using Patterns.Specifications.Steps.Observations;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Automation
{
	[Binding]
	public class TypeUsageAutomation
	{
		public const string Start = "abracadabra";
		public const string Finish = "arbadacarba";
		public const string PropertyWriteValue = "the dog jumped over the fence";

		[When(@"I try to write to a property value that throws an exception on the subject")]
		public void WriteAngryProperty()
		{
			Try.Do(() => TestSubjectFactory.TestySubject.AngryProperty = PropertyWriteValue);
		}

		[When(@"I try to write to a property value on the subject")]
		public void WriteProperty()
		{
			Try.Do(() => TestSubjectFactory.TestySubject.Property = PropertyWriteValue);
		}

		[When(@"I try to call a method that throws an exception on the subject")]
		public void CallAngryMethod()
		{
			TestObservations.CallResult = Try.Get(() => TestSubjectFactory.TestySubject.AngryReverseText(Start));
		}

		[When(@"I try to read a value that throws an exception from the subject")]
		public void ReadAngryProperty()
		{
			TestObservations.CallResult = Try.Get(() => TestSubjectFactory.TestySubject.AngryProperty);
		}

		[When(@"I try to call a method on the subject")]
		public void CallMethod()
		{
			TestObservations.CallResult = Try.Get(() => TestSubjectFactory.TestySubject.ReverseText(Start));
		}

		[When(@"I try to read a property value from the subject")]
		public void ReadProperty()
		{
			TestObservations.CallResult = Try.Get(() => TestSubjectFactory.TestySubject.Property);
		}
	}
}