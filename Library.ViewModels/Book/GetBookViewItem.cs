using Library.ViewModels.Author;
using Library.ViewModels.Publication;
using Library.ViewModels.Publisher;
using System;
using System.Collections.Generic;

namespace Library.ViewModels.Book
{
    public class GetBookViewItem : GetPublicationViewItem
    {
        public List<GetAuthorViewItem> Authors { get; set; }

        public DateTime DateOfPublishing { get; set; }

        public List<GetPublisherViewItem> Publishers { get; set; }

        public GetBookViewItem()
        {
            Authors = new List<GetAuthorViewItem>();
            Publishers = new List<GetPublisherViewItem>();
        }
    }
}
