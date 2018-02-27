using AutoMapper;
using Library.DAL.Repositories;
using Library.Entities.Enums;
using Library.Entities.Models;
using Library.ViewModels.Author;
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
        private readonly AuthorRepository _authorRepository;
        private readonly BookAuthorRepository _bookAuthorRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
            _publisherRepository = new PublisherRepository();
            _bookPublisherRepository = new BookPublisherRepository();
            _authorRepository = new AuthorRepository();
            _bookAuthorRepository = new BookAuthorRepository();
        }

        public void Add(PostBookViewModel bookView)
        {
            Book book = Mapper.Map<PostBookViewModel, Book>(bookView);
            book.TypeOfPublication = TypeOfPublication.Book;
            _bookRepository.Add(book);

            AddRelationshipsBookPublisher(book, bookView.Publishers);
            AddRelationshipsBookAuthor(book, bookView.Authors);
        }

        public IEnumerable<GetBookViewModel> GetAll()
        {
            var result = new List<GetBookViewModel>();
            var bookPublishers = _bookPublisherRepository.GetAll().GroupBy(x => x.Book);
            var bookAuthors = _bookAuthorRepository.GetAll().GroupBy(x => x.Book);

            foreach (var bookPublisher in bookPublishers)
            {
                GetBookViewModel bookViewModel = Mapper.Map<GetBookViewModel>(bookPublisher.Key);

                var publishers = bookPublisher.Select(a => a.Publisher);
                var publishersViewModel = Mapper.Map<List<GetPublisherViewModel>>(publishers);
               
                bookViewModel.Publishers.AddRange(publishersViewModel);
                result.Add(bookViewModel);
            }

            foreach (var bookAuthor in bookAuthors)
            {
                var bookViewModel = result.Where(x => x.Id == bookAuthor.Key.Id).SingleOrDefault();

                var authors = bookAuthor.Select(a => a.Author);
                var authorsViewModel = Mapper.Map<List<GetAuthorViewModel>>(authors);

                bookViewModel.Authors.AddRange(authorsViewModel);
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
            _bookAuthorRepository.RemoveByBook(book.Id);

            AddRelationshipsBookPublisher(book, bookView.Publishers);
            AddRelationshipsBookAuthor(book, bookView.Authors);
        }

        private void AddRelationshipsBookPublisher(Book book, List<GetPublisherViewModel> publishers)
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

        private void AddRelationshipsBookAuthor(Book book, List<GetAuthorViewModel> authors)
        {
            List<BookAuthor> bookAuthors = new List<BookAuthor>();

            foreach (var publisher in authors)
            {
                var bookAuthor = new BookAuthor();
                bookAuthor.BookId = book.Id;
                bookAuthor.AuthorId = publisher.Id;
                bookAuthors.Add(bookAuthor);
            }

            _bookAuthorRepository.Add(bookAuthors);
        }
    }
}
