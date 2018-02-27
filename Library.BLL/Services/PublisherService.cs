using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Models;
using Library.ViewModels.Publisher;
using System.Collections.Generic;

namespace Library.BLL.Services
{
    public class PublisherService
    {
        private readonly PublisherRepository _publisherRepository;

        public PublisherService()
        {
            _publisherRepository = new PublisherRepository();
        }

        public void Add(PostPublisherViewModel publisherView)
        {
            Publisher publisher = Mapper.Map<PostPublisherViewModel, Publisher>(publisherView);
            _publisherRepository.Add(publisher);
        }

        public IEnumerable<GetPublisherViewModel> GetAll()
        {
            var publisherEntities = _publisherRepository.GetAll();
            var publisherViews = Mapper.Map<IEnumerable<Publisher>, List<GetPublisherViewModel>>(publisherEntities);
            return publisherViews;
        }

        public void Remove(int id)
        {
            _publisherRepository.Remove(id);
        }

        public void Update(PutPublisherViewModel publisherView)
        {
            Publisher publisher = Mapper.Map<PutPublisherViewModel, Publisher>(publisherView);
            _publisherRepository.Update(publisher);
        }
    }
}
