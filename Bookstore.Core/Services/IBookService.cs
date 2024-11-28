using Bookstore.Core.Models;

namespace Bookstore.Core.Services
{
    public interface IBookService : IEntityService<Book>
    {
        public IEnumerable<Book?> GetBooks(string author, int pageNumber, int pageSize);
        public Book? GetBookById(int id);
        public Book AddBook(Book book);
        public bool UpdateBook(int id, Book book);
        public bool DeleteBook(int id);
    }
}
