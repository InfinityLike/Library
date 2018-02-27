using Library.ViewModels.Publication;

namespace Library.ViewModels.Brochure
{
    public class BrochureViewModel : PublicationViewModel
    {
        public string CoverType { get; set; }

        public int NumberOfPages { get; set; }
    }
}
