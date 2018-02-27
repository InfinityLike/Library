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

        public IEnumerable<GetPublicationViewModel> GetAll()
        {
            var result = new List<GetPublicationViewModel>();

            var bookEntities = _bookRepository.GetAll();
            var magazineEntities = _magazineRepository.GetAll();
            var brochureEntities = _brochureRepository.GetAll();

            var bookViews = Mapper.Map<IEnumerable<Book>, List<GetBookViewModel>>(bookEntities);
            var magazineViews = Mapper.Map<IEnumerable<Magazine>, List<GetMagazineViewModel>>(magazineEntities);
            var brochureViews = Mapper.Map<IEnumerable<Brochure>, List<GetBrochureViewModel>>(brochureEntities);

            result.AddRange(bookViews);
            result.AddRange(magazineViews);
            result.AddRange(brochureViews);

            return result;
        }
    }
}
