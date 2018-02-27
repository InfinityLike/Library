using System;

namespace Library.Entities.Models
{
    public class Book : Publication
    {
        public DateTime DateOfPublishing { get; set; }
    }
}