using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Models;
using Library.ViewModels.Author;
using System.Collections.Generic;

namespace Library.BLL.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService()
        {
            _authorRepository = new AuthorRepository();
        }

        public void Add(PostAuthorViewModel authorView)
        {
            Author publisher = Mapper.Map<PostAuthorViewModel, Author>(authorView);
            _authorRepository.Add(publisher);
        }

        public IEnumerable<GetAuthorViewModel> GetAll()
        {
            var authorEntities = _authorRepository.GetAll();
            var authorViews = Mapper.Map<IEnumerable<Author>, List<GetAuthorViewModel>>(authorEntities);
            return authorViews;
        }

        public void Remove(int id)
        {
            _authorRepository.Remove(id);
        }

        public void Update(PutAuthorViewModel authorView)
        {
            Author author = Mapper.Map<PutAuthorViewModel, Author>(authorView);
            _authorRepository.Update(author);
        }
    }
}
