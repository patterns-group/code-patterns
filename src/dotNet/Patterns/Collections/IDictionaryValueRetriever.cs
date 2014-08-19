namespace Patterns.Collections
{
	/// <summary>
	///    Provides a proxy for dictionary value retrieval.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	public interface IDictionaryValueRetriever<in TKey, out TValue>
	{
		/// <summary>
		///    Retrieves the value at the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		TValue Retrieve(TKey key);
	}
}