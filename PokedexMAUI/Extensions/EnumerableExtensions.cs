namespace PokedexMAUI.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Use this method to safely form a dictionary without checking for null source and without checking for duplicate keys. If there are duplicate keys the first one will be
        /// added and the others will be skipped.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionarySafe<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
            where TKey : notnull
        {
            var dict = new Dictionary<TKey, TValue>();
            if (source != null)
            {
                foreach (var item in source.Where(item => !dict.ContainsKey(keySelector.Invoke(item))))
                {
                    dict.Add(keySelector.Invoke(item), item);
                }
            }
            return dict;
        }
    }
}
