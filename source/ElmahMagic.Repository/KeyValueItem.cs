using System;
using System.Collections.Generic;
using System.Linq;
using ElmahMagic.Repository.Helpers.ValueFormatter;
using NullGuard;

namespace ElmahMagic.Repository
{
    public class KeyValueItem
    {
        private static readonly IValueFormatter[] ValueFormatters = GetValueFormatters();

        public KeyValueItem(string key, [AllowNull] object value)
        {
            Key = key;
            Value = FormatValue(value);
        }

        public string Key { get; }
        public object Value { [return: AllowNull] get; }

        private static IValueFormatter[] GetValueFormatters()
        {
            return new IValueFormatter[]
            {
                new NullValueFormatter(),
                new ObjectValueFormatter(),
                new DefaultValueFormatter()
            };
        }

        private static object FormatValue(object value)
        {
            var typeCode = value == null ? TypeCode.Empty : Type.GetTypeCode(value.GetType());
            var valueFormatter = ValueFormatters.First(formatter => formatter.CanFormat(typeCode, value));
            var formattedValue = valueFormatter.Format(typeCode, value);

            return formattedValue;
        }

        private static KeyValueItem[] FormatObject(object value)
        {
            return new[]
            {
                new KeyValueItem("type", value.GetType().ToString()),
                new KeyValueItem("properties", GetProperties(value))
            };
        }

        private static IEnumerable<KeyValueItem> GetProperties(object value)
        {
            return from propertyInfo in value.GetType().GetProperties()
                where propertyInfo.CanRead && !propertyInfo.GetMethod.GetParameters().Any()
                select new KeyValueItem(propertyInfo.Name, propertyInfo.GetValue(value));
        }
    }
}