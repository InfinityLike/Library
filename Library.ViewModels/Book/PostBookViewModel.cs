using Library.ViewModels.Publisher;
using System.Collections.Generic;

namespace Library.ViewModels.Book
{
    public class PostBookViewModel : GetPublicationViewModel
    {
        public string Author { get; set; }

        public int YearOfPublishing { get; set; }

        public List<GetPublisherViewModel> Publishers { get; set; }

        public PostBookViewModel()
        {
            Publishers = new List<GetPublisherViewModel>();
        }
    }
}