using System.Threading.Tasks;
using Elmah;
using ElmahMagic.Repository.Tests.Helpers;
using FakeItEasy;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class GetAnErrorFromTheRepositorySteps
    {
        private readonly GivenData _given;
        private ErrorLogEntry _result;

        public GetAnErrorFromTheRepositorySteps(GivenData given)
        {
            _given = given;
            _given.ErrorRepository = A.Fake<IErrorRepository>();
            _given.ErrorLog = new RepositoryErrorLog(_given.ErrorRepository);
        }

        [Given(@"the error log has multiple errors")]
        public void GivenTheErrorLogHasMultipleErrors()
        {
            // nothing to do we can using a fake repository
        }

        [Given(@"the id of an error in the error log")]
        public void GivenTheIdOfAnErrorInTheErrorLog()
        {
            var taskWithFakeErrorRecord = Task.FromResult(A.Fake<ErrorRecord>());

            A.CallTo(() => _given.ErrorRepository.GetErrorAsync(A<string>.Ignored))
                .Returns(taskWithFakeErrorRecord);
        }

        [Given(@"the id of an error that is not in the error log")]
        public void GivenTheIdOfAnErrorThatIsNotInTheErrorLog()
        {
            var taskWithNullErrorRecord = Task.FromResult<ErrorRecord>(null);

            A.CallTo(() => _given.ErrorRepository.GetErrorAsync(A<string>.Ignored))
                .Returns(taskWithNullErrorRecord);
        }

        [When(@"GetError\(id\) is called")]
        public void WhenGetErrorIdIsCalled()
        {
            _result = _given.ErrorLog.GetError("dummy id");
        }

        [Then(@"the error for the given id should be returned")]
        public void ThenTheErrorForTheGivenIdShouldBeReturned()
        {
            _result.Should().NotBeNull();
        }

        [Then(@"a null error should be returned")]
        public void ThenANullErrorShouldBeReturned()
        {
            _result.Should().BeNull();
        }
    }
}