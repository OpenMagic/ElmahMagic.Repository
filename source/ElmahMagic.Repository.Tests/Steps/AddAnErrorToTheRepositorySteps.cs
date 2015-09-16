using System;
using Elmah;
using ElmahMagic.Repository.Helpers;
using ElmahMagic.Repository.Tests.Helpers;
using FakeItEasy;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class AddAnErrorToTheRepositorySteps
    {
        private readonly GivenData _given;
        private string _actualErrorId;
        private int _callsToAddErrorAsync;

        public AddAnErrorToTheRepositorySteps(GivenData given)
        {
            _given = given;

            _given.Error = new Error(new Exception("dummy exception"));
            _given.ErrorId = Guid.NewGuid().ToString();

            _given.ErrorRepository = A.Fake<IErrorRepository>();

            A.CallTo(() => _given.ErrorRepository.AddErrorAsync(A<ErrorRecord>.That.Matches(errorRecord => errorRecord.IsEquivalentTo(_given.Error.ToErrorRecord()))))
                .Invokes(x => _callsToAddErrorAsync += 1)
                .Returns(_given.ErrorId);

            _given.ErrorLog = new RepositoryErrorLog(_given.ErrorRepository);
        }

        [Given(@"an error log has been created")]
        public void GivenAnErrorLogHasBeenCreated()
        {
            if (_given.ErrorLog == null)
            {
                throw new InvalidOperationException("Constructor of current test class must create the error log");
            }
        }

        [When(@"an error is passed to the error log")]
        public void WhenAnErrorIsPassedToTheErrorLog()
        {
            _actualErrorId = _given.ErrorLog.Log(_given.Error);
        }

        [Then(@"the error is added to the repository")]
        public void ThenTheErrorIsAddedToTheRepository()
        {
            _callsToAddErrorAsync.Should().Be(1);
        }

        [Then(@"the error id is returned")]
        public void ThenTheErrorIdIsReturned()
        {
            _actualErrorId.Should().Be(_given.ErrorId);
        }
    }
}