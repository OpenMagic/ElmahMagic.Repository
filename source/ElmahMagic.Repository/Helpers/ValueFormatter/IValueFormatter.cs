using System;

namespace ElmahMagic.Repository.Helpers.ValueFormatter
{
    internal interface IValueFormatter
    {
        bool CanFormat(TypeCode typeCode, object value);
        object Format(TypeCode typeCode, object value);
    }
}