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
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Framework
{
	public static class Extensions
	{
		public static string NewKey(this ScenarioContext context)
		{
			if (context == null) return null;

			while (true)
			{
				string key = Guid.NewGuid().ToString("N");
				if (!context.ContainsKey(key)) return key;
			}
		}

		public static TValue SafeGet<TValue>(this ScenarioContext context, string key)
		{
			return context.ContainsKey(key) ? context[key] is TValue ? (TValue) context[key] : default(TValue) : default(TValue);
		}

		public static object GetDefault(this Type type)
		{
			MethodInfo factoryMethod = typeof (Extensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Where(x => x.Name.StartsWith("Default") && x.IsGenericMethod)
				.Select(x => x.GetGenericMethodDefinition().MakeGenericMethod(type))
				.FirstOrDefault();

			Debug.Assert(factoryMethod != null);

			return factoryMethod.Invoke(null, null);
		}

		public static TValue Default<TValue>()
		{
			return default(TValue);
		}

		public static TimeSpan GetDifference(this DateTime left, DateTime right)
		{
			var greater = new DateTime(Math.Max(left.Ticks, right.Ticks));
			var lesser = new DateTime(Math.Min(left.Ticks, right.Ticks));
			return greater - lesser;
		}
	}
}