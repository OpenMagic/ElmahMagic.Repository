using Elmah;
using ElmahMagic.Repository.Helpers;
using ElmahMagic.Repository.Tests.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class CreateErrorFromErrorRecordSteps
    {
        private ErrorRecord _givenErrorRecord;
        private Error _result;

        [Given(@"an ErrorRecord")]
        public void GivenAnErrorRecord()
        {
            _givenErrorRecord = Random.ErrorRecord;
        }

        [When(@"I call ToError")]
        public void WhenICallToError()
        {
            _result = _givenErrorRecord.ToError();
        }

        [Then(@"the result should be an ELMAH Error")]
        public void ThenTheResultShouldBeAnELMAHError()
        {
            _result.Should().BeOfType<Error>();
        }

        [Then(@"all public ErrorRecord properties are copied to Error")]
        public void ThenAllPublicErrorRecordPropertiesAreCopiedToError()
        {
            _result.ShouldBeEquivalentTo(
                _givenErrorRecord,
                options => options
                    .Excluding(e => e.Exception)
                    .Excluding(e => e.Time)
                    .Excluding(e => e.ServerVariables)
                    .Excluding(e => e.QueryString)
                    .Excluding(e => e.Form)
                    .Excluding(e => e.Cookies));

            _result.Time.Should().Be(_givenErrorRecord.WhenUtc);

            _result.ServerVariables.ShouldAllBeEquivalentTo(_givenErrorRecord.ServerVariables);
            _result.QueryString.ShouldAllBeEquivalentTo(_givenErrorRecord.QueryString);
            _result.Form.ShouldAllBeEquivalentTo(_givenErrorRecord.Form);
            _result.Cookies.ShouldAllBeEquivalentTo(_givenErrorRecord.Cookies);
        }
    }
}