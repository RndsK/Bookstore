using Bookstore.Core.Models;
using Bookstore.Core.Services;
using Bookstore.Data;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services
{
    public class BookService : EntityService<Book>, IBookService
    {
        private readonly BookStoreDbContext _context;

        public BookService(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks(string author = null, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(b => b.Author.Contains(author));
            }

            return query
                .OrderBy(b => b.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Book? GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public bool UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return false;
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Books.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return true;
        }
    }
}
