using Library.ViewModels.Publication;
using System;

namespace Library.ViewModels.Magazine
{
    public class PostMagazineViewModel : GetPublicationViewItem
    {
        public int Number { get; set; }

        public DateTime DateOfPublishing { get; set; }
    }
}