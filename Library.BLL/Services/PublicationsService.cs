using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Models;
using Library.ViewModels;
using Library.ViewModels.Book;
using Library.ViewModels.Brochure;
using Library.ViewModels.Magazine;
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

            var books = Mapper.Map<IEnumerable<Book>, List<GetBookViewModel>>(_bookRepository.GetAll());
            var magazines = Mapper.Map<IEnumerable<Magazine>, List<GetMagazineViewModel>>(_magazineRepository.GetAll());
            var brochures = Mapper.Map<IEnumerable<Brochure>, List<GetBrochureViewModel>>(_brochureRepository.GetAll());

            //result.AddRange(books);
            result.AddRange(magazines);
            result.AddRange(brochures);

            return result;
        }
    }
}
