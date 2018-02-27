using AutoMapper;
using Library.Entities.Models;
using Library.ViewModels.Book;

namespace Library.BLL.AutoMapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, GetBookViewModel>()
                .ForMember(x => x.Publishers, opt => opt.Ignore())
                .ForMember(x => x.Authors, opt => opt.Ignore());
            CreateMap<Book, PostBookViewModel>()
                .ForMember(x => x.Publishers, opt => opt.Ignore())
                .ForMember(x => x.Authors, opt => opt.Ignore());
            CreateMap<Book, PutBookViewModel>()
                .ForMember(x => x.Publishers, opt => opt.Ignore())
                .ForMember(x => x.Authors, opt => opt.Ignore());
        }
    }
}
