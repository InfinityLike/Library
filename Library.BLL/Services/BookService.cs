using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Enums;
using Library.Entities.Models;
using Library.ViewModels;
using Library.ViewModels.Book;
using Library.ViewModels.Publisher;
using System.Collections.Generic;
using System.Linq;

namespace Library.BLL.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;
        private readonly PublisherRepository _publisherRepository;
        private readonly BookPublisherRepository _bookPublisherRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
            _publisherRepository = new PublisherRepository();
            _bookPublisherRepository = new BookPublisherRepository();
        }

        public void Add(PostBookViewModel bookView)
        {
            Book book = Mapper.Map<PostBookViewModel, Book>(bookView);
            book.TypeOfPublication = TypeOfPublication.Book;
            _bookRepository.Add(book);

            AddRelationships(book, bookView.Publishers);
        }

        public IEnumerable<GetBookViewModel> GetAll()
        {
            var result = new List<GetBookViewModel>();
            var bookPublishers = _bookPublisherRepository.GetAll().GroupBy(x => x.Book);

            foreach (var bookPublisher in bookPublishers)
            {
                GetBookViewModel bookViewModel = Mapper.Map<GetBookViewModel>(bookPublisher.Key);

                var publishers = bookPublisher.Select(a=>a.Publisher);
                var publishersViewModel = Mapper.Map<List<GetPublisherViewModel>>(publishers);

                bookViewModel.Publishers.AddRange(publishersViewModel);
                result.Add(bookViewModel);
            }

            return result;
        }

        public void Remove(int id)
        {
            _bookRepository.Remove(id);
        }

        public void Update(PutBookViewModel bookView)
        {
            Book book = Mapper.Map<PutBookViewModel, Book>(bookView);
            _bookRepository.Update(book);

            _bookPublisherRepository.RemoveByBook(book.Id);

            AddRelationships(book, bookView.Publishers);
        }

        private void AddRelationships(Book book, List<GetPublisherViewModel> publishers)
        {
            List<BookPublisher> bookPublishers = new List<BookPublisher>();

            foreach (var publisher in publishers)
            {
                var bookPublisher = new BookPublisher();
                bookPublisher.BookId = book.Id;
                bookPublisher.PublisherId = publisher.Id;
                bookPublishers.Add(bookPublisher);
            }

            _bookPublisherRepository.Add(bookPublishers);
        }
    }
}
