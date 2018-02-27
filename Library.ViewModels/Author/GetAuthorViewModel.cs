using System.Collections.Generic;

namespace Library.ViewModels.Author
{
    public class GetAuthorViewModel
    {
        public List<AuthorViewModel> Authors { get; set; }

        public GetAuthorViewModel()
        {
            Authors = new List<AuthorViewModel>();
        }
    }
}
