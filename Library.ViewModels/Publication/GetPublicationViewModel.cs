using System.Collections.Generic;

namespace Library.ViewModels.Publication
{
    public class GetPublicationViewModel
    {
        public List<GetPublicationViewItem> Publications { get; set; }

        public GetPublicationViewModel()
        {
            Publications = new List<GetPublicationViewItem>();
        }
    }
}