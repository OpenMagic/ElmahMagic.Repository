using System.Collections.Generic;
using System.Linq;
using ElmahMagic.Repository.Helpers;
using ElmahMagic.Repository.Tests.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class ConvertAnIDictionaryToKeyValueCollectionSteps
    {
        private readonly GivenData _given;
        private IReadOnlyCollection<KeyValueItem>  _result;

        public ConvertAnIDictionaryToKeyValueCollectionSteps(GivenData given)
        {
            _given = given;
        }

        [Given(@"an IDictionary with values")]
        public void GivenAnIDictionaryWithValues(Table table)
        {
            _given.Dictionary = new Dictionary<string, object>();

            foreach (var row in table.Rows.Select(r => new KeyValueRow(r)))
            {
                _given.Dictionary.Add(row.Key, row.Value);
            }
        }

        [Given(@"an empty IDictionary")]
        public void GivenAnEmptyIDictionary()
        {
            _given.Dictionary = new Dictionary<string, object>();
        }

        [When(@"I call ToKeyValueCollection")]
        public void WhenICallToKeyValueCollection()
        {
            _result = _given.Dictionary != null 
                ? _given.Dictionary.ToKeyValueCollection() 
                : _given.NameValueCollection.ToKeyValueCollection();
        }

        [Then(@"a read only collection should be returned with KeyValueItem values")]
        public void ThenAReadOnlyCollectionShouldBeReturnedWithKeyValueItemValues(Table table)
        {
            var actualKeys = _result.Select(pair => pair.Key);
            var actualValues = _result.Select(pair => pair.Value);

            var expectedKeys = table.Rows.Select(row => row["Key"]);
            var expectedValues = table.Rows.Select(row => row["Value"]);

            actualKeys.ShouldAllBeEquivalentTo(expectedKeys);
            actualValues.ShouldAllBeEquivalentTo(expectedValues);
        }

        [Then(@"an empty read only collection should be returned")]
        public void ThenAnEmptyReadOnlyCollectionShouldBeReturned()
        {
            _result.Count.Should().Be(0);
        }
    }
}
