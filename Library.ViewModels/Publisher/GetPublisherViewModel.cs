using System.Collections.Generic;

namespace Library.ViewModels.Publisher
{
    public class GetPublisherViewModel
    {
        public List<GetPublisherViewItem> Publishers { get; set; }

        public GetPublisherViewModel()
        {
            Publishers = new List<GetPublisherViewItem>();
        }
    }
}
