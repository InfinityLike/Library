using Library.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Repositories
{
    public class BookAuthorRepository : GenericRepository<BookAuthor>
    {
        public override IEnumerable<BookAuthor> GetAll()
        {
            var result = _context.Set<BookAuthor>()
                        .Include(book => book.Book)
                        .Include(author => author.Author)
                        .ToList();
            return result;
        }

        public void RemoveByBook(int id)
        {
            var item = _dbSet.Where(x => x.BookId == id);
            if (item != null)
            {
                _dbSet.RemoveRange(item);
                _context.SaveChanges();
            }
        }
    }
}
