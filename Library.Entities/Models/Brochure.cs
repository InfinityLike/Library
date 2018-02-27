using Library.Entities.Enums;

namespace Library.Entities.Models
{
    public class Brochure : Publication
    {
        public BrochureCoverType CoverType { get; set; }

        public int NumberOfPages { get; set; }
    }
}
