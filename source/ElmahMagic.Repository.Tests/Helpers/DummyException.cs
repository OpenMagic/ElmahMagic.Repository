using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public class DummyException : Exception
    {
        private readonly IReadOnlyCollection<KeyValueItem> _data;

        public DummyException(string message):base(message)
        {
            _data = Random.Data;
        }

        public override IDictionary Data => _data.ToDictionary(d => d.Key, d=>d.Value);
    }
}