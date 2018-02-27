using Library.ViewModels.Author;
using Library.ViewModels.Publication;
using Library.ViewModels.Publisher;
using System;
using System.Collections.Generic;

namespace Library.ViewModels.Book
{
    public class PostBookViewModel : PublicationViewModel
    {
        public List<AuthorViewModel> Authors { get; set; }

        public DateTime DateOfPublishing { get; set; }

        public List<PublisherViewModel> Publishers { get; set; }

        public PostBookViewModel()
        {
            Authors = new List<AuthorViewModel>();
            Publishers = new List<PublisherViewModel>();
        }
    }
}