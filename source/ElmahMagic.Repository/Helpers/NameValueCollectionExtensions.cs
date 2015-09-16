using System.Collections.Generic;
using System.Collections.Specialized;

namespace ElmahMagic.Repository.Helpers
{
    public static class NameValueCollectionExtensions
    {
        public static void AddKeyValueCollection(this NameValueCollection nameValueCollection, IReadOnlyCollection<KeyValueItem> keyValueCollection)
        {
            foreach (var keyValueItem in keyValueCollection)
            {
                nameValueCollection.Add(keyValueItem.Key, keyValueItem.Value.ToString());
            }
        }
    }
}
