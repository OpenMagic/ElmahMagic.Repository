using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using FluentAssertions;

namespace ElmahMagic.Repository.Tests.Helpers
{
    // ReSharper disable once InconsistentNaming
    public static class IReadOnlyCollectionExtensions
    {
        public static void ShouldAllBeEquivalentTo(this IReadOnlyCollection<KeyValueItem> actual, NameValueCollection expected)
        {
            actual.Select(i => i.Key).ShouldAllBeEquivalentTo(expected.AllKeys);
            actual.Select(i => i.Value).ShouldAllBeEquivalentTo(expected.AllKeys.Select(key => expected[key]));
        }
    }
}