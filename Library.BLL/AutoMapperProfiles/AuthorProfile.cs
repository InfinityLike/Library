using AutoMapper;
using Library.Entities.Models;
using Library.ViewModels.Author;
using Library.ViewModels.Book;

namespace Library.BLL.AutoMapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>()
                    .ReverseMap();
            CreateMap<Author, PostAuthorViewModel>()
                    .ReverseMap();
            CreateMap<Author, PutAuthorViewModel>()
                    .ReverseMap();
        }
    }
}
