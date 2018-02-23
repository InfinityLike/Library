namespace Library.Entities.Models
{
    public class Magazine : Publication
    {
        public int Number { get; set; }

        public int YearOfPublishing { get; set; }
    }
}