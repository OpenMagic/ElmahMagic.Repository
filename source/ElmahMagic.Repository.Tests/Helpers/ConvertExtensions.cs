using System;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public static class ConvertExtensions
    {
        public static object ConvertTo(this string value, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Char:
                    var intValue = int.Parse(value);
                    var charValue = (char)intValue;
                    return charValue;

                case TypeCode.DBNull:
                    return DBNull.Value;

                case TypeCode.Empty:
                    return null;

                default:
                    return System.Convert.ChangeType(value, typeCode);
            }
        }
    }
}
