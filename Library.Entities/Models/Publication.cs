using Library.Entities.Enums;

namespace Library.Entities.Models
{
    public class Publication
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PublicationType PublicationType { get; set; }
    }
}