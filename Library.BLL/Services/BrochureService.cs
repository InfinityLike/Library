using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Enums;
using Library.Entities.Models;
using Library.ViewModels;
using Library.ViewModels.Brochure;
using System.Collections.Generic;

namespace Library.BLL.Services
{
    public class BrochureService
    {
        private readonly BrochureRepository _brochureRepository;

        public BrochureService()
        {
            _brochureRepository = new BrochureRepository();
        }

        public void Add(PostBrochureViewModel brochureView)
        {
            Brochure brochure = Mapper.Map<PostBrochureViewModel, Brochure>(brochureView);
            brochure.TypeOfPublication = TypeOfPublication.Brochure;
            _brochureRepository.Add(brochure);
        }

        public IEnumerable<GetBrochureViewModel> GetAll()
        {
            var result = Mapper.Map<IEnumerable<Brochure>, List<GetBrochureViewModel>>(_brochureRepository.GetAll());
            return result;
        }

        public void Remove(int id)
        {
            _brochureRepository.Remove(id);
        }

        public void Update(PutBrochureViewModel brochureView)
        {
            Brochure brochure = Mapper.Map<PutBrochureViewModel, Brochure>(brochureView);
            _brochureRepository.Update(brochure);
        }
    }
}
