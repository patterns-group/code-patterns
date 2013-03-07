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
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using AutoMapper;

using Patterns.ExceptionHandling;
using Patterns.Testing.Moq;

using TechTalk.SpecFlow;

namespace Patterns.Testing.SpecFlow
{
	public static class Mixins
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

		public static TObject CreateAndMapValues<TObject>(this Table table) where TObject : new()
		{
			var target = new TObject();
			table.MapValues(target);
			return target;
		}

		public static TObject MapValues<TObject>(this Table table, TObject target)
		{
			PropertyInfo[] properties = target.GetType().GetProperties();

			foreach (TableRow row in table.Rows)
			{
				string propertyName = row["name"];
				string propertyValue = row["value"];

				PropertyInfo property = properties.FirstOrDefault(item => item.Name == propertyName);

				if (property == null) continue;

				object actualValue = property.PropertyType != typeof (string)
					? Mapper.Map(propertyValue, typeof (string), property.PropertyType)
					: propertyValue;

				property.SetValue(target, actualValue, null);
			}

			return target;
		}

		public static TValue GetValue<TValue>(this ScenarioContext context, string key = null, Func<TValue> factory = null)
		{
			key = ResolveKey<TValue>(key);
			bool valueExists = context.ContainsKey(key);

			if (!valueExists && factory != null)
			{
				TValue value = factory();
				context[key] = value;
				return value;
			}

			factory = factory ?? (() => default(TValue));
			return valueExists ? Try.Get(() => context.Get<TValue>(key), exception => new ExceptionState(exception, true), factory) : factory();
		}

		public static object GetValue(this ScenarioContext context, string key, Func<object> factory = null)
		{
			bool valueExists = context.ContainsKey(key);

			if (!valueExists && factory != null)
			{
				object value = factory();
				context[key] = value;
				return value;
			}

			return valueExists ? Try.Get(() => context[key], exception => new ExceptionState(exception, true)) : null;
		}

		public static void SetValue<TValue>(this ScenarioContext context, TValue instance, string key = null)
		{
			key = ResolveKey<TValue>(key);
			context[key] = instance;
		}

		public static IMoqContainer GetContainer(this ScenarioContext context)
		{
			return context.GetValue<IMoqContainer>(factory: () => new MoqContainer());
		}

		private static string ResolveKey<TValue>(string key)
		{
			key = String.IsNullOrEmpty(key) ? typeof (TValue).AssemblyQualifiedName : key;
			Debug.Assert(key != null);
			return key;
		}
	}
}