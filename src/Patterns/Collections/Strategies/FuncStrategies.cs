using System;
using System.Collections.Generic;

namespace Patterns.Collections.Strategies
{
	#region Func<TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TOut> : Dictionary<TKey, Func<TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key)
		{
			Func<TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null ? default(TOut) : retrieve();
		}
	}

	#endregion

	#region Func<TIn, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn">The type of the function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn, TOut> : Dictionary<TKey, Func<TIn, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn, TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn, TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn input)
		{
			Func<TIn, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null ? default(TOut) : retrieve(input);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TOut> : Dictionary<TKey, Func<TIn1, TIn2, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2)
		{
			Func<TIn1, TIn2, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null ? default(TOut) : retrieve(parameter1, parameter2);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TOut> : Dictionary<TKey, Func<TIn1, TIn2, TIn3, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TOut>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
		{
			Func<TIn1, TIn2, TIn3, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null ? default(TOut) : retrieve(parameter1, parameter2, parameter3);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TOut> : Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null ? default(TOut) : retrieve(parameter1, parameter2, parameter3, parameter4);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null ? default(TOut) : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null ? default(TOut) : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>>(
				this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>>(
				this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>>
	{
		private readonly IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>>
	{
		private readonly
			IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <param name="parameter10">The tenth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9, parameter10);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth function parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>>
	{
		private readonly
			IDictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <param name="parameter10">The tenth parameter.</param>
		/// <param name="parameter11">The eleventh parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9, parameter10, parameter11);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth function parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh function parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut> :
		Dictionary<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <param name="parameter10">The tenth parameter.</param>
		/// <param name="parameter11">The eleventh parameter.</param>
		/// <param name="parameter12">The twelfth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11, TIn12 parameter12)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9, parameter10, parameter11, parameter12);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth function parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh function parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth function parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13,
	                            TOut> :
		                            Dictionary
			                            <TKey,
			                            Func
			                            <TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <param name="parameter10">The tenth parameter.</param>
		/// <param name="parameter11">The eleventh parameter.</param>
		/// <param name="parameter12">The twelfth parameter.</param>
		/// <param name="parameter13">The thirteenth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11, TIn12 parameter12, TIn13 parameter13)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth function parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh function parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth function parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth function parameter.</typeparam>
	/// <typeparam name="TIn14">The type of the fourteenth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13,
	                            TIn14, TOut> :
		                            Dictionary
			                            <TKey,
			                            Func
			                            <TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14,
			                            TOut>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <param name="parameter10">The tenth parameter.</param>
		/// <param name="parameter11">The eleventh parameter.</param>
		/// <param name="parameter12">The twelfth parameter.</param>
		/// <param name="parameter13">The thirteenth parameter.</param>
		/// <param name="parameter14">The fourteenth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11, TIn12 parameter12, TIn13 parameter13, TIn14 parameter14)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth function parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh function parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth function parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth function parameter.</typeparam>
	/// <typeparam name="TIn14">The type of the fourteenth function parameter.</typeparam>
	/// <typeparam name="TIn15">The type of the fifteenth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13,
	                            TIn14, TIn15, TOut>
		:
			Dictionary
				<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <param name="parameter10">The tenth parameter.</param>
		/// <param name="parameter11">The eleventh parameter.</param>
		/// <param name="parameter12">The twelfth parameter.</param>
		/// <param name="parameter13">The thirteenth parameter.</param>
		/// <param name="parameter14">The fourteenth parameter.</param>
		/// <param name="parameter15">The fifteenth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6,
			TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10, TIn11 parameter11, TIn12 parameter12,
			TIn13 parameter13, TIn14 parameter14, TIn15 parameter15)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14,
					       parameter15);
		}
	}

	#endregion

	#region Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of functions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first function parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second function parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third function parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth function parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth function parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth function parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh function parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth function parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth function parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth function parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh function parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth function parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth function parameter.</typeparam>
	/// <typeparam name="TIn14">The type of the fourteenth function parameter.</typeparam>
	/// <typeparam name="TIn15">The type of the fifteenth function parameter.</typeparam>
	/// <typeparam name="TIn16">The type of the sixteenth function parameter.</typeparam>
	/// <typeparam name="TOut">The return type of the function.</typeparam>
	public class FuncStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13,
	                            TIn14, TIn15, TIn16, TOut>
		:
			Dictionary
				<TKey,
				Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey,
					Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey,
						Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>>
					(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="FuncStrategies{TKey, TOut}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public FuncStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey,
						Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut>>
					(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the function at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <param name="parameter6">The sixth parameter.</param>
		/// <param name="parameter7">The seventh parameter.</param>
		/// <param name="parameter8">The eighth parameter.</param>
		/// <param name="parameter9">The ninth parameter.</param>
		/// <param name="parameter10">The tenth parameter.</param>
		/// <param name="parameter11">The eleventh parameter.</param>
		/// <param name="parameter12">The twelfth parameter.</param>
		/// <param name="parameter13">The thirteenth parameter.</param>
		/// <param name="parameter14">The fourteenth parameter.</param>
		/// <param name="parameter15">The fifteenth parameter.</param>
		/// <param name="parameter16">The sixteenth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual TOut Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6,
			TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10, TIn11 parameter11, TIn12 parameter12,
			TIn13 parameter13, TIn14 parameter14, TIn15 parameter15, TIn16 parameter16)
		{
			Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, TOut> retrieve = _valueRetriever.Retrieve(key);
			return retrieve == null
				       ? default(TOut)
				       : retrieve(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
					       parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14,
					       parameter15,
					       parameter16);
		}
	}

	#endregion
}