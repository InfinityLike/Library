using System.Collections.Generic;

namespace Library.ViewModels.Publisher
{
    public class GetPublisherViewModel
    {
        public List<PublisherViewModel> Publishers { get; set; }

        public GetPublisherViewModel()
        {
            Publishers = new List<PublisherViewModel>();
        }
    }
}
