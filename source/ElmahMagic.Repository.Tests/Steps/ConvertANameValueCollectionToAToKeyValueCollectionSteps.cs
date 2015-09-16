using System.Collections.Specialized;
using System.Linq;
using ElmahMagic.Repository.Tests.Helpers;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class ConvertANameValueCollectionToAToKeyValueCollectionSteps
    {
        private readonly GivenData _given;

        public ConvertANameValueCollectionToAToKeyValueCollectionSteps(GivenData given)
        {
            _given = given;
        }

        [Given(@"a NameValueCollection with values")]
        public void GivenANameValueCollectionWithValues(Table table)
        {
            _given.NameValueCollection = new NameValueCollection();

            foreach (var row in table.Rows.Select(r => new KeyValueRow(r)))
            {
                _given.NameValueCollection.Add(row.Key, row.Value.ToString());
            }
        }
        
        [Given(@"an empty NameValueCollection")]
        public void GivenAnEmptyNameValueCollection()
        {
            _given.NameValueCollection = new NameValueCollection();
        }
    }
}
