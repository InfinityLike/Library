using Library.ViewModels.Publication;

namespace Library.ViewModels.Brochure
{
    public class PostBrochureViewModel : GetPublicationViewItem
    {
        public string CoverType { get; set; }

        public int NumberOfPages { get; set; }
    }
}