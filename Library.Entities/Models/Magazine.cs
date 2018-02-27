using System;

namespace Library.Entities.Models
{
    public class Magazine : Publication
    {
        public int Number { get; set; }

        public DateTime DateOfPublishing { get; set; }
    }
}