using Bookstore.Core.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get all books with optional filtering, sorting, and pagination.
        /// </summary>
        /// <param name="author">Optional filter by author name.</param>
        /// <param name="pageNumber">Page number for pagination.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <returns>A list of books in the store.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks(string author = null, int pageNumber = 1, int pageSize = 10)
        {
            var books = _bookService.GetBooks(author, pageNumber, pageSize);
            return Ok(books);
        }

        /// <summary>
        /// Get a specific book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID.</returns>
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound(new { Message = "Book with the specified ID was not found." });
            }

            return book;
        }

        /// <summary>
        /// Update an existing book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="book">The updated book object.</param>
        /// <returns>No content if successful, otherwise appropriate error response.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest(new { Message = "The book ID in the URL does not match the ID in the body." });
            }

            if (!_bookService.UpdateBook(id, book))
            {
                return NotFound(new { Message = "Unable to update. Book with the specified ID was not found." });
            }

            return NoContent();
        }

        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="book">The book object to create.</param>
        /// <returns>The created book object with the assigned ID.</returns>
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid data provided." });
            }

            var addedBook = _bookService.AddBook(book);

            return CreatedAtAction(nameof(GetBook), new { id = addedBook.Id }, addedBook);
        }

        /// <summary>
        /// Delete a book by ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>No content if successful, otherwise appropriate error response.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (!_bookService.DeleteBook(id))
            {
                return NotFound(new { Message = "Unable to delete. Book with the specified ID was not found." });
            }

            return NoContent();
        }
    }
}
