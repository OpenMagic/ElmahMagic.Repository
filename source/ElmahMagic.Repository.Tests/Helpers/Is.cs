using System;
using FluentAssertions;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public static class Is
    {
        public static bool IsEquivalentTo<T>(this T objA, T objB)
        {
            try
            {
                objA.ShouldBeEquivalentTo(objB);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
