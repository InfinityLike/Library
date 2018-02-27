using System.Collections.Generic;

namespace Library.ViewModels.Author
{
    public class GetAuthorViewModel
    {
        public List<GetAuthorViewItem> Authors { get; set; }

        public GetAuthorViewModel()
        {
            Authors = new List<GetAuthorViewItem>();
        }
    }
}
