using Library.ViewModels.Publication;

namespace Library.ViewModels.Brochure
{
    public class GetBrochureViewItem : GetPublicationViewItem
    {
        public string CoverType { get; set; }

        public int NumberOfPages { get; set; }
    }
}
