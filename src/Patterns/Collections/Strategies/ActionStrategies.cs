using System;
using System.Collections.Generic;

namespace Patterns.Collections.Strategies
{
	#region Action

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	public class ActionStrategies<TKey> : Dictionary<TKey, Action>
	{
		private readonly IDictionaryValueRetriever<TKey, Action> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual void Execute(TKey key)
		{
			Action strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy();
		}
	}

	#endregion

	#region Action<TIn>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn">The type of the action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn> : Dictionary<TKey, Action<TIn>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual void Execute(TKey key, TIn input)
		{
			Action<TIn> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(input);
		}
	}

	#endregion

	#region Action<TIn1, TIn2>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2> : Dictionary<TKey, Action<TIn1, TIn2>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2)
		{
			Action<TIn1, TIn2> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3> : Dictionary<TKey, Action<TIn1, TIn2, TIn3>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3>>(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3)
		{
			Action<TIn1, TIn2, TIn3> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4> : Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4)
		{
			Action<TIn1, TIn2, TIn3, TIn4> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="parameter1">The first parameter.</param>
		/// <param name="parameter2">The second parameter.</param>
		/// <param name="parameter3">The third parameter.</param>
		/// <param name="parameter4">The fourth parameter.</param>
		/// <param name="parameter5">The fifth parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>>(this,
				throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>>(
				this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever = new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>>(
				this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>>
	{
		private readonly IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>>
	{
		private readonly
			IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>>(this,
					throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9, parameter10);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth action parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>>
	{
		private readonly
			IDictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9, parameter10, parameter11);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth action parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh action parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12> :
		Dictionary<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11, TIn12 parameter12)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9, parameter10, parameter11, parameter12);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth action parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh action parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth action parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13> :
											 Dictionary
												 <TKey,
												 Action
												 <TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>> _valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11, TIn12 parameter12, TIn13 parameter13)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth action parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh action parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth action parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth action parameter.</typeparam>
	/// <typeparam name="TIn14">The type of the fourteenth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13,
										 TIn14> :
											 Dictionary
												 <TKey,
												 Action
												 <TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>>(this,
						throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6, TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10,
			TIn11 parameter11, TIn12 parameter12, TIn13 parameter13, TIn14 parameter14)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth action parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh action parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth action parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth action parameter.</typeparam>
	/// <typeparam name="TIn14">The type of the fourteenth action parameter.</typeparam>
	/// <typeparam name="TIn15">The type of the fifteenth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13,
										 TIn14, TIn15>
		:
			Dictionary
				<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey, Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>>(
					this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6,
			TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10, TIn11 parameter11, TIn12 parameter12,
			TIn13 parameter13, TIn14 parameter14, TIn15 parameter15)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14,
							 parameter15);
		}
	}

	#endregion

	#region Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>

	/// <summary>
	///    Defines a strategy dictionary; that is, a dictionary of actions.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TIn1">The type of the first action parameter.</typeparam>
	/// <typeparam name="TIn2">The type of the second action parameter.</typeparam>
	/// <typeparam name="TIn3">The type of the third action parameter.</typeparam>
	/// <typeparam name="TIn4">The type of the fourth action parameter.</typeparam>
	/// <typeparam name="TIn5">The type of the fifth action parameter.</typeparam>
	/// <typeparam name="TIn6">The type of the sixth action parameter.</typeparam>
	/// <typeparam name="TIn7">The type of the seventh action parameter.</typeparam>
	/// <typeparam name="TIn8">The type of the eighth action parameter.</typeparam>
	/// <typeparam name="TIn9">The type of the ninth action parameter.</typeparam>
	/// <typeparam name="TIn10">The type of the tenth action parameter.</typeparam>
	/// <typeparam name="TIn11">The type of the eleventh action parameter.</typeparam>
	/// <typeparam name="TIn12">The type of the twelfth action parameter.</typeparam>
	/// <typeparam name="TIn13">The type of the thirteenth action parameter.</typeparam>
	/// <typeparam name="TIn14">The type of the fourteenth action parameter.</typeparam>
	/// <typeparam name="TIn15">The type of the fifteenth action parameter.</typeparam>
	/// <typeparam name="TIn16">The type of the sixteenth action parameter.</typeparam>
	public class ActionStrategies<TKey, TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13,
										 TIn14, TIn15, TIn16>
		:
			Dictionary
				<TKey,
				Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>>
	{
		private readonly
			IDictionaryValueRetriever
				<TKey,
					Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>>
			_valueRetriever;

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(bool throwKeyNotFoundExceptions = false)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey,
						Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>>
					(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Initializes a new instance of the <see cref="Patterns.Collections.Strategies.ActionStrategies{TKey}" /> class.
		/// </summary>
		/// <param name="keyComparer">The key comparer.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public ActionStrategies(IEqualityComparer<TKey> keyComparer, bool throwKeyNotFoundExceptions = false)
			: base(keyComparer)
		{
			_valueRetriever =
				new DictionaryValueRetriever
					<TKey,
						Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>>
					(this, throwKeyNotFoundExceptions);
		}

		/// <summary>
		///    Executes the action at the specified key.
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
		public virtual void Execute(TKey key, TIn1 parameter1, TIn2 parameter2, TIn3 parameter3, TIn4 parameter4,
			TIn5 parameter5, TIn6 parameter6,
			TIn7 parameter7, TIn8 parameter8, TIn9 parameter9, TIn10 parameter10, TIn11 parameter11, TIn12 parameter12,
			TIn13 parameter13, TIn14 parameter14, TIn15 parameter15, TIn16 parameter16)
		{
			Action<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16> strategy = _valueRetriever.Retrieve(key);
			if (strategy != null) strategy(parameter1, parameter2, parameter3, parameter4, parameter5, parameter6,
							 parameter7, parameter8, parameter9, parameter10, parameter11, parameter12, parameter13, parameter14,
							 parameter15,
							 parameter16);
		}
	}

	#endregion
}