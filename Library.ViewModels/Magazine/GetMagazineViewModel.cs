using System.Collections.Generic;

namespace Library.ViewModels.Magazine
{
    public class GetMagazineViewModel
    {
        public List<GetMagazineViewItem> Magazines { get; set; }

        public GetMagazineViewModel()
        {
            Magazines = new List<GetMagazineViewItem>();
        }
    }
}