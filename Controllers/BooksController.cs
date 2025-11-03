using Microsoft.AspNetCore.Mvc;
using Library_BasicCRUD.Models;
using Library_BasicCRUD.Services;

namespace Library_BasicCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _booksService.GetAll();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _booksService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            _booksService.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book updatedBook)
        {
            var result = _booksService.Update(id, updatedBook);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _booksService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
