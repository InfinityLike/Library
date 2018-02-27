using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Models;
using Library.ViewModels.Book;
using Library.ViewModels.Brochure;
using Library.ViewModels.Magazine;
using Library.ViewModels.Publication;
using System.Collections.Generic;

namespace Library.BLL.Services
{
    public class PublicationsService
    {
        private readonly BookRepository _bookRepository;
        private readonly MagazineRepository _magazineRepository;
        private readonly BrochureRepository _brochureRepository;

        public PublicationsService()
        {
            _bookRepository = new BookRepository();
            _magazineRepository = new MagazineRepository();
            _brochureRepository = new BrochureRepository();
        }

        public GetPublicationViewModel GetAll()
        {
            var publicationView = new List<PublicationViewModel>();

            var bookEntities = _bookRepository.GetAll();
            var magazineEntities = _magazineRepository.GetAll();
            var brochureEntities = _brochureRepository.GetAll();

            var bookViews = Mapper.Map<IEnumerable<Book>, List<BookViewModel>>(bookEntities);
            var magazineViews = Mapper.Map<IEnumerable<Magazine>, List<MagazineViewModel>>(magazineEntities);
            var brochureViews = Mapper.Map<IEnumerable<Brochure>, List<BrochureViewModel>>(brochureEntities);

            publicationView.AddRange(bookViews);
            publicationView.AddRange(magazineViews);
            publicationView.AddRange(brochureViews);

            var result = new GetPublicationViewModel();
            result.Publications = publicationView;

            return result;
        }
    }
}
