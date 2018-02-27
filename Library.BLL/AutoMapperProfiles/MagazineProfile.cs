using AutoMapper;
using Library.Entities.Models;
using Library.ViewModels.Magazine;

namespace Library.BLL.AutoMapperProfiles
{
    public class MagazineProfile : Profile
    {
        public MagazineProfile()
        {
            CreateMap<Magazine, GetMagazineViewItem>()
                .ReverseMap();
            CreateMap<Magazine, PostMagazineViewModel>()
                .ReverseMap();
            CreateMap<Magazine, PutMagazineViewModel>()
                .ReverseMap();
        }
    }
}
