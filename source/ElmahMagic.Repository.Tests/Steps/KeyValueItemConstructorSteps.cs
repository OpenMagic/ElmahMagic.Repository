using System;
using ElmahMagic.Repository.Tests.Helpers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Steps
{
    [Binding]
    public class KeyValueItemConstructorSteps
    {
        private readonly GivenData _given;
        private KeyValueItem _result;

        public KeyValueItemConstructorSteps(GivenData given)
        {
            _given = given;
        }

        [Given(@"key is (.*)")]
        public void GivenKeyIs(string key)
        {
            _given.Key = key;
        }

        [Given(@"value type code is (.*)")]
        public void GivenValueTypeCodeIs(string typeCode)
        {
            _given.TypeCode = (TypeCode) Enum.Parse(typeof (TypeCode), typeCode, true);
        }

        [Given(@"value is (.*)")]
        public void GivenValueIs(string value)
        {
            _given.Value = _given.TypeCode == TypeCode.Object
                ? Activator.CreateInstance(Type.GetType("ElmahMagic.Repository.Tests.Helpers." + value, true))
                : value.ConvertTo(_given.TypeCode);
        }

        [When(@"I call new KeyValueItem\(key, value\)")]
        public void WhenICallNewKeyValueItemKeyValue()
        {
            _result = new KeyValueItem(_given.Key, _given.Value);
        }

        [Then(@"the result should be a KeyValueItem object")]
        public void ThenTheResultShouldBeAKeyValueItemObject()
        {
            _result.Should().NotBeNull();
        }

        [Then(@"result\.Key should be (.*)")]
        public void ThenResult_KeyShouldBe(string expectedKey)
        {
            _given.Key.Should().Be(expectedKey);
        }

        [Then(@"result\.Value type code should be (.*)")]
        public void ThenResult_ValueTypeCodeShouldBe(string expectedValueTypeCode)
        {
            var actualTypeCode = _result.Value == null ? TypeCode.Empty : Type.GetTypeCode(_result.Value.GetType());

            actualTypeCode.Should().Be(_given.TypeCode);
        }

        [Then(@"result\.Value should be (.*)")]
        public void ThenResult_ValueShouldBe(string expectedValue)
        {
            switch (expectedValue)
            {
                case "SimpleObject":
                    ThenResult_ValueShouldBeObjectValue(
                        "ElmahMagic.Repository.Tests.Helpers.SimpleObject",
                        "{\"FirstName\":\"Tim\",\"LastName\":\"Murphy\",\"DateOfBirth\":\"1960-01-01T00:00:00\",\"Age\":55}");
                    break;

                case "RecursiveObject":
                    ThenResult_ValueShouldBeObjectValue(
                        "ElmahMagic.Repository.Tests.Helpers.RecursiveObject",
                        "{\"Partner\":{\"FirstName\":\"Nicole\",\"LastName\":\"Murphy\",\"DateOfBirth\":\"1970-01-01T00:00:00\",\"Age\":45},\"FirstName\":\"Tim\",\"LastName\":\"Murphy\",\"DateOfBirth\":\"1960-01-01T00:00:00\",\"Age\":55}");
                    break;

                default:
                    _result.Value.Should().Be(expectedValue.ConvertTo(_given.TypeCode));
                    break;
            }
        }

        private void ThenResult_ValueShouldBeObjectValue(string expectedType, string expectedValue)
        {
            var objectValue = _result.Value.Should().BeOfType<ObjectValue>().Subject;

            objectValue.Type.Should().Be(expectedType);
            objectValue.Value.Should().Be(expectedValue);
        }
    }
}