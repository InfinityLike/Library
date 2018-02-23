namespace Library.ViewModels.Magazine
{
    public class PutMagazineViewModel : GetPublicationViewModel
    {
        public int Number { get; set; }

        public int YearOfPublishing { get; set; }
    }
}