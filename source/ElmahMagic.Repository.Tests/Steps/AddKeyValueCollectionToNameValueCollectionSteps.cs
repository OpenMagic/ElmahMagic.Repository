using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using ElmahMagic.Repository.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class AddKeyValueCollectionToNameValueCollectionSteps
    {
        private ReadOnlyCollection<KeyValueItem> _givenKeyValueCollection;
        private NameValueCollection _result;

        [Given(@"a KeyValueCollection with values:")]
        public void GivenAKeyValueCollectionWithValues(Table table)
        {
            _givenKeyValueCollection = new ReadOnlyCollection<KeyValueItem>(
                table.Rows.Select(tableRow => new KeyValueItem(tableRow["Key"], tableRow["Value"])).ToList());
        }

        [Given(@"an empty KeyValueCollection")]
        public void GivenAnEmptyKeyValueCollection()
        {
            _givenKeyValueCollection = new ReadOnlyCollection<KeyValueItem>(Enumerable.Empty<KeyValueItem>().ToList());
        }

        [When(@"I call AddKeyValueCollection")]
        public void WhenICallAddKeyValueCollection()
        {
            _result = new NameValueCollection();
            _result.AddKeyValueCollection(_givenKeyValueCollection);
        }

        [Then(@"the NameValueCollection should be:")]
        public void ThenTheNameValueCollectionShouldBe(Table table)
        {
            _result.AllKeys.ShouldAllBeEquivalentTo(table.Rows.Select(row => row["Key"]));
            _result.AllKeys.Select(a => _result[a]).ShouldAllBeEquivalentTo(table.Rows.Select(row => row["Value"]));
        }

        [Then(@"the NameValueCollection should be empty")]
        public void ThenTheNameValueCollectionShouldBeEmpty()
        {
            _result.Count.Should().Be(0);
        }
    }
}
