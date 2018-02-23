namespace Library.ViewModels.Brochure
{
    public class PutBrochureViewModel : GetPublicationViewModel
    {
        public string TypeOfCover { get; set; }

        public int NumberOfPages { get; set; }
    }
}