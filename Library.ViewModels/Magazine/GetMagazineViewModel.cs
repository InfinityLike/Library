using System.Collections.Generic;

namespace Library.ViewModels.Magazine
{
    public class GetMagazineViewModel
    {
        public List<MagazineViewModel> Magazines { get; set; }

        public GetMagazineViewModel()
        {
            Magazines = new List<MagazineViewModel>();
        }
    }
}