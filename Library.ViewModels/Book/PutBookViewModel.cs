using Library.ViewModels.Author;
using Library.ViewModels.Publication;
using Library.ViewModels.Publisher;
using System;
using System.Collections.Generic;

namespace Library.ViewModels.Book
{
    public class PutBookViewModel : GetPublicationViewItem
    {
        public List<GetAuthorViewItem> Authors { get; set; }

        public DateTime DateOfPublishing { get; set; }

        public List<GetPublisherViewItem> Publishers { get; set; }

        public PutBookViewModel()
        {
            Authors = new List<GetAuthorViewItem>();
            Publishers = new List<GetPublisherViewItem>();
        }
    }
}