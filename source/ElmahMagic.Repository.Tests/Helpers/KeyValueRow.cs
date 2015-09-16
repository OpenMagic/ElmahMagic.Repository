using System;
using TechTalk.SpecFlow;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public class KeyValueRow
    {
        public KeyValueRow(TableRow tableRow)
        {
            Key = tableRow["Key"];
            Value = FormatValue(tableRow["Value"]);
        }

        public string Key { get; }
        public object Value { get; }

        private static object FormatValue(string value)
        {
            if (value == "new Exception(\"dummy exception\")")
            {
                return new Exception("dummy exception");
            }

            return value;
        }
    }
}