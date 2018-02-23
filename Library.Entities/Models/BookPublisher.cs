namespace Library.Entities.Models
{
    public class BookPublisher
    {
        public int BookId { get; set; }
        public int PublisherId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
