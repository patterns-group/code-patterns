using System.Collections.Generic;

namespace Patterns.Collections
{
	/// <summary>
	///    Defines a default implementation of the <see cref="IDictionaryValueRetriever{TKey,TValue}" /> interface.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	public class DictionaryValueRetriever<TKey, TValue> : IDictionaryValueRetriever<TKey, TValue>
	{
		private readonly IDictionary<TKey, TValue> _dictionary;
		private readonly bool _throwKeyNotFoundExceptions;

		/// <summary>
		///    Initializes a new instance of the <see cref="DictionaryValueRetriever{TKey, TValue}" /> class.
		/// </summary>
		/// <param name="dictionary">The dictionary.</param>
		/// <param name="throwKeyNotFoundExceptions">
		///    if set to <c>true</c>, throw KeyNotFoundExceptions for missing keys.
		/// </param>
		public DictionaryValueRetriever(IDictionary<TKey, TValue> dictionary, bool throwKeyNotFoundExceptions)
		{
			_dictionary = dictionary;
			_throwKeyNotFoundExceptions = throwKeyNotFoundExceptions;
		}

		/// <summary>
		///    Retrieves the value at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public TValue Retrieve(TKey key)
		{
			if (!_dictionary.ContainsKey(key))
			{
				if (_throwKeyNotFoundExceptions) throw new KeyNotFoundException();

				return default(TValue);
			}

			return _dictionary[key];
		}
	}
}