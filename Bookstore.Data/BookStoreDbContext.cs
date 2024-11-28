using Bookstore.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
        public DbSet<Book?> Books { get; set; }
    }
}
