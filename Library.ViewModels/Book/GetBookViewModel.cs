using System.Collections.Generic;

namespace Library.ViewModels.Book
{
    public class GetBookViewModel
    {
        public List<GetBookViewItem> Books { get; set; }

        public GetBookViewModel()
        {
            Books = new List<GetBookViewItem>();
        }
    }
}