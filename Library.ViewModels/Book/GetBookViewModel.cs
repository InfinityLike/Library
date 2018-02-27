using Library.ViewModels.Author;
using Library.ViewModels.Publication;
using Library.ViewModels.Publisher;
using System;
using System.Collections.Generic;

namespace Library.ViewModels.Book
{
    public class GetBookViewModel : GetPublicationViewModel
    {
        public List<GetAuthorViewModel> Authors { get; set; }

        public DateTime DateOfPublishing { get; set; }

        public List<GetPublisherViewModel> Publishers { get; set; }

        public GetBookViewModel()
        {
            Authors = new List<GetAuthorViewModel>();
            Publishers = new List<GetPublisherViewModel>();
        }
    }
}