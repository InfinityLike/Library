﻿using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Enums;
using Library.Entities.Models;
using Library.ViewModels.Magazine;
using System.Collections.Generic;

namespace Library.BLL.Services
{
    public class MagazineService
    {
        private readonly MagazineRepository _magazineRepository;

        public MagazineService()
        {
            _magazineRepository = new MagazineRepository();
        }

        public void Add(PostMagazineViewModel magazineView)
        {
            Magazine magazine = Mapper.Map<PostMagazineViewModel, Magazine>(magazineView);
            magazine.PublicationType = PublicationType.Magazine;
            _magazineRepository.Add(magazine);
        }

        public GetMagazineViewModel GetAll()
        {
            var magazineEntities = _magazineRepository.GetAll();
            var magazineViews = new GetMagazineViewModel();
            magazineViews.Magazines = Mapper.Map<IEnumerable<Magazine>, List<GetMagazineViewItem>>(magazineEntities);
            return magazineViews;
        }

        public void Remove(int id)
        {
            _magazineRepository.Remove(id);
        }

        public void Update(PutMagazineViewModel magazineView)
        {
            Magazine magazine = Mapper.Map<PutMagazineViewModel, Magazine>(magazineView);
            magazine.PublicationType = PublicationType.Magazine;
            _magazineRepository.Update(magazine);
        }
    }
}
