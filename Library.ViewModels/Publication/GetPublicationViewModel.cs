using System.Collections.Generic;

namespace Library.ViewModels.Publication
{
    public class GetPublicationViewModel
    {
        public List<PublicationViewModel> Publications { get; set; }

        public GetPublicationViewModel()
        {
            Publications = new List<PublicationViewModel>();
        }
    }
}