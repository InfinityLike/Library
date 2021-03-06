﻿using AutoMapper;
using Library.Entities.Models;
using Library.ViewModels.Brochure;

namespace Library.BLL.AutoMapperProfiles
{
    public class BrochureProfile : Profile
    {
        public BrochureProfile()
        {
            CreateMap<Brochure, GetBrochureViewItem>()
                .ReverseMap();
            CreateMap<Brochure, PostBrochureViewModel>()
                .ReverseMap();
            CreateMap<Brochure, PutBrochureViewModel>()
                .ReverseMap();
        }
    }
}
