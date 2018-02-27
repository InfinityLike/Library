using AutoMapper;
using Library.Entities.Models;
using Library.ViewModels.Publisher;

namespace Library.BLL.AutoMapperProfiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, GetPublisherViewModel>()
                .ReverseMap();
            CreateMap<Publisher, PostPublisherViewModel>()
                .ReverseMap();
            CreateMap<Publisher, PutPublisherViewModel>()
                .ReverseMap();
        }
    }
}
