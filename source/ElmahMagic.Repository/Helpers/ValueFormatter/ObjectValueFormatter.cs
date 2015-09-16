using System;

namespace ElmahMagic.Repository.Helpers.ValueFormatter
{
    internal class ObjectValueFormatter : IValueFormatter
    {
        public bool CanFormat(TypeCode typeCode, object value)
        {
            return typeCode == TypeCode.Object;
        }

        public object Format(TypeCode typeCode, object value)
        {
            return new ObjectValue(value);
        }
    }
}