using System;

namespace ElmahMagic.Repository.Helpers.ValueFormatter
{
    internal class DefaultValueFormatter : IValueFormatter
    {
        public bool CanFormat(TypeCode typeCode, object value)
        {
            return typeCode != TypeCode.Empty && typeCode != TypeCode.Object;
        }

        public object Format(TypeCode typeCode, object value)
        {
            return value;
        }
    }
}