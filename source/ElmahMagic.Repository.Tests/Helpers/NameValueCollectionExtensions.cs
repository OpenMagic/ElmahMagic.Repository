using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using FluentAssertions;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public static class NameValueCollectionExtensions
    {
        public static void ShouldAllBeEquivalentTo(this NameValueCollection actual, IReadOnlyCollection<KeyValueItem> expected)
        {
            actual.AllKeys.ShouldAllBeEquivalentTo(expected.Select(e => e.Key));
            actual.AllKeys.Select(a => actual[a]).ShouldAllBeEquivalentTo(expected.Select(e => e.Value));
        }
    }
}
