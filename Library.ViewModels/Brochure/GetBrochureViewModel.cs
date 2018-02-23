namespace Library.ViewModels.Brochure
{
    public class GetBrochureViewModel : GetPublicationViewModel
    {
        public string TypeOfCover { get; set; }

        public int NumberOfPages { get; set; }
    }
}