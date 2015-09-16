using System;

namespace ElmahMagic.Repository.Tests.Helpers
{
    public class SimpleObject
    {
        public SimpleObject()
        {
            FirstName = "Tim";
            LastName = "Murphy";
            DateOfBirth = new DateTime(1960, 1, 1);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
    }
}
