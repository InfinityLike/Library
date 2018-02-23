using AutoMapper;
using Library.Entities.Models;
using Library.ViewModels.Publisher;

namespace Library.BLL.AutoMapperProfiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, GetPublisherViewModel>();
            CreateMap<Publisher, PostPublisherViewModel>();
            CreateMap<Publisher, PutPublisherViewModel>();
                //.ForMember(a => a.Books, opt => opt.MapFrom(x => x.Books.Select(y => y.Book).ToList()));
        }
    }
}
