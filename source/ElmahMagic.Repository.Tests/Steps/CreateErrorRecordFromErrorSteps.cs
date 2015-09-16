using Elmah;
using ElmahMagic.Repository.Helpers;
using ElmahMagic.Repository.Tests.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class CreateErrorRecordFromErrorSteps
    {
        private Error _givenError;
        private ErrorRecord _result;

        [Given(@"an ELMAH Error")]
        public void GivenAnELMAHError()
        {
            _givenError = Random.ElmahError;
        }
        
        [When(@"I call ToErrorRecord")]
        public void WhenICallToErrorRecord()
        {
            _result = _givenError.ToErrorRecord();
        }
        
        [Then(@"the result should be an ErrorRecord")]
        public void ThenTheResultShouldBeAnErrorRecord()
        {
            _result.Should().BeOfType<ErrorRecord>();
        }
        
        [Then(@"all public Error properties are copied to ErrorRecord")]
        public void ThenAllPublicErrorPropertiesAreCopiedToErrorRecord()
        {
            _result.ShouldBeEquivalentTo(
                 _givenError,
                 options => options
                     .Excluding(e => e.WhenUtc)
                     .Excluding(e => e.Data)
                     .Excluding(e => e.ServerVariables)
                     .Excluding(e => e.QueryString)
                     .Excluding(e => e.Form)
                     .Excluding(e => e.Cookies));

            _result.WhenUtc.Should().Be(_givenError.Time.ToUniversalTime());

            _result.Data.ShouldAllBeEquivalentTo(_givenError.Exception.Data);
            _result.ServerVariables.ShouldAllBeEquivalentTo(_givenError.ServerVariables);
            _result.QueryString.ShouldAllBeEquivalentTo(_givenError.QueryString);
            _result.Form.ShouldAllBeEquivalentTo(_givenError.Form);
            _result.Cookies.ShouldAllBeEquivalentTo(_givenError.Cookies);
        }
    }
}
