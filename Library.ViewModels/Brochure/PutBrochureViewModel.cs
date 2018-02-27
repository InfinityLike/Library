using Library.ViewModels.Publication;

namespace Library.ViewModels.Brochure
{
    public class PutBrochureViewModel : GetPublicationViewItem
    {
        public string CoverType { get; set; }

        public int NumberOfPages { get; set; }
    }
}