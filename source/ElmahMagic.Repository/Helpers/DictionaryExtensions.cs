using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace ElmahMagic.Repository.Helpers
{
    public static class DictionaryExtensions
    {
        public static IReadOnlyCollection<KeyValueItem> ToKeyValueCollection(this NameValueCollection collection)
        {
            return new ReadOnlyCollection<KeyValueItem>(collection.ToKeyValueList());
        }

        public static IReadOnlyCollection<KeyValueItem> ToKeyValueCollection(this IDictionary dictionary)
        {
            return new ReadOnlyCollection<KeyValueItem>(dictionary.ToKeyValueList());
        }

        private static IList<KeyValueItem> ToKeyValueList(this NameValueCollection collection)
        {
            var query =
                from key in collection.AllKeys
                select new KeyValueItem(key, collection[key]);

            return query.ToList();
        }

        private static IList<KeyValueItem> ToKeyValueList(this IDictionary dictionary)
        {
            var query =
                from object key in dictionary.Keys
                select new KeyValueItem(key.ToString(), dictionary[key]);

            return query.ToList();
        }
    }
}