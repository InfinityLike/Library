using System.Collections.Generic;

namespace Library.ViewModels.Brochure
{
    public class GetBrochureViewModel
    {
        public List<BrochureViewModel> Brochures { get; set; }

        public GetBrochureViewModel()
        {
            Brochures = new List<BrochureViewModel>();
        }
    }
}