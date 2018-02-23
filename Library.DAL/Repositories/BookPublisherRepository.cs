using System.Collections.Generic;
using System.Linq;
using Library.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repositories
{
    public class BookPublisherRepository : GenericRepository<BookPublisher>
    {
        public override IEnumerable<BookPublisher> GetAll()
        {
            var result = _context.Set<BookPublisher>()
                        .Include(book => book.Book)
                        .Include(publisher => publisher.Publisher)
                        .ToList();
            return result;
        }

        public void RemoveByBook(int id)
        {
            var item = _dbSet.Where(x=>x.BookId == id);
            if (item != null)
            {
                _dbSet.RemoveRange(item);
                _context.SaveChanges();
            }
        }
    }
}
