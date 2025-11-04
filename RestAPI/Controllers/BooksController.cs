using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /*
        static private List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "1984",
                Author = "George Orwell",
                PublishedDate = new DateOnly(1949,6,8),
            },
            new Book
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                PublishedDate = new DateOnly(1960,7,11),
            },
            new Book
            {
                Id = 3,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                PublishedDate = new DateOnly(1925,4,10),
            },
            new Book
            {
                Id = 4,
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                PublishedDate = new DateOnly(1951,7,16),
            },
            new Book
            {
                Id = 5,
                Title = "Harry Potter and the Philosopher's Stone",
                Author = "J.K. Rowling",
                PublishedDate = new DateOnly(1997,6,26),
            },
            new Book
            {
                Id = 6,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                PublishedDate = new DateOnly(1937,9,21),
            },
            new Book
            {
                Id = 7,
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                PublishedDate = new DateOnly(1813,1,28),
            },
            new Book
            {
                Id = 8,
                Title = "The Da Vinci Code",
                Author = "Dan Brown",
                PublishedDate = new DateOnly(2003,3,18),
            },
            new Book
            {
                Id = 9,
                Title = "The Road",
                Author = "Cormac McCarthy",
                PublishedDate = new DateOnly(2006,9,26),
            },
            new Book
            {
                Id = 10,
                Title = "The Girl with the Dragon Tattoo",
                Author = "Stieg Larsson",
                PublishedDate = new DateOnly(2005,8,1),
            }
        };*/

        /*
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book newBook)
        {
            if (newBook == null)
                return BadRequest();
            newBook.Id = books.Max(b => b.Id) + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            book.Id = updatedBook.Id;
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.PublishedDate = updatedBook.PublishedDate;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            books.Remove(book);
            return NoContent();
        }*/

        // Instead of using in-memory list, we will use database context
        private readonly Data.BooksContext _context;
        public BooksController(Data.BooksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book newBook)
        {
            if (newBook == null)
                return BadRequest();
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.PublishedDate = updatedBook.PublishedDate;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
