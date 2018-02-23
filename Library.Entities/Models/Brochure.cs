using Library.Entities.Enums;

namespace Library.Entities.Models
{
    public class Brochure : Publication
    {
        public TypeOfCover TypeOfCover { get; set; }

        public int NumberOfPages { get; set; }
    }
}
