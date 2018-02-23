using System.Collections.Generic;

namespace Library.Entities.Models
{
    public class Book : Publication
    {
        public string Author { get; set; }

        public int YearOfPublishing { get; set; }
    }
}