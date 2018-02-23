namespace Library.ViewModels.Magazine
{
    public class GetMagazineViewModel : GetPublicationViewModel
    {
        public int Number { get; set; }

        public int YearOfPublishing { get; set; }
    }
}