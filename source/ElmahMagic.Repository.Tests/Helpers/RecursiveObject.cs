using System;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public class RecursiveObject : SimpleObject
    {
        public RecursiveObject()
        {
            Partner = new SimpleObject
            {
                FirstName = "Nicole",
                LastName = "Murphy",
                DateOfBirth = new DateTime(1970, 1, 1)
            };
        }

        public SimpleObject Partner { get; set; }
    }
}
