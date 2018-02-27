using Library.ViewModels.Publication;
using System;

namespace Library.ViewModels.Magazine
{
    public class MagazineViewModel: PublicationViewModel
    {
        public int Number { get; set; }

        public DateTime DateOfPublishing { get; set; }
    }
}
