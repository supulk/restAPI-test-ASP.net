using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTBooks.Models;
using RESTBooks.Data;
using RESTBooks.Dto;
using RESTBooks.DTO;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RESTBooks.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStore bookStore;
        public BooksController(BookStore bookStore)
        {
            this.bookStore = bookStore;
        }


        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> getAllBooks(BookStore bookStore) {
            var books = bookStore.getAllBooks().Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublicationDate = b.PublicationDate
            });
            return Ok(books);
        }


        [HttpPost]
        public IActionResult addBook([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublicationDate = dto.PublicationDate
            };

            bookStore.addBook(book);
            return Ok("Book Added " + book.Title);
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] CreateBookDto dto) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublicationDate = dto.PublicationDate
            };
            var result = bookStore.updateBook(book);
            if (result == "1")
                return Ok("Book Updated");
            else
            {
                return BadRequest("Did not find the book at ID : " + book.Id);
            }
        }

        [HttpDelete]
        public IActionResult DeleteBook([FromBody] int id) {
                var result = bookStore.deleteBook(id);
                if (result)
                    return Ok("Book Deleted");
                else
                {
                    return NotFound("Book with ID not found."); ;
                }
        }
    }
}
