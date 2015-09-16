using System.Collections.Generic;
using Elmah;
using ElmahMagic.Repository.Tests.Helpers;
using FakeItEasy;
using FakeItEasy.Core;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class GetPagesOfErrorsFromTheRepositorySteps
    {
        private readonly GivenData _given;
        private int _result;

        public GetPagesOfErrorsFromTheRepositorySteps(GivenData given)
        {
            _given = given;
            _given.ErrorRepository = A.Fake<IErrorRepository>();
            _given.ErrorLog = new RepositoryErrorLog(_given.ErrorRepository);
        }

        [Given(@"the error log has (.*) errors")]
        public void GivenTheErrorLogHasErrors(int givenTotalErrorCount)
        {
            _given.TotalErrorCount = givenTotalErrorCount;

            A.CallTo(() => _given.ErrorRepository.GetErrorsAsync(A<int>.Ignored, A<int>.Ignored, A<IDictionary<string, ErrorRecord>>.Ignored))
                .Invokes(GetFakeErrors)
                .Returns(givenTotalErrorCount);
        }

        [Given(@"the expectedErrorCount is (.*)")]
        public void GivenTheExpectedErrorCountIs(int givenExpectedErrorCount)
        {
            _given.ExpectedErrorCount = givenExpectedErrorCount;
        }

        private void GetFakeErrors(IFakeObjectCall obj)
        {
            var errors = (Dictionary<string, ErrorRecord>)obj.Arguments[2];

            for (var i = 0; i < _given.ExpectedErrorCount; i++)
            {
                errors.Add(i.ToString(), Random.ErrorRecord);
            }
        }

        [Given(@"the pageIndex is (.*)")]
        public void GivenThePageIndexIs(int givenPageIndex)
        {
            _given.PageIndex = givenPageIndex;
        }
        
        [Given(@"the pageSize is (.*)")]
        public void GivenThePageSizeIs(int givenPageSize)
        {
            _given.PageSize = givenPageSize;
        }
        
        [Given(@"the errorEntryList is empty")]
        public void GivenTheErrorEntryListIsEmpty()
        {
            _given.ErrorEntryList = new List<ErrorLogEntry>();
        }
        
        [When(@"GetErrors\((.*), (.*), errorEntryList\) is called")]
        public void WhenGetErrorsErrorEntryListIsCalled(int givenPageIndex, int givenPageSize)
        {
            _result = _given.ErrorLog.GetErrors(givenPageIndex, givenPageSize, _given.ErrorEntryList);
        }

        [Then(@"repository\.GetErrorsAsync\(pageIndex, pageSize, errors\) should be called")]
        public void ThenRepository_GetErrorsAsyncPageIndexPageSizeErrorsShouldBeCalled()
        {
            A.CallTo(() => _given.ErrorRepository.GetErrorsAsync(_given.PageIndex, _given.PageSize, A<IDictionary<string, ErrorRecord>>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        [Then(@"(.*) should be returned")]
        public void ThenShouldBeReturned(int expectedTotalErrorCount)
        {
            _result.Should().Be(expectedTotalErrorCount);
        }

        [Then(@"errorEntryList should be updated with (.*) ErrorLogEntry items")]
        public void ThenErrorEntryListShouldBeUpdatedWithErrorLogEntryItems(int expectedErrorCount)
        {
            _given.ErrorEntryList.Count.Should().Be(expectedErrorCount);
        }
    }
}
